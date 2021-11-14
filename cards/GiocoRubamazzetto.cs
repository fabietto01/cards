using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
    public class GiocoRubamazzetto : Gioco
    {
        
        public GiocoRubamazzetto() : base()
        {
            this.mazzo = new Rubamazzetto();
            this.numero_carte_scoperte = 3;
            this.numero_di_giocatori = new int[] { 2, 3, 4 };
            this.numero_carte_coperte = 3;
        }

        public override void partita()
        {
            bool partita = true;
            do
            {
                giro();
                partita = condizioni_fine_partita();
                Console.WriteLine("digita esci se vui usire, altimeti inviao");
                string input = Console.ReadLine();
                if (input == "esci")
                {
                    partita = false;
                }
            }while (partita);
            fine_partita();
        }

        protected override void giro()
        {
            foreach (Giocatore giocatore in giocatori)
            {
                Console.WriteLine("-------------------------------------------------------------" +
                    "\n\t PROSIMO TURNO");
                turno(giocatore);
                if (giocatore.carte_coperte.Count == 0)
                {
                    for (int i = 0; i < numero_carte_coperte; i++)
                    {
                        giocatore.add_carta_coperta(da_pescare[i]);
                        da_pescare.RemoveAt(i);
                    }
                }
            }
        }

        protected override void turno(Giocatore giocatore)
        {
            bool azione = true;
            do
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine($"tocha a {giocatore}\ncosa vui fare?" +
                    $"\nprendi = prendere una carta\nruba = rubare il mazzo\nmeti = metere carta" +
                    $"\nvedi = per vedere le carte in campo");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "prendi":
                        if (scartate.Count > 0)
                        {
                            Console.WriteLine($"le carte che puoi prendere sono:\n\t{get_string_scartate()}\n" +
                                $"le carte che hai imano sono\n\t{giocatore.get_string_carte_coperte()}");
                            Console.WriteLine("qulle carta vuoi prendere?( " + get_cart_itestate(scartate) + ")");
                            bool prendi_conferma1 = false;
                            bool prendi_conferma2 = false;
                            int int_scelta_pesca;
                            int_scelta_pesca = get_scelta(scartate.Count, ref prendi_conferma1);
                            Console.WriteLine("con quelle vui prendere?(" + get_cart_itestate(giocatore.carte_coperte) + ")" +
                                "\ninserischi solo una carta");
                            int int_scelta_con_pesca;
                            int_scelta_con_pesca = get_scelta(giocatore.carte_coperte.Count, ref prendi_conferma2);
                            if (prendi_conferma1 && prendi_conferma2)
                            {
                                
                                if (scartate[int_scelta_pesca].valore == giocatore.carte_coperte[int_scelta_con_pesca].valore)
                                {
                                    giocatore.add_carta_scoperta(scartate[int_scelta_pesca]);
                                    scartate.RemoveAt(int_scelta_pesca);
                                    giocatore.muve_coperta_to_scopeta(int_scelta_con_pesca);
                                    Console.WriteLine("ok!, fatto");
                                    azione = false;
                                }
                                else
                                {
                                    Console.WriteLine("hey ma che fai non poi prendre queste carte");
                                }
                            }
                            else
                            {
                                Console.WriteLine("mhhh qualcosa non e andato bene riprova!");
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("non ci sono carte scoperte nel tavolo, sei obligato a meterne giu tu!");
                        }
                        break;
                    case "ruba":
                        bool ruba_condizione1 = false;
                        bool ruba_condizione2 = false;
                        int ruba_int_scelta_mazzo;
                        Console.WriteLine("qualle mazzo vuoi rubare?");
                        Giocatore[] ruba_giocatori = new Giocatore[giocatori.Length - 1];
                        //esperimento
                        for (int[] i = {0, 0}; i[0] < giocatori.Length; i[0]++)
                        {
                            if (giocatore != giocatori[i[0]])
                            {
                                ruba_giocatori[i[1]] = giocatori[i[0]];
                                i[1]++;
                            }
                        }
                        for (int i = 0; i < ruba_giocatori.Length; i++)
                        {
                            Console.WriteLine("\t" + i.ToString() + " ===> " +  get_ultima_carta_scoperta(ruba_giocatori[i]));
                        }
                        ruba_int_scelta_mazzo = get_scelta(ruba_giocatori.Length, ref ruba_condizione1);
                        Console.WriteLine("con quelle vui prendere?(" + get_cart_itestate(giocatore.carte_coperte) + ")" +
                                "\ninserischi solo una carta");
                        int ruba_int_scelata_carta;
                        ruba_int_scelata_carta = get_scelta(giocatore.carte_coperte.Count, ref ruba_condizione2);
                        if (ruba_condizione1 && ruba_condizione2)
                        {
                            List<Carte> ruba_carte_scoperte_momentania = ruba_giocatori[ruba_int_scelta_mazzo].carte_scoperte;
                            if (giocatore.carte_coperte[ruba_int_scelata_carta].valore ==
                               ruba_carte_scoperte_momentania[ruba_carte_scoperte_momentania.Count-1].valore)
                            {
                                for (int i = 0; i < ruba_carte_scoperte_momentania.Count; i++)
                                {
                                    giocatore.add_carta_scoperta(ruba_carte_scoperte_momentania[i]);
                                    ruba_giocatori[ruba_int_scelta_mazzo].remuve_to_scoperte(i);
                                }
                                giocatore.muve_coperta_to_scopeta(ruba_int_scelata_carta);
                                Console.WriteLine($"ok!, fatto\nhai rubato il mazzo di {ruba_giocatori[ruba_int_scelta_mazzo]}" +
                                    $" con la carta {giocatore.carte_coperte[ruba_int_scelata_carta]}");
                                azione = false;
                            }
                            else
                            {
                                Console.WriteLine("ma che fai non puoi rubare qual mazzo con questa carta");
                            }
                        }
                        else
                        {
                            Console.WriteLine("mhhh qualcosa e andato storto riprova");
                        }
                        break;
                    case "vedi":
                        string[] str_a_mazzo_coperto = get_ultima_carta_scoperta();
                        string str_mazzo_coperto = "";
                        foreach(string str in str_a_mazzo_coperto)
                        {
                            str_mazzo_coperto =  str_mazzo_coperto + "\n\t" + str;
                        }
                        Console.WriteLine("\nl' ultima carta del mazzo che pui rubare" + str_mazzo_coperto +
                            "\nle carte sul tavolo sono:\n\t" + get_string_scartate() +
                            "\nle carte che hai in mano sono:\n\t" + giocatore.get_string_carte_coperte());
                        break;
                    case "meti":
                        if (verifica_carte_scartate(giocatore))
                        {
                            Console.WriteLine("quelle carta vui depositare(" + get_cart_itestate(giocatore.carte_coperte) + ")" +
                                "\ninserischi solo una carta");
                            bool meti_conferma1 = false;
                            int int_scelta_carata = 65;
                            //scelta di che carta usare per rubare
                            int_scelta_carata = get_scelta(giocatore.carte_coperte.Count, ref meti_conferma1);
                            if (meti_conferma1)
                            {
                                this.scartate.Add(giocatore.carte_coperte[int_scelta_carata]);
                                Console.WriteLine($"ok, hai 'scartato' {giocatore.carte_coperte[int_scelta_carata]}");
                                giocatore.remuve_to_coperte(int_scelta_carata);
                                azione = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("controla meglio, ci risulta che puoi prendere una carta!");
                        }
                        break;
                    default:
                        Console.WriteLine("non ho capito riprova!");
                        break;
                }
            } while (azione);
        }

        private void fine_partita()
        {
            Console.WriteLine("la partita e terminata!\ncon:");
            int[] numero_di_carte = new int[giocatori.Length];
            for (int i = 0; i < numero_di_carte.Length; i++)
            {
                numero_di_carte[i] = giocatori[i].carte_scoperte.Count;
                Console.WriteLine($"\t{numero_di_carte[i]} carte per {giocatori[i]} ");
            }
            int Indice_magiroe = numero_di_carte.Max();
            Console.WriteLine($"il giocatore {giocatori[Indice_magiroe]} ha vinto con {numero_di_carte[Indice_magiroe]} punti!");
        }

        protected bool condizioni_fine_partita()
        {
            bool condizioni = true;
            foreach (Giocatore giocatore in giocatori)
            {
                condizioni = condizioni && (giocatore.carte_coperte.Count == 0);
            }
            condizioni = condizioni && (scartate.Count == 0);
            return !condizioni;
        }

        /// <summary>
        /// ritorno un array di stinge contenente tutte la prima carta! di tutti i giocatori
        /// </summary>
        /// <returns></returns>
        private string[] get_ultima_carta_scoperta()
        {
            string[] str_a_mazzo_coperto = new string[giocatori.Length];
            for (int i = 0; i < giocatori.Length; i++)
            {
                str_a_mazzo_coperto[i] = get_ultima_carta_scoperta(giocatori[i]);
            }
            return str_a_mazzo_coperto;
        }

        /// <summary>
        /// sirona una stinga contenete il nome del giocatore e la ultima carta che a nel mazzo
        /// </summary>
        /// <returns name="giocatore"></returns>
        private string get_ultima_carta_scoperta(Giocatore giocatore)
        {
            string str_a_mazzo_coperto = "";
            for (int j = 0; j < giocatore.carte_scoperte.Count; j++)
            {
                str_a_mazzo_coperto = giocatore + " ==> " + giocatore.carte_scoperte[j].ToString();
            }
            return str_a_mazzo_coperto;
        }

        /// <summary>
        /// chiede e ritorna il numero che server per schegliere la carta
        /// effetuando anche delle controli
        /// </summary>
        /// <param name="max_int_scelata"></param>
        /// <param name="conferma1"></param>
        /// <returns></returns>
        private int get_scelta(int max_int_scelata, ref bool conferma1)
        {
            string input;
            bool condizione1 = true;
            int scleta = 50;
            do
            {
                input = Console.ReadLine();
                try
                {
                    scleta = Int32.Parse(input);
                    if (0 <= scleta && scleta <= max_int_scelata)
                    {
                        condizione1 = false;
                        conferma1 = true;
                    }
                    else
                    {
                        Console.WriteLine("mhhh c'e` qualcosa che non va!\n hai scelto un numero staro riprova!!");
                    }
                }
                catch
                {
                    Console.WriteLine("non hai inserito dei numeri, o il numero non era interno");
                }
            } while (condizione1);
            return scleta;
        }
    }
}
