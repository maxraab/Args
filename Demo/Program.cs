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
                Args arg = new Args("l,n*,a#", new string[] { "-n", "Max", "-a", "25", "-l" });

                Console.WriteLine("soll geloggt werden?: {0}", arg.GetBoolean('l'));
                Console.WriteLine("dein Name: {0}", arg.GetString('n'));
                Console.WriteLine("dein Alter in Jahren: {0}", arg.GetInteger('a'));
            }
            catch (ArgsException e)
            {
                Console.WriteLine("Argument error: {0}", e.Message);
            }
        }
    }
}
