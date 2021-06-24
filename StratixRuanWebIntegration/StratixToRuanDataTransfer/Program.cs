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
            aTimer = new Timer(10000); // 10 Seconds
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
            StratixToRuanOrderDataTransfer dataTransfer = new StratixToRuanOrderDataTransfer();
            dataTransfer.Execute();
        }
    }
}
