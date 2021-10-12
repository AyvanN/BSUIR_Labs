#define _CRT_SECURE_NO_WARNINGS
#include "ClientInformation.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>


BuyerInfo* CreateBuyerInfo()
{
    BuyerInfo* tmp = (BuyerInfo*)malloc(sizeof(BuyerInfo));
    tmp->size = 0;
    tmp->head = tmp->tail = NULL;

    return tmp;
}

void deleteBuyerInfo(BuyerInfo* list)
{
    Node* tmp = list->head;
    Node* next = NULL;
    while (tmp) {
        next = (Node*)tmp->next;
        free(tmp);
        tmp = next;
    }
    free(list);
    (list) = NULL;
}



void* popBack(BuyerInfo* list) {
    Node* next;
    Info* tmp;
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


