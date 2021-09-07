namespace S2_DX1
{
    public abstract class Employee
    {
        public string name;

        public Employee(string name)
        {
            this.name = name;
        }

        public abstract double GetMonthlySalary();
    }
}