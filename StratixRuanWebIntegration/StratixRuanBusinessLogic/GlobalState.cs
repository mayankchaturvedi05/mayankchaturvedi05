using System;
using System.Collections.Generic;
using System.Linq;
using StratixRuanInterfaces;
using StratixRuanDataLayer.Linq2SQL;

namespace StratixRuanBusinessLogic
{
    public class GlobalState
    {

        private static string _connectionString;
        public static string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            set
            {
                _connectionString = value;
                StratixRuanDataLayer.Linq2SQL.SharedAppsDataContext.ConnectionString = value;
            }
        }

        private static long _userNumber;

        public static long UserNumber
        {
            get { return _userNumber; }
            set
            {
                _userNumber = value;
                StratixRuanDataLayer.Linq2SQL.SharedAppsDataContext.UserNumber = value;
            }
        }

        private static long _workStationNumber;

        public static long WorkStationNumber
        {
            get { return _workStationNumber; }
            set
            {
                _workStationNumber = value;
                StratixRuanDataLayer.Linq2SQL.SharedAppsDataContext.WorkstationNumber = value;
            }

        }

        private static XMLTypeList _xmlTypes;
        public static XMLTypeList XMLTypes
        {
            get
            {
                if (_xmlTypes == null)
                {
                    var genericXMLs = XMLType.FetchAll();
                    _xmlTypes = (XMLTypeList)genericXMLs.To(typeof(XMLTypeList));
                }

                return _xmlTypes;
            }
        }
    }

    public class XMLTypeList : BusinessLogicList<XMLType, SMCODEXMLTYPE>
    {

        public XMLType XMLTypeByCode(string code)
        {
            return this.SingleOrDefault(t => t.Code == code && t.DeletedOn == null);
        }
    }

    public class XMLType : BusinessLogicBase<XMLType, SMCODEXMLTYPE>, ITriggerless
    {
        private long _xMLTypeNumber;
        public long XMLTypeNumber
        {
            get
            {
                return _xMLTypeNumber;
            }
            set
            {
                SetField(ref _xMLTypeNumber, value);
            }
        }

        private string _xMLTypeCode;
        public string XMLTypeCode
        {
            get
            {
                return _xMLTypeCode;
            }
            set
            {
                SetField(ref _xMLTypeCode, value);
            }
        }

        private string _description;
        public override string Description
        {
            get
            {
                return _description;
            }
            set
            {
                SetField(ref _description, value);
            }
        }

        private string _headerSpecVersion;
        public string HeaderSpecVersion
        {
            get
            {
                return _headerSpecVersion;
            }
            set
            {
                SetField(ref _headerSpecVersion, value);
            }
        }

        protected override void PopulateDataObject(SMCODEXMLTYPE destination)
        {
            base.PopulateDataObject(destination);

            destination.SMXMLNumber = XMLTypeNumber;
            destination.SMXMLCode = XMLTypeCode;
            destination.SMXMLDescription = Description;
            destination.SMXMLHeaderSpecVersion = HeaderSpecVersion;
        }

        internal override void PopulateBusinessObject(SMCODEXMLTYPE source)
        {
            base.PopulateBusinessObject(source);

            _xMLTypeNumber = source.SMXMLNumber;
            _xMLTypeCode = source.SMXMLCode;
            _description = source.SMXMLDescription;
            _headerSpecVersion = source.SMXMLHeaderSpecVersion;
        }

        public void CustomTriggerLogic()
        {
        }
    }
}
