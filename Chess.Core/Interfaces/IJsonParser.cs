using System;
using System.Collections.Generic;
using System.Text;
using Chess.Core.Models;

namespace Chess.Core.Interfaces
{
    public interface IJsonParser
    {
        List<ChessPiece> SerializeChessPieces(string movementsJson);
    }
}
