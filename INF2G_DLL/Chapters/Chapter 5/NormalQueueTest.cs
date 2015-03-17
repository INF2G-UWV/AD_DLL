﻿using System;
using System.Collections;
using System.Linq;
using DLL;

namespace INF2G_DLL.Chapters.Chapter_5
{
    internal class NormalQueueTest
    {
        public static void Run(string[] args)
        {
            QueueTest2();
        }

        public static void QueueTest2()
        {
            // Create a Generic Queue and Timer
            NormalQueue<string> rndWords = new NormalQueue<string>();
            HighResolutionTimer timer = new HighResolutionTimer(true);

            string choice, value1;
            
            Console.WriteLine("\nCommand to follow!");
            Console.WriteLine("(1) Enqueue");
            Console.WriteLine("(2) Dequeue");
            Console.WriteLine("(3) Peek");
            Console.WriteLine("(4) Contains");
            Console.WriteLine("(5) Print Queue list");
            Console.WriteLine("(6) Clear");

            while (true)
            {
                Console.Write("\nSelect command: ");
                choice = Console.ReadLine();
                choice = choice.ToLower();

                if (choice == "1")
                {
                    Console.WriteLine();
                    Console.Write("Enter item to Enqeue: ");
                    value1 = Console.ReadLine();
                    rndWords.EnqueueT(value1);
                }
                else if (choice == "2")
                {
                    if (!(rndWords.IsEmpty))
                    {
                        Console.WriteLine();
                        Console.Write("Dequeueing the first item in the Queue: '{0}'", rndWords.Dequeue());
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("There is no item to Dequeue");
                    }
                }
                else if (choice == "3")
                {
                    if (!(rndWords.IsEmpty))
                    {
                        Console.WriteLine();
                        Console.Write("Peek at the first item in the Queue: '{0}'", rndWords.Peek());
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("\nThere is no item to Peek at");
                    }
                }
                else if (choice == "4")
                {
                    if (!(rndWords.IsEmpty))
                    {
                        Console.WriteLine();
                        Console.Write("Enter item to check if it Contains in the List: ");
                        value1 = Console.ReadLine();
                        Console.Write(rndWords.Contains(value1)
                            ? "Item is found in the index"
                            : "Item is not found in the index");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("\nThere is no item to check for");
                    }
                }
                else if (choice == "5")
                {
                    Console.WriteLine();
                    Console.Write("Items in the Queue: " + rndWords.Count() + " item(s)");
                    Console.WriteLine();
                }
                else if (choice == "6")
                {
                    Console.WriteLine();
                    Console.Write("The Queue list has been cleared! ");
                    rndWords.Clear();
                    Console.Write(rndWords.Count() + " item(s) remain in the list");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.Write("Unknown command");
                }
            }
        }

        #region
        public static void QueueTest()
        {
            // Create a Generic Queue and Timer
            System.Collections.Generic.Queue<int> rndWords = new System.Collections.Generic.Queue<int>();
            HighResolutionTimer timer = new HighResolutionTimer(true);

            // Timer start
            timer.Start();

            // Vars to add in the Queue
            int one = 1, three = 3, four = 4, five = 5, two = 2;

            Console.WriteLine("Starting Queue:");
            Console.WriteLine("Adding " + one + ", " + three + ", " + four + ", " + five + ", " + two + " to the queue");
            rndWords.Enqueue(one);
            rndWords.Enqueue(three);
            rndWords.Enqueue(four);
            rndWords.Enqueue(five);
            rndWords.Enqueue(two);

            // Print the total Queue's in the list
            PrintValues(rndWords);

            //DeQueue's the first one in the list;
            Console.WriteLine("\n\nDequeuing '{0}'", rndWords.Dequeue());

            //Looks at the next item in line after the one that has been Dequeued;
            Console.WriteLine("Peek at next item to Dequeue: {0}", rndWords.Peek());

            //DeQueue's the first one in the list;
            Console.WriteLine("Dequeuing '{0}'", rndWords.Dequeue());

            //Looks at the next item in line after the one that has been Dequeued;
            Console.WriteLine("Peek at next item to Dequeue: {0}", rndWords.Peek());

            //DeQueue's the first one in the list;
            Console.WriteLine("Dequeuing '{0}'", rndWords.Dequeue());

            // Print the total Queue's in the list
            PrintValues(rndWords);
            Console.WriteLine();

            // Check for if the items are still in the Queue are not
            Console.WriteLine("\nCheck for number 4 in the list: " + rndWords.Contains(four));
            Console.WriteLine("Check for number 5 in the list: " + rndWords.Contains(five));
            Console.WriteLine("Check for number 2 in the list: " + rndWords.Contains(two));

            // End timer + results
            timer.Stop();
            Console.WriteLine("\nTime needed for Queue: " + timer.Duration(TimeResolution.Seconds));

            // Clear the whole Queue
            Console.WriteLine("Clearing the Queue list!");
            rndWords.Clear();

            Console.WriteLine("Total Queue's left in the list: " + rndWords.Count() + " item");

            Console.ReadLine();
        }

        public static void PrintValues(IEnumerable rndWords)
        {
            Console.WriteLine("\nItems in the Queue!");
            foreach (object rndWord in rndWords)
            {
                Console.Write(rndWord + ", ");
            }
        }
        #endregion
    }
}