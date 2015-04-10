using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DLL
{
    /// <summary>
    ///     Timeresolution enum
    /// </summary>
    public enum TimeResolution
    {
        Seconds = 1,
        Milliseconds = 1000,
        Microseconds = 1000000,
        Nanoseconds = 1000000000
    }

    /// <summary>
    ///     HighResolutionTimer.
    ///     Powerful timer for accurate measurements.
    /// </summary>
    public class HighResolutionTimer
    {
        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="useDLL">useDLL</param>
        public HighResolutionTimer(bool useDLL)
        {
            TimestampStart = 0;
            TimestampEnd = 0;

            this.useDLL = useDLL;
        }

        #endregion

        #region QueryPerformance DLL Import

        //Import QueryPerfomanceCounter from kernel

        [DllImport("kernel32.dll")]
        private static extern short QueryPerformanceCounter(ref long x);

        [DllImport("kernel32.dll")]
        private static extern short QueryPerformanceFrequency(ref long x);

        #endregion

        #region Variables

        //fields
        private long timestampStart;
        private long timestampEnd;

        private readonly bool useDLL;

        #endregion

        #region Properties

        /// <summary>
        ///     Get/Set Start
        /// </summary>
        public long TimestampStart
        {
            get { return timestampStart; }
            private set { timestampStart = value; }
        }

        /// <summary>
        ///     Get/Set End
        /// </summary>
        public long TimestampEnd
        {
            get { return timestampEnd; }
            private set { timestampEnd = value; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Start timer
        /// </summary>
        public void Start()
        {
            //Check if DLL is used, else use default Stopwatch
            if (useDLL)
            {
                QueryPerformanceCounter(ref timestampStart);
            }
            else
            {
                TimestampStart = Stopwatch.GetTimestamp();
            }
        }

        /// <summary>
        ///     Stop timer
        /// </summary>
        public void Stop()
        {
            if (useDLL)
            {
                QueryPerformanceCounter(ref timestampEnd);
            }
            else
            {
                TimestampEnd = Stopwatch.GetTimestamp();
            }
        }

        /// <summary>
        ///     Get the duration between start and end
        /// </summary>
        /// <param name="timeResolution">Timeresolution</param>
        /// <returns>double - duration</returns>
        public double Duration(TimeResolution timeResolution)
        {
            //check if DLL is used
            if (useDLL)
            {
                //Return the duration
                long frequency = 0;
                QueryPerformanceFrequency(ref frequency);

                return ((timestampEnd - timestampStart)*((double) timeResolution/frequency));
            }
            //Return the duration (without DLL)
            return ((timestampEnd - timestampStart)*((double) timeResolution/Stopwatch.Frequency));
        }

        #endregion
    }
}
