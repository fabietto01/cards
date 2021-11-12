using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
    internal class GiocoBriscola : Gioco
    {


        public GiocoBriscola() : base()
        {
            this.mazzo = new Briscola();
            this.numero_di_giocatori = new int[] { 2 };
            carte_coperte = 3;
        }

        public override void partita()
        {
            throw new NotImplementedException();
        }

        protected override void giro()
        {
            throw new NotImplementedException();
        }

        protected override void turno()
        {
            throw new NotImplementedException();
        }
    }
}
