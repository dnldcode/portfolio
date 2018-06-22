using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWorkN1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Calc 
            //double a, b, answer;
            //string op, answ;
            //while (true)
            //{
            //    try
            //    {
            //        Console.Write("\n Введите первое число : ");
            //        a = Double.Parse(Console.ReadLine());
            //    }
            //    catch (FormatException e)
            //    {
            //        Console.WriteLine("\n Ошибка : " + e.Message);
            //        continue;
            //    }
            //    try
            //    {
            //        Console.Write(" Введите второе число : ");
            //        b = Double.Parse(Console.ReadLine());
            //    }
            //    catch (FormatException e)
            //    {
            //        Console.WriteLine("\n Ошибка : " + e.Message);
            //        continue;
            //    }
            //    Console.Write(" Введите оператор : ");
            //    op = Console.ReadLine();
            //    switch (op)
            //    {
            //        case "+":
            //            answer = a + b;
            //            break;
            //        case "-":
            //            answer = a - b;
            //            break;
            //        case "*":
            //            answer = a * b;
            //            break;
            //        case "/":
            //            answer = a / b;
            //            break;
            //        default:
            //            Console.WriteLine("\n Ошибка. Не найден оператор, попробуйте снова.");
            //            continue;
            //    }
            //    Console.WriteLine(" a {0} b = {1}", op, answer);
            //    Console.Write(" Продолжить работу с калькулятором?(1 - да, любая другая - нет) : ");
            //    answ = Console.ReadLine();
            //    if (answ != "1")
            //        break;
            //}

            //Degree
            //int a, degr;
            //double answer;
            //string answ;
            //while (true)
            //{
            //    try
            //    {
            //        Console.Write("\n Введите число : ");
            //        a = Int32.Parse(Console.ReadLine());
            //    }
            //    catch(FormatException e)
            //    {
            //        Console.WriteLine("\n Ошибка : " + e.Message);
            //        continue;
            //    }
            //    try
            //    {
            //        Console.Write("\n Введите степень : ");
            //        degr = Int32.Parse(Console.ReadLine());
            //    }
            //    catch(FormatException e)
            //    {
            //        Console.WriteLine("\n Ошибка : " + e.Message);
            //        continue;
            //    }
            //    answer = a;
            //    if (degr == 0)
            //        answer = 1;
            //    else
            //    {
            //        for (int i = 0; i < Math.Abs(degr) - 1; i++)
            //            answer *= a;
            //        if (degr < 0)
            //            answer = 1 / answer;
            //    }
            //    Console.WriteLine(" {0}^{1} = {2}", a, degr, answer);
            //    Console.Write(" Продолжить работу с калькулятором?(1 - да, любая другая - нет) : ");
            //    answ = Console.ReadLine();
            //    if (answ != "1")
            //        break;
            //}

            //Count of nums
            //long a;
            //int count;
            //string answ;
            //while (true)
            //{
            //    count = 1;
            //    try
            //    {
            //        Console.Write("\n Введите число : ");
            //        a = Int32.Parse(Console.ReadLine());
            //    }
            //    catch(FormatException e)
            //    {
            //        Console.WriteLine("\n Ошибка : " + e.Message);
            //        continue;
            //    }

            //    while (a >= 10)
            //    {
            //        a /= 10;
            //        count++;
            //    }

            //    Console.WriteLine(" {0} ", count);
            //    Console.Write(" Продолжить работу с калькулятором?(1 - да, любая другая - нет) : ");
            //    answ = Console.ReadLine();
            //    if (answ != "1")
            //        break;
            //}
        }
    }
}