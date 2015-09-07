using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArvoreRubroNegra
{
    class Program
    {
        static void Main(string[] args)
        {
            RedBlackTree<string>.Inserir("50");
            RedBlackTree<string>.Inserir("120");
            RedBlackTree<string>.Inserir("25");
            RedBlackTree<string>.Inserir("40");
        }
    }
}
