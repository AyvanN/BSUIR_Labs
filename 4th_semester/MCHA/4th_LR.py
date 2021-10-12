import numpy as np
import sympy as sp
from sympy.plotting import plot
import math

x, y, z = sp.symbols('x y z')

m = 0.1
a = 0.6

f = []
f.append(lambda _x, _y : math.tan(_x*_y+m) - _x)
f.append(lambda _x, _y : a*_x**2 + 2*_y**2 - 1)

g = []
g.append(lambda x, y: math.tan(x*y + m))
g.append(lambda x, y: math.sqrt(0.5*(1 - a*x**2)))

def simple_iterations(vec, entry_x, entry_y, accuracy):
    size = len(vec)
    counter = 0
    _X_ = np.array([entry_x, entry_y])
    _x_temp_ = _X_ + np.array([10*accuracy, 10*accuracy])
    while np.linalg.norm(_X_ - _x_temp_) > accuracy:
        _x_temp_ = _X_
        _X_ = np.array([vec[i](_X_[0], _X_[1]) for i in range(size)])
        counter += 1
    return _X_, counter

def newton(entry_x, entry_y, accuracy):
    def calculate_jacobian(jacobian, X):
        size = len(jacobian)
        res_jac = []
        for i in range(size):
            grad = []
            for j in range(size):
                grad.append(jacobian[i][j](X[0], X[1]))
            res_jac.append(grad)
        return res_jac
    def calculate_vect_func(vec, X):
        size = len(vec)
        res = []
        for func in vec:
            res.append(func(X[0], X[1]))
        return res
    
    jacobian = [
        [lambda x, y : y/(math.cos(x*y+0.2))**2 - 1, lambda x, y : x/(math.cos(x*y+0.2))**2],
        [lambda x, y : 1.8*x, lambda x, y : 4*y]
    ]
    
    vect_func = f
    counter = 0
    _X_ = np.array([entry_x, entry_y])
    _x_temp_ = _X_ + np.array([10*accuracy, 10*accuracy])
    while np.linalg.norm(_X_ - _x_temp_) > accuracy:
        _x_temp_ = _X_
        _X_ = _X_ - (np.linalg.inv(calculate_jacobian(jacobian, _X_))@calculate_vect_func(vect_func, _X_))
        counter += 1
    return _X_, counter

print(simple_iterations(g, 0.5, 0.5, 1e-5))    
print(newton(0.5, 0.5, 1e-5))

p1 = sp.plot_implicit(sp.Eq(sp.tan(x*y+m), x), (x, -1, 1), (y, -1, 1), show=False)
p1.extend(sp.plot_implicit(sp.Eq(a*x**2 + 2*y**2, 1), (x, -1, 1), (y, -1, 1),show=False))
p1.show()
