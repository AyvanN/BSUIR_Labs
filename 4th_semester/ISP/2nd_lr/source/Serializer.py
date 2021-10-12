from src.Factory import SerializerFactory as sf

class Serializer():

    def __init__(self, path="", extension='json'):
        self._path = path
        self._extension = extension
        self.factory = sf.SerializerFactory(self._path)
        self.serializer = self.factory.create_serializer(self._extension)

    @property
    def path(self):
        return self._path

    @path.setter
    def path(self, path):
        self._path = path
        self.factory = sf.SerializerFactory(self._path)
        self.serializer = self.factory.create_serializer(self._path)

    @property
    def extension(self):
        return self._extension

    @extension.setter
    def extension(self, extension):
        self._extension = extension
        self.serializer = self.factory.create_serializer(self._extension)

    def dump(self, obj):
        self.serializer.dump(obj)

    def dumps(self, obj):
        return self.serializer.dumps(obj)

    def load(self):
        return self.serializer.load()

    def loads(self, obj_str):
        return self.serializer.loads(obj_str)