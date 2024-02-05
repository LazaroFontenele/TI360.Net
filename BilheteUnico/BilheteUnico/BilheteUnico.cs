using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilheteUnico
{
    internal interface IBilheteUnico
    {
        string Code { get; set; }
        Usuario User { get; set; }
        double TicketBalance { get; set; } 


        void PayPass();
        void Recharge(double valor);
        string GenerateTicketCode();
    }
}
