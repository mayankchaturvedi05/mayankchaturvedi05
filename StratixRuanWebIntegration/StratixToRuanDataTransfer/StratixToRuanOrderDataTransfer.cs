using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using StratixRuanBusinessLogic;
using StratixRuanBusinessLogic.Ruan.Action;
using StratixRuanDataLayer;
using GlobalState = StratixRuanBusinessLogic.GlobalState;

namespace StratixToRuanDataTransfer
{
    public class StratixToRuanOrderDataTransfer
    {
        private QueueFlag queueFlagForActivityNotAssigned;
        private long timerInterval;
        public StratixToRuanOrderDataTransfer()
        {
            queueFlagForActivityNotAssigned = GlobalState.QueueFlags.QueueFlagByCode("ActivityNotAssigned");
            
        }
        public void ExecuteOrderReleases()
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
                    List<string> stratixInterchangeActivitiesForActiveRuanStatusValue = new List<string>(){"A", "C", "S", "U"}; // Status value for Ruan mapping will be "A"
                    List<string> stratixInterchangeActivitiesForCancelledRuanStatusValue = new List<string>() { "D" }; // Status value for Ruan mapping will be "C"
                    
                    foreach (StratixOrderNotification currentPendingOrderNtNotification in allPendingOrderNtNotifications)
                    {
                        string ruanStatusValue = "A";

                        StratixOrderNotification isOrderXmlAlreadySentToRuan = null;
                        
                        try
                        {
                            if (stratixInterchangeActivitiesForActiveRuanStatusValue.Contains(currentPendingOrderNtNotification.InterchangeActivity))
                            {
                                ruanStatusValue = "A"; //Active for Ruan
                            }
                            else if (stratixInterchangeActivitiesForCancelledRuanStatusValue.Contains(currentPendingOrderNtNotification.InterchangeActivity))
                            {
                                ruanStatusValue = "C"; //Cancelled for Ruan
                            }

                            logText.AppendLine($"{DateTime.Now.ToShortTimeString()}:  Preparing to send to Ruan - InterchangeNumber# {currentPendingOrderNtNotification.InterchangeNumber}/ OrderNumber: {currentPendingOrderNtNotification.ReferenceNumber}");
                            //send the XML to Ruan
                            RuanAction.Synchronize = true;
                            StratixOrderReleaseParametersForRuan stratixOrderReleaseParametersForRuan = new StratixOrderReleaseParametersForRuan
                                {
                                    stratixInterchangeNumber = currentPendingOrderNtNotification.InterchangeNumber,
                                    orderFileKeyNumber = currentPendingOrderNtNotification.ReferenceNumber,
                                    orderFileKeyPfx = currentPendingOrderNtNotification.ReferencePrefix

                            };
                            if (currentPendingOrderNtNotification.ReferenceItem > 0)
                            {
                                stratixOrderReleaseParametersForRuan.orderFileItemNumber = currentPendingOrderNtNotification.ReferenceItem;
                            }

                            if (currentPendingOrderNtNotification.ReferenceSubItem > 0)
                            {
                                stratixOrderReleaseParametersForRuan.orderFileSubItemNumber = currentPendingOrderNtNotification.ReferenceSubItem;
                            }

                            stratixOrderReleaseParametersForRuan.orderReleaseStatusValue = ruanStatusValue;
                            
                            RuanAction.GenerateOrderReleaseForRuan(stratixOrderReleaseParametersForRuan);

                            logText.AppendLine($"{DateTime.Now.ToShortTimeString()}: Sent to Ruan - InterchangeNumber# {currentPendingOrderNtNotification.InterchangeNumber}/ Interchange Activity {currentPendingOrderNtNotification.InterchangeActivity}/ OrderNumber: {currentPendingOrderNtNotification.ReferenceNumber}");

                           
                        }
                        catch (Exception e)
                        {
                            logText.AppendLine($"{DateTime.Now.ToShortTimeString()}: Error processing - InterchangeNumber# {currentPendingOrderNtNotification.InterchangeNumber}/ Interchange Activity {currentPendingOrderNtNotification.InterchangeActivity} / OrderNumber: {currentPendingOrderNtNotification.ReferenceNumber}");
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
                logText.AppendLine(exceptionText);
                LogMessage(logText.ToString());
                logText.Clear();
                Console.WriteLine(exceptionText);
            }
        }

        public void ExecutePendingTransports()
        {
            StringBuilder logText = new StringBuilder();
            RuanXMLQueueList pendingTransportActivitiesToBeCreated = RuanXMLQueue.FetchAllByQueueFlagNumber(queueFlagForActivityNotAssigned.QueueTypeNumber);

            foreach (var pendingTransportActivity in pendingTransportActivitiesToBeCreated)
            {
                try
                {
                    RuanAction.ProcessTransportActivities(pendingTransportActivity.RuanXMLQueueNumber);
                }
                catch (Exception e)
                {
                    string exceptionText =
                        $"{DateTime.Now.ToShortTimeString()}: Error processing. The exception message is {e.Message}";

                    LogMessage(logText.ToString());
                    logText.Clear();
                    Console.WriteLine(exceptionText);
                }
                
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
