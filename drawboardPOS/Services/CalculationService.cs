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
            if (productFactTable == null || productFactTable.ScannedProduct == null || productFactTable.Product == null)
            { return price; }
            try
            {
                bundle = productFactTable.ScannedProduct.Count / productFactTable.Product.VolumePrice.Volume;
                remaining = productFactTable.ScannedProduct.Count % productFactTable.Product.VolumePrice.Volume;
                price = (bundle * productFactTable.Product.VolumePrice.Price) + (remaining) * productFactTable.Product.OriginalPrice;
            }
            catch
            {
                //Log Exception 

            }
            return price;

        }

        public double CalculateItemPrice(ProducFactTable productFactTable)
        {
            if (productFactTable == null || productFactTable.ScannedProduct == null || productFactTable.Product == null)
            { return price; }
            try
            {
                price = productFactTable.ScannedProduct.Count * productFactTable.Product.OriginalPrice;
            }
            catch
            {
                //Log Exception 

            }
            return price;
        }

    }
}
