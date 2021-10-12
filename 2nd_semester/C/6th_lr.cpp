#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>


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


typedef int Data;
struct Node {
    Data val;            
    struct Node* left;  
    struct Node* right; 
};
void tree_destroy(struct Node* tree);
void insert(struct Node** p, Data x);
void insert(struct Node** p, Data x)
{
    if (*p == NULL)
    {
        *p = (struct Node*)malloc(sizeof(struct Node));
        (*p)->val = x;
        (*p)->left = NULL;
        (*p)->right = NULL;
    }
    else
    {
        if (x > (*p)->val)
        {
            insert(&((*p)->right), x);
        }
        if (x < (*p)->val)
            insert(&((*p)->left), x);
    }
}
void tree_destroy(struct Node* tree)
{
    if (tree == NULL)
    {
        return;
    }
    else
    {
        tree_destroy(tree->left);
        tree_destroy(tree->right);
        free(tree);
    }
}
int max(int a, int b)
{
    int c = a;
    if (a > b)
        c = a;
    if (b > a)
        c = b;
    if (a == b)
        c = a;
    return c;
}
int min(int a, int b)
{
    int c = a;
    if (a < b)
        c = a;
    if (b < a)
        c = b;
    if (a == b)
        c = a;
    return c;
}
int height(struct Node* tree)
{
    int i = 0;
    if (tree == NULL)
        return 0;
    if (tree != NULL)
    {
        i = max(height(tree->left), height(tree->right)) + 1;
    }
    return i;
}
int minheight(struct Node* tree)
{
    int i = 0;
    if (tree == NULL)
        return 0;
    if (tree != NULL)
    {
        i = min(height(tree->left), height(tree->right)) + 1;
    }
    return i;
}
int check_node(struct Node* tree)
{
    int c = -1;
    if (tree != NULL)
    {
        if (height(tree) - minheight(tree) > 1)
        {
            c = 0;
        }
        else
        {
            c = 1;
        }
    }
    return c;
}
int check(struct Node* tree)
{
    int t = 1;
    if (height(tree) == 3)
    {
        t = check_node(tree);
    }
    if (height(tree) > 3)
        t = check(tree->left) * check(tree->right);
    return t;
}
void main(void)
{
    struct Node* tree = NULL;
    int value = 0;
    printf("Enter the root of the binary tree: ");
    value = input_check(value);
    printf("Enter binary tree elements: ");
    insert(&tree, value);
    while (value != 0)
    {
        value = input_check(value);
        if (value > 0)
            insert(&tree, value);
    }
    if (check(tree) == 0)
    {
        printf("Binary tree is not balanced");
    }
    else
    {
        printf("Binary tree balanced");
    }
    tree_destroy(tree);
}