#include <stdio.h>
#include <stdlib.h>

void MostrarPonteiros(){
     int n;
     int *pt;
     n=5;
     pt = n;
     printf("\t\n\n\nO Valor da variavel referenciada por pt = %d\n  ",pt);
     
}
void MostrarPonteiros2(){
     int n;
     int *pt1,*pt2;
     n=5;
     pt1 = &n;
     pt2 = pt1;
     printf("\t\n\n\nO Valor da variavel referenciada por pt = %d\n  ",*pt1);
     
}

int main()
{
    int num;
    int *pt1,*pt2;
    num=5;
    pt2 = &num;
    pt1 = pt2;
    printf("\n\tValor de num: %d \n",num);
    printf("\tEndereco armazenado em pt1: %d \n",&pt1);
    printf("\tEndereco armazenado em pt2: %d \n",pt2);
    MostrarPonteiros();
    MostrarPonteiros2();
    system("PAUSE");
}

