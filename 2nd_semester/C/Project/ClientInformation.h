#pragma once
#ifndef CLIENTINFORMATION_H
#define CLIENTINFORMATION_H
#include <stdlib.h>

#define SIZE 25


typedef struct _Info
{
    char name[SIZE];
    char surname[SIZE];
    char lastname[SIZE];
    char phonenumber[13];
    int Bag[SIZE];
    int SizeBag = 0;
    int Buy = 0;
}Info;


typedef struct _Node
{
    Info* value;
    void* next;
    void* prev;
}Node;

typedef struct _BuyerInfo {
    size_t size;
    Node* head;
    Node* tail;
}BuyerInfo;


BuyerInfo* CreateBuyerInfo();

void deleteBuyerInfo(BuyerInfo* list);

void* popBack(BuyerInfo* list);

#endif