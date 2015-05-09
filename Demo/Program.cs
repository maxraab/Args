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
                Args arg = new Args("l,n*", args);
                //Args arg = new Args("l", new string[] { "-l", "true" });

                Console.WriteLine("soll geloggt werden?: {0}", arg.GetBoolean('l'));
                Console.WriteLine("dein Name: {0}", arg.GetString('n'));
            }
            catch (ArgsException e)
            {
                Console.WriteLine("Argument error: {0}", e.Message);
            }

            Console.ReadLine();
        }
    }
}
