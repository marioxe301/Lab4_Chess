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
            for(int i = 0; i < movements.Count; i++)
            {
                if(checkMove(movements, i))
                {
                    System.Console.WriteLine("Valid movement");
                }
                else
                {
                    System.Console.WriteLine("Invalid movement");
                }
            }
        }

        public bool checkMove(List<ChessPiece> movements, int index)
        {
            int x1 = _converter.CharToCoordinate(movements[index].from[0]);
            int y1 = _converter.CharToCoordinate(movements[index].from[1]);
            int x2 = _converter.CharToCoordinate(movements[index].to[0]);
            int y2 = _converter.CharToCoordinate(movements[index].to[1]);
            bool SpotIsAvailable = table[x2, y2] == ChessPieceType.None;
            bool MovementIsValid = IsValid(movements[index].type, x1, y1, x2, y2);
            return SpotIsAvailable && MovementIsValid;
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
                        int paraArriba = y1+1;
                        while(paraArriba <= 8)
                        {
                            //XPossibleMoves.Add(x1);
                            //YPossibleMoves.Add(paraArriba);
                            if(x2 == x1 && y2 == paraArriba)
                            {
                                return true;
                            }
                            paraArriba++;
                        }
                        int paraAbajo = y1 - 1;
                        while (paraAbajo >= 0)
                        {
                            //XPossibleMoves.Add(x1);
                            //YPossibleMoves.Add(paraAbajo);
                            if(x2 == x1 && y2 == paraAbajo)
                            {
                                return true;
                            }
                            paraAbajo--;
                        }
                        int paraIzquierda = x1 - 1;
                        while(paraIzquierda >= 0)
                        {
                            //XPossibleMoves.Add(paraIzquierda);
                            //YPossibleMoves.Add(y1);
                            if(x2 == paraIzquierda && y2 == y1)
                            {
                                return true;
                            }
                            paraIzquierda--;
                        }
                        int paraDerecha = x1 + 1;
                        while (paraDerecha <= 8)
                        {
                            //XPossibleMoves.Add(paraDerecha);
                            //YPossibleMoves.Add(y1);
                            if (x2 == paraDerecha && y2 == y1)
                            {
                                return true;
                            }
                            paraDerecha++;
                        }
                        return false;
                    }
                default:
                    return false;
            }
        }
    }
}
