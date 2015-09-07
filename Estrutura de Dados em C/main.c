#include <stdio.h>
#include <stdlib.h>

struct Lista
{
  int info;
  struct Lista* prox;     
};
typedef struct Lista LISTA;
// INICIALIZANDO A LISTA ENCADEADA
LISTA* Inicializa(void)
{
   return NULL;
}
// SIZEOF RETORNA O INTEIRO
LISTA* Insere (LISTA* l, int i)
{
    LISTA* novo = (LISTA*)malloc(sizeof(LISTA));
    novo->info =i;
    novo->prox = l;
    return novo;
}
void Imprime(LISTA* l)
{
     LISTA* p;
     for(p=l; p!=NULL; p=p->prox)
         printf("info = %d \n",p->info);
}
int main()
{
    LISTA* l;
    l = Inicializa();
    l = Insere(l,23);
    l = Insere(l,45);
    l = Insere(l,82);
    Imprime(l);
    system("PAUSE");	 
}
