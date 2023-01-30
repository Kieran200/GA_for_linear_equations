using System;
using System.Collections.Generic;
using System.Text;

namespace GA_for_lineare_quations
{
    class Individual
    {
        public List<double> chromosomes;
        public double survival_rate;
        public double survival_percent;
        public Individual(List<double> chrom, double rate)
        {
            chromosomes = chrom;
            survival_rate = rate;
        }
    }
}
