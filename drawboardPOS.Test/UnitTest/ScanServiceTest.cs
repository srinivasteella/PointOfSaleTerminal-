using drawboardPOS.Model;
using drawboardPOS.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace drawboardPOS.Test.UnitTest
{
    public class ScanServiceTest
    {
        [Theory]
        [InlineData("ABCDABA")]
        [InlineData(null)]
        public void ScanService_return_list_of_items(string inputData)
        {
            //given
            var expected = typeof(IEnumerable<ScannedProducts>);

            ItemstoScan items = new ItemstoScan(inputData);
            var sut = new ScanService();

            //when
            var actual = sut.Scan(items);

            //then
            Assert.IsAssignableFrom(expected, actual);
        }
    }
}
