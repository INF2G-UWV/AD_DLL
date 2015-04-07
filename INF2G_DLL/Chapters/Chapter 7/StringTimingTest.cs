using System;
using System.Diagnostics;
using System.Management;
using System.Text;
using DLL;

namespace DLL_Test.Chapters.Chapter_7
{
    /// <summary>
    ///     String timing test.
    ///     Author: INF2G.
    /// </summary>
    internal class StringTimingTest
    {
        //Fields
        private static int threadCount;
        private static readonly Process proc = Process.GetCurrentProcess();
        private static readonly Object threadLock = new object();
        //Size of the string
        //int size = 100000;
        private static readonly int size = 100;
        //Timer for the StringBuilder
        private static readonly HighResolutionTimer timerSB = new HighResolutionTimer(true);
        //Timer for the string
        private static readonly HighResolutionTimer timerString = new HighResolutionTimer(true);
        // The order of magnitude we're displaying our times in
        private static readonly TimeResolution timeResolution = TimeResolution.Milliseconds;
        // Helper variables
        private static double SBDuration, SDuration;
        //Methods:

        /// <summary>
        ///     Main execution
        /// </summary>
        /// <param name="args"></param>
        private static void Run(string[] args)
        {
            WriteIntroduction();
            CPUWarmUp();
            SetAffinity();
            RunTest();
        }

        /// <summary>
        ///     Write introduction text.
        /// </summary>
        private static void WriteIntroduction()
        {
            Console.WriteLine("> **********************************");
            Console.WriteLine("> *****  Timing test by INF2G  *****");
            Console.WriteLine("> *****  Version 0.1           *****");
            Console.WriteLine("> **********************************");
            Console.WriteLine();
        }

        /// <summary>
        ///     Run the actual test.
        /// </summary>
        private static void RunTest()
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

            Console.ReadLine();
        }

        /// <summary>
        ///     SetAffinity of thread.
        /// </summary>
        private static void SetAffinity()
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

        /// <summary>
        ///     Method to build strings using the StringBuilder class.
        /// </summary>
        /// <param name="size">int - size of string</param>
        private static void BuildSB(int size)
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
        private static void BuildString(int size)
        {
            var stringObject = "";
            for (var i = 0; i <= size; i++)
            {
                stringObject += "a";
            }
        }

        /// <summary>
        ///     Get current CPU clock frequency.
        /// </summary>
        /// <returns>uint clockspeed in hertz</returns>
        public static uint GetCurrentCPUSpeed()
        {
            uint currentSpeed;
            using (var Mo = new ManagementObject("Win32_Processor.DeviceID='CPU0'"))
            {
                currentSpeed = (uint) (Mo["CurrentClockSpeed"]);
            }
            return currentSpeed;
        }

        /// <summary>
        ///     Get maximum cpu clock frequency.
        /// </summary>
        /// <returns>uint - clockspeed in hertz</returns>
        public static uint GetMaxCPUSpeed()
        {
            uint maxSpeed;
            using (var Mo = new ManagementObject("Win32_Processor.DeviceID='CPU0'"))
            {
                maxSpeed = (uint) (Mo["MaxClockSpeed"]);
            }
            return maxSpeed;
        }

        /// <summary>
        ///     Feature to stabilize CPU clockspeed.
        ///     Many modern processors have power-saving features
        ///     that decrease clockspeed when cpu-utilization is low.
        ///     This method maximises cpu clockspeed prior to running the timing test.
        /// </summary>
        public static void CPUWarmUp()
        {
            Console.Write("> Warming up CPU...");
            long nthPrime = 0;
            while (GetCurrentCPUSpeed() < GetMaxCPUSpeed())
            {
                nthPrime = FindPrimeNumber(10000001); //set higher value for more time
            }
            Console.WriteLine(nthPrime);
            Console.WriteLine("Done.");
            Console.WriteLine();
        }

        /// <summary>
        ///     Find prime number.
        /// </summary>
        /// <param name="n">integer number</param>
        /// <returns>long prime</returns>
        public static long FindPrimeNumber(int n)
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
            return (--a);
        }
    }
}