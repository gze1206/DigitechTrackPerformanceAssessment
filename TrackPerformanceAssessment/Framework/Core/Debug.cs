using System;
using System.Drawing;

namespace TPA.Framework.Core
{
    public enum LogLevel
    {
        All, Log, Warning, Error, None
    }

    public static class Debug
    {
        public static LogLevel displayLevel
        {
            get => LogLevel.All;
        }
        private static Color GetColor(LogLevel level)
        {
            if (level == LogLevel.Warning) return Color.Yellow;
            if (level == LogLevel.Error) return Color.Red;
            return Color.White;
        }

        private static void Write(LogLevel level, string message)
        {
            if (displayLevel >= level) return;

            var console = DevConsole.Get.console;
            var color = console.SelectionColor;

            console.SelectionStart = console.TextLength;
            console.SelectionColor = GetColor(level);
            console.AppendText($"{level} : {message}");
            console.AppendText(Environment.NewLine);
            console.SelectionStart = console.TextLength;
            console.SelectionColor = color;
            console.ScrollToCaret();
        }
        
        public static void Log(object msg) => Write(LogLevel.Log, (msg ?? "null").ToString());
        public static void Warning(object msg) => Write(LogLevel.Warning, (msg ?? "null").ToString());
        public static void Error(object msg) => Write(LogLevel.Error, (msg ?? "null").ToString());

        public static void LogFormat(string format, params object[] args) => Write(LogLevel.Log, string.Format(format, args));
        public static void WarningFormat(string format, params object[] args) => Write(LogLevel.Warning, string.Format(format, args));
        public static void ErrorFormat(string format, params object[] args) => Write(LogLevel.Error, string.Format(format, args));

        public static void Exception(Exception.GameException e) => Write(e.logLevel, $"{e.Message}\n\t: {(string.IsNullOrEmpty(e.StackTrace) ? "can't trace call stack" : e.StackTrace)}\n");
    }
}
