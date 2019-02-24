using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace drawboardPOS
{
    public static class GroupByItems
    {
        public static dynamic groupby(this string products)
        {
            var output = products.ToCharArray()
                .GroupBy(product => product)
                .OrderByDescending(group => group.Count())
                .Select(group => new { productname = group.Key.ToString(), count = group.Count() });

            return output;
        }
    }
}
