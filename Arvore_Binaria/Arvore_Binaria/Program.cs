using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/* Código comentado de ESTRUTURA DE DADOS passado dia 25/10/2012  */
/* A dica pra quem após ler estes comentarios ferrados ainda não entendeu é colocar um BREAKPOINT na classe BST e ir*/
/* acompanhando a inserção dos valores na árvore*/
namespace Arvore_Binaria
{
    class Program
    {
        static void Main(string[] args)
        {
            BST b = new BST(); // Instancio a classe BST (criando assim uma árvore vazia)


            //Faço inserção de valores aleatórios que eu escolhi
            b.insert(23);
            b.insert(45);
            b.insert(16);
            b.insert(37);
            b.insert(3);
            b.insert(99);
            b.insert(22);

            b.inOrder(b.root); //Exibe em ordem
            Console.WriteLine();

            b.preOrder(b.root); //Exibe em pre-ordem
            Console.WriteLine();

            b.postOrder(b.root); //Exibe em pos-ordem
            Console.WriteLine();

            Console.ReadKey();
        }
    }

    public class Node //CRIA A ESTRUTURA DA ARVORE
    {
        public int Data; //ARMAZENA O VALOR NO NÓ
        public Node Left; //ARMAZENA O  NÓ A ESQUERDA
        public Node Right; //ARMAZENA O  NÓ A DIREITA
        public void DisplayNode() //EXIBE O NÓ NA TELA
        {
            Console.Write(Data + " ");
        }
    }

    public class BST //binary search tree (Árvore binária de pesquisa)
    {
        public Node root; //CRIA UM OBJETO 'root' DO TIPO NÓ('node')
        public BST()
        {
            root = null; //Crio uma nova BST assim que algum objeto instanciar a classe BST
        }
        public void inOrder(Node theRoot) //ORDEM - Recebe a arvore como parametro
        {
            if (!(theRoot == null))
            {
                inOrder(theRoot.Left);
                theRoot.DisplayNode();
                inOrder(theRoot.Right);
            }
        }

        public void preOrder(Node theRoot) //PRE-ORDEM - Recebe a arvore como parametro
        {
            if (!(theRoot == null))
            {
                theRoot.DisplayNode();
                preOrder(theRoot.Left);                
                preOrder(theRoot.Right);
            }
        }

        public void postOrder(Node theRoot) //POS-ORDEM - Recebe a arvore como parametro
        {
            if (!(theRoot == null))
            {              
                postOrder(theRoot.Left);
                postOrder(theRoot.Right);
                theRoot.DisplayNode();
            }
        }

        public void insert(int v)
        {
            Node newNode = new Node(); // Instancia um novo nó

            newNode.Data = v; //o valor (atributo Data) do nó recebe v (valor aleatório que passei como parametro)

            if (root == null) // se a arvore for vazia, inicia uma nova árvore
            {
                root = newNode;
            }
            else //se a árvore nao estiver vazia, a inserção será feita em seu devido lugar
            {
                Node current = root; //ramificação atual

                Node parent; //ramificação ancestral

                while (true) //a condição de parada não é variável, o laço while será parado pela condição 'break', 
                {                   //que indicará que o item inserido chegou na raiz da árvore

                    parent = current; 

                    if (v < current.Data) // se o nó a ser inserido for menor que o nó a ser comparado
                    {
                        current = current.Left; // nó corrente recebe o nó que está a esquerda do nó corrente
                        if (current == null) // se o nó corrente for vazio
                        {
                            parent.Left = newNode; // o nó que está a esquerda do nó ancestral recebe o novo nó
                            break;
                        }
                    }
                    else // se o nó a ser inserido for maior que o nó a ser comparado
                    {
                        current = current.Right;  // nó corrente recebe o nó que está a direita do nó corrente
                        if (current == null)  // se o nó corrente for vazio
                        {
                            parent.Right = newNode;  // o nó que está a esquerda do nó ancestral recebe o novo nó
                            break;
                        }
                    }
                }
            }
           
        }
    }    
}
