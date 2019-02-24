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
        PriceTable priceTable;
        IScanService _scanService;
        IPriceService _priceService;
        ICalculateService _calculateService;

        public Service(IScanService scanService, IPriceService priceService, ICalculateService calculateService)
        {
            _scanService = scanService;
            _priceService = priceService;
            _calculateService = calculateService;
        }

        public double CalculateTotal()
        {
            return _calculateService.CalculateTotal(priceTable);
        }

        public void Scan(string item) => priceTable = _scanService.Scan(item.groupby(), productList);

        public void SetPrice() => productList = _priceService.SetPrice();


    }
}
