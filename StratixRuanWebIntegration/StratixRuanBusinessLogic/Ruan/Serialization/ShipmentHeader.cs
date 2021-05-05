using System.Collections.Generic;
using System.Linq;

namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.Runtime.Serialization.DataContract]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class ShipmentHeader
    {
        [System.Runtime.Serialization.DataMember]
        public string DomainName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ShipmentNumber { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ShipmentName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string TransactionCode { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ServiceProviderDomain { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ServiceProvider { get; set; }
        public bool ShouldSerializeServiceProver => !string.IsNullOrEmpty(ServiceProvider);

        [System.Runtime.Serialization.DataMember]
        public string ProcessAsFlowThru { get; set; }
        public bool ShouldSerializeProcessAsFlowThru => !string.IsNullOrEmpty(ProcessAsFlowThru);

        [System.Runtime.Serialization.DataMember]
        public string TransportMode { get; set; }
        public bool ShouldSerializeTransportMode => !string.IsNullOrEmpty(TransportMode);

        [System.Runtime.Serialization.DataMember]
        public string StopCount { get; set; }
        public bool ShouldSerializeStropCount => !string.IsNullOrEmpty(StopCount);

        [System.Runtime.Serialization.DataMember]
        public string ShipmentAsWork { get; set; }
        public bool ShouldSerializeShipmentAsWork => !string.IsNullOrEmpty(ShipmentAsWork);

        [System.Runtime.Serialization.DataMember]
        public string AutoGenerateRelease { get; set; }
        public bool ShouldSerializeAutoGenerateRelease => !string.IsNullOrEmpty(AutoGenerateRelease);

        [System.Runtime.Serialization.DataMember]
        [System.Xml.Serialization.XmlArrayItem("ReferenceNumber")]
        public System.Collections.Generic.List<ReferenceNumber> ReferenceNumbers { get; set; } = new List<ReferenceNumber>();
        public bool ShouldSerializeReferenceNumbers()
        {
            return ReferenceNumbers.Any();
        }

        [System.Runtime.Serialization.DataMember]
        public FlexFieldStrings FlexFieldStrings { get; set; } = new FlexFieldStrings();
        public bool ShouldSerializeFlexFieldStrings()
        {
            return FlexFieldStrings.ShouldSerializeAttribute1();
        }

        [System.Runtime.Serialization.DataMember]
        public FlexFieldNumbers FlexFieldNumbers { get; set; } = new FlexFieldNumbers();
        public bool ShouldSerializeFlexFieldNumbers()
        {
            return !string.IsNullOrEmpty(FlexFieldNumbers.AttributeNumber1);
        }

        [System.Runtime.Serialization.DataMember]
        public FlexFieldDates FlexFieldDates { get; set; } = new FlexFieldDates();
        public bool ShouldSerializeFlexFieldDates()
        {
            return FlexFieldDates.ShouldSerializeAttributeDate1();
        }

        [System.Runtime.Serialization.DataMember]
        public FlexFieldCurrencies FlexFieldCurrencies { get; set; } = new FlexFieldCurrencies();
        public bool ShouldSerializeFlexFieldCurrencies()
        {
            return FlexFieldCurrencies.ShouldSerializeAttributeCurrency1();
        } 
    }
}