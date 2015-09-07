using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BubbleSort
{
    public class Sorts
    {
        public static void OrdenarBubbleSort(int[] Vet, int tam)
        {
            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam - 1; j++)
                {
                    if (Vet[j] > Vet[j + 1])
                    {
                        int ant = Vet[j];
                        Vet[j] = Vet[j + 1];
                        Vet[j + 1] = ant;
                    }
                }
            }
        }

        public static void OrdenarInsertionSort(ref int[] A)
        {
            int i, j, index;
            for (i = 1; i < A.Length; i++)
            {
                index = A[i];
                j = i;
                while ((j > 0) && (A[j - 1] > index))
                {
                    A[j] = A[j - 1];
                    j = j - 1;
                }
                A[j] = index;
            }
        }

        public static void OrdenarSelectionSort(ref int[] vetor)
        {
            int min, aux;

            for (int i = 0; i < vetor.Length - 1; i++)
            {
                min = i;

                for (int j = i + 1; j < vetor.Length; j++)
                    if (vetor[j] < vetor[min])
                        min = j;

                if (min != i)
                {
                    aux = vetor[min];
                    vetor[min] = vetor[i];
                    vetor[i] = aux;
                }
            }
        }

        public static void OrdenarQuickSort(ref int[] vetor)
        {
            Ordenar(vetor, 0, vetor.Length - 1);
        }

        private static void Ordenar(int[] vetor, int inicio, int fim)
        {
            if (inicio < fim)
            {
                int posicaoPivo = Separar(vetor, inicio, fim);
                Ordenar(vetor, inicio, posicaoPivo - 1);
                Ordenar(vetor, posicaoPivo + 1, fim);
            }
        }

        private static int Separar(int[] vetor, int inicio, int fim)
        {
            int pivo = vetor[inicio];
            int i = inicio + 1, f = fim;
            while (i <= f)
            {
                if (vetor[i] <= pivo)
                    i++;
                else if (pivo < vetor[f])
                    f--;
                else
                {
                    int troca = vetor[i];
                    vetor[i] = vetor[f];
                    vetor[f] = troca;
                    i++;
                    f--;
                }
            }
            vetor[inicio] = vetor[f];
            vetor[f] = pivo;
            return f;
        }
    }
}
