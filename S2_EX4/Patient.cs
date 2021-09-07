using System;

namespace S2_EX4
{
    public class Patient
    {
        private int numberInQueue;
        private WaitingRoom wr;

        public Patient(WaitingRoom wr)
        {
            this.wr = wr;
        }

        public void ReactToNumber(int ticketNumber)
        {
            if (ticketNumber == numberInQueue)
            {
                Console.WriteLine("Yay");
            }
        }
    }
}