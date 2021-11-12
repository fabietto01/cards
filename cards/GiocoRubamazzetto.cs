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
            this.mazzo = new Scala40();
            this.numero_carte_scoperte = 3;
            this.numero_di_giocatori = new int[] { 2, 3, 4 };
            this.carte_coperte = 3;
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
