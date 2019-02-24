using drawboardPOS.Services;
using System;
using System.Linq;

namespace drawboardPOS
{
    class Program
    {
        static void Main(string[] args)
        {
            var terminalService = (IService)Startup.Init().GetService(typeof(IService));
            terminalService.SetPrice();
            terminalService.Scan("ABCDABA");
            var total = terminalService.CalculateTotal();
            Console.WriteLine("Total Price:" + total);
            Console.Read();
        }
    }
}
