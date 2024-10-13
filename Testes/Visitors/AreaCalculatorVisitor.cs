using Testes.Classes;
using Testes.Interfaces;

namespace Testes.Visitors;

public class AreaCalculatorVisitor : IShapeVisitor
{
    public double Area { get; private set; }
    public void VisitCircle(Circle circle)
    {
        Area = circle.Radius * circle.Radius * Circle.Pi;
    }

    public void VisitSquare(Square square)
    {
        Area = square.Side * square.Side;
    }

    public void VisitRectangle(Rectangle rectangle)
    {
        Area = rectangle.Height * rectangle.Width;
    }
}