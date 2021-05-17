
namespace StratixRuanBusinessLogic.Stratix
{
    public class RuanOrderIntegrationHelperData
    {
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

        protected RuanOrderIntegrationHelperData(StratixRuanDataLayer.TSRuanOrderIntegrationHelperData source)
        {
            ShipFromID = source.ShipFromID;
            ShipFromName = source.ShipFromName;
            ShipFromAddress1 = source.ShipFromAddress1;
            ShipFromAddress2 = source.ShipFromAddress2;
            ShipFromAddress3 = source.ShipFromAddress3;
            ShipFromCity = source.ShipFromCity;
            ShipFromState = ""; //todo
            ShipFromZipCode = source.ShipFromZipCode;
            ShipFromCountry = source.ShipFromCountry;
            SoldToID = source.SoldToID;
            SoldToName = source.SoldToName;
            SoldToAddress1 = source.SoldToAddress1;
            SoldToAddress2 = source.SoldToAddress2;
            SoldToAddress3 = source.SoldToAddress3;
            SoldToCity = source.SoldToCity;
            SoldToState = ""; //todo
            SoldToZipCode = source.SoldToZipCode;
            SoldToCountry = source.SoldToCountry;
            ShipToID = source.ShipToID;
            ShipToName = source.ShipToName;
            ShipToName2 = source.ShipToName2;
            ShipToAddress1 = source.ShipToAddress1;
            ShipToAddress2 = source.ShipToAddress2;
            ShipToAddress3 = source.ShipToAddress3;
            ShipToCity = source.ShipToCity;
            ShipToState = ""; //todo
            ShipToZipCode = source.ShipToZipCode;
            ShipToCountry = source.ShipToCountry;
           
        }

        public static RuanOrderIntegrationHelperData GetDataToConstructRuanOrderIntegrationHelperData(long orderReleaseNumber)
        {
            RuanOrderIntegrationHelperData result =
                GetSalesOrderDataToConstructRuanOrderIntegrationXML(orderReleaseNumber);


            return result;
        }

        public static RuanOrderIntegrationHelperData GetSalesOrderDataToConstructRuanOrderIntegrationXML(long orderReleaseNumber)
        {
            StratixRuanDataLayer.TSRuanOrderIntegrationHelperData dataLayerResult = StratixRuanDataLayer.TSRuanOrderIntegrationHelperData.GetSalesOrderDataToConstructRuanOrderIntegrationXML(orderReleaseNumber);
            RuanOrderIntegrationHelperData blInstance = new RuanOrderIntegrationHelperData(dataLayerResult);
            return blInstance;
        }

    }
}
