namespace Testes
{
    public static class FunctionHandling
    {
        public static TResult? Prevent<TResult>(Func<TResult?> func)
        {
            try
            {
                return func();
            }
            catch
            {
                Console.WriteLine("Erro");
                return default;
            }
        }
        public static void Prevent(Action func)
        {
            try
            {
                func();
            }
            catch
            {
                Console.WriteLine("Erro");
            }
        }


        public static int Somar(int a, int b)
        {
            return a + b;
        }
    }
}
