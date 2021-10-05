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
            decimal discountTotal = Discount.DiscountedCost(3, 2);

            Assert.Equal(1, discountTotal);

        }
    }
}
