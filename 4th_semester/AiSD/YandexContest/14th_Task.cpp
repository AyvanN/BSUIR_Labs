#include <iostream>
#include <fstream>
#include <vector>

using namespace std;

long long** matrix;

const long long module = 1e9 + 7;

vector<vector<long long>> multMatrix(vector<vector<long long>> firstMatrix, vector<vector<long long>> secondMatrix)
{
	vector<vector<long long>> mainMatrix(firstMatrix.size(), vector<long long>(firstMatrix.size(), 0));
	for (int i = 0; i < firstMatrix.size(); i++)
	{
		for (int m = 0; m < firstMatrix.size(); m++)
		{
			for (int n = 0; n < firstMatrix.size(); n++)
			{
				mainMatrix[i][m] = (mainMatrix[i][m] + (firstMatrix[i][n] * secondMatrix[n][m]) % module) % module;
			}
		}
	}
	return mainMatrix;
}


int main()
{
	int N, M, A, B, L, U, V;
	std::cin >> N >> M >> U >> V >> L;
	vector<vector<long long>> curMatrix(N, vector<long long>(N, 0));
	vector<vector<long long>> matrix(curMatrix.size(), vector<long long>(curMatrix.size(), 0));
	for (int i = 0; i < curMatrix.size(); i++)
	{
		matrix[i][i] = 1;
	}
	int iterator = 0;
	while (iterator < M)
	{
		cin >> A >> B;
		A -= 1;
		B -= 1;
		if (B == A)
		{
			curMatrix[A][B] += 2;
		}
		else
		{
			curMatrix[A][B] += 1;
			curMatrix[B][A] += 1;
		}
		iterator++;
	}

	while (L)
	{
		if (L % 2 != 1)
		{
			curMatrix = multMatrix(curMatrix, curMatrix);
			L /= 2;
		}
		else
		{
			matrix = multMatrix(matrix, curMatrix);
			L--;
		}
	}
	U--;
	V--;
	cout << matrix[U][V];

}

