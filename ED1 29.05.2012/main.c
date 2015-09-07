    #include <stdio.h>
    #include <stdlib.h>
                                                
    struct nodo{
           float info;
           struct  nodo* prox;
    };
    typedef struct nodo No;
                                                 
    struct Pilha{
           No* prim;
    };
    typedef struct Pilha PILHA;
                                                 
    PILHA* Cria(void){
           PILHA* P = (PILHA*) malloc(sizeof(PILHA));
           P->prim = NULL;
           return P;
    };
    No* Inserir_ini(No* L,float v){
        No* p=(No*)malloc(sizeof(No));
        p->info = v;
        p->prox =L;
        return p;
    };
    No* Retirar_Ini(No* L){
        No* p= L->prox;
        free(L);
        return p;
    }
                                                
    int main(int argc, char *argv[])
    {                                               
    system("PAUSE");	
    return 0;
    }
