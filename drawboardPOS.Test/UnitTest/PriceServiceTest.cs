using drawboardPOS.Model;
using drawboardPOS.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace drawboardPOS.Test.UnitTest
{
    public class PriceServiceTest
    {
        [Fact]
        public void SetPrice_return_allproduct_prices()
        {
            //given
            var sut = new PriceService();

            //when
            var actual = sut.SetPrice();

            //then
            Assert.IsType<ProductList>(actual);
        }
    }
}
