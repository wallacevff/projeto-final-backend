namespace Testes.Interfaces;

public interface IShape
{
    public void Accept(IShapeVisitor visitor);
}

