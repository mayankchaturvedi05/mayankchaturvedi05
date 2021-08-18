using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratixRuanDataLayer
{
    public class XCTI19
    {
        public string i19_cmpy_id { get; set; }
        public string i19_intchg_pfx { get; set; }
        public long i19_intchg_no { get; set; }
        public string i19_crtd_dtts { get; set; }
        public long i19_crtd_dtms { get; set; }
        public DateTime  i19_upd_dtts { get; set; }
        public long i19_upd_dtms { get; set; }
        public string i19_transp_pfx { get; set; }
        public long i19_transp_no { get; set; }
        public string i19_trrte { get; set; }
        public string i19_rte_clr { get; set; }
        public string i19_dlvy_mthd { get; set; }
        public string i19_frt_ven_id { get; set; }
        public string i19_crr_nm { get; set; }
        public string i19_frt_cry { get; set; }
        public double i19_frt_exrt { get; set; }
        public string i19_frt_ex_rt_typ { get; set; }
        public string i19_vcl_no { get; set; }
        public string i19_sch_rmk { get; set; }
        public string i19_lic_pl { get; set; }
        public string i19_drvr_1 { get; set; }
        public string i19_drvr_2 { get; set; }
        public long i19_trctr { get; set; }
        public string i19_trlr_no { get; set; }
        public string i19_trlr_typ { get; set; }
        public long i19_max_stp { get; set; }
        public double i19_max_wgt { get; set; }
        public double i19_max_wdth { get; set; }
        public double i19_max_lgth { get; set; }
        public string i19_appt_no { get; set; }
        public string i19_gt_dck { get; set; }
        public string i19_sch_dtts { get; set; }
        public long i19_sch_dtms { get; set; }
        public string i19_crr_ref_no { get; set; }

        public static void ModifyTransport(XCTI19 transportvalues)
        {
            OdbcConnection connection = new OdbcConnection(GlobalState.StratixConnectionString);//64 bit
            connection.Open();


            string insertColumnsQueryForTransport = "INSERT INTO xcti19_rec" +
                                        "(" +
                                        "i19_intchg_no," +
                                        "i19_crtd_dtts," +
                                        " i19_trrte," +
                                        "i19_dlvy_mthd," +
                                        "i19_cmpy_id," +
                                        "i19_intchg_pfx," +
                                        "i19_rte_clr," +
                                        "i19_crr_nm," +
                                        "i19_frt_exrt," +
                                        "i19_frt_ex_rt_typ," +
                                        "i19_sch_rmk," +
                                        "i19_lic_pl," +
                                        "i19_drvr_1," +
                                        "i19_drvr_2," +
                                        "i19_trctr," +
                                        "i19_trlr_typ," +
                                        "i19_max_stp," +
                                        "i19_max_wgt," +
                                        "i19_max_wdth," +
                                        "i19_max_lgth," +
                                        "i19_appt_no," +
                                        "i19_gt_dck," +
                                        "i19_transp_no," +
                                        "i19_crr_ref_no," +
                                        "i19_frt_cry," +
                                        "i19_frt_ven_id," +
                                        "i19_sch_dtts" +
                                        ")";
            string valuesQueryForTransport = " VALUES" +
                                             "(" +
                                             $"'{transportvalues.i19_intchg_no}', " +
                                             $"{transportvalues.i19_crtd_dtts}, " +
                                             $"'{transportvalues.i19_trrte}', " +
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
                                             $"{transportvalues.i19_max_stp}, " +
                                             $"{transportvalues.i19_max_wgt}, " +
                                             " 0," +
                                             " 0, " +
                                             "''," +
                                             " '', " +
                                             "0," +
                                             $"'{transportvalues.i19_crr_ref_no}', " +
                                             " 'USD', " +
                                             $"'', " +
                                             $"{transportvalues.i19_sch_dtts} " +
                                             ");";

            string eventTableInsertQuery = " insert into xcti00_rec values" +
                                           "(" +
                                           $"'HSP', 'XI', {transportvalues.i19_intchg_no}, 'CTN', 'skhan', {transportvalues.i19_crtd_dtts}, 0, NULL,0, 'N', 0, 'E') ";

            ;


            OdbcCommand cmd = new OdbcCommand(insertColumnsQueryForTransport + valuesQueryForTransport + eventTableInsertQuery, connection);



            cmd.ExecuteNonQuery();

            connection.Close();

        }
    }
}
