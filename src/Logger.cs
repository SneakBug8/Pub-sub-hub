using System;

public class Logger {
    public static void Log(string message) {
        Logger.Log(DateTime.Now.ToString() + ": " + message);
    }
}