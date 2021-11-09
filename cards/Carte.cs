using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
    public abstract class Carte
    {
        /*
         * modello patre per le carte mi server solo per una questione pratica
         * di denominazione
         */

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
