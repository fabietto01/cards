using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
    internal class Briscola : Mazzo
    {
        /*
         * classe figlia di mazzo e serve per gestire il mazzo di briscola
         * le eventuale regole
         */

        public Briscola(int numero_carte = 40) : base(numero_carte)
        {
            this.semi = new string[] { "spade", "coppe", "denari", "bastoni" };
            generatore();
        }

        protected override void generatore()
        {
            //genera il mazzo di carte a seconda dei parametri passati
            for (int i = 0; i < carte.Length;)
            {
                i = genera_carta(carte, i, "asso");
                for (int j = 2; j <= 7; j++)
                {
                    i = genera_carta(carte, i, j.ToString());
                }
                i = genera_carta(carte, i, "dama");
                i = genera_carta(carte, i, "re");
                i = genera_carta(carte, i, "fante");
            }
        }

        public override string ToString()
        {
            return $"mazzo per briscola, contine {numero_carte} carte";
        }
    }
}
