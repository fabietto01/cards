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
                Console.WriteLine("digita esci se vui usire, altimeti inviao");
                string input = Console.ReadLine();
                if (input == "esci")
                {
                    partita = false;
                }
            }while (partita);
            





        }

        protected override void giro()
        {
            foreach (Giocatore giocatore in giocatori)
            {
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
                            bool PC = true;
                            bool conferma1 = false;
                            bool conferma2 = false;
                            int int_scelta_pesca = 60;
                            //scelta di qualle carta vuolre rubare
                            do
                            {
                                input = Console.ReadLine();
                                try
                                {
                                    int_scelta_pesca = Int32.Parse(input);
                                    if (0 <= int_scelta_pesca && int_scelta_pesca <= scartate.Count)
                                    {
                                        PC = false;
                                        conferma1 = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("mhhh c'e` qualcosa che non va!\nriprova!!");
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("non hai inserito dei numeri");
                                }
                            } while (PC);
                            Console.WriteLine("con quelle vui prendere?(" + get_cart_itestate(giocatore.carte_coperte) + ")" +
                                "\ninserischi solo una carta");
                            PC = true;
                            int int_scelta_con_pesca = 65;
                            //scelta di che carta usare per rubare
                            do
                            {
                                input = Console.ReadLine();
                                try
                                {
                                    int_scelta_con_pesca = Int32.Parse(input);
                                    if (0 <= int_scelta_con_pesca && int_scelta_con_pesca <= giocatore.carte_coperte.Count)
                                    {
                                        PC = false;
                                        conferma2 = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("mhhh che qualcosa che non va riprova");
                                    }

                                }
                                catch
                                {
                                    Console.WriteLine("non hai inserito dei numeri");
                                }

                            } while (PC);

                            if (scartate[int_scelta_pesca].valore == giocatore.carte_coperte[int_scelta_con_pesca].valore)
                            {
                                if (conferma1 && conferma2)
                                {
                                    giocatore.add_carta_scoperta(scartate[int_scelta_pesca]);
                                    scartate.RemoveAt(int_scelta_pesca);
                                    giocatore.muve_coperta_to_scopeta(int_scelta_con_pesca);
                                    Console.WriteLine("ok!, fatto");
                                    azione = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("hey ma che fai non poi prendre queste carte");
                            }
                        }
                        else
                        {
                            Console.WriteLine("non ci sono carte scoperte nel tavolo, sei obligato a meterne giu tu!");
                        }
                        break;
                    case "ruba":
                        break;
                    case "vedi":
                        string[] str_mazzo_coperto = new string[giocatori.Length];
                        foreach (Giocatore gin in giocatori)
                        {
                            for (int i = 0; i > gin.carte_scoperte.Count; i++)
                            {

                            }


                        }





                        Console.WriteLine("le carte sul tavolo sono:\n\t" + get_string_scartate() +
                            "\nle carte che hai in mano sono:\n\t" + giocatore.get_string_carte_coperte() +
                            "\nqui devo pensare come far vedere gli altri mazzi.....");
                        break;
                    case "meti":

                        Console.WriteLine("quelle carta vui depositare(" + get_cart_itestate(giocatore.carte_coperte) + ")" +
                                "\ninserischi solo una carta");
                        bool MC = true;
                        int int_scelta_della_carata = 65;
                        //scelta di che carta usare per rubare
                        do
                        {
                            input = Console.ReadLine();
                            try
                            {
                                int_scelta_della_carata = Int32.Parse(input);
                                if (0 <= int_scelta_della_carata && int_scelta_della_carata < giocatore.carte_coperte.Count)
                                {
                                    MC = false;
                                    this.scartate.Add(giocatore.carte_coperte[int_scelta_della_carata]);
                                    Console.WriteLine($"ok, hai 'scartato' {giocatore.carte_coperte[int_scelta_della_carata]}");
                                    giocatore.remuve_to_coperte(int_scelta_della_carata);
                                    azione = false;
                                }
                                else
                                {
                                    Console.WriteLine("mhhh che qualcosa che non va riprova");
                                }

                            }
                            catch
                            {
                                Console.WriteLine("non hai inserito dei numeri");
                            }
                        } while (MC);
                        break;
                }
            } while (azione);
        }




    }
}
