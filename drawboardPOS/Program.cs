using drawboardPOS.Services;
using System;
using System.Linq;

namespace drawboardPOS
{
    class Program
    {
        static void Main(string[] args)
        {
            var terminalService = Startup.Init();
            Console.WriteLine("Please enter the items!");
            var input = System.Console.ReadLine();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            terminalService.SetPrice();
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            var watch1 = System.Diagnostics.Stopwatch.StartNew();
            terminalService.Scan(input);
            watch1.Stop();
            Console.WriteLine(watch1.ElapsedMilliseconds);
            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            var total = terminalService.CalculateTotal();
            watch2.Stop();
            Console.WriteLine(watch2.ElapsedMilliseconds);
            Console.WriteLine("Total Price:" + total);
            Console.Read();
        }
    }
}
