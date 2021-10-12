from src.packer import packer, unpacker
import pickle


class PickleSerializer:
    def __init__(self, path: str):
        self.path = path
        self.packer = packer.Packer()
        self.unpacker = unpacker.Unpacker()

    def dump(self, obj: object):
        obj_dict = self.packer.pack(obj)
        with open(self.path, "wb") as file:
            pickle.dump(obj_dict, file)

    def dumps(self, obj: object):
        obj_dict = self.packer.pack(obj)
        result_string = pickle.dumps(obj_dict)
        return result_string

    def load(self):
        obj_dict = {}
        with open(self.path, "rb") as file:
            obj_dict = pickle.load(file)
        obj = self.unpacker.unpack(obj_dict)  # may be make both packer and unpacker callable
        return obj

    def loads(self, obj_str: str):
        obj_dict = pickle.loads(obj_str)
        obj = self.unpacker.unpack(obj_dict)
        return obj
