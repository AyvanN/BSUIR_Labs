#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <string.h>
#include "Product.h"

ProductList* CreateProductList()
{
    ProductList* tmp = (ProductList*)malloc(sizeof(ProductList));
    tmp->size = 0;
    tmp->head = tmp->tail = NULL;

    return tmp;
}

void deleteProductList(ProductList* list)
{
    NoDe* tmp = list->head;
    NoDe* next = NULL;
    while (tmp) {
        next = (NoDe*)tmp->next;
        free(tmp);
        tmp = next;
    }
    free(list);
    (list) = NULL;
}
