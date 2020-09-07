using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Core.Models
{
    public class ChessPiece
    {
        public ChessPieceType type { get; set; }
        public string to { get; set; }

        public string from { get; set; }

        
    }
}
