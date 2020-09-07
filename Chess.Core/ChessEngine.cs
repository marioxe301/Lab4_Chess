using System;
using Chess.Core.Interfaces;

namespace Chess.Core
{
    public class ChessEngine
    {
        private readonly IJsonSource _movementsSource;
        private readonly IJsonParser _movementsParser;
        //private readonly MovementValidator _validator;

        public ChessEngine(IJsonSource movementsSource, IJsonParser movementsParser)
        {
            _movementsSource = movementsSource;
            _movementsParser = movementsParser;
            //_validator = validator;
        }

        public void ValidateMoves()
        {
            var movementsJson = _movementsSource.GetMovementsFromSource();
            var movements = _movementsParser.SerializeChessPieces(movementsJson);
            //validator.checkMoves(movements); //receives movement list
            //internamente el validator tiene la tabla y revisa si los movimientos son validos
        }
    }
}
