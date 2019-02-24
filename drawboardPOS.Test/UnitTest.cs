using drawboardPOS.Services;
using System;
using Xunit;

namespace drawboardPOS.Test
{
    public class UnitTest
    {
        [Fact]
        public void Scan_Calculate_Product_Price()
        {
            var scan = new ScanService();
            var price = new PriceService();
            var calculate = new CalculateService();
            var sut = new Service(scan, price, calculate);
            sut.SetPrice();
            sut.Scan("ABCD");
            var total = sut.CalculateTotal();
            Assert.Equal(7.25, total);
        }
    }
}
