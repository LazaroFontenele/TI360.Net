using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilheteUnico
{
    internal class BilheteEstudante : IBilheteUnico
    {
        public int Cotas { get; set; }
        public int Codigo { get; set; }
        public Usuario Usuario { get; set ; }

        public int CotasEstudante = 48;
        public int ValorPassagemEstudante = 1;

        public void recarregarBilhete(double valor)
        {
            Cotas += CotasEstudante;
        }
        public void pagarPassagem()
        {
            Cotas -= ValorPassagemEstudante;
        }
    }

}
