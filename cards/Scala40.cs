using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
    public class Scala40 : Mazzo
    {
        /*
         * questa classe eredita dal classe mazzo con al interno diversi parametri genera un mazzo per
         * giocare a scala 40 per 2 o 4 giocatori!
         */
       


        public Scala40(int numero_carte = 104, int numero_jolli = 4, int carta_numero_magiore = 10, int carte_coperte = 13) : base(numero_carte, numero_jolli, carta_numero_magiore, carte_coperte)
        {
            generatore(carte, carta_numero_magiore, numero_jolli);
        }

        
        public override string ToString()
        {
            return $"mazo per scala 40, contiene {numero_carte} corte";
        }



    }
}
