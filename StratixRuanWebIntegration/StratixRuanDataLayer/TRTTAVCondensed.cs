using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratixRuanDataLayer
{
    public class TRTTAVCondensed
    {
        public string tav_trac_pfx { get; set; }
        public long tav_trac_no { get; set; }
        public long tav_trac_itm { get; set; }
        public string tav_trgt_ord_pfx { get; set; }
        public long tav_trgt_ord_no { get; set; }
        public long tav_trgt_ord_itm { get; set; }
        public long tav_trgt_ord_rls { get; set; }

        public long tav_bal_pcs { get; set; }
        public long tav_bal_msr { get; set; }
        public long tav_bal_wgt { get; set; }


        public static TRTTAVCondensed GetTrttavCondensed(string orderId, string detailItem, string releaseItem)
        {
            String query = $@"SElect tav_trac_pfx, tav_trac_no, tav_trac_itm , tav_bal_pcs, tav_bal_msr, tav_bal_wgt
                            from TRTTAV_rec
                            WHERE tav_trgt_ord_pfx = 'SO' and tav_trgt_ord_no = {orderId}  and tav_trgt_ord_itm = {detailItem}  and tav_trgt_ord_rls = {releaseItem} and tav_trac_typ = 'SH' and tav_src_job_sts = 0
                            ";
            TRTTAVCondensed result = new TRTTAVCondensed();
            using (OdbcConnection connection = new OdbcConnection(GlobalState.StratixConnectionString))
            {
                using (OdbcCommand cmd = new OdbcCommand(query, connection))
                {
                    connection.Open();
                    cmd.CommandType = CommandType.Text;
                  

                    OdbcDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);


                    while (reader.Read() == true)
                    {
                        result.tav_trac_pfx = reader["tav_trac_pfx"].ToString().Trim();
                        result.tav_trac_no = Convert.ToInt64(reader["tav_trac_no"]);
                        result.tav_trac_itm = Convert.ToInt64(reader["tav_trac_itm"]);
                        result.tav_bal_pcs = Convert.ToInt64(reader["tav_bal_pcs"]);
                        result.tav_bal_msr = Convert.ToInt64(reader["tav_bal_msr"]);
                        result.tav_bal_wgt = Convert.ToInt64(reader["tav_bal_wgt"]);

                    }
                    cmd.Connection.Close();

                }
            }

            return result;
        }

    }
}
