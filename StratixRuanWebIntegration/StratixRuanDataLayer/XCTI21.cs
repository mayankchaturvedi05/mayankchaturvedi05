using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratixRuanDataLayer
{
    public class XCTI21
    {

        public string i21_cmpy_id { get; set; }
        public string i21_intchg_pfx { get; set; }
        public long i21_intchg_no { get; set; }
        public long i21_intchg_itm { get; set; }
        public string i21_crtd_dtts { get; set; }
        public long i21_crtd_dtms { get; set; }
        public string i21_upd_dtts { get; set; }
        public long i21_upd_dtms { get; set; }
        public string i21_transp_pfx { get; set; }
        public long i21_transp_no { get; set; }
        public string i21_actvy_pfx { get; set; }
        public long i21_actvy_no { get; set; }
        public long i21_actvy_itm { get; set; }
        public long i21_plnd_trs_pcs { get; set; }
        public double i21_plnd_trs_msr { get; set; }
        public double i21_plnd_trs_wgt { get; set; }
        public string i21_sts_cd { get; set; }
        public string i21_sprc_pfx { get; set; }
        public long i21_sprc_no { get; set; }
        public string i21_ven_shp_ref { get; set; }

        public static void PlanTransportActivity(XCTI21 transportActivityValues)
        {
            OdbcConnection connection = new OdbcConnection(GlobalState.StratixConnectionString);//64 bit
            connection.Open();


            string insertColumnsQueryForTransport = "INSERT INTO xcti21_rec" +
                                        "(" +
                                                    "i21_cmpy_id," +
                                                    "i21_intchg_pfx," +
                                                    "i21_intchg_no," +
                                                    "i21_intchg_itm," +
                                                    "i21_crtd_dtts," +
                                                    "i21_crtd_dtms," +
                                                    "i21_transp_pfx," +
                                                    "i21_transp_no," +
                                                    "i21_actvy_pfx," +
                                                    "i21_actvy_no," +
                                                    "i21_actvy_itm," +
                                                    "i21_plnd_trs_pcs," +
                                                    "i21_plnd_trs_msr," +
                                                    "i21_plnd_trs_wgt," +
                                                    "i21_sts_cd," +
                                                    "i21_sprc_pfx," +
                                                    "i21_sprc_no," +
                                                    "i21_ven_shp_ref" +
                                        ")";
            string valuesQueryForTransport = " VALUES" +
                                             "(" +
                                             "'HSP', " +
                                             "'XI'," +
                                             $"{transportActivityValues.i21_intchg_no}, " +
                                             $"'{transportActivityValues.i21_intchg_itm}', " +
                                             $"{transportActivityValues.i21_crtd_dtts}, " +
                                             "667," +
                                             "'TR'," +
                                             $"{transportActivityValues.i21_transp_no}, " +
                                             $"'{transportActivityValues.i21_actvy_pfx}', " +
                                             $"{transportActivityValues.i21_actvy_no}, " +
                                             $"{transportActivityValues.i21_actvy_itm}, " +
                                             $" {transportActivityValues.i21_plnd_trs_pcs}," +
                                             $"{transportActivityValues.i21_plnd_trs_msr}," +
                                             $"{transportActivityValues.i21_plnd_trs_wgt}," +
                                             " 'N', " +
                                             "''," +
                                             " 0," +
                                             " ''" +
                                             ");";

            string eventTableInsertQuery = " insert into xcti00_rec values" +
                                           "(" +
                                           $"'HSP', 'XI', {transportActivityValues.i21_intchg_no}, 'SCH', 'jcross', {transportActivityValues.i21_crtd_dtts}, 0, NULL,0, 'N', 0, 'E') ";

            ;


            OdbcCommand cmd = new OdbcCommand(insertColumnsQueryForTransport + valuesQueryForTransport + eventTableInsertQuery, connection);



            cmd.ExecuteNonQuery();

            connection.Close();

        }
    }
}