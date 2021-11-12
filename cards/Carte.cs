using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
    public class Carte
    {
        /*
         * modello patre per le carte mi server solo per una questione pratica
         * di denominazione
         */
        private string _valore;
        private string _seme;
        
        public string valore
        {
            get { return _valore; }
            protected set { _valore = value; }
        }

        public string seme
        {
            get { return _seme; }
            protected set { _valore = value; }
        }

        public Carte(string valore, string seme)
        {
            this._seme = seme;
            this._valore = valore;
        }

        public override string ToString()
        {
            if (seme == null)
            {
                return this.valore;
            }
            return $"{this.valore} di {this.seme}";
        }
    }
}
