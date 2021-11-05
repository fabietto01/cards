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

            Scala40 scala40 = new Scala40();






            


            Console.WriteLine("inserisli il nome dei giocatori divisi da una virgola (nome,nome)");
            string strgin_giocatori = Console.ReadLine();
            string[] giocatori = strgin_giocatori.Split(',');

            Gioco gioco = new Gioco(scala40, giocatori);
            Console.WriteLine(gioco);


            gioco.start();

            Console.WriteLine("se vui conoscere tutte le carte che sono presenti per oggi mano e mazzo digiva visualiza");

            Console.WriteLine(gioco.get_all_carte());



            //Console.WriteLine(scala40.get_scring_carte());

            //scala40.mischia();

            //Console.WriteLine(scala40.get_scring_carte());


            Console.ReadLine();
        }
    }
}
