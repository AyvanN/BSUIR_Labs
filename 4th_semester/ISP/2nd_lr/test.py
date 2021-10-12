from tests.test_objects import *
import unittest

import sys

from src import Serializer as ser


class SerializerTester(unittest.TestCase):

    def __init__(self, method):
        super().__init__(method)
        self.json_serializer = ser.Serializer()
        path = self.json_serializer.path
        self.json_serializer.path = json_file
        ext = self.json_serializer.extension
        self.json_serializer.extension = 'json'
        self.pickle_serializer = ser.Serializer(path=pickle_file, extension='pickle')
        self.yaml_serializer = ser.Serializer(path=yaml_file, extension='yaml')

    def test_str(self):
        json_obj = self.json_serializer.loads(self.json_serializer.dumps(str1))
        pickle_obj = self.pickle_serializer.loads(self.pickle_serializer.dumps(str1))
        yaml_obj = self.yaml_serializer.loads(self.yaml_serializer.dumps(str1))

        self.assertEqual(json_obj, str1)
        self.assertEqual(pickle_obj, str1)
        self.assertEqual(yaml_obj, str1)

    def test_int(self):
        json_obj = self.json_serializer.loads(self.json_serializer.dumps(num1))
        pickle_obj = self.pickle_serializer.loads(self.pickle_serializer.dumps(num1))
        yaml_obj = self.yaml_serializer.loads(self.yaml_serializer.dumps(num1))

        self.assertEqual(json_obj, num1)
        self.assertEqual(pickle_obj, num1)
        self.assertEqual(yaml_obj, num1)

    def test_float(self):
        json_obj = self.json_serializer.loads(self.json_serializer.dumps(flot1))
        pickle_obj = self.pickle_serializer.loads(self.pickle_serializer.dumps(flot1))
        yaml_obj = self.yaml_serializer.loads(self.yaml_serializer.dumps(flot1))

        self.assertEqual(json_obj, flot1)
        self.assertEqual(pickle_obj, flot1)
        self.assertEqual(yaml_obj, flot1)

    def test_bool(self):
        json_obj = self.json_serializer.loads(self.json_serializer.dumps(bool1))
        pickle_obj = self.pickle_serializer.loads(self.pickle_serializer.dumps(bool1))
        yaml_obj = self.yaml_serializer.loads(self.yaml_serializer.dumps(bool1))

        self.assertEqual(json_obj, bool1)
        self.assertEqual(pickle_obj, bool1)
        self.assertEqual(yaml_obj, bool1)

    def test_bytes(self):
        json_obj = self.json_serializer.loads(self.json_serializer.dumps(bytes1))
        pickle_obj = self.pickle_serializer.loads(self.pickle_serializer.dumps(bytes1))
        yaml_obj = self.yaml_serializer.loads(self.yaml_serializer.dumps(bytes1))

        self.assertEqual(json_obj, bytes1)
        self.assertEqual(pickle_obj, bytes1)
        self.assertEqual(yaml_obj, bytes1)

    def test_bytearray(self):
        json_obj = self.json_serializer.loads(self.json_serializer.dumps(bytearr1))
        pickle_obj = self.pickle_serializer.loads(self.pickle_serializer.dumps(bytearr1))
        yaml_obj = self.yaml_serializer.loads(self.yaml_serializer.dumps(bytearr1))

        self.assertEqual(json_obj, bytearr1)
        self.assertEqual(pickle_obj, bytearr1)
        self.assertEqual(yaml_obj, bytearr1)

    def test_builtin(self):
        json_obj = self.json_serializer.loads(self.json_serializer.dumps(bltfunc))
        pickle_obj = self.pickle_serializer.loads(self.pickle_serializer.dumps(bltfunc))
        yaml_obj = self.yaml_serializer.loads(self.yaml_serializer.dumps(bltfunc))

        self.assertEqual(json_obj(lst1), bltfunc(lst1))
        self.assertEqual(pickle_obj(lst1), bltfunc(lst1))
        self.assertEqual(yaml_obj(lst1), bltfunc(lst1))

    def test_set(self):
        json_obj = self.json_serializer.loads(self.json_serializer.dumps(set1))
        pickle_obj = self.pickle_serializer.loads(self.pickle_serializer.dumps(set1))
        yaml_obj = self.yaml_serializer.loads(self.yaml_serializer.dumps(set1))
        # toml_obj = self.toml_serializer.loads(self.toml_serializer.dumps(lst1))

        self.assertEqual(json_obj, set1)
        self.assertEqual(pickle_obj, set1)
        self.assertEqual(yaml_obj, set1)
        # self.assertEqual(toml_obj, lst1)

    def test_frozenset(self):
        json_obj = self.json_serializer.loads(self.json_serializer.dumps(frzset1))
        pickle_obj = self.pickle_serializer.loads(self.pickle_serializer.dumps(frzset1))
        yaml_obj = self.yaml_serializer.loads(self.yaml_serializer.dumps(frzset1))
        # toml_obj = self.toml_serializer.loads(self.toml_serializer.dumps(lst1))

        self.assertEqual(json_obj, frzset1)
        self.assertEqual(pickle_obj, frzset1)
        self.assertEqual(yaml_obj, frzset1)
        # self.assertEqual(toml_obj, lst1)

    def test_tuple(self):
        json_obj = self.json_serializer.loads(self.json_serializer.dumps(tpl1))
        pickle_obj = self.pickle_serializer.loads(self.pickle_serializer.dumps(tpl1))
        yaml_obj = self.yaml_serializer.loads(self.yaml_serializer.dumps(tpl1))
        # toml_obj = self.toml_serializer.loads(self.toml_serializer.dumps(lst1))

        self.assertEqual(json_obj, tpl1)
        self.assertEqual(pickle_obj, tpl1)
        self.assertEqual(yaml_obj, tpl1)
        # self.assertEqual(toml_obj, lst1)

    def test_list(self):
        json_obj = self.json_serializer.loads(self.json_serializer.dumps(lst1))
        pickle_obj = self.pickle_serializer.loads(self.pickle_serializer.dumps(lst1))
        yaml_obj = self.yaml_serializer.loads(self.yaml_serializer.dumps(lst1))
        # toml_obj = self.toml_serializer.loads(self.toml_serializer.dumps(lst1))

        self.assertEqual(json_obj, lst1)
        self.assertEqual(pickle_obj, lst1)
        self.assertEqual(yaml_obj, lst1)
        # self.assertEqual(toml_obj, lst1)

    def test_simple_dicts(self):
        json_obj = self.json_serializer.loads(self.json_serializer.dumps(dict1))
        pickle_obj = self.pickle_serializer.loads(self.pickle_serializer.dumps(dict1))
        yaml_obj = self.yaml_serializer.loads(self.yaml_serializer.dumps(dict1))
        # toml_obj = self.toml_serializer.loads(self.toml_serializer.dumps(dict1))
        # print(toml_obj.a)
        # print(toml_obj.b)
        # print(toml_obj)

        self.assertEqual(json_obj, dict1)
        self.assertEqual(pickle_obj, dict1)
        self.assertEqual(yaml_obj, dict1)
        # self.assertEqual(toml_obj, dict1)

    def test_simple_object(self):
        json_obj = self.json_serializer.loads(self.json_serializer.dumps(obj1))
        pickle_obj = self.pickle_serializer.loads(self.pickle_serializer.dumps(obj1))
        yaml_obj = self.yaml_serializer.loads(self.yaml_serializer.dumps(obj1))
        # toml_obj = self.toml_serializer.loads(self.toml_serializer.dumps(obj1))

        self.assertEqual(json_obj.a, obj1.a)
        self.assertEqual(json_obj.b, obj1.b)
        self.assertEqual(pickle_obj.a, obj1.a)
        self.assertEqual(pickle_obj.b, obj1.b)
        self.assertEqual(yaml_obj.a, obj1.a)
        self.assertEqual(yaml_obj.b, obj1.b)

    def test_classes(self):
        json_obj = self.json_serializer.loads(self.json_serializer.dumps(cls1))
        pickle_obj = self.pickle_serializer.loads(self.pickle_serializer.dumps(cls1))
        yaml_obj = self.yaml_serializer.loads(self.yaml_serializer.dumps(cls1))

        self.assertEqual(json_obj.__bases__[0].__name__, cls1.__bases__[0].__name__)
        self.assertEqual(pickle_obj.__bases__[0].__name__, cls1.__bases__[0].__name__)
        self.assertEqual(yaml_obj.__bases__[0].__name__, cls1.__bases__[0].__name__)
        self.assertEqual(json_obj.__bases__[1].__name__, cls1.__bases__[1].__name__)
        self.assertEqual(pickle_obj.__bases__[1].__name__, cls1.__bases__[1].__name__)
        self.assertEqual(yaml_obj.__bases__[1].__name__, cls1.__bases__[1].__name__)

    def test_simple_function(self):
        json_obj = self.json_serializer.loads(self.json_serializer.dumps(hello))
        pickle_obj = self.pickle_serializer.loads(self.pickle_serializer.dumps(hello))
        yaml_obj = self.yaml_serializer.loads(self.yaml_serializer.dumps(hello))
        # toml_obj = self.toml_serializer.loads(self.toml_serializer.dumps(hello))

        self.assertEqual(json_obj(), exp_hello)
        self.assertEqual(pickle_obj(), exp_hello)
        self.assertEqual(yaml_obj(), exp_hello)

    def test_functions_with_global_variable(self):
        json_obj = self.json_serializer.loads(self.json_serializer.dumps(say_hello))
        pickle_obj = self.pickle_serializer.loads(self.pickle_serializer.dumps(say_hello))
        yaml_obj = self.yaml_serializer.loads(self.yaml_serializer.dumps(say_hello))

        self.assertEqual(json_obj(), exp_say_hello)
        self.assertEqual(pickle_obj(), exp_say_hello)
        self.assertEqual(yaml_obj(), exp_say_hello)

    def test_function_with_parameters(self):
        json_obj = self.json_serializer.loads(self.json_serializer.dumps(add))
        pickle_obj = self.pickle_serializer.loads(self.pickle_serializer.dumps(add))
        yaml_obj = self.yaml_serializer.loads(self.yaml_serializer.dumps(add))
        # toml_obj = self.toml_serializer.loads(self.toml_serializer.dumps(add))

        self.assertEqual(json_obj(2, 3), exp_add)
        self.assertEqual(pickle_obj(2, 3), exp_add)
        self.assertEqual(yaml_obj(2, 3), exp_add)
        # self.assertEqual(toml_obj(2, 3), exp_add)

    def test_file_io(self):
        self.json_serializer.dump(add)
        self.pickle_serializer.dump(add)
        self.yaml_serializer.dump(add)
        json_obj = self.json_serializer.load()
        pickle_obj = self.pickle_serializer.load()
        yaml_obj = self.yaml_serializer.load()

        self.assertEqual(json_obj(2, 3), exp_add)
        self.assertEqual(pickle_obj(2, 3), exp_add)
        self.assertEqual(yaml_obj(2, 3), exp_add)

    def test_lambda(self):
        json_obj = self.json_serializer.loads(self.json_serializer.dumps(power))
        pickle_obj = self.pickle_serializer.loads(self.pickle_serializer.dumps(power))
        yaml_obj = self.yaml_serializer.loads(self.yaml_serializer.dumps(power))

        self.assertEqual(json_obj(2, 3), exp_power)
        self.assertEqual(pickle_obj(2, 3), exp_power)
        self.assertEqual(yaml_obj(2, 3), exp_power)
