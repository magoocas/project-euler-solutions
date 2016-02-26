using System;
using System.Diagnostics;

namespace csharp.Utility
{
    public static class Time
    {
        public static void This(Action action, string message = "")
        {
            var sw = new Stopwatch();
            sw.Start();
            action();
            sw.Stop();

            Console.WriteLine($"{message}{sw.ElapsedMilliseconds}ms");
        }

    }
}
