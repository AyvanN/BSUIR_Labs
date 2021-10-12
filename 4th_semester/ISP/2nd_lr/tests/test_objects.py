from collections import namedtuple
"""
primitives
"""
str1 = "forbes"
num1 = 3
flot1 = 5.22
bool1 = True
bytes1 = bytes(b'd\x01S\x00')
bytearr1 = bytearray(bytes1)
bltfunc = len
"""
simple lists
"""
lst1 = ['a', 2, 'c']
lst2 = [1, 2, 3, 4]

set1 = set(lst1)
frzset1 = frozenset(lst1)
tpl1 = tuple(lst1)

"""
simple dictionary
"""
dict1 = {'a': 1, 'b': 2}
exp_dict = namedtuple('object', ['a', 'b'])(*[1, 2])


class MyClass:
    def __init__(self):
        self.a = 'a'
        self.b = 1


class B: pass
class cls1(MyClass, B):pass

"""
simple object
"""
obj1 = MyClass()

"""
simple function
"""
def hello():
    return 'Hello, world!'


exp_hello = 'Hello, world!'

"""
global variable
"""
name = 'Chizh'

"""
function using globals variable
"""
def say_hello():
    global name
    return 'Hello, ' + name

exp_say_hello = 'Hello, Chizh'

"""
function with parameters
"""
json_file = 'func.json'
pickle_file = 'func.pickle'
yaml_file = 'func.yaml'

def add(a, b):
    return a + b


exp_add = 5

"""
lambda
"""
power = lambda num, p: num ** p
exp_power = 8