using System;
using System.Collections.Generic;
using System.Text;

namespace GA_for_lineare_quations
{
    class Distance_Calc
    {
        public double Distance(List<double> variablesList, List<double> chromosomes, double c)
        {
            double value = 0;
            for (int i = 0; i < variablesList.Count; i++)
            {
                 value += variablesList[i] * chromosomes[i];
            }
            value = Math.Abs(value - c);
            return value; 
        }
    }
}
