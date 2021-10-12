#include <stdio.h>
#include <stdlib.h>

void main(void)
{
    int *mass;
    int size = 0, Counter1 = 0, Counter2 = 0;
    printf("Enter number size\t");
    scanf_s("%d", &size);
    mass = (int*)malloc(size*sizeof(int));
    printf("Insert the number\n");
    for (int i = 0; i < size; i++)
    {
        scanf_s("%d", &mass[i]);
    }
    for (int i = 0; i < size-1; i++)
    {
        if (mass[i + 1] - mass[i] == -1)
        {
            Counter1++;
            continue;
        }
        else if (mass[i + 1] - mass[i] == 1)
        {
            Counter2++;
            continue;
        }
        else
        {
            printf("Error\n");
            break;
        }
    }
    if (Counter1 == size-1)
    {
        printf("Numbers in decreasing order\n");
    }
    else if (Counter2 == size-1)
    {
        printf("Numbers in ascending order\n");
    }
    free(mass);
}
