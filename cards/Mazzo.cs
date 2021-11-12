using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
    public abstract class Mazzo
    {
        /*
         * classe padre per i mazzi contiene il generatore di carte e tutto cio che e in comune hai mazzi
         */
        protected int numero_carte;
        protected string[] semi;
        protected Carte[] carte;

        public Mazzo(int numero_carte)
        {
            //costruturo
            this.numero_carte = numero_carte;
            carte = new Carte[this.numero_carte];
        }

        protected abstract void generatore();

        protected int genera_carta(Carte[] carte, int puntatore, string valore_carta)
        {
            //genera le carte numero
            foreach (string seme in semi)
            {
                carte[puntatore] = new Carte(valore_carta, seme);
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
