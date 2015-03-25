using System;
using DLL;

namespace INF2G_DLL.Chapters.Chapter_5
{
    internal class NormalQueueTest
    {
        public static void Run(string[] args)
        {
            // Zonder UI, maar met tijd metingen;
            QueueTest1();

            // Zonder tijdmeetingen, met UI
            //QueueTest2();
        }

        // Zonder tijdmeetingen, met UI | Queuetest2();

        #region

        public static void QueueTest2()
        {
            // Create a Generic Queue
            var rndWords = new NormalQueue<string>();

            // Two variables which choice stores the command pressed, and value typed in the input;
            string choice, value;

            // Commands that are available;
            Console.WriteLine("\nCommands to follow!");
            Console.WriteLine("(1) Enqueue");
            Console.WriteLine("(2) Dequeue");
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
                choice = choice.ToLower();

                if (choice == "1") // If pressed 1, add item to the Queue;
                {
                    Console.WriteLine();
                    Console.Write("Enter item to Enqeue: ");
                    value = Console.ReadLine();
                    rndWords.Enqueue(value);
                }
                else if (choice == "2") // If pressed 2, delete first item in the Queue;
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
                    value = Console.ReadLine();
                    rndWords.Contains(value);
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
            }
        }

        #endregion

        // Zonder UI, maar met tijd metingen | QueueTest1();

        #region

        public static void QueueTest1()
        {
            // Create a Generic Queue and Timer;
            var rndWords = new NormalQueue<int>();
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