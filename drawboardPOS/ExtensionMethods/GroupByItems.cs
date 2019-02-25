using drawboardPOS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace drawboardPOS
{
    public static class GroupByItems
    {
        public static IEnumerable<ScannedProducts> groupby(this string products)
        {
            var output = products.ToUpper().ToCharArray()
                .GroupBy(product => product)
                .Select(group => Regex.IsMatch(group.Key.ToString(), @"[A-Z]", RegexOptions.IgnorePatternWhitespace) &&
                Enum.TryParse(group.Key.ToString(), true, out Item item) ? new ScannedProducts { Name = item, Count = group.Count() } : null);

            return output;
        }
    }
}
