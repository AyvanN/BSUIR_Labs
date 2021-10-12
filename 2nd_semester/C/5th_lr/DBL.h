#pragma once
#ifndef DBL_H
#define DBL_H
#include <stdlib.h>



typedef struct _Node {
    int value;
    void* next;
    void* prev;
} Node;



typedef struct _DblLinkedList {
    size_t size;
    Node* head;
    Node* tail;
} DblLinkedList;


DblLinkedList* createDblLinkedList();

void deleteDblLinkedList(DblLinkedList** list);

void pushFront(DblLinkedList* list, int data);

void* popFront(DblLinkedList* list);

void pushFront(DblLinkedList* list, int data);

void pushBack(DblLinkedList* list, int value);

void* popBack(DblLinkedList* list);

Node* getValue(DblLinkedList* list, size_t index);

void insert(DblLinkedList* list, size_t index, int value);

void* deleteNth(DblLinkedList* list, size_t index);

void printDblLinkedList(DblLinkedList* list, void (*fun)(int));

void printInt(int value);

#endif

