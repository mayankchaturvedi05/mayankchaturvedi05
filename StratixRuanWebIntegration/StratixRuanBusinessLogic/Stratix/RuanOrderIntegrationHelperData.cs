
using System;
using System.Data.Common;
using System.Diagnostics;
using StratixRuanDataLayer;

namespace StratixRuanBusinessLogic.Stratix
{
    public class RuanOrderIntegrationHelperData
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
        public string CustomerPO { get; set; }

        public double ReleaseWeight { get; set; }
        public DateTime OrderDeliveryDateFrom { get; set; }
        public DateTime OrderDeliveryDateTo { get; set; }
        public Int16 OrderDeliveryDateFromHour { get; set; }
        public Int16 OrderDeliveryDateToHour { get; set; }

        public string OrderProductDescription1 { get; set; }
        public string OrderProductDescription2 { get; set; }
        public string PartID { get; set; }
        public double? PartWidth { get; set; }
        public double? PartLength { get; set; }
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

        protected RuanOrderIntegrationHelperData(StratixRuanDataLayer.TSRuanOrderIntegrationHelperData source)
        {
            SalesOrderReleaseNumber = source.SalesOrderReleaseNumber;
            ShipFromID = source.ShipFromID;
            ShipFromName = source.ShipFromName;
            ShipFromAddress1 = source.ShipFromAddress1;
            ShipFromAddress2 = source.ShipFromAddress2;
            ShipFromAddress3 = source.ShipFromAddress3;
            ShipFromCity = source.ShipFromCity;
            ShipFromState = source.ShipFromState;
            ShipFromZipCode = source.ShipFromZipCode;
            ShipFromCountry = source.ShipFromCountry;
            SoldToID = source.SoldToID;
            SoldToName = source.SoldToName;
            SoldToAddress1 = source.SoldToAddress1;
            SoldToAddress2 = source.SoldToAddress2;
            SoldToAddress3 = source.SoldToAddress3;
            SoldToCity = source.SoldToCity;
            SoldToState = source.SoldToState;
            SoldToZipCode = source.SoldToZipCode;
            SoldToCountry = source.SoldToCountry;
            EarliestDueDateTolerance = source.EarliestDueDateTolerance;
            ShipToID = source.ShipToID;
            ShipToName = source.ShipToName;
            ShipToName2 = source.ShipToName2;
            ShipToAddress1 = source.ShipToAddress1;
            ShipToAddress2 = source.ShipToAddress2;
            ShipToAddress3 = source.ShipToAddress3;
            ShipToCity = source.ShipToCity;
            ShipToState = source.ShipToState;
            ShipToZipCode = source.ShipToZipCode;
            ShipToCountry = source.ShipToCountry;
            CustomerPO = source.CustomerPO;
            ReleaseWeight = source.ReleaseWeight;
            OrderDeliveryDateFrom = source.OrderDeliveryDateFrom;
            OrderDeliveryDateTo = source.OrderDeliveryDateTo;
            OrderDeliveryDateFromHour = source.OrderDeliveryDateFromHour;
            OrderDeliveryDateToHour = source.OrderDeliveryDateToHour;
            InsideSalesPersonName = source.InsideSalesPersonName;
            InsideSalesPersonEmail = source.InsideSalesPersonEmail;
            OrderProductDescription1 = source.OrderProductDescription1;
            OrderProductDescription2 = source.OrderProductDescription2;
            PartID = source.PartID;
            PartLength = source.PartLength;
            PartWidth = source.PartWidth;
            PackagingCode = source.PackagingCode;
            LoadComments = source.LoadComments;
            ShippingComments = source.ShippingComments;
            DeliveryComments = source.DeliveryComments;

            tav_trgt_ord_pfx = source.tav_trgt_ord_pfx;
            tav_trgt_ord_itm = source.tav_trgt_ord_itm;
            tav_trgt_ord_rls = source.tav_trgt_ord_rls;
            tav_ref_pfx = source.tav_ref_pfx;
            tav_ref_no = source.tav_ref_no;
            tav_jbs_pfx = source.tav_jbs_pfx;
            tav_jbs_no = source.tav_jbs_no;
        }

        public static RuanOrderIntegrationHelperData GetDataToConstructRuanOrderIntegrationHelperData(StratixOrderReleaseParametersForRuan stratixOrderReleaseParametersForRuan)
        {
            RuanOrderIntegrationHelperData result = null;
            if (stratixOrderReleaseParametersForRuan.orderFileKeyPfx.Equals("SO"))
            {
                if (stratixOrderReleaseParametersForRuan.orderFileItemNumber != null)
                    if (stratixOrderReleaseParametersForRuan.orderFileSubItemNumber != null)
                        result =
                            GetSalesOrderDataToConstructRuanOrderIntegrationXML(
                                stratixOrderReleaseParametersForRuan.orderFileKeyNumber,
                                stratixOrderReleaseParametersForRuan.orderFileItemNumber.Value,
                                stratixOrderReleaseParametersForRuan.orderFileSubItemNumber.Value);
            }
            else // JS OR IP filekey pfx
            {
                result =
                    GetTransferDataToConstructRuanOrderIntegrationXML(
                        stratixOrderReleaseParametersForRuan.orderFileKeyPfx,
                        stratixOrderReleaseParametersForRuan.orderFileKeyNumber
                        );

            }


            return result;
        }

        public static RuanOrderIntegrationHelperData GetSalesOrderDataToConstructRuanOrderIntegrationXML(long orderNumber , short orderItemNumber, short orderSubItemNumber)
        {
            StratixRuanDataLayer.TSRuanOrderIntegrationHelperData dataLayerResult = StratixRuanDataLayer.TSRuanOrderIntegrationHelperData.GetSalesOrderDataToConstructRuanOrderIntegrationXML(orderNumber, orderItemNumber, orderSubItemNumber);
            RuanOrderIntegrationHelperData blInstance = new RuanOrderIntegrationHelperData(dataLayerResult);
            return blInstance;
        }

        public static RuanOrderIntegrationHelperData GetTransferDataToConstructRuanOrderIntegrationXML(string transferKeyPfx, long transferKeyNumber)
        {
            StratixRuanDataLayer.TSRuanOrderIntegrationHelperData dataLayerResult = StratixRuanDataLayer.TSRuanOrderIntegrationHelperData.GetTransferDataToConstructRuanOrderIntegrationXML(transferKeyPfx, transferKeyNumber);
            RuanOrderIntegrationHelperData blInstance = new RuanOrderIntegrationHelperData(dataLayerResult);
            return blInstance;
        }

    }
}
