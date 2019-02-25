using drawboardPOS.Services;
using System;
using Xunit;

namespace drawboardPOS.Test
{
    public class IntegrationTest : IDisposable
    {
        IPriceService priceService;
        IScanService scanService;
        ITotalCalculatorService totalcalculationService;
        ICalculationService calculationService;
        public IntegrationTest()
        {
            priceService = new PriceService();
            scanService = new ScanService();
            calculationService = new CalculationService();
            totalcalculationService = new TotalCalculatorService(calculationService);
        }

        public void Dispose()
        {
            priceService = null;
            scanService = null;
            totalcalculationService = null;
            calculationService = null;
        }

        [Theory]
        [InlineData("ABCDABAX", 13.25)]
        [InlineData("ABCDABA", 13.25)]
        [InlineData("AbCDaBA", 13.25)]
        [InlineData("CCCCCCC", 6.00)]
        [InlineData("ABCD", 7.25)]
        [InlineData("123", 0)] //incorrect data as numerics
        [InlineData("A B", 5.5)] //data with whitespace
        [InlineData("? *", 0)]//incorrect data as special characters
        public void Scan_Calculate_Product_Price(string inputproducts, double expectedvalue)
        {
            //given
            var sut = new TerminalService(scanService, priceService, totalcalculationService);
            sut.SetPrice();
            sut.Scan(inputproducts);

            //when
            var actualprice = sut.CalculateTotal();

            //then
            Assert.IsType<double>(actualprice);
            Assert.Equal(expectedvalue, actualprice);
        }
    }
}
