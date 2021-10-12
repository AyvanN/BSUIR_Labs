from src import Serializer as ser
import argparse

def main():
    parser = argparse.ArgumentParser(description="ArgParser")
    parser.add_argument('src', type=str, help='Source file')
    parser.add_argument('dest', type=str, help='Destination file')
    parser.add_argument('ext', type=str, help='New file extension')

    argv = parser.parse_args()

    src_ext = argv.src.split('.')[-1]

    if src_ext == argv.ext.lower():
        pass
    else:
        serializer = ser.Serializer(argv.src, src_ext)
        obj = serializer.load()
        serializer.path = argv.dest
        serializer.extension = argv.ext.lower()
        serializer.dump(obj)
        print(f"Succefully redumped from .{src_ext} to .{argv.ext.lower()}")

if __name__ == "__main__":
    main()