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
        public Dictionary<Item, Product> _ProductList { get; private set; }
        public ProductList(Dictionary<Item, Product> productList)
        {
            _ProductList = productList;
        }
    }

    public class ScannedProducts
    {
        public Item Name { get; set; }
        public int Count { get; set; }
    }

    public class ProductListandScanCount
    {
        public IEnumerable<ScannedProducts> ScannedProducts { get; set; }
        public ProductList ProductList { get; set; }
        public ProductListandScanCount(IEnumerable<ScannedProducts> _ScannedProducts, ProductList _ProductList)
        {
            ScannedProducts = _ScannedProducts;
            ProductList = _ProductList;
        }

    }

    public class ProducFactTable
    {
        public ScannedProducts ScannedProduct { get; set; }
        public Product Product { get; set; }

        //public int ItemTypeCount { get; set; }
        //public double ItemOriginalPrice { get; set; }
        //public double ItemVolumnPrice { get; set; }
        //public int ItemVolume { get; set; }

        public ProducFactTable(ScannedProducts _scannedProduct, Product _product)
        {
            ScannedProduct = _scannedProduct;
            Product = _product;
        }

    }
}
