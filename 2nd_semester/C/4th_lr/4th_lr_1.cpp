#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <string.h>


void main(void)
{
	int size;
	char str[180];
	printf("Enter the string: ");
	scanf("%s", &str);
	size = strlen(str);
	for (int i = 0; i < size; i++)
	{
		if (str[i] == ('('))
		{		
			for (int j = i+1; j < size; j++)
			{
				if (str[j] == (')'))
				{
					if (i + 1 - j == 0)
					{
						break;
					}
					else 
					{
						for (int k = i + 1; k < size; k++, j++)
						{
							str[k] = str[j];
						}
					}
				}
				if (str[j] == ('('))
				{
					printf("\n missing closing bracket )\n");
					break;
				}
			}
		}
	}
	size = strlen(str);
	printf("\n Answer: ");
	for (int i = 0; i < size; i++)
	{
		printf("%c", str[i]);
	}
}

//qw(((((qwe)sfg(sg)
//Answer: qw((((()sfg()