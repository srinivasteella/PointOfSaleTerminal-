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
        Dictionary<Item, Product> productList = new Dictionary<Item, Product>();

        public ProductList SetPrice()
        {
            productList.Add(Item.A, new Product { Name = Item.A, OriginalPrice = 1.25, VolumePrice = new VolumePrice { Price = 3, Volume = 3 } });
            productList.Add(Item.B, new Product { Name = Item.B, OriginalPrice = 4.25, VolumePrice = null });
            productList.Add(Item.C, new Product { Name = Item.C, OriginalPrice = 1, VolumePrice = new VolumePrice { Price = 5, Volume = 6 } });
            productList.Add(Item.D, new Product { Name = Item.D, OriginalPrice = 0.75, VolumePrice = null });

            return new ProductList(productList);
        }
    }
}
