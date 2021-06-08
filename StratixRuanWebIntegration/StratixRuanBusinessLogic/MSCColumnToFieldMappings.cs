using l2s = StratixRuanDataLayer.Linq2SQL;

namespace StratixRuanBusinessLogic
{
    public class MSCColumnToFieldMappings : BusinessLogicBase<MSCColumnToFieldMappings, l2s.MSCColumnToFieldMappings>
    {
        private string _tableName;
        public string TableName
        {
            get
            {
                return _tableName;
            }
            set
            {
                SetField(ref _tableName, value);
            }
        }

        private int _position;
        public int Position
        {
            get
            {
                return _position;
            }
            set
            {
                SetField(ref _position, value);
            }
        }

        private string _columnName;
        public string ColumnName
        {
            get
            {
                return _columnName;
            }
            set
            {
                SetField(ref _columnName, value);
            }
        }

        private string _fieldName;
        public string FieldName
        {
            get
            {
                return _fieldName;
            }
            set
            {
                SetField(ref _fieldName, value);
            }
        }

        private string _type;
        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                SetField(ref _type, value);
            }
        }

        private string _nullable;
        public string Nullable
        {
            get
            {
                return _nullable;
            }
            set
            {
                SetField(ref _nullable, value);
            }
        }

        protected override void PopulateDataObject(l2s.MSCColumnToFieldMappings destination)
        {
            base.PopulateDataObject(destination);

            destination.TableName = TableName;
            destination.Position = Position;
            destination.ColumnName = ColumnName;
            destination.FieldName = FieldName;
            destination.Type = Type;
            destination.Nullable = Nullable;
        }

        internal override void PopulateBusinessObject(l2s.MSCColumnToFieldMappings source)
        {
            base.PopulateBusinessObject(source);

            _tableName = source.TableName;
            _position = source.Position;
            _columnName = source.ColumnName;
            _fieldName = source.FieldName;

            if (_fieldName != null)
            {
                _fieldName = _fieldName.Replace(" ", "");
                _fieldName = _fieldName.Replace("/", "");
                _fieldName = _fieldName.Replace("'s", "");
                _fieldName = _fieldName.Replace("-", "");
                _fieldName = _fieldName.Replace("&", "And");
            }

            _type = source.Type;
            _nullable = source.Nullable;
        }

        public static MSCColumnToFieldMappingsList FetchAllByTableName(string TableName)
        {
            MSCColumnToFieldMappingsList businessLogicItems = new MSCColumnToFieldMappingsList();
            l2s.MSCColumnToFieldMappings[] dataLayerItems = l2s.MSCColumnToFieldMappings.FetchAllByTableName(TableName);
            foreach (l2s.MSCColumnToFieldMappings dataLayerItem in dataLayerItems)
            {
                MSCColumnToFieldMappings businessLogicItem = new MSCColumnToFieldMappings();
                businessLogicItem.PopulateBusinessObject(dataLayerItem);
                businessLogicItems.Add(businessLogicItem);
            }
            return businessLogicItems;
        }

        public override string ToString()
        {
            string toString = string.Format("{0}=>{1}", FieldName, ColumnName);
            return toString;
        }
    }
}

