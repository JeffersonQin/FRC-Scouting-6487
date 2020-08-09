using System;
using System.Collections.Generic;
using System.Text;

namespace FRC_Scouting_6487.Lib
{
    public static class ConsoleLog
    {
        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("EROR");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("]: " + message);
        }

        public static void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("INFO");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("]: " + message);
        }

        public static void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("LOGG");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("]: " + message);
        }

        public static void Warning(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("WARN");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("]: " + message);
        }

        public static void Succeed(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("SUCC");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("]: " + message);
        }
        public static void Note(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("NOTE");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("]: " + message);
        }

        public static void LogException(Exception e, string message)
        {
            ConsoleLog.Error("**************************************");
            ConsoleLog.Error(message);
            ConsoleLog.Error("Detailed Information: ");
            ConsoleLog.Error("Error Message: " + e.Message);
            ConsoleLog.Error("Error Stack Trace: \n" + e.StackTrace);
            ConsoleLog.Error("Error Source Method: " + e.Source);
            ConsoleLog.Error("Error Code: " + e.HResult);
            ConsoleLog.Error("Error Help Link: " + e.HelpLink);
            ConsoleLog.Error("**************************************");
        }
    }
}
