import math
import matplotlib.pyplot as plt

dataset = [
    [i * (2 / 5) for i in range(6)],
    [math.atan(i * (2 / 5)) for i in range(6)]
]


class SplineStruct:
    def __init__(self, a, b, c, d, x):
        self.a = a
        self.b = b
        self.c = c
        self.d = d
        self.x = x


def spline_create(x, y, n):
    splines = [SplineStruct(0, 0, 0, 0, 0) for _ in range(0, n)]
    for i in range(0, n):
        splines[i].x = x[i]
        splines[i].a = y[i]

    splines[0].c = splines[n - 1].c = 0.0

    alpha = [0.0 for _ in range(0, n - 1)]
    beta = [0.0 for _ in range(0, n - 1)]

    for i in range(1, n - 1):
        hi = x[i] - x[i - 1]
        hi1 = x[i + 1] - x[i]
        A = hi
        C = 2.0 * (hi + hi1)
        B = hi1
        F = 6.0 * ((y[i + 1] - y[i]) / hi1 - (y[i] - y[i - 1]) / hi)
        z = (A * alpha[i - 1] + C)
        alpha[i] = -B / z
        beta[i] = (F - A * beta[i - 1]) / z

    for i in range(n - 2, 0, -1):
        splines[i].c = alpha[i] * splines[i + 1].c + beta[i]

    for i in range(n - 1, 0, -1):
        hi = x[i] - x[i - 1]
        splines[i].d = (splines[i].c - splines[i - 1].c) / hi
        splines[i].b = hi * (2.0 * splines[i].c + splines[i - 1].c) / 6.0 + (y[i] - y[i - 1]) / hi
    return splines


def interpolate(splines, x):
    if not splines:
        return None

    n = len(splines)
    s = SplineStruct(0, 0, 0, 0, 0)

    if x <= splines[0].x:
        s = splines[0]
    elif x >= splines[n - 1].x:
        s = splines[n - 1]
    else:
        i = 0
        j = n - 1
        while i + 1 < j:
            k = i + (j - i) // 2
            if x <= splines[k].x:
                j = k
            else:
                i = k
        s = splines[j]

    dx = x - s.x
    return s.a + (s.b + (s.c / 2.0 + s.d * dx / 6.0) * dx) * dx


spline = spline_create(dataset[0], dataset[1], 6)

print("Сплайн в точке x = 0.75: ", interpolate(spline, 0.75))
print("Значение функции tg(x) в точке x = 0.75: ", math.atan(0.75))
print("Погрешность: {:0.9f}".format(abs(interpolate(spline, 0.75) - math.atan(0.75))))

splinesx = []
for i in dataset[0]:
    splinesx.append(interpolate(spline, i))

plt.plot(dataset[0], dataset[1])
plt.scatter(dataset[0], splinesx)
plt.show()
