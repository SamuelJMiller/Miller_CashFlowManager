using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Miller_CashFlowManager
{
    class Invoice : IPayable
    {
        private string part_number;
        private string invoice_number;
        private int quantity;
        private string part_desc;
        private decimal price;

        public LedgerType led_type { get; }

        private Random r = new Random(DateTime.Now.Millisecond);

        public Invoice(string part_num, int qty, string desc, decimal itemprice)
        {
            part_number = part_num;
            quantity = qty;
            part_desc = desc;
            price = itemprice;
            invoice_number = gen_invoice_num();

            led_type = LedgerType.invoice;
        }

        private string gen_invoice_num()
        {
            string big_rand = r.Next(100000, 999999).ToString();

            return big_rand + '_' + part_number;
        }

        public decimal get_payable_amount()
        {
            return quantity * price;
        }

        public override string ToString()
        {
            return "Invoice: " + invoice_number + "\n" +
                "Quantity: " + quantity + "\n" +
                "Part Description: " + part_desc + "\n" +
                "Unit Price: " + price.ToString("C") + "\n" +
                "Extended Price: " + get_payable_amount().ToString("C");
        }
    }
}
