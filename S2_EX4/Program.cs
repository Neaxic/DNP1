using System;

namespace S2_EX4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            WaitingRoom wr1 = new WaitingRoom();
            Patient p1 = new Patient(wr1);
            
            wr1.NumberChange += p1.ReactToNumber;


        }
    }
}