using drawboardPOS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace drawboardPOS.Services
{
    public interface IScanService
    {
        IEnumerable<ScannedProducts> Scan(string ItemstoScan);

    }
    public class ScanService : IScanService
    {
        public IEnumerable<ScannedProducts> Scan(string ItemstoScan)
        {
            return ItemstoScan.groupby();
        }
    }
}
