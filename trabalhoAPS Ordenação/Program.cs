using System;
using System.IO;
using System.Threading;
namespace trabalhoAPS
{
    class Program
    {
        static int seed = 1;
        public const int Tamanho = 100000;
        public static int[][] lista;

        public static void escreverNaTela(int numero)
        {
            Console.SetCursorPosition(3, 5);
            Console.Write("{0:0,0}", numero);
        }

        static void inicializarLista()
        {
            lista = new int[5][];
            lista[0] = new int[Tamanho];
            lista[1] = new int[Tamanho];
            lista[2] = new int[Tamanho];
            lista[3] = new int[Tamanho];
            lista[4] = new int[Tamanho];
            Random a = new Random(seed);
            string caminho = AppDomain.CurrentDomain.BaseDirectory + "numeros aleatorios.txt";
            StreamWriter b = new StreamWriter(caminho);
            for (int i = 0; i < Tamanho; i++)
            {
                int num = a.Next(1, int.MaxValue);

                if (!repetido(num))
                {
                    lista[0][i] = num;
                    // b.WriteLine(num);

                  //  if (i % 100 == 0)
                        escreverNaTela(i);

                }
                else
                    i--;

            }
            for (int i = 0; i < Tamanho; i++)
                lista[1][i] = lista[2][i] = lista[3][i] = lista[4][i] = lista[0][i];
            b.Close();

        }

        static bool repetido(int numero)
        {
            for (int i = 0; i < lista[0].Length; i++)
            {
                if (i == 0)
                    return false;
                if (i == numero)
                    return true;
            }
            return false;
        }

        static void Main(string[] args)
        {

            Console.CursorVisible = false;
            Console.WriteLine();
            Console.WriteLine("Elementos:      {0:0,0}\n", Tamanho);
            Console.WriteLine("Hora Inicial:   {0:hh:mm:ss}\n", DateTime.Now);
            double tempo = Environment.TickCount;
            inicializarLista();
            Console.WriteLine("\n\nIniciando lista:{0} segundos\n", (Environment.TickCount - tempo) / 1000);

            tempo = Environment.TickCount;
            Ordenacao.InsertionSort(ref lista[0]);
            Console.WriteLine("Insertion Sort: {0} segundos", (Environment.TickCount - tempo) / 1000);


            tempo = Environment.TickCount;
            Ordenacao.SelectionSort(ref lista[1]);
            Console.WriteLine("Selection Sort: {0} segundos", (Environment.TickCount - tempo) / 1000);

            tempo = Environment.TickCount;
            Ordenacao.BubbleSortCrescente(ref lista[2]);
            Console.WriteLine("Bubble Sort:    {0} segundos", (Environment.TickCount - tempo) / 1000);

            tempo = Environment.TickCount;
            Ordenacao.OrdenarQuickSort(ref lista[3]);
            Console.WriteLine("Quick Sort:     {0} segundos", (Environment.TickCount - tempo) / 1000);

            tempo = Environment.TickCount;
            Ordenacao.HeapSort(ref lista[0]);
            Console.WriteLine("Heap Sort:      {0} segundos\n", (Environment.TickCount - tempo) / 1000);

            Console.WriteLine("Hora  Final:    {0:hh:mm:ss}", DateTime.Now);

            Console.ReadKey();
        }
    }
}
