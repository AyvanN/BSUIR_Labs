import types
import importlib
import builtins
import inspect
import sys


class Packer:
    def __init__(self):
        self.mod = importlib.import_module(__name__)

    def is_instance(self, obj):
        if not hasattr(obj, "__dict__"):
            return False
        if inspect.isroutine(obj):
            return False
        if inspect.isclass(obj):
            return False
        if inspect.ismodule(obj):
            return False
        else:
            if not hasattr(obj, '__module__'): return
            mod = importlib.import_module(obj.__module__)
            if obj.__class__.__name__ in dict(
                inspect.getmembers(mod, inspect.isclass)
            ):
                return True
            else:
                return False

    def pack_instance(self, obj):
        obj_dict = {}
        obj_dict["class"] = obj.__class__
        obj_dict["dict"] = obj.__dict__
        return obj_dict

    def get_closure_globs(self, obj, globs):
        if hasattr(obj, '__code__'):
            code_obj = obj.__code__
            for var in code_obj.co_consts:
                self.get_closure_globs(var, globs)
            for name in code_obj.co_names:
                if name in obj.__globals__.keys() and name != obj.__name__:
                    globs[name] = obj.__globals__[name]
                elif name in dir(builtins):
                    globs[name] = getattr(builtins, name)

    def pack_class(self, obj):
        obj_dict = {}
        obj_dict["__name__"] = obj.__name__
        obj_dict["__bases__"] = tuple(
            [base for base in obj.__bases__ if not base is object]
        )
        obj_dict["__dict__"] = dict(obj.__dict__)
        return obj_dict

    def get_codeobject_attrs(self, obj):
        if isinstance(obj, types.CodeType):
            obj_dict = {}
            for key in dir(obj):
                if key.startswith("co_"):
                    value = obj.__getattribute__(key)
                    obj_dict[key] = value
            return obj_dict

    def pack_function(self, obj):
        obj_dict = {}
        attrs = {}
        attrs["__name__"] = obj.__qualname__
        attrs["__defaults__"] = obj.__defaults__
        attrs["__closure__"] = obj.__closure__
        attrs["__code__"] = obj.__code__
        global_ns = {}
        self.get_closure_globs(obj, global_ns)
        obj_dict["__globals__"] = global_ns
        obj_dict["attributes"] = attrs
        return obj_dict

    def pack_builtinfunction(self, obj):
        obj_dict = {}
        obj_dict["type"] = "builtinfunction"
        obj_dict["module"] = obj.__module__
        obj_dict["attributes"] = {"__name__": obj.__name__}
        return obj_dict

    def pack(self, obj):
        obj_dict = {}

        if type(obj) in (int, float, str, bool):
            if type(obj) == int:
                obj_dict["type"] = "int"
                obj_dict["data"] = obj
                return obj_dict
            elif type(obj) == float:
                obj_dict["type"] = "float"
                obj_dict["data"] = obj
                return obj_dict
            elif type(obj) == bool:
                obj_dict["type"] = "bool"
                obj_dict["data"] = obj
                return obj_dict
            elif type(obj) == str:
                obj_dict["type"] = "str"
                obj_dict["data"] = obj
                return obj_dict

        if type(obj) in (dict, list, tuple, set, frozenset):
            if isinstance(obj, dict):
                obj_dict["type"] = "dict"
                obj_dict["data"] = {key: self.pack(val) for key, val in obj.items()}
                return obj_dict
            if isinstance(obj, list):
                obj_dict["type"] = "list"
                obj_dict["data"] = [self.pack(el) for el in obj]
                return obj_dict
            if isinstance(obj, tuple):
                obj_dict["type"] = "tuple"
                obj_dict["data"] = [self.pack(el) for el in obj]
                return obj_dict
            if isinstance(obj, list):
                obj_dict["type"] = "set"
                obj_dict["data"] = [self.pack(el) for el in obj]
                return obj_dict
            if isinstance(obj, set):
                obj_dict["type"] = "set"
                obj_dict["data"] = [self.pack(el) for el in obj]
                return obj_dict
            if isinstance(obj, frozenset):
                obj_dict["type"] = "frozenset"
                obj_dict["data"] = [self.pack(el) for el in obj]
                return obj_dict

        if isinstance(obj, bytes):
            obj_dict["type"] = "bytes"
            obj_dict["data"] = [byte for byte in obj]
            return obj_dict

        if isinstance(obj, bytearray):
            obj_dict["type"] = "bytearray"
            obj_dict["data"] = [byte for byte in obj]
            return obj_dict

        if isinstance(obj, types.CodeType):
            obj_dict["type"] = "codeobject"
            obj_dict["data"] = self.pack(self.get_codeobject_attrs(obj))
            return obj_dict

        if isinstance(obj, types.FunctionType):
            obj_dict["type"] = "function"
            obj_dict["data"] = self.pack(self.pack_function(obj))
            return obj_dict

        if isinstance(obj, types.BuiltinFunctionType):
            obj_dict["type"] = "builtinfunction"
            obj_dict["data"] = self.pack(self.pack_builtinfunction(obj))
            return obj_dict

        if isinstance(obj, types.CellType):
            obj_dict["type"] = "celltype"
            obj_dict["data"] = self.pack(obj.cell_contents)
            return obj_dict

        if isinstance(obj, type):
            obj_dict["type"] = "class"
            obj_dict["data"] = self.pack(self.pack_class(obj))
            return obj_dict

        if self.is_instance(obj):
            obj_dict["type"] = "instance"
            obj_dict["data"] = self.pack(self.pack_instance(obj))
            return obj_dict