using System;
using DLL;

namespace DLL_Test.Chapters.Chapter_5
{
    /// <summary>
    ///     NQueue Test
    ///     Author: Selami Çetingüney - INF2G
    /// </summary>
    internal class NQueueTest
    {
        private static NQueue<string> rndWords;

        /// <summary>
        ///     Main execution.
        /// </summary>
        /// <param name="args"></param>
        public static void Run(int test)
        {
            // Create a Generic Queue
            rndWords = new NQueue<string>();

            if (test == 1)
            {
                //With time measurement, without UI.
                QueueTestTimer();
            }

            if (test == 2)
            {
                //Without time measurement, with UI.
                QueueTestUI();
            }
        }

        #region

        /// <summary>
        ///     Normal Queue Test 2.
        ///     Has a user interface so that the various features can be tested individually.
        /// </summary>
        private static void QueueTestUI()
        {
            // Two variables which choice stores the command pressed, and value typed in the input;
            string value;
            Console.Clear();

            // Commands that are available;
            Console.WriteLine("*************************");
            Console.WriteLine("****Normal Queue Test****");
            Console.WriteLine("*************************");
            Console.WriteLine("(1) Enqueue");
            Console.WriteLine("(2) Dequeue");
            Console.WriteLine("(3) Peek");
            Console.WriteLine("(4) Contains");
            Console.WriteLine("(5) Print Queue list");
            Console.WriteLine("(6) Clear");
            Console.WriteLine("(X) Exit");

            // While the console applications runs, the commands can be executed;
            var runProgram = true;

            Console.Write("\nSelect command: ");
            var input = Console.ReadKey(true);

            if (input.Key.Equals(ConsoleKey.D1)) // If pressed 1, add item to the Queue;
            {
                Console.WriteLine();
                Console.Write("Enter item to Enqeue: ");
                value = Console.ReadLine();
                rndWords.Enqueue(value);
                Console.WriteLine();
                Console.WriteLine("Item {0} added to the queue.", value);
            }
            else if (input.Key.Equals(ConsoleKey.D2)) // If pressed 2, delete first item in the Queue;
            {
                Console.WriteLine();
                Console.Write("{0}", rndWords.Dequeue());
                Console.WriteLine();
            }
            else if (input.Key.Equals(ConsoleKey.D3)) // If pressed 3, peek at the first item in the Queue;
            {
                Console.WriteLine();
                Console.Write("{0}", rndWords.Peek());
                Console.WriteLine();
            }
            else if (input.Key.Equals(ConsoleKey.D4)) // If pressed 4, check if the item Contains in the list;
            {
                Console.WriteLine();
                Console.Write("Enter item to check if it Contains in the List: ");
                value = Console.ReadLine();
                rndWords.Contains(value);
                Console.WriteLine();
            }
            else if (input.Key.Equals(ConsoleKey.D5)) // If pressed 5, display all the items in the Queue;
            {
                Console.WriteLine();
                rndWords.GetAllQueueItems();
                Console.WriteLine();
            }
            else if (input.Key.Equals(ConsoleKey.D6)) // If pressed 6, clear the Queue list;
            {
                Console.WriteLine();
                rndWords.Clear();
                Console.WriteLine();
            }
            else if (input.Key.Equals(ConsoleKey.X) || input.Key.Equals(ConsoleKey.Backspace))
            {
                runProgram = false; // If pressed 7, close the Program;
            }
            else
            {
                Console.WriteLine();
                Console.Write("Unknown command");
                Console.WriteLine();
            }
            if (runProgram)
            {
                Console.ReadKey();
                Console.Clear();
                QueueTestUI();
            }
        }

        #endregion

        #region

        /// <summary>
        ///     Normal Queue Test 1.
        ///     Testing NQueue functionality with timer.
        /// </summary>
        private static void QueueTestTimer()
        {
            // Create a Generic Queue and Timer;
            var rndWords = new NQueue<int>();
            var timer = new HighResolutionTimer(true);

            // Timer start;
            timer.Start();

            // Vars to add in the Queue;
            int one = 1, three = 3, four = 4, five = 5, two = 2;

            Console.WriteLine("Adding " + one + ", " + three + ", " + four + ", " + five + ", " + two + " to the queue");
            rndWords.Enqueue(one);
            rndWords.Enqueue(three);
            rndWords.Enqueue(four);
            rndWords.Enqueue(five);
            rndWords.Enqueue(two);

            Console.WriteLine();
            // Print the total Queue's in the list;
            rndWords.GetAllQueueItems();

            Console.WriteLine("\n");
            //DeQueue's the first one in the list;
            Console.WriteLine("{0}", rndWords.Dequeue());

            //Looks at the next item in line after the one that has been Dequeued;
            Console.WriteLine("{0}", rndWords.Peek());

            //DeQueue's the first one in the list;
            Console.WriteLine("{0}", rndWords.Dequeue());

            //Looks at the next item in line after the one that has been Dequeued;
            Console.WriteLine("{0}", rndWords.Peek());

            //DeQueue's the first one in the list;
            Console.WriteLine("{0}", rndWords.Dequeue());

            Console.WriteLine();
            // Print the total Queue's in the list;
            rndWords.GetAllQueueItems();

            // Check for if the items are still in the Queue or not;
            Console.WriteLine("\n\nCheck for 4 in the list: ");
            rndWords.Contains(four);
            Console.WriteLine("\n\nCheck for 5 in the list: ");
            rndWords.Contains(five);
            Console.WriteLine("\n\nCheck for 2 in the list: ");
            rndWords.Contains(two);

            // End timer + results
            timer.Stop();
            Console.WriteLine("\n\nTime needed for Queue: " + timer.Duration(TimeResolution.Seconds));

            // Clears the whole Queue;
            rndWords.Clear();

            // Remaing Queue in the list;
            rndWords.Count();

            Console.ReadLine();
        }

        #endregion
    }
}