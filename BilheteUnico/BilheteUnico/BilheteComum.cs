using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilheteUnico
{
    internal class BilheteComum : BilheteUnico
    { 
        public double Saldo { get; set; }
        public double ValorPassagem = 5.00;

        public override void recarregarBilhete(double valor)
        {
            Saldo += valor;
        }
        public override void pagarPassagem()
        {
            Saldo -= ValorPassagem;
            Console.WriteLine("Passagem paga com sucesso!");

        }
        public override List<BilheteUnico> PesquisarBilhetePorCpf(string cpf)
        {
            throw new NotImplementedException();
        }



    }
}
