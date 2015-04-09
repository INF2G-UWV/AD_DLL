using System;
using DLL;

namespace DLL_Test.Chapters.Chapter_5
{
    /// <summary>
    ///     PQueue Test
    ///     Author: Selami Çetingüney - INF2G
    /// </summary>
    internal class PQueueTest
    {
        private static PQueue<string> rndWords;

        /// <summary>
        ///     Main Execution.
        /// </summary>
        /// <param name="args">Int - 1 = Timer, 2 = UI </param>
        public static void Run(int test)
        {
            // Create a Generic Queue
            rndWords = new PQueue<string>();
            if (test == 1)
            {
                PQueueTestTimer();
            }

            if (test == 2)
            {
                PQueueTestUI();
            }
        }

        #region

        /// <summary>
        ///     Priority Queue Test UI.
        ///     Test with UI and no time measurements.
        /// </summary>
        public static void PQueueTestUI()
        {
            // Two variables which choice stores the command pressed, and value typed in the input;
            string choice, value1;
            int value2;

            // Commands that are available;
            Console.WriteLine("\nCommands to follow!");
            Console.WriteLine("(1) Enqueue");
            Console.WriteLine("(2) Dequeue Highest Priority");
            Console.WriteLine("(3) Peek");
            Console.WriteLine("(4) Contains");
            Console.WriteLine("(5) Print Queue list");
            Console.WriteLine("(6) Clear");
            Console.WriteLine("(7) Exit");

            // While the console applications runs, the commands can be executed;
            var runProgram = true;
            while (runProgram)
            {
                Console.Write("\nSelect command: ");
                choice = Console.ReadLine();
                if (choice != null)
                {
                    choice = choice.ToLower();
                    if (choice == "1") // If pressed 1, add item to the Queue;
                    {
                        Console.WriteLine();
                        Console.Write("Enter item to Enqeue: ");
                        value1 = Console.ReadLine();
                        Console.Write("Enter the Priority: ");

                        if (int.TryParse(Console.ReadLine(), out value2))
                        {
                            rndWords.Enqueue(value1, value2);
                            Console.WriteLine();
                            Console.WriteLine("Item {0} with priority {1} added to the queue.", value1, value2);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }
                    }
                    else if (choice == "2") // If pressed 2, delete first Highest Priority in the Queue;
                    {
                        Console.WriteLine();
                        Console.Write("{0}", rndWords.Dequeue());
                        Console.WriteLine();
                    }
                    else if (choice == "3") // If pressed 3, peek at the first item in the Queue;
                    {
                        Console.WriteLine();
                        Console.Write("{0}", rndWords.Peek());
                        Console.WriteLine();
                    }
                    else if (choice == "4") // If pressed 4, check if the item Contains in the list;
                    {
                        Console.WriteLine();
                        Console.Write("Enter item to check if it Contains in the List: ");
                        value1 = Console.ReadLine();
                        rndWords.Contains(value1);
                        Console.WriteLine();
                    }
                    else if (choice == "5") // If pressed 5, display all the items in the Queue;
                    {
                        Console.WriteLine();
                        rndWords.GetAllQueueItems();
                        Console.WriteLine();
                    }
                    else if (choice == "6") // If pressed 6, clear the Queue list;
                    {
                        Console.WriteLine();
                        rndWords.Clear();
                        Console.WriteLine();
                    }
                    else if (choice == "7")
                    {
                        runProgram = false; // If pressed 7, close the Program;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.Write("Unknown command");
                        Console.WriteLine();
                    }
                    Console.ReadKey();
                    Console.Clear();
                    PQueueTestUI();
                }
            }
        }

        #endregion

        #region

        /// <summary>
        ///     Priority Queue Test Timer.
        ///     Test without UI, but with time measurements.
        /// </summary>
        public static void PQueueTestTimer()
        {
            // Create a Generic Queue and Timer;
            var priorQueue = new PQueue<string>();
            var timer = new HighResolutionTimer(true);

            // Timer start
            timer.Start();

            // Patiënt and their priority;
            const string patiënt1 = "Patiënt1";
            const string patiënt2 = "Patiënt2";
            const string patiënt3 = "Patiënt3";
            const string patiënt4 = "Patiënt4";
            const int priority1 = 11;
            const int priority2 = 5;
            const int priority3 = 7;
            const int priority4 = 1;

            Console.WriteLine("\nAdding " + patiënt1 + " with Priority (" + priority1 + ")");
            Console.WriteLine("Adding " + patiënt2 + " with Priority (" + priority2 + ")");
            Console.WriteLine("Adding " + patiënt3 + " with Priority (" + priority3 + ")");
            Console.WriteLine("Adding " + patiënt4 + " with Priority (" + priority4 + ")");
            priorQueue.Enqueue(patiënt1, priority1);
            priorQueue.Enqueue(patiënt2, priority2);
            priorQueue.Enqueue(patiënt3, priority3);
            priorQueue.Enqueue(patiënt4, priority4);

            Console.WriteLine();
            // Print the total Queue's in the list
            priorQueue.GetAllQueueItems();
            Console.WriteLine();

            Console.WriteLine();
            //DeQueue's the first one in the list;
            Console.WriteLine("{0}", priorQueue.Dequeue());

            //Looks at the next item in line after the one that has been Dequeued;
            Console.WriteLine("{0}", priorQueue.Peek());

            //DeQueue's the first one in the list;
            Console.WriteLine("{0}", priorQueue.Dequeue());

            //Looks at the next item in line after the one that has been Dequeued;
            Console.WriteLine("{0}", priorQueue.Peek());

            //DeQueue's the first one in the list;
            Console.WriteLine("{0}", priorQueue.Dequeue());

            //Looks at the next item in line after the one that has been Dequeued;
            Console.WriteLine("{0}", priorQueue.Peek());

            Console.WriteLine();
            // Print the total Queue's in the list;
            priorQueue.GetAllQueueItems();

            // Check for if the items are still in the Queue or not;
            Console.WriteLine("\n\nCheck for Patiënt1 in the list: ");
            priorQueue.Contains(patiënt1);
            Console.WriteLine("\n\nCheck for Patiënt3 in the list: ");
            priorQueue.Contains(patiënt3);

            // End timer + results;
            timer.Stop();
            Console.WriteLine("\n\nTime needed for Queue: " + timer.Duration(TimeResolution.Seconds));

            // Clears the whole Queue;
            priorQueue.Clear();

            // Remaing Queue in the list;
            priorQueue.Count();

            Console.ReadLine();
        }

        #endregion
    }
}