using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
    internal class Rubamazzetto : Mazzo
    {

        public Rubamazzetto(int numero_carte = 40) : base(numero_carte)
        {
            this.semi = new string[] { "spade", "coppe", "denari", "bastoni" };
            generatore();
        }

        protected override void generatore()
        {
            //genera il mazzo di carte a seconda dei parametri passati
            for (int i = 0; i < carte.Length;)
            {
                i = figura_generatore(carte, i, "asso");
                for (int j = 2; j <= 7; j++)
                {
                    i = numero_generatore(carte, i, j);
                }
                i = figura_generatore(carte, i, "dama");
                i = figura_generatore(carte, i, "re");
                i = figura_generatore(carte, i, "fante");
            }
        }

        public override string ToString()
        {
            return $"mazo per rubamazzetto, contiene {numero_carte} carte";
        }







    }
}
