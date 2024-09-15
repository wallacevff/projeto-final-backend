namespace Testes;

public class MinhaOperacao : ITesteOperacao
{
    public object GetT(params object[] valor)
    {
        return valor;
    }
}