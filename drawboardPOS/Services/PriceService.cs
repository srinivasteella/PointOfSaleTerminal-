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
            return JsonConvert.DeserializeObject<ProductList>(File.ReadAllText("Products.json"));
        }
    }
}
