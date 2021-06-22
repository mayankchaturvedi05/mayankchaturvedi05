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

        public double? PartWidth { get; set; }
        public double? PartLength { get; set; }

        public string PartID { get; set; }
        public string PackagingCode { get; set; }

        public string LoadComments { get; set; }
        public string ShippingComments { get; set; }
        public string DeliveryComments { get; set; }

        public static TSRuanOrderIntegrationHelperData GetSalesOrderDataToConstructRuanOrderIntegrationXML(long orderReleaseNumber)
        {
            TSRuanOrderIntegrationHelperData result = new TSRuanOrderIntegrationHelperData();

           
            {
                string sql = $@"

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
	                 CommonOrderInformation.pds_prd_desc50b as OrderProductDescription2,
					 OrderCrossDetail.xrd_part as PartID,
                     PartDimension.ipd_wdth as PartWidth,
                     PartDimension.ipd_lgth as PartLength,
                     ItemPackaging.ipk_pkg as PackagingCode
                      
                      
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
                      INNER JOIN ORTXRD_REC OrderCrossDetail ON OrderCrossDetail.xrd_ord_no = OD.ord_ord_no AND OrderCrossDetail.xrd_ord_itm =  OD.ord_ord_itm
                      INNER JOIN CPRCLG_Rec PartMaster ON PartMaster.clg_Part = OrderCrossDetail.xrd_part 					  
					                   AND PartMaster.clg_cus_ven_typ = 'C' 
									   AND PartMaster.clg_cus_ven_id = CUST.cus_cus_id									   
									   AND OrderCrossDetail.xrd_part_revno = PartMaster.clg_part_revno
					  INNER JOIN TCTIPD_rec PartDimension ON PartDimension.ipd_ref_pfx = 'SO' 
					                  AND PartDimension.ipd_part_cus_id = CUST.cus_cus_id AND PartDimension.ipd_ref_no = OD.ord_ord_no
									  AND PartDimension.ipd_ref_itm   = OD.ord_ord_itm
                      INNER JOIN PNTIPK_rec ItemPackaging ON ItemPackaging.ipk_ref_pfx = 'SO'
					                AND ItemPackaging.ipk_ref_no = OD.ord_ord_no
									AND ItemPackaging.ipk_ref_itm = OD.ord_ord_itm
                      WHERE 1=1
                      AND OH.orh_ord_no= {orderReleaseNumber} ";

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
                    result.ShipFromID = reader["ShipFromName"].ToString().Trim();
                    result.ShipFromName = reader["ShipFromID"].ToString().Trim();
                    result.ShipFromAddress1 = reader["ShipFromAddress1"].ToString().Trim();
                    result.ShipFromAddress2 = reader["ShipFromAddress2"].ToString().Trim();
                    result.ShipFromAddress3 = reader["ShipFromAddress3"].ToString().Trim();
                    result.ShipFromCity = reader["ShipFromCity"].ToString().Trim();
                    result.ShipFromState = reader["ShipFromState"].ToString().Trim();
                    result.ShipFromZipCode = reader["ShipFromZipCode"].ToString().Trim();
                    result.ShipFromCountry = reader["ShipFromCountry"].ToString().Trim();

                    result.ShipToID = reader["ShipToName"].ToString().Trim();
                    result.ShipToName = reader["ShipToID"].ToString().Trim();
                    result.ShipToAddress1 = reader["ShipToAddress1"].ToString().Trim();
                    result.ShipToAddress2 = reader["ShipToAddress2"].ToString().Trim();
                    result.ShipToAddress3 = reader["ShipToAddress3"].ToString().Trim();
                    result.ShipToCity = reader["ShipToCity"].ToString().Trim();
                    result.ShipToState = reader["ShipToState"].ToString().Trim();
                    result.ShipToZipCode = reader["ShipToZipCode"].ToString().Trim();
                    result.ShipToCountry = reader["ShipToCountry"].ToString().Trim();

                    result.SoldToID = reader["SoldToName"].ToString().Trim();
                    result.SoldToName = reader["SoldToID"].ToString().Trim();
                    result.SoldToAddress1 = reader["SoldToAddress1"].ToString().Trim();
                    result.SoldToAddress2 = reader["SoldToAddress2"].ToString().Trim();
                    result.SoldToAddress3 = reader["SoldToAddress3"].ToString().Trim();
                    result.SoldToCity = reader["SoldToCity"].ToString().Trim();
                    result.SoldToState = reader["SoldToState"].ToString().Trim();
                    result.SoldToZipCode = reader["SoldToZipCode"].ToString().Trim();
                    result.SoldToCountry = reader["SoldToCountry"].ToString().Trim();
                    result.CustomerPO = reader["CustomerPO"].ToString().Trim();

                    result.InsideSalesPersonName = reader["InsideSalesPersonName"].ToString().Trim();
                    result.InsideSalesPersonEmail = reader["InsideSalesPersonEmail"].ToString().Trim();

                    object salesOrderReleaseNumber = reader["SalesOrderReleaseNumber"];
                    result.SalesOrderReleaseNumber = Convert.ToInt64(salesOrderReleaseNumber);

                    object releaseWeight= reader["ReleaseWeight"];
                    result.ReleaseWeight = Convert.ToDouble(releaseWeight);

                    object orderDeliveryDateFrom = reader["OrderDeliveryDateFrom"];
                    result.OrderDeliveryDateFrom = Convert.ToDateTime(orderDeliveryDateFrom);

                    object orderDeliveryDateTo = reader["OrderDeliveryDateTo"];
                    result.OrderDeliveryDateTo = Convert.ToDateTime(orderDeliveryDateTo);

                    result.OrderProductDescription1 = reader["OrderProductDescription1"].ToString().Trim();
                    result.OrderProductDescription2 = reader["OrderProductDescription2"].ToString().Trim();
                    result.PartID = reader["PartID"].ToString().Trim();

                    object partWidth = reader["PartWidth"];
                    result.PartWidth = Convert.ToDouble(partWidth);

                    object partLength = reader["PartLength"];
                    result.PartLength = Convert.ToDouble(partLength);
                    result.PackagingCode = reader["PackagingCode"].ToString().Trim();
                }

                // Close the reader and connection (commands are not closed).
                reader.Close();
                connection.Close();

                
            }

            result.LoadComments = GetOrderHeaderLoadComment(orderReleaseNumber);
            result.ShippingComments = GetOrderHeaderShippingComment(orderReleaseNumber);
            result.DeliveryComments = GetOrderDetailDeliveryComment(orderReleaseNumber);

            return result;
        }

        public static string GetOrderHeaderLoadComment(long orderReleaseNumber)
        {
            string loadComment = string.Empty;
                //TODO: change hard code number to based on code.
                string sql = $@"

                       SELECT tsi_txt
                            FROM TCTTSI_REC
                                WHERE tsi_ref_pfx = 'SO' AND tsi_cmpy_id = 'HSP' AND tsi_rmk_typ = '20' AND tsi_ref_itm = 0
                                AND tsi_ref_no =  {orderReleaseNumber} ";
                

                OdbcConnection connection = new OdbcConnection(GlobalState.StratixConnectionString);//64 bit

                connection.Open();


                OdbcCommand command = new OdbcCommand(sql, connection);

                // Execute the SQL command and return a reader for navigating the results.
                OdbcDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

              
                while (reader.Read())
                {
                    loadComment = reader["tsi_txt"].ToString().Trim();
                  
                }

                // Close the reader and connection (commands are not closed).
                reader.Close();
                connection.Close();



            return loadComment;
        }

        public static string GetOrderHeaderShippingComment(long orderReleaseNumber)
        {
            string shippingComment = string.Empty;
            //TODO: change hard code number to based on code.
            string sql = $@"

                       SELECT tsi_txt
                            FROM TCTTSI_REC
                                WHERE tsi_ref_pfx = 'SO' AND tsi_cmpy_id = 'HSP' AND tsi_rmk_typ = '22' AND tsi_ref_itm = 0
                                AND tsi_ref_no =  {orderReleaseNumber} ";


                OdbcConnection connection = new OdbcConnection(GlobalState.StratixConnectionString);//64 bit

                connection.Open();


                OdbcCommand command = new OdbcCommand(sql, connection);

                // Execute the SQL command and return a reader for navigating the results.
                OdbcDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);


                while (reader.Read())
                {
                    shippingComment = reader["tsi_txt"].ToString().Trim();

                }

                // Close the reader and connection (commands are not closed).
                reader.Close();
                connection.Close();


            return shippingComment;
        }

        public static string GetOrderDetailDeliveryComment(long orderReleaseNumber)
        {
            string deliveryComments = string.Empty;
            //TODO: change hard code number to based on code.
            string sql = $@"

                       SELECT tsi_txt
                            FROM TCTTSI_REC
                                WHERE tsi_ref_pfx = 'SO' AND tsi_cmpy_id = 'HSP' AND tsi_rmk_typ = '65' AND tsi_ref_itm = 0
                                AND tsi_ref_no =  {orderReleaseNumber} ";


            OdbcConnection connection = new OdbcConnection(GlobalState.StratixConnectionString);//64 bit

            connection.Open();


            OdbcCommand command = new OdbcCommand(sql, connection);

            // Execute the SQL command and return a reader for navigating the results.
            OdbcDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);


            while (reader.Read())
            {
                deliveryComments = reader["tsi_txt"].ToString().Trim();

            }

            // Close the reader and connection (commands are not closed).
            reader.Close();
            connection.Close();



            return deliveryComments;
        }
    }
}
