using System;
using System.Linq;
using DLL;

namespace INF2G_DLL.Chapters.Chapter_5
{
    internal class Queue
    {
        public static void Run(string[] args)
        {
            // Create a Generic Queue and Timer
            System.Collections.Generic.Queue<int> rndWords = new System.Collections.Generic.Queue<int>();
            HighResolutionTimer timer = new HighResolutionTimer(true);

            // Timer start
            timer.Start();

            // Vars to add in the Queue
            int one = 1, three = 3, four = 4, five = 5, two = 2;
            
            Console.WriteLine("Starting Queue:");
            Console.WriteLine("Adding " + one + " to the que");
            rndWords.Enqueue(one);
            Console.WriteLine("Adding " + three + " to the que");
            rndWords.Enqueue(three);
            Console.WriteLine("Adding " + four + " to the que");
            rndWords.Enqueue(four);
            Console.WriteLine("Adding " + five + " to the que");
            rndWords.Enqueue(five);
            Console.WriteLine("Adding " + two + " to the que");
            rndWords.Enqueue(two);

            // Print the total Queue's in the list
            var sequence = Enumerable.Empty<int>();
            Console.WriteLine("\nQueue's in the list:");
            foreach (int rndWord in rndWords)
            {
                Console.Write(rndWord + ", ");
            }

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

            // Total items in the list
            Console.WriteLine("\nTotal Queue left in the list: " + rndWords.Count() + " item");

            // Check for if the items are still in the Queue are not
            Console.WriteLine("Check for number 4 in the list: " + rndWords.Contains(four));
            Console.WriteLine("Check for number 2 in the list: " + rndWords.Contains(two));

            // Clear the whole Queue
            Console.WriteLine("\nClearing the Queue list!");
            rndWords.Clear();

            Console.WriteLine("Total Queue's left in the list: " + rndWords.Count() + " item");

            // End timer + results
            timer.Stop();
            Console.WriteLine("Time needed for Queue: " + timer.Duration(TimeResolution.Seconds));

            Console.ReadLine();
        }
    }
}