using drawboardPOS.Model;
using drawboardPOS.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace drawboardPOS.Test.UnitTest
{
    public class TerminalServiceTest : IDisposable
    {
        Mock<ITotalCalculatorService> moqTotalCalculateService = null;
        Mock<IPriceService> moqPriceService = null;
        Mock<IScanService> moqScanService = null;

        public TerminalServiceTest()
        {
            moqTotalCalculateService = new Mock<ITotalCalculatorService>();
            moqPriceService = new Mock<IPriceService>();
            moqScanService = new Mock<IScanService>();
        }
        public void Dispose()
        {
            moqTotalCalculateService = null;
            moqPriceService = null;
            moqScanService = null;
        }

        [Theory]
        [InlineData("ABCDABA", 13.5)]
        [InlineData("CCCCCCC", 6)]
        [InlineData("ABCD", 7.25)]

        public void Scan_Products(string scanProducts, double expected)
        {
            //given
            moqTotalCalculateService.Setup(m => m.CalculateTotal(It.IsAny<ProductListandScanCount>())).Returns(expected);

            var sut = new TerminalService(moqScanService.Object, moqPriceService.Object, moqTotalCalculateService.Object);

            //when
            sut.SetPrice();
            sut.Scan(scanProducts);
            var actual = sut.CalculateTotal();

            //then
            Assert.IsType<double>(actual);
            Assert.Equal(expected, actual);

            moqPriceService.Verify(v => v.SetPrice(), Times.Once);
            moqScanService.Verify(v => v.Scan(It.IsAny<ItemstoScan>()), Times.Once);
            moqTotalCalculateService.Verify(v => v.CalculateTotal(It.IsAny<ProductListandScanCount>()), Times.Once);
        }
    }
}
