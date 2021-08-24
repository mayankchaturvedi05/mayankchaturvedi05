using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;


namespace StratixRuanDataLayer
{
    public class RuanBaseOrderIntegrationHelperData
    {

        public string poh_po_no { get; set; }
        public string poi_po_itm { get; set; }
        public string poi_ord_qty { get; set; }
        public string poi_ord_wgt_um { get; set; }
        public DateTime poh_po_pl_dt { get; set; }
        public string poh_ven_id { get; set; }
        public string poh_cmpy_id { get; set; }
        public string poh_po_brh { get; set; }
        public RuanBaseOrderIntegrationShipFromHelperData ship_from { get; set; }
        public RuanBaseOrderIntegrationShipToHelperData ship_To { get; set; }
        public RuanBaseOrderIntegrationPrdDescHelperData prd_desc { get; set; }

        public static List<RuanBaseOrderIntegrationHelperData> GetPurchaseOrderDataToConstructRuanOrderIntegrationXML(string orderReleaseNumber)
        {

            List<RuanBaseOrderIntegrationHelperData> mainObj = new List<RuanBaseOrderIntegrationHelperData>();

            RuanBaseOrderIntegrationHelperData result = null;

            string sql = $@"

                select poh_po_no, poi_po_itm, poi_ord_qty, poi_ord_wgt_um,
                poh_po_pl_dt,poh_cmpy_id,poh_ven_id,poh_po_brh from potpoh_rec, 
                potpoi_rec where poh_cmpy_id = poi_cmpy_id and 
                poh_po_pfx = poi_po_pfx and poh_po_no = poi_po_no 
                and poh_po_pfx  = 'PO' and poh_po_no = {orderReleaseNumber}";
            // and poh_cmpy_id = 'SQ1'

            OdbcConnection connection = new OdbcConnection(GlobalState.StratixConnectionString);//64 bit

            connection.Open();

            // Create an ODBC SQL command that will be executed below. Any SQL 
            // command that is valid with PostgreSQL is valid here (I think, 
            // but am not 100 percent sure. Every SQL command I've tried works).
            OdbcCommand command = new OdbcCommand(sql, connection);

            // Execute the SQL command and return a reader for navigating the results.
            OdbcDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);


            // This loop will output the entire contents of the results, iterating
            // through each row and through each field of the row.
            while (reader.Read())
            {
                result = new RuanBaseOrderIntegrationHelperData();

                result.poh_po_no = reader["poh_po_no"].ToString().Trim();
                result.poi_po_itm = reader["poi_po_itm"].ToString().Trim();
                result.poi_ord_qty = reader["poi_ord_qty"].ToString().Trim();
                result.poi_ord_wgt_um = reader["poi_ord_wgt_um"].ToString().Trim();
                result.poh_cmpy_id = reader["poh_cmpy_id"].ToString().Trim();
                result.poh_ven_id = reader["poh_ven_id"].ToString().Trim();
                result.poh_po_brh = reader["poh_po_brh"].ToString().Trim();
                object poh_po_pl_dt = reader["poh_po_pl_dt"];
                result.poh_po_pl_dt = Convert.ToDateTime(poh_po_pl_dt);

                mainObj.Add(result);

            }

            // Close the reader and connection (commands are not closed).
            reader.Close();
            connection.Close();

            foreach (var ord in mainObj)
            {
                ord.ship_from = GetShipFrom(ord.poh_po_no, ord.poh_cmpy_id, ord.poh_ven_id, ord.poh_po_brh);
                ord.ship_To = GetShipTo(ord.poh_po_no, ord.poh_cmpy_id, ord.poh_ven_id, ord.poh_po_brh);
                ord.prd_desc = GetPrdDesc(ord.poh_po_no,ord.poi_po_itm, ord.poh_cmpy_id);
            }

                return mainObj;
        }

        public static RuanBaseOrderIntegrationShipFromHelperData GetShipFrom(string orderReleaseNumber, string cmpyId, string venId, string brh)
        {
            RuanBaseOrderIntegrationShipFromHelperData result = new RuanBaseOrderIntegrationShipFromHelperData();
            //TODO: change hard code number to based on code.
            string sql = "select cva_cus_ven_id, cva_nm1, cva_addr1,";
                    sql += " cva_addr2, cva_addr3, cva_city, ";
                    sql += "    cva_st_prov, cva_pcd, cva_cty from scrcva_rec, potpoh_rec ";
                    sql += " where poh_cmpy_id = cva_cmpy_id and poh_shp_fm = cva_addr_no  ";
                    sql += " and poh_ven_id = cva_cus_ven_id ";
                    sql += "  and poh_shp_fm = 0 ";
                    sql += "  and poh_ven_id = '" + venId + "' and poh_po_pfx = 'PO' ";
                    sql += "   and poh_cmpy_id = '" + cmpyId + "'  ";
                    sql += "  and poh_po_brh = '" + brh + "' ";
                    sql += "  and poh_po_no  = '" + orderReleaseNumber +"' and cva_ref_pfx = 'VS'";
                        

            OdbcConnection connection = new OdbcConnection(GlobalState.StratixConnectionString);//64 bit

            connection.Open();
            
            OdbcCommand command = new OdbcCommand(sql, connection);

            // Execute the SQL command and return a reader for navigating the results.
            OdbcDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while (reader.Read())
            {
                result.cva_cus_ven_id = reader["cva_cus_ven_id"].ToString().Trim();
                result.cva_nm1 = reader["cva_nm1"].ToString().Trim();
                result.cva_addr1 = reader["cva_addr1"].ToString().Trim();
                result.cva_addr2 = reader["cva_addr2"].ToString().Trim();
                result.cva_addr3 = reader["cva_addr3"].ToString().Trim();
                result.cva_city = reader["cva_city"].ToString().Trim();
                result.cva_st_prov = reader["cva_st_prov"].ToString().Trim();
                result.cva_pcd = reader["cva_pcd"].ToString().Trim();
                result.cva_cty = reader["cva_cty"].ToString().Trim();

            }

            // Close the reader and connection (commands are not closed).
            reader.Close();
            connection.Close();
            
            return result;
        }


        public static RuanBaseOrderIntegrationShipToHelperData GetShipTo(string orderReleaseNumber, string cmpyId, string venId, string brh)
        {
            RuanBaseOrderIntegrationShipToHelperData result = new RuanBaseOrderIntegrationShipToHelperData();
            //TODO: change hard code number to based on code.
            string sql = " select brh_brh, brh_nm1, brh_addr1, brh_addr2, brh_addr3,";
                        sql += " brh_city, brh_st_prov, brh_pcd, brh_cty from scrbrh_Rec, potpoh_rec ";
                        sql += " where brh_cmpy_id = poh_cmpy_id and  brh_brh = poh_po_brh   ";
                        sql += "  and poh_ven_id = '" + venId + "' and poh_po_pfx = 'PO' ";
                        sql += "   and poh_cmpy_id = '" + cmpyId + "'  ";
                        sql += "  and poh_po_brh = '" + brh + "' ";
                        sql += "  and poh_po_no  = '" + orderReleaseNumber + "' ";

                        
            OdbcConnection connection = new OdbcConnection(GlobalState.StratixConnectionString);//64 bit

            connection.Open();

            OdbcCommand command = new OdbcCommand(sql, connection);

            // Execute the SQL command and return a reader for navigating the results.
            OdbcDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while (reader.Read())
            {
                result.brh_brh = reader["brh_brh"].ToString().Trim();
                result.brh_nm1 = reader["brh_nm1"].ToString().Trim();
                result.brh_addr1 = reader["brh_addr1"].ToString().Trim();
                result.brh_addr2 = reader["brh_addr2"].ToString().Trim();
                result.brh_addr3 = reader["brh_addr3"].ToString().Trim();
                result.brh_city = reader["brh_city"].ToString().Trim();
                result.brh_st_prov = reader["brh_st_prov"].ToString().Trim();
                result.brh_pcd = reader["brh_pcd"].ToString().Trim();
                result.brh_cty = reader["brh_cty"].ToString().Trim();


            }

            // Close the reader and connection (commands are not closed).
            reader.Close();
            connection.Close();

            return result;
        }


        public static RuanBaseOrderIntegrationPrdDescHelperData GetPrdDesc(string orderReleaseNumber , string item, string cmpyId)
        {
            RuanBaseOrderIntegrationPrdDescHelperData result = new RuanBaseOrderIntegrationPrdDescHelperData();


            //TODO: change hard code number to based on code.
            string sql = "select pds_prd_desc50a, pds_prd_desc50b, pds_prd_desc50c ";
            sql += "  from tctpds_rec ";
            sql += "   where pds_ref_pfx = 'PO' ";
            sql += "  and pds_cmpy_id =  '" + cmpyId + "'   ";
            sql += "  and pds_ref_no =  '" + orderReleaseNumber + "'  and  pds_ref_itm = '" + item + "'  ";
            // 
            OdbcConnection connection = new OdbcConnection(GlobalState.StratixConnectionString);//64 bit

            connection.Open();

            OdbcCommand command = new OdbcCommand(sql, connection);

            // Execute the SQL command and return a reader for navigating the results.
            OdbcDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                result.pds_prd_desc50a = reader["pds_prd_desc50a"].ToString().Trim();
                result.pds_prd_desc50b = reader["pds_prd_desc50b"].ToString().Trim();
                result.pds_prd_desc50c = reader["pds_prd_desc50c"].ToString().Trim();
               
            }

            // Close the reader and connection (commands are not closed).
            reader.Close();
            connection.Close();

            return result;
        }


    }
    }
