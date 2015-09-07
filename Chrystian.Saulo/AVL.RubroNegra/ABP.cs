using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVLTree
{
    public class ABP
    {
        public Nodo raiz;
        public ABP()
        {
            raiz = null;
        }
        public void EmOrdem(Nodo theraiz) //ORDEM - Recebe a arvore como parametro
        {
            if (!(theraiz == null))
            {
                EmOrdem(theraiz.Esquerdo);
                theraiz.MostrarnaTela();
                EmOrdem(theraiz.Direito);
            }
        }

        public void PreOrdem(Nodo theraiz) //PRE-ORDEM - Recebe a arvore como parametro
        {
            if (!(theraiz == null))
            {
                theraiz.MostrarnaTela();
                PreOrdem(theraiz.Esquerdo);
                PreOrdem(theraiz.Direito);
            }
        }

        public void PosOrdem(Nodo theraiz) //POS-ORDEM - Recebe a arvore como parametro
        {
            if (!(theraiz == null))
            {
                PosOrdem(theraiz.Esquerdo);
                PosOrdem(theraiz.Direito);
                theraiz.MostrarnaTela();
            }
        }

        public void Inserir(int v)
        {
            Nodo novoNo = new Nodo();

            novoNo.valor = v;

            if (raiz == null) // se a arvore for vazia, inicia uma nova árvore
            {
                raiz = novoNo;
            }
            else //se a árvore nao estiver vazia, a inserção será feita em seu devido lugar
            {
                Nodo current = raiz; //ramificação atual

                Nodo parent; //ramificação ancestral

                while (true) //a condição de parada não é variável, o laço while será parado pela condição 'break', 
                {                   //que indicará que o item inserido chegou na raiz da árvore

                    parent = current;

                    if (v < current.valor) // se o nó a ser inserido for menor que o nó a ser comparado
                    {
                        current = current.Esquerdo; // nó corrente recebe o nó que está a esquerda do nó corrente
                        if (current == null) // se o nó corrente for vazio
                        {
                            parent.Esquerdo = novoNo; // o nó que está a esquerda do nó ancestral recebe o novo nó
                            break;
                        }
                    }
                    else // se o nó a ser inserido for maior que o nó a ser comparado
                    {
                        current = current.Direito;  // nó corrente recebe o nó que está a direita do nó corrente
                        if (current == null)  // se o nó corrente for vazio
                        {
                            parent.Direito = novoNo;  // o nó que está a esquerda do nó ancestral recebe o novo nó
                            break;
                        }
                    }
                }
            }
        }

        public Nodo Buscar(int chave)
        {
            Nodo current = raiz;
            while (current.valor != chave)
            {
                if (chave < current.valor)
                    current = current.Esquerdo;
                else
                    current = current.Direito;
                if (current == null)
                    return null;
            }
            return current;
        }


        public bool Excluir(int chave)
        {
            Nodo current = raiz;
            Nodo parent = raiz;
            bool filhosEsquerda = true;
            while (current.valor != chave)
            {
                parent = current;
                if (chave < current.valor)
                {
                    filhosEsquerda = true;
                    current = current.Esquerdo;
                }
                else
                {
                    filhosEsquerda = false;
                    current = current.Direito;
                }

                if (current == null)
                {
                    return false;
                }
                if ((current.Esquerdo == null) && (current.Direito == null))
                {
                    if (current == raiz)
                    {
                        raiz = null;
                    }
                    else if (filhosEsquerda)
                    {
                        parent.Esquerdo = null;
                    }
                    else
                    {
                        parent.Direito = null;
                    }
                }
                else if (current.Direito == null)
                {
                    if (current == raiz)
                    {
                        raiz = current.Esquerdo;
                    }
                    else if (filhosEsquerda)
                    {
                        parent.Esquerdo = current.Esquerdo;
                    }
                    else
                        parent.Direito = current.Direito;
                }
                else if (current.Esquerdo == null)
                {
                    if (current == raiz)
                    {
                        raiz = current.Direito;
                    }
                    else if (filhosEsquerda)
                    {
                        parent.Esquerdo = current.Direito;
                    }
                    else
                    {
                        parent.Direito = current.Direito;
                    }
                }
                Nodo successor = RetornaSuccessor(current);
                if (current == raiz)
                    raiz = successor;
                else if (filhosEsquerda)
                    parent.Esquerdo = successor;
                else
                    parent.Direito = successor;
                successor.Esquerdo = current.Esquerdo;
            }
            return true;
        }


        public Nodo RetornaSuccessor(Nodo delNode)
        {
            Nodo successorParent = delNode;
            Nodo successor = delNode;
            Nodo current = delNode.Direito;
            while (!(current == null))
            {
                successorParent = current;
                successor = current;
                current = current.Esquerdo;
            }
            if (!(successor == delNode.Direito))
            {
                successorParent.Esquerdo = successor.Direito;
                successor.Direito = delNode.Direito;
            }
            return successor;
        }


    }
}
