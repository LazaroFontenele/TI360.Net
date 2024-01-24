using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilheteUnico
{
    internal interface IBilheteUnico
    {
        string Codigo { get; set; }
        Usuario Usuario { get; set; }


        void PagarPassagem();
        void RecarregarBilhete(double valor);
        string GenerateTicketCode();
    }
}
