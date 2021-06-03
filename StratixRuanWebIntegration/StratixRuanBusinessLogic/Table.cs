using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StratixRuanDataLayer.Linq2SQL;

namespace StratixRuanBusinessLogic
{
    public class Table : BusinessLogicBase<Table, ADTABLE>
    {
        private long _tableNumber;
        public long TableNumber
        {
            get
            {
                return _tableNumber;
            }
            set
            {
                SetField(ref _tableNumber, value);
            }
        }

        private string _code;
        public override string Code
        {
            get
            {
                return _code;
            }
            set
            {
                SetField(ref _code, value);
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

        private bool _allowUDF;
        public bool AllowUDF
        {
            get
            {
                return _allowUDF;
            }
            set
            {
                SetField(ref _allowUDF, value);
            }
        }

        private bool _allowMemo;
        public bool AllowMemo
        {
            get
            {
                return _allowMemo;
            }
            set
            {
                SetField(ref _allowMemo, value);
            }
        }

        private bool _usesAuditTrail;
        public bool UsesAuditTrail
        {
            get
            {
                return _usesAuditTrail;
            }
            set
            {
                SetField(ref _usesAuditTrail, value);
            }
        }

        private string _displayType;
        public string DisplayType
        {
            get
            {
                return _displayType;
            }
            set
            {
                SetField(ref _displayType, value);
            }
        }

        private int? _comboPopupWidth;
        public int? ComboPopupWidth
        {
            get
            {
                return _comboPopupWidth;
            }
            set
            {
                SetField(ref _comboPopupWidth, value);
            }
        }

        private string _tablePrefix;
        public string TablePrefix
        {
            get
            {
                return _tablePrefix;
            }
            set
            {
                SetField(ref _tablePrefix, value);
            }
        }


        protected override void PopulateDataObject(ADTABLE destination)
        {
            base.PopulateDataObject(destination);

            destination.ADTBLNumber = TableNumber;
            destination.ADTBLCode = Code;
            destination.ADTBLDesc = Description;
            destination.ADTBLAllowUDF = AllowUDF;
            destination.ADTBLAllowMmo = AllowMemo;
            destination.ADTBLUsesAudit = UsesAuditTrail;
            destination.ADTBLDisplayType = DisplayType;
            destination.ADTBLEcbWidth = ComboPopupWidth;
            destination.ADTBLPrefix = TablePrefix;
        }

        internal override void PopulateBusinessObject(ADTABLE source)
        {
            base.PopulateBusinessObject(source);

            _tableNumber = source.ADTBLNumber;
            _code = source.ADTBLCode;
            _description = source.ADTBLDesc;
            _allowUDF = source.ADTBLAllowUDF;
            _allowMemo = source.ADTBLAllowMmo;
            _usesAuditTrail = source.ADTBLUsesAudit;
            _displayType = source.ADTBLDisplayType;
            _comboPopupWidth = source.ADTBLEcbWidth;
            _tablePrefix = source.ADTBLPrefix;
        }

        

        public static List<object> GetTableFromName(string name)
        {
            return ADTABLE.GetTableFromName(name);
        }
    }
}


