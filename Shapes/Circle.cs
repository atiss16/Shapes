namespace Shapes
{
    public class Circle : IShape
    {
        public double Radius { get; private set; }

        /// <summary>
        /// Инициализиация нового круга по его радиусу.
        /// </summary>
        /// <param name="radius">Первая сторона</param>
        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Radius must be greater than 0.");

            Radius = radius;
        }

        public double GetArea()
        {
            return Math.Pow(Radius, 2) * Math.PI;
        }
    }
}
