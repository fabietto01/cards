using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
    public class Giocatore
    {
        /*
         * gestisce i giocatroi salvano nome, il mazzo di carte coperto e quello scopertto
         */
        public string name
        {
            get; 
        }

        private List<Carte> carte_coperte = new List<Carte>();
        private List<Carte> carte_scoperte = null;

        public List<Carte> _carte_coperte
        {
            get { return carte_coperte;}
        }
        public List<Carte> _carte_scoperte
        {
            get { return carte_scoperte;}
        }

        public Giocatore(string nome)
        {
            //costrutore
            name = nome;
        }

        public string get_string_carte()
        {
            //ritorna come stringa le carte in poseso del giocatore
            string x = "carte coperte:\n" + string.Join(" - ", carte_coperte) + "\n";
            if (carte_scoperte != null)
            {
                x = x + "carte scoperte:\n" + string.Join(" - ", carte_scoperte) + "\n";
            }
            return x;
        }

        /// <summary>
        /// prende una carta e la inserisce imete nella sua manno, qusto comanda e anche chiamato pesca
        /// </summary>
        /// <param name="carta"></param>
        public void add_carta_coperta(Carte carta)
        {
            carte_coperte.Add(carta);
        }

    }
}
