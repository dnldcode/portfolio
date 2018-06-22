using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWorkN2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random R = new Random();

            //#1
            //int[] ar = new int[20];
            //int max = - 50, min = 50;
            //Console.Write(" Array : ");
            //for (int i = 0; i < ar.Length; i++)
            //{
            //    ar[i] = R.Next(-50, 50);
            //    if (min > ar[i])
            //        min = ar[i];
            //    if (max < ar[i])
            //        max = ar[i];
            //    Console.Write("{0} ", ar[i]);
            //}
            //Console.WriteLine("\n Max : {0}, Min : {1} ", max, min);

            //#2
            //int[] ar = new int[20];
            //int temp, count = 0;
            //Console.Write(" Array 1 : ");
            //for (int i = 0; i < ar.Length; i++)
            //{
            //    ar[i] = R.Next(-50, 50);
            //    Console.Write("{0} ", ar[i]);
            //}
            //for (int i = 0; i < ar.Length - count; i++)
            //{
            //    if(ar[i] % 2 != 0)
            //    {
            //        for (int j = i + 1; j < ar.Length; j++)
            //        {
            //            temp = ar[j - 1];
            //            ar[j - 1] = ar[j];
            //            ar[j] = temp;
            //        }
            //        count++;
            //        i = 0;
            //    }
            //}
            //Console.Write("\n Array 2 : ");
            //for (int i = 0; i < ar.Length; i++)
            //    Console.Write("{0} ", ar[i]);
            //Console.WriteLine();

            //#3
            //int[,] ar = new int[3, 10];
            //int min;
            //int[] armin = new int[ar.GetLength(0) + ar.GetLength(1)];
            //for (int i = 0; i < ar.GetLength(0); i++)
            //{
            //    min = 100;
            //    for (int j = 0; j < ar.GetLength(1); j++)
            //    {
            //        ar[i, j] = R.Next(0, 100);
            //        if (min > ar[i, j])
            //            min = ar[i, j];
            //    }
            //    armin[i] = min;
            //}
            //for(int i = 0; i < ar.GetLength(1); i++)
            //{
            //    min = 100;
            //    for (int j = 0; j < ar.GetLength(0); j++)
            //    {
            //        if (min > ar[j, i])
            //            min = ar[j, i];
            //    }
            //    armin[i + ar.GetLength(0)] = min;
            //}
            //for (int i = 0; i < ar.GetLength(0); i++)
            //{
            //    for (int j = 0; j < ar.GetLength(1); j++)
            //    {
            //        Console.Write(" {0:D2}  ", ar[i, j]);
            //    }
            //    Console.Write("\t\t{0:D2}  ", armin[i]);
            //    Console.WriteLine();
            //}
            //Console.WriteLine("\n");
            //for (int j = ar.GetLength(0); j < armin.Length; j++)
            //    Console.Write(" {0:D2}  ", armin[j]);
            //Console.WriteLine();

            //#4
            //int[] A = new int[20];
            //int count = 0;

            //for (int i = 0; i < A.Length; i++)
            //{
            //    A[i] = R.Next(-50, 50);
            //    if (A[i] % 2 == 0)
            //        count++;
            //}
            //int[] B = new int[count];
            //count = 0;
            //for (int i = 0; i < A.Length; i++)
            //    if (A[i] % 2 == 0)
            //        B[count++] = A[i];

            //Console.Write(" Array A : ");
            //for (int i = 0; i < A.Length; i++)
            //    Console.Write("{0} ", A[i]);
            //Console.WriteLine();
            //Console.Write("\n Array B : ");
            //for (int i = 0; i < B.Length; i++)
            //    Console.Write("{0} ", B[i]);
            //Console.WriteLine();
        }
    }
}