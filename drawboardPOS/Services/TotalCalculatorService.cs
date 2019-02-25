﻿using drawboardPOS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace drawboardPOS.Services
{
    public interface ITotalCalculatorService
    {
        double CalculateTotal(ProductListandScanCount productsListandCount);
    }
    public class TotalCalculatorService : ITotalCalculatorService
    {
        ICalculationService _calculateService;
        double totalprice = 0;

        public TotalCalculatorService(ICalculationService calculationService)
        {
            _calculateService = calculationService;
        }
        public double CalculateTotal(ProductListandScanCount productsListandCount)
        {
            if (productsListandCount == null)
            { return totalprice; }

            try
            {
                foreach (var scanneditems in productsListandCount.ScannedProducts.Where(a => a != null))
                {
                    var item = productsListandCount.ProductList._ProductList[scanneditems.Name];
                    var productfactdata = new ProducFactTable(scanneditems, item);
                    if (item.VolumePrice != null)
                        totalprice = totalprice + _calculateService.CalculateBundlePrice(productfactdata);
                    else
                        totalprice = totalprice + _calculateService.CalculateItemPrice(productfactdata);
                }
            }
            catch
            {
                //Log Exception
            }

            return totalprice;
        }
    }
}
