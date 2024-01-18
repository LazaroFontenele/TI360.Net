using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilheteUnico
{
    internal class BilheteEstudante : BilheteUnico
    {
        public int Cotas { get; set; }
        public int CotasEstudante = 48;
        public int ValorPassagemEstudante = 1;

        public override void recarregarBilhete(double valor)
        {
            Cotas += CotasEstudante;
        }
        public override void pagarPassagem()
        {
            Cotas -= ValorPassagemEstudante;
        }
    }

}
