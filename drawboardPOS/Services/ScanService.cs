using drawboardPOS.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace drawboardPOS.Services
{
    public interface IScanService
    {
        Product Scan(string item, ProductList productList);

    }
    public class ScanService : IScanService
    {
        public Product Scan(string item, ProductList productList)
        {
            return productList.Product.Find(p => p.Name.ToString().Equals(item, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
