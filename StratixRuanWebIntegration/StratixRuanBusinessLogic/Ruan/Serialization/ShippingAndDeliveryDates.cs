using System;

namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.Runtime.Serialization.DataContract]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class ShippingAndDeliveryDates
    {
        [System.Xml.Serialization.XmlIgnore] public System.DateTime ShipDateTimeEarly { get; set; }

        [System.Runtime.Serialization.DataMember]
        [System.Xml.Serialization.XmlElement("ShipDateTimeEarly")]
        public string ShipDateTimeEarlyString
        {
            get => $"{ShipDateTimeEarly:yyyy-MM-ddTHH:mm:ss}";
            set => ShipDateTimeEarly = DateTime.Parse(value);
        }
        public bool ShouldSerializeShipDateTimeEarlyString()
        {
            return ShipDateTimeEarly != DateTime.MinValue;
        }

        [System.Xml.Serialization.XmlIgnore] public System.DateTime ShipDateTimeLate { get; set; }

        [System.Runtime.Serialization.DataMember]
        [System.Xml.Serialization.XmlElement("ShipDateTimeLate")]
        public string ShipDateTimeLateString
        {
            get => $"{ShipDateTimeLate:yyyy-MM-ddTHH:mm:ss}";
            set => ShipDateTimeLate = DateTime.Parse(value);
        }
        public bool ShouldSerializeShipDateTimeLateString()
        {
            return ShipDateTimeLate != DateTime.MinValue;
        }

        [System.Runtime.Serialization.DataMember]
        public string ShipAppointmentFlag { get; set; }
        public bool ShouldShipAppointmentFlag => !string.IsNullOrEmpty(ShipAppointmentFlag);

        [System.Xml.Serialization.XmlIgnore] public System.DateTime DeliveryDateTimeEarly { get; set; }

        [System.Runtime.Serialization.DataMember]
        [System.Xml.Serialization.XmlElement("DeliveryDateTimeEarly")]
        public string DeliveryDateTimeEarlyString
        {
            get => $"{DeliveryDateTimeEarly:yyyy-MM-ddTHH:mm:ss}";
            set => DeliveryDateTimeEarly = DateTime.Parse(value);
        }
        public bool ShouldSerializeDeliveryDateTimeEarlyString()
        {
            return DeliveryDateTimeEarly != DateTime.MinValue;
        }

        [System.Xml.Serialization.XmlIgnore] public System.DateTime DeliveryDateTimeLate { get; set; }

        [System.Runtime.Serialization.DataMember]
        [System.Xml.Serialization.XmlElement("DeliveryDateTimeLate")]
        public string DeliveryDateTimeLateString
        {
            get => $"{DeliveryDateTimeLate:yyyy-MM-ddTHH:mm:ss}";
            set => DeliveryDateTimeLate = DateTime.Parse(value);
        }
        public bool ShouldSerializeDeliveryDateTimeLateString()
        {
            return DeliveryDateTimeLate != DateTime.MinValue;
        }

        [System.Runtime.Serialization.DataMember]
        public string DeliveryAppointmentFlag { get; set; }
        public bool ShouldSerializeDeliveryAppointmentFlag => !string.IsNullOrEmpty(DeliveryAppointmentFlag);
    }
}