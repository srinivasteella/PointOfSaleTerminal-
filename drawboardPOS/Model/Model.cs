using System;
using System.Collections.Generic;
using System.Text;

namespace drawboardPOS.Model
{

    public class VolumePrice
    {
        public int Volume { get; set; }
        public double Price { get; set; }
    }

    public class Product
    {
        public string Name { get; set; }
        public double OriginalPrice { get; set; }
        public VolumePrice VolumePrice { get; set; }
    }

    public class RootObject
    {
        public List<Product> Products { get; set; }
    }


}
