using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
    internal class Gioco
    {
        /*
         * qui vengono presi i mazzi e i giocatori e vengono unite le cose gestendo il gioco in se dal ditribuire
         */
        private Mazzo mazzo;
        private Giocatore[] giocatori;
        private List<Carte> da_pescare;
        private List<Carte> scartate;

        public Gioco(Mazzo mazzo, string[] giocatori)
        {
            //metodo costrutore
            this.mazzo = mazzo;
            this.giocatori = new Giocatore[giocatori.Length];
            for (int i = 0; i < this.giocatori.Length; i++)
            {
                this.giocatori[i] = new Giocatore(giocatori[i], mazzo.carte_coperte);
            }
            
        }

        public void start()
        {
            /*
             * prima che il gioco abbia inizio bisoglia startare una volta eseguito il funzione
             * le carte vengono mischiate e distribuite hai fari giocatori
             */
            Console.WriteLine("preparazione.....");
            mazzo.mischia();
            da_pescare = mazzo.get_list_carte();
            for (int i = 0; i < (giocatori.Length * mazzo.carte_coperte);)
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
            // ritorna tutte le carte sia nel mazzo che apartenente hai giocatori
            string x;
            try
            {
                x = $"carte ancora da pescare {da_pescare.Count}:\n" + string.Join(" - ", da_pescare) + "\n";
                if (scartate != null)
                {
                    x = x + "carte scartate:\n" + string.Join(" - ", scartate) + "\n\n\n";
                }
                foreach (Giocatore giocatore in giocatori)
                {
                    x = x + $"\tcarti in mano al giocatore {giocatore.get_nome()}\n" + giocatore.get_string_carte() + "\n";
                }
            }
             catch (NullReferenceException)
            {
               x = "non sono statte ancora disribuite le carte";
            }
            return x;
        }

        public string get_mazzo()
        {
            //ritorna solo il mazzo 
            string x;
            try
            {
                x = $"carte ancora da pescare {da_pescare.Count}:\n" + string.Join(" - ", da_pescare) + "\n";
                if (scartate != null)
                {
                    x = x + "carte scartate:\n" + string.Join(" - ", scartate) + "\n\n\n";
                }
            }
            catch (NullReferenceException)
            {
                x = "mazzo vergine:\n" +  mazzo.get_scring_carte();
            }
            return x;
        }

        public override string ToString()
        {
            return $"stai giocando con!\n{mazzo.ToString()}";
        }
    }
}
