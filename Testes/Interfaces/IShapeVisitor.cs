using Testes.Classes;

namespace Testes.Interfaces;

public interface IShapeVisitor
{
    void VisitCircle(Circle circle);
    void VisitSquare(Square square);
    void VisitRectangle(Rectangle rectangle);
}