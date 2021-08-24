using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratixRuanBusinessLogic.Stratix
{
    public class RuanBaseOrdersHelperData
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
        
        //protected RuanBaseOrdersHelperData()
        //{

        //}
        
        public static List<RuanBaseOrdersHelperData> GetPurchaseOrderDataToConstructRuanOrderIntegrationXML(String orderReleaseNumber)
        {
            List<StratixRuanDataLayer.RuanBaseOrderIntegrationHelperData> dataLayerResult = StratixRuanDataLayer.RuanBaseOrderIntegrationHelperData.GetPurchaseOrderDataToConstructRuanOrderIntegrationXML(orderReleaseNumber);
            List<RuanBaseOrdersHelperData> businessLayer = new List<RuanBaseOrdersHelperData>();

            RuanBaseOrdersHelperData result = null;
            RuanBaseOrderIntegrationShipFromHelperData shipFrom;
            RuanBaseOrderIntegrationShipToHelperData shipTo;
            RuanBaseOrderIntegrationPrdDescHelperData preDesc;

            foreach (var ord in dataLayerResult)
            {
                result = new RuanBaseOrdersHelperData();

                result.poh_po_no = ord.poh_po_no;
                result.poi_po_itm = ord.poi_po_itm;
                result.poi_ord_qty = ord.poi_ord_qty;
                result.poi_ord_wgt_um = ord.poi_ord_wgt_um;
                result.poh_cmpy_id = ord.poh_cmpy_id;
                result.poh_ven_id = ord.poh_ven_id;
                result.poh_po_brh = ord.poh_po_brh;
                object poh_po_pl_dt = ord.poh_po_pl_dt;
                result.poh_po_pl_dt = Convert.ToDateTime(poh_po_pl_dt);
                
                shipFrom = new RuanBaseOrderIntegrationShipFromHelperData();
                shipFrom.cva_addr1 = ord.ship_from.cva_addr1;
                shipFrom.cva_nm1 = ord.ship_from.cva_nm1;
                shipFrom.cva_addr1 = ord.ship_from.cva_addr1;
                shipFrom.cva_addr2 = ord.ship_from.cva_addr2 ;
                shipFrom.cva_addr3 = ord.ship_from.cva_addr3;
                shipFrom.cva_city = ord.ship_from.cva_city;
                shipFrom.cva_st_prov = ord.ship_from.cva_st_prov;
                shipFrom.cva_pcd = ord.ship_from.cva_pcd;
                shipFrom.cva_cty = ord.ship_from.cva_cty;
                result.ship_from = shipFrom;
                
                shipTo = new RuanBaseOrderIntegrationShipToHelperData();
                shipTo.brh_nm1 = ord.ship_To.brh_nm1;
                shipTo.brh_addr1 = ord.ship_To.brh_addr1;
                shipTo.brh_addr2 = ord.ship_To.brh_addr2;
                shipTo.brh_addr3= ord.ship_To.brh_addr3;
                shipTo.brh_city = ord.ship_To.brh_city;
                shipTo.brh_st_prov = ord.ship_To.brh_st_prov;
                shipTo.brh_pcd = ord.ship_To.brh_pcd;
                shipTo.brh_cty = ord.ship_To.brh_cty;
                result.ship_To = shipTo;

                preDesc = new RuanBaseOrderIntegrationPrdDescHelperData();
                preDesc.pds_prd_desc50a = ord.prd_desc.pds_prd_desc50a;
                preDesc.pds_prd_desc50b = ord.prd_desc.pds_prd_desc50b;
                preDesc.pds_prd_desc50c = ord.prd_desc.pds_prd_desc50c;
                result.prd_desc = preDesc;

                businessLayer.Add(result);

            }


                // List<RuanBaseOrdersHelperData> obj = List < RuanBaseOrdersHelperData >(dataLayerResult);
                //RuanBaseOrdersHelperData blInstance = new RuanBaseOrdersHelperData(dataLayerResult);
                return businessLayer;
        }


    }
}
