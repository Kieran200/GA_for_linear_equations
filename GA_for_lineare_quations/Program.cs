using System;
using System.Collections.Generic;


namespace GA_for_lineare_quations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Для уравнений типа ax1+bx2+dx3+...+zxn=c");
            Console.WriteLine("Введите количество коэффициентов уравнения, которые хотите добавить");
            int count = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите коэффициенты уравнения");
            GA ga = new GA();
            List<double> descList = new List<double>();
            for (int i = 0; i < count; i++)
                descList.Add(Convert.ToDouble(Console.ReadLine()));
            Console.WriteLine("Введите результат уравнения");
            double solub = Convert.ToDouble(Console.ReadLine());
            ga.Genetic_Algorithm(descList, solub);
           
        }
    }
}
