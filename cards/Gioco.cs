using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
    public abstract class Gioco
    {
        /*
         * qui vengono presi i mazzi e i giocatori e vengono unite le cose gestendo il gioco in se dal ditribuire
         */
        private bool _isStart = false;

        protected Mazzo mazzo;
        protected Giocatore[] giocatori;
        protected List<Carte> da_pescare;
        protected List<Carte> scartate;

        private int _numero_carte_coperte;
        private int[] _numero_di_giocatori;
        private int _numero_carte_scoperte = 1;

        public int[] numero_di_giocatori
        {
            get { return _numero_di_giocatori; }
            protected set { _numero_di_giocatori = value; }
        }
        public int numero_carte_coperte
        {
            get { return _numero_carte_coperte; }
            protected set { _numero_carte_coperte = value; }
        }

        public int numero_carte_scoperte
        {
            get { return _numero_carte_scoperte; }
            protected set { _numero_carte_scoperte = value; }
        }

        public bool IsStart
        {
            get { return _isStart; }
            protected set { _isStart = value; }
        }

        public Gioco()
        {
        }

        public void start(string[] giocatori)
        {
            /*
             * prima che il gioco abbia inizio bisoglia startare una volta eseguito il funzione
             * le carte vengono mischiate e distribuite hai fari giocatori
             */
            this.giocatori = new Giocatore[giocatori.Length];
            for(int i = 0; i < this.giocatori.Length; i++)
            {
                this.giocatori[i] = new Giocatore(giocatori[i]);
            }
            Console.WriteLine("preparazione.....");
            mazzo.mischia();
            da_pescare = mazzo.get_list_carte();
            for (int i = 0; i < (giocatori.Length * numero_carte_coperte);)
            {
                foreach (Giocatore giocatore in this.giocatori)
                {
                    giocatore.add_carta_coperta(da_pescare[i]);
                    da_pescare.RemoveAt(i);
                    i++;
                }
            }
            if (numero_carte_scoperte > 0)
            {
                scartate = new List<Carte>();
                for (int i = 0; i < numero_carte_scoperte; i++)
                {
                    scartate.Add(da_pescare[i]);
                    da_pescare.RemoveAt(i);
                }
            }
            IsStart = true;
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
                    x = x + get_string_scartate() + "\n\n\n";
                }
                foreach (Giocatore giocatore in giocatori)
                {
                    x = x + $"\tcarti in mano al giocatore {giocatore.name}\n" + giocatore.get_string_carte() + "\n";
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
                    x = x + "carte scartate:\n" + get_string_scartate() + "\n\n\n";
                }
            }
            catch (NullReferenceException)
            {
                x = "mazzo vergine:\n" +  mazzo.get_scring_carte();
            }
            return x;
        }

        public string get_string_scartate()
        {
            return string.Join(" - ", scartate);
        }

        protected string get_cart_itestate(List<Carte> carte)
        {
            int i = 0;
            string x = "";
            foreach (Carte carta in carte)
            {
                x = x + $"{i} ==> {carta}, ";
                i++;
            }
            return x;
        }

        protected bool verifica_carte_scartate(Giocatore giocatore)
        {
            bool conferma = true;

            foreach (Carte carte_in_mano in giocatore.carte_coperte)
            {
                foreach (Carte carta_in_tavolo in scartate)
                {
                    if (carta_in_tavolo.valore == carte_in_mano.valore)
                    {
                        conferma = false;
                    }
                }
            }
            return conferma;
        }

        public abstract void partita();

        protected abstract void giro();

        protected abstract void turno(Giocatore giocatore);

        public override string ToString()
        {
            return $"stai giocando con!\n{mazzo.ToString()}";
        }
    }
}
