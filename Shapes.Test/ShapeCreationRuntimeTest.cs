using System;
using Xunit;

namespace Shapes.Test
{
    public sealed class ShapeCreationRuntimeTest
    {
        [Fact]
        public void WhenNotSupportedShapeTypeThenThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ShapeCreation.GetAreaOnRuntime("Rectangle", 1));
        }

        [Theory]
        [InlineData("Circle", 1, 2, 3)]
        [InlineData("Circle", null)]
        [InlineData("Circle", "1")]
        [InlineData("Triangle", 1)]
        [InlineData("Triangle", "2")]
        public void WhenNotValidParametersThenThrowArgumentException(string shapeType, params object?[]? parameters)
        {
            Assert.Throws<ArgumentException>(() => ShapeCreation.GetAreaOnRuntime(shapeType, parameters));
        }

        [Theory]
        [InlineData(3.14, 30.97484693)]
        public void WhenValidCircleThenCalculateArea(double radius, double area)
        {
            Assert.Equal(area, ShapeCreation.GetAreaOnRuntime("Circle", radius), 8);
        }

        [Theory]
        [InlineData(3, 4, 5, 6)]
        public void WhenValidRectangleThenCalculateArea(double x, double y, double z, double area)
        {
            Assert.Equal(area, ShapeCreation.GetAreaOnRuntime("Triangle", x, y, z), 8);
        }
    }
}
