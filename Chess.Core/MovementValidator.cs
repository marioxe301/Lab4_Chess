using System;
using System.Collections.Generic;
using Chess.Core.Models;
using Chess.Core.Interfaces;

namespace Chess.Core
{
    public class MovementValidator
    {
        private readonly ChessPieceType[,] table;
        //private List<ChessPiece> _movements;
        private IXYConverter _converter;

        public MovementValidator(IXYConverter converter)
        {
            table = new ChessPieceType[8, 8] {{ ChessPieceType.None, ChessPieceType.None,
                ChessPieceType.None, ChessPieceType.None, ChessPieceType.None, ChessPieceType.None,
                ChessPieceType.None, ChessPieceType.None },{ ChessPieceType.None, ChessPieceType.None,
                ChessPieceType.None, ChessPieceType.None, ChessPieceType.None, ChessPieceType.None,
                ChessPieceType.None, ChessPieceType.None },{ ChessPieceType.None, ChessPieceType.None,
                ChessPieceType.None, ChessPieceType.None, ChessPieceType.None, ChessPieceType.None,
                ChessPieceType.None, ChessPieceType.None },{ ChessPieceType.None, ChessPieceType.None,
                ChessPieceType.None, ChessPieceType.None, ChessPieceType.None, ChessPieceType.None,
                ChessPieceType.None, ChessPieceType.None },{ ChessPieceType.None, ChessPieceType.None,
                ChessPieceType.None, ChessPieceType.None, ChessPieceType.None, ChessPieceType.None,
                ChessPieceType.None, ChessPieceType.None },{ ChessPieceType.None, ChessPieceType.None,
                ChessPieceType.None, ChessPieceType.None, ChessPieceType.None, ChessPieceType.None,
                ChessPieceType.None, ChessPieceType.None },{ ChessPieceType.None, ChessPieceType.None,
                ChessPieceType.None, ChessPieceType.None, ChessPieceType.None, ChessPieceType.None,
                ChessPieceType.None, ChessPieceType.None },{ ChessPieceType.None, ChessPieceType.None,
                ChessPieceType.None, ChessPieceType.None, ChessPieceType.None, ChessPieceType.None,
                ChessPieceType.None, ChessPieceType.None },};
            //_movements = movements;
            _converter = converter;
        }

        public void checkMoves(List<ChessPiece> movements)
        {
            movements.ForEach(piece =>
            {
                //convert movement format to coordinates
                int x1 = _converter.CharToCoordinate(piece.from[0]);
                int y1 = _converter.CharToCoordinate(piece.from[1]);
                int x2 = _converter.CharToCoordinate(piece.to[0]);
                int y2 = _converter.CharToCoordinate(piece.to[0]);
                //store if its an available spot
                bool SpotIsAvailable = table[x2, y2] == ChessPieceType.None;
               
                if(SpotIsAvailable)
                {
                    //check if move is valid
                    System.Console.WriteLine("Valid movement");
                }
                else
                {
                    System.Console.WriteLine("Invalid movement");
                }
                
            });
        }

        private bool IsValid(ChessPieceType type, int x1, int y1, int x2, int y2)
        {
            switch (type)
            {
                case ChessPieceType.Pawn:
                    {
                        int[] XPossible = new int[2] { x1, x1 };
                        int[] YPossible = new int[2] { y1 + 1, y1 - 1 };
                        for (int i = 0; i < 2; i++)
                        {
                            if (x2 == XPossible[i] && y2 == YPossible[i])
                            {
                                return true;
                            }
                        }
                        return false;
                    }
                    
                case ChessPieceType.Horse:
                    {
                        int[] XPossible = new int[8] { x1-1, x1+1, x1-2, x1+2,
                            x1 - 1, x1 + 1, x1 - 2, x1 + 2 };
                        //int[] YPossible = new int[8] { y1 };
                        return false;
                    }
                    

                case ChessPieceType.Rook:
                    {
                        return false;
                    }
                default:
                    return false;
            }
        }
    }
}
