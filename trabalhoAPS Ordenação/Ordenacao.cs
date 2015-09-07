using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace trabalhoAPS
{
    class Ordenacao
    {
        public static void InsertionSort(ref int[] A)
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

        public static void SelectionSort(ref int[] vetor)
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


        public static void BubbleSortCrescente(ref int[] vetor)
        {

            //Ordem crescente

            for (int i = 0; i < vetor.Length; i++)
            {
                for (int j = vetor.Length -1 ; j > i; j--)
                {
                    if (vetor[i] > vetor[j])
                    {
                        int swap = vetor[i];
                        vetor[i] = vetor[j];
                        vetor[j] = swap;

                    }
                }
            }
        }

        #region QuickSort
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
        #endregion

        #region HeapSort
        public static void HeapSort(ref int[] v)
        {
            buildMaxHeap(ref v);
            int n = v.Length;

            for (int i = v.Length - 1; i > 0; i--)
            {

                swap(v, i, 0);
                maxHeapify(v, 0, --n);
            }
        }
        private static void buildMaxHeap(ref int[] v)
        {
            for (int i = v.Length / 2 - 1; i >= 0; i--)
                maxHeapify(v, i, v.Length);
        }
        private static void maxHeapify(int[] v, int pos, int n)
        {
            int max = 2 * pos + 1, right = max + 1;
            if (max < n)
            {
                if (right < n && v[max] < v[right])
                    max = right;
                if (v[max] > v[pos])
                {
                    swap(v, max, pos);
                    maxHeapify(v, max, n);
                }
            }
        }

        public static void swap(int[] v, int j, int aposJ)
        {
            int aux = v[j];
            v[j] = v[aposJ];
            v[aposJ] = aux;
        }
        #endregion

    }
}
