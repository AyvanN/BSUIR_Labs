#include <iostream>
#include <math.h>
#include <string>
using namespace std;
int shiftMes = 0;
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
		while (powf(2, (float)i) > num || num > powf(2, (float)i + 1))
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
	float Mreal = (num - powf(2, (float)i)) /
		(powf(2, (float)(i + 1)) - powf(2, (float)i)) * powf(2, 23);
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
int* binRealSum(int* a, int* b)
{
	int* aM = (int*)malloc(26 * sizeof(int));
	int* bM = (int*)malloc(26 * sizeof(int));
	int* aE = (int*)malloc(8 * sizeof(int));
	int* bE = (int*)malloc(8 * sizeof(int));
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
	int* minE;
	int* maxE;
	int* minM;
	if (compare(aE, bE, 8) == -1)
	{
		maxE = bE;
		minE = aE;
		minM = aM;
	}
	else
	{
		maxE = aE;
		minE = bE;
		minM = bM;
	}
	while (compare(maxE, minE, 8) != 0)
	{
		binInc(&minE, 8);
		shift(&minM, 26);
	}
	if (a[31] == 1)
		invers(&aM, 26);
	if (b[31] == 1)
		invers(&bM, 26);
	int* ansM = binIntegerSum(aM, bM, 26);
	int ansS = 0;
	if (ansM[25] == 1)
	{
		ansS = 1;
		invers(&ansM, 26);
	}
	if (ansM[24] == 1)
	{
		binInc(&minE, 8);
		shift(&ansM, 26);
	}
	else
		if (ansM[23] == 0)
		{
			binDec(&minE, 8);
			backShift(&ansM, 26);
		}
	int p = 0;
	for (int i = 0; i < 8; i++)
		p += minE[i] * pow(2, i);
	p -= 127;
	if (p >= 23)
		shiftMes = 1;
	int* ans = (int*)malloc(32 * sizeof(int));
	for (int i = 0; i < 31; i++)
	{
		if (i < 23)
			ans[i] = ansM[i];
		else
			ans[i] = minE[i - 23];
	}
	int resExp = 0;
	for (int i = 23; i < 31; i++)
		resExp += pow(2, (i - 23)) * ans[i];
	if (resExp > 253)
		overflowMes = 1;
	ans[31] = ansS;
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
		system("CLS");
		setlocale(LC_ALL, "ru");
		cout << fixed;
		cout.precision(8);
		float x, y;
		cout << "Первое число: ";
		cin >> x;
		cout << "Второе число: ";
		cin >> y;
		int* sum = binRealSum(decToBinFrac(x), decToBinFrac(y));
		int* sub = binRealSum(decToBinFrac(x), decToBinFrac(-y));
		if (overflowMes == 1)
		{
			cout << "\n Переполнение \n\n";
			return 1;
		}
		if (shiftMes == 1)
		{
			cout << "\n Слоишком большое число "
				"\n\n";
			return 1;
		}
		cout << "Первое число в бинарном виде: ";
		prntBin(decToBinFrac(x), 32);
		cout << "Второе число в бинарном виде: ";
		prntBin(decToBinFrac(y), 32);
		cout << "Бинарная сумма: ";
		prntBin(sum, 32);
		cout << "Десятичная сумма: ";
		cout << binToDec(sum);
		cout << "\nБинарная разность: ";
		prntBin(sub, 32);
		cout << "Десятичная разность: ";
		cout << binToDec(sub) << "\n";
		system("pause");
	}
}