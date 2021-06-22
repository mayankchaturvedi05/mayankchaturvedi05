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
            StringBuilder logText = new StringBuilder();
            try
            {
                List<StratixOrderNotification> allPendingOrderNtNotifications = StratixOrderNotification.GetStratixOrderNotification();
                List<StratixOrderNotification> processedNotifications = new List<StratixOrderNotification>();

                List<long> interChangeNumbers = allPendingOrderNtNotifications.Select(x => x.InterchangeNumber).ToList();

                if (interChangeNumbers.Count > 0)
                {

                    StratixOrderNotification.SetOrderNotificationToInProcess(interChangeNumbers); //Mark them all In process
                    List<string> stratixInterchangeActivitiesForActiveRuanStatusValue = new List<string>(){"A", "C", "S"}; // Status value for Ruan mapping will be "A"
                    List<string> stratixInterchangeActivitiesForCancelledRuanStatusValue = new List<string>() { "D" }; // Status value for Ruan mapping will be "C"
                    foreach (StratixOrderNotification currentPendingOrderNtNotification in allPendingOrderNtNotifications)
                    {
                        string ruanStatusValue = "A";

                        StratixOrderNotification isOrderXmlAlreadySentToRuan = null;

                        try
                        {
                            if (stratixInterchangeActivitiesForActiveRuanStatusValue.Contains(currentPendingOrderNtNotification.InterchangeActivity))
                            {
                                isOrderXmlAlreadySentToRuan = processedNotifications.FirstOrDefault(x =>
                                    x.ReferenceNumber == currentPendingOrderNtNotification.ReferenceNumber &&
                                    stratixInterchangeActivitiesForActiveRuanStatusValue.Contains(x.InterchangeActivity));
                                ruanStatusValue = "A"; //Active for Ruan
                            }
                            else if (stratixInterchangeActivitiesForCancelledRuanStatusValue.Contains(currentPendingOrderNtNotification.InterchangeActivity))
                            {
                                isOrderXmlAlreadySentToRuan = processedNotifications.FirstOrDefault(x =>
                                    x.ReferenceNumber == currentPendingOrderNtNotification.ReferenceNumber &&
                                    stratixInterchangeActivitiesForCancelledRuanStatusValue.Contains(x.InterchangeActivity));
                                ruanStatusValue = "C"; //Cancelled for Ruan
                            }


                            if (isOrderXmlAlreadySentToRuan == null) //Nothing sent to Ruan for this Order and Interchange Activity combination.
                            {

                                logText.AppendLine($"{DateTime.Now.ToShortTimeString()}:  Preparing to send to Ruan - InterchangeNumber# {currentPendingOrderNtNotification.InterchangeNumber}");

                                //send the XML to Ruan
                                RuanAction.Synchronize = true;
                                RuanAction.GenerateOrderReleaseForRuan(currentPendingOrderNtNotification.InterchangeNumber, currentPendingOrderNtNotification.ReferenceNumber, ruanStatusValue);

                                //After the Sent Process, add the order and interchange activity to the processed Notification list, so that any subsequent Order/Interchange activity notification NEED NOT BE SENT
                                processedNotifications.Add(new StratixOrderNotification() { ReferenceNumber = currentPendingOrderNtNotification.ReferenceNumber, InterchangeActivity = currentPendingOrderNtNotification.InterchangeActivity });


                            }
                            else // if it was already in the Processed notification list, DON'T sent to RUAN
                            {
                                //Dont send to Ruan
                                logText.AppendLine($"{DateTime.Now.ToShortTimeString()}: Not sent to Ruan - as InterchangeNumber# {currentPendingOrderNtNotification.InterchangeNumber}/ Interchange Activity {currentPendingOrderNtNotification.InterchangeActivity} is already processed for the Order {currentPendingOrderNtNotification.ReferenceNumber} and sent to Ruan as part of this current transaction list. ");

                            }
                        }
                        catch (Exception e)
                        {
                            logText.AppendLine($"{DateTime.Now.ToShortTimeString()}: Error processing - InterchangeNumber# {currentPendingOrderNtNotification.InterchangeNumber}/ Interchange Activity {currentPendingOrderNtNotification.InterchangeActivity}");
                        }
                        

                    }
                    
                    StratixOrderNotification.SetOrderNotificationToComplete(interChangeNumbers);
                    logText.AppendLine($"{DateTime.Now.ToShortTimeString()}:  Stratix Notification records marked as updated # {string.Join(",", interChangeNumbers.Select(n => n.ToString()).ToArray())}");
                    Console.WriteLine(logText.ToString());

                }
                

                LogMessage(logText.ToString());
            }
            catch (Exception e)
            {
                string exceptionText =
                    $"{DateTime.Now.ToShortTimeString()}: Error processing. The exception message is {e.Message}";
                logText.Clear();
                logText.AppendLine(exceptionText);
                Console.WriteLine(exceptionText);
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
