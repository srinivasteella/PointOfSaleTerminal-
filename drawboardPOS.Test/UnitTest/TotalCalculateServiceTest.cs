using drawboardPOS.Model;
using drawboardPOS.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace drawboardPOS.Test.UnitTest
{
    public class TotalCalculatorServiceTest : IDisposable
    {
        Mock<ICalculationService> moqCalculateService = null;
        ProductListandScanCount prodListCount;
        public TotalCalculatorServiceTest()
        {
            moqCalculateService = new Mock<ICalculationService>();
            Dictionary<Item, Product> productListDictionary = new Dictionary<Item, Product>();
            productListDictionary.Add(Item.A, new Product(Item.A, 1.25, new VolumePrice(3, 3)));
            productListDictionary.Add(Item.B, new Product(Item.B, 4.25, null));

            ProductList _productList = new ProductList(productListDictionary);
            IEnumerable<ScannedProducts> scannedProducts = new ScannedProducts[] { new ScannedProducts(Item.A, 1) };
            prodListCount = new ProductListandScanCount(scannedProducts, _productList);
        }

        public void Dispose()
        {
            moqCalculateService = null;
        }

        [Theory]
        [InlineData(13.25)]
        [InlineData(5.5)]
        public void Calculate_TotalPrice_AllScannedItems(double expectedprice)
        {
            //given
            moqCalculateService.Setup(m => m.CalculateBundlePrice(It.IsAny<ProducFactTable>())).Returns(expectedprice);
            moqCalculateService.Setup(m => m.CalculateItemPrice(It.IsAny<ProducFactTable>())).Returns(expectedprice);

            var sut = new TotalCalculatorService(moqCalculateService.Object);

            //when
            var actual = sut.CalculateTotal(prodListCount);

            //then
            Assert.Equal(expectedprice, actual);
            moqCalculateService.Verify(v => v.CalculateBundlePrice(It.IsAny<ProducFactTable>()), Times.Between(0, 10, Range.Inclusive));
            moqCalculateService.Verify(v => v.CalculateItemPrice(It.IsAny<ProducFactTable>()), Times.Between(0, 10, Range.Inclusive));
        }


    }
}
