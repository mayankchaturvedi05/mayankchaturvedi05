﻿using System;

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
        
        public Int16 EarliestDueDateTolerance { get; set; }

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
        public Int16 OrderDeliveryDateFromHour { get; set; }
        public Int16 OrderDeliveryDateToHour { get; set; }

        public string OrderProductDescription1 { get; set; }
        public string OrderProductDescription2 { get; set; }

        public double? PartWidth { get; set; }
        public double? PartLength { get; set; }

        public string PartID { get; set; }
        public string PackagingCode { get; set; }

        public string LoadComments { get; set; }
        public string ShippingComments { get; set; }
        public string DeliveryComments { get; set; }

        public string tav_trgt_ord_pfx { get; set; }
        public Int16 tav_trgt_ord_itm { get; set; }
        public Int16 tav_trgt_ord_rls { get; set; }
        public string tav_ref_pfx { get; set; }
        public long tav_ref_no { get; set; }
        public string tav_jbs_pfx { get; set; }
        public long tav_jbs_no { get; set; }
        public DateTime? ShipDateTimeEarly { get; set; }



        public static TSRuanOrderIntegrationHelperData GetSalesOrderDataToConstructRuanOrderIntegrationXML(long orderNumber, Int16 orderItemNumber, Int16 orderSubItemNumber)
        {
            TSRuanOrderIntegrationHelperData result = new TSRuanOrderIntegrationHelperData();

           
            {
                string sql = $@"

                      SELECT
                      DISTINCT
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
                      CUSTAdditional.cai_edue_dt_tol as EarliestDueDateTolerance,
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
                      ORL.orl_due_fm_hr AS OrderDeliveryDateFromHour,
					  ORL.orl_due_to_hr AS OrderDeliveryDateToHour,
                      tav.tav_rdy_by_ltts AS ShipDateTimeEarly,
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
					  TRTTAV_rec TAV
					  INNER JOIN ORTORL_REC ORL  ON ORL.orl_ord_no = TAV.tav_trgt_ord_no AND ORL.orl_ord_itm = TAV.tav_trgt_ord_itm AND ORL.orl_ord_rls_no = TAV.tav_trgt_ord_rls
                      INNER JOIN ORTORD_REC OD ON ORL.orl_ord_no = OD.ord_ord_no
                      INNER JOIN ORTORH_REC OH ON OH.orh_ord_no = ORL.orl_ord_no
                      INNER JOIN ARRCUS_REC CUST ON CUST.cus_cus_id = OH.orh_sld_cus_id
                      INNER JOIN ARRCAI_REC CUSTAdditional ON CustAdditional.cai_cus_id = CUST.cus_cus_id AND CUST.CUS_CMPY_ID = CustAdditional.CAI_CMPY_ID
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
                      LEFT OUTER JOIN PNTIPK_rec ItemPackaging ON ItemPackaging.ipk_ref_pfx = 'SO'
					                AND ItemPackaging.ipk_ref_no = OD.ord_ord_no
									AND ItemPackaging.ipk_ref_itm = OD.ord_ord_itm
                      WHERE 1=1
                      AND ORL.orl_ord_no= {orderNumber} AND ORL.orl_ord_itm = {orderItemNumber} AND ORL.orl_ord_rls_no = {orderSubItemNumber} AND tav_trac_typ = 'SH'";

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

                    object earliestDueDateTolerance = reader["EarliestDueDateTolerance"];
                    result.EarliestDueDateTolerance = Convert.ToInt16(earliestDueDateTolerance);

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

                    object orderDeliveryDateFromHour = reader["OrderDeliveryDateFromHour"];
                    result.OrderDeliveryDateFromHour = Convert.ToInt16(orderDeliveryDateFromHour);

                    object orderDeliveryDateToHour = reader["OrderDeliveryDateToHour"];
                    result.OrderDeliveryDateToHour = Convert.ToInt16(orderDeliveryDateToHour);

                    object shipDateTimeEarly = reader["tav_rdy_by_ltts"];
                    if (shipDateTimeEarly != null)
                    {
                        result.ShipDateTimeEarly = Convert.ToDateTime(shipDateTimeEarly);
                    }

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

            result.LoadComments = GetOrderHeaderLoadComment(orderNumber);
            result.ShippingComments = GetOrderHeaderShippingComment(orderNumber);
            result.DeliveryComments = GetOrderDetailDeliveryComment(orderNumber);

            return result;
        }

        public static TSRuanOrderIntegrationHelperData GetTransferDataToConstructRuanOrderIntegrationXML(string keyPfx, long? keyNumber)
        {
            TSRuanOrderIntegrationHelperData result = new TSRuanOrderIntegrationHelperData();


            {
                string whereClause = string.Empty;

                if (keyPfx.Equals("IP"))
                {
                    whereClause = $@" AND tav_ref_pfx = '{keyPfx}' and tav_ref_no = {keyNumber}";
                }
                else if(keyPfx.Equals("JS"))
                {
                    whereClause = $@" AND tav_jbs_pfx = '{keyPfx}' and tav_jbs_no = {keyNumber}";
                }

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
									
									PLANT_SHIP_TO.whs_whs as ShipToID,
                      				PLANT_SHIP_TO.whs_whs AS ShipToName,
                      				PLANT_SHIP_TO.whs_addr1 AS ShipToAddress1,
                      				PLANT_SHIP_TO.whs_addr2 AS ShipToAddress2,
                      				PLANT_SHIP_TO.whs_addr3 AS ShipToAddress3,
                      				PLANT_SHIP_TO.whs_city AS ShipToCity,
                      				PLANT_SHIP_TO.whs_st_prov AS ShipToState,
                      				PLANT_SHIP_TO.whs_pcd AS ShipToZipCode,
                      				PLANT_SHIP_TO.whs_cty AS ShipToCountry,
									
									0 as EarliestDueDateTolerance,
									
									SOLD_TO.whs_whs as SoldToID,
                      				SOLD_TO.whs_whs AS SoldToName,                      
                      				SOLD_TO.whs_addr1 AS SoldToAddress1,
                      				SOLD_TO.whs_addr2 AS SoldToAddress2,
                      				SOLD_TO.whs_addr3 AS SoldToAddress3,
                      				SOLD_TO.whs_city AS SoldToCity,
                      				SOLD_TO.whs_st_prov AS SoldToState,
                      				SOLD_TO.whs_pcd AS SoldToZipCode,
                      				SOLD_TO.whs_cty AS SoldToCountry,									
									
					  				tav.tav_reqd_wgt AS ReleaseWeight,
									tav.tav_trgt_ord_pfx, tav.tav_trgt_ord_no AS SalesOrderReleaseNumber, tav.tav_trgt_ord_itm,  tav.tav_trgt_ord_rls,
									tav_ref_pfx, tav_ref_no,
                                    tav_jbs_pfx, tav_jbs_no,
                                    tav.tav_rdy_by_ltts AS ShipDateTimeEarly,
					  				tav.tav_actvy_dtts AS OrderDeliveryDateFrom,
					  				tav.tav_actvy_dtts AS OrderDeliveryDateTo,
                      				0 AS OrderDeliveryDateFromHour,
					  				0 AS OrderDeliveryDateToHour,
                      				'' AS CustomerPO,
                   
                                    '' as InsideSalesPersonName,
                                    '' as InsideSalesPersonEmail,
									'' as OrderProductDescription1,
	                                '' as OrderProductDescription2,
					                '' as PartID,
                                    '' as PackagingCode,
									TAV.tav_wdth as PartWidth,
                                    TAV.tav_lgth as PartLength
							     FROM TRTTAV_rec TAV
								 INNER JOIN SCRWHS_REC PLANT_SHIP_FROM ON TAV.tav_pkp_whs = PLANT_SHIP_FROM.whs_whs AND PLANT_SHIP_FROM.whs_cmpy_id = 'HSP'
								 INNER JOIN SCRWHS_REC PLANT_SHIP_TO ON TAV.tav_dlvy_whs = PLANT_SHIP_TO.whs_whs AND PLANT_SHIP_TO.whs_cmpy_id = 'HSP'
								 INNER JOIN SCRWHS_REC SOLD_TO ON TAV.tav_plng_whs = SOLD_TO.whs_whs AND SOLD_TO.whs_cmpy_id = 'HSP'
							     WHERE tav_trac_typ = 'TF'";
                sql = sql + whereClause;

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

                    object earliestDueDateTolerance = reader["EarliestDueDateTolerance"];
                    result.EarliestDueDateTolerance = Convert.ToInt16(earliestDueDateTolerance);

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

                    object releaseWeight = reader["ReleaseWeight"];
                    result.ReleaseWeight = Convert.ToDouble(releaseWeight);

                    object orderDeliveryDateFrom = reader["OrderDeliveryDateFrom"];
                    result.OrderDeliveryDateFrom = Convert.ToDateTime(orderDeliveryDateFrom);

                    object orderDeliveryDateTo = reader["OrderDeliveryDateTo"];
                    result.OrderDeliveryDateTo = Convert.ToDateTime(orderDeliveryDateTo);

                    object orderDeliveryDateFromHour = reader["OrderDeliveryDateFromHour"];
                    result.OrderDeliveryDateFromHour = Convert.ToInt16(orderDeliveryDateFromHour);

                    object orderDeliveryDateToHour = reader["OrderDeliveryDateToHour"];
                    result.OrderDeliveryDateToHour = Convert.ToInt16(orderDeliveryDateToHour);

                    object shipDateTimeEarly = reader["tav_rdy_by_ltts"];
                    if (shipDateTimeEarly != null)
                    {
                        result.ShipDateTimeEarly = Convert.ToDateTime(shipDateTimeEarly);
                    }


                    if (reader["OrderProductDescription1"] != null)
                    {
                        result.OrderProductDescription1 = reader["OrderProductDescription1"].ToString().Trim();
                    }

                    if (reader["OrderProductDescription2"] != null)
                    {
                        result.OrderProductDescription2 = reader["OrderProductDescription2"].ToString().Trim();
                    }

                    if (reader["PartID"] != null)
                    {
                        result.PartID = reader["PartID"].ToString().Trim();
                    }
                    
                    object partWidth = reader["PartWidth"];
                    if (partWidth != null)
                    {
                        result.PartWidth = Convert.ToDouble(partWidth);
                    }

                    object partLength = reader["PartLength"];
                    if (partLength != null)
                    {
                        result.PartLength = Convert.ToDouble(partLength);
                    }

                    if (reader["PackagingCode"] != null)
                    {
                        result.PackagingCode = reader["PackagingCode"].ToString().Trim();
                    }

                    result.tav_trgt_ord_pfx = reader["tav_trgt_ord_pfx"].ToString().Trim(); 

                    object tav_trgt_ord_itm = reader["tav_trgt_ord_itm"];
                    result.tav_trgt_ord_itm = Convert.ToInt16(tav_trgt_ord_itm);

                    object tav_trgt_ord_rls = reader["tav_trgt_ord_rls"];
                    result.tav_trgt_ord_rls = Convert.ToInt16(tav_trgt_ord_rls);

                    result.tav_ref_pfx = reader["tav_ref_pfx"].ToString().Trim(); 
                    
                    object tav_ref_no = reader["tav_ref_no"];
                    result.tav_ref_no = Convert.ToInt64(tav_ref_no);

                    result.tav_jbs_pfx = reader["tav_jbs_pfx"].ToString().Trim(); 

                    object tav_jbs_no = reader["tav_jbs_no"];
                    result.tav_jbs_no = Convert.ToInt64(tav_jbs_no);
                }

                // Close the reader and connection (commands are not closed).
                reader.Close();
                connection.Close();


            }

            result.LoadComments = string.Empty;
            result.ShippingComments = string.Empty;
            result.DeliveryComments = string.Empty;

            return result;
        }

        public static string GetOrderHeaderLoadComment(long orderReleaseNumber)
        {
            string loadComment = string.Empty;
                //TODO: change hard code number to based on code.
                string sql = $@"

                       SELECT T.tsi_txt
                            FROM TCTTSI_REC T
							INNER JOIN RPRCDS_REC R ON T.tsi_rmk_typ = R.cds_cd
                                WHERE T.tsi_ref_pfx = 'SO' AND T.tsi_cmpy_id = 'HSP' AND T.tsi_ref_itm = 0
								AND cds_data_el_nm = 'RMK-TYP' 
								AND cds_lng = 'en' and cds_desc = 'Loading'
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

                       SELECT T.tsi_txt
                            FROM TCTTSI_REC T
							INNER JOIN RPRCDS_REC R ON T.tsi_rmk_typ = R.cds_cd
                                WHERE T.tsi_ref_pfx = 'SO' AND T.tsi_cmpy_id = 'HSP' AND T.tsi_ref_itm = 0
								AND cds_data_el_nm = 'RMK-TYP' 
								AND cds_lng = 'en' and cds_desc = 'Shp/Receiving'
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

                        SELECT T.tsi_txt
                            FROM TCTTSI_REC T
							INNER JOIN RPRCDS_REC R ON T.tsi_rmk_typ = R.cds_cd
                                WHERE T.tsi_ref_pfx = 'SO' AND T.tsi_cmpy_id = 'HSP' AND T.tsi_ref_itm = 0
								AND cds_data_el_nm = 'RMK-TYP' 
								AND cds_lng = 'en' and cds_desc = 'Delivery'
                                AND tsi_ref_no = {orderReleaseNumber} ";


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
