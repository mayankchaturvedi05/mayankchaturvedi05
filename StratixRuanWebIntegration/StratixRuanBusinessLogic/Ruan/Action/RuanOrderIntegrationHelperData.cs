using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace StratixRuanBusinessLogic.Ruan.Action
{
    public class RuanOrderIntegrationHelperData
    {
        public double? PartThickness { get; set; }
        public string PartThicknessUM { get; set; }
        public double? PartWidth { get; set; }
        public string PartWidthUM { get; set; }
        public double? PartLength { get; set; }
        public double? PartDim4 { get; set; }
        public string PartLengthUM { get; set; }
        public double? PartCoilWeightMin { get; set; }
        public double? PartCoilWeightMax { get; set; }
        public string PartCoilWeightMinMaxUM { get; set; }
        public double? PartLiftWeightMin { get; set; }
        public double? PartLiftWeightMax { get; set; }
        public string PartLiftWeightMinMaxUM { get; set; }
        public double? PartCoilIDMin { get; set; }
        public double? PartCoilIDMax { get; set; }
        public string PartCoilIDMinMaxUM { get; set; }
        public double? PartCoilODMin { get; set; }
        public double? PartCoilODMax { get; set; }
        public string PartCoilODMinMaxUM { get; set; }
        public string ShipFromCode { get; set; }
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
        public string ShipAuthNumber { get; set; }
        public string SmRepName { get; set; }
        public string SmrepEmail { get; set; }
        public string SalesOrderCode { get; set; }
        public string TransferHeaderCode { get; set; }
        public string PartDescription { get; set; }
        public string PartCode { get; set; }
        public DateTime? ShipToSundayPickupFromTime { get; set; }
        public DateTime? ShipToSundayPickupThruTime { get; set; }
        public DateTime? ShipToMondayPickupFromTime { get; set; }
        public DateTime? ShipToMondayPickupThruTime { get; set; }
        public DateTime? ShipToTuesdayPickupFromTime { get; set; }
        public DateTime? ShipToTuesdayPickupThruTime { get; set; }
        public DateTime? ShipToWednesdayPickupFromTime { get; set; }
        public DateTime? ShipToWednesdayPickupThruTime { get; set; }
        public DateTime? ShipToThursdayPickupFromTime { get; set; }
        public DateTime? ShipToThursdayPickupThruTime { get; set; }
        public DateTime? ShipToFridayPickupFromTime { get; set; }
        public DateTime? ShipToFridayPickupThruTime { get; set; }
        public DateTime? ShipToSaturdayPickupFromTime { get; set; }
        public DateTime? ShipToSaturdayPickupThruTime { get; set; }
        public bool DeliverWeekOf { get; set; }
        public bool DeliverBefore { get; set; }
        public Int16? DeliverNumberOfDaysBefore { get; set; }
        public DateTime EarliestDeliveryDateTime { get; set; }
        public DateTime LatestDeliveryDateTime { get; set; }
        public string ShipUnitType { get; set; } = string.Empty;
        public string SalesOrderTransferRef { get; set; }
        public string InventoryType { get; set; } //Coil/Lift/Sheet
        public string LoadComments { get; set; } 
        public string AMALTRComment { get; set; }
        public string CustPO { get; set; }

        public RuanOrderIntegrationHelperData()
        {
        }

        //protected RuanOrderIntegrationHelperData(l2s.TSRuanOrderIntegrationHelperData source)
        //{
        //    PartDim4 = source.PartDim4;
        //    PartThickness = source.PartThickness;
        //    PartThicknessUM = source.PartThicknessUM;
        //    PartWidth = source.PartWidth;
        //    PartWidthUM = source.PartWidthUM;
        //    PartLength = source.PartLength;
        //    PartLengthUM = source.PartLengthUM;
        //    PartCoilWeightMin = source.PartCoilWeightMin;
        //    PartCoilWeightMax = source.PartCoilWeightMax;
        //    PartCoilWeightMinMaxUM = source.PartCoilWeightMinMaxUM;
        //    PartLiftWeightMin = source.PartLiftWeightMin;
        //    PartLiftWeightMax = source.PartLiftWeightMax;
        //    PartLiftWeightMinMaxUM = source.PartLiftWeightMinMaxUM;
        //    PartCoilIDMin = source.PartCoilIDMin;
        //    PartCoilIDMax = source.PartCoilIDMax;
        //    PartCoilIDMinMaxUM = source.PartCoilIDMinMaxUM;
        //    PartCoilODMin = source.PartCoilODMin;
        //    PartCoilODMax = source.PartCoilODMax;
        //    PartCoilODMinMaxUM = source.PartCoilODMinMaxUM;
        //    ShipFromCode = source.ShipFromCode;
        //    ShipFromName = source.ShipFromName;
        //    ShipFromAddress1 = source.ShipFromAddress1;
        //    ShipFromAddress2 = source.ShipFromAddress2;
        //    ShipFromAddress3 = source.ShipFromAddress3;
        //    ShipFromCity = source.ShipFromCity;
        //    ShipFromState = source.ShipFromCountry.Equals("Mexico") ? FixMexicanState(source.ShipFromState) : source.ShipFromState;
        //    ShipFromZipCode = source.ShipFromZipCode;
        //    ShipFromCountry = source.ShipFromCountry;
        //    SoldToID = source.SoldToID;
        //    SoldToName = source.SoldToName;
        //    SoldToAddress1 = source.SoldToAddress1;
        //    SoldToAddress2 = source.SoldToAddress2;
        //    SoldToAddress3 = source.SoldToAddress3;
        //    SoldToCity = source.SoldToCity;
        //    SoldToState = source.SoldToCountry.Equals("Mexico")? FixMexicanState(source.SoldToState) : source.SoldToState;
        //    SoldToZipCode = source.SoldToZipCode;
        //    SoldToCountry = source.SoldToCountry;
        //    ShipToID = source.ShipToID;
        //    ShipToName = source.ShipToName;
        //    ShipToName2 = source.ShipToName2;
        //    ShipToAddress1 = source.ShipToAddress1;
        //    ShipToAddress2 = source.ShipToAddress2;
        //    ShipToAddress3 = source.ShipToAddress3;
        //    ShipToCity = source.ShipToCity;
        //    ShipToState = source.ShipToCountry.Equals("Mexico") ? FixMexicanState(source.ShipToState) : source.ShipToState;
        //    ShipToZipCode = source.ShipToZipCode;
        //    ShipToCountry = source.ShipToCountry;
        //    ShipAuthNumber = source.ShipAuthNumber;
        //    SmRepName = source.SmRepName;
        //    SmrepEmail = source.SmrepEmail;
        //    SalesOrderCode = source.SalesOrderCode;
        //    TransferHeaderCode = source.TransferHeaderCode;
        //    //superfluous crazy spaces in Part Description
        //    if(!string.IsNullOrEmpty(source.SOCPTDesc))
        //        PartDescription = Regex.Replace(source.SOCPTDesc, @"\s\s+", " ");
        //    PartCode = source.SOCPTCode;
        //    ShipToSundayPickupFromTime  = source.AMALTRSunFrom;
        //    ShipToSundayPickupThruTime  = source.AMALTRSunThru;
        //    ShipToMondayPickupFromTime  = source.AMALTRMonFrom;
        //    ShipToMondayPickupThruTime = source.AMALTRMonThru;
        //    ShipToTuesdayPickupFromTime  = source.AMALTRTueFrom;
        //    ShipToTuesdayPickupThruTime = source.AMALTRTueThru;
        //    ShipToWednesdayPickupFromTime  = source.AMALTRWedFrom;
        //    ShipToWednesdayPickupThruTime = source.AMALTRWedThru;
        //    ShipToThursdayPickupFromTime  = source.AMALTRThuFrom;
        //    ShipToThursdayPickupThruTime = source.AMALTRThuThru;
        //    ShipToFridayPickupFromTime  = source.AMALTRFriFrom;
        //    ShipToFridayPickupThruTime = source.AMALTRFriThru;
        //    ShipToSaturdayPickupFromTime  = source.AMALTRSatFrom;
        //    ShipToSaturdayPickupThruTime = source.AMALTRSatThru;
        //    DeliverWeekOf = source.DeliverWeekOf;
        //    DeliverBefore = source.DeliverBefore;
        //    DeliverNumberOfDaysBefore = source.DeliverNumberOfDaysBefore;
        //    InventoryType = source.InventoryType;
        //    AMALTRComment = source.AMALTRComment;
        //    CustPO = source.CustPO;
        //}

        //private void FixCountries()
        //{
        //    if (ShipFromCountry.Equals("United States"))
        //    {
        //        ShipFromCountry = "USA";
        //    }
        //    else if (ShipFromCountry.Equals("Canada"))
        //    {
        //        ShipFromCountry = "CAN";
        //    }
        //    else if (ShipFromCountry.Equals("Mexico"))
        //    {
        //        ShipFromCountry = "MEX";
        //    }

        //    if (ShipToCountry.Equals("United States"))
        //    {
        //        ShipToCountry = "USA";
        //    }
        //    else if (ShipToCountry.Equals("Canada"))
        //    {
        //        ShipToCountry = "CAN";
        //    }
        //    else if (ShipToCountry.Equals("Mexico"))
        //    {
        //        ShipToCountry = "MEX";
        //    }

        //    if (SoldToCountry.Equals("United States"))
        //    {
        //        SoldToCountry = "USA";
        //    }
        //    else if (SoldToCountry.Equals("Canada"))
        //    {
        //        SoldToCountry = "CAN";
        //    }
        //    else if (SoldToCountry.Equals("Mexico"))
        //    {
        //        SoldToCountry = "MEX";
        //    }
        //}

        //private string FixMexicanState(string longStateName)
        //{
        //    if (longStateName.Equals("Aguascalientes"))
        //    {
        //        return "AG";
        //    }
        //    else if (longStateName.Equals("Baja California"))
        //    {
        //        return "BC";
        //    }
        //    else if (longStateName.Equals("Baja California Sur"))
        //    {
        //        return "BS";
        //    }
        //    else if (longStateName.Equals("Campeche"))
        //    {
        //        return "CM";
        //    }
        //    else if (longStateName.Equals("Chiapas"))
        //    {
        //        return "CS";
        //    }
        //    else if (longStateName.Equals("Chihuahua"))
        //    {
        //        return "CH";
        //    }
        //    else if (longStateName.Equals("Coahuila"))
        //    {
        //        return "CO";
        //    }
        //    else if (longStateName.Equals("Colima"))
        //    {
        //        return "CL";
        //    }
        //    else if (longStateName.Equals("Distrito Federal"))
        //    {
        //        return "DF";
        //    }
        //    else if (longStateName.Equals("Durango"))
        //    {
        //        return "DG";
        //    }
        //    else if (longStateName.Equals("Guanajuato"))
        //    {
        //        return "GT";
        //    }
        //    else if (longStateName.Equals("Guerrero"))
        //    {
        //        return "GR";
        //    }
        //    else if (longStateName.Equals("Hidalgo"))
        //    {
        //        return "HG";
        //    }
        //    else if (longStateName.Equals("Jalisco"))
        //    {
        //        return "JA";
        //    }
        //    else if (longStateName.Equals("Mexico"))
        //    {
        //        return "EM";
        //    }
        //    else if (longStateName.Equals("Michoacan"))
        //    {
        //        return "MI";
        //    }
        //    else if (longStateName.Equals("Morelos"))
        //    {
        //        return "MO";
        //    }
        //    else if (longStateName.Equals("Nayarit"))
        //    {
        //        return "NA";
        //    }
        //    else if (longStateName.Equals("Nuevo Leon"))
        //    {
        //        return "NL";
        //    }
        //    else if (longStateName.Equals("Oaxaca"))
        //    {
        //        return "OA";
        //    }
        //    else if (longStateName.Equals("Puebla"))
        //    {
        //        return "PU";
        //    }
        //    else if (longStateName.Equals("Queretaro"))
        //    {
        //        return "QT";
        //    }
        //    else if (longStateName.Equals("Quintana Roo"))
        //    {
        //        return "QR";
        //    }
        //    else if (longStateName.Equals("San Luis Potosi"))
        //    {
        //        return "SL";
        //    }
        //    else if (longStateName.Equals("Sinaloa"))
        //    {
        //        return "SI";
        //    }
        //    else if (longStateName.Equals("Sonora"))
        //    {
        //        return "SO";
        //    }
        //    else if (longStateName.Equals("Tabasco"))
        //    {
        //        return "TB";
        //    }
        //    else if (longStateName.Equals("Tamaulipas"))
        //    {
        //        return "TM";
        //    }
        //    else if (longStateName.Equals("Tlaxcala"))
        //    {
        //        return "TL";
        //    }
        //    else if (longStateName.Equals("Veracruz"))
        //    {
        //        return "VE";
        //    }
        //    else if (longStateName.Equals("Yucatan"))
        //    {
        //        return "YU";
        //    }
        //    else if (longStateName.Equals("Zacatecas"))
        //    {
        //        return "ZA";
        //    }


        //    return string.Empty;
        //}

        ////The below method will not be used. Keeping it here and remove it after the delivery dates logic is confirmed.
        //private void SetDeliveryDatesFromSalesOrder(DateTime requestedShipDate)
        //{
        //    if (DeliverWeekOf)
        //    {
        //        switch (requestedShipDate.DayOfWeek)
        //        {
        //            case DayOfWeek.Monday:
        //                EarliestDeliveryDateTime = requestedShipDate.AddDays(0);
        //                LatestDeliveryDateTime = requestedShipDate.AddDays(4);
        //                break;
        //            case DayOfWeek.Tuesday:
        //                EarliestDeliveryDateTime = requestedShipDate.AddDays(-1);
        //                LatestDeliveryDateTime = requestedShipDate.AddDays(3);
        //                break;
        //            case DayOfWeek.Wednesday:
        //                EarliestDeliveryDateTime = requestedShipDate.AddDays(-2);
        //                LatestDeliveryDateTime = requestedShipDate.AddDays(2);
        //                break;
        //            case DayOfWeek.Thursday:
        //                EarliestDeliveryDateTime = requestedShipDate.AddDays(-3);
        //                LatestDeliveryDateTime = requestedShipDate.AddDays(1);
        //                break;
        //            case DayOfWeek.Friday:
        //                EarliestDeliveryDateTime = requestedShipDate.AddDays(-4);
        //                LatestDeliveryDateTime = requestedShipDate.AddDays(0);
        //                break;
        //            case DayOfWeek.Saturday:
        //                EarliestDeliveryDateTime = requestedShipDate.AddDays(-5);
        //                LatestDeliveryDateTime = requestedShipDate.AddDays(-1);
        //                break;
        //            case DayOfWeek.Sunday:
        //                EarliestDeliveryDateTime = requestedShipDate.AddDays(1);
        //                LatestDeliveryDateTime = requestedShipDate.AddDays(5);
        //                break;
        //        }
        //    }

        //    else if (DeliverBefore)
        //    {
        //        double daysBefore = Convert.ToDouble(DeliverNumberOfDaysBefore ?? 0);
        //        EarliestDeliveryDateTime = requestedShipDate.AddDays(-1 * daysBefore);
        //        LatestDeliveryDateTime = requestedShipDate;
        //    }
        //    else
        //    {
        //        EarliestDeliveryDateTime = requestedShipDate;
        //        LatestDeliveryDateTime = requestedShipDate;
        //    }

        //    //set the dates to today if the date ranges fall past or before the delivery dates calculated.
        //    if (EarliestDeliveryDateTime < DateTime.Now.Date)
        //    {
        //        EarliestDeliveryDateTime = DateTime.Now.Date;//set it to today.
        //    }
        //    if (LatestDeliveryDateTime < DateTime.Now.Date)
        //    {
        //        LatestDeliveryDateTime = DateTime.Now.Date;//set it to today.
        //    }
        //}

        //private void SetDeliveryTimes()
        //{
        //    //Add early and latest drop off hour time.
        //    DateTime defaultEarlyAndLatestOffTime = DateTime.Now.Date;
        //    switch (Convert.ToDateTime(EarliestDeliveryDateTime).DayOfWeek)
        //    {
        //        case DayOfWeek.Monday:
        //            EarliestDeliveryDateTime = Convert.ToDateTime(EarliestDeliveryDateTime).Date.Add(ShipToMondayPickupFromTime.HasValue ? ShipToMondayPickupFromTime.Value.TimeOfDay : defaultEarlyAndLatestOffTime.TimeOfDay);
        //            break;
        //        case DayOfWeek.Tuesday:
        //            EarliestDeliveryDateTime = Convert.ToDateTime(EarliestDeliveryDateTime).Date.Add(ShipToTuesdayPickupFromTime.HasValue ? ShipToTuesdayPickupFromTime.Value.TimeOfDay : defaultEarlyAndLatestOffTime.TimeOfDay);
        //            break;
        //        case DayOfWeek.Wednesday:
        //            EarliestDeliveryDateTime = Convert.ToDateTime(EarliestDeliveryDateTime).Date.Add(ShipToWednesdayPickupFromTime.HasValue ? ShipToWednesdayPickupFromTime.Value.TimeOfDay : defaultEarlyAndLatestOffTime.TimeOfDay);
        //            break;
        //        case DayOfWeek.Thursday:
        //            EarliestDeliveryDateTime = Convert.ToDateTime(EarliestDeliveryDateTime).Date.Add(ShipToThursdayPickupFromTime.HasValue ? ShipToThursdayPickupFromTime.Value.TimeOfDay : defaultEarlyAndLatestOffTime.TimeOfDay);
        //            break;
        //        case DayOfWeek.Friday:
        //            EarliestDeliveryDateTime = Convert.ToDateTime(EarliestDeliveryDateTime).Date.Add(ShipToFridayPickupFromTime.HasValue ? ShipToFridayPickupFromTime.Value.TimeOfDay : defaultEarlyAndLatestOffTime.TimeOfDay);
        //            break;
        //        case DayOfWeek.Saturday:
        //            EarliestDeliveryDateTime = Convert.ToDateTime(EarliestDeliveryDateTime).Date.Add(ShipToSaturdayPickupFromTime.HasValue ? ShipToSaturdayPickupFromTime.Value.TimeOfDay : defaultEarlyAndLatestOffTime.TimeOfDay);
        //            break;
        //        case DayOfWeek.Sunday:
        //            EarliestDeliveryDateTime = Convert.ToDateTime(EarliestDeliveryDateTime).Date.Add(ShipToSundayPickupFromTime.HasValue ? ShipToSundayPickupFromTime.Value.TimeOfDay : defaultEarlyAndLatestOffTime.TimeOfDay);
        //            break;
        //        default:
        //            throw new ArgumentOutOfRangeException();
        //    }

        //    switch (Convert.ToDateTime(LatestDeliveryDateTime).DayOfWeek)
        //    {
        //        case DayOfWeek.Monday:
        //            LatestDeliveryDateTime = GetLatestDateTime(LatestDeliveryDateTime, ShipToMondayPickupFromTime, ShipToMondayPickupThruTime, defaultEarlyAndLatestOffTime);
        //            break;
        //        case DayOfWeek.Tuesday:
        //            LatestDeliveryDateTime = GetLatestDateTime(LatestDeliveryDateTime, ShipToTuesdayPickupFromTime, ShipToTuesdayPickupThruTime, defaultEarlyAndLatestOffTime);
        //            break;
        //        case DayOfWeek.Wednesday:
        //            LatestDeliveryDateTime = GetLatestDateTime(LatestDeliveryDateTime, ShipToWednesdayPickupFromTime, ShipToWednesdayPickupThruTime, defaultEarlyAndLatestOffTime);
        //            break;
        //        case DayOfWeek.Thursday:
        //            LatestDeliveryDateTime = GetLatestDateTime(LatestDeliveryDateTime, ShipToThursdayPickupFromTime, ShipToThursdayPickupThruTime, defaultEarlyAndLatestOffTime);
        //            break;
        //        case DayOfWeek.Friday:
        //            LatestDeliveryDateTime = GetLatestDateTime(LatestDeliveryDateTime, ShipToFridayPickupFromTime, ShipToFridayPickupThruTime, defaultEarlyAndLatestOffTime);
        //            break;
        //        case DayOfWeek.Saturday:
        //            LatestDeliveryDateTime = GetLatestDateTime(LatestDeliveryDateTime, ShipToSaturdayPickupFromTime, ShipToSaturdayPickupThruTime, defaultEarlyAndLatestOffTime);
        //            break;
        //        case DayOfWeek.Sunday:
        //            LatestDeliveryDateTime = GetLatestDateTime(LatestDeliveryDateTime, ShipToSundayPickupFromTime, ShipToSundayPickupThruTime, defaultEarlyAndLatestOffTime);
        //            break;
        //        default:
        //            throw new ArgumentOutOfRangeException();
        //    }
        //}

        //internal static DateTime GetLatestDateTime(DateTime latestDeliveryDate, DateTime? fromDateTime, DateTime? thruDateTime, DateTime defaultEarlyAndLatestOffTime)
        //{
        //    DateTime fromTime = fromDateTime ?? defaultEarlyAndLatestOffTime;
        //    DateTime thruTime = thruDateTime ?? defaultEarlyAndLatestOffTime;

        //    DateTime newDateTime = thruTime.TimeOfDay < fromTime.TimeOfDay ? latestDeliveryDate.Date.AddDays(1d).Add(thruTime.TimeOfDay) : latestDeliveryDate.Date.Add(thruTime.TimeOfDay);
        //    return newDateTime;
        //}


        ////protected internal void SetShipUnitType(List<PackageLoad> packingLoads)
        ////{
        ////    if (PartDim4.HasValue && PartDim4.Value > 0)//4th dim..means..it is a tube.
        ////    {
        ////        ShipUnitType = "TUBE";
        ////    }
        ////    else if(PartLength.HasValue && PartLength.Value > 0)//if length..then it is a sheet.
        ////    {
        ////        ShipUnitType = "SHEET";
        ////    }
        ////    List<long?> packageLoads = new List<long?>()
        ////    {
        ////        SOCPTPackageLoad01,
        ////        SOCPTPackageLoad02,
        ////        SOCPTPackageLoad03,
        ////        SOCPTPackageLoad04,
        ////        SOCPTPackageLoad05,
        ////        SOCPTPackageLoad06,
        ////        SOCPTPackageLoad07,
        ////        SOCPTPackageLoad08,
        ////        SOCPTPackageLoad09,
        ////        SOCPTPackageLoad10
        ////    };
        ////    if (packageLoads.Any(t => t.HasValue) && string.IsNullOrEmpty(ShipUnitType))
        ////    {
        ////        foreach (long? load in packageLoads.Where(l => l.HasValue))
        ////        {
        ////            if (packingLoads.Any(pl => pl.PackageLoadNumber == Convert.ToInt64(load)))
        ////            {
        ////                ShipUnitType = packingLoads.First(pl => pl.PackageLoadNumber == Convert.ToInt64(load)).PackageLoadCode.ToUpper();
        ////                return;
        ////            }
        ////        }
        ////    }
        ////}

        //public static RuanOrderIntegrationHelperData GetSalesOrderDataToConstructRuanOrderIntegrationXML(long salesOrderReleaseNumber, long locationNumber)
        //{
        //    l2s.TSRuanOrderIntegrationHelperData dataLayerResult = l2s.TSRuanOrderIntegrationHelperData.GetSalesOrderDataToConstructRuanOrderIntegrationXML(salesOrderReleaseNumber, locationNumber);
        //    RuanOrderIntegrationHelperData blInstance = new RuanOrderIntegrationHelperData(dataLayerResult);
        //    return blInstance;
        //}

        //public static RuanOrderIntegrationHelperData GetTransferDataToConstructRuanOrderIntegrationXML(long transferNumber)
        //{
        //    l2s.TSRuanOrderIntegrationHelperData dataLayerResult = l2s.TSRuanOrderIntegrationHelperData.GetTransferDataToConstructRuanOrderIntegrationXML(transferNumber);
        //    RuanOrderIntegrationHelperData blInstance = new RuanOrderIntegrationHelperData(dataLayerResult);
        //    return blInstance;
        //}

        //public static RuanOrderIntegrationHelperData GetDataToConstructRuanOrderIntegrationHelperData(LoadAuthorizationCross loadAuthCross)
        //{
        //    RuanOrderIntegrationHelperData result;
        //    if (loadAuthCross.TransferHeaderNumber.HasValue)
        //    {
        //        result = GetTransferDataToConstructRuanOrderIntegrationXML(Convert.ToInt64(loadAuthCross.TransferHeaderNumber));
        //        result.SalesOrderTransferRef = result.TransferHeaderCode;
        //    }
        //    else
        //    {
        //        result = GetSalesOrderDataToConstructRuanOrderIntegrationXML(Convert.ToInt64(loadAuthCross.SalesOrderReleaseNumber), Convert.ToInt64(loadAuthCross.LocationNumber));
        //        result.SalesOrderTransferRef = result.SalesOrderCode;
        //        //set dates
        //        //result.SetDeliveryDatesFromSalesOrder(Convert.ToDateTime(loadAuthCross.Date)); This is set from Trucklist entry instead of calculating here.
        //        result.SetLoadCommentsForTruckList(Convert.ToInt64(loadAuthCross.SalesOrderReleaseNumber));
        //    }
        //    //set dates
        //    result.EarliestDeliveryDateTime = Convert.ToDateTime(loadAuthCross.EarliestDeliveryDate);
        //    result.LatestDeliveryDateTime = Convert.ToDateTime(loadAuthCross.LatestDeliveryDate);
        //    result.FixCountries();
        //    return result;
        //}


        //public static string GetPackagingType(LoadAuthorizationCross loadAuthCross)
        //{
        //    List<string> packageListForRuan = new List<string>
        //    {
        //        "'1H'",
        //        "'7G'",
        //        "'1A'",
        //        "'1B'",
        //        "'1C'",
        //        "'1D'",
        //        "'1E'",
        //        "'1G'",
        //        "'1I'",
        //        "'1L'",
        //        "'1M'",
        //        "'1O'",
        //        "'7A'",
        //        "'7B'",
        //        "'7F'",
        //        "'7I'",
        //        "'7D'",
        //        "'7H'",
        //        "'7C'",
        //        "'7J'",
        //        "'T24'",
        //        "'T34'",
        //        "'1 Coil'",
        //        "'7Z'",
        //        "'ACC'",
        //        "'Rockford'"
        //    };

        //    if (loadAuthCross == null)
        //    {
        //        return null;
        //    }
        //    string customerPackagingCode = "";
        //    PackageLoadList packageLoadList = new PackageLoadList();
        //    TransferDetail firstTransferDetailItem = new TransferDetail();

        //    SalesOrderRelease soOrderRelease = SalesOrderRelease.FetchByNumber(loadAuthCross.SalesOrderReleaseNumber);

        //    if (loadAuthCross.TransferHeaderNumber != null)
        //    {
        //        TransferDetailList transferList = TransferDetail.FetchAllByHeaderNumber(loadAuthCross.TransferHeaderNumber.Value);

        //        firstTransferDetailItem = transferList.FirstOrDefault();
        //    }

        //    if (soOrderRelease != null) // For SalesORder RElease based TruckRelease
        //    {
        //        packageLoadList = PackageLoad.FetchAllForCustomerPartNumber(soOrderRelease.CustPart.CustomerPartNumber);
        //    }
        //    else //For Transfer based Truckrelease
        //    {
        //        //if its a transfer only grab the first item to get packaging codes.
        //        if (firstTransferDetailItem != null)
        //        {
        //            Inventory inv = Inventory.FetchByNumber(firstTransferDetailItem.ItemNumberIn);
        //            soOrderRelease = SalesOrderRelease.FetchByNumber(inv.SalesOrderReleaseNumber);
        //            if (soOrderRelease != null && soOrderRelease.CustPart != null && soOrderRelease.CustPart.CustomerPartNumber > 0)
        //            {
        //                packageLoadList = PackageLoad.FetchAllForCustomerPartNumber(soOrderRelease.CustPart.CustomerPartNumber);
        //            }
        //        }

        //    }

        //    if (soOrderRelease != null)
        //    {
        //        if (soOrderRelease.CustPart != null && (soOrderRelease.CustPart.Dimension4Ordered.HasValue && soOrderRelease.CustPart.Dimension4Ordered > 0))
        //        {
        //            customerPackagingCode = "TUBE";
        //        }
        //        else if (soOrderRelease.CustPart != null && (soOrderRelease.CustPart.LengthOrdered.HasValue && soOrderRelease.CustPart.LengthOrdered > 0))
        //        {
        //            customerPackagingCode = "SHEET";
        //        }
        //    }
        //    else
        //    {
        //        foreach (PackageLoad pacl in packageLoadList)
        //        {
        //            if (pacl.PackageLoadCode.Contains("1"))
        //            {
        //                customerPackagingCode = pacl.PackageLoadCode;
        //                break;
        //            }
        //        }

        //    }

        //    if (!packageListForRuan.Contains(customerPackagingCode))//should match the precode listst..if NOT send 1 H
        //    {
        //        customerPackagingCode = "1H";
        //    }

        //    if (string.IsNullOrWhiteSpace(customerPackagingCode))//if nothing..Default to 1H
        //    {
        //        customerPackagingCode = "1H";
        //    }
        //    return customerPackagingCode;

        //}

        ////Note: This comment generation is a strip down version of public TruckListReadyToShipComment GenerateComments(TruckListReadyToShipQueryResult rowItem) method in MGTruckListEntryVM
        ////The query should be refactored if needed later.
        //public void SetLoadCommentsForTruckList(long SalesOrderReleaseNumber)
        //{
        //    long? partNumber;
        //    StringBuilder comment = new StringBuilder();
        //    partNumber = SalesOrderRelease.FetchCustomerPartNumberOfSalesOrderDetailByReleaseNumber(SalesOrderReleaseNumber);
           
        //    //Sets the Part Memo information
        //    if (partNumber.HasValue)
        //    {
        //        CustomerPart bobPart = CustomerPart.FetchByNumber(partNumber.Value);
        //        comment.AppendLine("P/L Instructions:");

        //        if (bobPart.PackageLoad1.HasValue && bobPart.PackageLoad1 != 0)
        //        {
        //            GetPackLoadComment(bobPart.PackageLoad1.Value, comment);
        //        }
        //        if (bobPart.PackageLoad2.HasValue && bobPart.PackageLoad2 != 0)
        //        {
        //            GetPackLoadComment(bobPart.PackageLoad2.Value, comment);
        //        }
        //        if (bobPart.PackageLoad3.HasValue && bobPart.PackageLoad3 != 0)
        //        {
        //            GetPackLoadComment(bobPart.PackageLoad3.Value, comment);
        //        }
        //        if (bobPart.PackageLoad4.HasValue && bobPart.PackageLoad4 != 0)
        //        {
        //            GetPackLoadComment(bobPart.PackageLoad4.Value, comment);
        //        }
        //        if (bobPart.PackageLoad5.HasValue && bobPart.PackageLoad5 != 0)
        //        {
        //            GetPackLoadComment(bobPart.PackageLoad5.Value, comment);
        //        }
        //        if (bobPart.PackageLoad6.HasValue && bobPart.PackageLoad6 != 0)
        //        {
        //            GetPackLoadComment(bobPart.PackageLoad6.Value, comment);
        //        }
        //        if (bobPart.PackageLoad7.HasValue && bobPart.PackageLoad7 != 0)
        //        {
        //            GetPackLoadComment(bobPart.PackageLoad7.Value, comment);
        //        }
        //        if (bobPart.PackageLoad8.HasValue && bobPart.PackageLoad8 != 0)
        //        {
        //            GetPackLoadComment(bobPart.PackageLoad8.Value, comment);
        //        }
        //        if (bobPart.PackageLoad9.HasValue && bobPart.PackageLoad9 != 0)
        //        {
        //            GetPackLoadComment(bobPart.PackageLoad9.Value, comment);
        //        }
        //        if (bobPart.PackageLoad10.HasValue && bobPart.PackageLoad10 != 0)
        //        {
        //            GetPackLoadComment(bobPart.PackageLoad10.Value, comment);
        //        }

        //        if (!string.IsNullOrWhiteSpace(bobPart.PackageMemo))
        //        {
        //            comment.AppendLine();
        //            comment.AppendLine("P/L Memo:");
        //            comment.AppendLine(bobPart.PackageMemo);
        //        }
               
        //    }

        //    LoadComments=  comment.ToString();
        //}

        //public void GetPackLoadComment(long pklNumber, StringBuilder comment)
        //{
        //    PackageLoad packageLoad = PackageLoad.FetchByNumber(pklNumber);
        //    if (packageLoad == null)
        //    {
        //        return;
        //    }

        //    comment.Append(packageLoad.Description);
        //    if (!string.IsNullOrWhiteSpace(packageLoad.Text))
        //    {
        //        comment.Append($" : {packageLoad.Text}");
        //    }
        //    comment.AppendLine();
        //}

    }

    public class RuanOrderIntegrationHelperDataList : List<RuanOrderIntegrationHelperData>
    {
    }
}
