using System;
using System.Threading;

namespace S2_EX4
{
    public class WaitingRoom
    {
        public Action<int> NumberChange;
        private int currentNumber = 0;
        private int ticketCount = 0;

        public void RunWaitingRoom()
        {
            for (int i = currentNumber; currentNumber < ticketCount; currentNumber++)
            {
                NumberChange?.Invoke(i);
                Console.WriteLine($"Patient number {i} can now enter");
                Thread.Sleep(1000);
            }
        }

        public int DrawNummer()
        {
            ticketCount++;
            return ticketCount;
        }
    }
}