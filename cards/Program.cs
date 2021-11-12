using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
    public class Program
    {
        static void Main(string[] args)
        {
            Gioco game;
            bool x = true;

            //chiede e istazione qualle il giusto mazzo che ti interesa
            Console.WriteLine("a cosa vui giocare oggi? scala40,briscola,rubamazzetto");
            do
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "scala40":
                        game = new GiocoScala40();
                        //x = false;
                        break;
                    case "briscola":
                        game = new GiocoBriscola();
                        //x = false;
                        break;
                    case "rubamazzetto":
                        game = new GiocoRubamazzetto();
                        x = false;
                        break;
                    default:
                        game = new GiocoRubamazzetto();
                        Console.WriteLine($"mi spiace non conosco qeuseto gioco {input}");
                        break;
                }
            }while (x);

            x = true;
            string[] giocatori;

            do
            {
                //istazia la classe gioco passado il nome dei giocatori, divisi da una virgola, e il mazzo scelto qui sopra
                Console.WriteLine("inserisli il nome dei giocatori divisi da una virgola (nome,nome)");
                string strgin_giocatori = Console.ReadLine();
                giocatori = strgin_giocatori.Split(',');
                if (Array.Exists(game.numero_di_giocatori, element => element == giocatori.Length))
                {
                    x = false;
                    Console.WriteLine("perfetto!");
                }
                else
                {

                    string str = $"tu hai inserito {giocatori.Length} giocatori, piu inserire solo i seguenti numero di gocatori: ";
                    foreach (int i in game.numero_di_giocatori)
                    {
                        str = str + i + " ";
                    }
                    str = str + "\n\triprovaci";
                    Console.WriteLine(str);
                }
            } while (x);
            Console.WriteLine(game);
            x = true;
            string comand = "\n\tmazzo = per stamapre a scarmo il contenuto del mazzo" +
                "\n\tstart = startare il gioco cosi che le carte vengono misciate e distribuite hai giocatori" +
                "\n\tvisualiza = per vedere le carte in mano hai giocatori e nel mazzo\n\tesci = per uscire dal programma" +
                "\nnon tutto le funzioni sono implementate completamente il servizio e ancora in alfa";
            //e ora di vedere cosa abbiamo combinato
            Console.WriteLine("cosa vui fare ora?" + comand);
            do
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "mazzo":
                        Console.WriteLine(game.get_mazzo());
                        break;
                    case "start":
                        game.start(giocatori);
                        Console.WriteLine("se vui conoscere tutte le carte che sono presenti per oggi mano e mazzo digita visualiza" +
                            "\naltrimenti digita inizia per comincare a giocare");
                        break;
                    case "visualiza":
                        Console.WriteLine(game.get_all_carte());
                        break;
                    case "inizia":
                        if (game.IsStart)
                        {
                            try
                            {
                                game.partita();
                            }
                            catch (NotImplementedException)
                            {
                                Console.WriteLine("hey mi spiace come detto prima non tutti i giochi sono implementati questo e uno di quelli" +
                                    " prova con un altro...");
                            }
                           
                        }
                        else
                        {
                            Console.WriteLine("il gioco non e ancora stato startato prego digita start");
                        }
                        Console.WriteLine(game.get_all_carte());
                        break;
                    case "esci":
                        x = false;
                        break;
                    default:
                        Console.WriteLine($"mi spiace non conosco qeuseto comando {input}");
                        Console.WriteLine("prova con uno di questio comandi:" + comand);
                        break;
                }
            } while (x);

            Console.Write("premi invio per terminare.......");
            Console.ReadLine();
        }
    }
}
