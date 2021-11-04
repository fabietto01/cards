using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
    public class Scala40 : Mazzo
    {
        int numero_carte;
        Carte[] carte;

        public Scala40(int numero_carte = 104) : base(numero_carte)
        {
            this.numero_carte = numero_carte;
            this.carte = new Carte[numero_carte];
            generatore(this.carte);
        }


        public override string ToString()
        {
            return $" mazo per scala 40";
        }


        


    }
}
