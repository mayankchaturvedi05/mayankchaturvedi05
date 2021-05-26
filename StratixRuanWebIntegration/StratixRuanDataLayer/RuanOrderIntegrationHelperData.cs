using System;

using System.Data;
using System.Data.Odbc;


namespace StratixRuanDataLayer
{
    public class TSRuanOrderIntegrationHelperData
    {
        public long SalesOrderReleaseNumber { get; set; }
        public string InsideSalesPersonName { get; set; }
        public string InsideSalesPersonEmail { get; set; }
        public string ShipFromID { get; set; }
        public string ShipFromName { get; set; }
        public string ShipFromAddress1 { get; set; }
        public string ShipFromAddress2 { get; set; }
        public string ShipFromAddress3 { get; set; }
        public string ShipFromCity { get; set; }
        public string ShipFromState { get; set; }
        public string ShipFromZipCode { get; set; }
        public string ShipFromCountry { get; set; }

        public string SoldToID { get; set; }
        public string SoldToName { get; set; }
        public string SoldToAddress1 { get; set; }
        public string SoldToAddress2 { get; set; }
        public string SoldToAddress3 { get; set; }
        public string SoldToCity { get; set; }
        public string SoldToState { get; set; }
        public string SoldToZipCode { get; set; }
        public string SoldToCountry { get; set; }

        public string ShipToID { get; set; }
        public string ShipToName { get; set; }
        public string ShipToName2 { get; set; }
        public string ShipToAddress1 { get; set; }
        public string ShipToAddress2 { get; set; }
        public string ShipToAddress3 { get; set; }
        public string ShipToCity { get; set; }
        public string ShipToState { get; set; }
        public string ShipToZipCode { get; set; }
        public string ShipToCountry { get; set; }
        public double ReleaseWeight { get; set; }
        public  string CustomerPO { get; set; }
        public DateTime OrderDeliveryDateFrom { get; set; }
        public DateTime OrderDeliveryDateTo { get; set; }

        public string OrderProductDescription1 { get; set; }
        public string OrderProductDescription2 { get; set; }

        public static TSRuanOrderIntegrationHelperData GetSalesOrderDataToConstructRuanOrderIntegrationXML(long orderReleaseNumber)
        {
            TSRuanOrderIntegrationHelperData result = new TSRuanOrderIntegrationHelperData();

           
            {
                string sql = @"

                      SELECT
                      PLANT_SHIP_FROM.whs_whs as ShipFromID,
                      PLANT_SHIP_FROM.whs_whs_nm AS ShipFromName,
                      PLANT_SHIP_FROM.whs_addr1 AS ShipFromAddress1,
                      PLANT_SHIP_FROM.whs_addr2 AS ShipFromAddress2,
                      PLANT_SHIP_FROM.whs_addr3 AS ShipFromAddress3,
                      PLANT_SHIP_FROM.whs_city AS ShipFromCity,
                      PLANT_SHIP_FROM.whs_st_prov AS ShipFromState,
                      PLANT_SHIP_FROM.whs_pcd AS ShipFromZipCode,
                      PLANT_SHIP_FROM.whs_cty AS ShipFromCountry,
                      
                      CUST_SHIP_ADDRESS.cva_addr_no AS ShipToID,
                      CUST_SHIP_ADDRESS.cva_nm1 AS ShipToName,
                      CUST_SHIP_ADDRESS.cva_addr1 AS ShipToAddress1,
                      CUST_SHIP_ADDRESS.cva_addr2 AS ShipToAddress2,
                      CUST_SHIP_ADDRESS.cva_addr3 AS ShipToAddress3,
                      CUST_SHIP_ADDRESS.cva_city AS ShipToCity,
                      CUST_SHIP_ADDRESS.cva_st_prov AS ShipToState,
                      CUST_SHIP_ADDRESS.cva_pcd AS ShipToZipCode,
                      CUST_SHIP_ADDRESS.cva_cty AS ShipToCountry,
                      
                      CUST.cus_cus_id as SoldToID,
                      CUST.cus_cus_nm AS SoldToName,
                      CUST_BILL_ADDRESS.cva_addr1 AS SoldToAddress1,
                      CUST_BILL_ADDRESS.cva_addr2 AS SoldToAddress2,
                      CUST_BILL_ADDRESS.cva_addr3 AS SoldToAddress3,
                      CUST_BILL_ADDRESS.cva_city AS SoldToCity,
                      CUST_BILL_ADDRESS.cva_st_prov AS SoldToState,
                      CUST_BILL_ADDRESS.cva_pcd AS SoldToZipCode,
                      CUST_BILL_ADDRESS.cva_cty AS SoldToCountry,

                      ORL.orl_ord_no AS SalesOrderReleaseNumber,
					  ORL.orl_rls_wgt AS ReleaseWeight,
					  ORL.orl_due_fm_dt AS OrderDeliveryDateFrom,
					  ORL.orl_due_to_dt AS OrderDeliveryDateTo,
                      OD.ord_cus_po AS CustomerPO,
                   
                     SalesPersonLoginDetail.usr_nm as InsideSalesPersonName,
                     SalesPersonLoginDetail.usr_email as InsideSalesPersonEmail,

                     CommonOrderInformation.pds_prd_desc50a as OrderProductDescription1,
	                 CommonOrderInformation.pds_prd_desc50b as OrderProductDescription2
                      
                      
                      
                      FROM
                      ORTORH_REC OH
                      INNER JOIN ORTORD_REC OD ON OH.orh_ord_no = OD.ord_ord_no
                      INNER JOIN ORTORL_REC ORL ON OD.ord_ord_no = ORL.orl_ord_no
                      INNER JOIN ARRCUS_REC CUST ON CUST.cus_cus_id = OH.orh_sld_cus_id
                      INNER JOIN ARRSHP_REC SHIPTO ON CUST.cus_cus_id = SHIPTO.shp_cus_id AND OH.orh_shp_to = SHIPTO.shp_shp_to
                      INNER JOIN SCRCVA_REC CUST_BILL_ADDRESS ON CUST_BILL_ADDRESS.cva_ref_pfx = 'CU' AND CUST_BILL_ADDRESS.cva_cus_ven_typ = 'C'
                                                              AND CUST_BILL_ADDRESS.cva_cus_ven_id = CUST.cus_cus_id
                      INNER JOIN SCRCVA_REC CUST_SHIP_ADDRESS ON CUST_SHIP_ADDRESS.cva_ref_pfx = 'CS' AND CUST_SHIP_ADDRESS.cva_cus_ven_typ = 'C'
                      										AND CUST_SHIP_ADDRESS.cva_addr_typ = 'S'
                                                              AND CUST_SHIP_ADDRESS.cva_cus_ven_id = CUST.cus_cus_id 
                      										AND CUST_SHIP_ADDRESS.cva_addr_no = OH.orh_shp_to
                      INNER JOIN SCRSLP_rec SalesPersonLogin ON SalesPersonLogin.slp_slp = SHIPTO.shp_is_slp
					  INNER JOIN MXRUSR_REC SalesPersonLoginDetail ON SalesPersonLoginDetail.usr_lgn_id = SalesPersonLogin.slp_lgn_id
                      INNER JOIN SCRWHS_REC PLANT_SHIP_FROM ON PLANT_SHIP_FROM.whs_whs = ORL.orl_shpg_whs
                      INNER JOIN TCTPDS_rec CommonOrderInformation ON CommonOrderInformation.pds_ref_pfx = 'SO' 
					                                      AND CommonOrderInformation.pds_ref_no = OD.ord_ord_no  AND CommonOrderInformation.pds_ref_itm = OD.ord_ord_itm
                      WHERE 1=1
                      AND OH.orh_ord_no= 661 ";

                OdbcConnection connection = new OdbcConnection("DSN=PostgreSQL30");//64 bit

                connection.Open();
                


                // Create an ODBC SQL command that will be executed below. Any SQL 
                // command that is valid with PostgreSQL is valid here (I think, 
                // but am not 100 percent sure. Every SQL command I've tried works).
                string query = "select * from scrcva_rec where cva_cus_ven_id = '5142'";
                OdbcCommand command = new OdbcCommand(sql, connection);


                // Execute the SQL command and return a reader for navigating the results.
                OdbcDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);


                // This loop will output the entire contents of the results, iterating
                // through each row and through each field of the row.
                while (reader.Read() == true)
                {
                    result.ShipFromID = reader["ShipFromName"].ToString();
                    result.ShipFromName = reader["ShipFromID"].ToString();
                    result.ShipFromAddress1 = reader["ShipFromAddress1"].ToString();
                    result.ShipFromAddress2 = reader["ShipFromAddress2"].ToString();
                    result.ShipFromAddress3 = reader["ShipFromAddress3"].ToString();
                    result.ShipFromCity = reader["ShipFromCity"].ToString();
                    result.ShipFromState = reader["ShipFromState"].ToString();
                    result.ShipFromZipCode = reader["ShipFromZipCode"].ToString();
                    result.ShipFromCountry = reader["ShipFromCountry"].ToString();

                    result.ShipToID = reader["ShipToName"].ToString();
                    result.ShipToName = reader["ShipToID"].ToString();
                    result.ShipToAddress1 = reader["ShipToAddress1"].ToString();
                    result.ShipToAddress2 = reader["ShipToAddress2"].ToString();
                    result.ShipToAddress3 = reader["ShipToAddress3"].ToString();
                    result.ShipToCity = reader["ShipToCity"].ToString();
                    result.ShipToState = reader["ShipToState"].ToString();
                    result.ShipToZipCode = reader["ShipToZipCode"].ToString();
                    result.ShipToCountry = reader["ShipToCountry"].ToString();

                    result.SoldToID = reader["SoldToName"].ToString();
                    result.SoldToName = reader["SoldToID"].ToString();
                    result.SoldToAddress1 = reader["SoldToAddress1"].ToString();
                    result.SoldToAddress2 = reader["SoldToAddress2"].ToString();
                    result.SoldToAddress3 = reader["SoldToAddress3"].ToString();
                    result.SoldToCity = reader["SoldToCity"].ToString();
                    result.SoldToState = reader["SoldToState"].ToString();
                    result.SoldToZipCode = reader["SoldToZipCode"].ToString();
                    result.SoldToCountry = reader["SoldToCountry"].ToString();
                    result.CustomerPO = reader["CustomerPO"].ToString();

                    result.InsideSalesPersonName = reader["InsideSalesPersonName"].ToString();
                    result.InsideSalesPersonEmail = reader["InsideSalesPersonEmail"].ToString();

                    object salesOrderReleaseNumber = reader["SalesOrderReleaseNumber"];
                    result.SalesOrderReleaseNumber = Convert.ToInt64(salesOrderReleaseNumber);

                    object releaseWeight= reader["ReleaseWeight"];
                    result.ReleaseWeight = Convert.ToDouble(releaseWeight);

                    object orderDeliveryDateFrom = reader["OrderDeliveryDateFrom"];
                    result.OrderDeliveryDateFrom = Convert.ToDateTime(orderDeliveryDateFrom);

                    object orderDeliveryDateTo = reader["OrderDeliveryDateTo"];
                    result.OrderDeliveryDateTo = Convert.ToDateTime(orderDeliveryDateTo);

                    result.OrderProductDescription1 = reader["OrderProductDescription1"].ToString();
                    result.OrderProductDescription2 = reader["OrderProductDescription2"].ToString();
                }

                // Close the reader and connection (commands are not closed).
                reader.Close();
                connection.Close();

                
            }

            return result;
        }
    }
}
