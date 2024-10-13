using Testes.Interfaces;

namespace Testes.Classes;



public class Rectangle(double height, double width) : IShape
{
    public double Height { get; private set; } = height;
    public double Width { get; private set; } = width;

    public void Accept(IShapeVisitor visitor)
    {
        visitor.VisitRectangle(this);
    }
}

public class Circle(double radius) : IShape
{
    public const double Pi = Math.PI;
    public double Radius { get; private set; } = radius;

    public void Accept(IShapeVisitor visitor)
    {
        visitor.VisitCircle(this);
    }
}

public class Square(double side) : IShape
{
    public double Side { get; private set; } = side;
    public void Accept(IShapeVisitor visitor)
    {
        visitor.VisitSquare(this);
    }
}