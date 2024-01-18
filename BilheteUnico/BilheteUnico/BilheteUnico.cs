using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilheteUnico
{
    internal abstract class BilheteUnico
    {
        public int Codigo { get; set; }
        public Usuario Usuario { get; set; }


        public abstract void pagarPassagem();
        public abstract void recarregarBilhete(double valor);
        public abstract List<BilheteUnico> PesquisarBilhetePorCpf(string cpf);
    }
}
