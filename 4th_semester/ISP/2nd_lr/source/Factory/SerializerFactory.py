from src.JsonSerializer import JsonSerializer as js
from src.PickleSerializer import PickleSerializer as ps
# from src.TomlSerializer import TomlSerializer as ts
from src.YamlSerializer import YamlSerializer as ys

class SerializerFactory:
    def __init__(self, path: str):
        self.path = path

    def create_serializer(self, extension="json"):
        if extension.lower() == "json":
            return js.JsonSerializer(self.path)
        elif extension.lower() == "pickle":
            return ps.PickleSerializer(self.path)
        # elif extension.lower() == "toml":
            # return ts.TomlSerializer(self.path)
        elif extension.lower() == "yaml":
            return ys.YamlSerializer(self.path)
