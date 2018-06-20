using System;
using System.Collections.Generic;
using System.Text;

namespace TPA.Framework.Core.Exception
{
    [Serializable]
    public class GameException : System.Exception
    {
        public GameException() : base("ERROR!") { }
        public GameException(string message) : base(message) { }
    }

    [Serializable]
    public class GameInitializeException : System.Exception
    {
        public GameInitializeException() : base("Error on initialize the game") { }
    }
}
