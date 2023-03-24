using System;
using Xunit;

namespace Shapes.Test
{
    public sealed class TriangleTests
    {
        [Theory]
        [InlineData(-1, 1, 1)]
        [InlineData(1, -1, 1)]
        [InlineData(1, 1, -1)]
        [InlineData(0, 1, 2)]
        [InlineData(1, 0, 2)]
        [InlineData(1, 2, 0)]
        public void WhenEdgeLessOrEqualThanZeroThenThrowArgumentException(double x, double y, double z)
        {
            Assert.Throws<ArgumentException>(() => new Triangle(x, y, z));
        }

        [Theory]
        [InlineData(2, 3, 7)]
        [InlineData(3, 7, 2)]
        [InlineData(7, 3, 2)]
        [InlineData(2, 3, 6)]
        [InlineData(3, 6, 2)]
        [InlineData(6, 3, 2)]
        public void WhenTriangleCouldntExistsThenThrowArgumentException(double x, double y, double z)
        {
            Assert.Throws<ArgumentException>(() => new Triangle(x, y, z));
        }

        [Theory]
        [InlineData(1, 1, 1, 0.433012701)]
        [InlineData(2, 4, 3, 2.904737509)]
        [InlineData(2, 4, 5, 3.799671038)]
        [InlineData(3, 4, 5, 6)]
        public void GetAreaTests(double x, double y, double z, double area)
        {
            var t = new Triangle(x, y, z);
            Assert.Equal(area, t.GetArea(), 8);
        }

        [Theory]
        [InlineData(3, 4, 5)]
        [InlineData(5, 13, 12)]
        [InlineData(2, 5, 5.3851648)]
        public void WhenTriangleIsRightThenReturnIsRightTriangle(double x, double y, double z)
        {
            var t = new Triangle(x, y, z);
            Assert.True(t.IsRightTriangle());
        }

        [Theory]
        [InlineData(3, 4, 6)]
        [InlineData(5, 14, 12)]
        [InlineData(2, 6, 5.3851648)]
        public void WhenTriangleIsNotRightThenReturnIsNotRightTriangle(double x, double y, double z)
        {
            var t = new Triangle(x, y, z);
            Assert.False(t.IsRightTriangle());
        }
    }
}
