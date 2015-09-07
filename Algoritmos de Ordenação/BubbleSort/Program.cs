using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BubbleSort
{
    class Program
    {
        private static DateTime HoraInicio;
        private static TimeSpan Diferenca;
        private static int TamanhoVetor = 0;
        private static int[] vetor = new int[0];
        private static Random r = new Random();


        private static byte Opcoes()
        {
            Console.Clear();
            Console.Title = "Algorítmo de Ordenação";
            Console.WriteLine("\n------------------------------------------------- ");
            Console.WriteLine("\tEscolha um Ordenador e o tamanho do vetor ");
            Console.WriteLine("-------------------------------------------------\n\n");
            Console.WriteLine(" 1 - Bubble Sort ");
            Console.WriteLine(" 2 - Insertion Sort ");
            Console.WriteLine(" 3 - Selection Sort ");
            Console.WriteLine(" 4 - Quick Sort");
            Console.WriteLine(" 5 - Sair  \n\n ");
            Console.WriteLine("---------------------");
            Console.Write(" Informe a Opção Desejada: ");
            byte op;
            while (!byte.TryParse(Console.ReadLine(), out op))
            {
                Console.Write("\n\n\t Opção Inválida! Digite novamente: ");
            }
            if (op != 5)
            {
                Console.Clear();
            }
            else
            {
                Console.WriteLine("\n\n Obrigado por utilizar este programa...");
                Console.ReadKey();
            }
            return op;
        }

        private static void MostrarVetorTempo(TimeSpan Resultado)
        {
            Console.Clear();
            for (int i = 0; i < TamanhoVetor; i++)
            {
                Console.Write("{0} ", vetor[i]);
            }

            Console.WriteLine("\n\nTamanho do vetor: " + vetor.Length);
            Console.WriteLine("\n\nTempo para  : {0} Minutos, {1} Segundos, {2} Milisegundos", Diferenca.Minutes,
                Resultado.Seconds, Diferenca.Milliseconds);
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            bool sair = false;
            do
            {

                switch (Opcoes())
                {
                    case 1:
                        Console.Write("Tamanho do vetor: ");
                        TamanhoVetor = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < TamanhoVetor; i++)
                        {
                            Array.Resize(ref vetor, TamanhoVetor);
                            vetor[i] = r.Next(0, 1000);
                        }
                        HoraInicio = DateTime.Now;

                        //BUBBLE SORT
                        Sorts.OrdenarBubbleSort(vetor, TamanhoVetor);
                        
                        Diferenca = DateTime.Now - HoraInicio;
                        MostrarVetorTempo(Diferenca);
                        break;
                    case 2:
                        Console.Write("Tamanho do vetor: ");
                        TamanhoVetor = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < TamanhoVetor; i++)
                        {
                            Array.Resize(ref vetor, TamanhoVetor);
                            vetor[i] = r.Next(0, 1000);
                        }
                        HoraInicio = DateTime.Now;

                        //INSERTION SORT
                        Sorts.OrdenarInsertionSort(ref vetor);

                        Diferenca = DateTime.Now - HoraInicio;
                        MostrarVetorTempo(Diferenca);
                        break;
                    case 3:
                        Console.Write("Tamanho do vetor: ");
                        TamanhoVetor = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < TamanhoVetor; i++)
                        {
                            Array.Resize(ref vetor, TamanhoVetor);
                            vetor[i] = r.Next(0, 1000);
                        }
                        HoraInicio = DateTime.Now;

                        // SELECTION SORT
                        Sorts.OrdenarSelectionSort(ref vetor);

                        Diferenca = DateTime.Now - HoraInicio;
                        MostrarVetorTempo(Diferenca);
                        break;
                    case 4:
                        Console.Write("Tamanho do vetor: ");
                        TamanhoVetor = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < TamanhoVetor; i++)
                        {
                            Array.Resize(ref vetor, TamanhoVetor);
                            vetor[i] = r.Next(0, 1000);
                        }
                        HoraInicio = DateTime.Now;

                        //QUICK SORT
                        Sorts.OrdenarQuickSort(ref vetor);

                        Diferenca = DateTime.Now - HoraInicio;
                        MostrarVetorTempo(Diferenca);
                        break;
                    default:
                        sair = true;
                        break;
                }

            } while (!sair);
           
        }

        
    }
}
