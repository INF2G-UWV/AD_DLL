using System;
using System.Threading;
using DLL_Test.Chapters.Chapter_10;
using DLL_Test.Chapters.Chapter_11;
using DLL_Test.Chapters.Chapter_12;
using DLL_Test.Chapters.Chapter_2;
using DLL_Test.Chapters.Chapter_3;
using DLL_Test.Chapters.Chapter_4;
using DLL_Test.Chapters.Chapter_5;
using DLL_Test.Chapters.Chapter_7;

namespace DLL_Test
{
    /// <summary>
    ///     Main Test Suite application for the demonstration
    ///     of the various algorithms included in the DLL.
    ///     Author: INF2G
    /// </summary>
    internal class TestSuite
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        public TestSuite()
        {
            Console.Title = "Algorithms and Datastructures Showcase - By INF2G";
            Intro();
            MainMenu();
        }

        #region Intro

        /// <summary>
        ///     ASCII intro
        /// </summary>
        private static void Intro()
        {
            //Change colors
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            //ASCII text
            const string ADTEXT =
                "              _                  _ _   _                                   \r\n        /\\   | |                (_) | | |                     ___          \r\n       /  \\  | | __ _  ___  _ __ _| |_| |__  _ __ ___  ___   ( _ )         \r\n      / /\\ \\ | |/ _` |/ _ \\| '__| | __| '_ \\| '_ ` _ \\/ __|  / _ \\/\\       \r\n     / ____ \\| | (_| | (_) | |  | | |_| | | | | | | | \\__ \\ | (_>  <       \r\n    /_/    \\_\\_|\\__, |\\___/|_|  |_|\\__|_| |_|_| |_| |_|___/  \\___/\\/       \r\n                 __/ |                                                     \r\n     _____      |___/          _                   _                       \r\n    |  __ \\      | |          | |                 | |                      \r\n    | |  | | __ _| |_ __ _ ___| |_ _ __ _   _  ___| |_ _   _ _ __ ___  ___ \r\n    | |  | |/ _` | __/ _` / __| __| '__| | | |/ __| __| | | | '__/ _ \\/ __|\r\n    | |__| | (_| | || (_| \\__ \\ |_| |  | |_| | (__| |_| |_| | | |  __/\\__ \\\r\n    |_____/ \\__,_|\\__\\__,_|___/\\__|_|   \\__,_|\\___|\\__|\\__,_|_|  \\___||___/\r\n                                                                           \r\n                                                                           ";
            const string INF2GTEXT =
                "                    \u2588\u2588\u2557\u2588\u2588\u2588\u2557   \u2588\u2588\u2557\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2557\u2588\u2588\u2588\u2588\u2588\u2588\u2557  \u2588\u2588\u2588\u2588\u2588\u2588\u2557 \r\n                    \u2588\u2588\u2551\u2588\u2588\u2588\u2588\u2557  \u2588\u2588\u2551\u2588\u2588\u2554\u2550\u2550\u2550\u2550\u255D\u255A\u2550\u2550\u2550\u2550\u2588\u2588\u2557\u2588\u2588\u2554\u2550\u2550\u2550\u2550\u255D \r\n                    \u2588\u2588\u2551\u2588\u2588\u2554\u2588\u2588\u2557 \u2588\u2588\u2551\u2588\u2588\u2588\u2588\u2588\u2557   \u2588\u2588\u2588\u2588\u2588\u2554\u255D\u2588\u2588\u2551  \u2588\u2588\u2588\u2557\r\n                    \u2588\u2588\u2551\u2588\u2588\u2551\u255A\u2588\u2588\u2557\u2588\u2588\u2551\u2588\u2588\u2554\u2550\u2550\u255D  \u2588\u2588\u2554\u2550\u2550\u2550\u255D \u2588\u2588\u2551   \u2588\u2588\u2551\r\n                    \u2588\u2588\u2551\u2588\u2588\u2551 \u255A\u2588\u2588\u2588\u2588\u2551\u2588\u2588\u2551     \u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2557\u255A\u2588\u2588\u2588\u2588\u2588\u2588\u2554\u255D\r\n                    \u255A\u2550\u255D\u255A\u2550\u255D  \u255A\u2550\u2550\u2550\u255D\u255A\u2550\u255D     \u255A\u2550\u2550\u2550\u2550\u2550\u2550\u255D \u255A\u2550\u2550\u2550\u2550\u2550\u255D \r\n                                                          ";
            //Write text using CharWriter
            CharWriter(ADTEXT.ToCharArray(), 10);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            CharWriter(INF2GTEXT.ToCharArray(), 10);
            //Wait
            Thread.Sleep(2000);
        }

        #endregion

        #region MainMenu

        /// <summary>
        ///     Main menu
        /// </summary>
        private static void MainMenu()
        {
            //Change colors
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
            //Print menu
            Console.Clear();
            Console.WriteLine("************************");
            Console.WriteLine("****AD Testing Suite****");
            Console.WriteLine("************************");
            Console.WriteLine("(1) Hashing tests");
            Console.WriteLine("(2) List tests");
            Console.WriteLine("(3) Queue tests");
            Console.WriteLine("(4) Binary tests");
            Console.WriteLine("(5) Sorting test");
            Console.WriteLine("(6) Stack test");
            Console.WriteLine("(7) Timer test using strings");
            Console.WriteLine("(X) Exit");
            //Read input
            var input = Console.ReadKey(true);
            if (input.Key.Equals(ConsoleKey.D1))
            {
                //Hashing tests
                HashingTestMenu();
            }
            else if (input.Key.Equals(ConsoleKey.D2))
            {
                //List tests
                ListTestMenu();
            }
            else if (input.Key.Equals(ConsoleKey.D3))
            {
                //Queue tests
                QueueTestMenu();
            }
            else if (input.Key.Equals(ConsoleKey.D4))
            {
                //Binary tests
                BinaryTestMenu();
            }
            else if (input.Key.Equals(ConsoleKey.D5))
            {
                //Various sort algorithms
                Sort.Run();
                MainMenu();
            }
            else if (input.Key.Equals(ConsoleKey.D6))
            {
                //Stack test
                StackTest.Run();
                MainMenu();
            }
            else if (input.Key.Equals(ConsoleKey.D7))
            {
                //String timing test
                var timingTest = new StringTimingTest();
                timingTest.Run();
                MainMenu();
            }
            else if (input.Key.Equals(ConsoleKey.X) || input.Key.Equals(ConsoleKey.Backspace) ||
                     input.Key.Equals(ConsoleKey.Escape))
            {
                //Exit
                CheckExit();
            }
            else
            {
                //Loop
                MainMenu();
            }
        }

        #endregion

        #region HashingTestMenu

        /// <summary>
        ///     Hashing test menu
        /// </summary>
        private static void HashingTestMenu()
        {
            Console.Clear();
            Console.WriteLine("*********************");
            Console.WriteLine("****Hashing Tests****");
            Console.WriteLine("*********************");
            Console.WriteLine("(1) Bucket Hash");
            Console.WriteLine("(2) Linear Hash");
            Console.WriteLine("(3) Quadratic Hash");
            Console.WriteLine("(X) Back");
            var input = Console.ReadKey(true);
            if (input.Key.Equals(ConsoleKey.D1))
            {
                BucketHashTest.Run();
            }
            else if (input.Key.Equals(ConsoleKey.D2))
            {
                LinearHashTest.Run();
            }
            else if (input.Key.Equals(ConsoleKey.D3))
            {
                QuadraticHashTest.Run();
            }
            else if (input.Key.Equals(ConsoleKey.X) || input.Key.Equals(ConsoleKey.Backspace))
            {
                MainMenu();
            }
            else
            {
                HashingTestMenu();
            }
            HashingTestMenu();
        }

        #endregion

        #region ListTestMenu

        /// <summary>
        ///     List test menu
        /// </summary>
        private static void ListTestMenu()
        {
            Console.Clear();
            Console.WriteLine("*******************");
            Console.WriteLine("****Lists Tests****");
            Console.WriteLine("*******************");
            Console.WriteLine("(1) Single Linked List");
            Console.WriteLine("(2) Double Linked List");
            Console.WriteLine("(3) Circular List");
            Console.WriteLine("(4) ArrayList");
            Console.WriteLine("(5) Iterator");
            Console.WriteLine("(X) Back");
            var input = Console.ReadKey(true);
            if (input.Key.Equals(ConsoleKey.D1))
            {
                ExampleSingleLinkedList.Run();
            }
            else if (input.Key.Equals(ConsoleKey.D2))
            {
                ExampleDoubleLinkedList.Run();
            }
            else if (input.Key.Equals(ConsoleKey.D3))
            {
                ExampleCircularList.Run();
            }
            else if (input.Key.Equals(ConsoleKey.D4))
            {
                ArrayListTest<string>.Run();
            }
            else if (input.Key.Equals(ConsoleKey.D5))
            {
                IteratorTest<int>.Run();
            }
            else if (input.Key.Equals(ConsoleKey.X) || input.Key.Equals(ConsoleKey.Backspace))
            {
                MainMenu();
            }
            else
            {
                ListTestMenu();
            }
            ListTestMenu();
        }

        #endregion

        #region QueueTestMenu

        /// <summary>
        ///     Queue Test Menu
        /// </summary>
        private static void QueueTestMenu()
        {
            Console.Clear();
            Console.WriteLine("*******************");
            Console.WriteLine("****Queue Tests****");
            Console.WriteLine("*******************");
            Console.WriteLine("(1) Normal Queue - UI");
            Console.WriteLine("(2) Priority Queue - UI");
            Console.WriteLine("(3) Normal Queue - Timing");
            Console.WriteLine("(4) Priority Queue - Timing");
            Console.WriteLine("(X) Back");
            var input = Console.ReadKey(true);
            if (input.Key.Equals(ConsoleKey.D1))
            {
                NQueueTest.Run(2);
            }
            else if (input.Key.Equals(ConsoleKey.D2))
            {
                PQueueTest.Run(2);
            }
            else if (input.Key.Equals(ConsoleKey.D3))
            {
                NQueueTest.Run(1);
            }
            else if (input.Key.Equals(ConsoleKey.D4))
            {
                PQueueTest.Run(1);
            }
            else if (input.Key.Equals(ConsoleKey.X) || input.Key.Equals(ConsoleKey.Backspace))
            {
                MainMenu();
            }
            else
            {
                QueueTestMenu();
            }
            QueueTestMenu();
        }

        #endregion

        #region BinaryTestMenu

        /// <summary>
        ///     Binary test menu
        /// </summary>
        private static void BinaryTestMenu()
        {
            Console.Clear();
            Console.WriteLine("********************");
            Console.WriteLine("****Binary Tests****");
            Console.WriteLine("********************");
            Console.WriteLine("(1) Binary Search");
            Console.WriteLine("(2) Binary Search Tree");
            Console.WriteLine("(3) Min Max");
            Console.WriteLine("(X) Back");
            var input = Console.ReadKey(true);
            if (input.Key.Equals(ConsoleKey.D1))
            {
                BinarySearch.Run();
            }
            else if (input.Key.Equals(ConsoleKey.D2))
            {
                BstTest.Run();
            }
            else if (input.Key.Equals(ConsoleKey.D3))
            {
                MinMax.Run();
            }
            else if (input.Key.Equals(ConsoleKey.X) || input.Key.Equals(ConsoleKey.Backspace))
            {
                MainMenu();
            }
            else
            {
                BinaryTestMenu();
            }
            BinaryTestMenu();
        }

        #endregion

        #region CheckExit

        /// <summary>
        ///     Check if user really wants to exit
        /// </summary>
        private static void CheckExit()
        {
            Console.WriteLine("\nAre you sure? (y/n)");
            var input = Console.ReadKey(true);
            if (input.Key.Equals(ConsoleKey.Y))
            {
                //Exit
                Environment.Exit(0);
            }
            else if (input.Key.Equals(ConsoleKey.N))
            {
                //Go back to main menu
                MainMenu();
            }
            else
            {
                Console.WriteLine("Invalid input!");
                CheckExit();
            }
        }

        #endregion

        #region CharWriter

        /// <summary>
        ///     CharWriter.
        ///     Writes an array of chars with delay effect.
        /// </summary>
        /// <param name="input">Chararray</param>
        /// <param name="timing">Timing in ms</param>
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

        #endregion
    }
}