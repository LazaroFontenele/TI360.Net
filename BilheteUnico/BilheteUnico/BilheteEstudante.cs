using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilheteUnico
{
    internal class BilheteEstudante : IBilheteUnico
    {
        public double TicketBalance { get; set; }
        public string Code { get; set; }
        public Usuario User { get; set ; }

        public int CotasEstudante = 48;
        public int ticketStudentValue = 1;

        public void Recharge(double value)
        {
            if (TicketBalance < CotasEstudante)
            {
                double valueRec = value + TicketBalance;
                if (valueRec > CotasEstudante)
                {
                    Console.WriteLine($"O valor de recarga {value} somado ao seu saldo atual ultrapassa o limite de cotas permitida.");
                    double newValue = CotasEstudante - TicketBalance;
                    double valueChanged = Math.Floor(newValue);
                    Console.WriteLine($"O valor de recarga foi corrigido para {valueChanged}.");
                    double refund = value - valueChanged;
                    Console.WriteLine($"Valor a receber de volta nessa operação: {refund}");
                    value = newValue;
                }
                if (value % 1 == 0)
                {
                    TicketBalance += value;
                    Console.WriteLine("Recarga realizada com sucesso!");
                }
                else
                {
                    double valueChanged = Math.Floor(value);
                    TicketBalance += valueChanged;
                    Console.WriteLine("Não é possível recarregar um valor decimal. O valor foi corrigido para " + valueChanged + ".");
                    Console.WriteLine("Recarga realizada com sucesso!");
                }

            }
            else
            {
                Console.WriteLine("Número máximo de cotas atingido");
            }
            Console.WriteLine($"Saldo: {TicketBalance}");
        }
        public void PayPass()
        {
            if (TicketBalance >= 1)
            {
                TicketBalance -= ticketStudentValue;
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
            return $"E{sb.ToString()}";
        }

    }

}
