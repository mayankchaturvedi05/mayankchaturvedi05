using System;
using StratixRuanInterfaces;
using StratixRuanDataLayer.Linq2SQL;

namespace StratixRuanBusinessLogic
{
    public class RuanXml : BusinessLogicBase<RuanXml, TSRuanXML>, ITriggerless
    {
        private long _ruanXMLNumber;
        public long RuanXMLNumber
        {
            get => _ruanXMLNumber;
            set => SetField(ref _ruanXMLNumber, value);
        }

        private long _xmlTypeNumber;
        public long XMLTypeNumber
        {
            get => _xmlTypeNumber;
            set => SetField(ref _xmlTypeNumber, value);
        }

 
        private string _xml;
        public string XML
        {
            get => _xml;
            set => SetField(ref _xml, value);
        }

        protected override void PopulateDataObject(TSRuanXML destination)
        {
            base.PopulateDataObject(destination);

            destination.TSRNXNumber = RuanXMLNumber;
            destination.SMXMLNumber = XMLTypeNumber;
            destination.TSRNXXML = XML;
        }

        internal override void PopulateBusinessObject(TSRuanXML source)
        {
            base.PopulateBusinessObject(source);

            _ruanXMLNumber = source.TSRNXNumber;
            _xmlTypeNumber = source.SMXMLNumber;
            _xml = source.TSRNXXML;
        }

        public void CustomTriggerLogic()
        {
        }

        public RuanXml(){}

        public RuanXml(object xml)
        {
            XMLType xType = GlobalState.XMLTypes.XMLTypeByCode(xml.GetType().Name);
            if (xType == null)
            {
                throw new ArgumentException("XML Type does not exist in global state, check the codes");
            }
 
            XML = Utilities.SerializeObjectToString(xml);            
            XMLTypeNumber = xType.XMLTypeNumber;
        }
    }
}

