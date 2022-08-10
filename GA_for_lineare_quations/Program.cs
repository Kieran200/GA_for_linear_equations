using System;
using System.Collections.Generic;


namespace GA_for_lineare_quations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Для уравнений типа ax+b=c");
            Console.WriteLine("Введите угловой коэффициент, свободный коэффициент и результат уравнения");
            GA ga = new GA();
            ga.Genetic_Algorithm(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
        }
    }
}
