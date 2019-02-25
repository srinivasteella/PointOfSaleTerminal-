using drawboardPOS.Model;
using System.Collections.Generic;

namespace drawboardPOS.Services
{
    public interface ITerminalService
    {
        void SetPrice();
        void Scan(string items);
        double CalculateTotal();
    }

    public class TerminalService : ITerminalService
    {
        ProductList productList = null;
        IEnumerable<ScannedProducts> scannedProducts;
        IScanService _scanService;
        IPriceService _priceService;
        ITotalCalculatorService _TotalCalculatorService;

        public TerminalService(IScanService scanService, IPriceService priceService, ITotalCalculatorService TotalCalculatorService)
        {
            _scanService = scanService;
            _priceService = priceService;
            _TotalCalculatorService = TotalCalculatorService;
        }

        public double CalculateTotal()
        {
            var ProductListandScanCount = new ProductListandScanCount(scannedProducts, productList);
            return _TotalCalculatorService.CalculateTotal(ProductListandScanCount);

        }

        public void Scan(string item) => scannedProducts = _scanService.Scan(new ItemstoScan(item));

        public void SetPrice() => productList = _priceService.SetPrice();


    }
}
