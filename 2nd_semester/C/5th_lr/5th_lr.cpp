#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <conio.h>
#include <dos.h>
#include <Windows.h>
#include "DBL.h"
#include "Queue.h"


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


void Compound(QueueList* queue1, QueueList* queue2, DblLinkedList* dbl, int counter)
{
    int first, second;
    for (int i = 0; i < counter; i++)
    {
        if ((queue1->size == 0) && (queue2->size == 0))
        {
            break;
        }
        if (queue1->size == 0)
        {
            pushBack(dbl, (int)(getvalue(queue2, 0)->value));
            popfront(queue2);
            continue;
        }
        else first = (int)(getvalue(queue1, 0)->value);
        if (queue2->size == 0)
        {
            pushBack(dbl, (int)(getvalue(queue1, 0)->value));
            popfront(queue1);
            continue;
        }
        else second = (int)(getvalue(queue2, 0)->value);
        if (first > second)
        {
            pushBack(dbl, second);
            popfront(queue2);
        }
        else if (second > first)
        {
            pushBack(dbl, first);
            popfront(queue1);
        }
        else if (first == second)
        {
            pushBack(dbl, first);
            pushBack(dbl, second);
            popfront(queue1);
            popfront(queue2);
        }
    }
    printf("Ordered double linked list: \n");
    printDblLinkedList(dbl, printInt);
}


void main(void)
{
    DblLinkedList* dbl = createDblLinkedList();
    QueueList* queue1 = createQueueList();
    QueueList* queue2 = createQueueList();
    int value = 0, counter1 = 0, counter2 = 0, counter;
    printf("Enter the number of variables in the first list: ");
    counter1 = input_check(counter1);
    for (int i = 0; i < counter1; i++)
    {
        value = input_check(value);
        pushback(queue1, value);
    }
    printf("Enter the number of variables in the second list: ");
    counter2 = input_check(counter2);
    for (int i = 0; i < counter2; i++)
    {
        value = input_check(value);
        pushback(queue2, value);
    }

    counter = counter1 + counter2;

   Compound(queue1, queue2, dbl,counter);

    _getch();
}

