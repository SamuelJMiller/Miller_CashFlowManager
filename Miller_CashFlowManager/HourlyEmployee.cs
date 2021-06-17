using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miller_CashFlowManager
{
    class HourlyEmployee : Employee, IPayable
    {
        private decimal hourly_wage;
        private int hours_worked;

        public LedgerType led_type { get; }

        public HourlyEmployee(string first, string last, string ss_param, decimal wage, int hours) : base(first, last, ss_param)
        {
            hourly_wage = wage;
            hours_worked = hours;

            led_type = LedgerType.hourly;
        }

        public decimal get_payable_amount()
        {
            if (hours_worked <= 40)
            {
                return hours_worked * hourly_wage;
            } else
            {
                decimal overtime = hourly_wage * (decimal) 1.5;

                return (40 * hourly_wage) + ((hours_worked - 40) * overtime);
            }
        }

        public override string ToString()
        {
            return "Hourly Employee: " + FirstName + ' ' + LastName + "\n" +
                "SSN: " + SSnum + "\n" +
                "Hourly Wage: " + hourly_wage.ToString("C") + "\n" +
                "Hours Worked: " + hours_worked + "\n" +
                "Earned: " + get_payable_amount().ToString("C");
        }
    }
}
