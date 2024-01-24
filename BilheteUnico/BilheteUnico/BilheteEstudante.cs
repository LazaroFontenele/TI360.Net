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
        public string Codigo { get; set; }
        public Usuario Usuario { get; set ; }

        public int CotasEstudante = 48;
        public int ValorPassagemEstudante = 1;

        public void RecarregarBilhete(double valor)
        {
            Cotas += CotasEstudante;
        }
        public void PagarPassagem()
        {
            Cotas -= ValorPassagemEstudante;
        }
        public string GenerateTicketCode()
        {
            Random random = new Random();
            int ticketCode = random.Next(0, 5);
            return $"E{ticketCode}";
        }

    }

}
