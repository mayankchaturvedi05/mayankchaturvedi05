using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using StratixRuanBusinessLogic.Ruan.Action;
using StratixRuanDataLayer;

namespace StratixToRuanDataTransfer
{
    public class StratixToRuanOrderDataTransfer
    {

        public void Execute()
        {
            try
            {
                Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////");


                List<StratixOrderNotification> allPendingOrderNtNotifications = StratixOrderNotification.GetStratixOrderNotification();
                List<StratixOrderNotification> processedNotifications = new List<StratixOrderNotification>();

                StringBuilder successfulMessages = new StringBuilder();

                string messagetest = "";
                List<long> interChangeNumbers = allPendingOrderNtNotifications.Select(x => x.InterchangeNumber).ToList();

                if (interChangeNumbers.Count > 0)
                {

                    StratixOrderNotification.SetOrderNotificationInProcess(interChangeNumbers);

                    foreach (StratixOrderNotification pendingOrderNotification in allPendingOrderNtNotifications)
                    {

                        string pendingInterchangeActivity = string.Empty;
                        if (pendingInterchangeActivity == "S")
                        {
                            pendingInterchangeActivity = "C";
                        }
                        else
                        {
                            pendingInterchangeActivity = pendingOrderNotification.InterchangeActivity;
                        }



                        StratixOrderNotification alreadySent = processedNotifications.FirstOrDefault(x =>
                            x.ReferenceNumber == pendingOrderNotification.ReferenceNumber && x.InterchangeActivity == pendingInterchangeActivity);

                        if (alreadySent != null)
                        {
                            //Dont send to Ruan
                            successfulMessages.AppendLine($"{DateTime.Now.ToShortTimeString()}: Not sent to Ruan - InterchangeNumber# {pendingOrderNotification.InterchangeNumber} as another order notification for the Order {pendingOrderNotification.ReferenceNumber} is already being sent to Ruan as part of this transfer. ");

                        }
                        else
                        {
                            successfulMessages.AppendLine($"{DateTime.Now.ToShortTimeString()}:  Preparing to send to Ruan - InterchangeNumber# {pendingOrderNotification.InterchangeNumber}");
                            //send to Ruan
                            RuanAction.GenerateOrderReleaseForRuan(pendingOrderNotification.ReferenceNumber);
                            successfulMessages.AppendLine($"{DateTime.Now.ToShortTimeString()}:  Sent to Ruan - InterchangeNumber# {pendingOrderNotification.InterchangeNumber}");
                            //and update Stratix
                            processedNotifications.Add(new StratixOrderNotification() { ReferenceNumber = pendingOrderNotification.ReferenceNumber, InterchangeActivity = pendingOrderNotification.InterchangeActivity });
                           
                        }




                        //////////////////
                       

                    }
                    
                    StratixOrderNotification.SetOrderNotificationToComplete(interChangeNumbers);
                    successfulMessages.AppendLine($"{DateTime.Now.ToShortTimeString()}:  Stratix Notification records marked as updated # {string.Join(",", interChangeNumbers.Select(n => n.ToString()).ToArray())}");
                    Console.WriteLine(successfulMessages.ToString());

                }
                


                LogMessage(successfulMessages.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        private void LogMessage(string messages)
        {
            string assemblyName = Assembly.GetCallingAssembly().GetName().Name;
            string fileName = string.Format(assemblyName + "-{0:yyyy-MM-dd}.log", DateTime.Now);
            string filePath = AppDomain.CurrentDomain.BaseDirectory + fileName;

            
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(messages);
                sw.Close();
            }
        }
    }
}
