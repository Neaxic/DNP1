using System.Collections;

namespace S2_DX1
{
    public class Company
    {
        private ArrayList employees = new ArrayList();
        
        public double GetMonthlySalaryTotal()
        {
            double total = 0;
            foreach(Employee i in employees)
            {
                total += i.GetMonthlySalary();
            }
            return total;
        }

        public void HireNewEmployee(Employee emp)
        {
            employees.Add(emp);
        }
    }
}