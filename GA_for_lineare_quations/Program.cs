using System;
using System.Collections.Generic;


namespace GA_for_lineare_quations
{
    class Program
    {
        static void Main(string[] args)
        {
            int survival_rate = 101;            //3х+2=101
            int a = 3;
            int b = 2;
            int c = 101;
            

            Random rnd = new Random();
            List<Population> generationList = new List<Population>();

            List <List<Population>> parentsList = new List<List<Population>>(5);

            for (int i = 0; i < 5; i++)                           
            {
                Population subject = new Population(rnd.Next(1, c), survival_rate);
                generationList.Add(subject);
            }

            bool stop = true;
            while (stop)
            {
                float sum_of_reciprocals = 0;

                foreach (Population subject in generationList)
                {
                    subject.survival_rate = Math.Abs(101 - (3*subject.x+2));
                    if (subject.survival_rate != 0)
                        sum_of_reciprocals += 1 / subject.survival_rate;
                    else break;
                }
                foreach (Population subject in generationList)
                {
                    if (subject.survival_rate != 0)
                        subject.survival_percent = 100*((1 / subject.survival_rate) / sum_of_reciprocals);
                    else break;
                }

                foreach (Population subject in generationList)
                {
                    if (subject.survival_rate == 0)
                    {
                        Console.WriteLine("x = " + subject.x);
                        stop = false;
                    }

                }

                //ранжирование списка популяции
                float number = 0; //локальная переменная 
                for (int i = 0;  i < generationList.Count-1; i++)
                {
                    if (generationList[i].survival_percent > generationList[i+1].survival_percent)
                    {
                        number = generationList[i].survival_percent;
                        generationList[i].survival_percent = generationList[i + 1].survival_percent;
                        generationList[i+1].survival_percent = number;
                        i = -1;
                    }
                }
                //
                parentsList.Clear();
                for (int i = 0; i < 5; i++)
                {
                    parentsList.Add(new List<Population> { generationList[rnd.Next(0, 2)], generationList[rnd.Next(2, 5)] });
                }

                //создаем новое поколение
                generationList.Clear();
                foreach (List<Population> parents in parentsList) 
                {
                    Population subject = new Population(parents[rnd.Next(0, 2)].x, survival_rate);
                    generationList.Add(subject);
                }

                int mutation_coef = rnd.Next(0,11);
                if (mutation_coef == 5)
                {
                    generationList[rnd.Next(0, 5)].x = rnd.Next(0, c);
                }
            }
        }
    }
}
