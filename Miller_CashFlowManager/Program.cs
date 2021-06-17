using System;
using System.Collections.Generic;
using System.Threading;

// Samuel Miller
// IT112  

namespace Miller_CashFlowManager
{
    class Program
    {
        // Helper methods:
        static void write()
        {
            Console.WriteLine();
        }

        static void write(string s)
        {
            Console.WriteLine(s); // make it easy on myself :)
        }

        static string read()
        {
            return Console.ReadLine();
        }
        
        static void show_menu()
        {
            write("Welcome to CashFlowManager by Sam Miller. Please select what you would like to do" +
                "\n(enter the number of the option to select):" +
                "\n1. Add an entry for a salaried employee payroll" +
                "\n2. Add an entry for an hourly employee payroll" +
                "\n3. Add an entry for an invoice" +
                "\n4. Create and display a report showing all expenses" +
                "\n5. Quit the program");
        }

        static SalariedEmployee user_create_salaried()
        {
            write("Enter employee's first name:");
            string first_name = Console.ReadLine();

            write("Enter employee's last name:");
            string last_name = Console.ReadLine();

            write("Enter employee's SSN:");
            string ssn = Console.ReadLine();

            write("Enter employee's weekly salary:");
            decimal salary = Decimal.Parse(Console.ReadLine());

            return new SalariedEmployee(first_name, last_name, ssn, salary);
        }

        static HourlyEmployee user_create_hourly()
        {
            write("Enter employee's first name:");
            string first_name = Console.ReadLine();

            write("Enter employee's last name:");
            string last_name = Console.ReadLine();

            write("Enter employee's SSN:");
            string ssn = Console.ReadLine();

            write("Enter employee's hourly wage:");
            decimal wage = Decimal.Parse(Console.ReadLine());

            write("Enter employee's hours worked:");
            int hours_worked = Int32.Parse(Console.ReadLine());

            return new HourlyEmployee(first_name, last_name, ssn, wage, hours_worked);
        }

        static Invoice user_create_invoice()
        {
            write("Enter invoice part number:");
            string num = read();

            write("Enter number of items included:");
            int count = Int32.Parse(read());

            write("Enter invoice part description:");
            string desc = read();

            write("Enter the price per one item in the invoice:");
            decimal price = Decimal.Parse(read());

            return new Invoice(num, count, desc, price);
        }

        static void Main(string[] args)
        {
            List<IPayable> payments = new List<IPayable>();
            int user_choice;

            payments.Add(new SalariedEmployee("Robert", "Zimmerman", "453-667-5372", 1199.50M));
            payments.Add(new SalariedEmployee("Lionel", "Messi", "879-627-8851", 1450.32M));
            payments.Add(new SalariedEmployee("Elon", "Musk", "665-013-5537", 150.66M));

            payments.Add(new HourlyEmployee("Freddie", "Mercury", "312-778-9902", 22.50M, 50));
            payments.Add(new HourlyEmployee("Frank", "Sinatra", "748-993-2267", 22.50M, 40));
            payments.Add(new HourlyEmployee("Tom", "Brady", "920-482-5723", 14.50M, 60));

            payments.Add(new Invoice("3896", 283748, "Footballs", 12.25M));
            Thread.Sleep(1); // Wait one millisecond for new random seed
            payments.Add(new Invoice("8943", 3, "Microphones", 35.75M));
            Thread.Sleep(1);
            payments.Add(new Invoice("6120", 7839, "Rocket Ships", 5732830578.78M));

            while (true)
            {
                show_menu();

                user_choice = Int16.Parse(Console.ReadLine());
                switch (user_choice)
                {
                    case 1: // Salaried
                        payments.Add(user_create_salaried());
                        write();

                        break;
                    case 2: // Hourly
                        payments.Add(user_create_hourly());
                        write();

                        break;
                    case 3: // Invoice
                        payments.Add(user_create_invoice());
                        write();

                        break;
                    case 4: // Report
                        decimal total_paid = 0;
                        decimal total_paid_salaried = 0;
                        decimal total_paid_hourly = 0;
                        decimal total_paid_invoice = 0;

                        decimal[] total_vars = { total_paid_salaried,
                                                 total_paid_hourly,
                                                 total_paid_invoice };

                        LedgerType[] types = { LedgerType.salaried,
                                               LedgerType.hourly,
                                               LedgerType.invoice };

                        write("Weekly Cash Flow Analysis is as follows:\n");

                        for (int i = 0; i < types.Length; ++i)
                        {
                            foreach (IPayable ip in payments)
                            {
                                if (ip.led_type == types[i])
                                {
                                    total_vars[i] += ip.get_payable_amount();
                                    write(ip.ToString());
                                    write();
                                }
                            }
                        }

                        foreach (IPayable i in payments)
                        {
                            total_paid += i.get_payable_amount();
                        }

                        write("Total Weekly Payout: " + total_paid.ToString("C") +
                            "\nCategory Breakdown:" +
                            "\n  Invoices: " + total_vars[2].ToString("C") +
                            "\n  Salaried Payroll: " + total_vars[0].ToString("C") +
                            "\n  Hourly Payroll: " + total_vars[1].ToString("C"));
                        write();

                        break;
                    case 5: // Quit
                        return;
                }

            }
        }
    }
}
