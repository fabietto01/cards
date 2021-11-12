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

        private List<Carte> _carte_coperte = new List<Carte>();
        private List<Carte> _carte_scoperte = new List<Carte>();

        public List<Carte> carte_coperte
        {
            get { return _carte_coperte; }
            private set { _carte_coperte = value;}
        }
        public List<Carte> carte_scoperte
        {
            get { return _carte_scoperte; }
            private set { _carte_scoperte = value; }
        }

        public Giocatore(string nome)
        {
            //costrutore
            name = nome;
        }

        public string get_string_carte()
        {
            //ritorna come stringa le carte in poseso del giocatore
            string x = "carte coperte:\n" + get_string_carte_coperte() + "\n";
            if (carte_scoperte != null)
            {
                x = x + "carte scoperte:\n" + string.Join(" - ", carte_scoperte) + "\n";
            }
            return x;
        }

        public string get_string_carte_coperte()
        {
            return string.Join(" - ", carte_coperte);
        }

        /// <summary>
        /// prende una carta e la inserisce imete nella sua manno, qusto comanda e anche chiamato pesca
        /// </summary>
        /// <param name="carta"></param>
        public void add_carta_coperta(Carte carta)
        {
            carte_coperte.Add(carta);
        }

        public void add_carta_scoperta(Carte carta)
        {
            carte_scoperte.Add(carta);
        }

        public void muve_coperta_to_scopeta(int index)
        {
            add_carta_scoperta(carte_coperte[index]);
            carte_coperte.RemoveAt(index);
        }

        public void remuve_to_coperte(int index)
        {
            carte_coperte.RemoveAt(index);
        }




        public override string ToString()
        {
            return $"{name}";
        }

    }
}
