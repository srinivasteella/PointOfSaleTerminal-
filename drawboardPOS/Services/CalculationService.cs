using drawboardPOS.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace drawboardPOS.Services
{
    public interface ICalculationService
    {
        double CalculateBundlePrice(ProducFactTable productFactTable);
        double CalculateItemPrice(ProducFactTable productFactTable);
    }
    public class CalculationService : ICalculationService
    {
        double price = 0;
        int remaining = 0, bundle = 0;
        public double CalculateBundlePrice(ProducFactTable productFactTable)
        {
            bundle = productFactTable.ScannedProduct.Count / productFactTable.Product.VolumePrice.Volume;
            remaining = productFactTable.ScannedProduct.Count % productFactTable.Product.VolumePrice.Volume;
            price = (bundle * productFactTable.Product.VolumePrice.Price) + (remaining) * productFactTable.Product.OriginalPrice;

            return price;
        }

        public double CalculateItemPrice(ProducFactTable productFactTable)
        {
            price = productFactTable.ScannedProduct.Count * productFactTable.Product.OriginalPrice;
            return price;
        }
    }
}
