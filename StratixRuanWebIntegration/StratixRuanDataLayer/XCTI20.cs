using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratixRuanDataLayer
{
    public class XCTI20
    {
        public string i20_cmpy_id { get; set; }
        public string i20_intchg_pfx { get; set; }
        public long i20_intchg_no { get; set; }
        public string i20_crtd_dtts { get; set; }
        public long i20_crtd_dtms { get; set; }
        public DateTime i20_upd_dtts { get; set; }
        public long i20_upd_dtms { get; set; }
        public string i20_transp_pfx { get; set; }
        public long i20_transp_no { get; set; }

        public static void DeleteTransport(XCTI20 transportvalues)
        {

            OdbcConnection connection = new OdbcConnection(GlobalState.StratixConnectionString);//64 bit
            connection.Open();
            string insertColumnsQuery = "INSERT INTO xcti20_rec" +
                                        "(" +
                                        "i20_cmpy_id," +
                                        "i20_intchg_pfx," +
                                        "i20_intchg_no," +
                                        "i20_crtd_dtts," +
                                        "i20_transp_pfx," +
                                        "i20_transp_no" +
                                         ")";

            string valuesQuery = " VALUES" +
                                 "(" +
                                 $"'{transportvalues.i20_cmpy_id}', " +
                                 $"'{transportvalues.i20_intchg_pfx}', " +
                                 $"{transportvalues.i20_intchg_no}, " +
                                 $"{transportvalues.i20_crtd_dtts}, " +
                                 $"'{transportvalues.i20_transp_pfx}', " +
                                 $"{transportvalues.i20_transp_no} " +
                                 ");" +
                                " insert into xcti00_rec values" +
                                "(" +
                                 $"'HSP', '{transportvalues.i20_intchg_pfx}', {transportvalues.i20_intchg_no}, 'DTN', 'jcross', {transportvalues.i20_crtd_dtts}, 0, NULL,0, 'N', 0, 'E');";

            OdbcCommand cmd = new OdbcCommand(insertColumnsQuery + valuesQuery, connection);


            cmd.ExecuteNonQuery();

            connection.Close();

        }
    }
}
