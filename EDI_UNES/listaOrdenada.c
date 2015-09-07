#include <stdio.h>
#include <stdlib.h>

struct lista {
       int info;
       struct lista* prox;
};

typedef struct lista Lista;

/* fun��o de inicializa��o: retorna uma lista vazia */
Lista* inicializa (void)
{
   return NULL;
}

/* inser��o no in�cio: retorna a lista atualizada */
Lista* insere (Lista* l, int i)
{
   Lista* novo = (Lista*) malloc(sizeof(Lista));
   novo->info = i;
   novo->prox = l;
   return novo;
}

/* fun��o imprime: imprime valores dos elementos */
void imprime (Lista* l)
{
   Lista* p;   /* vari�vel auxiliar para percorrer a lista */
   for (p = l; p != NULL; p = p->prox)
      printf("info = %d\n", p->info);
}

/* fun��o vazia: retorna 1 se vazia ou 0 se n�o vazia */
int vazia (Lista* l)
{
   return (l == NULL);
}

/* fun��o busca: busca um elemento na lista */
Lista* busca (Lista* l, int v)
{
   Lista* p;
   for (p=l; p!=NULL; p=p->prox)
      if (p->info == v)
         return p;
   return NULL;       /* n�o achou o elemento */
}

/* fun��o retira: retira elemento da lista */
Lista* retira (Lista* l, int v) {
   Lista* ant = NULL; /* ponteiro para elemento anterior */
   Lista* p = l;      /* ponteiro para percorrer a lista*/
   /* procura elemento na lista, guardando anterior */
   while (p != NULL && p->info != v) {
      ant = p;
      p = p->prox;
   }
   /* verifica se achou elemento */
   if (p == NULL)
      return l;   /* n�o achou: retorna lista original */
   /* retira elemento */
   if (ant == NULL) {
      /* retira elemento do inicio */
      l = p->prox;
   }
   else {
      /* retira elemento do meio da lista */
      ant->prox = p->prox;
   }
   free(p);
   return l;
}

void libera (Lista* l)
{
   Lista* p = l;
   while (p != NULL) {
       Lista* t = p->prox; /* guarda refer�ncia para o pr�ximo elemento
*/
      free(p);            /* libera a mem�ria apontada por p */
      p = t;              /* faz p apontar para o pr�ximo */
   }
}

/* fun��o auxiliar: cria e inicializa um n� */
Lista* cria (int v)
{
   Lista* p = (Lista*) malloc(sizeof(Lista));
   p->info = v;
   return p;
}
/* fun��o insere_ordenado: insere elemento em ordem */
Lista* insere_ordenado (Lista* l, int v)
{
   Lista* novo = cria(v); /* cria novo n� */
   Lista* ant = NULL;     /* ponteiro para elemento anterior */
   Lista* p = l;          /* ponteiro para percorrer a lista*/
   /* procura posi��o de inser��o */
   while (p != NULL && p->info < v) {
      ant = p;
      p = p->prox;
   }
   /* insere elemento */
   if (ant == NULL) {   /* insere elemento no in�cio */
      novo->prox = l;
      l = novo;
   }
   else {   /* insere elemento no meio da lista */
      novo->prox = ant->prox;
      ant->prox = novo;
   }
   return l;
}

/* Fun��o imprime recursiva */
void imprime_rec (Lista* l)
{
   if (vazia(l))
      return;
   /* imprime primeiro elemento */
   printf("info: %d\n",l->info);
   /* imprime sub-lista */
   imprime_rec(l->prox);
}

/* Fun��o retira recursiva */
Lista* retira_rec (Lista* l, int v)
{
   if (vazia(l))
      return l;   /* lista vazia: retorna valor original */
   /* verifica se elemento a ser retirado � o primeiro */
   if (l->info == v) {
      Lista* t = l;     /* tempor�rio para poder liberar */
      l = l->prox;
      free(t);
   }
   else {
      /* retira de sub-lista */
      l->prox = retira_rec(l->prox,v);
   }
   return l;
}

void libera_rec (Lista* l)
{
   if (!vazia(l))
   {
      libera_rec(l->prox);
      free(l);
   }
}

void imprime_circular (Lista* l)
{
   Lista* p = l;        /* faz p apontar para o n� inicial */
   /* testa se lista n�o � vazia */
   if (p) 
   {
      /* percorre os elementos at� alcan�ar novamente o in�cio */
      do {
         printf("%d\n", p->info);   /* imprime informa��o do n� */
         p = p->prox;               /* avan�a para o pr�ximo n� */
      } while (p != l);
      }
}

int main()
{
  Lista* l;
  l = inicializa();
  l = insere_ordenado(l, 78);
  l = insere_ordenado(l, 56);
  l = insere_ordenado(l, 23);
  l = insere_ordenado(l, 45);
  imprime_rec(l);
  l = retira_rec(l, 78);
  imprime_rec(l);
  l = retira_rec(l, 45);
  imprime_rec(l);
  libera_rec(l);
  system("PAUSE");	
  return 0;
}
