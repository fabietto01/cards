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
         * classe figlia di mazzo e serve per gestire il mazzo di scala40 e
         * le eventuale regole
         */


        public Scala40(int numero_carte = 104, int numero_jolli = 4, int carta_numero_magiore = 10, int carte_coperte = 13) : base(numero_carte, numero_jolli, carta_numero_magiore, carte_coperte)
        {
            numero_carte = 104;
            generatore(carte, carta_numero_magiore, numero_jolli);
        }

        
        public override string ToString()
        {
            return $"mazo per scala 40, contiene {numero_carte} carte";
        }



    }
}
