#include <stdio.h>
#include <stdlib.h>

struct lista2 {
   int info;
   struct lista2* ant;
struct lista2* prox;
};

typedef struct lista2 Lista2;

/* inser��o no in�cio */
Lista2* insere (Lista2* l, int v)
{
   Lista2* novo = (Lista2*)malloc(sizeof(Lista2));
   novo->info = v;
   novo->prox = l;
   novo->ant = NULL;
   /* verifica se lista n�o est� vazia */
   if (l != NULL)
      l->ant = novo;
return novo;
}

/* fun��o busca: busca um elemento na lista */
Lista2* busca (Lista2* l, int v)
{
   Lista2* p;
   for (p=l; p!=NULL; p=p->prox)
      if (p->info == v)
         return p;
   return NULL;       /* n�o achou o elemento */
}

/* fun��o retira: retira elemento da lista */
Lista2* retira (Lista2* l, int v) {
   Lista2* p = busca(l,v);
   if (p == NULL)
      return l;   /* n�o achou o elemento: retorna lista inalterada */
   /* retira elemento do encadeamento */
   if (l == p)
      l = p->prox;
   else
      p->ant->prox = p->prox;
   if (p->prox != NULL)
      p->prox->ant = p->ant;
   free(p);
   return l;
}

void imprime_circular_rev (Lista2* l)
{
   Lista2* p = l;        /* faz p apontar para o n� inicial */
   /* testa se lista n�o � vazia */
   if (p)
   {
      /* percorre os elementos at� alcan�ar novamente o in�cio */
      do {
         printf("%d\n", p->info);   /* imprime informa��o do n� */
         p = p->ant;                /* "avan�a" para o n� anterior */
      } while (p != l);
   }
}

int main(int argc, char *argv[])
{
  
  system("PAUSE");	
  return 0;
}
