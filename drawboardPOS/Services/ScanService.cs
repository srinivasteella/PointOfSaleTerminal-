using drawboardPOS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace drawboardPOS.Services
{
    public interface IScanService
    {
        PriceTable Scan(IEnumerable<ScannedProducts> product, ProductList productList);

    }
    public class ScanService : IScanService
    {
        public PriceTable Scan(IEnumerable<ScannedProducts> products, ProductList productList)
        {
            Dictionary<Product, ScannedProducts> productVolume = new Dictionary<Product, ScannedProducts>();

            foreach (var product in products.Where(p => p != null))
            {
                var productdetails = productList.Product.Find(p => p.Name.Equals(product.Name));
                if (productdetails != null)
                    productVolume.Add(productdetails, product);
            }
            return new PriceTable(productVolume);
        }
    }
}
