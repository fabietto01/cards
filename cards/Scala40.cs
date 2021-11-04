using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
    public class Scala40 : Mazzo
    {
        public Scala40(int numero_carte = 104) : base(numero_carte)
        {
            carte = new Carte[numero_carte];
            generatore(carte);
        }

        public override string ToString()
        {
            return $" mazo per scala 40";
        }



        


    }
}
