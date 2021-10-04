using System;
using System.Text.Json.Serialization;
using DefaultNamespace;

namespace SDJ_JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            JSONConverter c = new JSONConverter();
            Person p = c.jsonConverter();
            Console.WriteLine(p.name);
            Console.WriteLine("Hello World!");
        }
    }
}