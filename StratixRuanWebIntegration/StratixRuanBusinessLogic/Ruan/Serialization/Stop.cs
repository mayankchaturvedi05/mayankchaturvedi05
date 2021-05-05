namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.DataContract(Name="Stop")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class TransportationArrangedStop
    {
        [System.Runtime.Serialization.DataMember]
        public string StopNumber { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string StopType { get; set; }

        [System.Runtime.Serialization.DataMember]
        public Serialization.Location Location { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string StopPlannedArrivalDateTime { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string StopActualArrivalDateTime { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string StopPlannedDepartureDateTime { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string StopActualDepartureDateTime { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string StopPickupAppointmentDateTime { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string StopDeliveryAppointmentDateTime { get; set; }

        [System.Runtime.Serialization.DataMember]
        [System.Xml.Serialization.XmlArrayItemAttribute("TransportationArrangedOrder", IsNullable = false)]
        public Order[] Orders { get; set; }

        [System.Runtime.Serialization.DataMember]
        [System.Xml.Serialization.XmlArrayItemAttribute("ReferenceNumber", IsNullable = false)]
        public ReferenceNumber[] References { get; set; }

    }
}