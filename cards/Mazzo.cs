using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
    public class Mazzo
    {
        protected int numero_carte;
        private string[] semi = new string[] { "quadri", "fiori", "cuori", "picche" };
        protected Carte[] carte;

        public Mazzo(int numero_carte)
        {
            //costruturo
            this.numero_carte = numero_carte;
        }

        protected void generatore(Carte[] carte, int numero = 10)
        {
            //genera il mazzo, in numero si passa il numero piu alto delle numero delle carte
            for (int i = 0; i < carte.Length;)
            {
                i = figura_generatore(carte, i, "asso");
                for (int j = 2; j <= numero; j++)
                {
                    i = numero_generatore(carte, i, j);
                }
                i = figura_generatore(carte, i, "dama");
                i = figura_generatore(carte, i, "re");
                i = figura_generatore(carte, i, "fante");
            }
        }

        private int numero_generatore(Carte[] carte, int puntatore, int numero_di_carta)
        {
            //genera le carte numero
            foreach (string seme in semi)
            {
                carte[puntatore] = new Numero(numero_di_carta, seme);
                puntatore++;
            }
            return puntatore;
        }

        private int figura_generatore(Carte[] carte, int puntatore, string typo_figura)
        {
            //genera le carte figura
            foreach (string seme in semi)
            {
                carte[puntatore] = new Figura(typo_figura, seme);
                puntatore++;
            }
            return puntatore;
        }

        public void mischia()
        {
            Random rand = new Random();
            carte = carte.OrderBy(x => rand.Next()).ToArray();
        }

        public Carte[] get_carte()
        {
            return carte;
        }

        public string get_scring_carte()
        {
            string x = "";
            foreach (Carte carta in carte)
            {
                x = x + carta + " - ";
            }
            return x + "\n";
        }

    }
}
