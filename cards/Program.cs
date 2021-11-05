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
            Mazzo mazzo;
            bool x = true;

            Console.WriteLine("a cosa vui giocare oggi? scala40,briscola");
            do
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "scala40":
                        mazzo = new Scala40();
                        x = false;
                        break;
                    case "briscola":
                        mazzo = new Briscola();
                        x = false;
                        break;
                    default:
                        mazzo = new Mazzo();
                        Console.WriteLine($"mi spiace non conosco qeuseto gioco {input}");
                        break;
                }
            }while (x);

            //generazione del gioco
            Console.WriteLine("inserisli il nome dei giocatori divisi da una virgola (nome,nome)");
            string strgin_giocatori = Console.ReadLine();
            string[] giocatori = strgin_giocatori.Split(',');
            Gioco gioco = new Gioco(mazzo, giocatori);
            Console.WriteLine(gioco);

            
            x = true;
            string comand = "\n\tmazzo = per stamapre a scarmo il contenuto del mazzo" +
                "\n\tstart = startare il gioco cosi che le carte vengono misciate e distribuite hai giocatori" +
                "\n\tvisualiza = per vedere le carte in mano hai giocatori e nel mazzo\n\tesci = per uscire dal programma";
            Console.WriteLine("cosa vui fare ora?" + comand);
            do
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "mazzo":
                        Console.WriteLine(gioco.get_mazzo());
                        break;
                    case "start":
                        gioco.start();
                        Console.WriteLine("se vui conoscere tutte le carte che sono presenti per oggi mano e mazzo digita visualiza");
                        break;
                    case "visualiza":
                        Console.WriteLine(gioco.get_all_carte());
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
