using System;
using System.Collections.Generic;
using System.Text;

namespace TPA.Framework.Core.Exception
{
    [Serializable]
    public class GameException : System.Exception
    {
        public GameException(LogLevel level = LogLevel.Error) : base("ERROR!") { logLevel = level; }
        public GameException(string message, LogLevel level = LogLevel.Error) : base(message) { logLevel = level; }

        public LogLevel logLevel;
    }

    [Serializable]
    public class GameInitializeException : GameException
    {
        public GameInitializeException() : base("Error on initialize the game") { }
    }
}
