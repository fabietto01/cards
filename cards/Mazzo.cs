using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
    public class Mazzo
    {
        /*
         * classe patre per creare e gestire un mazzo di carte
         */
        protected int numero_carte;
        protected int carta_numero_magiore;
        private string[] semi = new string[] { "quadri", "fiori", "cuori", "picche" };
        protected Carte[] carte;
        public readonly int carte_coperte;

        public Mazzo(int numero_carte = 52, int numero_jolli = 2, int carta_numero_magiore = 10,int carte_coperte = 0)
        {
            //costruturo
            this.carta_numero_magiore = carta_numero_magiore;
            this.numero_carte = numero_carte + numero_jolli;
            this.carte_coperte = carte_coperte;
            carte = new Carte[this.numero_carte];
        }

        protected void generatore(Carte[] carte, int carta_numero_magiore = 10, int numero_jolly = 0)
        {
            //genera il mazzo, in numero si passa il numero piu alto delle numero delle carte
            for (int i = 0; i < carte.Length;)
            {
                i = figura_generatore(carte, i, "asso");
                for (int j = 2; j <= carta_numero_magiore; j++)
                {
                    i = numero_generatore(carte, i, j);
                }
                i = figura_generatore(carte, i, "dama");
                i = figura_generatore(carte, i, "re");
                i = figura_generatore(carte, i, "fante");
                for (int j = 0; j < (numero_jolly/2); j++)
                {
                    carte[i] = new Figura("jolly", null);
                    i++;
                }
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
            //miscia le carte randomicamente
            Random rand = new Random();
            carte = carte.OrderBy(x => rand.Next()).ToArray();
        }

        public Carte[] mischia(Carte[] carte)
        {
            //miscia le carte randomicamente
            Random rand = new Random();
            return carte.OrderBy(x => rand.Next()).ToArray();
        }

        public List<Carte> get_list_carte()
        {
            return new List<Carte>(carte);
        }


        public Carte[] get_carte()
        {
            //ritorna l'arrey delle carte
            return carte;
        }

        public string get_scring_carte()
        {
            //ritorna una stinga delle carte
            return string.Join(" - ", get_list_carte());
        }

        public override string ToString()
        {
            return $"mazzo di carte generico";
        }

    }
}
