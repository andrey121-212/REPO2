using System;

interface IDrawable
{
    void Draw();
}

class Circle : IDrawable
{
    public void Draw()
    {
        Console.WriteLine("Рисую треугольник");
    }
}

class Rectangle : IDrawable
{
    public void Draw()
    {
        Console.WriteLine("Рисую круг");
    }
}

class Triangle : IDrawable
{
    public void Draw()
    {
        Console.WriteLine("Рисую квадрат");
    }
}

class Program
{
    static void Main()
    {
        IDrawable[] shapes = new IDrawable[]
        {
            new Circle(),
            new Rectangle(),
            new Triangle()
        };

        foreach (IDrawable shape in shapes)
        {
            shape.Draw();
        }
    }
}
