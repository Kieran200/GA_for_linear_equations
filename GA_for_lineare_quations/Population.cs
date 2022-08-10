using System;
using System.Collections.Generic;
using System.Text;

namespace GA_for_lineare_quations
{
    class Population
    {
        public int x;
        public int survival_rate;
        public double survival_percent;
        public Population(int number, int rate)
        {
            x = number;
            survival_rate = rate;
        }
    }
}
