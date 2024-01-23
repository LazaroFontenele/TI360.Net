using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilheteUnico
{
    internal interface IBilheteUnico
    {
        int Codigo { get; set; }
        Usuario Usuario { get; set; }


        void pagarPassagem();
        void recarregarBilhete(double valor);
    }
}
