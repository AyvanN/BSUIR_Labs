#include "Queue.h"
#include <stdio.h>
#include <stdlib.h>





QueueList* createQueueList()
{
    QueueList* tmp = (QueueList*)malloc(sizeof(QueueList));
    tmp->size = 0;
    tmp->head = tmp->tail = NULL;

    return tmp;
}


void deleteQueueList(QueueList** list) 
{
    NoDe* tmp = (*list)->head;
    NoDe* next = NULL;
    while (tmp) {
        next = (NoDe*)tmp->next;
        free(tmp);
        tmp = next;
    }
    free(*list);
    (*list) = NULL;
}

void* popfront(QueueList* list)
{
    NoDe* prev;
    int tmp;
    if (list->head == NULL)
    {
        exit(2);
    }

    prev = list->head;
    list->head = (NoDe*)list->head->next;
    if (list->head)
    {
        list->head->prev = NULL;
    }
    if (prev == list->tail)
    {
        list->tail = NULL;
    }
    tmp = prev->value;
    free(prev);

    list->size--;
}


void pushback(QueueList* list, int value)
{
    NoDe* tmp = (NoDe*)malloc(sizeof(NoDe));
    if (tmp == NULL)
    {
        exit(3);
    }
    tmp->value = value;
    tmp->next = NULL;
    tmp->prev = list->tail;
    if (list->tail) {
        list->tail->next = tmp;
    }
    list->tail = tmp;

    if (list->head == NULL) {
        list->head = tmp;
    }
    list->size++;
}


void* popback(QueueList* list)
{
    NoDe* next;
    int tmp;
    if (list->tail == NULL)
    {
        exit(4);
    }

    next = list->tail;
    list->tail = (NoDe*)list->tail->prev;
    if (list->tail) {
        list->tail->next = NULL;
    }
    if (next == list->head)
    {
        list->head = NULL;
    }
    tmp = next->value;
    free(next);

    list->size--;
}

void printint(int value)
{
    printf("%d ", (value));
}

void printQueueListFront(QueueList* list, void (*fun)(int))
{
    NoDe* tmp = list->head;
    fun(tmp->value);
    tmp = ((NoDe*)tmp->next);
    printf("\n");
}

void printQueueListBack(QueueList* list, void (*fun)(int))
{
    NoDe* tmp = list->tail;
    fun(tmp->value);
    tmp = ((NoDe*)tmp->next);
    printf("\n");
}


NoDe* getvalue(QueueList* list, size_t index)
{
    NoDe* tmp = NULL;
    size_t i;

    if (index < list->size / 2) {
        i = 0;
        tmp = list->head;
        while (tmp && i < index) {
            tmp = (NoDe*)tmp->next;
            i++;
        }
    }
    else {
        i = list->size - 1;
        tmp = list->tail;
        while (tmp && i > index) {
            tmp = (NoDe*)tmp->prev;
            i--;
        }
    }

    return tmp;
}

