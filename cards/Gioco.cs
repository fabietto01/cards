using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
    internal class Gioco
    {
        //
        private Mazzo mazzo;
        private Giocatore[] giocatori;
        private List<Carte> da_pescare;
        private List<Carte> scartate;




        public Gioco(Mazzo mazzo, string[] giocatori)
        {
            if (giocatori.Length >= 2)
            {
                var ex = new Exception("il numero di gocatori deve essere >= 2");
            }
            this.mazzo = mazzo;
            this.giocatori = new Giocatore[giocatori.Length];
            for (int i = 0; i < this.giocatori.Length; i++)
            {
                this.giocatori[i] = new Giocatore(giocatori[i], mazzo.carte_coperte);
            }
            
        }



        public void start()
        {
            Console.WriteLine("preparazione.....");
            mazzo.mischia();
            da_pescare = mazzo.get_list_carte();
            for (int i = 0; i < (giocatori.Length * mazzo.carte_coperte); i++)
            {
                foreach(Giocatore giocatore in giocatori)
                {
                    giocatore.add_carta_coperta(da_pescare[i]);
                    da_pescare.RemoveAt(i);
                    i++;
                }
            }
            Console.WriteLine("grazie per l'attesta le carte sono state distribuite....");
        }


        public string get_all_carte()
        {
            string x;
            x = $"\tcarte ancora da pescare {da_pescare.Count}:\n" + string.Join(" - ", da_pescare) + "\n";
            if (scartate != null)
            {
                x = x + "\tcarte scartate:\n" + string.Join("-", scartate) + "\n" ;
            }
            foreach (Giocatore giocatore in giocatori) 
            {
                x = x + $"\tcarti in mano al giocatore {giocatore.get_nome()}\n" + giocatore.get_string_carte() + "\n" ;
            }
            return x;
        }

        public override string ToString()
        {
            return $"stai giocando con!\n{mazzo.ToString()}";
        }
    }
}
