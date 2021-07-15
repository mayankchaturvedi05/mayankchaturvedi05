using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using StratixRuanBusinessLogic;
using StratixRuanBusinessLogic.Ruan.Action;
using StratixRuanBusinessLogic.Ruan.Serialization;

namespace StratixRuanWebIntegration
{
    public class RuanStratixService : IRuanStratixService
    {
        private readonly string _ruanUser;
        private readonly string _ruanPassword;
        private readonly string _logFilePath;
        private readonly bool _shouldLogXml;
        private const string JobUser = "System";
        private string EventLogSource = "RuanSource";
        private string EventLogName = "RuanLog";

        public RuanStratixService()
        {
            try
            {
                _logFilePath = ConfigurationManager.AppSettings["LogFileLocation"];
                _ruanUser = ConfigurationManager.AppSettings["RuanStratixUser"];
                _ruanPassword = ConfigurationManager.AppSettings["RuanStratixUPW"];
                _shouldLogXml = Convert.ToBoolean(ConfigurationManager.AppSettings["ShouldLogXML"]);
            }
            catch (FaultException<RuanStratixException>)
            {
                throw;
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.Message;
                string exceptionDescription = ex.StackTrace;
                GenerateStratixRuanException(exceptionMessage, exceptionDescription);
            }
        }


        #region Utility Methods

        private bool ValidateCredentials(RuanCredentials credentials, string methodName)
        {
            if (credentials == null)
            {
                string exceptionMessage = "The parameter Credentials cannot be null";
                string exceptionDescription = "Contract Method Name : " + methodName + ", Description: The parameter Credentials cannot be null";
                GenerateStratixRuanException(exceptionMessage, exceptionDescription);
                return false;
            }

            // ReSharper disable once InvertIf
            if (credentials.username != _ruanUser || credentials.password != _ruanPassword)
            {
                StringBuilder logtext = new StringBuilder();
                logtext.AppendLine("Contract Method Name : " + methodName + ", Description:Invalid credentials passed");
                logtext.AppendLine(Utilities.SerializeObjectToString(credentials));
                GenerateStratixRuanException($"Wrong Credentials Received: {credentials.username ?? string.Empty}/{credentials.password ?? string.Empty}", logtext.ToString());
                return false;
            }

            return true;
        }

        private void GenerateStratixRuanException(string exceptionMessage, string exceptionDetail)
        {
            RuanStratixException runStratixException = new RuanStratixException
            {
                ExceptionMesssage = exceptionMessage,
                ExceptionDescription = exceptionDetail
            };

            StringBuilder logText = new StringBuilder();
            logText.AppendLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            logText.AppendLine($"Exception Message: {exceptionMessage}");
            logText.AppendLine($"Exception Description: {exceptionDetail}");
            Log(logText.ToString());

            throw new FaultException<RuanStratixException>(runStratixException, new FaultReason($"{runStratixException.ExceptionMesssage}"));
        }

        private void Log(string logMessage)
        {
            try
            {
                using (StreamWriter w = File.AppendText(_logFilePath))
                {
                    w.WriteLine("  :{0}", logMessage);
                }
            }
            catch (Exception ex)
            {
                StringBuilder logText = new StringBuilder();
                logText.AppendLine("Exception occurred during Startup:");
                logText.AppendLine($"{ex.GetType().ToString()}: exception Message : {ex.Message}");
                logText.AppendLine($"Stack Trace:{ex.StackTrace}");
                EventLog eventLog = new EventLog();
                eventLog.Source = EventLogSource;
                eventLog.Log = EventLogName;
                eventLog.WriteEntry(logText.ToString(), EventLogEntryType.Error);
            }

        }

        private void GenerateRuanStratixException(string exceptionMessage, string exceptionDetail)
        {
            RuanStratixException ruanStratixException = new RuanStratixException { ExceptionMesssage = exceptionMessage, ExceptionDescription = exceptionDetail };
            StringBuilder logText = new StringBuilder();
            logText.AppendLine($"Exception Message: {exceptionMessage}");
            logText.AppendLine($"Exception Description: {exceptionDetail}");
            Log(logText.ToString());
            throw new FaultException<RuanStratixException>(ruanStratixException);
        }

        public string GetConnectionString(string connectionCode)
        {
            ConnectionStringSettings csSettings = ConfigurationManager.ConnectionStrings[connectionCode];
            if (csSettings != null)
            {
                return csSettings.ConnectionString;
            }
            else
            {
                Log("No connection string named " + connectionCode);
                throw new ConfigurationErrorsException("No ConnectionString with name=" + connectionCode);
            }
        }

        private void SetupDataConnection(string methodName)
        {
           //todo:
        }

        public bool SubmitRuanToStratix(RuanCredentials credentials, IRuanStratixClass xmlData, string callingMethodName)
        {
            try
            {
                if (!ValidateCredentials(credentials, callingMethodName))
                {
                    return false;
                }

                Validate(xmlData);

               
                RuanAction.ProcessTa((APITransportationShipment)xmlData);
              

            }
            catch (FaultException<RuanStratixException>)
            {
                throw;
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.Message;
                string exceptionDescription = ex.StackTrace;
                GenerateStratixRuanException(exceptionMessage, exceptionDescription);
            }

            return true;
        }

        private void Validate(IRuanStratixClass transportationAssigned)
        {
            WriteToLog(transportationAssigned);
            SetupDataConnection(MethodBase.GetCurrentMethod().Name);
            SendToXmlTable(transportationAssigned);
        }

        private void SendToXmlTable(IRuanStratixClass xmlData)
        {
          
        }

        

        private void WriteToLog(IRuanStratixClass xmlData)
        {
            StringBuilder logText = new StringBuilder();
            logText.AppendLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            logText.AppendLine($"Begin writing the whole {xmlData.GetType().Name} Object.");

            try
            {
                string ruanTransportationAssignedString = Utilities.SerializeObjectToString(xmlData);
                if (_shouldLogXml)
                {
                    logText.AppendLine(ruanTransportationAssignedString);
                }
            }
            catch
            {
                logText.AppendLine($"Unable to Serialize {xmlData.GetType().Name} into XML");
            }
            logText.AppendLine($"End writing the whole {xmlData.GetType().Name} Object.");
            Log(logText.ToString());
        }

        #endregion

        #region Ping

        public bool PingTestFromRuanToStratix()
        {
            StringBuilder logText = new StringBuilder();
            logText.AppendLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            logText.AppendLine($"Ping Stratix Test called...");
            Log(logText.ToString());
            return true;
        }

        public bool PingTestFromRuanToStratixWithCredentials(RuanCredentials credentials)
        {
            StringBuilder logText = new StringBuilder();
            logText.AppendLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            logText.AppendLine($"Ping Stratix Test called with Credentials...");
            logText.AppendLine(Utilities.SerializeObjectToString(credentials));

            Log(logText.ToString());
            ValidateCredentials(credentials, "PingTestFromRuanToStratixWithCredentials");

            return true;
        }

        #endregion

        #region Transportation Assigned File

        public bool SubmitRuanTransportationAssignedToStratix(RuanCredentials credentials, APITransportationShipment transportationAssigned)
        {
            //add security and error logging.
            
            return SubmitRuanToStratix(credentials, transportationAssigned, MethodBase.GetCurrentMethod().Name);
        }

        #endregion

        #region Order Status File

        public bool SubmitRuanOrderStatusToStratix(RuanCredentials credentials, APIOrderStatus xmlData)
        {
            return SubmitRuanToStratix(credentials, xmlData, MethodBase.GetCurrentMethod().Name);
        }

        #endregion
    }
}
