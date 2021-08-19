using System;
using System.Configuration;
using System.ServiceProcess;
using System.Timers;

namespace StratixToRuanDataTransfer
{
    partial class StratixToRuanService : ServiceBase
    {
        private static Timer aTimer;
        private static long timerInterval;
        private static string queueProcess;
        public StratixToRuanService()
        {
            InitializeComponent();
            if (string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["QueueProcessTimeInterval"]))
            {
                bool success = Int64.TryParse(ConfigurationManager.AppSettings["QueueProcessTimeInterval"], out timerInterval);
                if (!success)
                {
                    string exceptionText =
                        $"{DateTime.Now.ToShortTimeString()}: Error getting Queue Process Time Interval";
                    throw new Exception(exceptionText);
                }
            }

            if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["QueueProcess"]))
            {
                queueProcess = ConfigurationManager.AppSettings["QueueProcess"];
            }
        }

        protected override void OnStart(string[] args)
        {
            aTimer = new Timer(timerInterval);
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (queueProcess.Equals("OrderRelease"))
            {
                StratixToRuanOrderDataTransfer dataTransfer = new StratixToRuanOrderDataTransfer();
                dataTransfer.ExecuteOrderReleases();
            }
            else if (queueProcess.Equals("TAtoStratix"))
            {
                StratixToRuanOrderDataTransfer dataTransfer = new StratixToRuanOrderDataTransfer();
                dataTransfer.ExecutePendingTransports();
            }
            else
            {
                string exceptionText =
                    $"{DateTime.Now.ToShortTimeString()}: Error determining which process to Run(Order Release or Pending Transport).";
                throw new Exception(exceptionText);
            }
        }

        protected override void OnStop()
        {
            aTimer.Stop();
        }
    }
}
