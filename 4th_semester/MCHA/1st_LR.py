from math import fabs
i = 0
j = 0
v = 15
q = 0
C = [[0.2,0,0.2,0,0],[0,0.2,0,0.2,0],[0.2,0,0.2,0,0.2],[0,0.2,0,0.2,0],[0,0,0.2,0,0.2]]
D = [[2.33,0.81,0.67,0.92,-0.53],[-0.53,2.33,0.81,0.67,0.92],[0.92,-0.53,2.33,0.81,0.67],[0.67,0.92,-0.53,2.33,0.81],[0.81,0.67,0.92,-0.53,2.33]]
b = [4.2,4.2,4.2,4.2,4.2]
A = [[0,0,0,0,0],[0,0,0,0,0],[0,0,0,0,0],[0,0,0,0,0],[0,0,0,0,0]]
x = [0,0,0,0,0]
size = 5
inp = 0
def Gaus():
	k = 0
	while(k < size - 1):
		i = k + 1
		while(i < size):
			q = A[i][k] / A[k][k]
			b[i] = b[i] - q * b[k]
			j = 0
			while(j < size):
				A[i][j] = A[i][j] - q * A[k][j]
				j+=1
			i+=1
		k+=1
	x[4] = b[4] / A[4][4]
	i = 3
	while(i >= 0):
		j = i + 1
		while(j < size):
			b[i] = b[i] - x[j] * A[i][j]
			x[i] = b[i] / A[i][i]
			j+=1
		i-=1
	i = 0
	while(i < size):
		print(round(x[i],4))
		i+=1
	return 

def Choice():
	maxelement = 0
	row = 0
	string = 0
	k = 0
	reserv = 0
	reservb = 0
	while(k < size):
		i = k + 1
		j = k
		maxelement = A[k][k]
		while(i < size):
			if fabs(A[i][j]) > fabs(maxelement):
				maxelement = A[i][j]
				string = i
			i+=1
		if maxelement != A[k][k]:							#Changing strings
			j = 0
			while(j < size):
				reserv = A[k][j]
				A[k][j] = A[string][j]
				A[string][j] = reserv
				reservb = b[k]
				b[k] = b[string]
				b[string] = reservb
				j+=1
		i = k + 1
		while(i < size):
			q = A[i][k] / A[k][k]
			b[i] = b[i] - q * b[k]
			j = 0
			while(j < size):
				A[i][j] = A[i][j] - q * A[k][j]
				j+=1
			i+=1
		k+=1
	x[4] = b[4] / A[4][4]
	i = 3
	while(i >= 0):
		j = i + 1
		while(j < size):
			b[i] = b[i] - x[j] * A[i][j]
			x[i] = b[i] / A[i][i]
			j+=1
		i-=1
	i = 0
	while(i < size):
		print(round(x[i],4))
		i+=1
	return



while(i < size):					#Solve A matrix
	while(j < size):
		A[i][j] = v * C[i][j] + D[i][j]
		j+=1
	j = 0
	i+=1

inp = int(input("Выберите метод: 0 - Метод Гауса, 1 - Метод выбора главного элемента по столбцу"))
if inp == 0:
	Gaus()
else:
	Choice()
