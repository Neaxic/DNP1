using System;

namespace S2_DX1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Company c1 = new Company();

            Employee bent = new PartTimeEmployee("Bent", 130, 30);
            Employee peter = new FullTimeEmployee("Peter", 30000);
            
            c1.HireNewEmployee(bent);

            Console.WriteLine(c1.GetMonthlySalaryTotal());
            
            c1.HireNewEmployee(peter);

            Console.WriteLine(c1.GetMonthlySalaryTotal());
        }
    }
}