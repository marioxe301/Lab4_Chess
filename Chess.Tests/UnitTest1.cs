using System;
using Xunit;
using Chess.Core;
using Chess.Infrastructure.JsonManipulation;
using Chess.Infrastructure.XYConverter;

namespace Chess.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestPawnMovement()
        {
            var engine = new ChessEngine(
                new JsonSource(),
                new JsonParser(),
                new MovementValidator(new XYConverter()));
            Assert.False(engine.ValidateMove(1));
        }

        [Fact]
        public void TestRookMovement()
        {
            var engine = new ChessEngine(
                new JsonSource(),
                new JsonParser(),
                new MovementValidator(new XYConverter()));
            Assert.False(engine.ValidateMove(2));
        }
    }
}
