using drawboardPOS.Services;
using System;
using Xunit;

namespace drawboardPOS.Test
{
    public class UnitTest : IDisposable
    {
        IPriceService priceService;
        IScanService scanService;
        ICalculateService calculationService;
        public UnitTest()
        {
            priceService = new PriceService();
            scanService = new ScanService();
            calculationService = new CalculateService();
        }

        public void Dispose()
        {
            priceService = null;
            scanService = null;
            calculationService = null;
        }

        [Theory]
        [InlineData("ABCDABAX", 13.25)]
        [InlineData("CCCCCCC", 6.00)]
        [InlineData("ABCD", 7.25)]
        [InlineData("123", 0)] //incorrect data as numerics
        [InlineData("A B", 5.5)] //data with whitespace
        [InlineData("? *", 0)]//incorrect data as special characters
        public void Scan_Calculate_Product_Price(string inputproducts, double expectedvalue)
        {
            var sut = new Service(scanService, priceService, calculationService);
            sut.SetPrice();
            sut.Scan(inputproducts);
            var actualprice = sut.CalculateTotal();
            Assert.IsType<double>(actualprice);
            Assert.Equal(expectedvalue, actualprice);
        }
    }
}
