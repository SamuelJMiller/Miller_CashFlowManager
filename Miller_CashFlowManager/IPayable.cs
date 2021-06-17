using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miller_CashFlowManager
{
    interface IPayable
    {
        decimal get_payable_amount();

        LedgerType led_type { get; }
    }
}
