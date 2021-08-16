using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;


namespace StratixRuanDataLayer
{
    public class StratixOrderNotification
    {
        public long InterchangeNumber { get; set; }
        public long ReferenceNumber { get; set; }
        public short ReferenceItem { get; set; }
        public short ReferenceSubItem { get; set; }
        public string InterchangeActivity { get; set; }
        public DateTime ActivityDateTime { get; set; }
        public short AcknowledgedFlag { get; set; }
        public DateTime AcknowledgedDateTime { get; set; }

        private const string whereClauseSalesOrder = " WHERE T.not_ref_pfx IN ('SO') AND H.noh_cmpy_id = 'HSP' AND noh_intchg_pfx = 'XE' AND noh_ackd_dtts IS NULL AND noh_ackd = 0 AND T.not_intchg_actvy IN ('A','C','D', 'U') AND tav.tav_trac_typ = 'SH' ";
        private const string whereClauseTransfer = " WHERE T.not_ref_pfx IN ('IP') AND H.noh_cmpy_id = 'HSP' AND noh_intchg_pfx = 'XE' AND noh_ackd_dtts IS NULL AND noh_ackd = 0 AND T.not_intchg_actvy IN ('A','C','D', 'U') AND tav.tav_trac_typ = 'IP' ";
        private const string whereClauseJob = " WHERE T.not_ref_pfx IN ('JS') AND H.noh_cmpy_id = 'HSP' AND noh_intchg_pfx = 'XE' AND noh_ackd_dtts IS NULL AND noh_ackd = 0 AND T.not_intchg_actvy IN ('A','C','D', 'U') AND tav.tav_trac_typ = 'IP' ";

        public static List<StratixOrderNotification> GetStratixOrderNotification()
        {
            
            List<StratixOrderNotification > resultSet = new List<StratixOrderNotification>();
            
                string sql1 = @"

                      SELECT
                            H.noh_intchg_no, T.not_ref_no, T.not_ref_itm, T.not_ref_sitm, T.not_intchg_actvy, H.noh_actvy_dtts
                                FROM
                                XCTNOH_rec H
                                    INNER JOIN XCTNOT_rec T ON H.noh_cmpy_id = T.not_cmpy_id
                                        AND H.noh_intchg_pfx = T.not_intchg_pfx
                                        AND H.noh_intchg_no =  T.not_intchg_no
									INNER JOIN TRTTAV_rec tav ON tav.tav_trgt_ord_no = T.not_ref_no AND tav.tav_trgt_ord_itm = T.not_ref_itm AND  tav.tav_trgt_ord_rls = T.not_ref_sitm
										 " + whereClauseSalesOrder;
             string sql2 = @"
                      UNION
                      SELECT
                            H.noh_intchg_no, T.not_ref_no, T.not_ref_itm, T.not_ref_sitm, T.not_intchg_actvy, H.noh_actvy_dtts
                                FROM
                                XCTNOH_rec H
                                    INNER JOIN XCTNOT_rec T ON H.noh_cmpy_id = T.not_cmpy_id
                                        AND H.noh_intchg_pfx = T.not_intchg_pfx
                                        AND H.noh_intchg_no =  T.not_intchg_no
									INNER JOIN TRTTAV_rec tav ON tav.tav_ref_no = T.not_ref_no 
										 " + whereClauseTransfer;

            string sql3 = @"
                      UNION
                      SELECT
                            H.noh_intchg_no, T.not_ref_no, T.not_ref_itm, T.not_ref_sitm, T.not_intchg_actvy, H.noh_actvy_dtts
                                FROM
                                XCTNOH_rec H
                                    INNER JOIN XCTNOT_rec T ON H.noh_cmpy_id = T.not_cmpy_id
                                        AND H.noh_intchg_pfx = T.not_intchg_pfx
                                        AND H.noh_intchg_no =  T.not_intchg_no
									INNER JOIN TRTTAV_rec tav ON tav.tav_jbs_no = T.not_ref_no 
										 " + whereClauseJob;


            ;

                OdbcConnection connection = new OdbcConnection(GlobalState.StratixConnectionString);//64 bit

                connection.Open();
                StringBuilder combinedSQL = new StringBuilder();
            combinedSQL.AppendLine(sql1);
            combinedSQL.AppendLine(sql2);
            combinedSQL.AppendLine(sql3);
            OdbcCommand command = new OdbcCommand(combinedSQL.ToString(), connection);


                // Execute the SQL command and return a reader for navigating the results.
                OdbcDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                
                while (reader.Read() == true)
                {
                    StratixOrderNotification result = new StratixOrderNotification();
                    result.InterchangeNumber = Convert.ToInt64(reader["noh_intchg_no"]);
                    result.ReferenceNumber = Convert.ToInt64(reader["not_ref_no"]);
                    result.ReferenceItem = Convert.ToInt16(reader["not_ref_itm"]);
                    result.ReferenceSubItem = Convert.ToInt16(reader["not_ref_sitm"]);
                    result.InterchangeActivity = reader["not_intchg_actvy"].ToString().Trim();
                    object activityDateTimeObject = reader["noh_actvy_dtts"];
                    result.ActivityDateTime = Convert.ToDateTime(activityDateTimeObject);


                    resultSet.Add(result);

                }

                
                reader.Close();
                connection.Close();


            

            return resultSet;
        }

      
        public static void SetOrderNotificationToOpen(long interchangeNumber)
        {

            using (OdbcConnection connection =
                new OdbcConnection(StratixRuanDataLayer.GlobalState.StratixConnectionString))
            {
                OdbcCommand command = new OdbcCommand();
                OdbcTransaction transaction = null;

                // Set the Connection to the new OdbcConnection.
                command.Connection = connection;

                // Open the connection and execute the transaction.
                try
                {
                    connection.Open();

                    // Start a local transaction
                    transaction = connection.BeginTransaction();

                    // Assign transaction object for a pending local transaction.
                    command.Connection = connection;
                    command.Transaction = transaction;

                    // Execute the commands.
                    command.CommandText =
                        $"UPDATE XCTNOH_rec SET noh_ackd = 0, noh_ackd_dtts = null where noh_intchg_no = {interchangeNumber} ";
                    command.ExecuteNonQuery();


                    // Commit the transaction.
                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    try
                    {
                        // Attempt to roll back the transaction.
                        transaction?.Rollback();
                    }
                    catch
                    {
                        //Log to be added.
                    }
                }

            }
        }

        public static void SetOrderNotificationToInProcess(List<long> interchangeNumbers)
        {

            using (OdbcConnection connection =
                new OdbcConnection(StratixRuanDataLayer.GlobalState.StratixConnectionString))
            {
                OdbcCommand command = new OdbcCommand();
                OdbcTransaction transaction = null;

                // Set the Connection to the new OdbcConnection.
                command.Connection = connection;

                // Open the connection and execute the transaction.
                try
                {
                    connection.Open();

                    // Start a local transaction
                    transaction = connection.BeginTransaction();

                    // Assign transaction object for a pending local transaction.
                    command.Connection = connection;
                    command.Transaction = transaction;

                    // Execute the commands.
                    command.CommandText =
                        "UPDATE XCTNOH_rec SET noh_ackd = 2 where noh_intchg_no IN (" + string.Join(",", interchangeNumbers.Select(n => n.ToString()).ToArray()) + "); ";
                    command.ExecuteNonQuery();
                   

                    // Commit the transaction.
                    transaction.Commit();
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    try
                    {
                        // Attempt to roll back the transaction.
                        transaction?.Rollback();
                    }
                    catch
                    {
                        //Log to be added.
                    }
                }
               
            }
        }

        public static void SetOrderNotificationToComplete(List<long> interchangeNumbers)
        {
            using (OdbcConnection connection =
                new OdbcConnection(StratixRuanDataLayer.GlobalState.StratixConnectionString))
            {
                OdbcCommand command = new OdbcCommand();
                OdbcTransaction transaction = null;

                // Set the Connection to the new OdbcConnection.
                command.Connection = connection;

                // Open the connection and execute the transaction.
                try
                {
                    connection.Open();

                    // Start a local transaction
                    transaction = connection.BeginTransaction();

                    // Assign transaction object for a pending local transaction.
                    command.Connection = connection;
                    command.Transaction = transaction;

                    // Execute the commands.
                    command.CommandText =
                        "UPDATE XCTNOH_rec SET noh_ackd = 1, noh_ackd_dtts =  CURRENT_TIMESTAMP  where noh_intchg_no IN (" + string.Join(",", interchangeNumbers.Select(n => n.ToString()).ToArray()) + "); ";
                    command.ExecuteNonQuery();


                    // Commit the transaction.
                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    try
                    {
                        // Attempt to roll back the transaction.
                        transaction?.Rollback();
                    }
                    catch
                    {
                        //Log to be added.
                    }
                }

            }
        }
    }
}
