﻿using System;
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
        int numero_jolli;

        public Scala40(int numero_carte = 108, int numero_jolli = 4) : base(numero_carte)
        {
            this.numero_jolli = numero_jolli;
            this.semi = new string[] { "quadri", "fiori", "cuori", "picche" };
            generatore();
        }

        protected override void generatore()
        {
            //genera il mazzo di carte a seconda dei parametri passati
            for (int i = 0; i < carte.Length;)
            {
                i = figura_generatore(carte, i, "asso");
                for (int j = 2; j <= 10; j++)
                {
                    i = numero_generatore(carte, i, j);
                }
                i = figura_generatore(carte, i, "dama");
                i = figura_generatore(carte, i, "re");
                i = figura_generatore(carte, i, "fante");
                for (int j = 0; j < (numero_jolli / 2); j++)
                {
                    carte[i] = new Figura("jolly", null);
                    i++;
                }
            }
        }

        public override string ToString()
        {
            return $"mazo per scala 40, contiene {numero_carte} carte";
        }



    }
}
