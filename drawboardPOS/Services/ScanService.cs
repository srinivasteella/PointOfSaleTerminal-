using drawboardPOS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace drawboardPOS.Services
{
    public interface IScanService
    {
        IEnumerable<ScannedProducts> Scan(ItemstoScan ItemstoScan);

    }
    public class ScanService : IScanService
    {
        public IEnumerable<ScannedProducts> Scan(ItemstoScan ItemstoScan)
        {
            if (ItemstoScan == null || ItemstoScan.Items == null)
            { return Enumerable.Empty<ScannedProducts>(); }

            return ItemstoScan.Items.groupby();
        }
    }
}
