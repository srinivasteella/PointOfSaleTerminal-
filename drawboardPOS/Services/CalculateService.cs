using drawboardPOS.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace drawboardPOS.Services
{
    public interface ICalculateService
    {
        void CalculateTotal(dynamic item, ref double totalprice);
    }
    public class CalculateService : ICalculateService
    {
        public void CalculateTotal(dynamic item, ref double totalprice)
        {
            if (item.Key.VolumePrice != null)
                totalprice = totalprice + ((item.Value / item.Key.VolumePrice.Volume) * item.Key.VolumePrice.Price) + (item.Value % item.Key.VolumePrice.Volume) * item.Key.OriginalPrice;
            else
                totalprice = totalprice + (item.Value * item.Key.OriginalPrice);

        }
    }
}
