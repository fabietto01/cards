using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
    public class Giocatore
    {
        private string name;
        private List<Carte> carte_coperte = new List<Carte>();
        private List<Carte> carte_scoperte;

        public Giocatore(string nome, int carte_coperte)
        {
            name = nome;
        }

        public List<Carte> get_list_carte_scoperte()
        {
            return carte_scoperte;
        }

        public List<Carte> get_list_carte_coperte()
        {
            return carte_coperte;
        }

        public string get_string_carte()
        {
            string x = "carte coperte:\n" + string.Join(" - ", carte_coperte) + "\n";
            if (carte_scoperte != null)
            {
                x = x + "carte scoperte:\n" + string.Join(" - ", carte_scoperte) + "\n";
            }
            return x;
        }

        public string get_nome()
        {
            return name;
        }

        public void add_carta_coperta(Carte carta)
        {
            carte_coperte.Add(carta);
        }

    }
}
