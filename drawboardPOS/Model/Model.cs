using System;
using System.Collections.Generic;
using System.Text;

namespace drawboardPOS.Model
{
    public enum Item
    {
        A, B, C, D
    }
    public class VolumePrice
    {
        public int Volume { get; set; }
        public double Price { get; set; }
    }

    public class Product
    {
        public Item Name { get; set; }
        public double OriginalPrice { get; set; }
        public VolumePrice VolumePrice { get; set; }
    }

    public class ProductList
    {
        public List<Product> Product { get; set; }
    }

    public class ScannedProducts
    {
        public Item Name { get; set; }
        public int Count { get; set; }
    }

    public class PriceTable
    {
        public Dictionary<Product, ScannedProducts> ProductPriceTable { get; set; }
        public double TotalPrice { get; set; }
        public PriceTable(Dictionary<Product, ScannedProducts> _ProductPriceTable)
        {
            ProductPriceTable = _ProductPriceTable;
        }
    }

}
