using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
    public class Carte
    {
        string seme;

        public Carte(string seme)
        {
            this.seme = seme;
        }


        public string get_seme()
        {
            return seme;
        }


    }
}
