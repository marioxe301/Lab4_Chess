using System;
using Chess.Core;
using Chess.Core.Interfaces;
using Chess.Infrastructure.JsonManipulation;
using Chess.Infrastructure.XYConverter;

namespace Chess.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Validating moves...");
            var engine = new ChessEngine(
                new JsonSource(),
                new JsonParser(),
                new MovementValidator(new XYConverter()));
            engine.ValidateMoves();
        }
    }
}
