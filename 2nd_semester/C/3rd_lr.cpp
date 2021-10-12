#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <malloc.h>
#include <stdlib.h>
#include <ctime>

int input_check(int check)
{
    while (1)
    {
        if (scanf("%d", &check) != 1) {
            printf("Invalid input.Try again.\n");
            scanf("%*[^\n]");
        }
        else break;
    }
    return check;
}


void main(void)
{
    int y = 0, x = 0, choise = 0;
    int Case = 0, k;
    int **a;
    printf("Enter the number of columns: ");
    y = input_check(y);
    printf("Enter the number of lines: ");
    x = input_check(x);
    a = (int**)malloc(x * sizeof(int*));
    for (int i = 0; i < x; i++)
    {
        a[i] = (int*)malloc(y * sizeof(int));
        if (!a[i])
        {
            printf("Fale");
            break;
        }
    }
    for (int i = 0; i < x; i++)
    {
        a[i] = (int*)malloc(y * sizeof(int));
    }
    for (int i = 0; i < x; i++)
    {
        for (int j = 0; j < y; j++)
        {
            a[i][j] = rand() % 2;
        }
    }
    for (int i = 0; i < x; i++)
    {
        for (int j = 0; j < y; j++)
        {
            printf("%5d ", a[i][j]);
        }
        printf("\n");
    }
    do
    {
        srand(time(NULL));
        if (choise == 2)
        {
            system("cls");
            choise = 0;
            printf("Enter the number of columns: ");
            y = input_check(y);
            printf("Enter the number of lines: ");
            x = input_check(x);
            a = (int**)malloc(x * sizeof(int*));
            for (int i = 0; i < x; i++)
            {
                a[i] = (int*)malloc(y * sizeof(int));
            }
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    a[i][j] = rand() % 2;
                }
            }
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    printf("%5d ", a[i][j]);
                }
                printf("\n");
            }
        }
        if (choise == 1)
        {
            choise = 0;
            int x1 = 0, y1 = 0;
            printf("Enter the dimensions of the desired matrix:\n");
            printf("Enter the number of lines: ");
            y1 = input_check(y1);
            printf("Enter the number of columns: ");
            x1 = input_check(x1);
            int iterator1 = y - y1 + 1, iterator2 = x - x1 + 1;
            for (int i = 0; i < iterator1; i++)
            {
                for (int j = 0; j < iterator2; j++)
                {
                    k = 0;
                    for (int m = i; m < y1 + i; m++)
                    {
                        for (int n = j; n < x1 + j; n++)
                        {
                            if (a[m][n] == 0)

                                k++;
                        }
                    }
                    if (k == x1 * y1)
                    {
                        Case++;
                        printf("matrix number %d  ", Case);
                        printf("with dimension [%d][%d]  ", y1, x1);
                        printf("and starting coordinates %d %d\n", i+1, j+1);
                    }
                }
            }
            if (Case == 0)
            {
                printf("\nMatrices of specified size not found\n");
            }
            else Case = 0;
        }
        printf("\n1)Find matrix");
        printf("\n2)Create a new matrix");
        printf("\n3)Exit the program\n\n");
        choise = input_check(choise);
    }
   while (choise != 3);
    for (int i = 0; i < y; i++)
    {
        free(a[i]);
    }
    free(a);
 }

