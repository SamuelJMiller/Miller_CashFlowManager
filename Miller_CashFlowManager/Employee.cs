using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miller_CashFlowManager
{
    class Employee
    {
        private string first_name;
        private string last_name;
        private string ssn;

        public string FirstName { get { return first_name; } }
        public string LastName { get { return last_name; } }
        public string SSnum { get { return ssn; } }

        public Employee(string first, string last, string ss_param)
        {
            first_name = first;
            last_name = last;
            ssn = ss_param;
        }
    }
}
