using drawboardPOS.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace drawboardPOS.Services
{
    public interface ICalculateService
    {
        double CalculateTotal(PriceTable item);
    }
    public class CalculateService : ICalculateService
    {
        double totalprice = 0;
        public double CalculateTotal(PriceTable item)
        {
            foreach (var product in item.ProductPriceTable)
            {
                if (product.Key.VolumePrice != null)
                    totalprice = totalprice + ((product.Value.Count / product.Key.VolumePrice.Volume) * product.Key.VolumePrice.Price) + (product.Value.Count % product.Key.VolumePrice.Volume) * product.Key.OriginalPrice;
                else
                    totalprice = totalprice + (product.Value.Count * product.Key.OriginalPrice);
            }

            return totalprice;
        }
    }
}
