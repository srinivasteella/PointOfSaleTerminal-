﻿using drawboardPOS.Model;
using drawboardPOS.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace drawboardPOS.Test.UnitTest
{
    public class CalculateService : IDisposable
    {
        Product product;
        ScannedProducts scannedProduct;
        ProducFactTable productFactTable;
        public CalculateService()
        {
            product = new Product { Name = Item.A, OriginalPrice = 1.25, VolumePrice = new VolumePrice { Price = 3, Volume = 3 } };
            scannedProduct = new ScannedProducts { Count = 3, Name = Item.A };
            productFactTable = new ProducFactTable(scannedProduct, product);
        }

        public void Dispose()
        {
            product = null;
            scannedProduct = null;
            productFactTable = null;
        }

        [Theory]
        [InlineData(3.00)]
        public void CalculationService_return_total_price_of_scanned_items_thathasbundleoffers(double expected)
        {
            //given
            var sut = new CalculationService();

            //when
            var actual = sut.CalculateBundlePrice(productFactTable);

            //then
            Assert.Equal(expected, actual);
        }
    }
}
