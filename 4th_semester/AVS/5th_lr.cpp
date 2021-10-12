#include <iostream>
#include <math.h>
using namespace std;
int overflowMes = 0;
void prntBin(int* num, int N)
{
	for (int i = N - 1; i > -1; i--)
		cout << num[i];
	cout << endl;
}
void invers(int** bin, int N)
{
	for (int i = 0; i < N; i++)
		(*bin)[i] = abs((*bin)[i] - 1);
	int temp;
	int e = 1;
	for (int i = 0; i < N; i++)
	{
		temp = (*bin)[i];
		(*bin)[i] = (*bin)[i] ^ e;
		e = temp && e;
	}
}
int* decToBinFrac(float num)
{
	int* frac = (int*)malloc(32 * sizeof(int));
	int S = 0;
	if (num < 0)
	{
		S = 1;
		num = fabs(num);
	}
	int i;
	if (num >= 1)
	{
		i = 0;
		while (powf(2, (float)i) > num || num >= powf(2, (float)i + 1))
			i++;
	}
	else
	{
		i = -1;
		while (powf(2, (float)i) > num || num > powf(2, (float)i + 1))
			i--;
	}
	int E = 127 + i, M;
	if (E > 253)
		overflowMes = 1;
	float Mreal = (num - powf(2, (float)i)) / (powf(2, (float)(i + 1)) - powf(2, (float)i))
		* powf(2, 23);
	if (Mreal - (float)(int)Mreal >= 0.5)
		M = (int)Mreal + 1;
	else
		M = (int)Mreal;
	for (int i = 0; i < 23; i++)
	{
		frac[i] = M % 2;
		M /= 2;
	}
	for (int i = 23; i < 31; i++)
	{
		frac[i] = E % 2;
		E /= 2;
	}
	frac[31] = S;
	return frac;
}
float binToDec(int* num)
{
	float frac = 0;
	for (int i = 0; i < 23; i++)
		frac += (float)num[i] * powf(2, (float)(i - 23));
	frac += 1;
	int p = 0;
	for (int i = 23; i < 31; i++)
		p += num[i] * pow(2, i - 23);
	p -= 127;
	return powf(-1, (float)num[31]) * powf(2, (float)p) * frac;
}
int* binIntegerSum(int* a, int* b, int N)
{
	int e = 0;
	int* c;
	c = (int*)malloc(N * sizeof(int));
	for (int i = 0; i < N; i++)
	{
		c[i] = (a[i] ^ b[i]) ^ e;
		e = (a[i] && b[i]) || (a[i] && e) || (b[i] && e);
	}
	return c;
}
void binInc(int** a, int N)
{
	int temp;
	int e = 1;
	for (int i = 0; i < N; i++)
	{
		temp = (*a)[i];
		(*a)[i] = (*a)[i] ^ e;
		e = temp && e;
	}
}
void binDec(int** a, int N)
{
	int temp, e = 0;
	for (int i = 0; i < N; i++)
	{
		temp = (*a)[i];
		(*a)[i] = ((*a)[i] ^ 1) ^ e;
		e = (temp && 1) || (temp && e) || (1 && e);
	}
}
void shift(int** a, int N)
{
	for (int i = 0; i < N - 1; i++)
		(*a)[i] = (*a)[i + 1];
	(*a)[N - 1] = 0;
}
void backShift(int** a, int N)
{
	for (int i = N - 1; i > 0; i--)
		(*a)[i] = (*a)[i - 1];
	(*a)[0] = 0;
}
int compare(int* a, int* b, int N)
{
	for (int i = N - 1; i > -1; i--)
	{
		if (a[i] > b[i])
			return 1;
		else
			if (a[i] < b[i])
				return -1;
	}
	return 0;
}
int* binRealMultiplication(int* a, int* b)
{
	int* aM = (int*)malloc(26 * sizeof(int));
	int* bM = (int*)malloc(26 * sizeof(int));
	int* aE = (int*)malloc(8 * sizeof(int));
	int* bE = (int*)malloc(8 * sizeof(int));
	int* ansM = (int*)malloc(51 * sizeof(int));
	int* ansM0 = (int*)malloc(51 * sizeof(int));
	for (int i = 0; i < 26; i++)
	{
		aM[i] = (a[i] && (i < 23)) || (i == 23);
		bM[i] = (b[i] && (i < 23)) || (i == 23);
		if (i < 8)
		{
			aE[i] = a[23 + i];
			bE[i] = b[23 + i];
		}
	}
	for (int i = 0; i < 51; i++)
		ansM[i] = 0;
	int decAnsE = 0;
	for (int i = 0; i < 8; i++)
		decAnsE += pow(2, i) * (aE[i] + bE[i]);
	decAnsE -= 127;
	if (decAnsE > 253)
		overflowMes = 1;
	int* ansE = (int*)malloc(8 * sizeof(int));
	for (int i = 0; i < 8; i++)
	{
		ansE[i] = decAnsE % 2;
		decAnsE /= 2;
	}
	for (int i = 0; i < 26; i++)
	{
		for (int j = 0; j < 51; j++)
		{
			if (j < 26)
				ansM0[j] = aM[j] * bM[i];
			else
				ansM0[j] = 0;
		}
		for (int j = 0; j < i; j++)
			backShift(&ansM0, 51);
		ansM = binIntegerSum(ansM, ansM0, 51);
	}
	int idx = 50, count = 0;
	while (true)
	{
		int idx = 50;
		while (ansM[idx] != 1)
			idx--;
		if (idx == 23)
			break;
		if (idx > 23)
		{
			shift(&ansM, 51);
			count++;
		}
	}
	if (count > 23)
	{
		binInc(&ansE, 8);
	}
	int p = 0;
	for (int i = 0; i < 8; i++)
		p += ansE[i] * pow(2, i);
	int* ans = (int*)malloc(32 * sizeof(int));
	for (int i = 0; i < 31; i++)
	{
		if (i < 23)
			ans[i] = ansM[i];
		else
			ans[i] = ansE[i - 23];
	}
	ans[31] = a[31] ^ b[31];
	free(aM);
	free(bM);
	free(aE);
	free(bE);
	return ans;
}
int main()
{
	while (true)
	{
		system("cls");
		setlocale(LC_ALL, "Russian");
		cout << fixed;
		cout.precision(8);
		float x, y;
		cout << "Первое число: ";
		cin >> x;
		cout << "Второе число: ";
		cin >> y;
		if (y == 0)
		{
			cout << "\n Деление на ноль \n\n";
			return 1;
		}
		int* prod = binRealMultiplication(decToBinFrac(x), decToBinFrac(y));
		if (overflowMes == 1)
		{
			cout << "\n Переполнение \n\n";
			return 1;
		}
		if (x != 0 && y != 0 && binToDec(prod) == 0)
		{
			cout << "\n Потеря значения \n\n";
			return 1;
		}
		cout << "Первое число в бинарном виде: ";
		prntBin(decToBinFrac(x), 32);
		cout << "Второе число в бинарном виде: ";
		prntBin(decToBinFrac(y), 32);
		cout << "Ответ (Бинарное представление) : ";
		prntBin(prod, 32);
		cout << "Ответ (Десятичное представление) : ";
		cout << binToDec(prod) << "\n";
		system("pause");
	}
}