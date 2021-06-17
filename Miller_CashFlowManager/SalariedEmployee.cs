using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miller_CashFlowManager
{
    class SalariedEmployee : Employee, IPayable
    {
        private decimal weekly_salary;

        public LedgerType led_type { get; }

        public SalariedEmployee(string first, string last, string ss_param, decimal salary) : base(first, last, ss_param)
        {
            weekly_salary = salary;

            led_type = LedgerType.salaried;
        }

        public decimal get_payable_amount()
        {
            return weekly_salary;
        }

        public override string ToString()
        {
            return "Salaried Employee: " + FirstName + ' ' + LastName + "\n" +
                "SSN: " + SSnum + "\n" +
                "Weekly Salary: " + weekly_salary.ToString("C") + "\n" +
                "Earned: " + get_payable_amount().ToString("C");
        }
    }
}
