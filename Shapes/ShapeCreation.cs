namespace Shapes
{
    public static class ShapeCreation
    {
        /// <summary>
        /// Вычисление площади фигуры без знания ее типа во время компиляции
        /// </summary>
        /// <param name="shapeType">Тип фигуры</param>
        /// <param name="parameters">Параметры для вычисления площади конкретной фигуры</param>
        /// <returns>Возвращает площадь фигуры</returns>
        /// <exception cref="ArgumentException">Имя фигуры не поддерживается или параметры заданы неверно</exception>
        public static double GetAreaOnRuntime(string shapeType, params object?[]? parameters)
        {
            if (shapeType != "Circle" && shapeType != "Triangle")
                throw new ArgumentException("ShapeType can be only 'Circle' or 'Triangle'");

            Type type = Type.GetType($"Shapes.{shapeType}")!;

            try
            {
                var shape = (IShape?)Activator.CreateInstance(type, parameters);

                if (shape == null)
                    throw new ArgumentException();
                
                return shape.GetArea();
            }
            catch (MissingMethodException)
            {
                throw new ArgumentException("Invalid arguments");
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Invalid arguments. Exception message: {ex.Message}");
            }
        }

    }
}
