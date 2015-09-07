using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVLTree
{
    class Program
    {
        static void Main(string[] args)
        {
            ABP arvore = new ABP();
            arvore.Inserir(20);
            arvore.Inserir(40);
            arvore.Inserir(30);
            arvore.Inserir(25);
            arvore.Inserir(70);

            arvore.Excluir(20);

            arvore.Buscar(25);

        }
    }
}
