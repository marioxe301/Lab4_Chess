using System;
using System.Collections.Generic;
using System.Text;
using Chess.Core.Interfaces;
using Chess.Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Chess.Infrastructure.JsonManipulation
{
    public class JsonParser : IJsonParser
    {
        public List<ChessPiece> SerializeChessPieces(string movementsJson)
        {
            return JsonConvert.DeserializeObject<List<ChessPiece>>(movementsJson);
        }
    }
}
