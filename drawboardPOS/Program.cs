using System;
using System.Linq;

namespace drawboardPOS
{
    class Program
    {
        static void Main(string[] args)
        {
            PointOfSaleTerminal a = new PointOfSaleTerminal();
            string[] productarray = new string[] { "Donut", "KitKat", "Donut", "Lolly", "Cheese", "Donut", "KitKat", "Donut", "Donut", "Donut", "Donut" };
            var groupedProdList = groupby(productarray);
            double totalPrice = 0;
            foreach (var product in groupedProdList)
            {
                var prod = a.Scan(product);
                a.CalculateTotal(prod, product, ref totalPrice);
            }
            Console.WriteLine("Total Price:" + totalPrice);
            Console.Read();
        }

        private static dynamic groupby(string[] productarray)
        {
            var output = productarray
                .GroupBy(product => product)
                .OrderByDescending(group => group.Count())
                .Select(group => new { productname = group.Key, count = group.Count() });

            return output;
        }
    }
}
