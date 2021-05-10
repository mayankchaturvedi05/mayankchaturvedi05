using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// ReSharper disable IdentifierTypo

namespace StratixRuanBusinessLogic.Ruan.Action
{
    public class RuanActualShipment
    {
        public string ManifestCode { get; set; }
        public string ManifestComment { get; set; }
        public DateTime ManifestShippedDate { get; set; }
        public string MercuryGateShipmentID { get; set; }
        public long? LoadAuthCrossNumber { get; set; }
        public string LoadAuthHeaderCode { get; set; }
        public string LoadAuthHeaderBolCode { get; set; }
        public string LoadAuthHeaderBolVehicleId { get; set; }
        public Guid? MercuryGateItemGuid { get; set; }
        public DateTime? LoadAuthDetailDeletedOn { get; set; }
        public string LiftNumber { get; set; }

        public long? SalesOrderReleaseNumber { get; set; }
        public long? TransferHeaderNumber { get; set; }
        public string OrderType { get; set; }
        public string SalesProcessing { get; set; }
        public string SCACCode { get; set; }
        public string ConsolidateIdCode { get; set; }
        public string CustPO { get; set; }

        public string RuanNumber { get; set; }
        public string TaTransportMode { get; set; }
        public string TaEquipment { get; set; }
        public long TaStopCount { get; set; }
        public long TaPickupStopSequence { get; set; }
        public long TaDropoffStopSequence { get; set; }

        public long? PartNumber { get; set; }
        public string PartCode { get; set; }
        public string PartDescription { get; set; }

        public string InventoryCode { get; set; }
        public string InventoryType { get; set; } //Coil/Lift/Sheet
        public double InventoryGrossWeight { get; set; }
        public string InventoryGrossWeightUom { get; set; }
        public double InventoryNetWeight { get; set; }
        public string InventoryNetWeightUom { get; set; }
        public double InventoryLength { get; set; }
        public string InventoryLengthUom { get; set; }
        public double InventoryWidth { get; set; }
        public string InventoryWidthUom { get; set; }

        public string ShipFromCode { get; set; }
        public string ShipFromName { get; set; }
        public string ShipFromAddress1 { get; set; }
        public string ShipFromAddress2 { get; set; }
        public string ShipFromCity { get; set; }
        public string ShipFromState { get; set; }
        public string ShipFromZip { get; set; }
        public string ShipFromCountry { get; set; }

        public string ShipToCode { get; set; }
        public string ShipToName { get; set; }
        public string ShipToAddress1 { get; set; }
        public string ShipToAddress2 { get; set; }
        public string ShipToCity { get; set; }
        public string ShipToState { get; set; }
        public string ShipToZip { get; set; }
        public string ShipToCountry { get; set; }

        //protected void PopulateBusinessObject(l2s.RUANACTUALSHIPMENT source)
        //{
        //    this.RuanNumber = source.RuanNumber;

        //    this.ManifestCode = source.TSMFHCode;
        //    this.ManifestComment = source.TSMFHComment;
        //    this.ManifestShippedDate = source.TSMFHDateShipped;

        //    this.LoadAuthCrossNumber = source.TSLACNumber;
        //    this.LoadAuthHeaderCode = source.TSLAHCode;
        //    this.LoadAuthHeaderBolCode = source.TSLAHBOLCode;
        //    this.LoadAuthHeaderBolVehicleId = source.TSLAHBOLVehicleID;
        //    this.LoadAuthDetailDeletedOn = source.TSLADDELETEDON;

        //    this.TransferHeaderNumber = source.ICTRHNumber;
        //    this.SalesOrderReleaseNumber = source.SOORRNumber;
        //    this.OrderType = source.ICTRHNumber != null ? "TRANSFERS" : "SALES_ORDER";

        //    this.SalesProcessing = "Sales";

        //    switch (source.SMTYPSalesProcessing)
        //    {
        //        case "S":
        //            this.SalesProcessing = "Sales";
        //            break;
        //        case "P":
        //            this.SalesProcessing = "Toll";
        //            break;
        //    }

        //    this.SCACCode = source.SCACCode;
        //    this.ConsolidateIdCode = source.ConsolidateIdCode;
        //    this.CustPO = source.CustPO;

        //    this.TaTransportMode = source.TATransportMode;
        //    this.TaEquipment = source.TAEquipment;
        //    this.TaStopCount = Convert.ToInt64(source.TAStopCount);
        //    this.TaPickupStopSequence = Convert.ToInt64(source.TAPickupStopSequence);
        //    this.TaDropoffStopSequence = Convert.ToInt64(source.TADropoffStopSequence);

        //    this.PartNumber = source.SOCPTNumber;
        //    this.PartCode = source.SOCPTCode;
        //    //superfluous crazy spaces in Part Description
        //    this.PartDescription = Regex.Replace(source.SOCPTDesc, @"\s\s+", " ");

        //    //Inventory
        //    this.InventoryCode = source.ICINVCode;
        //    this.LiftNumber = source.ICINVLiftNum;
        //    this.InventoryType = source.InventoryType.ToUpper();
        //    this.InventoryGrossWeight = Convert.ToDouble(source.ICINVGrossWgt);
        //    this.InventoryGrossWeightUom = source.ICINVGrossWgtUM;
        //    this.InventoryNetWeight = Convert.ToDouble(source.ICINVNetWgt);
        //    this.InventoryNetWeightUom = source.ICINVNetWgtUM;
        //    this.InventoryLength = Convert.ToDouble(source.ICINVDim3);
        //    this.InventoryLengthUom = string.IsNullOrEmpty(source.ICINVDim3UM) ? "IN" : source.ICINVDim3UM;
        //    this.InventoryWidth = Convert.ToDouble(source.ICINVDim2);
        //    this.InventoryWidthUom = source.ICINVDim2UM;

        //    this.ShipFromCode = source.ShipFromCode;
        //    this.ShipFromName = source.ShipFromName;
        //    this.ShipFromAddress1 = source.ShipFromAddress1;
        //    this.ShipFromAddress2 = source.ShipFromAddress2;
        //    this.ShipFromCity = source.ShipFromCity;
        //    this.ShipFromState = source.ShipFromState;
        //    this.ShipFromZip = source.ShipFromZip;
        //    this.ShipFromCountry = source.ShipFromCountry;

        //    this.ShipToCode = source.ShipToCode;
        //    this.ShipToName = source.ShipToName;
        //    this.ShipToAddress1 = source.ShipToAddress1;
        //    this.ShipToAddress2 = source.ShipToAddress2;
        //    this.ShipToCity = source.ShipToCity;
        //    this.ShipToState = source.ShipToState;
        //    this.ShipToZip = source.ShipToZip;
        //    this.ShipToCountry = source.ShipToCountry;
        //}

        public static List<RuanActualShipment> FetchActualShippedItems(long manifestHeaderNumber)
        {
            List<RuanActualShipment> results = new List<RuanActualShipment>();
            //l2s.RUANACTUALSHIPMENT[] items = l2s.RUANACTUALSHIPMENT.FetchActualShippedItems(manifestHeaderNumber);

            //foreach (l2s.RUANACTUALSHIPMENT item in items)
            //{
            //    RuanActualShipment newItem = new RuanActualShipment();
            //    newItem.PopulateBusinessObject(item);
            //    results.Add(newItem);
            //}

            return results;
        }
    }
}
