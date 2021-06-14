using System.ServiceProcess;
using System.Timers;

namespace StratixToRuanDataTransfer
{
    partial class StratixToRuanService : ServiceBase
    {
        private static Timer aTimer;
        public StratixToRuanService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            aTimer = new Timer(10000); // 10 Seconds
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            StratixToRuanOrderDataTransfer dataTransfer = new StratixToRuanOrderDataTransfer();
            dataTransfer.Execute();
        }

        protected override void OnStop()
        {
            aTimer.Stop();
        }
    }
}
