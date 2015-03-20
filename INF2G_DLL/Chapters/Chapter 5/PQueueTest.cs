using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL;

namespace INF2G_DLL.Chapters.Chapter_5
{
    internal class PQueueTest
    {
        public static void Run(string[] args)
        {
            PQueueTest1();
        }

        public static void PQueueTest1()
        {
            // Create a Generic Queue and Timer;
            PQueue<string> priorQueue = new PQueue<string>();
            HighResolutionTimer timer = new HighResolutionTimer(true);

            // Timer start
            timer.Start();

            // Patiënt and their priority;
            string patiënt1 = "Selami", patiënt2 = "Cetinguney", patiënt3 = "TestPerson1", patiënt4 = "TestPerson2";
            string priority1 = "5", priority2 = "1", priority3 = "7", priority4 = "1";

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
            Console.WriteLine("\n\nCheck for number Patiënt2 in the list: ");
            priorQueue.Contains(patiënt2);
            Console.WriteLine("\n\nCheck for number Patiënt3 in the list: ");
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
    }
}
