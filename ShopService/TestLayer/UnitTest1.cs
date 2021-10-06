using System;
using Xunit;
using BusinessLayer;

namespace TestLayer
{
    public class UnitTest1
    {
        [Fact]
        public void DiscountTest()
        {
            decimal discountTotal = Discount.DiscountedCost(3, (decimal)0.02);

            Assert.Equal((decimal)2.94, discountTotal);

        }
    }
}
