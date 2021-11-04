using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
    public class Numero : Carte
    {
        int numero;
        string seme;

        public Numero(int numero, string seme) : base(seme)
        {
            this.numero = numero;
            this.seme = seme;
        }

        public override string ToString()
        {
            return $"{this.numero} di {this.seme}";
        }
    }
}
