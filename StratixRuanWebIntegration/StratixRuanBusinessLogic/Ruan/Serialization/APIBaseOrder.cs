namespace StratixRuanBusinessLogic.Ruan.Serialization
{


    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ApiBaseOrder
    {

        private string domainNameField;

        private string transmissionTypeField;

        private string senderTransmissionNoField;

        //private ApiBaseOrderBaseOrder[] baseOrdersField;

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
        [System.Xml.Serialization.XmlArrayItemAttribute("BaseOrder")]
        public System.Collections.Generic.List<ApiBaseOrderBaseOrder> BaseOrders { get; set; }
    /* 
        public ApiBaseOrderBaseOrder[] BaseOrders
        {
            get
            {
                return this.baseOrdersField;
            }
            set
            {
                this.baseOrdersField = value;
            }
        } */
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ApiBaseOrderBaseOrder
    {

        private ApiBaseOrderBaseOrderOrderHeader orderHeaderField;

        //private ApiBaseOrderBaseOrderOrderLine[] orderLinesField;

        /// <remarks/>
        public ApiBaseOrderBaseOrderOrderHeader OrderHeader
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
        [System.Xml.Serialization.XmlArrayItemAttribute("OrderLine")]
        public System.Collections.Generic.List<ApiBaseOrderBaseOrderOrderLine> OrderLines { get; set; }
       /* public ApiBaseOrderBaseOrderOrderLine[] OrderLines
        {
            get
            {
                return this.orderLinesField;
            }
            set
            {
                this.orderLinesField = value;
            } */
        }
    

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ApiBaseOrderBaseOrderOrderHeader
    {

        private string orderNumberField;

        private string orderTypeField;

        private string externalSystemIdField;

        private string transactionCodeField;

        private string[] replaceChildrenField;

        private string timeWindowEmphasisField;

        private string priorityField;

        private string orderShippingConfigurationField;

        private string paymentMethodField;

        private string mustShipDirectField;

        private string mustShipThruXDockField;

        private string mustShipThruPoolField;

        private string bundlingTypeField;

        private string isShipperKnownField;

        private decimal totalNetWeightField;

        private string totalNetWeightUnitOfMeasureField;

        private decimal totalNetVolumeField;

        private string totalNetVolumeUnitOfMeasureField;

        private object effectiveDateField;

        private object expirationDateField;

        private ApiBaseOrderBaseOrderOrderHeaderCustomerServiceRep customerServiceRepField;

        private ApiBaseOrderBaseOrderOrderHeaderReferenceNumber[] referenceNumbersField;

        private ApiBaseOrderBaseOrderOrderHeaderComment[] commentsField;

        private ApiBaseOrderBaseOrderOrderHeaderFlexFieldStrings flexFieldStringsField;

        private ApiBaseOrderBaseOrderOrderHeaderFlexFieldNumbers flexFieldNumbersField;

        private ApiBaseOrderBaseOrderOrderHeaderFlexFieldDates flexFieldDatesField;

        private ApiBaseOrderBaseOrderOrderHeaderFlexFieldCurrencies flexFieldCurrenciesField;

        private string statusValueField;

        private string statusTypeField;

        private string shipWithGroupIdField;

        private string preferredTransportationModeField;

        private string equipmentGroupField;

        private ApiBaseOrderBaseOrderOrderHeaderTemperatureRestriction temperatureRestrictionField;

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
        public string ExternalSystemId
        {
            get
            {
                return this.externalSystemIdField;
            }
            set
            {
                this.externalSystemIdField = value;
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
        public string[] ReplaceChildren
        {
            get
            {
                return this.replaceChildrenField;
            }
            set
            {
                this.replaceChildrenField = value;
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
        public string MustShipDirect
        {
            get
            {
                return this.mustShipDirectField;
            }
            set
            {
                this.mustShipDirectField = value;
            }
        }

        /// <remarks/>
        public string MustShipThruXDock
        {
            get
            {
                return this.mustShipThruXDockField;
            }
            set
            {
                this.mustShipThruXDockField = value;
            }
        }

        /// <remarks/>
        public string MustShipThruPool
        {
            get
            {
                return this.mustShipThruPoolField;
            }
            set
            {
                this.mustShipThruPoolField = value;
            }
        }

        /// <remarks/>
        public string BundlingType
        {
            get
            {
                return this.bundlingTypeField;
            }
            set
            {
                this.bundlingTypeField = value;
            }
        }

        /// <remarks/>
        public string IsShipperKnown
        {
            get
            {
                return this.isShipperKnownField;
            }
            set
            {
                this.isShipperKnownField = value;
            }
        }

        /// <remarks/>
        public decimal TotalNetWeight
        {
            get
            {
                return this.totalNetWeightField;
            }
            set
            {
                this.totalNetWeightField = value;
            }
        }

        /// <remarks/>
        public string TotalNetWeightUnitOfMeasure
        {
            get
            {
                return this.totalNetWeightUnitOfMeasureField;
            }
            set
            {
                this.totalNetWeightUnitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public decimal TotalNetVolume
        {
            get
            {
                return this.totalNetVolumeField;
            }
            set
            {
                this.totalNetVolumeField = value;
            }
        }

        /// <remarks/>
        public string TotalNetVolumeUnitOfMeasure
        {
            get
            {
                return this.totalNetVolumeUnitOfMeasureField;
            }
            set
            {
                this.totalNetVolumeUnitOfMeasureField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object EffectiveDate
        {
            get
            {
                return this.effectiveDateField;
            }
            set
            {
                this.effectiveDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object ExpirationDate
        {
            get
            {
                return this.expirationDateField;
            }
            set
            {
                this.expirationDateField = value;
            }
        }

        /// <remarks/>
        public ApiBaseOrderBaseOrderOrderHeaderCustomerServiceRep CustomerServiceRep
        {
            get
            {
                return this.customerServiceRepField;
            }
            set
            {
                this.customerServiceRepField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ReferenceNumber")]
        public ApiBaseOrderBaseOrderOrderHeaderReferenceNumber[] ReferenceNumbers
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
        public ApiBaseOrderBaseOrderOrderHeaderComment[] Comments
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
        public ApiBaseOrderBaseOrderOrderHeaderFlexFieldStrings FlexFieldStrings
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
        public ApiBaseOrderBaseOrderOrderHeaderFlexFieldNumbers FlexFieldNumbers
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
        public ApiBaseOrderBaseOrderOrderHeaderFlexFieldDates FlexFieldDates
        {
            get
            {
                return this.flexFieldDatesField;
            }
            set
            {
                this.flexFieldDatesField = value;
            }
        }

        /// <remarks/>
        public ApiBaseOrderBaseOrderOrderHeaderFlexFieldCurrencies FlexFieldCurrencies
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
        public ApiBaseOrderBaseOrderOrderHeaderTemperatureRestriction TemperatureRestriction
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ApiBaseOrderBaseOrderOrderHeaderCustomerServiceRep
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
    public partial class ApiBaseOrderBaseOrderOrderHeaderReferenceNumber
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
    public partial class ApiBaseOrderBaseOrderOrderHeaderComment
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
    public partial class ApiBaseOrderBaseOrderOrderHeaderFlexFieldStrings
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
    public partial class ApiBaseOrderBaseOrderOrderHeaderFlexFieldNumbers
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
    public partial class ApiBaseOrderBaseOrderOrderHeaderFlexFieldDates
    {

        private ApiBaseOrderBaseOrderOrderHeaderFlexFieldDatesAttributeDate1 attributeDate1Field;

        private ApiBaseOrderBaseOrderOrderHeaderFlexFieldDatesAttributeDate2 attributeDate2Field;

        private ApiBaseOrderBaseOrderOrderHeaderFlexFieldDatesAttributeDate3 attributeDate3Field;

        private ApiBaseOrderBaseOrderOrderHeaderFlexFieldDatesAttributeDate4 attributeDate4Field;

        private ApiBaseOrderBaseOrderOrderHeaderFlexFieldDatesAttributeDate5 attributeDate5Field;

        private ApiBaseOrderBaseOrderOrderHeaderFlexFieldDatesAttributeDate6 attributeDate6Field;

        private ApiBaseOrderBaseOrderOrderHeaderFlexFieldDatesAttributeDate7 attributeDate7Field;

        private ApiBaseOrderBaseOrderOrderHeaderFlexFieldDatesAttributeDate8 attributeDate8Field;

        private ApiBaseOrderBaseOrderOrderHeaderFlexFieldDatesAttributeDate9 attributeDate9Field;

        private ApiBaseOrderBaseOrderOrderHeaderFlexFieldDatesAttributeDate10 attributeDate10Field;

        /// <remarks/>
        public ApiBaseOrderBaseOrderOrderHeaderFlexFieldDatesAttributeDate1 AttributeDate1
        {
            get
            {
                return this.attributeDate1Field;
            }
            set
            {
                this.attributeDate1Field = value;
            }
        }

        /// <remarks/>
        public ApiBaseOrderBaseOrderOrderHeaderFlexFieldDatesAttributeDate2 AttributeDate2
        {
            get
            {
                return this.attributeDate2Field;
            }
            set
            {
                this.attributeDate2Field = value;
            }
        }

        /// <remarks/>
        public ApiBaseOrderBaseOrderOrderHeaderFlexFieldDatesAttributeDate3 AttributeDate3
        {
            get
            {
                return this.attributeDate3Field;
            }
            set
            {
                this.attributeDate3Field = value;
            }
        }

        /// <remarks/>
        public ApiBaseOrderBaseOrderOrderHeaderFlexFieldDatesAttributeDate4 AttributeDate4
        {
            get
            {
                return this.attributeDate4Field;
            }
            set
            {
                this.attributeDate4Field = value;
            }
        }

        /// <remarks/>
        public ApiBaseOrderBaseOrderOrderHeaderFlexFieldDatesAttributeDate5 AttributeDate5
        {
            get
            {
                return this.attributeDate5Field;
            }
            set
            {
                this.attributeDate5Field = value;
            }
        }

        /// <remarks/>
        public ApiBaseOrderBaseOrderOrderHeaderFlexFieldDatesAttributeDate6 AttributeDate6
        {
            get
            {
                return this.attributeDate6Field;
            }
            set
            {
                this.attributeDate6Field = value;
            }
        }

        /// <remarks/>
        public ApiBaseOrderBaseOrderOrderHeaderFlexFieldDatesAttributeDate7 AttributeDate7
        {
            get
            {
                return this.attributeDate7Field;
            }
            set
            {
                this.attributeDate7Field = value;
            }
        }

        /// <remarks/>
        public ApiBaseOrderBaseOrderOrderHeaderFlexFieldDatesAttributeDate8 AttributeDate8
        {
            get
            {
                return this.attributeDate8Field;
            }
            set
            {
                this.attributeDate8Field = value;
            }
        }

        /// <remarks/>
        public ApiBaseOrderBaseOrderOrderHeaderFlexFieldDatesAttributeDate9 AttributeDate9
        {
            get
            {
                return this.attributeDate9Field;
            }
            set
            {
                this.attributeDate9Field = value;
            }
        }

        /// <remarks/>
        public ApiBaseOrderBaseOrderOrderHeaderFlexFieldDatesAttributeDate10 AttributeDate10
        {
            get
            {
                return this.attributeDate10Field;
            }
            set
            {
                this.attributeDate10Field = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ApiBaseOrderBaseOrderOrderHeaderFlexFieldDatesAttributeDate1
    {

        private string gLogDateField;

        private string tZIdField;

        private string tZOffsetField;

        /// <remarks/>
        public string GLogDate
        {
            get
            {
                return this.gLogDateField;
            }
            set
            {
                this.gLogDateField = value;
            }
        }

        /// <remarks/>
        public string TZId
        {
            get
            {
                return this.tZIdField;
            }
            set
            {
                this.tZIdField = value;
            }
        }

        /// <remarks/>
        public string TZOffset
        {
            get
            {
                return this.tZOffsetField;
            }
            set
            {
                this.tZOffsetField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ApiBaseOrderBaseOrderOrderHeaderFlexFieldDatesAttributeDate2
    {

        private string gLogDateField;

        private string tZIdField;

        private string tZOffsetField;

        /// <remarks/>
        public string GLogDate
        {
            get
            {
                return this.gLogDateField;
            }
            set
            {
                this.gLogDateField = value;
            }
        }

        /// <remarks/>
        public string TZId
        {
            get
            {
                return this.tZIdField;
            }
            set
            {
                this.tZIdField = value;
            }
        }

        /// <remarks/>
        public string TZOffset
        {
            get
            {
                return this.tZOffsetField;
            }
            set
            {
                this.tZOffsetField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ApiBaseOrderBaseOrderOrderHeaderFlexFieldDatesAttributeDate3
    {

        private string gLogDateField;

        private string tZIdField;

        private string tZOffsetField;

        /// <remarks/>
        public string GLogDate
        {
            get
            {
                return this.gLogDateField;
            }
            set
            {
                this.gLogDateField = value;
            }
        }

        /// <remarks/>
        public string TZId
        {
            get
            {
                return this.tZIdField;
            }
            set
            {
                this.tZIdField = value;
            }
        }

        /// <remarks/>
        public string TZOffset
        {
            get
            {
                return this.tZOffsetField;
            }
            set
            {
                this.tZOffsetField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ApiBaseOrderBaseOrderOrderHeaderFlexFieldDatesAttributeDate4
    {

        private string gLogDateField;

        private string tZIdField;

        private string tZOffsetField;

        /// <remarks/>
        public string GLogDate
        {
            get
            {
                return this.gLogDateField;
            }
            set
            {
                this.gLogDateField = value;
            }
        }

        /// <remarks/>
        public string TZId
        {
            get
            {
                return this.tZIdField;
            }
            set
            {
                this.tZIdField = value;
            }
        }

        /// <remarks/>
        public string TZOffset
        {
            get
            {
                return this.tZOffsetField;
            }
            set
            {
                this.tZOffsetField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ApiBaseOrderBaseOrderOrderHeaderFlexFieldDatesAttributeDate5
    {

        private string gLogDateField;

        private string tZIdField;

        private string tZOffsetField;

        /// <remarks/>
        public string GLogDate
        {
            get
            {
                return this.gLogDateField;
            }
            set
            {
                this.gLogDateField = value;
            }
        }

        /// <remarks/>
        public string TZId
        {
            get
            {
                return this.tZIdField;
            }
            set
            {
                this.tZIdField = value;
            }
        }

        /// <remarks/>
        public string TZOffset
        {
            get
            {
                return this.tZOffsetField;
            }
            set
            {
                this.tZOffsetField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ApiBaseOrderBaseOrderOrderHeaderFlexFieldDatesAttributeDate6
    {

        private string gLogDateField;

        private string tZIdField;

        private string tZOffsetField;

        /// <remarks/>
        public string GLogDate
        {
            get
            {
                return this.gLogDateField;
            }
            set
            {
                this.gLogDateField = value;
            }
        }

        /// <remarks/>
        public string TZId
        {
            get
            {
                return this.tZIdField;
            }
            set
            {
                this.tZIdField = value;
            }
        }

        /// <remarks/>
        public string TZOffset
        {
            get
            {
                return this.tZOffsetField;
            }
            set
            {
                this.tZOffsetField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ApiBaseOrderBaseOrderOrderHeaderFlexFieldDatesAttributeDate7
    {

        private string gLogDateField;

        private string tZIdField;

        private string tZOffsetField;

        /// <remarks/>
        public string GLogDate
        {
            get
            {
                return this.gLogDateField;
            }
            set
            {
                this.gLogDateField = value;
            }
        }

        /// <remarks/>
        public string TZId
        {
            get
            {
                return this.tZIdField;
            }
            set
            {
                this.tZIdField = value;
            }
        }

        /// <remarks/>
        public string TZOffset
        {
            get
            {
                return this.tZOffsetField;
            }
            set
            {
                this.tZOffsetField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ApiBaseOrderBaseOrderOrderHeaderFlexFieldDatesAttributeDate8
    {

        private string gLogDateField;

        private string tZIdField;

        private string tZOffsetField;

        /// <remarks/>
        public string GLogDate
        {
            get
            {
                return this.gLogDateField;
            }
            set
            {
                this.gLogDateField = value;
            }
        }

        /// <remarks/>
        public string TZId
        {
            get
            {
                return this.tZIdField;
            }
            set
            {
                this.tZIdField = value;
            }
        }

        /// <remarks/>
        public string TZOffset
        {
            get
            {
                return this.tZOffsetField;
            }
            set
            {
                this.tZOffsetField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ApiBaseOrderBaseOrderOrderHeaderFlexFieldDatesAttributeDate9
    {

        private string gLogDateField;

        private string tZIdField;

        private string tZOffsetField;

        /// <remarks/>
        public string GLogDate
        {
            get
            {
                return this.gLogDateField;
            }
            set
            {
                this.gLogDateField = value;
            }
        }

        /// <remarks/>
        public string TZId
        {
            get
            {
                return this.tZIdField;
            }
            set
            {
                this.tZIdField = value;
            }
        }

        /// <remarks/>
        public string TZOffset
        {
            get
            {
                return this.tZOffsetField;
            }
            set
            {
                this.tZOffsetField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ApiBaseOrderBaseOrderOrderHeaderFlexFieldDatesAttributeDate10
    {

        private string gLogDateField;

        private string tZIdField;

        private string tZOffsetField;

        /// <remarks/>
        public string GLogDate
        {
            get
            {
                return this.gLogDateField;
            }
            set
            {
                this.gLogDateField = value;
            }
        }

        /// <remarks/>
        public string TZId
        {
            get
            {
                return this.tZIdField;
            }
            set
            {
                this.tZIdField = value;
            }
        }

        /// <remarks/>
        public string TZOffset
        {
            get
            {
                return this.tZOffsetField;
            }
            set
            {
                this.tZOffsetField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ApiBaseOrderBaseOrderOrderHeaderFlexFieldCurrencies
    {

        private ApiBaseOrderBaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency1 attributeCurrency1Field;

        private ApiBaseOrderBaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency2 attributeCurrency2Field;

        private ApiBaseOrderBaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency3 attributeCurrency3Field;

        /// <remarks/>
        public ApiBaseOrderBaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency1 AttributeCurrency1
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
        public ApiBaseOrderBaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency2 AttributeCurrency2
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
        public ApiBaseOrderBaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency3 AttributeCurrency3
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
    public partial class ApiBaseOrderBaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency1
    {

        private ApiBaseOrderBaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency1FinancialAmount financialAmountField;

        /// <remarks/>
        public ApiBaseOrderBaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency1FinancialAmount FinancialAmount
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
    public partial class ApiBaseOrderBaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency1FinancialAmount
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
    public partial class ApiBaseOrderBaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency2
    {

        private ApiBaseOrderBaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency2FinancialAmount financialAmountField;

        /// <remarks/>
        public ApiBaseOrderBaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency2FinancialAmount FinancialAmount
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
    public partial class ApiBaseOrderBaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency2FinancialAmount
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
    public partial class ApiBaseOrderBaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency3
    {

        private ApiBaseOrderBaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency3FinancialAmount financialAmountField;

        /// <remarks/>
        public ApiBaseOrderBaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency3FinancialAmount FinancialAmount
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
    public partial class ApiBaseOrderBaseOrderOrderHeaderFlexFieldCurrenciesAttributeCurrency3FinancialAmount
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
    public partial class ApiBaseOrderBaseOrderOrderHeaderTemperatureRestriction
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
    public partial class ApiBaseOrderBaseOrderOrderLine
    {

        private string autoCreateItemField;

        private string autoCreateItemMasterField;

        private string isStackableField;

        private string lineItemNumberField;

        private string transactionCodeField;

        private string statusValueField;

        private string statusTypeField;

        private ApiBaseOrderBaseOrderOrderLineShipFrom shipFromField;

        private ApiBaseOrderBaseOrderOrderLineShipTo shipToField;

        private string itemNumberField;

        private string itemNameField;

        private string itemDescriptionField;

        private string itemCommodityGroupField;

        private decimal quantityField;

        private string quantityUnitOfMeasureField;

        private decimal weightField;

        private string weightUnitOfMeasureField;

        private decimal volumeField;

        private string volumeUnitOfMeasureField;

        private decimal weightGrossField;

        private string weightGrossUnitOfMeasureField;

        private decimal volumeGrossField;

        private string volumeGrossUnitOfMeasureField;

        private string hazardousClassficationField;

        private string unitedNationsHazardNumberField;

        private string hazardousPackagingGroupField;

        private ApiBaseOrderBaseOrderOrderLineLineItemDimensions lineItemDimensionsField;

        private ApiBaseOrderBaseOrderOrderLineTemperatureRestriction temperatureRestrictionField;

        private ApiBaseOrderBaseOrderOrderLineReferenceNumber[] referenceNumbersField;

        private ApiBaseOrderBaseOrderOrderLinePackagingShipUnit packagingShipUnitField;

        private string domainNameField;

        private string numLayersPerShipUnitField;

        private string quantityPerLayerField;

        private string shipUnitSpecIdField;

        private string isShippableField;

        private string isSplitAllowedField;

        private ApiBaseOrderBaseOrderOrderLineFlexFieldStrings flexFieldStringsField;

        private ApiBaseOrderBaseOrderOrderLineFlexFieldNumbers flexFieldNumbersField;

        private ApiBaseOrderBaseOrderOrderLineFlexFieldDates flexFieldDatesField;

        private ApiBaseOrderBaseOrderOrderLineShippingAndDeliveryDates shippingAndDeliveryDatesField;

        private string preferredCarrierScacField;

        private string specialRoutingInstructionsField;

        private ApiBaseOrderBaseOrderOrderLineComment[] commentsField;

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
        public ApiBaseOrderBaseOrderOrderLineShipFrom ShipFrom
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
        public ApiBaseOrderBaseOrderOrderLineShipTo ShipTo
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
        public decimal Quantity
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
        public decimal Weight
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
        public decimal Volume
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
        public decimal WeightGross
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
        public decimal VolumeGross
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
        public ApiBaseOrderBaseOrderOrderLineLineItemDimensions LineItemDimensions
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
        public ApiBaseOrderBaseOrderOrderLineTemperatureRestriction TemperatureRestriction
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
        [System.Xml.Serialization.XmlArrayItemAttribute("ReferenceNumber")]
        public ApiBaseOrderBaseOrderOrderLineReferenceNumber[] ReferenceNumbers
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
        public ApiBaseOrderBaseOrderOrderLinePackagingShipUnit PackagingShipUnit
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
        public string NumLayersPerShipUnit
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
        public string QuantityPerLayer
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

        /// <remarks/>
        public string ShipUnitSpecId
        {
            get
            {
                return this.shipUnitSpecIdField;
            }
            set
            {
                this.shipUnitSpecIdField = value;
            }
        }

        /// <remarks/>
        public string IsShippable
        {
            get
            {
                return this.isShippableField;
            }
            set
            {
                this.isShippableField = value;
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
        public ApiBaseOrderBaseOrderOrderLineFlexFieldStrings FlexFieldStrings
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
        public ApiBaseOrderBaseOrderOrderLineFlexFieldNumbers FlexFieldNumbers
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
        public ApiBaseOrderBaseOrderOrderLineFlexFieldDates FlexFieldDates
        {
            get
            {
                return this.flexFieldDatesField;
            }
            set
            {
                this.flexFieldDatesField = value;
            }
        }

        /// <remarks/>
        public ApiBaseOrderBaseOrderOrderLineShippingAndDeliveryDates ShippingAndDeliveryDates
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

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Comment")]
        public ApiBaseOrderBaseOrderOrderLineComment[] Comments
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ApiBaseOrderBaseOrderOrderLineShipFrom
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

        private decimal latitudeField;

        private decimal longitudeField;

        private string customerLocationCodeField;

        private string contactNumberField;

        private string locationTypeField;

        private string roleField;

        private ApiBaseOrderBaseOrderOrderLineShipFromContact contactField;

        private ApiBaseOrderBaseOrderOrderLineShipFromReferenceNumber[] referenceNumbersField;

        private bool postLocationToOTMField;

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
        public decimal Latitude
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
        public decimal Longitude
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
        public ApiBaseOrderBaseOrderOrderLineShipFromContact Contact
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
        [System.Xml.Serialization.XmlArrayItemAttribute("ReferenceNumber")]
        public ApiBaseOrderBaseOrderOrderLineShipFromReferenceNumber[] ReferenceNumbers
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ApiBaseOrderBaseOrderOrderLineShipFromContact
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
    public partial class ApiBaseOrderBaseOrderOrderLineShipFromReferenceNumber
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
    public partial class ApiBaseOrderBaseOrderOrderLineShipTo
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

        private decimal latitudeField;

        private decimal longitudeField;

        private string customerLocationCodeField;

        private string contactNumberField;

        private string locationTypeField;

        private string roleField;

        private ApiBaseOrderBaseOrderOrderLineShipToContact contactField;

        private ApiBaseOrderBaseOrderOrderLineShipToReferenceNumber[] referenceNumbersField;

        private bool postLocationToOTMField;

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
        public decimal Latitude
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
        public decimal Longitude
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
        public ApiBaseOrderBaseOrderOrderLineShipToContact Contact
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
        [System.Xml.Serialization.XmlArrayItemAttribute("ReferenceNumber")]
        public ApiBaseOrderBaseOrderOrderLineShipToReferenceNumber[] ReferenceNumbers
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ApiBaseOrderBaseOrderOrderLineShipToContact
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
    public partial class ApiBaseOrderBaseOrderOrderLineShipToReferenceNumber
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
    public partial class ApiBaseOrderBaseOrderOrderLineLineItemDimensions
    {

        private decimal length1Field;

        private decimal length2Field;

        private decimal width1Field;

        private decimal width2Field;

        private decimal height1Field;

        private decimal height2Field;

        private string unitOfMeasureField;

        private decimal weightField;

        private string weightUnitOfMeasureField;

        private decimal volumeField;

        private string volumeUnitOfMeasureField;

        private string nMFCField;

        private string nMFCCodeField;

        private string userDefinedCommodityField;

        /// <remarks/>
        public decimal Length1
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
        public decimal Length2
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
        public decimal Width1
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
        public decimal Width2
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
        public decimal Height1
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
        public decimal Height2
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
        public decimal Weight
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
        public decimal Volume
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
    public partial class ApiBaseOrderBaseOrderOrderLineTemperatureRestriction
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
    public partial class ApiBaseOrderBaseOrderOrderLineReferenceNumber
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
    public partial class ApiBaseOrderBaseOrderOrderLinePackagingShipUnit
    {

        private string domainNameField;

        private string shipUnitSpecGidField;

        private decimal numLayersPerShipUnitField;

        private decimal quantityPerLayerField;

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
        public decimal NumLayersPerShipUnit
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
        public decimal QuantityPerLayer
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
    public partial class ApiBaseOrderBaseOrderOrderLineFlexFieldStrings
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
    public partial class ApiBaseOrderBaseOrderOrderLineFlexFieldNumbers
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
    public partial class ApiBaseOrderBaseOrderOrderLineFlexFieldDates
    {

        private ApiBaseOrderBaseOrderOrderLineFlexFieldDatesAttributeDate1 attributeDate1Field;

        private ApiBaseOrderBaseOrderOrderLineFlexFieldDatesAttributeDate2 attributeDate2Field;

        private ApiBaseOrderBaseOrderOrderLineFlexFieldDatesAttributeDate3 attributeDate3Field;

        private ApiBaseOrderBaseOrderOrderLineFlexFieldDatesAttributeDate4 attributeDate4Field;

        private ApiBaseOrderBaseOrderOrderLineFlexFieldDatesAttributeDate5 attributeDate5Field;

        private ApiBaseOrderBaseOrderOrderLineFlexFieldDatesAttributeDate6 attributeDate6Field;

        private ApiBaseOrderBaseOrderOrderLineFlexFieldDatesAttributeDate7 attributeDate7Field;

        private ApiBaseOrderBaseOrderOrderLineFlexFieldDatesAttributeDate8 attributeDate8Field;

        private ApiBaseOrderBaseOrderOrderLineFlexFieldDatesAttributeDate9 attributeDate9Field;

        private ApiBaseOrderBaseOrderOrderLineFlexFieldDatesAttributeDate10 attributeDate10Field;

        /// <remarks/>
        public ApiBaseOrderBaseOrderOrderLineFlexFieldDatesAttributeDate1 AttributeDate1
        {
            get
            {
                return this.attributeDate1Field;
            }
            set
            {
                this.attributeDate1Field = value;
            }
        }

        /// <remarks/>
        public ApiBaseOrderBaseOrderOrderLineFlexFieldDatesAttributeDate2 AttributeDate2
        {
            get
            {
                return this.attributeDate2Field;
            }
            set
            {
                this.attributeDate2Field = value;
            }
        }

        /// <remarks/>
        public ApiBaseOrderBaseOrderOrderLineFlexFieldDatesAttributeDate3 AttributeDate3
        {
            get
            {
                return this.attributeDate3Field;
            }
            set
            {
                this.attributeDate3Field = value;
            }
        }

        /// <remarks/>
        public ApiBaseOrderBaseOrderOrderLineFlexFieldDatesAttributeDate4 AttributeDate4
        {
            get
            {
                return this.attributeDate4Field;
            }
            set
            {
                this.attributeDate4Field = value;
            }
        }

        /// <remarks/>
        public ApiBaseOrderBaseOrderOrderLineFlexFieldDatesAttributeDate5 AttributeDate5
        {
            get
            {
                return this.attributeDate5Field;
            }
            set
            {
                this.attributeDate5Field = value;
            }
        }

        /// <remarks/>
        public ApiBaseOrderBaseOrderOrderLineFlexFieldDatesAttributeDate6 AttributeDate6
        {
            get
            {
                return this.attributeDate6Field;
            }
            set
            {
                this.attributeDate6Field = value;
            }
        }

        /// <remarks/>
        public ApiBaseOrderBaseOrderOrderLineFlexFieldDatesAttributeDate7 AttributeDate7
        {
            get
            {
                return this.attributeDate7Field;
            }
            set
            {
                this.attributeDate7Field = value;
            }
        }

        /// <remarks/>
        public ApiBaseOrderBaseOrderOrderLineFlexFieldDatesAttributeDate8 AttributeDate8
        {
            get
            {
                return this.attributeDate8Field;
            }
            set
            {
                this.attributeDate8Field = value;
            }
        }

        /// <remarks/>
        public ApiBaseOrderBaseOrderOrderLineFlexFieldDatesAttributeDate9 AttributeDate9
        {
            get
            {
                return this.attributeDate9Field;
            }
            set
            {
                this.attributeDate9Field = value;
            }
        }

        /// <remarks/>
        public ApiBaseOrderBaseOrderOrderLineFlexFieldDatesAttributeDate10 AttributeDate10
        {
            get
            {
                return this.attributeDate10Field;
            }
            set
            {
                this.attributeDate10Field = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ApiBaseOrderBaseOrderOrderLineFlexFieldDatesAttributeDate1
    {

        private string gLogDateField;

        private string tZIdField;

        private string tZOffsetField;

        /// <remarks/>
        public string GLogDate
        {
            get
            {
                return this.gLogDateField;
            }
            set
            {
                this.gLogDateField = value;
            }
        }

        /// <remarks/>
        public string TZId
        {
            get
            {
                return this.tZIdField;
            }
            set
            {
                this.tZIdField = value;
            }
        }

        /// <remarks/>
        public string TZOffset
        {
            get
            {
                return this.tZOffsetField;
            }
            set
            {
                this.tZOffsetField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ApiBaseOrderBaseOrderOrderLineFlexFieldDatesAttributeDate2
    {

        private string gLogDateField;

        private string tZIdField;

        private string tZOffsetField;

        /// <remarks/>
        public string GLogDate
        {
            get
            {
                return this.gLogDateField;
            }
            set
            {
                this.gLogDateField = value;
            }
        }

        /// <remarks/>
        public string TZId
        {
            get
            {
                return this.tZIdField;
            }
            set
            {
                this.tZIdField = value;
            }
        }

        /// <remarks/>
        public string TZOffset
        {
            get
            {
                return this.tZOffsetField;
            }
            set
            {
                this.tZOffsetField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ApiBaseOrderBaseOrderOrderLineFlexFieldDatesAttributeDate3
    {

        private string gLogDateField;

        private string tZIdField;

        private string tZOffsetField;

        /// <remarks/>
        public string GLogDate
        {
            get
            {
                return this.gLogDateField;
            }
            set
            {
                this.gLogDateField = value;
            }
        }

        /// <remarks/>
        public string TZId
        {
            get
            {
                return this.tZIdField;
            }
            set
            {
                this.tZIdField = value;
            }
        }

        /// <remarks/>
        public string TZOffset
        {
            get
            {
                return this.tZOffsetField;
            }
            set
            {
                this.tZOffsetField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ApiBaseOrderBaseOrderOrderLineFlexFieldDatesAttributeDate4
    {

        private string gLogDateField;

        private string tZIdField;

        private string tZOffsetField;

        /// <remarks/>
        public string GLogDate
        {
            get
            {
                return this.gLogDateField;
            }
            set
            {
                this.gLogDateField = value;
            }
        }

        /// <remarks/>
        public string TZId
        {
            get
            {
                return this.tZIdField;
            }
            set
            {
                this.tZIdField = value;
            }
        }

        /// <remarks/>
        public string TZOffset
        {
            get
            {
                return this.tZOffsetField;
            }
            set
            {
                this.tZOffsetField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ApiBaseOrderBaseOrderOrderLineFlexFieldDatesAttributeDate5
    {

        private string gLogDateField;

        private string tZIdField;

        private string tZOffsetField;

        /// <remarks/>
        public string GLogDate
        {
            get
            {
                return this.gLogDateField;
            }
            set
            {
                this.gLogDateField = value;
            }
        }

        /// <remarks/>
        public string TZId
        {
            get
            {
                return this.tZIdField;
            }
            set
            {
                this.tZIdField = value;
            }
        }

        /// <remarks/>
        public string TZOffset
        {
            get
            {
                return this.tZOffsetField;
            }
            set
            {
                this.tZOffsetField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ApiBaseOrderBaseOrderOrderLineFlexFieldDatesAttributeDate6
    {

        private string gLogDateField;

        private string tZIdField;

        private string tZOffsetField;

        /// <remarks/>
        public string GLogDate
        {
            get
            {
                return this.gLogDateField;
            }
            set
            {
                this.gLogDateField = value;
            }
        }

        /// <remarks/>
        public string TZId
        {
            get
            {
                return this.tZIdField;
            }
            set
            {
                this.tZIdField = value;
            }
        }

        /// <remarks/>
        public string TZOffset
        {
            get
            {
                return this.tZOffsetField;
            }
            set
            {
                this.tZOffsetField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ApiBaseOrderBaseOrderOrderLineFlexFieldDatesAttributeDate7
    {

        private string gLogDateField;

        private string tZIdField;

        private string tZOffsetField;

        /// <remarks/>
        public string GLogDate
        {
            get
            {
                return this.gLogDateField;
            }
            set
            {
                this.gLogDateField = value;
            }
        }

        /// <remarks/>
        public string TZId
        {
            get
            {
                return this.tZIdField;
            }
            set
            {
                this.tZIdField = value;
            }
        }

        /// <remarks/>
        public string TZOffset
        {
            get
            {
                return this.tZOffsetField;
            }
            set
            {
                this.tZOffsetField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ApiBaseOrderBaseOrderOrderLineFlexFieldDatesAttributeDate8
    {

        private string gLogDateField;

        private string tZIdField;

        private string tZOffsetField;

        /// <remarks/>
        public string GLogDate
        {
            get
            {
                return this.gLogDateField;
            }
            set
            {
                this.gLogDateField = value;
            }
        }

        /// <remarks/>
        public string TZId
        {
            get
            {
                return this.tZIdField;
            }
            set
            {
                this.tZIdField = value;
            }
        }

        /// <remarks/>
        public string TZOffset
        {
            get
            {
                return this.tZOffsetField;
            }
            set
            {
                this.tZOffsetField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ApiBaseOrderBaseOrderOrderLineFlexFieldDatesAttributeDate9
    {

        private string gLogDateField;

        private string tZIdField;

        private string tZOffsetField;

        /// <remarks/>
        public string GLogDate
        {
            get
            {
                return this.gLogDateField;
            }
            set
            {
                this.gLogDateField = value;
            }
        }

        /// <remarks/>
        public string TZId
        {
            get
            {
                return this.tZIdField;
            }
            set
            {
                this.tZIdField = value;
            }
        }

        /// <remarks/>
        public string TZOffset
        {
            get
            {
                return this.tZOffsetField;
            }
            set
            {
                this.tZOffsetField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ApiBaseOrderBaseOrderOrderLineFlexFieldDatesAttributeDate10
    {

        private string gLogDateField;

        private string tZIdField;

        private string tZOffsetField;

        /// <remarks/>
        public string GLogDate
        {
            get
            {
                return this.gLogDateField;
            }
            set
            {
                this.gLogDateField = value;
            }
        }

        /// <remarks/>
        public string TZId
        {
            get
            {
                return this.tZIdField;
            }
            set
            {
                this.tZIdField = value;
            }
        }

        /// <remarks/>
        public string TZOffset
        {
            get
            {
                return this.tZOffsetField;
            }
            set
            {
                this.tZOffsetField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ApiBaseOrderBaseOrderOrderLineShippingAndDeliveryDates
    {

        private object shipDateTimeEarlyField;

        private object shipDateTimeLateField;

        private object deliveryDateTimeEarlyField;

        private object deliveryDateTimeLateField;

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
    public partial class ApiBaseOrderBaseOrderOrderLineComment
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

}

