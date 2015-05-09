using System;
using Utilities;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Args arg = new Args("l,n*,a#", args);
                Args arg = new Args("l,n*,a#", new string[] { "-u", "Max", "-a", "25", "-l" });

                Console.WriteLine("soll ein Log geschrieben werden?: {0}", arg.GetBoolean('l'));
                Console.WriteLine("Name: {0}", arg.GetString('n'));
                Console.WriteLine("Alter: {0}", arg.GetInteger('a'));
            }
            catch (ArgsException e)
            {
                Console.WriteLine("Fehler: {0}", e.ErrorMessage());
            }
        }
    }
}
