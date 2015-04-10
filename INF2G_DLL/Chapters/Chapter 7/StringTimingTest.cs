using System;
using System.Diagnostics;
using System.Text;
using DLL;

namespace DLL_Test.Chapters.Chapter_7
{
    /// <summary>
    ///     String timing test.
    ///     Author: Martijn Buurman - INF2G.
    /// </summary>
    internal class StringTimingTest
    {
        //Fields
        private readonly Process proc = Process.GetCurrentProcess();
        private readonly int size = 100;
        private readonly Object threadLock = new object();
        // The order of magnitude we're displaying our times in
        private readonly TimeResolution timeResolution = TimeResolution.Milliseconds;
        //Timer for the StringBuilder
        private readonly HighResolutionTimer timerSB = new HighResolutionTimer(true);
        //Timer for the string
        private readonly HighResolutionTimer timerString = new HighResolutionTimer(true);
        // Helper variables
        private double SBDuration, SDuration;
        //Fields
        private int threadCount;
        //Methods:

        /// <summary>
        ///     Main execution
        /// </summary>
        public void Run()
        {
            Console.Clear();
            WriteIntroduction();
            CPUWarmUp();
            SetAffinity();
            RunTest();
        }

        /// <summary>
        ///     Write introduction text.
        /// </summary>
        private void WriteIntroduction()
        {
            Console.WriteLine("> **********************************");
            Console.WriteLine("> *****  Timing test by INF2G  *****");
            Console.WriteLine("> **********************************");
            Console.WriteLine();
        }

        /// <summary>
        ///     Run the actual test.
        /// </summary>
        private void RunTest()
        {
            // Lock the thread
            lock (threadLock)
            {
                //Start timer
                timerSB.Start();

                //Build using StringBuilder
                BuildSB(size);

                //Stop timer
                timerSB.Stop();

                //Return duration
                SBDuration = timerSB.Duration(timeResolution);
            }

            // Lock the thread
            lock (threadLock)
            {
                //Start timer
                timerString.Start();

                //Build using String
                BuildString(size);

                //Stop timer
                timerString.Stop();

                //Return duration
                SDuration = timerString.Duration(timeResolution);
            }

            Console.WriteLine();

            //Write String duration
            Console.WriteLine("> String Duration: {0} {1}",
                SDuration, timeResolution);

            //Write String Builder duration
            Console.WriteLine("> StringBuilder Duration: {0} {1}",
                SBDuration, timeResolution);

            // Calculate percentage
            var highest = Math.Max(SBDuration, SDuration);
            var lowest = Math.Min(SBDuration, SDuration);

            //Print difference
            Console.WriteLine("> Difference: " + (highest - lowest));
            Console.WriteLine("\n> Press a key to continue");
            Console.ReadKey(true);
        }

        /// <summary>
        ///     SetAffinity of thread.
        /// </summary>
        private void SetAffinity()
        {
            try
            {
                foreach (ProcessThread pt in proc.Threads)
                {
                    // Set all our threads to use core 1 of the CPU
                    pt.IdealProcessor = 0;
                    pt.ProcessorAffinity = (IntPtr) 0x1;
                    pt.PriorityLevel = ThreadPriorityLevel.Highest;
                    threadCount++;
                }
                //Write thread affinity changes
                Console.WriteLine("> Thread affinity changes: {0}", threadCount);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error setting CPU Affinity: {0}", ex);
            }
        }

        /// <summary>
        ///     Method to build strings using the StringBuilder class.
        /// </summary>
        /// <param name="size">int - size of string</param>
        private void BuildSB(int size)
        {
            var sbObject = new StringBuilder();
            for (var i = 0; i <= size; i++)
            {
                sbObject.Append("a");
            }
        }

        /// <summary>
        ///     Method to build string using the String class.
        /// </summary>
        /// <param name="size">int - size of string</param>
        private void BuildString(int size)
        {
            var stringObject = "";
            for (var i = 0; i <= size; i++)
            {
                stringObject += "a";
            }
        }

        /// <summary>
        ///     Feature to stabilize CPU clockspeed.
        ///     Many modern processors have power-saving features
        ///     that decrease clockspeed when cpu-utilization is low.
        ///     This method maximises cpu clockspeed prior to running the timing test.
        /// </summary>
        private void CPUWarmUp()
        {
            Console.Write("> Warming up CPU...");
            //Find prime number of 300001
            FindPrimeNumber(300001);
            Console.WriteLine("Done.");
            Console.WriteLine();
        }

        /// <summary>
        ///     Find prime number.
        /// </summary>
        /// <param name="n">integer number</param>
        private void FindPrimeNumber(int n)
        {
            var count = 0;
            long a = 2;
            while (count < n)
            {
                long b = 2;
                var prime = 1; // to check if found a prime
                while (b*b <= a)
                {
                    if (a%b == 0)
                    {
                        prime = 0;
                        break;
                    }
                    b++;
                }
                if (prime > 0)
                    count++;
                a++;
            }
        }
    }
}