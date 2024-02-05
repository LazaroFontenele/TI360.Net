using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilheteUnico
{
    internal class BilheteComum : IBilheteUnico
    { 
        public double TicketBalance { get; set; }
        public string Code { get ; set ; }
        public Usuario User { get; set;}

        public double TravelFare = 5.00;

        public void Recharge(double valor)
        {
            TicketBalance += valor;
        }
        public void PayPass()
        {
            if (TicketBalance > 5)
            {
                TicketBalance -= TravelFare;
                Console.WriteLine("Passagem paga com sucesso!");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente para realizar o pagamento!");
            }

        }
        public string GenerateTicketCode()
        {
            Random random = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                sb.Append(random.Next(10));
            }        
            return $"C{sb.ToString()}";
        }

    }
}
