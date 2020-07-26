using System;
using System.Collections.Generic;
using System.Linq;

namespace teste1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            double[] numeros;
            Console.Write("Quantidade de números que você deseja informar: ");
            int n = int.Parse(Console.ReadLine());
            numeros = new double[n];
            for (int posicao = 1; posicao <= n; posicao++)
            {
                Console.Write($"Informe o número ({ posicao }) : ");
                int numero = int.Parse(Console.ReadLine());

                VerificaPositivo(numero, posicao);
                list.Add(numero);

            }

            double soma = 0.0;
            int TotalNaLista = list.Count() - 1;

            int cont = 1;
            int cont1 = 0;
            Console.WriteLine();
            Console.WriteLine("Resultado: ");
            Console.WriteLine();
            Console.Write("Os números informados foram: ");

            foreach (double obj in list)
            {
                Console.Write(obj);
                if (cont <= TotalNaLista)
                {
                    Console.Write(" | ");
                    cont++;
                }
                soma += obj;
               numeros[cont1++] = obj;
            }

            Double media = soma / n;
            Console.WriteLine();
            Console.WriteLine("A média dos números " + media);
            Console.WriteLine("A soma dos números é " + list.Sum());
            Console.WriteLine("O maior número é " + list.Max());
            Console.WriteLine("O menor número é " + list.Min());
            Console.WriteLine("Mediana: {0}", Moda(numeros).ToString());
        }

        private static void VerificaPositivo(int numero, int posicao)
        {
            while (numero > 0 || numero <= 1000)
            {
                if (numero > 0 && numero <= 1000)
                {
                    break;
                }
                else
                {
                    Console.Write($"Informe o número ({ posicao }) : número tem que ser menor que 1000 e maior que 0 : ");
                    numero = int.Parse(Console.ReadLine());
                }

            }
        }

        static public double Moda(double[] vs)
        {
            try
            {
                double[] i = new double[vs.Length];
                vs.CopyTo(i, 0);
                Sort(i);
                double valorModa = i[0], tempValorModa = i[0];
                int contador = 0, novoContador = 0;
                int j = 0;
                for (; j <= i.Length - 1; j++)
                    if (i[j] == tempValorModa) novoContador++;
                    else if (novoContador > contador)
                    {
                        contador = novoContador;
                        novoContador = 1;
                        tempValorModa = i[j];
                        valorModa = i[j - 1];
                    }
                    else if (novoContador == contador)
                    {
                        valorModa = double.NaN;
                        tempValorModa = i[j];
                        novoContador = 1;
                    }
                    else
                    {
                        tempValorModa = i[j];
                        novoContador = 1;
                    }
                if (novoContador > contador) valorModa = i[j - 1];
                else if (novoContador == contador) valorModa = double.NaN;
                return valorModa;
            }
            catch (Exception)
            {
                return double.NaN;
            }
        }
        private static void Sort(double[] i)
        {
            double[] temp = new double[i.Length];
            Merge_sort(i, temp, 0, i.Length - 1);
        }

        private static void Merge_sort(double[] source,
               double[] temp, int left, int right)
        {
            int mid;
            if (left < right)
            {
                mid = (left + right) / 2;
                Merge_sort(source, temp, left, mid);
                Merge_sort(source, temp, mid + 1, right);
                Merge(source, temp, left, mid + 1, right);
            }
        }

        private static void Merge(double[] source, double[] temp,
             int left, int mid, int right)
        {
            int i, left_end, num_elements, tmp_pos;
            left_end = mid - 1;
            tmp_pos = left;
            num_elements = right - left + 1;
            while ((left <= left_end) && (mid <= right))
            {
                if (source[left] <= source[mid])
                {
                    temp[tmp_pos] = source[left];
                    tmp_pos++;
                    left++;
                }
                else
                {
                    temp[tmp_pos] = source[mid];
                    tmp_pos++;
                    mid++;
                }
            }
            while (left <= left_end)
            {
                temp[tmp_pos] = source[left];
                left++;
                tmp_pos++;
            }
            while (mid <= right)
            {
                temp[tmp_pos] = source[mid];
                mid++;
                tmp_pos++;
            }
            for (i = 1; i <= num_elements; i++)
            {
                source[right] = temp[right];
                right--;
            }
        }


    }
}


