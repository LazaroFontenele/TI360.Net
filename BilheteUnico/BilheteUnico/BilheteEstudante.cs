using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilheteUnico
{
    internal class BilheteEstudante : IBilheteUnico
    {
        public double Saldo { get; set; }
        public string Codigo { get; set; }
        public Usuario Usuario { get; set ; }

        public int CotasEstudante = 48;
        public int ValorPassagemEstudante = 1;

        public void RecarregarBilhete(double valor)
        {
            if(CotasEstudante < 48)
            {
                Saldo += CotasEstudante;
            }
            else
            {
                Console.WriteLine("Número máximo de cotas atingido");
            }
        }
        public void PagarPassagem()
        {
            if (CotasEstudante > 1)
            {
                Saldo -= ValorPassagemEstudante;
            }
            else
            {
                Console.WriteLine("Saldo insuficiente para realizar o pagamento!");
            }
            
        }
        public string GenerateTicketCode()
        {
            Random random = new Random();
            int ticketCode = random.Next(0, 5);
            return $"E{ticketCode}";
        }

    }

}
