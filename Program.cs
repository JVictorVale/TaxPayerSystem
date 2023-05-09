using System;
using System.Globalization;
using TaxPayerSystem.Entities;

namespace TaxPayerSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> list = new List<TaxPayer>();
            
            Console.Clear();
            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Tax payer #{i} data:");
                Console.Write("Individual or company (i/c)? ");
                char ch = Char.Parse(Console.ReadLine());

                if (ch == 'i' || ch == 'I')
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Anual income: ");
                    double anualIncome = Double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                    Console.Write("Health expenditures: ");
                    double healthExpenditures = Double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                    
                    list.Add(new Individual(name,anualIncome,healthExpenditures));
                }
                else if (ch == 'c' || ch == 'C')
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Anual income: ");
                    double anualIncome = Double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                    Console.Write("Number of employees: ");
                    int numberOfEmployees = int.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

                    list.Add(new Company(name, anualIncome, numberOfEmployees));
                }
                
            }
            
            double sum = 0.0;
            Console.WriteLine();
            Console.WriteLine("TAXES PAID: ");
            foreach (TaxPayer tp in list)
            {
                double tax = tp.Tax();
                Console.WriteLine(tp.ToString());
                sum += tax;
            }
                
            Console.WriteLine();
            Console.Write($"TOTAL TAXES: $ {sum}");
        }
    }
}

