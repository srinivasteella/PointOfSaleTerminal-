using drawboardPOS.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace drawboardPOS.Services
{
    public interface IService
    {
        void SetPrice();
        void Scan(string items);
        double CalculateTotal();
    }

    public class Service : IService
    {
        ProductList productList = new ProductList();
        Dictionary<Product, int> productVolume = new Dictionary<Product, int>();
        IScanService _scanService;
        IPriceService _priceService;
        ICalculateService _calculateService;
        double totalPrice = 0;

        public Service(IScanService scanService, IPriceService priceService, ICalculateService calculateService)
        {
            _scanService = scanService;
            _priceService = priceService;
            _calculateService = calculateService;
        }

        public double CalculateTotal()
        {
            foreach (var item in productVolume)
            {
                _calculateService.CalculateTotal(item, ref totalPrice);

            }
            return totalPrice;
        }

        public void Scan(string item)
        {
            var ItemArray = item.groupby();
            foreach (var product in ItemArray)
            {
                var productdetails = _scanService.Scan(product.productname, productList);
                if (productdetails != null)
                    productVolume.Add(productdetails, product.count);
            }
        }

        public void SetPrice() => productList = _priceService.SetPrice();


    }
}
