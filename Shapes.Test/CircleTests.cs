using System;
using Xunit;

namespace Shapes.Test
{
    public class CircleTests
    {
        [Fact]
        public void WhenRadiusLessThanZeroThenThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Circle(-1));
        }

        [Fact]
        public void WhenRadiusIsZeroThenThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Circle(0));
        }

        [Theory]
        [InlineData(2, 12.56637061)]
        [InlineData(3.14, 30.97484693)]
        [InlineData(1, Math.PI)]
        public void GetAreaTests(double radius, double area)
        {
            var c = new Circle(radius);
            Assert.Equal(area, c.GetArea(), 8);
        }
    }
}