using System;
using System.Diagnostics;
using System.Reflection;

namespace AwesomeUtilities
{
    public static class AwesomeDebug
    {
#if DEBUG
        private static int _indentationLevel = 0;
        private static DateTime lastTimeStamp = DateTime.Now;
        private static DateTime initTimeStamp = lastTimeStamp;
#endif
        [DebuggerStepThrough]
        public static void Begin()
        {
#if DEBUG
            try
            {
                StackTrace callStack = new StackTrace();
                StackFrame frame = callStack.GetFrame(1);
                MethodBase method = frame.GetMethod();

                string indent = new String(' ', _indentationLevel * 5);
                Debug.WriteLine(indent + "Begin " + method.Name);
                _indentationLevel++;
            }
            catch
            {
                //this method should not fail visibly for any reason
                //it's just for tracing information
            }
#endif 
        }

        [DebuggerStepThrough]
        public static void End()
        {
#if DEBUG
            try
            {
                _indentationLevel--;

                if (_indentationLevel < 0)
                    _indentationLevel = 0; 
                
                StackTrace callStack = new StackTrace();
                StackFrame frame = callStack.GetFrame(1);
                MethodBase method = frame.GetMethod();

                string indent = new String(' ', _indentationLevel * 5);
                Debug.WriteLine(indent + "End " + method.Name);
            }
            catch
            {
                //this method should not fail visibly for any reason
                //it's just for tracing information
            }
#endif
        }

        [DebuggerStepThrough]
        public static void initElapsedTime()
        {
#if DEBUG
            lastTimeStamp = DateTime.Now;
            initTimeStamp = lastTimeStamp;
#endif
        }

        [DebuggerStepThrough]
        public static void elapsedTime(string label)
        {
#if DEBUG
            try
            {
                label = label.PadRight(80);
                DateTime endTime = DateTime.Now;
                TimeSpan elapsedTime = endTime - lastTimeStamp;
                TimeSpan totalElapsedTime = endTime - initTimeStamp;
                lastTimeStamp = endTime;

                string timeString = string.Format("{0}m {1}s {2}ms", elapsedTime.Minutes, elapsedTime.Seconds, elapsedTime.Milliseconds);
                timeString = timeString.PadRight(16);
                string totalTimeString = string.Format("{0}m {1}s {2}ms", totalElapsedTime.Minutes, totalElapsedTime.Seconds, totalElapsedTime.Milliseconds);
                Debug.WriteLine("SADebug: " + label + "\t\telapsed time: " + timeString + "\t\ttotal elapsed: " + totalTimeString);
            }
            catch
            {
                //this method should not fail visibly for any reason
                //it's just for tracing information
            }
#endif
        }
    }
}
