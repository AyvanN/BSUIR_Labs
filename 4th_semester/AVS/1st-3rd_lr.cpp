#include <iostream>
#include<cmath>

using namespace std;


void PrintMass(int* mass, int length)
{
	for (int i = 0; i < length; i++)
	{
		cout << mass[i];
	}
	cout << "\n";
}


void dec2bin(int num, int* mass, int length)
{
	int bin = 0;

	if (num < 0)
	{
		num *= -1;
		mass[0] = 1;
	}

	while (num)
	{
		bin = (num % 2);
		mass[length - 1] = bin;
		length--;
		num /= 2;
	}
}


int CheckSize(int num)
{
	int size = 0;
	if (abs(num) <= 127)
	{
		size = 8;
	}
	else if (abs(num) <= 32767)
	{
		size = 16;
	}
	else
	{
		size = 32;
	}

	return size;
}


int OverflowCheck(int firstnum, int secondnum, int length)
{
	int sum = firstnum + secondnum;
	if (sum < 0)
	{
		int check = (((pow(2, length) / 2) - 1) * (-1));

		if (sum < check)
		{
			return 0;
		}
	}
	else
	{
		if (sum > ((pow(2, length) / 2) - 1))
		{
			return 0;
		}
	}
	return 1;
}


int bin2dec(int* mass, int length)
{
	int power = 0, ans = 0;
	for (int i = length - 1; i > 0; --i, power++)
	{
		ans += mass[i] * pow(2, power);
	}
	return ans;
}


void Computation(int* firstmass, int* secondmass, int* answer, int length)
{
	for (int i = length - 1; i > 0; --i)
	{
		answer[i] += firstmass[i] + secondmass[i];
		if (answer[i] == 2)
		{
			answer[i] = 0;
			answer[i - 1] += 1;
		}
		else if (answer[i] == 3)
		{
			answer[i] = 1;
			answer[i - 1] += 1;
		}
	}
}

void AditionalCode(int* mass, int length)
{
	if (mass[0] == 1)
	{
		cout << "Инвертирование значений (Обратный код) :\n";
		for (int i = length - 1; i > 0; --i)
		{
			if (mass[i] == 1)
			{
				mass[i] = 0;
				PrintMass(mass, length);
			}
			else
			{
				mass[i] = 1;
				PrintMass(mass, length);
			}
		}
		cout << "Прибавление единицы к инверсии :\n";
		mass[length - 1] += 1;
		PrintMass(mass, length);
		for (int i = length - 1; i > 0; --i)
		{
			if (mass[i] == 2)
			{
				mass[i] = 0;
				mass[i - 1] += 1;
				PrintMass(mass, length);
			}
			else if (mass[i] == 3)
			{
				mass[i] = 1;
				mass[i - 1] += 1;
				PrintMass(mass, length);
			}
		}
		PrintMass(mass, length);
	}
}

void StraightCode(int* mass, int length)
{
	if (mass[0] == 1)
	{
		cout << " Отнимаение единицы от инвертированного кода :\n";
		for (int i = length - 1; i > 0; --i)
		{
			if (mass[i] == 1)
			{
				mass[i] = 0;
				PrintMass(mass, length);
				for (int k = i + 1; k < length; ++k)
				{
					mass[k] = 1;
					PrintMass(mass, length);
				}
				break;
			}
		}
		cout << " Обратное инвертирование кода кода :\n";
		for (int i = length - 1; i > 0; --i)
		{
			if (mass[i] == 0)
			{
				mass[i] = 1;
				PrintMass(mass, length);
			}
			else
			{
				mass[i] = 0;
				PrintMass(mass, length);
			}
		}
	}
}

int CheckSign(int* firstmass, int* secondmass)
{
	if (firstmass[0] == 1 && secondmass[0] == 1)
	{
		return 0;
	}
	else if (firstmass[0] == 1 || secondmass[0] == 1)
	{
		return 1;
	}
	else
	{
		return 0;
	}
}


void Multiplication(int* firstmass, int* secondmass, int* mulAnswer, int length)
{
	cout << "Операция умножения : \n";
	for (int i = length - 1; i > 0; --i)
	{
		if (secondmass[i] == 1)
		{
			for (int k = length - 1, j = length - i; k > 0; --k, ++j)
			{
				mulAnswer[(length * 2) - j] += firstmass[k];
				PrintMass(mulAnswer, length * 2);
			}
			cout << "-----------------------------------------------------\n";
			for (int i = (length * 2) - 1; i > 0; --i)
			{
				if (mulAnswer[i] == 2)
				{
					mulAnswer[i] = 0;
					mulAnswer[i - 1] += 1;
					PrintMass(mulAnswer, length * 2);
				}
				else if (mulAnswer[i] == 3)
				{
					mulAnswer[i] = 1;
					mulAnswer[i - 1] += 1;
					PrintMass(mulAnswer, length * 2);
				}
			}
		}
	}
}

void shift(int** bin, int length)
{
	for (int i = length - 2; i > 0; i--)

		(*bin)[i] = (*bin)[i - 1];

	(*bin)[0] = 0;
}

void backShift(int** bin, int length)
{
	for (int i = 0; i < length - 1; i++)

		(*bin)[i] = (*bin)[i + 1];
}

void main(void)
{
	while (true)
	{
		system("cls");
		setlocale(LC_ALL, "ru");
		char sign = '+';
		int firstnum, secondnum, length, choice = 0, ansSign = 0, decAnswer;
		cout << "Первое число: ";
		cin >> firstnum;
		cout << "Второе число: ";
		cin >> secondnum;
		cout << "1 - Сложить\n2 - Отнять \n3 - умножить \n";
		cin >> choice;
		if (abs(firstnum) > abs(secondnum))
		{
			length = CheckSize(firstnum);
			if (firstnum < 0)
			{
				ansSign = 1;
			}
		}
		else
		{
			length = CheckSize(secondnum);
			if (secondnum < 0)
			{
				ansSign = 1;
			}
		}
		int* firstmass = new int[length] {};
		int* secondmass = new int[length] {};
		int* answer = new int[length] {ansSign, {}};
		if (choice == 1 || choice == 2)
		{
			if (choice == 2)
			{
				secondnum *= -1;
			}
			if (secondnum < 0)
			{
				sign = ' ';
			}
			if (OverflowCheck(firstnum, secondnum, length) == 0)
			{
				cout << "Переполнение";
				exit(0);
			}
			dec2bin(firstnum, firstmass, length);
			dec2bin(secondnum, secondmass, length);
			cout << firstnum << sign << secondnum << " = \n";
			cout << firstnum << ": \n";
			cout << "Прямой код: ";
			PrintMass(firstmass, length);
			AditionalCode(firstmass, length);
			cout << "Дополнительный код: ";
			PrintMass(firstmass, length);
			cout << secondnum << ": \n";
			cout << "Прямой код: ";
			PrintMass(secondmass, length);
			AditionalCode(secondmass, length);
			cout << "Дополнительный код: ";
			PrintMass(secondmass, length);
			Computation(firstmass, secondmass, answer, length);
			cout << "Ответ в двоичном представлении (Дополнительный код): ";
			PrintMass(answer, length);
			answer[0] = ansSign;
			StraightCode(answer, length);
			cout << "Прямой код : ";
			PrintMass(answer, length);
			decAnswer = bin2dec(answer, length);
			if (ansSign == 1)
			{
				decAnswer *= -1;
			}
			cout << "Ответ в десятичном представлении : " << decAnswer << "\n";
		}
		else if (choice == 3)
		{
			int answer = 0;
			int* mulAnswer = new int[length * 2]{};
			dec2bin(firstnum, firstmass, length);
			dec2bin(secondnum, secondmass, length);
			cout << firstnum << " * " << secondnum << " = " << "\n";
			cout << firstnum << ": \n";
			cout << "Прямой код: ";
			PrintMass(firstmass, length);
			cout << secondnum << ": \n";
			cout << "Прямой код: ";
			PrintMass(secondmass, length);
			Multiplication(firstmass, secondmass, mulAnswer, length);
			answer = bin2dec(mulAnswer, length * 2);
			if (CheckSign(firstmass, secondmass) == 1)
			{
				answer *= -1;
				mulAnswer[0] = 1;
			}
			cout << "Ответ в двоичном представлении : ";
			PrintMass(mulAnswer, length * 2);
			cout << "Ответ в десятичном представлении : " << answer << "\n";
		}
		if (choice == 4)
		{
			int answer = 0;
			int* mulAnswer = new int[length * 2]{};
			dec2bin(firstnum, firstmass, length);
			dec2bin(secondnum, secondmass, length);
			cout << firstnum << " * " << secondnum << " = " << "\n";
			cout << firstnum << ": \n";
			cout << "Прямой код: ";
			PrintMass(firstmass, length);
			cout << secondnum << ": \n";
			cout << "Прямой код: ";
			PrintMass(secondmass, length);
			Multiplication(firstmass, secondmass, mulAnswer, length);
			answer = bin2dec(mulAnswer, length * 2);
			if (CheckSign(firstmass, secondmass) == 1)
			{
				answer *= -1;
				mulAnswer[0] = 1;
			}
			cout << "Ответ в двоичном представлении : ";
			PrintMass(mulAnswer, length * 2);
			cout << "Ответ в десятичном представлении : " << answer << "\n";
		}
		system("pause");
	}

}