using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
    internal class GiocoScala40 : Gioco
    {


        public GiocoScala40() : base()
        {
            this.mazzo = new Scala40();
            this.numero_di_giocatori = new int[] { 2, 4 };
            carte_coperte = 13;
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
