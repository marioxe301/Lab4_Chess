using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Chess.Core.Interfaces;

namespace Chess.Infrastructure.JsonManipulation
{
    public class JsonSource : IJsonSource
    {
        public string GetMovementsFromSource()
        {
            return File.ReadAllText("policy.json");
        }
    }
}
