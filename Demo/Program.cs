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
                //Args arg = new Args("l", args);
                Args arg = new Args("l", new string[] { "-l", "true" });
                bool logging = arg.GetBoolean('l');

                Console.WriteLine("soll geloggt werden?: {0}", logging);
            }
            catch (ArgsException e)
            {
                Console.WriteLine("Argument error: {0}", e.Message);
            }

            Console.ReadLine();
        }
    }
}
