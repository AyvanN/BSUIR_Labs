#include "DBL.h"
#include <stdio.h>
#include <stdlib.h>



DblLinkedList* createDblLinkedList() 
{
    DblLinkedList* tmp = (DblLinkedList*)malloc(sizeof(DblLinkedList));
    tmp->size = 0;
    tmp->head = tmp->tail = NULL;

    return tmp;
}


void deleteDblLinkedList(DblLinkedList** list) 
{
    Node* tmp = (*list)->head;
    Node* next = NULL;
    while (tmp) {
        next = (Node*) tmp->next;
        free(tmp);
        tmp = next;
    }
    free(*list);
    (*list) = NULL;
}


void pushFront(DblLinkedList* list, int data) {
    Node* tmp = (Node*)malloc(sizeof(Node));
    if (tmp == NULL) {
        exit(1);
    }
    tmp->value = data;
    tmp->next = list->head;
    tmp->prev = NULL;
    if (list->head) {
        list->head->prev = tmp;
    }
    list->head = tmp;

    if (list->tail == NULL) {
        list->tail = tmp;
    }
    list->size++;
}


void* popFront(DblLinkedList* list) {
    Node* prev;
    int tmp;
    if (list->head == NULL) {
        exit(2);
    }

    prev = list->head;
    list->head = (Node*)list->head->next;
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



void pushBack(DblLinkedList* list, int value) {
    Node* tmp = (Node*)malloc(sizeof(Node));
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


void* popBack(DblLinkedList* list) {
    Node* next;
    int tmp;
    if (list->tail == NULL) {
        exit(4);
    }

    next = list->tail;
    list->tail = (Node*)list->tail->prev;
    if (list->tail) {
        list->tail->next = NULL;
    }
    if (next == list->head) {
        list->head = NULL;
    }
    tmp = next->value;
    free(next);

    list->size--;
}




Node* getValue(DblLinkedList* list, size_t index) {
    Node* tmp = NULL;
    size_t i;

    if (index < list->size / 2) {
        i = 0;
        tmp = list->head;
        while (tmp && i < index) {
            tmp = (Node*)tmp->next;
            i++;
        }
    }
    else {
        i = list->size - 1;
        tmp = list->tail;
        while (tmp && i > index) {
            tmp = (Node*)tmp->prev;
            i--;
        }
    }

    return tmp;
}


void insert(DblLinkedList* list, size_t index, int value) {
    Node* elm = NULL;
    Node* ins = NULL;
    elm = getValue(list, index);
    if (elm == NULL) {
        exit(5);
    }
    ins = (Node*)malloc(sizeof(Node));
    ins->value = value;
    ins->prev = elm;
    ins->next = elm->next;
    if (elm->next) {
        ((Node*)(elm->next))->prev = ins;
    }
    elm->next = ins;

    if (!elm->prev) {
        list->head = elm;
    }
    if (!elm->next) {
        list->tail = elm;
    }

    list->size++;
}

void* deleteNth(DblLinkedList* list, size_t index) {
    Node* elm = NULL;
    int tmp = NULL;
    elm = getValue(list, index);
    if (elm == NULL) {
        exit(5);
    }
    if (elm->prev) {
        ((Node*)(elm->prev))->next = (Node*)(elm->next);
    }
    if (elm->next) {
        ((Node*)(elm->next))->prev = elm->prev;
    }
    tmp = elm->value;

    if (!elm->prev) {
        list->head = ((Node*)elm->next);
    }
    if (!elm->next) {
        list->tail = ((Node*)elm->prev);
    }

    free(elm);

    list->size--;

}


void printInt(int value) {
    printf("%d ", (value));
}

void printDblLinkedList(DblLinkedList* list, void (*fun)(int)) {
    Node* tmp = list->head;
    while (tmp) {
        fun(tmp->value);
        tmp = ((Node*)tmp->next);
    }
    printf("\n");
}




