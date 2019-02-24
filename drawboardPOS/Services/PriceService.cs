using drawboardPOS.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace drawboardPOS.Services
{
    public interface IPriceService
    {
        ProductList SetPrice();

    }
    public class PriceService : IPriceService
    {
        public ProductList SetPrice()
        {
            using (StreamReader r = new StreamReader("Products.json"))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<ProductList>(json);
            }
        }
    }
}
