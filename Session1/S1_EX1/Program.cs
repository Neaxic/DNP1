using System;
using System.Collections.Generic;

namespace S1_EX1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> klasseListe = new();
            Person karl = new("Karl", 25);

            klasseListe.Add(new("Bente", 21));
            klasseListe.Add(karl);
            
            Console.WriteLine("Hello smatso!");
            Person p1 = new();
            p1.Name = Console.ReadLine();
            Console.WriteLine("Yo "+p1.Name);
            Console.Write("Input age: ");
            string ageInput = Console.ReadLine();
            try
            {
                p1.Age = Int32.Parse(ageInput);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Ugyldigt Input '{ageInput}");
            }
            Console.Write("Du blev født i år: "+p1.CalcBirthYear());

            Console.WriteLine("Klassen består af: ");
            foreach (Person i in klasseListe)
            {
                Console.Write($"{i.Name}, {i.Age} År gammel, født i {i.CalcBirthYear()} \n");
                //Console.Write(i.Name + ", " +i.Age + " År\n");
            }

        }
    }
}