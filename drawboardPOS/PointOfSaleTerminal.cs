using drawboardPOS.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace drawboardPOS
{
    public interface IPointOfSaleTerminal
    {
        Product Scan(dynamic productName);
        void CalculateTotal(Product prod, dynamic saleprod, ref double totalprice);

    }
    class PointOfSaleTerminal : IPointOfSaleTerminal
    {
        RootObject productList = new RootObject();
        public PointOfSaleTerminal()
        {
            using (StreamReader r = new StreamReader("Products.json"))
            {
                string json = r.ReadToEnd();
                productList = JsonConvert.DeserializeObject<RootObject>(json);

            }
        }

        public void CalculateTotal(Product prod, dynamic saleprod, ref double totalprice)
        {
            Double individualprice = ((saleprod.count / prod.VolumePrice.Volume) * prod.VolumePrice.Price) + (saleprod.count % prod.VolumePrice.Volume) * prod.OriginalPrice;
            totalprice = totalprice + ((saleprod.count / prod.VolumePrice.Volume) * prod.VolumePrice.Price) + (saleprod.count % prod.VolumePrice.Volume) * prod.OriginalPrice;
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(prod.Name + " : " + saleprod.count);
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Total volume offer : (" + saleprod.count + "/" + prod.VolumePrice.Volume + ")*" + prod.VolumePrice.Price);
            Console.WriteLine("Individual items : (" + saleprod.count + "%" + prod.VolumePrice.Volume + ")*" + prod.OriginalPrice);
            Console.WriteLine("Final price for " + prod.Name + " = " + individualprice);
        }

        public Product Scan(dynamic productName)
        {
            return productList.Products.Find(p => p.Name.Equals(productName.productname, StringComparison.InvariantCulture));
        }


    }
}
