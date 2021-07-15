using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratixRuanDataLayer
{
    public class StratixHelperData
    {

        public static string GetShipFromWarehouseForOrder(string orderId)
        {
            String query = $@"SELECT Distinct PLANT_SHIP_FROM.whs_whs as ShipFromID		
                             FROM
                            ORTORL_REC ORL
                            INNER JOIN SCRWHS_REC PLANT_SHIP_FROM ON PLANT_SHIP_FROM.whs_whs = ORL.orl_shpg_whs
                            WHERE ORL.orl_ord_no = {orderId}";

            using (OdbcConnection connection = new OdbcConnection(GlobalState.StratixConnectionString))
            {
                using (OdbcCommand cmd = new OdbcCommand(query, connection))
                {
                    connection.Open();
                    cmd.CommandType = CommandType.Text;
                    string fromWarehouse = Convert.ToString(cmd.ExecuteScalar());
                    cmd.Connection.Close();

                    return fromWarehouse;
                }
            }
        }

        public static long GetMaxInterchangeNumber()
        {
            String query = @"Select Max(i00_intchg_no)
                                        From XCTI00_rec";

            using (OdbcConnection connection = new OdbcConnection(GlobalState.StratixConnectionString))
            {
                using (OdbcCommand cmd = new OdbcCommand(query, connection))
                {
                    connection.Open();
                    cmd.CommandType = CommandType.Text;
                    long latestInterchangeNumber  = Convert.ToInt64(cmd.ExecuteScalar());
                    cmd.Connection.Close();

                    return latestInterchangeNumber;
                }
            }
        }

        public static long GetTransportNumber(long tranportInterchangeNumber)
        {
            String query = $@"
select i18_transp_no from  XCTI18_rec
WHERE i18_intchg_pfx = 'XI' and i18_intchg_no = {tranportInterchangeNumber}";

            using (OdbcConnection connection = new OdbcConnection(GlobalState.StratixConnectionString))
            {
                using (OdbcCommand cmd = new OdbcCommand(query, connection))
                {
                    connection.Open();
                    cmd.CommandType = CommandType.Text;
                    object transportNumberObject = cmd.ExecuteScalar();
                    long transportNumber = Convert.ToInt64(transportNumberObject);
                    cmd.Connection.Close();

                    return transportNumber;
                }
            }
        }

    }
}
