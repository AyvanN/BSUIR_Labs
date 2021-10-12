import numpy


def count_left_rect(func, a, b, n):
    h = (b - a) / n
    sum = 0
    for i in range(0, n):
        sum += func(a + i * h)
    return sum * h


def count_right_rect(func, a, b, n):
    h = (b - a) / n
    sum = 0
    for i in range(1, n + 1):
        sum += func(a + i * h)
    return sum * h


def count_trap(func, a, b, n):
    return (count_left_rect(func, a, b, n) + count_right_rect(func, a, b, n)) / 2


def count_simpson(func, a, b, n):
    h = (b - a) / (2 * n)
    sum = 0
    for i in range(2 * n + 1):
        if i == 0 or i == 2 * n:
            sum += func(a + i * h)
        elif i % 2 == 0:
            sum += 2 * func(a + i * h)
        else:
            sum += 4 * func(a + i * h)
    return sum * h / 3


def count_mid_rect(func, a, b, n):
    h = (b - a) / n
    sum = 0
    for i in range(0, n + 1):
        sum += func(a + i * h + h / 2)
    return sum * h


def count_derivatives(func, a, b, n):
    h = (b - a) / n
    x = a + (b - a) / 2
    der_1 = (func(x + h) - func(x - h)) / (2 * h)
    der_2 = (func(x + h) - 2 * func(x) + func(x - h)) / h ** 2
    return der_1, der_2


if __name__ == '__main__':
    a = 1
    b = 3
    mid = (a + b) / 2
    f = lambda x: numpy.log(x)
    func_string = 'ln(x)'
    der_epsilon = 0.01
    int_epsilon = 0.000001

    trap_int_n = 1400
    simp_int_n = 15
    mid_int_n = 1400
    der_n = 5
    trap_integral = count_trap(f, a, b, trap_int_n)
    simpson_integral = count_simpson(f, a, b, simp_int_n)
    mid_integral = count_mid_rect(f, a, b, mid_int_n)
    der_1, der_2 = count_derivatives(f, a, b, der_n)
    lambda_d1 = lambda x: 1/x
    lambda_d2 = lambda x: -1/x ** 2
    lambda_d3 = lambda x: 2/x ** 3
    lambda_d4 = lambda x: -6/x ** 4

    true_der1 = lambda_d1(mid)
    true_der2 = lambda_d2(mid)
    true_integral = 1.295836866

    M2 = lambda_d2(b)
    M3 = lambda_d3(b)
    M4 = lambda_d4(b)

    trap_h = (b-a)/trap_int_n
    simpson_h = (b-a)/simp_int_n
    mid_h = (b - a) / mid_int_n
    der_h = (b-a)/der_n

    print(f'Function: {func_string}\nSegment: [{a}; {b}]')
    print('Integral:')
    print('True intergral:', true_integral)
    print('Trapezoidal rule result:', trap_integral.round(7))
    print('Received difference: {:.10f} at n = {}'.format(abs(true_integral - trap_integral), trap_int_n))
    print('Difference:{:.10f}'.format(abs((M2* trap_int_n * trap_h**2)/12)))

    print('')
    print('Simpson rule result:', simpson_integral.round(7))
    print('Received difference: {:.10f} at n = {}'.format(abs(true_integral - simpson_integral), simp_int_n))
    print('Difference:{:.10f}'.format(abs(((b-a)**4 * simpson_h**4 * M4)/ 180)))

    print('')
    print('Mid rule result:', mid_integral.round(7))
    print('Received difference: {:.10f} at n = {}'.format(abs(true_integral - mid_integral), mid_int_n))
    print('Difference:{:.10f}'.format(abs((M2 * mid_int_n * mid_h**2)/24)))

    print('Derivative:')
    print('True derivatives:\n1)', true_der1, '\n2)', true_der2)
    print('Received results:\n1)', der_1, '\n2)', der_2)
    print('Received difference at n =', der_n, ':\n', abs(der_1 - true_der1), '\n', abs(der_2-true_der2))