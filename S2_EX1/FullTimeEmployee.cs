namespace S2_DX1
{
    public class FullTimeEmployee: Employee
    {
        public double MonthlySalary;

        public FullTimeEmployee(string name, double MonthlySalary) : base(name)
        {
            this.MonthlySalary = MonthlySalary;
        }

        public override double GetMonthlySalary()
        {
            return MonthlySalary;
        }
    }
}