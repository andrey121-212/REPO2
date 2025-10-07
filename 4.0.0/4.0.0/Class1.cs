using System;

namespace _4._0._0
{
    // Интерфейс Фигура
    public interface IShape
    {
        double CalculateArea();
        double CalculatePerimeter();
        string GetShapeName();
    }

    // Класс Круг
    public class Circle : IShape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public string GetShapeName()
        {
            return "Круг";
        }
    }

    // Класс Прямоугольник
    public class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double CalculateArea()
        {
            return Width * Height;
        }

        public double CalculatePerimeter()
        {
            return 2 * (Width + Height);
        }

        public string GetShapeName()
        {
            return "Прямоугольник";
        }
    }

    // Класс Треугольник
    public class Triangle : IShape
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public double CalculateArea()
        {
            // Используем формулу Герона
            double p = CalculatePerimeter() / 2;
            return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }

        public double CalculatePerimeter()
        {
            return SideA + SideB + SideC;
        }

        public string GetShapeName()
        {
            return "Треугольник";
        }

        public bool IsValidTriangle()
        {
            return SideA + SideB > SideC &&
                   SideA + SideC > SideB &&
                   SideB + SideC > SideA;
        }
    }
}