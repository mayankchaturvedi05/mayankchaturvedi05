using System;
using System.Configuration;
using System.ServiceProcess;
using System.Timers;
using StratixRuanBusinessLogic;

namespace StratixToRuanDataTransfer
{
    class Program
    {
        private static Timer aTimer;
        private static string queueProcess;
        private static long timerInterval;
        static void Main(string[] args)
        {
           
            try
            {
                var connectionSettings = ConfigurationManager.ConnectionStrings["qa"];
                if (connectionSettings != null)
                {
                    GlobalState.ConnectionString = connectionSettings.ConnectionString;

                }
            }
            catch (Exception)
            {
                throw new Exception("Heidtman connection is NOT  configured for the environment, contact support.");
            }

            try
            {
               StratixRuanDataLayer.GlobalState.StratixConnectionString = ConfigurationManager.AppSettings["StratixDsn"];
                if (string.IsNullOrEmpty(StratixRuanDataLayer.GlobalState.StratixConnectionString)) throw new Exception();
            }
            catch (Exception)
            {
                throw new Exception("Stratix connection is NOT  configured for the environment, contact support.");
            }

            if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["QueueProcessTimeInterval"]))
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
            else
            {
                string exceptionText =
                    $"{DateTime.Now.ToShortTimeString()}: Error getting Queue Process";
                throw new Exception(exceptionText);
            }

            if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["StratixUser"]))
            {
                GlobalState.StratixUserName = ConfigurationManager.AppSettings["StratixUser"];
            }
            else
            {
                string exceptionText =
                    $"{DateTime.Now.ToShortTimeString()}: Error getting Stratix User Name";
                throw new Exception(exceptionText);
            }

            if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["StratixPassword"]))
            {
                GlobalState.StratixPassword = ConfigurationManager.AppSettings["StratixPassword"];
            }
            else
            {
                string exceptionText =
                    $"{DateTime.Now.ToShortTimeString()}: Error getting Stratix Password";
                throw new Exception(exceptionText);
            }

            if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["StratixEnvironmentName"]))
            {
                GlobalState.StratixEnvironmentName = ConfigurationManager.AppSettings["StratixEnvironmentName"];
            }
            else
            {
                string exceptionText =
                    $"{DateTime.Now.ToShortTimeString()}: Error getting Stratix Environment name";
                throw new Exception(exceptionText);
            }

            if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["StratixEnvironmentClass"]))
            {
                GlobalState.StratixEnvironmentClass = ConfigurationManager.AppSettings["StratixEnvironmentClass"];
            }
            else
            {
                string exceptionText =
                    $"{DateTime.Now.ToShortTimeString()}: Error getting Stratix Environment Class";
                throw new Exception(exceptionText);
            }


            if ((!Environment.UserInteractive))
            {
                Program.RunAsAService();
            }
            else
            {
                if (args != null && args.Length > 0)
                {
                    if (args[0].Equals("-i", StringComparison.OrdinalIgnoreCase))
                    {
                        SelfInstaller.InstallMe();
                    }
                    else
                    {
                        if (args[0].Equals("-u", StringComparison.OrdinalIgnoreCase))
                        {
                            SelfInstaller.UninstallMe();
                        }
                        else
                        {
                            Console.WriteLine("Invalid argument!");
                        }
                    }
                }
                else
                {
                    Program.RunAsAConsole();
                }
            }
        }

        static void RunAsAConsole()
        {
            aTimer = new Timer(timerInterval); 
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Enabled = true;

            // StratixToRuanOrderDataTransfer dataTransfer = new StratixToRuanOrderDataTransfer();
            //dataTransfer.Execute();

            Console.ReadLine();
            aTimer.Stop();


        }

        static void RunAsAService()
        {
            ServiceBase[] servicesToRun = new ServiceBase[]
            {
                new StratixToRuanService()
            };
            ServiceBase.Run(servicesToRun);
        }

         static void OnTimedEvent(object source, ElapsedEventArgs e)
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
    }
}
