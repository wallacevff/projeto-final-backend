﻿// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices.JavaScript;
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
FunctionHandling.Prevent(() => square.Accept(visitor));
var soma = FunctionHandling.Prevent(() => FunctionHandling.Somar(2, 3));
Console.WriteLine(visitor.Area);
Console.WriteLine(soma);

var a = new MinhaHeranca();