using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
    internal class Figura : Carte
    {
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
