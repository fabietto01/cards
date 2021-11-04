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

            scala40.mischia();

            Console.Write(scala40.get_scring_carte());

            Console.ReadLine();
        }
    }
}
