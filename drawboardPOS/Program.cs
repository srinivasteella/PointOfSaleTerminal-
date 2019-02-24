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
            terminalService.SetPrice();
            terminalService.Scan("123");
            var total = terminalService.CalculateTotal();
            Console.WriteLine("Total Price:" + total);
            Console.Read();
        }
    }
}
