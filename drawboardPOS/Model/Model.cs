using System;
using System.Collections.Generic;
using System.Text;

namespace drawboardPOS.Model
{
    public enum Item
    {
        A, B, C, D, E
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

}
