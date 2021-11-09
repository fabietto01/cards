using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
    public class Figura : Carte
    {
        /*
         * classe che contine le carte di tipo figura quindi l'asso,
         * il re, la dona e il fante nel casso esista al il jolly
         */
        string figura;
        string seme;

        public Figura(string figura, string seme) : base(seme)
        {
            this.figura = figura;
            this.seme = seme;
        }

        public override string ToString()
        {
            if (seme == null)
            {
                return this.figura;
            }
            return $"{this.figura} di {this.seme}";
        }

    }
}
