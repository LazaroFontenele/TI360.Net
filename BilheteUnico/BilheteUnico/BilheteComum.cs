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
        public int Codigo { get ; set ; }
        public Usuario Usuario { get; set;}

        public double ValorPassagem = 5.00;

        public void recarregarBilhete(double valor)
        {
            Saldo += valor;
        }
        public void pagarPassagem()
        {
            Saldo -= ValorPassagem;
            Console.WriteLine("Passagem paga com sucesso!");

        }
        public List<BilheteUnico> PesquisarBilhetePorCpf(string cpf)
        {
            throw new NotImplementedException();
        }



    }
}
