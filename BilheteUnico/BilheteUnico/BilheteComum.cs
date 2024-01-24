using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilheteUnico
{
    internal class BilheteComum : IBilheteUnico
    { 
        public double Saldo { get; set; }
        public string Codigo { get ; set ; }
        public Usuario Usuario { get; set;}

        public double ValorPassagem = 5.00;

        public void RecarregarBilhete(double valor)
        {
            Saldo += valor;
        }
        public void PagarPassagem()
        {
            Saldo -= ValorPassagem;
            Console.WriteLine("Passagem paga com sucesso!");

        }
        public List<BilheteUnico> PesquisarBilhetePorCpf(string cpf)
        {
            throw new NotImplementedException();
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
