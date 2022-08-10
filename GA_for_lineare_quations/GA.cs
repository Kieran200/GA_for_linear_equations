using System;
using System.Collections.Generic;
using System.Text;

namespace GA_for_lineare_quations
{
    class GA
    {
        public void Genetic_Algorithm(int a, int b, int c)
        {
            
            int survival_rate = c;

            Random rnd = new Random();
            List<Population> generationList = new List<Population>();

            List<List<Population>> parentsList = new List<List<Population>>(5);

            for (int i = 0; i < 5; i++)
            {
                Population subject = new Population(rnd.Next(1, c), survival_rate);
                generationList.Add(subject);
            }

            bool stop = true;
            while (stop)
            {
                float sum_of_reciprocals = 0;

                //рассчитываем коэффициенты выживаемости
                foreach (Population subject in generationList)
                {
                    subject.survival_rate = Math.Abs((a * subject.x + b) - c);
                    if (subject.survival_rate != 0)
                        sum_of_reciprocals = sum_of_reciprocals + (1 / subject.survival_rate);
                    else break;
                }
                foreach (Population subject in generationList)
                {
                    if (subject.survival_rate != 0)
                        subject.survival_percent = 100 * ((1 / subject.survival_rate) / sum_of_reciprocals);
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
                for (int i = 0; i < generationList.Count - 1; i++)
                {
                    if (generationList[i].survival_percent > generationList[i + 1].survival_percent)
                    {
                        number = generationList[i].survival_percent;
                        generationList[i].survival_percent = generationList[i + 1].survival_percent;
                        generationList[i + 1].survival_percent = number;
                        i = -1;
                    }
                }
                //список родителей
                parentsList.Clear();
                for (int i = 0; i < 5; i++)
                {
                    parentsList.Add(new List<Population> { generationList[rnd.Next(0, 2)], generationList[rnd.Next(2, 5)] });
                }

                //новое поколение
                generationList.Clear();
                foreach (List<Population> parents in parentsList)
                {
                    Population subject = new Population(parents[rnd.Next(0, 2)].x, survival_rate);
                    generationList.Add(subject);
                }
                //мутация        
                int mutation_coef = rnd.Next(0, 11);
                if (mutation_coef == 5)
                {
                    generationList[rnd.Next(0, 5)].x = rnd.Next(0, c);
                }
            }
        }
    }
}
