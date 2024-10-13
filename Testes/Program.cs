// See https://aka.ms/new-console-template for more information

using Testes;
using Testes.Classes;
using Testes.Interfaces;
using Testes.Visitors;

//var newOperation = new MinhaOperacao();
//var meuValor = 1;
//var b = newOperation.GetT(meuValor);
//Console.WriteLine(b);

var typesShapes = typeof(IShape).Assembly.GetTypes().Where(t =>
    t is not { IsAbstract: true, IsInterface: true } && t.IsAssignableTo(typeof(IShape)));

var visitor  =  new AreaCalculatorVisitor();
var square = new Square(3);
square.Accept(visitor);
Console.WriteLine(visitor.Area);