

namespace StratixRuanBusinessLogic.xsd
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class APIActualShipment
    {

        private string transmissionTypeField;

        private string senderTransmissionNoField;

        private APIActualShipmentActualShipment[] actualShipmentsField;

        /// <remarks/>
        public string TransmissionType
        {
            get
            {
                return this.transmissionTypeField;
            }
            set
            {
                this.transmissionTypeField = value;
            }
        }

        /// <remarks/>
        public string SenderTransmissionNo
        {
            get
            {
                return this.senderTransmissionNoField;
            }
            set
            {
                this.senderTransmissionNoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ActualShipment")]
        public APIActualShipmentActualShipment[] ActualShipments
        {
            get
            {
                return this.actualShipmentsField;
            }
            set
            {
                this.actualShipmentsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipment
    {

        private string messageIdField;

        private APIActualShipmentActualShipmentShipmentHeader shipmentHeaderField;

        private APIActualShipmentActualShipmentStop[] stopsField;

        private APIActualShipmentActualShipmentShipUnit[] shipUnitsField;

        private APIActualShipmentActualShipmentReleaseOrder[] releaseOrdersField;

        /// <remarks/>
        public string MessageId
        {
            get
            {
                return this.messageIdField;
            }
            set
            {
                this.messageIdField = value;
            }
        }

        /// <remarks/>
        public APIActualShipmentActualShipmentShipmentHeader ShipmentHeader
        {
            get
            {
                return this.shipmentHeaderField;
            }
            set
            {
                this.shipmentHeaderField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Stop")]
        public APIActualShipmentActualShipmentStop[] Stops
        {
            get
            {
                return this.stopsField;
            }
            set
            {
                this.stopsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ShipUnit")]
        public APIActualShipmentActualShipmentShipUnit[] ShipUnits
        {
            get
            {
                return this.shipUnitsField;
            }
            set
            {
                this.shipUnitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ReleaseOrder")]
        public APIActualShipmentActualShipmentReleaseOrder[] ReleaseOrders
        {
            get
            {
                return this.releaseOrdersField;
            }
            set
            {
                this.releaseOrdersField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentShipmentHeader
    {

        private string domainNameField;

        private string shipmentNumberField;

        private string shipmentNameField;

        private string transactionCodeField;

        private string serviceProviderDomainField;

        private string serviceProviderField;

        private string isFixedDistanceField;

        private byte loadedDistanceField;

        private string loadedDistanceUOMField;

        private string globalCurrencyCodeField;

        private byte totalCostField;

        private string isCostFixedField;

        private string processAsFlowThruField;

        private string transportModeField;

        private byte stopCountField;

        private string shipmentAsWorkField;

        private string autoGenerateReleaseField;

        private string sEquipmentDomainField;

        private string sEquipmentField;

        private string equipmentDomainField;

        private string equipmentField;

        private APIActualShipmentActualShipmentShipmentHeaderReferenceNumber[] referenceNumbersField;

        private APIActualShipmentActualShipmentShipmentHeaderShipmentCost[] shipmentCostsField;

        private APIActualShipmentActualShipmentShipmentHeaderFlexFieldStrings flexFieldStringsField;

        private APIActualShipmentActualShipmentShipmentHeaderFlexFieldNumbers flexFieldNumbersField;

        private APIActualShipmentActualShipmentShipmentHeaderFlexFieldCurrencies flexFieldCurrenciesField;

        /// <remarks/>
        public string DomainName
        {
            get
            {
                return this.domainNameField;
            }
            set
            {
                this.domainNameField = value;
            }
        }

        /// <remarks/>
        public string ShipmentNumber
        {
            get
            {
                return this.shipmentNumberField;
            }
            set
            {
                this.shipmentNumberField = value;
            }
        }

        /// <remarks/>
        public string ShipmentName
        {
            get
            {
                return this.shipmentNameField;
            }
            set
            {
                this.shipmentNameField = value;
            }
        }

        /// <remarks/>
        public string TransactionCode
        {
            get
            {
                return this.transactionCodeField;
            }
            set
            {
                this.transactionCodeField = value;
            }
        }

        /// <remarks/>
        public string ServiceProviderDomain
        {
            get
            {
                return this.serviceProviderDomainField;
            }
            set
            {
                this.serviceProviderDomainField = value;
            }
        }

        /// <remarks/>
        public string ServiceProvider
        {
            get
            {
                return this.serviceProviderField;
            }
            set
            {
                this.serviceProviderField = value;
            }
        }

        /// <remarks/>
        public string IsFixedDistance
        {
            get
            {
                return this.isFixedDistanceField;
            }
            set
            {
                this.isFixedDistanceField = value;
            }
        }

        /// <remarks/>
        public byte LoadedDistance
        {
            get
            {
                return this.loadedDistanceField;
            }
            set
            {
                this.loadedDistanceField = value;
            }
        }

        /// <remarks/>
        public string LoadedDistanceUOM
        {
            get
            {
                return this.loadedDistanceUOMField;
            }
            set
            {
                this.loadedDistanceUOMField = value;
            }
        }

        /// <remarks/>
        public string GlobalCurrencyCode
        {
            get
            {
                return this.globalCurrencyCodeField;
            }
            set
            {
                this.globalCurrencyCodeField = value;
            }
        }

        /// <remarks/>
        public byte TotalCost
        {
            get
            {
                return this.totalCostField;
            }
            set
            {
                this.totalCostField = value;
            }
        }

        /// <remarks/>
        public string IsCostFixed
        {
            get
            {
                return this.isCostFixedField;
            }
            set
            {
                this.isCostFixedField = value;
            }
        }

        /// <remarks/>
        public string ProcessAsFlowThru
        {
            get
            {
                return this.processAsFlowThruField;
            }
            set
            {
                this.processAsFlowThruField = value;
            }
        }

        /// <remarks/>
        public string TransportMode
        {
            get
            {
                return this.transportModeField;
            }
            set
            {
                this.transportModeField = value;
            }
        }

        /// <remarks/>
        public byte StopCount
        {
            get
            {
                return this.stopCountField;
            }
            set
            {
                this.stopCountField = value;
            }
        }

        /// <remarks/>
        public string ShipmentAsWork
        {
            get
            {
                return this.shipmentAsWorkField;
            }
            set
            {
                this.shipmentAsWorkField = value;
            }
        }

        /// <remarks/>
        public string AutoGenerateRelease
        {
            get
            {
                return this.autoGenerateReleaseField;
            }
            set
            {
                this.autoGenerateReleaseField = value;
            }
        }

        /// <remarks/>
        public string SEquipmentDomain
        {
            get
            {
                return this.sEquipmentDomainField;
            }
            set
            {
                this.sEquipmentDomainField = value;
            }
        }

        /// <remarks/>
        public string SEquipment
        {
            get
            {
                return this.sEquipmentField;
            }
            set
            {
                this.sEquipmentField = value;
            }
        }

        /// <remarks/>
        public string EquipmentDomain
        {
            get
            {
                return this.equipmentDomainField;
            }
            set
            {
                this.equipmentDomainField = value;
            }
        }

        /// <remarks/>
        public string Equipment
        {
            get
            {
                return this.equipmentField;
            }
            set
            {
                this.equipmentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ReferenceNumber")]
        public APIActualShipmentActualShipmentShipmentHeaderReferenceNumber[] ReferenceNumbers
        {
            get
            {
                return this.referenceNumbersField;
            }
            set
            {
                this.referenceNumbersField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ShipmentCost")]
        public APIActualShipmentActualShipmentShipmentHeaderShipmentCost[] ShipmentCosts
        {
            get
            {
                return this.shipmentCostsField;
            }
            set
            {
                this.shipmentCostsField = value;
            }
        }

        /// <remarks/>
        public APIActualShipmentActualShipmentShipmentHeaderFlexFieldStrings FlexFieldStrings
        {
            get
            {
                return this.flexFieldStringsField;
            }
            set
            {
                this.flexFieldStringsField = value;
            }
        }

        /// <remarks/>
        public APIActualShipmentActualShipmentShipmentHeaderFlexFieldNumbers FlexFieldNumbers
        {
            get
            {
                return this.flexFieldNumbersField;
            }
            set
            {
                this.flexFieldNumbersField = value;
            }
        }

        /// <remarks/>
        public APIActualShipmentActualShipmentShipmentHeaderFlexFieldCurrencies FlexFieldCurrencies
        {
            get
            {
                return this.flexFieldCurrenciesField;
            }
            set
            {
                this.flexFieldCurrenciesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentShipmentHeaderReferenceNumber
    {

        private string domainNameField;

        private string referenceNumberTypeField;

        private string referenceNumberValueField;

        /// <remarks/>
        public string DomainName
        {
            get
            {
                return this.domainNameField;
            }
            set
            {
                this.domainNameField = value;
            }
        }

        /// <remarks/>
        public string ReferenceNumberType
        {
            get
            {
                return this.referenceNumberTypeField;
            }
            set
            {
                this.referenceNumberTypeField = value;
            }
        }

        /// <remarks/>
        public string ReferenceNumberValue
        {
            get
            {
                return this.referenceNumberValueField;
            }
            set
            {
                this.referenceNumberValueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentShipmentHeaderShipmentCost
    {

        private string shipmentCostSeqnoField;

        private string transactionCodeField;

        private string costTypeField;

        private byte costField;

        private string isCostFixedField;

        private string processAsFlowThruField;

        private byte financialAmountField;

        private string currencyCodeField;

        private byte monetaryAmountField;

        private string rateToBaseField;

        private string accessorialCodeDomainNameField;

        private string accessorialCodeField;

        /// <remarks/>
        public string ShipmentCostSeqno
        {
            get
            {
                return this.shipmentCostSeqnoField;
            }
            set
            {
                this.shipmentCostSeqnoField = value;
            }
        }

        /// <remarks/>
        public string TransactionCode
        {
            get
            {
                return this.transactionCodeField;
            }
            set
            {
                this.transactionCodeField = value;
            }
        }

        /// <remarks/>
        public string CostType
        {
            get
            {
                return this.costTypeField;
            }
            set
            {
                this.costTypeField = value;
            }
        }

        /// <remarks/>
        public byte Cost
        {
            get
            {
                return this.costField;
            }
            set
            {
                this.costField = value;
            }
        }

        /// <remarks/>
        public string IsCostFixed
        {
            get
            {
                return this.isCostFixedField;
            }
            set
            {
                this.isCostFixedField = value;
            }
        }

        /// <remarks/>
        public string ProcessAsFlowThru
        {
            get
            {
                return this.processAsFlowThruField;
            }
            set
            {
                this.processAsFlowThruField = value;
            }
        }

        /// <remarks/>
        public byte FinancialAmount
        {
            get
            {
                return this.financialAmountField;
            }
            set
            {
                this.financialAmountField = value;
            }
        }

        /// <remarks/>
        public string CurrencyCode
        {
            get
            {
                return this.currencyCodeField;
            }
            set
            {
                this.currencyCodeField = value;
            }
        }

        /// <remarks/>
        public byte MonetaryAmount
        {
            get
            {
                return this.monetaryAmountField;
            }
            set
            {
                this.monetaryAmountField = value;
            }
        }

        /// <remarks/>
        public string RateToBase
        {
            get
            {
                return this.rateToBaseField;
            }
            set
            {
                this.rateToBaseField = value;
            }
        }

        /// <remarks/>
        public string AccessorialCodeDomainName
        {
            get
            {
                return this.accessorialCodeDomainNameField;
            }
            set
            {
                this.accessorialCodeDomainNameField = value;
            }
        }

        /// <remarks/>
        public string AccessorialCode
        {
            get
            {
                return this.accessorialCodeField;
            }
            set
            {
                this.accessorialCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentShipmentHeaderFlexFieldStrings
    {

        private string attribute1Field;

        private string attribute2Field;

        private string attribute3Field;

        private string attribute4Field;

        private string attribute5Field;

        private string attribute6Field;

        private string attribute7Field;

        private string attribute8Field;

        private string attribute9Field;

        private string attribute10Field;

        private string attribute11Field;

        private string attribute12Field;

        private string attribute13Field;

        private string attribute14Field;

        private string attribute15Field;

        private string attribute16Field;

        private string attribute17Field;

        private string attribute18Field;

        private string attribute19Field;

        private string attribute20Field;

        /// <remarks/>
        public string Attribute1
        {
            get
            {
                return this.attribute1Field;
            }
            set
            {
                this.attribute1Field = value;
            }
        }

        /// <remarks/>
        public string Attribute2
        {
            get
            {
                return this.attribute2Field;
            }
            set
            {
                this.attribute2Field = value;
            }
        }

        /// <remarks/>
        public string Attribute3
        {
            get
            {
                return this.attribute3Field;
            }
            set
            {
                this.attribute3Field = value;
            }
        }

        /// <remarks/>
        public string Attribute4
        {
            get
            {
                return this.attribute4Field;
            }
            set
            {
                this.attribute4Field = value;
            }
        }

        /// <remarks/>
        public string Attribute5
        {
            get
            {
                return this.attribute5Field;
            }
            set
            {
                this.attribute5Field = value;
            }
        }

        /// <remarks/>
        public string Attribute6
        {
            get
            {
                return this.attribute6Field;
            }
            set
            {
                this.attribute6Field = value;
            }
        }

        /// <remarks/>
        public string Attribute7
        {
            get
            {
                return this.attribute7Field;
            }
            set
            {
                this.attribute7Field = value;
            }
        }

        /// <remarks/>
        public string Attribute8
        {
            get
            {
                return this.attribute8Field;
            }
            set
            {
                this.attribute8Field = value;
            }
        }

        /// <remarks/>
        public string Attribute9
        {
            get
            {
                return this.attribute9Field;
            }
            set
            {
                this.attribute9Field = value;
            }
        }

        /// <remarks/>
        public string Attribute10
        {
            get
            {
                return this.attribute10Field;
            }
            set
            {
                this.attribute10Field = value;
            }
        }

        /// <remarks/>
        public string Attribute11
        {
            get
            {
                return this.attribute11Field;
            }
            set
            {
                this.attribute11Field = value;
            }
        }

        /// <remarks/>
        public string Attribute12
        {
            get
            {
                return this.attribute12Field;
            }
            set
            {
                this.attribute12Field = value;
            }
        }

        /// <remarks/>
        public string Attribute13
        {
            get
            {
                return this.attribute13Field;
            }
            set
            {
                this.attribute13Field = value;
            }
        }

        /// <remarks/>
        public string Attribute14
        {
            get
            {
                return this.attribute14Field;
            }
            set
            {
                this.attribute14Field = value;
            }
        }

        /// <remarks/>
        public string Attribute15
        {
            get
            {
                return this.attribute15Field;
            }
            set
            {
                this.attribute15Field = value;
            }
        }

        /// <remarks/>
        public string Attribute16
        {
            get
            {
                return this.attribute16Field;
            }
            set
            {
                this.attribute16Field = value;
            }
        }

        /// <remarks/>
        public string Attribute17
        {
            get
            {
                return this.attribute17Field;
            }
            set
            {
                this.attribute17Field = value;
            }
        }

        /// <remarks/>
        public string Attribute18
        {
            get
            {
                return this.attribute18Field;
            }
            set
            {
                this.attribute18Field = value;
            }
        }

        /// <remarks/>
        public string Attribute19
        {
            get
            {
                return this.attribute19Field;
            }
            set
            {
                this.attribute19Field = value;
            }
        }

        /// <remarks/>
        public string Attribute20
        {
            get
            {
                return this.attribute20Field;
            }
            set
            {
                this.attribute20Field = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentShipmentHeaderFlexFieldNumbers
    {

        private object attributeNumber1Field;

        private object attributeNumber2Field;

        private object attributeNumber3Field;

        private object attributeNumber4Field;

        private object attributeNumber5Field;

        private object attributeNumber6Field;

        private object attributeNumber7Field;

        private object attributeNumber8Field;

        private object attributeNumber9Field;

        private object attributeNumber10Field;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object AttributeNumber1
        {
            get
            {
                return this.attributeNumber1Field;
            }
            set
            {
                this.attributeNumber1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object AttributeNumber2
        {
            get
            {
                return this.attributeNumber2Field;
            }
            set
            {
                this.attributeNumber2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object AttributeNumber3
        {
            get
            {
                return this.attributeNumber3Field;
            }
            set
            {
                this.attributeNumber3Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object AttributeNumber4
        {
            get
            {
                return this.attributeNumber4Field;
            }
            set
            {
                this.attributeNumber4Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object AttributeNumber5
        {
            get
            {
                return this.attributeNumber5Field;
            }
            set
            {
                this.attributeNumber5Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object AttributeNumber6
        {
            get
            {
                return this.attributeNumber6Field;
            }
            set
            {
                this.attributeNumber6Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object AttributeNumber7
        {
            get
            {
                return this.attributeNumber7Field;
            }
            set
            {
                this.attributeNumber7Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object AttributeNumber8
        {
            get
            {
                return this.attributeNumber8Field;
            }
            set
            {
                this.attributeNumber8Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object AttributeNumber9
        {
            get
            {
                return this.attributeNumber9Field;
            }
            set
            {
                this.attributeNumber9Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object AttributeNumber10
        {
            get
            {
                return this.attributeNumber10Field;
            }
            set
            {
                this.attributeNumber10Field = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentShipmentHeaderFlexFieldCurrencies
    {

        private APIActualShipmentActualShipmentShipmentHeaderFlexFieldCurrenciesAttributeCurrency1 attributeCurrency1Field;

        private APIActualShipmentActualShipmentShipmentHeaderFlexFieldCurrenciesAttributeCurrency2 attributeCurrency2Field;

        private APIActualShipmentActualShipmentShipmentHeaderFlexFieldCurrenciesAttributeCurrency3 attributeCurrency3Field;

        /// <remarks/>
        public APIActualShipmentActualShipmentShipmentHeaderFlexFieldCurrenciesAttributeCurrency1 AttributeCurrency1
        {
            get
            {
                return this.attributeCurrency1Field;
            }
            set
            {
                this.attributeCurrency1Field = value;
            }
        }

        /// <remarks/>
        public APIActualShipmentActualShipmentShipmentHeaderFlexFieldCurrenciesAttributeCurrency2 AttributeCurrency2
        {
            get
            {
                return this.attributeCurrency2Field;
            }
            set
            {
                this.attributeCurrency2Field = value;
            }
        }

        /// <remarks/>
        public APIActualShipmentActualShipmentShipmentHeaderFlexFieldCurrenciesAttributeCurrency3 AttributeCurrency3
        {
            get
            {
                return this.attributeCurrency3Field;
            }
            set
            {
                this.attributeCurrency3Field = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentShipmentHeaderFlexFieldCurrenciesAttributeCurrency1
    {

        private APIActualShipmentActualShipmentShipmentHeaderFlexFieldCurrenciesAttributeCurrency1FinancialAmount financialAmountField;

        /// <remarks/>
        public APIActualShipmentActualShipmentShipmentHeaderFlexFieldCurrenciesAttributeCurrency1FinancialAmount FinancialAmount
        {
            get
            {
                return this.financialAmountField;
            }
            set
            {
                this.financialAmountField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentShipmentHeaderFlexFieldCurrenciesAttributeCurrency1FinancialAmount
    {

        private string globalCurrencyCodeField;

        private object monetaryAmountField;

        private object rateToBaseField;

        private object funcCurrencyAmountField;

        /// <remarks/>
        public string GlobalCurrencyCode
        {
            get
            {
                return this.globalCurrencyCodeField;
            }
            set
            {
                this.globalCurrencyCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object MonetaryAmount
        {
            get
            {
                return this.monetaryAmountField;
            }
            set
            {
                this.monetaryAmountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object RateToBase
        {
            get
            {
                return this.rateToBaseField;
            }
            set
            {
                this.rateToBaseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object FuncCurrencyAmount
        {
            get
            {
                return this.funcCurrencyAmountField;
            }
            set
            {
                this.funcCurrencyAmountField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentShipmentHeaderFlexFieldCurrenciesAttributeCurrency2
    {

        private APIActualShipmentActualShipmentShipmentHeaderFlexFieldCurrenciesAttributeCurrency2FinancialAmount financialAmountField;

        /// <remarks/>
        public APIActualShipmentActualShipmentShipmentHeaderFlexFieldCurrenciesAttributeCurrency2FinancialAmount FinancialAmount
        {
            get
            {
                return this.financialAmountField;
            }
            set
            {
                this.financialAmountField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentShipmentHeaderFlexFieldCurrenciesAttributeCurrency2FinancialAmount
    {

        private string globalCurrencyCodeField;

        private byte monetaryAmountField;

        private byte rateToBaseField;

        private byte funcCurrencyAmountField;

        /// <remarks/>
        public string GlobalCurrencyCode
        {
            get
            {
                return this.globalCurrencyCodeField;
            }
            set
            {
                this.globalCurrencyCodeField = value;
            }
        }

        /// <remarks/>
        public byte MonetaryAmount
        {
            get
            {
                return this.monetaryAmountField;
            }
            set
            {
                this.monetaryAmountField = value;
            }
        }

        /// <remarks/>
        public byte RateToBase
        {
            get
            {
                return this.rateToBaseField;
            }
            set
            {
                this.rateToBaseField = value;
            }
        }

        /// <remarks/>
        public byte FuncCurrencyAmount
        {
            get
            {
                return this.funcCurrencyAmountField;
            }
            set
            {
                this.funcCurrencyAmountField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentShipmentHeaderFlexFieldCurrenciesAttributeCurrency3
    {

        private APIActualShipmentActualShipmentShipmentHeaderFlexFieldCurrenciesAttributeCurrency3FinancialAmount financialAmountField;

        /// <remarks/>
        public APIActualShipmentActualShipmentShipmentHeaderFlexFieldCurrenciesAttributeCurrency3FinancialAmount FinancialAmount
        {
            get
            {
                return this.financialAmountField;
            }
            set
            {
                this.financialAmountField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentShipmentHeaderFlexFieldCurrenciesAttributeCurrency3FinancialAmount
    {

        private string globalCurrencyCodeField;

        private object monetaryAmountField;

        private object rateToBaseField;

        private object funcCurrencyAmountField;

        /// <remarks/>
        public string GlobalCurrencyCode
        {
            get
            {
                return this.globalCurrencyCodeField;
            }
            set
            {
                this.globalCurrencyCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object MonetaryAmount
        {
            get
            {
                return this.monetaryAmountField;
            }
            set
            {
                this.monetaryAmountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object RateToBase
        {
            get
            {
                return this.rateToBaseField;
            }
            set
            {
                this.rateToBaseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object FuncCurrencyAmount
        {
            get
            {
                return this.funcCurrencyAmountField;
            }
            set
            {
                this.funcCurrencyAmountField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentStop
    {

        private string domainNameField;

        private byte stopSequenceField;

        private string locationIDField;

        private string locationNameField;

        private string locationAddress1Field;

        private string locationAddress2Field;

        private string locationCityField;

        private string locationStateField;

        private string locationZipField;

        private string locationCountryField;

        private byte distanceFromPreviousStopField;

        private string distanceFromPreviousStopUOMField;

        private string actualArrivalTimeField;

        private string plannedArrivalTimeField;

        private string arrivalIsPlannedTimeFixedField;

        private string actualDepartureTimeField;

        private string plannedDepartureTimeField;

        private string departureIsPlannedTimeFixedField;

        private string activityField;

        private string shipUnitKeyField;

        private bool postLocationToOTMField;

        private string stopTypeField;

        private APIActualShipmentActualShipmentStopShipmentStopDetail[] shipmentStopDetailsField;

        private APIActualShipmentActualShipmentStopFlexFieldStrings flexFieldStringsField;

        private APIActualShipmentActualShipmentStopFlexFieldNumbers flexFieldNumbersField;

        private APIActualShipmentActualShipmentStopFlexFieldCurrencies flexFieldCurrenciesField;

        /// <remarks/>
        public string DomainName
        {
            get
            {
                return this.domainNameField;
            }
            set
            {
                this.domainNameField = value;
            }
        }

        /// <remarks/>
        public byte StopSequence
        {
            get
            {
                return this.stopSequenceField;
            }
            set
            {
                this.stopSequenceField = value;
            }
        }

        /// <remarks/>
        public string LocationID
        {
            get
            {
                return this.locationIDField;
            }
            set
            {
                this.locationIDField = value;
            }
        }

        /// <remarks/>
        public string LocationName
        {
            get
            {
                return this.locationNameField;
            }
            set
            {
                this.locationNameField = value;
            }
        }

        /// <remarks/>
        public string LocationAddress1
        {
            get
            {
                return this.locationAddress1Field;
            }
            set
            {
                this.locationAddress1Field = value;
            }
        }

        /// <remarks/>
        public string LocationAddress2
        {
            get
            {
                return this.locationAddress2Field;
            }
            set
            {
                this.locationAddress2Field = value;
            }
        }

        /// <remarks/>
        public string LocationCity
        {
            get
            {
                return this.locationCityField;
            }
            set
            {
                this.locationCityField = value;
            }
        }

        /// <remarks/>
        public string LocationState
        {
            get
            {
                return this.locationStateField;
            }
            set
            {
                this.locationStateField = value;
            }
        }

        /// <remarks/>
        public string LocationZip
        {
            get
            {
                return this.locationZipField;
            }
            set
            {
                this.locationZipField = value;
            }
        }

        /// <remarks/>
        public string LocationCountry
        {
            get
            {
                return this.locationCountryField;
            }
            set
            {
                this.locationCountryField = value;
            }
        }

        /// <remarks/>
        public byte DistanceFromPreviousStop
        {
            get
            {
                return this.distanceFromPreviousStopField;
            }
            set
            {
                this.distanceFromPreviousStopField = value;
            }
        }

        /// <remarks/>
        public string DistanceFromPreviousStopUOM
        {
            get
            {
                return this.distanceFromPreviousStopUOMField;
            }
            set
            {
                this.distanceFromPreviousStopUOMField = value;
            }
        }

        /// <remarks/>
        public string ActualArrivalTime
        {
            get
            {
                return this.actualArrivalTimeField;
            }
            set
            {
                this.actualArrivalTimeField = value;
            }
        }

        /// <remarks/>
        public string PlannedArrivalTime
        {
            get
            {
                return this.plannedArrivalTimeField;
            }
            set
            {
                this.plannedArrivalTimeField = value;
            }
        }

        /// <remarks/>
        public string ArrivalIsPlannedTimeFixed
        {
            get
            {
                return this.arrivalIsPlannedTimeFixedField;
            }
            set
            {
                this.arrivalIsPlannedTimeFixedField = value;
            }
        }

        /// <remarks/>
        public string ActualDepartureTime
        {
            get
            {
                return this.actualDepartureTimeField;
            }
            set
            {
                this.actualDepartureTimeField = value;
            }
        }

        /// <remarks/>
        public string PlannedDepartureTime
        {
            get
            {
                return this.plannedDepartureTimeField;
            }
            set
            {
                this.plannedDepartureTimeField = value;
            }
        }

        /// <remarks/>
        public string DepartureIsPlannedTimeFixed
        {
            get
            {
                return this.departureIsPlannedTimeFixedField;
            }
            set
            {
                this.departureIsPlannedTimeFixedField = value;
            }
        }

        /// <remarks/>
        public string Activity
        {
            get
            {
                return this.activityField;
            }
            set
            {
                this.activityField = value;
            }
        }

        /// <remarks/>
        public string ShipUnitKey
        {
            get
            {
                return this.shipUnitKeyField;
            }
            set
            {
                this.shipUnitKeyField = value;
            }
        }

        /// <remarks/>
        public bool PostLocationToOTM
        {
            get
            {
                return this.postLocationToOTMField;
            }
            set
            {
                this.postLocationToOTMField = value;
            }
        }

        /// <remarks/>
        public string StopType
        {
            get
            {
                return this.stopTypeField;
            }
            set
            {
                this.stopTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ShipmentStopDetail")]
        public APIActualShipmentActualShipmentStopShipmentStopDetail[] ShipmentStopDetails
        {
            get
            {
                return this.shipmentStopDetailsField;
            }
            set
            {
                this.shipmentStopDetailsField = value;
            }
        }

        /// <remarks/>
        public APIActualShipmentActualShipmentStopFlexFieldStrings FlexFieldStrings
        {
            get
            {
                return this.flexFieldStringsField;
            }
            set
            {
                this.flexFieldStringsField = value;
            }
        }

        /// <remarks/>
        public APIActualShipmentActualShipmentStopFlexFieldNumbers FlexFieldNumbers
        {
            get
            {
                return this.flexFieldNumbersField;
            }
            set
            {
                this.flexFieldNumbersField = value;
            }
        }

        /// <remarks/>
        public APIActualShipmentActualShipmentStopFlexFieldCurrencies FlexFieldCurrencies
        {
            get
            {
                return this.flexFieldCurrenciesField;
            }
            set
            {
                this.flexFieldCurrenciesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentStopShipmentStopDetail
    {

        private string shipUnitKeyField;

        private string activityField;

        /// <remarks/>
        public string ShipUnitKey
        {
            get
            {
                return this.shipUnitKeyField;
            }
            set
            {
                this.shipUnitKeyField = value;
            }
        }

        /// <remarks/>
        public string Activity
        {
            get
            {
                return this.activityField;
            }
            set
            {
                this.activityField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentStopFlexFieldStrings
    {

        private string attribute1Field;

        private string attribute2Field;

        private string attribute3Field;

        private string attribute4Field;

        private string attribute5Field;

        private string attribute6Field;

        private string attribute7Field;

        private string attribute8Field;

        private string attribute9Field;

        private string attribute10Field;

        private string attribute11Field;

        private string attribute12Field;

        private string attribute13Field;

        private string attribute14Field;

        private string attribute15Field;

        private string attribute16Field;

        private string attribute17Field;

        private string attribute18Field;

        private string attribute19Field;

        private string attribute20Field;

        /// <remarks/>
        public string Attribute1
        {
            get
            {
                return this.attribute1Field;
            }
            set
            {
                this.attribute1Field = value;
            }
        }

        /// <remarks/>
        public string Attribute2
        {
            get
            {
                return this.attribute2Field;
            }
            set
            {
                this.attribute2Field = value;
            }
        }

        /// <remarks/>
        public string Attribute3
        {
            get
            {
                return this.attribute3Field;
            }
            set
            {
                this.attribute3Field = value;
            }
        }

        /// <remarks/>
        public string Attribute4
        {
            get
            {
                return this.attribute4Field;
            }
            set
            {
                this.attribute4Field = value;
            }
        }

        /// <remarks/>
        public string Attribute5
        {
            get
            {
                return this.attribute5Field;
            }
            set
            {
                this.attribute5Field = value;
            }
        }

        /// <remarks/>
        public string Attribute6
        {
            get
            {
                return this.attribute6Field;
            }
            set
            {
                this.attribute6Field = value;
            }
        }

        /// <remarks/>
        public string Attribute7
        {
            get
            {
                return this.attribute7Field;
            }
            set
            {
                this.attribute7Field = value;
            }
        }

        /// <remarks/>
        public string Attribute8
        {
            get
            {
                return this.attribute8Field;
            }
            set
            {
                this.attribute8Field = value;
            }
        }

        /// <remarks/>
        public string Attribute9
        {
            get
            {
                return this.attribute9Field;
            }
            set
            {
                this.attribute9Field = value;
            }
        }

        /// <remarks/>
        public string Attribute10
        {
            get
            {
                return this.attribute10Field;
            }
            set
            {
                this.attribute10Field = value;
            }
        }

        /// <remarks/>
        public string Attribute11
        {
            get
            {
                return this.attribute11Field;
            }
            set
            {
                this.attribute11Field = value;
            }
        }

        /// <remarks/>
        public string Attribute12
        {
            get
            {
                return this.attribute12Field;
            }
            set
            {
                this.attribute12Field = value;
            }
        }

        /// <remarks/>
        public string Attribute13
        {
            get
            {
                return this.attribute13Field;
            }
            set
            {
                this.attribute13Field = value;
            }
        }

        /// <remarks/>
        public string Attribute14
        {
            get
            {
                return this.attribute14Field;
            }
            set
            {
                this.attribute14Field = value;
            }
        }

        /// <remarks/>
        public string Attribute15
        {
            get
            {
                return this.attribute15Field;
            }
            set
            {
                this.attribute15Field = value;
            }
        }

        /// <remarks/>
        public string Attribute16
        {
            get
            {
                return this.attribute16Field;
            }
            set
            {
                this.attribute16Field = value;
            }
        }

        /// <remarks/>
        public string Attribute17
        {
            get
            {
                return this.attribute17Field;
            }
            set
            {
                this.attribute17Field = value;
            }
        }

        /// <remarks/>
        public string Attribute18
        {
            get
            {
                return this.attribute18Field;
            }
            set
            {
                this.attribute18Field = value;
            }
        }

        /// <remarks/>
        public string Attribute19
        {
            get
            {
                return this.attribute19Field;
            }
            set
            {
                this.attribute19Field = value;
            }
        }

        /// <remarks/>
        public string Attribute20
        {
            get
            {
                return this.attribute20Field;
            }
            set
            {
                this.attribute20Field = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentStopFlexFieldNumbers
    {

        private object attributeNumber1Field;

        private object attributeNumber2Field;

        private object attributeNumber3Field;

        private object attributeNumber4Field;

        private object attributeNumber5Field;

        private object attributeNumber6Field;

        private object attributeNumber7Field;

        private object attributeNumber8Field;

        private object attributeNumber9Field;

        private object attributeNumber10Field;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object AttributeNumber1
        {
            get
            {
                return this.attributeNumber1Field;
            }
            set
            {
                this.attributeNumber1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object AttributeNumber2
        {
            get
            {
                return this.attributeNumber2Field;
            }
            set
            {
                this.attributeNumber2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object AttributeNumber3
        {
            get
            {
                return this.attributeNumber3Field;
            }
            set
            {
                this.attributeNumber3Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object AttributeNumber4
        {
            get
            {
                return this.attributeNumber4Field;
            }
            set
            {
                this.attributeNumber4Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object AttributeNumber5
        {
            get
            {
                return this.attributeNumber5Field;
            }
            set
            {
                this.attributeNumber5Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object AttributeNumber6
        {
            get
            {
                return this.attributeNumber6Field;
            }
            set
            {
                this.attributeNumber6Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object AttributeNumber7
        {
            get
            {
                return this.attributeNumber7Field;
            }
            set
            {
                this.attributeNumber7Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object AttributeNumber8
        {
            get
            {
                return this.attributeNumber8Field;
            }
            set
            {
                this.attributeNumber8Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object AttributeNumber9
        {
            get
            {
                return this.attributeNumber9Field;
            }
            set
            {
                this.attributeNumber9Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object AttributeNumber10
        {
            get
            {
                return this.attributeNumber10Field;
            }
            set
            {
                this.attributeNumber10Field = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentStopFlexFieldCurrencies
    {

        private APIActualShipmentActualShipmentStopFlexFieldCurrenciesAttributeCurrency1 attributeCurrency1Field;

        private APIActualShipmentActualShipmentStopFlexFieldCurrenciesAttributeCurrency2 attributeCurrency2Field;

        private APIActualShipmentActualShipmentStopFlexFieldCurrenciesAttributeCurrency3 attributeCurrency3Field;

        /// <remarks/>
        public APIActualShipmentActualShipmentStopFlexFieldCurrenciesAttributeCurrency1 AttributeCurrency1
        {
            get
            {
                return this.attributeCurrency1Field;
            }
            set
            {
                this.attributeCurrency1Field = value;
            }
        }

        /// <remarks/>
        public APIActualShipmentActualShipmentStopFlexFieldCurrenciesAttributeCurrency2 AttributeCurrency2
        {
            get
            {
                return this.attributeCurrency2Field;
            }
            set
            {
                this.attributeCurrency2Field = value;
            }
        }

        /// <remarks/>
        public APIActualShipmentActualShipmentStopFlexFieldCurrenciesAttributeCurrency3 AttributeCurrency3
        {
            get
            {
                return this.attributeCurrency3Field;
            }
            set
            {
                this.attributeCurrency3Field = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentStopFlexFieldCurrenciesAttributeCurrency1
    {

        private APIActualShipmentActualShipmentStopFlexFieldCurrenciesAttributeCurrency1FinancialAmount financialAmountField;

        /// <remarks/>
        public APIActualShipmentActualShipmentStopFlexFieldCurrenciesAttributeCurrency1FinancialAmount FinancialAmount
        {
            get
            {
                return this.financialAmountField;
            }
            set
            {
                this.financialAmountField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentStopFlexFieldCurrenciesAttributeCurrency1FinancialAmount
    {

        private string globalCurrencyCodeField;

        private string monetaryAmountField;

        private string rateToBaseField;

        private string funcCurrencyAmountField;

        /// <remarks/>
        public string GlobalCurrencyCode
        {
            get
            {
                return this.globalCurrencyCodeField;
            }
            set
            {
                this.globalCurrencyCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string MonetaryAmount
        {
            get
            {
                return this.monetaryAmountField;
            }
            set
            {
                this.monetaryAmountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string RateToBase
        {
            get
            {
                return this.rateToBaseField;
            }
            set
            {
                this.rateToBaseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string FuncCurrencyAmount
        {
            get
            {
                return this.funcCurrencyAmountField;
            }
            set
            {
                this.funcCurrencyAmountField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentStopFlexFieldCurrenciesAttributeCurrency2
    {

        private APIActualShipmentActualShipmentStopFlexFieldCurrenciesAttributeCurrency2FinancialAmount financialAmountField;

        /// <remarks/>
        public APIActualShipmentActualShipmentStopFlexFieldCurrenciesAttributeCurrency2FinancialAmount FinancialAmount
        {
            get
            {
                return this.financialAmountField;
            }
            set
            {
                this.financialAmountField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentStopFlexFieldCurrenciesAttributeCurrency2FinancialAmount
    {

        private string globalCurrencyCodeField;

        private object monetaryAmountField;

        private object rateToBaseField;

        private object funcCurrencyAmountField;

        /// <remarks/>
        public string GlobalCurrencyCode
        {
            get
            {
                return this.globalCurrencyCodeField;
            }
            set
            {
                this.globalCurrencyCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object MonetaryAmount
        {
            get
            {
                return this.monetaryAmountField;
            }
            set
            {
                this.monetaryAmountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object RateToBase
        {
            get
            {
                return this.rateToBaseField;
            }
            set
            {
                this.rateToBaseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object FuncCurrencyAmount
        {
            get
            {
                return this.funcCurrencyAmountField;
            }
            set
            {
                this.funcCurrencyAmountField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentStopFlexFieldCurrenciesAttributeCurrency3
    {

        private APIActualShipmentActualShipmentStopFlexFieldCurrenciesAttributeCurrency3FinancialAmount financialAmountField;

        /// <remarks/>
        public APIActualShipmentActualShipmentStopFlexFieldCurrenciesAttributeCurrency3FinancialAmount FinancialAmount
        {
            get
            {
                return this.financialAmountField;
            }
            set
            {
                this.financialAmountField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentStopFlexFieldCurrenciesAttributeCurrency3FinancialAmount
    {

        private string globalCurrencyCodeField;

        private string monetaryAmountField;

        private string rateToBaseField;

        private string funcCurrencyAmountField;

        /// <remarks/>
        public string GlobalCurrencyCode
        {
            get
            {
                return this.globalCurrencyCodeField;
            }
            set
            {
                this.globalCurrencyCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string MonetaryAmount
        {
            get
            {
                return this.monetaryAmountField;
            }
            set
            {
                this.monetaryAmountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string RateToBase
        {
            get
            {
                return this.rateToBaseField;
            }
            set
            {
                this.rateToBaseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string FuncCurrencyAmount
        {
            get
            {
                return this.funcCurrencyAmountField;
            }
            set
            {
                this.funcCurrencyAmountField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentShipUnit
    {

        private string shipFromLocationDomainNameField;

        private string shipFromLocationField;

        private string shipToLocationDomainNameField;

        private string shipToLocationField;

        private object stopSequenceField;

        private string domainNameField;

        private string transactionCodeField;

        private string shipUnitKeyField;

        private string shipUnitTypeField;

        private byte shipUnitCountField;

        private byte weightField;

        private string weightUnitOfMeasureField;

        private byte volumeField;

        private string volumeUnitOfMeasureField;

        private byte weightGrossField;

        private string weightGrossUnitOfMeasureField;

        private byte volumeGrossField;

        private string volumeGrossUnitOfMeasureField;

        private byte totalWeightField;

        private byte totalVolumeField;

        private string isSplitAllowedField;

        private string isCountSplittableField;

        private string isRepackAllowedField;

        private string netWeightUOMField;

        private string netVolumeUOMField;

        private APIActualShipmentActualShipmentShipUnitShipUnitContent[] shipUnitContentsField;

        private APIActualShipmentActualShipmentShipUnitReferenceNumber[] referenceNumbersField;

        private APIActualShipmentActualShipmentShipUnitShipUnitDimensions shipUnitDimensionsField;

        /// <remarks/>
        public string ShipFromLocationDomainName
        {
            get
            {
                return this.shipFromLocationDomainNameField;
            }
            set
            {
                this.shipFromLocationDomainNameField = value;
            }
        }

        /// <remarks/>
        public string ShipFromLocation
        {
            get
            {
                return this.shipFromLocationField;
            }
            set
            {
                this.shipFromLocationField = value;
            }
        }

        /// <remarks/>
        public string ShipToLocationDomainName
        {
            get
            {
                return this.shipToLocationDomainNameField;
            }
            set
            {
                this.shipToLocationDomainNameField = value;
            }
        }

        /// <remarks/>
        public string ShipToLocation
        {
            get
            {
                return this.shipToLocationField;
            }
            set
            {
                this.shipToLocationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object StopSequence
        {
            get
            {
                return this.stopSequenceField;
            }
            set
            {
                this.stopSequenceField = value;
            }
        }

        /// <remarks/>
        public string DomainName
        {
            get
            {
                return this.domainNameField;
            }
            set
            {
                this.domainNameField = value;
            }
        }

        /// <remarks/>
        public string TransactionCode
        {
            get
            {
                return this.transactionCodeField;
            }
            set
            {
                this.transactionCodeField = value;
            }
        }

        /// <remarks/>
        public string ShipUnitKey
        {
            get
            {
                return this.shipUnitKeyField;
            }
            set
            {
                this.shipUnitKeyField = value;
            }
        }

        /// <remarks/>
        public string ShipUnitType
        {
            get
            {
                return this.shipUnitTypeField;
            }
            set
            {
                this.shipUnitTypeField = value;
            }
        }

        /// <remarks/>
        public byte ShipUnitCount
        {
            get
            {
                return this.shipUnitCountField;
            }
            set
            {
                this.shipUnitCountField = value;
            }
        }

        /// <remarks/>
        public byte Weight
        {
            get
            {
                return this.weightField;
            }
            set
            {
                this.weightField = value;
            }
        }

        /// <remarks/>
        public string WeightUnitOfMeasure
        {
            get
            {
                return this.weightUnitOfMeasureField;
            }
            set
            {
                this.weightUnitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public byte Volume
        {
            get
            {
                return this.volumeField;
            }
            set
            {
                this.volumeField = value;
            }
        }

        /// <remarks/>
        public string VolumeUnitOfMeasure
        {
            get
            {
                return this.volumeUnitOfMeasureField;
            }
            set
            {
                this.volumeUnitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public byte WeightGross
        {
            get
            {
                return this.weightGrossField;
            }
            set
            {
                this.weightGrossField = value;
            }
        }

        /// <remarks/>
        public string WeightGrossUnitOfMeasure
        {
            get
            {
                return this.weightGrossUnitOfMeasureField;
            }
            set
            {
                this.weightGrossUnitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public byte VolumeGross
        {
            get
            {
                return this.volumeGrossField;
            }
            set
            {
                this.volumeGrossField = value;
            }
        }

        /// <remarks/>
        public string VolumeGrossUnitOfMeasure
        {
            get
            {
                return this.volumeGrossUnitOfMeasureField;
            }
            set
            {
                this.volumeGrossUnitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public byte TotalWeight
        {
            get
            {
                return this.totalWeightField;
            }
            set
            {
                this.totalWeightField = value;
            }
        }

        /// <remarks/>
        public byte TotalVolume
        {
            get
            {
                return this.totalVolumeField;
            }
            set
            {
                this.totalVolumeField = value;
            }
        }

        /// <remarks/>
        public string IsSplitAllowed
        {
            get
            {
                return this.isSplitAllowedField;
            }
            set
            {
                this.isSplitAllowedField = value;
            }
        }

        /// <remarks/>
        public string IsCountSplittable
        {
            get
            {
                return this.isCountSplittableField;
            }
            set
            {
                this.isCountSplittableField = value;
            }
        }

        /// <remarks/>
        public string IsRepackAllowed
        {
            get
            {
                return this.isRepackAllowedField;
            }
            set
            {
                this.isRepackAllowedField = value;
            }
        }

        /// <remarks/>
        public string NetWeightUOM
        {
            get
            {
                return this.netWeightUOMField;
            }
            set
            {
                this.netWeightUOMField = value;
            }
        }

        /// <remarks/>
        public string NetVolumeUOM
        {
            get
            {
                return this.netVolumeUOMField;
            }
            set
            {
                this.netVolumeUOMField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ShipUnitContent")]
        public APIActualShipmentActualShipmentShipUnitShipUnitContent[] ShipUnitContents
        {
            get
            {
                return this.shipUnitContentsField;
            }
            set
            {
                this.shipUnitContentsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ReferenceNumber")]
        public APIActualShipmentActualShipmentShipUnitReferenceNumber[] ReferenceNumbers
        {
            get
            {
                return this.referenceNumbersField;
            }
            set
            {
                this.referenceNumbersField = value;
            }
        }

        /// <remarks/>
        public APIActualShipmentActualShipmentShipUnitShipUnitDimensions ShipUnitDimensions
        {
            get
            {
                return this.shipUnitDimensionsField;
            }
            set
            {
                this.shipUnitDimensionsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentShipUnitShipUnitContent
    {

        private string domainNameField;

        private byte sequenceNumberField;

        private byte releaseLineSequenceNumberField;

        private string orderNumberField;

        private string lineItemNumberField;

        private string itemNumberField;

        private string itemNameField;

        private string itemDescriptionField;

        private string itemCommodityGroupField;

        private byte quantityField;

        private string quantityUnitOfMeasureField;

        private byte weightField;

        private string weightUnitOfMeasureField;

        private byte volumeField;

        private string volumeUnitOfMeasureField;

        private byte weightGrossField;

        private string weightGrossUnitOfMeasureField;

        private byte volumeGrossField;

        private string volumeGrossUnitOfMeasureField;

        private string packagedItemField;

        private byte packagedItemCountField;

        /// <remarks/>
        public string DomainName
        {
            get
            {
                return this.domainNameField;
            }
            set
            {
                this.domainNameField = value;
            }
        }

        /// <remarks/>
        public byte SequenceNumber
        {
            get
            {
                return this.sequenceNumberField;
            }
            set
            {
                this.sequenceNumberField = value;
            }
        }

        /// <remarks/>
        public byte ReleaseLineSequenceNumber
        {
            get
            {
                return this.releaseLineSequenceNumberField;
            }
            set
            {
                this.releaseLineSequenceNumberField = value;
            }
        }

        /// <remarks/>
        public string OrderNumber
        {
            get
            {
                return this.orderNumberField;
            }
            set
            {
                this.orderNumberField = value;
            }
        }

        /// <remarks/>
        public string LineItemNumber
        {
            get
            {
                return this.lineItemNumberField;
            }
            set
            {
                this.lineItemNumberField = value;
            }
        }

        /// <remarks/>
        public string ItemNumber
        {
            get
            {
                return this.itemNumberField;
            }
            set
            {
                this.itemNumberField = value;
            }
        }

        /// <remarks/>
        public string ItemName
        {
            get
            {
                return this.itemNameField;
            }
            set
            {
                this.itemNameField = value;
            }
        }

        /// <remarks/>
        public string ItemDescription
        {
            get
            {
                return this.itemDescriptionField;
            }
            set
            {
                this.itemDescriptionField = value;
            }
        }

        /// <remarks/>
        public string ItemCommodityGroup
        {
            get
            {
                return this.itemCommodityGroupField;
            }
            set
            {
                this.itemCommodityGroupField = value;
            }
        }

        /// <remarks/>
        public byte Quantity
        {
            get
            {
                return this.quantityField;
            }
            set
            {
                this.quantityField = value;
            }
        }

        /// <remarks/>
        public string QuantityUnitOfMeasure
        {
            get
            {
                return this.quantityUnitOfMeasureField;
            }
            set
            {
                this.quantityUnitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public byte Weight
        {
            get
            {
                return this.weightField;
            }
            set
            {
                this.weightField = value;
            }
        }

        /// <remarks/>
        public string WeightUnitOfMeasure
        {
            get
            {
                return this.weightUnitOfMeasureField;
            }
            set
            {
                this.weightUnitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public byte Volume
        {
            get
            {
                return this.volumeField;
            }
            set
            {
                this.volumeField = value;
            }
        }

        /// <remarks/>
        public string VolumeUnitOfMeasure
        {
            get
            {
                return this.volumeUnitOfMeasureField;
            }
            set
            {
                this.volumeUnitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public byte WeightGross
        {
            get
            {
                return this.weightGrossField;
            }
            set
            {
                this.weightGrossField = value;
            }
        }

        /// <remarks/>
        public string WeightGrossUnitOfMeasure
        {
            get
            {
                return this.weightGrossUnitOfMeasureField;
            }
            set
            {
                this.weightGrossUnitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public byte VolumeGross
        {
            get
            {
                return this.volumeGrossField;
            }
            set
            {
                this.volumeGrossField = value;
            }
        }

        /// <remarks/>
        public string VolumeGrossUnitOfMeasure
        {
            get
            {
                return this.volumeGrossUnitOfMeasureField;
            }
            set
            {
                this.volumeGrossUnitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public string PackagedItem
        {
            get
            {
                return this.packagedItemField;
            }
            set
            {
                this.packagedItemField = value;
            }
        }

        /// <remarks/>
        public byte PackagedItemCount
        {
            get
            {
                return this.packagedItemCountField;
            }
            set
            {
                this.packagedItemCountField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentShipUnitReferenceNumber
    {

        private string domainNameField;

        private string referenceNumberTypeField;

        private string referenceNumberValueField;

        /// <remarks/>
        public string DomainName
        {
            get
            {
                return this.domainNameField;
            }
            set
            {
                this.domainNameField = value;
            }
        }

        /// <remarks/>
        public string ReferenceNumberType
        {
            get
            {
                return this.referenceNumberTypeField;
            }
            set
            {
                this.referenceNumberTypeField = value;
            }
        }

        /// <remarks/>
        public string ReferenceNumberValue
        {
            get
            {
                return this.referenceNumberValueField;
            }
            set
            {
                this.referenceNumberValueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentShipUnitShipUnitDimensions
    {

        private byte lengthField;

        private string lengthUnitOfMeasureField;

        private byte widthField;

        private string widthUnitOfMeasureField;

        private byte heightField;

        private string heightUnitOfMeasureField;

        /// <remarks/>
        public byte Length
        {
            get
            {
                return this.lengthField;
            }
            set
            {
                this.lengthField = value;
            }
        }

        /// <remarks/>
        public string LengthUnitOfMeasure
        {
            get
            {
                return this.lengthUnitOfMeasureField;
            }
            set
            {
                this.lengthUnitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public byte Width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }

        /// <remarks/>
        public string WidthUnitOfMeasure
        {
            get
            {
                return this.widthUnitOfMeasureField;
            }
            set
            {
                this.widthUnitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public byte Height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }

        /// <remarks/>
        public string HeightUnitOfMeasure
        {
            get
            {
                return this.heightUnitOfMeasureField;
            }
            set
            {
                this.heightUnitOfMeasureField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrder
    {

        private string messageIdField;

        private APIActualShipmentActualShipmentReleaseOrderOrderHeader orderHeaderField;

        private APIActualShipmentActualShipmentReleaseOrderShipFrom shipFromField;

        private APIActualShipmentActualShipmentReleaseOrderShipTo shipToField;

        private APIActualShipmentActualShipmentReleaseOrderShippingAndDeliveryDates shippingAndDeliveryDatesField;

        private APIActualShipmentActualShipmentReleaseOrderOrderRouting orderRoutingField;

        private APIActualShipmentActualShipmentReleaseOrderLineItem[] lineItemsField;

        private APIActualShipmentActualShipmentReleaseOrderLineItemGroup lineItemGroupField;

        private APIActualShipmentActualShipmentReleaseOrderShipUnit[] shipUnitsField;

        private APIActualShipmentActualShipmentReleaseOrderIntegrationError[] integrationErrorsField;

        /// <remarks/>
        public string MessageId
        {
            get
            {
                return this.messageIdField;
            }
            set
            {
                this.messageIdField = value;
            }
        }

        /// <remarks/>
        public APIActualShipmentActualShipmentReleaseOrderOrderHeader OrderHeader
        {
            get
            {
                return this.orderHeaderField;
            }
            set
            {
                this.orderHeaderField = value;
            }
        }

        /// <remarks/>
        public APIActualShipmentActualShipmentReleaseOrderShipFrom ShipFrom
        {
            get
            {
                return this.shipFromField;
            }
            set
            {
                this.shipFromField = value;
            }
        }

        /// <remarks/>
        public APIActualShipmentActualShipmentReleaseOrderShipTo ShipTo
        {
            get
            {
                return this.shipToField;
            }
            set
            {
                this.shipToField = value;
            }
        }

        /// <remarks/>
        public APIActualShipmentActualShipmentReleaseOrderShippingAndDeliveryDates ShippingAndDeliveryDates
        {
            get
            {
                return this.shippingAndDeliveryDatesField;
            }
            set
            {
                this.shippingAndDeliveryDatesField = value;
            }
        }

        /// <remarks/>
        public APIActualShipmentActualShipmentReleaseOrderOrderRouting OrderRouting
        {
            get
            {
                return this.orderRoutingField;
            }
            set
            {
                this.orderRoutingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("LineItem")]
        public APIActualShipmentActualShipmentReleaseOrderLineItem[] LineItems
        {
            get
            {
                return this.lineItemsField;
            }
            set
            {
                this.lineItemsField = value;
            }
        }

        /// <remarks/>
        public APIActualShipmentActualShipmentReleaseOrderLineItemGroup LineItemGroup
        {
            get
            {
                return this.lineItemGroupField;
            }
            set
            {
                this.lineItemGroupField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ShipUnit")]
        public APIActualShipmentActualShipmentReleaseOrderShipUnit[] ShipUnits
        {
            get
            {
                return this.shipUnitsField;
            }
            set
            {
                this.shipUnitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("IntegrationError")]
        public APIActualShipmentActualShipmentReleaseOrderIntegrationError[] IntegrationErrors
        {
            get
            {
                return this.integrationErrorsField;
            }
            set
            {
                this.integrationErrorsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderOrderHeader
    {

        private string domainNameField;

        private string rPClientIdField;

        private string orderNumberField;

        private string transactionCodeField;

        private string integrationCommandField;

        private string paymentMethodField;

        private string timeWindowEmphasisField;

        private string priorityField;

        private string orderReleaseNumberField;

        private string statusValueField;

        private string statusTypeField;

        private string orderShippingConfigurationField;

        private string orderTypeField;

        private string generalLedgerCodeField;

        private APIActualShipmentActualShipmentReleaseOrderOrderHeaderCustomerServiceRepInfo customerServiceRepInfoField;

        private APIActualShipmentActualShipmentReleaseOrderOrderHeaderReferenceNumber[] referenceNumbersField;

        private APIActualShipmentActualShipmentReleaseOrderOrderHeaderComment[] commentsField;

        private APIActualShipmentActualShipmentReleaseOrderOrderHeaderFlexFieldStrings flexFieldStringsField;

        private APIActualShipmentActualShipmentReleaseOrderOrderHeaderFlexFieldNumbers flexFieldNumbersField;

        private APIActualShipmentActualShipmentReleaseOrderOrderHeaderFlexFieldCurrencies flexFieldCurrenciesField;

        /// <remarks/>
        public string DomainName
        {
            get
            {
                return this.domainNameField;
            }
            set
            {
                this.domainNameField = value;
            }
        }

        /// <remarks/>
        public string RPClientId
        {
            get
            {
                return this.rPClientIdField;
            }
            set
            {
                this.rPClientIdField = value;
            }
        }

        /// <remarks/>
        public string OrderNumber
        {
            get
            {
                return this.orderNumberField;
            }
            set
            {
                this.orderNumberField = value;
            }
        }

        /// <remarks/>
        public string TransactionCode
        {
            get
            {
                return this.transactionCodeField;
            }
            set
            {
                this.transactionCodeField = value;
            }
        }

        /// <remarks/>
        public string IntegrationCommand
        {
            get
            {
                return this.integrationCommandField;
            }
            set
            {
                this.integrationCommandField = value;
            }
        }

        /// <remarks/>
        public string PaymentMethod
        {
            get
            {
                return this.paymentMethodField;
            }
            set
            {
                this.paymentMethodField = value;
            }
        }

        /// <remarks/>
        public string TimeWindowEmphasis
        {
            get
            {
                return this.timeWindowEmphasisField;
            }
            set
            {
                this.timeWindowEmphasisField = value;
            }
        }

        /// <remarks/>
        public string Priority
        {
            get
            {
                return this.priorityField;
            }
            set
            {
                this.priorityField = value;
            }
        }

        /// <remarks/>
        public string OrderReleaseNumber
        {
            get
            {
                return this.orderReleaseNumberField;
            }
            set
            {
                this.orderReleaseNumberField = value;
            }
        }

        /// <remarks/>
        public string StatusValue
        {
            get
            {
                return this.statusValueField;
            }
            set
            {
                this.statusValueField = value;
            }
        }

        /// <remarks/>
        public string StatusType
        {
            get
            {
                return this.statusTypeField;
            }
            set
            {
                this.statusTypeField = value;
            }
        }

        /// <remarks/>
        public string OrderShippingConfiguration
        {
            get
            {
                return this.orderShippingConfigurationField;
            }
            set
            {
                this.orderShippingConfigurationField = value;
            }
        }

        /// <remarks/>
        public string OrderType
        {
            get
            {
                return this.orderTypeField;
            }
            set
            {
                this.orderTypeField = value;
            }
        }

        /// <remarks/>
        public string GeneralLedgerCode
        {
            get
            {
                return this.generalLedgerCodeField;
            }
            set
            {
                this.generalLedgerCodeField = value;
            }
        }

        /// <remarks/>
        public APIActualShipmentActualShipmentReleaseOrderOrderHeaderCustomerServiceRepInfo CustomerServiceRepInfo
        {
            get
            {
                return this.customerServiceRepInfoField;
            }
            set
            {
                this.customerServiceRepInfoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ReferenceNumber")]
        public APIActualShipmentActualShipmentReleaseOrderOrderHeaderReferenceNumber[] ReferenceNumbers
        {
            get
            {
                return this.referenceNumbersField;
            }
            set
            {
                this.referenceNumbersField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Comment")]
        public APIActualShipmentActualShipmentReleaseOrderOrderHeaderComment[] Comments
        {
            get
            {
                return this.commentsField;
            }
            set
            {
                this.commentsField = value;
            }
        }

        /// <remarks/>
        public APIActualShipmentActualShipmentReleaseOrderOrderHeaderFlexFieldStrings FlexFieldStrings
        {
            get
            {
                return this.flexFieldStringsField;
            }
            set
            {
                this.flexFieldStringsField = value;
            }
        }

        /// <remarks/>
        public APIActualShipmentActualShipmentReleaseOrderOrderHeaderFlexFieldNumbers FlexFieldNumbers
        {
            get
            {
                return this.flexFieldNumbersField;
            }
            set
            {
                this.flexFieldNumbersField = value;
            }
        }

        /// <remarks/>
        public APIActualShipmentActualShipmentReleaseOrderOrderHeaderFlexFieldCurrencies FlexFieldCurrencies
        {
            get
            {
                return this.flexFieldCurrenciesField;
            }
            set
            {
                this.flexFieldCurrenciesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderOrderHeaderCustomerServiceRepInfo
    {

        private string customerServiceRepNameField;

        private string customerServiceRepPhoneField;

        private string customerServiceRepEmailField;

        /// <remarks/>
        public string CustomerServiceRepName
        {
            get
            {
                return this.customerServiceRepNameField;
            }
            set
            {
                this.customerServiceRepNameField = value;
            }
        }

        /// <remarks/>
        public string CustomerServiceRepPhone
        {
            get
            {
                return this.customerServiceRepPhoneField;
            }
            set
            {
                this.customerServiceRepPhoneField = value;
            }
        }

        /// <remarks/>
        public string CustomerServiceRepEmail
        {
            get
            {
                return this.customerServiceRepEmailField;
            }
            set
            {
                this.customerServiceRepEmailField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderOrderHeaderReferenceNumber
    {

        private string domainNameField;

        private string referenceNumberTypeField;

        private string referenceNumberValueField;

        /// <remarks/>
        public string DomainName
        {
            get
            {
                return this.domainNameField;
            }
            set
            {
                this.domainNameField = value;
            }
        }

        /// <remarks/>
        public string ReferenceNumberType
        {
            get
            {
                return this.referenceNumberTypeField;
            }
            set
            {
                this.referenceNumberTypeField = value;
            }
        }

        /// <remarks/>
        public string ReferenceNumberValue
        {
            get
            {
                return this.referenceNumberValueField;
            }
            set
            {
                this.referenceNumberValueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderOrderHeaderComment
    {

        private string commentTypeField;

        private string commentValueField;

        /// <remarks/>
        public string CommentType
        {
            get
            {
                return this.commentTypeField;
            }
            set
            {
                this.commentTypeField = value;
            }
        }

        /// <remarks/>
        public string CommentValue
        {
            get
            {
                return this.commentValueField;
            }
            set
            {
                this.commentValueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderOrderHeaderFlexFieldStrings
    {

        private string attribute1Field;

        private string attribute2Field;

        private string attribute3Field;

        private string attribute4Field;

        private string attribute5Field;

        private string attribute6Field;

        private string attribute7Field;

        private string attribute8Field;

        private string attribute9Field;

        private string attribute10Field;

        private string attribute11Field;

        private string attribute12Field;

        private string attribute13Field;

        private string attribute14Field;

        private string attribute15Field;

        private string attribute16Field;

        private string attribute17Field;

        private string attribute18Field;

        private string attribute19Field;

        private string attribute20Field;

        /// <remarks/>
        public string Attribute1
        {
            get
            {
                return this.attribute1Field;
            }
            set
            {
                this.attribute1Field = value;
            }
        }

        /// <remarks/>
        public string Attribute2
        {
            get
            {
                return this.attribute2Field;
            }
            set
            {
                this.attribute2Field = value;
            }
        }

        /// <remarks/>
        public string Attribute3
        {
            get
            {
                return this.attribute3Field;
            }
            set
            {
                this.attribute3Field = value;
            }
        }

        /// <remarks/>
        public string Attribute4
        {
            get
            {
                return this.attribute4Field;
            }
            set
            {
                this.attribute4Field = value;
            }
        }

        /// <remarks/>
        public string Attribute5
        {
            get
            {
                return this.attribute5Field;
            }
            set
            {
                this.attribute5Field = value;
            }
        }

        /// <remarks/>
        public string Attribute6
        {
            get
            {
                return this.attribute6Field;
            }
            set
            {
                this.attribute6Field = value;
            }
        }

        /// <remarks/>
        public string Attribute7
        {
            get
            {
                return this.attribute7Field;
            }
            set
            {
                this.attribute7Field = value;
            }
        }

        /// <remarks/>
        public string Attribute8
        {
            get
            {
                return this.attribute8Field;
            }
            set
            {
                this.attribute8Field = value;
            }
        }

        /// <remarks/>
        public string Attribute9
        {
            get
            {
                return this.attribute9Field;
            }
            set
            {
                this.attribute9Field = value;
            }
        }

        /// <remarks/>
        public string Attribute10
        {
            get
            {
                return this.attribute10Field;
            }
            set
            {
                this.attribute10Field = value;
            }
        }

        /// <remarks/>
        public string Attribute11
        {
            get
            {
                return this.attribute11Field;
            }
            set
            {
                this.attribute11Field = value;
            }
        }

        /// <remarks/>
        public string Attribute12
        {
            get
            {
                return this.attribute12Field;
            }
            set
            {
                this.attribute12Field = value;
            }
        }

        /// <remarks/>
        public string Attribute13
        {
            get
            {
                return this.attribute13Field;
            }
            set
            {
                this.attribute13Field = value;
            }
        }

        /// <remarks/>
        public string Attribute14
        {
            get
            {
                return this.attribute14Field;
            }
            set
            {
                this.attribute14Field = value;
            }
        }

        /// <remarks/>
        public string Attribute15
        {
            get
            {
                return this.attribute15Field;
            }
            set
            {
                this.attribute15Field = value;
            }
        }

        /// <remarks/>
        public string Attribute16
        {
            get
            {
                return this.attribute16Field;
            }
            set
            {
                this.attribute16Field = value;
            }
        }

        /// <remarks/>
        public string Attribute17
        {
            get
            {
                return this.attribute17Field;
            }
            set
            {
                this.attribute17Field = value;
            }
        }

        /// <remarks/>
        public string Attribute18
        {
            get
            {
                return this.attribute18Field;
            }
            set
            {
                this.attribute18Field = value;
            }
        }

        /// <remarks/>
        public string Attribute19
        {
            get
            {
                return this.attribute19Field;
            }
            set
            {
                this.attribute19Field = value;
            }
        }

        /// <remarks/>
        public string Attribute20
        {
            get
            {
                return this.attribute20Field;
            }
            set
            {
                this.attribute20Field = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderOrderHeaderFlexFieldNumbers
    {

        private object attributeNumber1Field;

        private object attributeNumber2Field;

        private object attributeNumber3Field;

        private object attributeNumber4Field;

        private object attributeNumber5Field;

        private object attributeNumber6Field;

        private object attributeNumber7Field;

        private object attributeNumber8Field;

        private object attributeNumber9Field;

        private object attributeNumber10Field;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object AttributeNumber1
        {
            get
            {
                return this.attributeNumber1Field;
            }
            set
            {
                this.attributeNumber1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object AttributeNumber2
        {
            get
            {
                return this.attributeNumber2Field;
            }
            set
            {
                this.attributeNumber2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object AttributeNumber3
        {
            get
            {
                return this.attributeNumber3Field;
            }
            set
            {
                this.attributeNumber3Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object AttributeNumber4
        {
            get
            {
                return this.attributeNumber4Field;
            }
            set
            {
                this.attributeNumber4Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object AttributeNumber5
        {
            get
            {
                return this.attributeNumber5Field;
            }
            set
            {
                this.attributeNumber5Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object AttributeNumber6
        {
            get
            {
                return this.attributeNumber6Field;
            }
            set
            {
                this.attributeNumber6Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object AttributeNumber7
        {
            get
            {
                return this.attributeNumber7Field;
            }
            set
            {
                this.attributeNumber7Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object AttributeNumber8
        {
            get
            {
                return this.attributeNumber8Field;
            }
            set
            {
                this.attributeNumber8Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object AttributeNumber9
        {
            get
            {
                return this.attributeNumber9Field;
            }
            set
            {
                this.attributeNumber9Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object AttributeNumber10
        {
            get
            {
                return this.attributeNumber10Field;
            }
            set
            {
                this.attributeNumber10Field = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderOrderHeaderFlexFieldCurrencies
    {

        private APIActualShipmentActualShipmentReleaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency1 attributeCurrency1Field;

        private APIActualShipmentActualShipmentReleaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency2 attributeCurrency2Field;

        private APIActualShipmentActualShipmentReleaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency3 attributeCurrency3Field;

        /// <remarks/>
        public APIActualShipmentActualShipmentReleaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency1 AttributeCurrency1
        {
            get
            {
                return this.attributeCurrency1Field;
            }
            set
            {
                this.attributeCurrency1Field = value;
            }
        }

        /// <remarks/>
        public APIActualShipmentActualShipmentReleaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency2 AttributeCurrency2
        {
            get
            {
                return this.attributeCurrency2Field;
            }
            set
            {
                this.attributeCurrency2Field = value;
            }
        }

        /// <remarks/>
        public APIActualShipmentActualShipmentReleaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency3 AttributeCurrency3
        {
            get
            {
                return this.attributeCurrency3Field;
            }
            set
            {
                this.attributeCurrency3Field = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency1
    {

        private APIActualShipmentActualShipmentReleaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency1FinancialAmount financialAmountField;

        /// <remarks/>
        public APIActualShipmentActualShipmentReleaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency1FinancialAmount FinancialAmount
        {
            get
            {
                return this.financialAmountField;
            }
            set
            {
                this.financialAmountField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency1FinancialAmount
    {

        private string globalCurrencyCodeField;

        private object monetaryAmountField;

        private object rateToBaseField;

        private object funcCurrencyAmountField;

        /// <remarks/>
        public string GlobalCurrencyCode
        {
            get
            {
                return this.globalCurrencyCodeField;
            }
            set
            {
                this.globalCurrencyCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object MonetaryAmount
        {
            get
            {
                return this.monetaryAmountField;
            }
            set
            {
                this.monetaryAmountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object RateToBase
        {
            get
            {
                return this.rateToBaseField;
            }
            set
            {
                this.rateToBaseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object FuncCurrencyAmount
        {
            get
            {
                return this.funcCurrencyAmountField;
            }
            set
            {
                this.funcCurrencyAmountField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency2
    {

        private APIActualShipmentActualShipmentReleaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency2FinancialAmount financialAmountField;

        /// <remarks/>
        public APIActualShipmentActualShipmentReleaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency2FinancialAmount FinancialAmount
        {
            get
            {
                return this.financialAmountField;
            }
            set
            {
                this.financialAmountField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency2FinancialAmount
    {

        private string globalCurrencyCodeField;

        private decimal monetaryAmountField;

        private decimal rateToBaseField;

        private decimal funcCurrencyAmountField;

        /// <remarks/>
        public string GlobalCurrencyCode
        {
            get
            {
                return this.globalCurrencyCodeField;
            }
            set
            {
                this.globalCurrencyCodeField = value;
            }
        }

        /// <remarks/>
        public decimal MonetaryAmount
        {
            get
            {
                return this.monetaryAmountField;
            }
            set
            {
                this.monetaryAmountField = value;
            }
        }

        /// <remarks/>
        public decimal RateToBase
        {
            get
            {
                return this.rateToBaseField;
            }
            set
            {
                this.rateToBaseField = value;
            }
        }

        /// <remarks/>
        public decimal FuncCurrencyAmount
        {
            get
            {
                return this.funcCurrencyAmountField;
            }
            set
            {
                this.funcCurrencyAmountField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency3
    {

        private APIActualShipmentActualShipmentReleaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency3FinancialAmount financialAmountField;

        /// <remarks/>
        public APIActualShipmentActualShipmentReleaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency3FinancialAmount FinancialAmount
        {
            get
            {
                return this.financialAmountField;
            }
            set
            {
                this.financialAmountField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency3FinancialAmount
    {

        private string globalCurrencyCodeField;

        private object monetaryAmountField;

        private object rateToBaseField;

        private object funcCurrencyAmountField;

        /// <remarks/>
        public string GlobalCurrencyCode
        {
            get
            {
                return this.globalCurrencyCodeField;
            }
            set
            {
                this.globalCurrencyCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object MonetaryAmount
        {
            get
            {
                return this.monetaryAmountField;
            }
            set
            {
                this.monetaryAmountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object RateToBase
        {
            get
            {
                return this.rateToBaseField;
            }
            set
            {
                this.rateToBaseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object FuncCurrencyAmount
        {
            get
            {
                return this.funcCurrencyAmountField;
            }
            set
            {
                this.funcCurrencyAmountField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderShipFrom
    {

        private string domainNameField;

        private string idField;

        private string nameField;

        private string addressLine1Field;

        private string addressLine2Field;

        private string addressLine3Field;

        private string cityField;

        private string stateField;

        private string zipField;

        private string countryField;

        private byte latitudeField;

        private byte longitudeField;

        private string customerLocationCodeField;

        private string contactNumberField;

        private string locationTypeField;

        private string roleField;

        private APIActualShipmentActualShipmentReleaseOrderShipFromContact contactField;

        private object postLocationToOTMField;

        private APIActualShipmentActualShipmentReleaseOrderShipFromReferenceNumber[] referenceNumbersField;

        /// <remarks/>
        public string DomainName
        {
            get
            {
                return this.domainNameField;
            }
            set
            {
                this.domainNameField = value;
            }
        }

        /// <remarks/>
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string AddressLine1
        {
            get
            {
                return this.addressLine1Field;
            }
            set
            {
                this.addressLine1Field = value;
            }
        }

        /// <remarks/>
        public string AddressLine2
        {
            get
            {
                return this.addressLine2Field;
            }
            set
            {
                this.addressLine2Field = value;
            }
        }

        /// <remarks/>
        public string AddressLine3
        {
            get
            {
                return this.addressLine3Field;
            }
            set
            {
                this.addressLine3Field = value;
            }
        }

        /// <remarks/>
        public string City
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        public string State
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }

        /// <remarks/>
        public string Zip
        {
            get
            {
                return this.zipField;
            }
            set
            {
                this.zipField = value;
            }
        }

        /// <remarks/>
        public string Country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }

        /// <remarks/>
        public byte Latitude
        {
            get
            {
                return this.latitudeField;
            }
            set
            {
                this.latitudeField = value;
            }
        }

        /// <remarks/>
        public byte Longitude
        {
            get
            {
                return this.longitudeField;
            }
            set
            {
                this.longitudeField = value;
            }
        }

        /// <remarks/>
        public string CustomerLocationCode
        {
            get
            {
                return this.customerLocationCodeField;
            }
            set
            {
                this.customerLocationCodeField = value;
            }
        }

        /// <remarks/>
        public string ContactNumber
        {
            get
            {
                return this.contactNumberField;
            }
            set
            {
                this.contactNumberField = value;
            }
        }

        /// <remarks/>
        public string LocationType
        {
            get
            {
                return this.locationTypeField;
            }
            set
            {
                this.locationTypeField = value;
            }
        }

        /// <remarks/>
        public string Role
        {
            get
            {
                return this.roleField;
            }
            set
            {
                this.roleField = value;
            }
        }

        /// <remarks/>
        public APIActualShipmentActualShipmentReleaseOrderShipFromContact Contact
        {
            get
            {
                return this.contactField;
            }
            set
            {
                this.contactField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object PostLocationToOTM
        {
            get
            {
                return this.postLocationToOTMField;
            }
            set
            {
                this.postLocationToOTMField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ReferenceNumber")]
        public APIActualShipmentActualShipmentReleaseOrderShipFromReferenceNumber[] ReferenceNumbers
        {
            get
            {
                return this.referenceNumbersField;
            }
            set
            {
                this.referenceNumbersField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderShipFromContact
    {

        private string domainNameField;

        private string nameField;

        private string phoneField;

        private string emailField;

        /// <remarks/>
        public string DomainName
        {
            get
            {
                return this.domainNameField;
            }
            set
            {
                this.domainNameField = value;
            }
        }

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string Phone
        {
            get
            {
                return this.phoneField;
            }
            set
            {
                this.phoneField = value;
            }
        }

        /// <remarks/>
        public string Email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderShipFromReferenceNumber
    {

        private string domainNameField;

        private string referenceNumberTypeField;

        private string referenceNumberValueField;

        /// <remarks/>
        public string DomainName
        {
            get
            {
                return this.domainNameField;
            }
            set
            {
                this.domainNameField = value;
            }
        }

        /// <remarks/>
        public string ReferenceNumberType
        {
            get
            {
                return this.referenceNumberTypeField;
            }
            set
            {
                this.referenceNumberTypeField = value;
            }
        }

        /// <remarks/>
        public string ReferenceNumberValue
        {
            get
            {
                return this.referenceNumberValueField;
            }
            set
            {
                this.referenceNumberValueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderShipTo
    {

        private string domainNameField;

        private string idField;

        private string nameField;

        private string addressLine1Field;

        private string addressLine2Field;

        private string addressLine3Field;

        private string cityField;

        private string stateField;

        private string zipField;

        private string countryField;

        private byte latitudeField;

        private byte longitudeField;

        private string customerLocationCodeField;

        private string contactNumberField;

        private string locationTypeField;

        private string roleField;

        private APIActualShipmentActualShipmentReleaseOrderShipToContact contactField;

        private object postLocationToOTMField;

        private APIActualShipmentActualShipmentReleaseOrderShipToReferenceNumber[] referenceNumbersField;

        /// <remarks/>
        public string DomainName
        {
            get
            {
                return this.domainNameField;
            }
            set
            {
                this.domainNameField = value;
            }
        }

        /// <remarks/>
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string AddressLine1
        {
            get
            {
                return this.addressLine1Field;
            }
            set
            {
                this.addressLine1Field = value;
            }
        }

        /// <remarks/>
        public string AddressLine2
        {
            get
            {
                return this.addressLine2Field;
            }
            set
            {
                this.addressLine2Field = value;
            }
        }

        /// <remarks/>
        public string AddressLine3
        {
            get
            {
                return this.addressLine3Field;
            }
            set
            {
                this.addressLine3Field = value;
            }
        }

        /// <remarks/>
        public string City
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        public string State
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }

        /// <remarks/>
        public string Zip
        {
            get
            {
                return this.zipField;
            }
            set
            {
                this.zipField = value;
            }
        }

        /// <remarks/>
        public string Country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }

        /// <remarks/>
        public byte Latitude
        {
            get
            {
                return this.latitudeField;
            }
            set
            {
                this.latitudeField = value;
            }
        }

        /// <remarks/>
        public byte Longitude
        {
            get
            {
                return this.longitudeField;
            }
            set
            {
                this.longitudeField = value;
            }
        }

        /// <remarks/>
        public string CustomerLocationCode
        {
            get
            {
                return this.customerLocationCodeField;
            }
            set
            {
                this.customerLocationCodeField = value;
            }
        }

        /// <remarks/>
        public string ContactNumber
        {
            get
            {
                return this.contactNumberField;
            }
            set
            {
                this.contactNumberField = value;
            }
        }

        /// <remarks/>
        public string LocationType
        {
            get
            {
                return this.locationTypeField;
            }
            set
            {
                this.locationTypeField = value;
            }
        }

        /// <remarks/>
        public string Role
        {
            get
            {
                return this.roleField;
            }
            set
            {
                this.roleField = value;
            }
        }

        /// <remarks/>
        public APIActualShipmentActualShipmentReleaseOrderShipToContact Contact
        {
            get
            {
                return this.contactField;
            }
            set
            {
                this.contactField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object PostLocationToOTM
        {
            get
            {
                return this.postLocationToOTMField;
            }
            set
            {
                this.postLocationToOTMField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ReferenceNumber")]
        public APIActualShipmentActualShipmentReleaseOrderShipToReferenceNumber[] ReferenceNumbers
        {
            get
            {
                return this.referenceNumbersField;
            }
            set
            {
                this.referenceNumbersField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderShipToContact
    {

        private string domainNameField;

        private string nameField;

        private string phoneField;

        private string emailField;

        /// <remarks/>
        public string DomainName
        {
            get
            {
                return this.domainNameField;
            }
            set
            {
                this.domainNameField = value;
            }
        }

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string Phone
        {
            get
            {
                return this.phoneField;
            }
            set
            {
                this.phoneField = value;
            }
        }

        /// <remarks/>
        public string Email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderShipToReferenceNumber
    {

        private string domainNameField;

        private string referenceNumberTypeField;

        private string referenceNumberValueField;

        /// <remarks/>
        public string DomainName
        {
            get
            {
                return this.domainNameField;
            }
            set
            {
                this.domainNameField = value;
            }
        }

        /// <remarks/>
        public string ReferenceNumberType
        {
            get
            {
                return this.referenceNumberTypeField;
            }
            set
            {
                this.referenceNumberTypeField = value;
            }
        }

        /// <remarks/>
        public string ReferenceNumberValue
        {
            get
            {
                return this.referenceNumberValueField;
            }
            set
            {
                this.referenceNumberValueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderShippingAndDeliveryDates
    {

        private object shipDateTimeEarlyField;

        private string shipDateTimeEarlyToStringField;

        private object shipDateTimeLateField;

        private string shipDateTimeLateToStringField;

        private object deliveryDateTimeEarlyField;

        private string deliveryDateTimeEarlyToStringField;

        private object deliveryDateTimeLateField;

        private string deliveryDateTimeLateToStringField;

        private string shipAppointmentFlagField;

        private string deliveryAppointmentFlagField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object ShipDateTimeEarly
        {
            get
            {
                return this.shipDateTimeEarlyField;
            }
            set
            {
                this.shipDateTimeEarlyField = value;
            }
        }

        /// <remarks/>
        public string ShipDateTimeEarlyToString
        {
            get
            {
                return this.shipDateTimeEarlyToStringField;
            }
            set
            {
                this.shipDateTimeEarlyToStringField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object ShipDateTimeLate
        {
            get
            {
                return this.shipDateTimeLateField;
            }
            set
            {
                this.shipDateTimeLateField = value;
            }
        }

        /// <remarks/>
        public string ShipDateTimeLateToString
        {
            get
            {
                return this.shipDateTimeLateToStringField;
            }
            set
            {
                this.shipDateTimeLateToStringField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object DeliveryDateTimeEarly
        {
            get
            {
                return this.deliveryDateTimeEarlyField;
            }
            set
            {
                this.deliveryDateTimeEarlyField = value;
            }
        }

        /// <remarks/>
        public string DeliveryDateTimeEarlyToString
        {
            get
            {
                return this.deliveryDateTimeEarlyToStringField;
            }
            set
            {
                this.deliveryDateTimeEarlyToStringField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object DeliveryDateTimeLate
        {
            get
            {
                return this.deliveryDateTimeLateField;
            }
            set
            {
                this.deliveryDateTimeLateField = value;
            }
        }

        /// <remarks/>
        public string DeliveryDateTimeLateToString
        {
            get
            {
                return this.deliveryDateTimeLateToStringField;
            }
            set
            {
                this.deliveryDateTimeLateToStringField = value;
            }
        }

        /// <remarks/>
        public string ShipAppointmentFlag
        {
            get
            {
                return this.shipAppointmentFlagField;
            }
            set
            {
                this.shipAppointmentFlagField = value;
            }
        }

        /// <remarks/>
        public string DeliveryAppointmentFlag
        {
            get
            {
                return this.deliveryAppointmentFlagField;
            }
            set
            {
                this.deliveryAppointmentFlagField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderOrderRouting
    {

        private string isExpeditedField;

        private string isPriorityField;

        private string hazardousClassificationField;

        private string unitiedNationsHazardousNumberField;

        private string hazardousPackagingGroupField;

        private string shipWithGroupIdField;

        private string preferredTransportationModeField;

        private string equipmentGroupField;

        private APIActualShipmentActualShipmentReleaseOrderOrderRoutingTemperatureRestriction temperatureRestrictionField;

        private string preferredCarrierScacField;

        private string specialRoutingInstructionsField;

        /// <remarks/>
        public string IsExpedited
        {
            get
            {
                return this.isExpeditedField;
            }
            set
            {
                this.isExpeditedField = value;
            }
        }

        /// <remarks/>
        public string IsPriority
        {
            get
            {
                return this.isPriorityField;
            }
            set
            {
                this.isPriorityField = value;
            }
        }

        /// <remarks/>
        public string HazardousClassification
        {
            get
            {
                return this.hazardousClassificationField;
            }
            set
            {
                this.hazardousClassificationField = value;
            }
        }

        /// <remarks/>
        public string UnitiedNationsHazardousNumber
        {
            get
            {
                return this.unitiedNationsHazardousNumberField;
            }
            set
            {
                this.unitiedNationsHazardousNumberField = value;
            }
        }

        /// <remarks/>
        public string HazardousPackagingGroup
        {
            get
            {
                return this.hazardousPackagingGroupField;
            }
            set
            {
                this.hazardousPackagingGroupField = value;
            }
        }

        /// <remarks/>
        public string ShipWithGroupId
        {
            get
            {
                return this.shipWithGroupIdField;
            }
            set
            {
                this.shipWithGroupIdField = value;
            }
        }

        /// <remarks/>
        public string PreferredTransportationMode
        {
            get
            {
                return this.preferredTransportationModeField;
            }
            set
            {
                this.preferredTransportationModeField = value;
            }
        }

        /// <remarks/>
        public string EquipmentGroup
        {
            get
            {
                return this.equipmentGroupField;
            }
            set
            {
                this.equipmentGroupField = value;
            }
        }

        /// <remarks/>
        public APIActualShipmentActualShipmentReleaseOrderOrderRoutingTemperatureRestriction TemperatureRestriction
        {
            get
            {
                return this.temperatureRestrictionField;
            }
            set
            {
                this.temperatureRestrictionField = value;
            }
        }

        /// <remarks/>
        public string PreferredCarrierScac
        {
            get
            {
                return this.preferredCarrierScacField;
            }
            set
            {
                this.preferredCarrierScacField = value;
            }
        }

        /// <remarks/>
        public string SpecialRoutingInstructions
        {
            get
            {
                return this.specialRoutingInstructionsField;
            }
            set
            {
                this.specialRoutingInstructionsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderOrderRoutingTemperatureRestriction
    {

        private string isTemperatureControlledField;

        private string temperatureMinimumField;

        private string temperatureMaximumField;

        private string temperatureUnitOfMeasureField;

        /// <remarks/>
        public string IsTemperatureControlled
        {
            get
            {
                return this.isTemperatureControlledField;
            }
            set
            {
                this.isTemperatureControlledField = value;
            }
        }

        /// <remarks/>
        public string TemperatureMinimum
        {
            get
            {
                return this.temperatureMinimumField;
            }
            set
            {
                this.temperatureMinimumField = value;
            }
        }

        /// <remarks/>
        public string TemperatureMaximum
        {
            get
            {
                return this.temperatureMaximumField;
            }
            set
            {
                this.temperatureMaximumField = value;
            }
        }

        /// <remarks/>
        public string TemperatureUnitOfMeasure
        {
            get
            {
                return this.temperatureUnitOfMeasureField;
            }
            set
            {
                this.temperatureUnitOfMeasureField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderLineItem
    {

        private string autoCreateItemField;

        private string autoCreateItemMasterField;

        private string isStackableField;

        private string lineItemNumberField;

        private string transportUnitKeyField;

        private string itemNumberField;

        private string itemNameField;

        private string itemDescriptionField;

        private string itemCommodityGroupField;

        private byte quantityField;

        private string quantityUnitOfMeasureField;

        private byte weightField;

        private string weightUnitOfMeasureField;

        private byte volumeField;

        private string volumeUnitOfMeasureField;

        private byte weightGrossField;

        private string weightGrossUnitOfMeasureField;

        private byte volumeGrossField;

        private string volumeGrossUnitOfMeasureField;

        private string hazardousClassficationField;

        private string unitedNationsHazardNumberField;

        private string hazardousPackagingGroupField;

        private APIActualShipmentActualShipmentReleaseOrderLineItemLineItemDimensions lineItemDimensionsField;

        private APIActualShipmentActualShipmentReleaseOrderLineItemReferenceNumber[] referenceNumbersField;

        private APIActualShipmentActualShipmentReleaseOrderLineItemItemMaster itemMasterField;

        private APIActualShipmentActualShipmentReleaseOrderLineItemPackagingShipUnit packagingShipUnitField;

        /// <remarks/>
        public string AutoCreateItem
        {
            get
            {
                return this.autoCreateItemField;
            }
            set
            {
                this.autoCreateItemField = value;
            }
        }

        /// <remarks/>
        public string AutoCreateItemMaster
        {
            get
            {
                return this.autoCreateItemMasterField;
            }
            set
            {
                this.autoCreateItemMasterField = value;
            }
        }

        /// <remarks/>
        public string IsStackable
        {
            get
            {
                return this.isStackableField;
            }
            set
            {
                this.isStackableField = value;
            }
        }

        /// <remarks/>
        public string LineItemNumber
        {
            get
            {
                return this.lineItemNumberField;
            }
            set
            {
                this.lineItemNumberField = value;
            }
        }

        /// <remarks/>
        public string TransportUnitKey
        {
            get
            {
                return this.transportUnitKeyField;
            }
            set
            {
                this.transportUnitKeyField = value;
            }
        }

        /// <remarks/>
        public string ItemNumber
        {
            get
            {
                return this.itemNumberField;
            }
            set
            {
                this.itemNumberField = value;
            }
        }

        /// <remarks/>
        public string ItemName
        {
            get
            {
                return this.itemNameField;
            }
            set
            {
                this.itemNameField = value;
            }
        }

        /// <remarks/>
        public string ItemDescription
        {
            get
            {
                return this.itemDescriptionField;
            }
            set
            {
                this.itemDescriptionField = value;
            }
        }

        /// <remarks/>
        public string ItemCommodityGroup
        {
            get
            {
                return this.itemCommodityGroupField;
            }
            set
            {
                this.itemCommodityGroupField = value;
            }
        }

        /// <remarks/>
        public byte Quantity
        {
            get
            {
                return this.quantityField;
            }
            set
            {
                this.quantityField = value;
            }
        }

        /// <remarks/>
        public string QuantityUnitOfMeasure
        {
            get
            {
                return this.quantityUnitOfMeasureField;
            }
            set
            {
                this.quantityUnitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public byte Weight
        {
            get
            {
                return this.weightField;
            }
            set
            {
                this.weightField = value;
            }
        }

        /// <remarks/>
        public string WeightUnitOfMeasure
        {
            get
            {
                return this.weightUnitOfMeasureField;
            }
            set
            {
                this.weightUnitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public byte Volume
        {
            get
            {
                return this.volumeField;
            }
            set
            {
                this.volumeField = value;
            }
        }

        /// <remarks/>
        public string VolumeUnitOfMeasure
        {
            get
            {
                return this.volumeUnitOfMeasureField;
            }
            set
            {
                this.volumeUnitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public byte WeightGross
        {
            get
            {
                return this.weightGrossField;
            }
            set
            {
                this.weightGrossField = value;
            }
        }

        /// <remarks/>
        public string WeightGrossUnitOfMeasure
        {
            get
            {
                return this.weightGrossUnitOfMeasureField;
            }
            set
            {
                this.weightGrossUnitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public byte VolumeGross
        {
            get
            {
                return this.volumeGrossField;
            }
            set
            {
                this.volumeGrossField = value;
            }
        }

        /// <remarks/>
        public string VolumeGrossUnitOfMeasure
        {
            get
            {
                return this.volumeGrossUnitOfMeasureField;
            }
            set
            {
                this.volumeGrossUnitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public string HazardousClassfication
        {
            get
            {
                return this.hazardousClassficationField;
            }
            set
            {
                this.hazardousClassficationField = value;
            }
        }

        /// <remarks/>
        public string UnitedNationsHazardNumber
        {
            get
            {
                return this.unitedNationsHazardNumberField;
            }
            set
            {
                this.unitedNationsHazardNumberField = value;
            }
        }

        /// <remarks/>
        public string HazardousPackagingGroup
        {
            get
            {
                return this.hazardousPackagingGroupField;
            }
            set
            {
                this.hazardousPackagingGroupField = value;
            }
        }

        /// <remarks/>
        public APIActualShipmentActualShipmentReleaseOrderLineItemLineItemDimensions LineItemDimensions
        {
            get
            {
                return this.lineItemDimensionsField;
            }
            set
            {
                this.lineItemDimensionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ReferenceNumber")]
        public APIActualShipmentActualShipmentReleaseOrderLineItemReferenceNumber[] ReferenceNumbers
        {
            get
            {
                return this.referenceNumbersField;
            }
            set
            {
                this.referenceNumbersField = value;
            }
        }

        /// <remarks/>
        public APIActualShipmentActualShipmentReleaseOrderLineItemItemMaster ItemMaster
        {
            get
            {
                return this.itemMasterField;
            }
            set
            {
                this.itemMasterField = value;
            }
        }

        /// <remarks/>
        public APIActualShipmentActualShipmentReleaseOrderLineItemPackagingShipUnit PackagingShipUnit
        {
            get
            {
                return this.packagingShipUnitField;
            }
            set
            {
                this.packagingShipUnitField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderLineItemLineItemDimensions
    {

        private byte length1Field;

        private byte length2Field;

        private byte width1Field;

        private byte width2Field;

        private byte height1Field;

        private byte height2Field;

        private string unitOfMeasureField;

        private byte weightField;

        private string weightUnitOfMeasureField;

        private byte volumeField;

        private string volumeUnitOfMeasureField;

        private string nMFCField;

        private string nMFCCodeField;

        private string userDefinedCommodityField;

        /// <remarks/>
        public byte Length1
        {
            get
            {
                return this.length1Field;
            }
            set
            {
                this.length1Field = value;
            }
        }

        /// <remarks/>
        public byte Length2
        {
            get
            {
                return this.length2Field;
            }
            set
            {
                this.length2Field = value;
            }
        }

        /// <remarks/>
        public byte Width1
        {
            get
            {
                return this.width1Field;
            }
            set
            {
                this.width1Field = value;
            }
        }

        /// <remarks/>
        public byte Width2
        {
            get
            {
                return this.width2Field;
            }
            set
            {
                this.width2Field = value;
            }
        }

        /// <remarks/>
        public byte Height1
        {
            get
            {
                return this.height1Field;
            }
            set
            {
                this.height1Field = value;
            }
        }

        /// <remarks/>
        public byte Height2
        {
            get
            {
                return this.height2Field;
            }
            set
            {
                this.height2Field = value;
            }
        }

        /// <remarks/>
        public string UnitOfMeasure
        {
            get
            {
                return this.unitOfMeasureField;
            }
            set
            {
                this.unitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public byte Weight
        {
            get
            {
                return this.weightField;
            }
            set
            {
                this.weightField = value;
            }
        }

        /// <remarks/>
        public string WeightUnitOfMeasure
        {
            get
            {
                return this.weightUnitOfMeasureField;
            }
            set
            {
                this.weightUnitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public byte Volume
        {
            get
            {
                return this.volumeField;
            }
            set
            {
                this.volumeField = value;
            }
        }

        /// <remarks/>
        public string VolumeUnitOfMeasure
        {
            get
            {
                return this.volumeUnitOfMeasureField;
            }
            set
            {
                this.volumeUnitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public string NMFC
        {
            get
            {
                return this.nMFCField;
            }
            set
            {
                this.nMFCField = value;
            }
        }

        /// <remarks/>
        public string NMFCCode
        {
            get
            {
                return this.nMFCCodeField;
            }
            set
            {
                this.nMFCCodeField = value;
            }
        }

        /// <remarks/>
        public string UserDefinedCommodity
        {
            get
            {
                return this.userDefinedCommodityField;
            }
            set
            {
                this.userDefinedCommodityField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderLineItemReferenceNumber
    {

        private string domainNameField;

        private string referenceNumberTypeField;

        private string referenceNumberValueField;

        /// <remarks/>
        public string DomainName
        {
            get
            {
                return this.domainNameField;
            }
            set
            {
                this.domainNameField = value;
            }
        }

        /// <remarks/>
        public string ReferenceNumberType
        {
            get
            {
                return this.referenceNumberTypeField;
            }
            set
            {
                this.referenceNumberTypeField = value;
            }
        }

        /// <remarks/>
        public string ReferenceNumberValue
        {
            get
            {
                return this.referenceNumberValueField;
            }
            set
            {
                this.referenceNumberValueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderLineItemItemMaster
    {

        private APIActualShipmentActualShipmentReleaseOrderLineItemItemMasterReferenceNumber[] referenceNumbersField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ReferenceNumber")]
        public APIActualShipmentActualShipmentReleaseOrderLineItemItemMasterReferenceNumber[] ReferenceNumbers
        {
            get
            {
                return this.referenceNumbersField;
            }
            set
            {
                this.referenceNumbersField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderLineItemItemMasterReferenceNumber
    {

        private string domainNameField;

        private string referenceNumberTypeField;

        private string referenceNumberValueField;

        /// <remarks/>
        public string DomainName
        {
            get
            {
                return this.domainNameField;
            }
            set
            {
                this.domainNameField = value;
            }
        }

        /// <remarks/>
        public string ReferenceNumberType
        {
            get
            {
                return this.referenceNumberTypeField;
            }
            set
            {
                this.referenceNumberTypeField = value;
            }
        }

        /// <remarks/>
        public string ReferenceNumberValue
        {
            get
            {
                return this.referenceNumberValueField;
            }
            set
            {
                this.referenceNumberValueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderLineItemPackagingShipUnit
    {

        private string domainNameField;

        private string shipUnitSpecGidField;

        private byte numLayersPerShipUnitField;

        private byte quantityPerLayerField;

        /// <remarks/>
        public string DomainName
        {
            get
            {
                return this.domainNameField;
            }
            set
            {
                this.domainNameField = value;
            }
        }

        /// <remarks/>
        public string ShipUnitSpecGid
        {
            get
            {
                return this.shipUnitSpecGidField;
            }
            set
            {
                this.shipUnitSpecGidField = value;
            }
        }

        /// <remarks/>
        public byte NumLayersPerShipUnit
        {
            get
            {
                return this.numLayersPerShipUnitField;
            }
            set
            {
                this.numLayersPerShipUnitField = value;
            }
        }

        /// <remarks/>
        public byte QuantityPerLayer
        {
            get
            {
                return this.quantityPerLayerField;
            }
            set
            {
                this.quantityPerLayerField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderLineItemGroup
    {

        private byte totalQuantityField;

        private byte totalWeightField;

        private byte totalVolumeField;

        private byte totalGrossWeightField;

        private byte totalGrossVolumeField;

        /// <remarks/>
        public byte TotalQuantity
        {
            get
            {
                return this.totalQuantityField;
            }
            set
            {
                this.totalQuantityField = value;
            }
        }

        /// <remarks/>
        public byte TotalWeight
        {
            get
            {
                return this.totalWeightField;
            }
            set
            {
                this.totalWeightField = value;
            }
        }

        /// <remarks/>
        public byte TotalVolume
        {
            get
            {
                return this.totalVolumeField;
            }
            set
            {
                this.totalVolumeField = value;
            }
        }

        /// <remarks/>
        public byte TotalGrossWeight
        {
            get
            {
                return this.totalGrossWeightField;
            }
            set
            {
                this.totalGrossWeightField = value;
            }
        }

        /// <remarks/>
        public byte TotalGrossVolume
        {
            get
            {
                return this.totalGrossVolumeField;
            }
            set
            {
                this.totalGrossVolumeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderShipUnit
    {

        private string shipFromLocationDomainNameField;

        private string shipFromLocationField;

        private string shipToLocationDomainNameField;

        private string shipToLocationField;

        private byte stopSequenceField;

        private string domainNameField;

        private string transactionCodeField;

        private string shipUnitKeyField;

        private string shipUnitTypeField;

        private double shipUnitCountField;

        private double weightField;

        private string weightUnitOfMeasureField;

        private double volumeField;

        private string volumeUnitOfMeasureField;

        private double weightGrossField;

        private string weightGrossUnitOfMeasureField;

        private double volumeGrossField;

        private string volumeGrossUnitOfMeasureField;

        private double totalWeightField;

        private double totalVolumeField;

        private string isSplitAllowedField;

        private string isCountSplittableField;

        private string isRepackAllowedField;

        private string netWeightUOMField;

        private string netVolumeUOMField;

        private APIActualShipmentActualShipmentReleaseOrderShipUnitShipUnitContent[] shipUnitContentsField;

        private APIActualShipmentActualShipmentReleaseOrderShipUnitReferenceNumber[] referenceNumbersField;

        private APIActualShipmentActualShipmentReleaseOrderShipUnitShipUnitDimensions shipUnitDimensionsField;

        /// <remarks/>
        public string ShipFromLocationDomainName
        {
            get
            {
                return this.shipFromLocationDomainNameField;
            }
            set
            {
                this.shipFromLocationDomainNameField = value;
            }
        }

        /// <remarks/>
        public string ShipFromLocation
        {
            get
            {
                return this.shipFromLocationField;
            }
            set
            {
                this.shipFromLocationField = value;
            }
        }

        /// <remarks/>
        public string ShipToLocationDomainName
        {
            get
            {
                return this.shipToLocationDomainNameField;
            }
            set
            {
                this.shipToLocationDomainNameField = value;
            }
        }

        /// <remarks/>
        public string ShipToLocation
        {
            get
            {
                return this.shipToLocationField;
            }
            set
            {
                this.shipToLocationField = value;
            }
        }

        /// <remarks/>
        public byte StopSequence
        {
            get
            {
                return this.stopSequenceField;
            }
            set
            {
                this.stopSequenceField = value;
            }
        }

        /// <remarks/>
        public string DomainName
        {
            get
            {
                return this.domainNameField;
            }
            set
            {
                this.domainNameField = value;
            }
        }

        /// <remarks/>
        public string TransactionCode
        {
            get
            {
                return this.transactionCodeField;
            }
            set
            {
                this.transactionCodeField = value;
            }
        }

        /// <remarks/>
        public string ShipUnitKey
        {
            get
            {
                return this.shipUnitKeyField;
            }
            set
            {
                this.shipUnitKeyField = value;
            }
        }

        /// <remarks/>
        public string ShipUnitType
        {
            get
            {
                return this.shipUnitTypeField;
            }
            set
            {
                this.shipUnitTypeField = value;
            }
        }

        /// <remarks/>
        public double ShipUnitCount
        {
            get
            {
                return this.shipUnitCountField;
            }
            set
            {
                this.shipUnitCountField = value;
            }
        }

        /// <remarks/>
        public double Weight
        {
            get
            {
                return this.weightField;
            }
            set
            {
                this.weightField = value;
            }
        }

        /// <remarks/>
        public string WeightUnitOfMeasure
        {
            get
            {
                return this.weightUnitOfMeasureField;
            }
            set
            {
                this.weightUnitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public double Volume
        {
            get
            {
                return this.volumeField;
            }
            set
            {
                this.volumeField = value;
            }
        }

        /// <remarks/>
        public string VolumeUnitOfMeasure
        {
            get
            {
                return this.volumeUnitOfMeasureField;
            }
            set
            {
                this.volumeUnitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public double WeightGross
        {
            get
            {
                return this.weightGrossField;
            }
            set
            {
                this.weightGrossField = value;
            }
        }

        /// <remarks/>
        public string WeightGrossUnitOfMeasure
        {
            get
            {
                return this.weightGrossUnitOfMeasureField;
            }
            set
            {
                this.weightGrossUnitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public double VolumeGross
        {
            get
            {
                return this.volumeGrossField;
            }
            set
            {
                this.volumeGrossField = value;
            }
        }

        /// <remarks/>
        public string VolumeGrossUnitOfMeasure
        {
            get
            {
                return this.volumeGrossUnitOfMeasureField;
            }
            set
            {
                this.volumeGrossUnitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public double TotalWeight
        {
            get
            {
                return this.totalWeightField;
            }
            set
            {
                this.totalWeightField = value;
            }
        }

        /// <remarks/>
        public double TotalVolume
        {
            get
            {
                return this.totalVolumeField;
            }
            set
            {
                this.totalVolumeField = value;
            }
        }

        /// <remarks/>
        public string IsSplitAllowed
        {
            get
            {
                return this.isSplitAllowedField;
            }
            set
            {
                this.isSplitAllowedField = value;
            }
        }

        /// <remarks/>
        public string IsCountSplittable
        {
            get
            {
                return this.isCountSplittableField;
            }
            set
            {
                this.isCountSplittableField = value;
            }
        }

        /// <remarks/>
        public string IsRepackAllowed
        {
            get
            {
                return this.isRepackAllowedField;
            }
            set
            {
                this.isRepackAllowedField = value;
            }
        }

        /// <remarks/>
        public string NetWeightUOM
        {
            get
            {
                return this.netWeightUOMField;
            }
            set
            {
                this.netWeightUOMField = value;
            }
        }

        /// <remarks/>
        public string NetVolumeUOM
        {
            get
            {
                return this.netVolumeUOMField;
            }
            set
            {
                this.netVolumeUOMField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ShipUnitContent")]
        public APIActualShipmentActualShipmentReleaseOrderShipUnitShipUnitContent[] ShipUnitContents
        {
            get
            {
                return this.shipUnitContentsField;
            }
            set
            {
                this.shipUnitContentsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ReferenceNumber")]
        public APIActualShipmentActualShipmentReleaseOrderShipUnitReferenceNumber[] ReferenceNumbers
        {
            get
            {
                return this.referenceNumbersField;
            }
            set
            {
                this.referenceNumbersField = value;
            }
        }

        /// <remarks/>
        public APIActualShipmentActualShipmentReleaseOrderShipUnitShipUnitDimensions ShipUnitDimensions
        {
            get
            {
                return this.shipUnitDimensionsField;
            }
            set
            {
                this.shipUnitDimensionsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderShipUnitShipUnitContent
    {

        private string domainNameField;

        private int sequenceNumberField;

        private int releaseLineSequenceNumberField;

        private string orderNumberField;

        private string lineItemNumberField;

        private string itemNumberField;

        private string itemNameField;

        private string itemDescriptionField;

        private string itemCommodityGroupField;

        private double quantityField;

        private string quantityUnitOfMeasureField;

        private double weightField;

        private string weightUnitOfMeasureField;

        private double volumeField;

        private string volumeUnitOfMeasureField;

        private double weightGrossField;

        private string weightGrossUnitOfMeasureField;

        private double volumeGrossField;

        private string volumeGrossUnitOfMeasureField;

        private string packagedItemField;

        private double packagedItemCountField;

        /// <remarks/>
        public string DomainName
        {
            get
            {
                return this.domainNameField;
            }
            set
            {
                this.domainNameField = value;
            }
        }

        /// <remarks/>
        public int SequenceNumber
        {
            get
            {
                return this.sequenceNumberField;
            }
            set
            {
                this.sequenceNumberField = value;
            }
        }

        /// <remarks/>
        public int ReleaseLineSequenceNumber
        {
            get
            {
                return this.releaseLineSequenceNumberField;
            }
            set
            {
                this.releaseLineSequenceNumberField = value;
            }
        }

        /// <remarks/>
        public string OrderNumber
        {
            get
            {
                return this.orderNumberField;
            }
            set
            {
                this.orderNumberField = value;
            }
        }

        /// <remarks/>
        public string LineItemNumber
        {
            get
            {
                return this.lineItemNumberField;
            }
            set
            {
                this.lineItemNumberField = value;
            }
        }

        /// <remarks/>
        public string ItemNumber
        {
            get
            {
                return this.itemNumberField;
            }
            set
            {
                this.itemNumberField = value;
            }
        }

        /// <remarks/>
        public string ItemName
        {
            get
            {
                return this.itemNameField;
            }
            set
            {
                this.itemNameField = value;
            }
        }

        /// <remarks/>
        public string ItemDescription
        {
            get
            {
                return this.itemDescriptionField;
            }
            set
            {
                this.itemDescriptionField = value;
            }
        }

        /// <remarks/>
        public string ItemCommodityGroup
        {
            get
            {
                return this.itemCommodityGroupField;
            }
            set
            {
                this.itemCommodityGroupField = value;
            }
        }

        /// <remarks/>
        public double Quantity
        {
            get
            {
                return this.quantityField;
            }
            set
            {
                this.quantityField = value;
            }
        }

        /// <remarks/>
        public string QuantityUnitOfMeasure
        {
            get
            {
                return this.quantityUnitOfMeasureField;
            }
            set
            {
                this.quantityUnitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public double Weight
        {
            get
            {
                return this.weightField;
            }
            set
            {
                this.weightField = value;
            }
        }

        /// <remarks/>
        public string WeightUnitOfMeasure
        {
            get
            {
                return this.weightUnitOfMeasureField;
            }
            set
            {
                this.weightUnitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public double Volume
        {
            get
            {
                return this.volumeField;
            }
            set
            {
                this.volumeField = value;
            }
        }

        /// <remarks/>
        public string VolumeUnitOfMeasure
        {
            get
            {
                return this.volumeUnitOfMeasureField;
            }
            set
            {
                this.volumeUnitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public double WeightGross
        {
            get
            {
                return this.weightGrossField;
            }
            set
            {
                this.weightGrossField = value;
            }
        }

        /// <remarks/>
        public string WeightGrossUnitOfMeasure
        {
            get
            {
                return this.weightGrossUnitOfMeasureField;
            }
            set
            {
                this.weightGrossUnitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public double VolumeGross
        {
            get
            {
                return this.volumeGrossField;
            }
            set
            {
                this.volumeGrossField = value;
            }
        }

        /// <remarks/>
        public string VolumeGrossUnitOfMeasure
        {
            get
            {
                return this.volumeGrossUnitOfMeasureField;
            }
            set
            {
                this.volumeGrossUnitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public string PackagedItem
        {
            get
            {
                return this.packagedItemField;
            }
            set
            {
                this.packagedItemField = value;
            }
        }

        /// <remarks/>
        public double PackagedItemCount
        {
            get
            {
                return this.packagedItemCountField;
            }
            set
            {
                this.packagedItemCountField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderShipUnitReferenceNumber
    {

        private string domainNameField;

        private string referenceNumberTypeField;

        private string referenceNumberValueField;

        /// <remarks/>
        public string DomainName
        {
            get
            {
                return this.domainNameField;
            }
            set
            {
                this.domainNameField = value;
            }
        }

        /// <remarks/>
        public string ReferenceNumberType
        {
            get
            {
                return this.referenceNumberTypeField;
            }
            set
            {
                this.referenceNumberTypeField = value;
            }
        }

        /// <remarks/>
        public string ReferenceNumberValue
        {
            get
            {
                return this.referenceNumberValueField;
            }
            set
            {
                this.referenceNumberValueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderShipUnitShipUnitDimensions
    {

        private double lengthField;

        private string lengthUnitOfMeasureField;

        private double widthField;

        private string widthUnitOfMeasureField;

        private double heightField;

        private string heightUnitOfMeasureField;

        /// <remarks/>
        public double Length
        {
            get
            {
                return this.lengthField;
            }
            set
            {
                this.lengthField = value;
            }
        }

        /// <remarks/>
        public string LengthUnitOfMeasure
        {
            get
            {
                return this.lengthUnitOfMeasureField;
            }
            set
            {
                this.lengthUnitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public double Width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }

        /// <remarks/>
        public string WidthUnitOfMeasure
        {
            get
            {
                return this.widthUnitOfMeasureField;
            }
            set
            {
                this.widthUnitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public double Height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }

        /// <remarks/>
        public string HeightUnitOfMeasure
        {
            get
            {
                return this.heightUnitOfMeasureField;
            }
            set
            {
                this.heightUnitOfMeasureField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIActualShipmentActualShipmentReleaseOrderIntegrationError
    {

        private byte idField;

        private byte orderIdField;

        private byte typeIdField;

        private string messageField;

        private string tradingPartnerIdField;

        private string orderNumberField;

        private string revenueTerminalField;

        private System.DateTime createDateTimeField;

        /// <remarks/>
        public byte Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public byte OrderId
        {
            get
            {
                return this.orderIdField;
            }
            set
            {
                this.orderIdField = value;
            }
        }

        /// <remarks/>
        public byte TypeId
        {
            get
            {
                return this.typeIdField;
            }
            set
            {
                this.typeIdField = value;
            }
        }

        /// <remarks/>
        public string Message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

        /// <remarks/>
        public string TradingPartnerId
        {
            get
            {
                return this.tradingPartnerIdField;
            }
            set
            {
                this.tradingPartnerIdField = value;
            }
        }

        /// <remarks/>
        public string OrderNumber
        {
            get
            {
                return this.orderNumberField;
            }
            set
            {
                this.orderNumberField = value;
            }
        }

        /// <remarks/>
        public string RevenueTerminal
        {
            get
            {
                return this.revenueTerminalField;
            }
            set
            {
                this.revenueTerminalField = value;
            }
        }

        /// <remarks/>
        public System.DateTime CreateDateTime
        {
            get
            {
                return this.createDateTimeField;
            }
            set
            {
                this.createDateTimeField = value;
            }
        }
    }


}
