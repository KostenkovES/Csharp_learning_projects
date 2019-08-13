using System;

namespace simple_geometry
{
    class Program
    {
        // класс Точка с приватными переменными, методом их поулчения в виде массива
        // и методом рассчета расстояния до произвольной точки
        class Point
        {
            private int x, y;
            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public int[] ReturnXY()
            {
                int[] returnXY = { this.x, this.y };
                return returnXY;
            }
            public double Distance(Point check)
            {
                return Math.Sqrt(Math.Pow(check.x - x, 2) + Math.Pow(check.y - y, 2));
            }
        }
        // класс Линия, использующий класс Точка для формирования линии и ряд расчетных методов
        class Line
        {
            private Point pointStartLine, pointEndLine;
            public Line(Point pointStartLine, Point pointEndLine)
            {
                this.pointStartLine = pointStartLine;
                this.pointEndLine = pointEndLine;
            }
            public string PointAffiliation(Point pointCheck)
            {
                if (((pointCheck.ReturnXY()[0] - pointStartLine.ReturnXY()[0]) * (pointEndLine.ReturnXY()[1] - pointStartLine.ReturnXY()[1]))
                    == ((pointCheck.ReturnXY()[1] - pointStartLine.ReturnXY()[1]) * (pointEndLine.ReturnXY()[0] - pointStartLine.ReturnXY()[0])))
                    return "принадлежит";
                else
                    return "не принадлежит";
            }
            public double Lenght()
            {
                double lenght = Math.Sqrt(Math.Pow(pointEndLine.ReturnXY()[0] - pointStartLine.ReturnXY()[0], 2)
                    + Math.Pow(pointEndLine.ReturnXY()[1] - pointStartLine.ReturnXY()[1], 2));
                return lenght;
            }
        }
        // аналогичный класс для квадрата
        class Square
        {
            private Point pointStartSqare, pointOfSquare1, pointOfSquare2, pointOfSquare3;
            private double sideSquare;
            public Square(Point pointStartSqare, double sideSquare)
            {
                this.pointStartSqare = pointStartSqare;
                this.sideSquare = sideSquare;
                pointOfSquare1 = new Point(pointStartSqare.ReturnXY()[0] + (int)sideSquare, pointStartSqare.ReturnXY()[1]);
                pointOfSquare2 = new Point(pointStartSqare.ReturnXY()[0] + (int)sideSquare, pointStartSqare.ReturnXY()[1] + (int)sideSquare);
                pointOfSquare3 = new Point(pointStartSqare.ReturnXY()[0], pointStartSqare.ReturnXY()[1] + (int)sideSquare);
            }
            public string PointInSquareCheck(Point pointToCheck)
            {
                if ((pointToCheck.ReturnXY()[0] >= pointStartSqare.ReturnXY()[0] && pointToCheck.ReturnXY()[0] <= (pointStartSqare.ReturnXY()[0] + sideSquare))
                    && (pointToCheck.ReturnXY()[1] >= pointStartSqare.ReturnXY()[1] && pointToCheck.ReturnXY()[1] <= (pointStartSqare.ReturnXY()[1] + sideSquare)))
                    return "принадлежит";
                else
                    return "не принадлежит";
            }
            public double SquareOfSquare()
            {
                double square_of_square = Math.Pow(sideSquare, 2);
                return square_of_square;
            }
            public double PerimeterOfSquare()
            {
                double perimeter_of_square = 4 * sideSquare;
                return perimeter_of_square;
            }
        }
        // аналогичный класс для круга
        class Circle
        {
            private Point pointCircleCentre;
            private double sideCircle;

            public Circle(Point pointCircleCentre, double sideCircle)
            {
                this.pointCircleCentre = pointCircleCentre;
                this.sideCircle = sideCircle;
            }
            public double SquareOfCircle()
            {
                double square_of_circle = Math.PI * Math.Pow(sideCircle, 2);
                return square_of_circle;
            }
            public double PerimeterOfCircle()
            {
                double perimeter_of_circle = 2 * Math.PI * sideCircle;
                return perimeter_of_circle;
            }
            public string PointInCircleCheck(Point pointToCheck)
            {
                double distance = (Math.Sqrt(Math.Pow(pointToCheck.ReturnXY()[0] - pointCircleCentre.ReturnXY()[0], 2)
                    + Math.Pow(pointToCheck.ReturnXY()[1] - pointCircleCentre.ReturnXY()[1], 2)));
                if (distance <= sideCircle)
                    return "принадлежит";
                else
                    return "не принадлежит";
            }
        }
        // аналогичный класс для прямоугольника
        class Rectangle
        {
            private Point pointStartRectangle, pointOfRectangle1, pointOfRectangle2, pointOfRectangle3;
            private double sideRectangle_OX, sideRectangle_OY;
            public Rectangle(Point pointStartRectangle, double sideRectangle_OX, double sideRectangle_OY)
            {
                this.pointStartRectangle = pointStartRectangle;
                this.sideRectangle_OX = sideRectangle_OX;
                this.sideRectangle_OY = sideRectangle_OY;
                pointOfRectangle1 = new Point(pointStartRectangle.ReturnXY()[0] + (int)sideRectangle_OX, pointStartRectangle.ReturnXY()[1]);
                pointOfRectangle2 = new Point(pointStartRectangle.ReturnXY()[0] + (int)sideRectangle_OX, pointStartRectangle.ReturnXY()[1] + (int)sideRectangle_OY);
                pointOfRectangle3 = new Point(pointStartRectangle.ReturnXY()[0], pointStartRectangle.ReturnXY()[1] + (int)sideRectangle_OY);
            }
            public string PointInRectangleCheck(Point pointToCheck)
            {
                if ((pointToCheck.ReturnXY()[0] >= pointStartRectangle.ReturnXY()[0] && pointToCheck.ReturnXY()[0] <=
                    (pointStartRectangle.ReturnXY()[0] + sideRectangle_OX)) && (pointToCheck.ReturnXY()[1] >=
                    pointStartRectangle.ReturnXY()[1] && pointToCheck.ReturnXY()[1] <= (pointStartRectangle.ReturnXY()[1] + sideRectangle_OY)))
                    return "принадлежит";
                else
                    return "не принадлежит";
            }
            public double SquareOfRectangle()
            {
                double rectangle_of_rectangle = sideRectangle_OX * sideRectangle_OY;
                return rectangle_of_rectangle;
            }
            public double PerimeterOfRectangle()
            {
                double perimeter_of_rectangle = 2 * (sideRectangle_OX * sideRectangle_OY);
                return perimeter_of_rectangle;
            }
        }

        static void Main(string[] args)
        {
            // вызов необходимой информации и соответствующий функций
            Console.Write("1) Создание точки и нахождение расстояния до нее" +
                "\nКоординаты точки:\nВведите х: ");
            int x1 = int.Parse(Console.ReadLine());
            Console.Write("Введите y: ");
            int y1 = int.Parse(Console.ReadLine());
            Point point1 = new Point(x1, y1);
            Console.Write("Введите точку до которой требуется найти растояние:\nВведите х: ");
            int x2 = int.Parse(Console.ReadLine());
            Console.Write("Введите y: ");
            int y2 = int.Parse(Console.ReadLine());
            Point point2 = new Point(x2, y2);
            Console.WriteLine("Расстояние от точки ({0},{1}) до точки ({2},{3}) составляет {4,5:0.00}",
                x1, y1, x2, y2, point1.Distance(point2));

            Console.Write("\n2) Создание линии, определение принадлежности точки линии и длины линии" +
                "\nКоординаты точки начала линии:\nВведите х: ");
            int start1 = int.Parse(Console.ReadLine());
            Console.Write("Введите y: ");
            int start2 = int.Parse(Console.ReadLine());
            Point pointStartLine = new Point(start1, start2);
            Console.Write("Координаты точки конца линии:\nВведите х: ");
            int end1 = int.Parse(Console.ReadLine());
            Console.Write("Введите y: ");
            int end2 = int.Parse(Console.ReadLine());
            Point pointEndLine = new Point(end1, end2);
            Line line = new Line(pointStartLine, pointEndLine);
            Console.Write("Введите точку которую требуется проверить:\nВведите х: ");
            int xCheck = int.Parse(Console.ReadLine());
            Console.Write("Введите y: ");
            int yCheck = int.Parse(Console.ReadLine());
            Point pointCheck = new Point(xCheck, yCheck);
            Console.WriteLine("Длинна линии с координатами (({0},{1}),({2},{3})) равна {4:0.00} ",
                start1, start2, end1, end2, line.Lenght());
            Console.WriteLine("Точка ({0},{1}) {2} линии",
                xCheck, yCheck, line.PointAffiliation(pointCheck));

            Console.Write("\n3) Создание квадрата, определение принадлежности ему точки, нахождение его площади и периметра" +
                "\nКоординаты левого нижнего угла квадрата:\nВведите х: ");
            int start_square1 = int.Parse(Console.ReadLine());
            Console.Write("Введите y: ");
            int start_square2 = int.Parse(Console.ReadLine());
            Point pointStartSquare = new Point(start_square1, start_square2);
            Console.Write("Введите длину стороны квадрата: ");
            double side_square1 = double.Parse(Console.ReadLine());
            Square square = new Square(pointStartSquare, side_square1);
            Console.Write("Введите точку которую требуется проверить:\nВведите х: ");
            int xCheck_Square = int.Parse(Console.ReadLine());
            Console.Write("Введите y: ");
            int yCheck_Square = int.Parse(Console.ReadLine());
            Point pointCheck_Square = new Point(xCheck_Square, yCheck_Square);
            Console.WriteLine("Периметр квадрата равен {0:0.00}, площадь квадрата равна {1:0.00}",
                square.SquareOfSquare(), square.PerimeterOfSquare());
            Console.WriteLine("Точка ({0},{1}) {2} квадрату",
                xCheck_Square, yCheck_Square, square.PointInSquareCheck(pointCheck_Square));

            Console.Write("\n4) Создание круга, определение принадлежности ему точки, нахождение его площади и периметра" +
                "\nКоординаты центра круга:\nВведите х: ");
            int start_circle1 = int.Parse(Console.ReadLine());
            Console.Write("Введите y: ");
            int start_circle2 = int.Parse(Console.ReadLine());
            Point pointStartCircle = new Point(start_circle1, start_circle2);
            Console.Write("Введите радиус круга: ");
            double side_circle1 = double.Parse(Console.ReadLine());
            Circle circle = new Circle(pointStartCircle, side_circle1);
            Console.Write("Введите точку которую требуется проверить:\nВведите х: ");
            int xCheck_Сircle = int.Parse(Console.ReadLine());
            Console.Write("Введите y: ");
            int yCheck_Сircle = int.Parse(Console.ReadLine());
            Point pointCheck_Circle = new Point(xCheck_Сircle, yCheck_Сircle);
            Console.WriteLine("Периметр круга равен {0:0.00}, площадь круга равна {1:0.00}",
                circle.SquareOfCircle(), circle.PerimeterOfCircle());
            Console.WriteLine("Точка ({0},{1}) {2} кругу",
                xCheck_Сircle, yCheck_Сircle, circle.PointInCircleCheck(pointCheck_Circle));

            Console.Write("\n5) Создание прямоугольника, определение принадлежности ему точки, нахождение его площади и периметра" +
                "\nКоординаты левого нижнего угла прямоугольника:\nВведите х: ");
            int start_rectangle1 = int.Parse(Console.ReadLine());
            Console.Write("Введите y: ");
            int start_rectangle2 = int.Parse(Console.ReadLine());
            Point pointStartRectangle = new Point(start_rectangle1, start_rectangle2);
            Console.Write("Введите длину стороны прямоугольника по оси OX: ");
            double side_rectangle_ox1 = double.Parse(Console.ReadLine());
            Console.Write("Введите длину стороны прямоугольника по оси OY: ");
            double side_rectangle_oy1 = double.Parse(Console.ReadLine());
            Rectangle rectangle = new Rectangle(pointStartRectangle, side_rectangle_ox1, side_rectangle_oy1);
            Console.Write("Введите точку которую требуется проверить:\nВведите х: ");
            int xCheck_Rectangle = int.Parse(Console.ReadLine());
            Console.Write("Введите y: ");
            int yCheck_Rectangle = int.Parse(Console.ReadLine());
            Point pointCheck_Rectangle = new Point(xCheck_Rectangle, yCheck_Rectangle);
            Console.WriteLine("Периметр прямоугольника равен {0:0.00}, площадь прямоугольника равна {1:0.00}",
                rectangle.SquareOfRectangle(), rectangle.PerimeterOfRectangle());
            Console.WriteLine("Точка ({0},{1}) {2} прямоугольнику",
                xCheck_Rectangle, yCheck_Rectangle, rectangle.PointInRectangleCheck(pointCheck_Rectangle));

            Console.ReadLine();
        }
    }
}
