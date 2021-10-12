#include <iostream>
#include <string>
#include <vector>

const int p = 1;
std::vector<int> vect[10001];
bool checker[10001];

void Solution(int num)
{
	int graphSize = vect[num].size();
	int value;
	checker[num] = true;
	for (int i = 0; i < graphSize; i++) {
		value = vect[num][i];
		if (!checker[value])
		{
			Solution(value);
		}
	}
}

bool Answer(int N)
{
	int answer = 0;
	Solution(p);
	for (int i = 1; i <= N; i++) {
		if (!checker[i])
		{
			return true;
		}
	}
	return false;
}

int main()
{
	int N, M;
	std::cin >> N;
	std::cin >> M;
	int insert = 0;
	while (insert < M)
	{
		int num1, num2;
		std::cin >> num1;
		std::cin >> num2;
		vect[num1].push_back(num2);
		vect[num2].push_back(num1);
		insert++;
	}
	if (Answer(N))
	{
		std::cout << -1;
	}
	else
	{
		std::cout << M - N + 1;
	}
	return 0;
}