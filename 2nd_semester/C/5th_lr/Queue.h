#pragma once
#ifndef Queue_H
#define Queue_H
#include <stdlib.h>



typedef struct _NoDe
{
    int value;
    void* next;
    void* prev;
} NoDe;



typedef struct _QueueList 
{
    size_t size;
    NoDe* head;
    NoDe* tail;
} QueueList;

void deleteQueueList(QueueList** list);

QueueList* createQueueList();

void* popfront(QueueList* list);

void pushback(QueueList* list, int value);

void* popback(QueueList* list);

void printint(int value);

void printQueueListFront(QueueList* list, void (*fun)(int));

void printQueueListBack(QueueList* list, void (*fun)(int));

NoDe* getvalue(QueueList* list, size_t index);

#endif
