using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratixRuanDataLayer
{
    public class XCTI18
    {
        public string i18_cmpy_id { get; set; }
        public string i18_intchg_pfx { get; set; }
        public long i18_intchg_no { get; set; }
        public string i18_crtd_dtts { get; set; }
        public long i18_crtd_dtms { get; set; }
        public DateTime i18_upd_dtts { get; set; }
        public long i18_upd_dtms { get; set; }
        public string i18_trpln_whs { get; set; }
        public string i18_trrte { get; set; }
        public string i18_rte_clr { get; set; }
        public string i18_dlvy_mthd { get; set; }
        public string i18_frt_ven_id { get; set; }
        public string i18_crr_nm { get; set; }
        public string i18_frt_cry { get; set; }
        public double i18_frt_exrt { get; set; }
        public string i18_frt_ex_rt_typ { get; set; }
        public string i18_vcl_no { get; set; }
        public string i18_sch_rmk { get; set; }
        public string i18_lic_pl { get; set; }
        public string i18_drvr_1 { get; set; }
        public string i18_drvr_2 { get; set; }
        public long i18_trctr { get; set; }
        public string i18_trlr_no { get; set; }
        public string i18_trlr_typ { get; set; }
        public long i18_max_stp { get; set; }
        public double i18_max_wgt { get; set; }
        public double i18_max_wdth { get; set; }
        public double i18_max_lgth { get; set; }
        public string i18_appt_no { get; set; }
        public string i18_gt_dck { get; set; }
        public string i18_sch_dtts { get; set; }
        public long i18_sch_dtms { get; set; }
        public string i18_transp_pfx { get; set; }
        public long i18_transp_no { get; set; }
        public string i18_crr_ref_no { get; set; }



        public static void AddTransportForSalesOrderAndTransfer(XCTI18 transportvalues)
        {
            OdbcConnection connection = new OdbcConnection(GlobalState.StratixConnectionString);//64 bit
            connection.Open();

            //TODO: pass in the values thru the XCTI18 object, Username from config etc
            string insertColumnsQueryForTransport = "INSERT INTO xcti18_rec" +
                                        "(" +
                                        "i18_intchg_no," +
                                        "i18_crtd_dtts," +
                                        " i18_trpln_whs," +
                                        " i18_trrte," +
                                        "i18_dlvy_mthd," +
                                        "i18_cmpy_id," +
                                        "i18_intchg_pfx," +
                                        "i18_rte_clr," +
                                        "i18_crr_nm," +
                                        "i18_frt_exrt," +
                                        "i18_frt_ex_rt_typ," +
                                        "i18_sch_rmk," +
                                        "i18_lic_pl," +
                                        "i18_drvr_1," +
                                        "i18_drvr_2," +
                                        "i18_trctr," +
                                        "i18_trlr_typ," +
                                        "i18_max_stp," +
                                        "i18_max_wgt," +
                                        "i18_max_wdth," +
                                        "i18_max_lgth," +
                                        "i18_appt_no," +
                                        "i18_gt_dck," +
                                        "i18_transp_no," +
                                        "i18_crr_ref_no," +
                                        "i18_frt_cry," +
                                        "i18_frt_ven_id," +
                                        "i18_sch_dtts" +
                                        ")";
            string valuesQueryForTransport = " VALUES" +
                                             "(" +
                                             $"'{transportvalues.i18_intchg_no}', " +
                                             $"{transportvalues.i18_crtd_dtts}, " +
                                             $"'{transportvalues.i18_trpln_whs}', " +
                                             $"'{transportvalues.i18_trrte}', " +
                                             "'OC', " +
                                             "'HSP', " +
                                             "'XI'," +
                                             " ''," +
                                             " 'RUAN'," +
                                             " 1.00000000," +
                                             " 'V'," +
                                             " ''," +
                                             " ''," +
                                             " '', " +
                                             "''," +
                                             " 1," +
                                             " 'CC'," +
                                             $"{transportvalues.i18_max_stp}, " +
                                             $"{transportvalues.i18_max_wgt}, " +
                                             " 0," +
                                             " 0, " +
                                             "''," +
                                             " '', " +
                                             "0," +
                                             $"'{transportvalues.i18_crr_ref_no}', " +
                                             " 'USD', " +
                                             $"'', " +
                                             $"{transportvalues.i18_sch_dtts} " +
                                             ");";

            string eventTableInsertQuery = " insert into xcti00_rec values" +
                                           "(" +
                                           $"'HSP', 'XI', {transportvalues.i18_intchg_no}, 'ATN', 'skhan', {transportvalues.i18_crtd_dtts}, 0, NULL,0, 'N', 0, 'E') ";

            ;


            OdbcCommand cmd = new OdbcCommand(insertColumnsQueryForTransport  + valuesQueryForTransport + eventTableInsertQuery, connection);



            cmd.ExecuteNonQuery();

            connection.Close();
           
        }

    }
}
