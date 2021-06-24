using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;


namespace StratixRuanDataLayer
{
    public class StratixOrderNotification
    {
        public long InterchangeNumber { get; set; }
        public long ReferenceNumber { get; set; }
        public long ReferenceItem { get; set; }
        public long ReferenceSubItem { get; set; }
        public string InterchangeActivity { get; set; }
        public DateTime ActivityDateTime { get; set; }
        public short AcknowledgedFlag { get; set; }
        public DateTime AcknowledgedDateTime { get; set; }

        private const string whereClause = "WHERE T.not_ref_pfx = 'SO' AND H.noh_cmpy_id = 'HSP' AND noh_intchg_pfx = 'XE' AND noh_ackd_dtts IS NULL AND noh_ackd = 0";

        public static List<StratixOrderNotification> GetStratixOrderNotification()
        {
            
            List<StratixOrderNotification > resultSet = new List<StratixOrderNotification>();
            
                string sql = @"

                      SELECT
                            H.noh_intchg_no, T.not_ref_no, T.not_ref_itm, T.not_ref_sitm, T.not_intchg_actvy, H.noh_actvy_dtts
                                FROM
                                XCTNOH_rec H
                                    INNER JOIN XCTNOT_rec T ON H.noh_cmpy_id = T.not_cmpy_id
                                        AND H.noh_intchg_pfx = T.not_intchg_pfx
                                        AND H.noh_intchg_no =  T.not_intchg_no " + whereClause;

                                
 ;

                OdbcConnection connection = new OdbcConnection(GlobalState.StratixConnectionString);//64 bit

                connection.Open();

                OdbcCommand command = new OdbcCommand(sql, connection);


                // Execute the SQL command and return a reader for navigating the results.
                OdbcDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                
                while (reader.Read() == true)
                {
                    StratixOrderNotification result = new StratixOrderNotification();
                    result.InterchangeNumber = Convert.ToInt64(reader["noh_intchg_no"]);
                    result.ReferenceNumber = Convert.ToInt64(reader["not_ref_no"]);
                    result.ReferenceItem = Convert.ToInt64(reader["not_ref_itm"]);
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

        public static List<StratixOrderNotification> GetStratixOrderNotifications()
        {

            List<StratixOrderNotification> resultSet = new List<StratixOrderNotification>();

            string sql = @"

                      SELECT
                            H.noh_intchg_no, T.not_ref_no, T.not_ref_itm, T.not_ref_sitm, T.not_intchg_actvy, H.noh_actvy_dtts
                                FROM
                                XCTNOH_rec H
                                    INNER JOIN XCTNOT_rec T ON H.noh_cmpy_id = T.not_cmpy_id
                                        AND H.noh_intchg_pfx = T.not_intchg_pfx
                                        AND H.noh_intchg_no =  T.not_intchg_no " + whereClause;


            ;

            OdbcConnection connection = new OdbcConnection(GlobalState.StratixConnectionString);//64 bit

            connection.Open();

            OdbcCommand command = new OdbcCommand(sql, connection);


            // Execute the SQL command and return a reader for navigating the results.
            OdbcDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);


            while (reader.Read() == true)
            {
                StratixOrderNotification result = new StratixOrderNotification();
                result.InterchangeNumber = Convert.ToInt64(reader["noh_intchg_no"]);
                result.ReferenceNumber = Convert.ToInt64(reader["not_ref_no"]);
                result.ReferenceItem = Convert.ToInt64(reader["not_ref_itm"]);
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
