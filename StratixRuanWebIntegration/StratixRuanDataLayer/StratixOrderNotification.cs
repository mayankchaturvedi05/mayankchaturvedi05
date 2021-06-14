using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


            {
                string sql = @"

                      SELECT
                            H.noh_intchg_no, T.not_ref_no, T.not_ref_itm, T.not_ref_sitm, T.not_intchg_actvy, H.noh_actvy_dtts
                                FROM
                                XCTNOH_rec H
                                    INNER JOIN XCTNOT_rec T ON H.noh_cmpy_id = T.not_cmpy_id
                                        AND H.noh_intchg_pfx = T.not_intchg_pfx
                                        AND H.noh_intchg_no =  T.not_intchg_no " + whereClause;

                                
 ;

                OdbcConnection connection = new OdbcConnection("DSN=PostgreSQL30");//64 bit

                connection.Open();

                // 

                // Create an ODBC SQL command that will be executed below. Any SQL 
                // command that is valid with PostgreSQL is valid here (I think, 
                // but am not 100 percent sure. Every SQL command I've tried works).

                OdbcCommand command = new OdbcCommand(sql, connection);


                // Execute the SQL command and return a reader for navigating the results.
                OdbcDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);


                // This loop will output the entire contents of the results, iterating
                // through each row and through each field of the row.
                
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

                // Close the reader and connection (commands are not closed).
                reader.Close();
                connection.Close();


            }

            return resultSet;
        }


        public static void SetOrderNotificationInProcess(List<long> interchangeNumbers)
        {

            OdbcConnection connection = new OdbcConnection("DSN=PostgreSQL30");
            connection.Open();
            string Query = $"UPDATE XCTNOH_rec SET noh_ackd = 2 where noh_intchg_no IN ("  + string.Join(",", interchangeNumbers.Select(n => n.ToString()).ToArray()) + "); ";
            OdbcCommand cmd = new OdbcCommand(Query, connection);

            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public static void SetOrderNotificationToComplete(List<long> interchangeNumbers)
        {

            OdbcConnection connection = new OdbcConnection("DSN=PostgreSQL30");
            connection.Open();
            string Query = $"UPDATE XCTNOH_rec SET noh_ackd = 1, noh_ackd_dtts =  CURRENT_TIMESTAMP  where noh_intchg_no IN (" + string.Join(",", interchangeNumbers.Select(n => n.ToString()).ToArray()) + "); ";
            OdbcCommand cmd = new OdbcCommand(Query, connection);

            cmd.ExecuteNonQuery();

            connection.Close();
        }
    }
}
