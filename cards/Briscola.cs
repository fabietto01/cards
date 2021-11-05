using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
    internal class Briscola : Mazzo
    {
        public Briscola(int numero_carte = 40, int numero_jolli = 0, int carta_numero_magiore = 7, int carte_coperte = 3) : base(numero_carte, numero_jolli, carta_numero_magiore, carte_coperte)
        {
            generatore(carte, carta_numero_magiore, numero_jolli);
        }

        public override string ToString()
        {
            return $"mazzo per briscola, contine {numero_carte} carte";
        }
    }
}
