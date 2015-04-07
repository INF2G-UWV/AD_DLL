using System;
using System.Threading;

namespace DLL_Test
{
    internal class TestSuite
    {
        public TestSuite()
        {
            Intro();
        }

        private static void Intro()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            const string adtext =
                "              _                  _ _   _                                   \r\n        /\\   | |                (_) | | |                     ___          \r\n       /  \\  | | __ _  ___  _ __ _| |_| |__  _ __ ___  ___   ( _ )         \r\n      / /\\ \\ | |/ _` |/ _ \\| '__| | __| '_ \\| '_ ` _ \\/ __|  / _ \\/\\       \r\n     / ____ \\| | (_| | (_) | |  | | |_| | | | | | | | \\__ \\ | (_>  <       \r\n    /_/    \\_\\_|\\__, |\\___/|_|  |_|\\__|_| |_|_| |_| |_|___/  \\___/\\/       \r\n                 __/ |                                                     \r\n     _____      |___/          _                   _                       \r\n    |  __ \\      | |          | |                 | |                      \r\n    | |  | | __ _| |_ __ _ ___| |_ _ __ _   _  ___| |_ _   _ _ __ ___  ___ \r\n    | |  | |/ _` | __/ _` / __| __| '__| | | |/ __| __| | | | '__/ _ \\/ __|\r\n    | |__| | (_| | || (_| \\__ \\ |_| |  | |_| | (__| |_| |_| | | |  __/\\__ \\\r\n    |_____/ \\__,_|\\__\\__,_|___/\\__|_|   \\__,_|\\___|\\__|\\__,_|_|  \\___||___/\r\n                                                                           \r\n                                                                           ";
            const string inf2gtext =
                "                    \u2588\u2588\u2557\u2588\u2588\u2588\u2557   \u2588\u2588\u2557\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2557\u2588\u2588\u2588\u2588\u2588\u2588\u2557  \u2588\u2588\u2588\u2588\u2588\u2588\u2557 \r\n                    \u2588\u2588\u2551\u2588\u2588\u2588\u2588\u2557  \u2588\u2588\u2551\u2588\u2588\u2554\u2550\u2550\u2550\u2550\u255D\u255A\u2550\u2550\u2550\u2550\u2588\u2588\u2557\u2588\u2588\u2554\u2550\u2550\u2550\u2550\u255D \r\n                    \u2588\u2588\u2551\u2588\u2588\u2554\u2588\u2588\u2557 \u2588\u2588\u2551\u2588\u2588\u2588\u2588\u2588\u2557   \u2588\u2588\u2588\u2588\u2588\u2554\u255D\u2588\u2588\u2551  \u2588\u2588\u2588\u2557\r\n                    \u2588\u2588\u2551\u2588\u2588\u2551\u255A\u2588\u2588\u2557\u2588\u2588\u2551\u2588\u2588\u2554\u2550\u2550\u255D  \u2588\u2588\u2554\u2550\u2550\u2550\u255D \u2588\u2588\u2551   \u2588\u2588\u2551\r\n                    \u2588\u2588\u2551\u2588\u2588\u2551 \u255A\u2588\u2588\u2588\u2588\u2551\u2588\u2588\u2551     \u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2557\u255A\u2588\u2588\u2588\u2588\u2588\u2588\u2554\u255D\r\n                    \u255A\u2550\u255D\u255A\u2550\u255D  \u255A\u2550\u2550\u2550\u255D\u255A\u2550\u255D     \u255A\u2550\u2550\u2550\u2550\u2550\u2550\u255D \u255A\u2550\u2550\u2550\u2550\u2550\u255D \r\n                                                          ";
            CharWriter(adtext.ToCharArray(), 10);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            CharWriter(inf2gtext.ToCharArray(), 10);
            Console.ReadKey();
        }

        private static void CharWriter(char[] input, int timing)
        {
            for (var i = 0; i < input.Length; i++)
            {
                Console.Write(input[i]);
                if (i%10 == 0)
                {
                    Thread.Sleep(timing);
                }
            }
        }
    }
}