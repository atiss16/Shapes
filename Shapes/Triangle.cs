namespace Shapes
{
    public class Triangle : IShape
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }

        /// <summary>
        /// Инициализиация нового треугольника по трем его сторонам.
        /// </summary>
        /// <param name="x">Первая сторона</param>
        /// <param name="y">Вторая сторона</param>
        /// <param name="z">Третья сторона</param>
        public Triangle(double x, double y, double z)
        {
            if (x <= 0 || y <= 0 || z <= 0)
                throw new ArgumentException("Сторона треугольника не может быть меньше или равна 0.");

            if (x + y < z)
                throw new ArgumentException("Такого треугольника не существует. Должно быть x + y > z");
            if (x + z < y)
                throw new ArgumentException("Такого треугольника не существует. Должно быть x + z > y");
            if (y + z < x)
                throw new ArgumentException("Такого треугольника не существует. Должно быть y + z < x");

            X = x;
            Y = y;
            Z = z;            
        }

        public double GetArea()
        {
            double p = perimetr() / 2;
            return Math.Sqrt(p * (p - X) * (p - Y) * (p - Z));
        }

        /// <summary>
        /// Является ли треугольник прямоугольным.
        /// </summary>
        public bool IsRightTriangle()
        {
            var edges = new List<double> { X, Y, Z };
            edges.Sort();

            double SumSquaresLegs = Math.Pow(edges[0], 2) + Math.Pow(edges[1], 2);
            return Math.Abs(SumSquaresLegs - Math.Pow(edges[2], 2)) < 1e-6;
        }

        private double perimetr() => X + Y + Z;
    }
}
