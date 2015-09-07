using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVLTree
{
    public class Nodo
    {
        public int valor;
        public Nodo Esquerdo;
        public Nodo Direito;

        public void MostrarnaTela()
        {
            Console.Write(valor + " ");
        }
    }
}
