using System;
using Chess.Core.Interfaces;

namespace Chess.Infrastructure.XYConverter
{
    public class XYConverter : IXYConverter
    {
        public int CharToCoordinate(char c)
        {
            switch (c)
            {
                case 'a':
                    return 0;
                case 'b':
                    return 1;
                case 'c':
                    return 2;
                case 'd':
                    return 3;
                case 'e':
                    return 4;
                case 'f':
                    return 5;
                case 'g':
                    return 6;
                case 'h':
                    return 7;
                case '8':
                    return 0;
                case '7':
                    return 1;
                case '6':
                    return 2;
                case '5':
                    return 3;
                case '4':
                    return 4;
                case '3':
                    return 5;
                case '2':
                    return 6;
                case '1':
                    return 7;
                default:
                    return -1;
            }
        }
    }
}
