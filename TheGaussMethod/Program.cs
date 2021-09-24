using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGaussMethod
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = 0;
            int m = 0;

            Console.WriteLine("Введите количество строк: ");
            try
            {
                n = Convert.ToInt32(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Вы ввели некорректное колличество строк");
            }


            Console.WriteLine("Введите количество столбцов: ");
            try
            {
                m = Convert.ToInt32(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Вы ввели некорректное колличество столбцов");
            }

            double[,] arrA = new double[100, 100];
            double[] arrB = new double[100];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите коэффициенты x-ов: ");
                for (int j = 0; j < m; j++)
                {
                    arrA[i, j] = Convert.ToDouble(Console.ReadLine());
                }
                Console.WriteLine("Введите коэффициент b: ");
                arrB[i] = Convert.ToDouble(Console.ReadLine());
            }

            Console.WriteLine("\nВаша матрица:");

            double[] A = new double[100];
            for (int i = 0; i < n; i++)
            {
             
                for (int j = 0; j < m; j++)
                {
                    Console.Write(arrA[i, j] + " ");
                }

                Console.WriteLine("|" + arrB[i]);
            }

            int N = n;
            for (int p = 0; p < N; p++)
            {
                int max = p;
                for (int i = p + 1; i < N; i++)
                {
                    if (Math.Abs(arrA[i, p]) > Math.Abs(arrA[max, p]))
                    {
                        max = i;
                    }
                }

                double[] temp = new double[100];
                for (int i = 0; i < N; i++)
                {
                    temp[i] = arrA[p, i];
                }

                for (int i = 0; i < N; i++)
                {
                    arrA[p, i] = arrA[max, i];
                }

                for (int i = 0; i < N; i++)
                {
                    arrA[max, i] = temp[i];
                }

                double t = arrB[p];
                arrB[p] = arrB[max];
                arrB[max] = t;

                if (Math.Abs(arrA[p, p]) <= 1e-10)
                {
                    Console.WriteLine("Решения не существует");
                    return;
                }

                for (int i = p + 1; i < N; i++)
                {
                    double a = arrA[i, p] / arrA[p, p];
                    arrB[i] -= a * arrB[p];
                    for (int j = p; j < N; j++)
                    {
                        arrA[i, j] = -a * arrA[p, j];
                    }
                }
            }

            double[] x = new double[N];
            for (int i = N - 1; i >= 0; i--)
            {
                double sum = 0.0;
                for (int j = i + 1; j < N; j++)
                {
                    sum += arrA[i, j] * x[j];
                }
                x[i] = (arrB[i] - sum) / arrA[i, i];
            }

            if (n < m)
            {
                Console.WriteLine("Бесконечное множество решений");
            }
            else
            {
                Console.WriteLine("\nРешение системы:");
                for (int i = 0; i < N; i++)
                {
                    Console.WriteLine(x[i] + " ");
                }
            }

        }
    }
}
