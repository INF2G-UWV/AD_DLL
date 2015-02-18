using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ADDLL
{    
    public enum TimeResolution
    {
        Seconds         = 1,
        Milliseconds    = 1000,
        Microseconds    = 1000000,
        Nanoseconds     = 1000000000
    }

    public class HighResolutionTimer
    {
        #region QueryPerformance DLL Import
        [DllImport("kernel32.dll")]
        extern static short QueryPerformanceCounter(ref long x);

        [DllImport("kernel32.dll")]
        extern static short QueryPerformanceFrequency(ref long x);
        #endregion

        #region Variables
        private long timestampStart;
        private long timestampEnd;

        private bool useDLL;
        #endregion

        #region Properties
        public long TimestampStart
        {
            get { return timestampStart; }
            private set { timestampStart = value; }
        }

        public long TimestampEnd
        {
            get { return timestampEnd; }
            private set { timestampEnd = value; }
        }
        #endregion

        #region Constructor
        public HighResolutionTimer(bool useDLL)
        {
            TimestampStart = 0;
            TimestampEnd = 0;
            
            this.useDLL = useDLL;
        }
        #endregion

        #region Public Methods
        public void Start()
        {
            if (useDLL)
            {
                QueryPerformanceCounter(ref timestampStart);
            }
            else
            {
                TimestampStart = Stopwatch.GetTimestamp();
            }
        }

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

        public double Duration(TimeResolution timeResolution)
        {
            if (useDLL)
            {
                long frequency = 0;
                QueryPerformanceFrequency(ref frequency);

                return ((timestampEnd - timestampStart) * ((double)timeResolution / frequency));
            }
            else
            {
                return ((timestampEnd - timestampStart) * ((double)timeResolution / Stopwatch.Frequency));
            }
        }
        #endregion
    }
}
