#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <string.h>


struct text
{
    char str[100];
};


void main(void)
{
    FILE *MyFile;
    text filetext[50];
    int i = 0, iterator, size;;
    MyFile = fopen("MyFile.txt", "r");
    if (MyFile == NULL)
    {
        printf("Error opening file\n");
    }
    else
    {
        printf("File is open\n\n");
        while (fscanf(MyFile, "%s", filetext[i].str) != EOF)
        {
           printf("%s\n", filetext[i].str);
            i++;
        }
        printf("\n");
        for (int j = 0; j < i; j++)
        {
            iterator = 0;
            size = strlen(filetext[j].str);
            for (int k = 0; k < size; k++)
            {
                if ((filetext[j].str[k] == 'A') || (filetext[j].str[k] == 'B') || (filetext[j].str[k] == 'E') ||
                    (filetext[j].str[k] == 'K') || (filetext[j].str[k] == 'P') || (filetext[j].str[k] == 'M') ||
                    (filetext[j].str[k] == 'H') || (filetext[j].str[k] == 'O') || (filetext[j].str[k] == 'C') ||
                    (filetext[j].str[k] == 'T') || (filetext[j].str[k] == 'X') || (filetext[j].str[k] == 'a') ||
                    (filetext[j].str[k] == 'e') || (filetext[j].str[k] == 'k') || (filetext[j].str[k] == 'p') ||
                    (filetext[j].str[k] == 'o') || (filetext[j].str[k] == 'c') || (filetext[j].str[k] == 'x'))
                {
                    iterator++;
                    continue;
                }
            }
            if (iterator == size)
            {
                for (int m = 0; m < size; m++)
                {
                    printf("%c", filetext[j].str[m]);
                }
                printf("\t");
            }
        }
    }
    printf("\n");
    fclose(MyFile);
}

