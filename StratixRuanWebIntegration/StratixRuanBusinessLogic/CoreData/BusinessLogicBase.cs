using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using StratixRuanBusinessLogic.Attributes;
using System.Linq;
using System.Runtime.InteropServices;
using StratixRuanDataLayer.Linq2SQL;
using StratixRuanInterfaces;

namespace StratixRuanBusinessLogic
{
    public abstract class BusinessLogicBase<BusinessLogicType, DataLayerType> : IBusinessLogicBase, INotifyPropertyChanged, IEditableObject
        where BusinessLogicType : BusinessLogicBase<BusinessLogicType, DataLayerType>, new()
        where DataLayerType : SharedAppsDataObject<DataLayerType>, new()
    {
        private static MSCColumnToFieldMappingsList _columnsToFields = null;
        private MSCColumnToFieldMappingsList GetMSCColumnToFieldMappingsList()
        {
                if(_columnsToFields == null)
                {
                    DataLayerType dataLayerType = new DataLayerType();
                    _columnsToFields = MSCColumnToFieldMappings.FetchAllByTableName(dataLayerType.GetType().Name);
                }

                return _columnsToFields;
        }
        public string FieldFromColumn(string column)
        {
            return GetMSCColumnToFieldMappingsList().GetFieldNameForColumn(column);
        }
        public string ColumnFromField(string field)
        {
            return GetMSCColumnToFieldMappingsList().GetColumnNameForField(field);
        }

        public virtual bool ValidateCode(string newCodeToValidate)
        {
            if (newCodeToValidate == null)
            {
                return false;
            }

            if(newCodeToValidate.Length > 10 || newCodeToValidate.Length < 1)
            {
                return false;
            }

            return true;
        }

        public string DatabaseTable
        {
            get
            {
                Type l2sqlType = typeof(DataLayerType);
                return l2sqlType.Name;
            }
        }

        private static Dictionary<string, BusinessLogicType> _codeCache = new Dictionary<string, BusinessLogicType>();

        private List<String> _changedProperties = null;
        protected List<String> ChangedProperties 
        {
            get
            {
                if (_changedProperties == null)
                {
                    _changedProperties = new List<string>();
                }

                return _changedProperties;
            }
        }
        public List<String> GetChangedProperties()
        {
            return ChangedProperties;
        }

        private bool _useValidation = true;
        [IgnoreForTest]
        public bool UseValidation
        {
            get { return _useValidation; }
            set { _useValidation = value; }
        }

        public virtual long Number
        {
            get
            {
                string propertyName = typeof(BusinessLogicType).Name + "Number";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                long number = -1;
                if (propertyInfo != null)
                {
                    number = Convert.ToInt64(propertyInfo.GetValue(this, null));
                }
                return number;
            }
            set
            {
                string propertyName = typeof(BusinessLogicType).Name + "Number";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(this, value, null);
                }
            }
        }

        [ViewAttribute(Index = 2)]
        public virtual string Code
        {
            get
            {
                string propertyName = typeof(BusinessLogicType).Name + "Code";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                string code = null;
                if (propertyInfo != null)
                {
                    code = propertyInfo.GetValue(this, null) as string;
                }
                return code;
            }
            set
            {
                string propertyName = typeof(BusinessLogicType).Name + "Code";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(this, value, null);
                }
            }
        }

        public virtual string Description
        {
            get
            {
                string propertyName = typeof(BusinessLogicType).Name + "Description";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                string description = null;
                if (propertyInfo != null)
                {
                    description = propertyInfo.GetValue(this, null) as string;
                }
                return description;
            }
            set
            {
                string propertyName = typeof(BusinessLogicType).Name + "Description";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(this, value, null);
                }
            }
        }

        private List<Tuple<string, string>> _requiredFieldList = new List<Tuple<string, string>>();
        [Browsable(false)]
        public virtual List<Tuple<string, string>> RequiredFieldList
        {
            get
            {
                return _requiredFieldList;
            }
            set
            {
                SetField(ref _requiredFieldList, value);
            }
        }

        /// <summary>
        /// Returns True if privateField was set
        /// <para>Returns false if privateField and value are equal.</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="privateField"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <returns>True if field was set</returns>
        protected bool SetField<T>(ref T privateField, T value, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(privateField, value))
            {
                return false;
            }

            privateField = value;
            NotifyPropertyChanged(propertyName);

            return true;
        }

        /// <summary>
        /// Returns True if privateField was set
        /// <para>Returns false if privateField and value are equal.</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="privateField"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <returns>True if field was set</returns>
        protected bool SetField<T>(ref T privateField, T value, T nullValue, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            if (value != null && value.Equals(nullValue))
            {
                value = default(T);
            }

            if (EqualityComparer<T>.Default.Equals(privateField, value))
            {
                return false;
            }

            privateField = value;
            NotifyPropertyChanged(propertyName);

            return true;
        }

        //do not expose
        protected DataLayerType FetchedObject = null;

        internal DataLayerType GetFetchedObject()
        {
            return FetchedObject;
        }

        internal void ClearFetchedObject()
        {
            FetchedObject = null;
        }

        /// <summary>
        /// Called by the framework on save
        /// </summary>
        /// <param name="destination"></param>
        protected virtual void PopulateDataObject(DataLayerType destination)
        {
            destination.CreatedOn = this.CreatedOn;
            destination.CreatedAt = this.CreatedAt;
            destination.CreatedBy = this.CreatedBy;
            destination.CreatedWS = this.CreatedStation;

            destination.LastChangedOn = this.ChangedOn;
            destination.LastChangedAt = this.ChangedAt;
            destination.LastChangedBy = this.ChangedBy;
            destination.LastChangedWS = this.ChangedStation;

            destination.PostedOn = this.PostedOn;
            destination.PostedAt = this.PostedAt;
            destination.PostedBy = this.PostedBy;
            destination.PostedWS = this.PostedStation;

            destination.DeletedOn = this.DeletedOn;
            destination.DeletedAt = this.DeletedAt;
            destination.DeletedBy = this.DeletedBy;
            destination.DeletedWS = this.DeletedStation;
        }
        internal virtual void PopulateBusinessObject(DataLayerType source)
        {
            FetchedObject = source;

            _createdOn = source.CreatedOn;
            _createdAt = source.CreatedAt;
            _createdBy = source.CreatedBy;
            _createdStation = source.CreatedWS;

            _changedOn = source.LastChangedOn;
            _changedAt = source.LastChangedAt;
            _changedBy = source.LastChangedBy;
            _changedStation = source.LastChangedWS;

            _postedOn = source.PostedOn;
            _postedAt = source.PostedAt;
            _postedBy = source.PostedBy;
            _postedStation = source.PostedWS;

            _deletedOn = source.DeletedOn;
            _deletedAt = source.DeletedAt;
            _deletedBy = source.DeletedBy;
            _deletedStation = source.DeletedWS;

            _hasChanged = false;
        }

        private DateTime? _postedOn;
        public DateTime? PostedOn
        {
            get
            {
                return _postedOn;
            }
            set
            {
                SetField(ref _postedOn, value);
            }
        }

        private DateTime? _postedAt;
        public DateTime? PostedAt
        {
            get
            {
                return _postedAt;
            }
            set
            {
                SetField(ref _postedAt, value);
            }
        }

        private long? _postedBy;
        public long? PostedBy
        {
            get
            {
                return _postedBy;
            }
            set
            {
                SetField(ref _postedBy, value);
            }
        }

        private long? _postedStation;
        public long? PostedStation
        {
            get
            {
                return _postedStation;
            }
            set
            {
                SetField(ref _postedStation, value);
            }
        }

        private DateTime? _createdOn;
        public DateTime? CreatedOn
        {
            get
            {
                return _createdOn;
            }
            set
            {
                SetField(ref _createdOn, value);
            }
        }

        private DateTime? _createdAt;
        public DateTime? CreatedAt
        {
            get
            {
                return _createdAt;
            }
            set
            {
                SetField(ref _createdAt, value);
            }
        }

        private long? _createdBy;
        public long? CreatedBy
        {
            get
            {
                return _createdBy;
            }
            set
            {
                SetField(ref _createdBy, value);
            }
        }

        private long? _createdStation;
        public long? CreatedStation
        {
            get
            {
                return _createdStation;
            }
            set
            {
                SetField(ref _createdStation, value);
            }
        }

        private DateTime? _changedOn;
        public DateTime? ChangedOn
        {
            get
            {
                return _changedOn;
            }
            set
            {
                SetField(ref _changedOn, value);
            }
        }

        private DateTime? _changedAt;
        public DateTime? ChangedAt
        {
            get
            {
                return _changedAt;
            }
            set
            {
                SetField(ref _changedAt, value);
            }
        }

        private long? _changedStation;
        public long? ChangedStation
        {
            get
            {
                return _changedStation;
            }
            set
            {
                SetField(ref _changedStation, value);
            }
        }

        private long? _changedBy;
        public long? ChangedBy
        {
            get
            {
                return _changedBy;
            }
            set
            {
                SetField(ref _changedBy, value);
            }
        }

        private DateTime? _deletedOn;
        public DateTime? DeletedOn
        {
            get
            {
                return _deletedOn;
            }
            set
            {
                SetField(ref _deletedOn, value);
            }
        }

        private DateTime? _deletedAt;
        public DateTime? DeletedAt
        {
            get
            {
                return _deletedAt;
            }
            set
            {
                SetField(ref _deletedAt, value);
            }
        }

        private long? _deletedStation;
        public long? DeletedStation
        {
            get
            {
                return _deletedStation;
            }
            set
            {
                SetField(ref _deletedStation, value);
            }
        }

        private long? _deletedBy;
        public long? DeletedBy
        {
            get
            {
                return _deletedBy;
            }
            set
            {
                SetField(ref _deletedBy, value);
            }
        }

        public bool IsDeleted
        {
            get
            {
                return DeletedOn == null ? false : true;
            }
        }

        public bool IsNew
        {
            get
            {
                return (Number == 0); //if the unique ID (number) is zero then the object has not been fetched or saved.
            }
        }

        protected IBusinessLogicBase _parent;

        public T GetParent<T>() where T : class, IBusinessLogicBase
        {
            return Parent as T;
        }

        public virtual IBusinessLogicBase Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
            }
        }

        public virtual void ClearAuditColumns()
        {
            CreatedOn = null;
            CreatedAt = null;
            CreatedBy = null;
            CreatedStation = null;

            ChangedOn = null;
            ChangedAt = null;
            ChangedBy = null;
            ChangedStation = null;
        }

        //MSM: until we have a better solution ive added the deleteChildren similar to how we have saveChildren
        /// <summary>
        /// Dont pass anything to this method or else! ?_?
        /// </summary>
        /// <param name="deleteChildren"></param>
        public virtual void Delete(bool deleteChildren = true)
        {
            if (deleteChildren)
            {
                foreach (PropertyInfo prop in this.GetType().GetProperties())
                {
                    //TODO: Compute the class name of the list
                    //string typeName = typeof(BusinessLogicList<BusinessLogicBase<).Name;
                    if (prop.PropertyType.IsGenericType && prop.PropertyType.Name.Contains("BusinessLogicList") || (prop.PropertyType.BaseType != null && prop.PropertyType.BaseType.IsGenericType && prop.PropertyType.BaseType.Name.Contains("BusinessLogicList")))
                    {
                        IEnumerable list = prop.GetValue(this, null) as IEnumerable;
                        if (list != null)
                        {
                            foreach (object item in list)
                            {
                                Type childType = item.GetType();
                                MethodInfo deleteMethod = childType.GetMethod("Delete");
                                deleteMethod.Invoke(item, new object[] { true });
                            }
                        }
                    }
                }
            }
            DataLayerType dest = new DataLayerType();
            PopulateDataObject(dest);
            dest.Delete(this is ITriggerless);
            PopulateBusinessObject(dest);
        }

        public virtual void DeletePermanently()
        {
            foreach (PropertyInfo prop in this.GetType().GetProperties())
            {
                //TODO: Compute the class name of the list
                //string typeName = typeof(BusinessLogicList<BusinessLogicBase<).Name;
                if (prop.PropertyType.IsGenericType && prop.PropertyType.Name.Contains("BusinessLogicList") || (prop.PropertyType.BaseType != null && prop.PropertyType.BaseType.IsGenericType && prop.PropertyType.BaseType.Name.Contains("BusinessLogicList")))
                {
                    IEnumerable list = prop.GetValue(this, null) as IEnumerable;
                    foreach (object item in list)
                    {
                        Type childType = item.GetType();
                        MethodInfo deleteMethod = childType.GetMethod("DeletePermanently");
                        deleteMethod.Invoke(item, null);
                    }
                }
            }

            DataLayerType dest = new DataLayerType();
            PopulateDataObject(dest);
            dest.DeletePermanently();
            PopulateBusinessObject(dest);
        }

        public virtual bool Undelete(bool cascadeToChildren)
        {
            bool success = false;

            if (cascadeToChildren)
            {
                PropertyInfo[] properties = this.GetType().GetProperties();
                foreach (PropertyInfo prop in properties)
                {
                    //TODO: Compute the class name of the list
                    if (prop.PropertyType.IsGenericType && prop.PropertyType.Name.Contains("BusinessLogicList") || (prop.PropertyType.BaseType != null && prop.PropertyType.BaseType.IsGenericType && prop.PropertyType.BaseType.Name.Contains("BusinessLogicList")))
                    {
                        IEnumerable list = prop.GetValue(this, null) as IEnumerable;
                        foreach (object item in list)
                        {
                            Type childType = item.GetType();
                            MethodInfo undeleteMethod = childType.GetMethod("Undelete");
                            undeleteMethod.Invoke(item, new object[1]{true});
                        }
                    }
                }
            }

            this.DeletedAt = null;
            this.DeletedOn = null;
            this.DeletedStation = 0;
            this.DeletedBy = 0;

            if (Save(false) != null)
            {
                success = true;
            }

            if (!cascadeToChildren)
            {
                IBusinessLogicBase parent = this.Parent;
                if (parent != null)
                {
                    success = parent.Undelete(false);
                }
            }

            return success;
        }

        public static BusinessLogicList<BusinessLogicType, DataLayerType> FetchAll()
        {
            return FetchAll<BusinessLogicList<BusinessLogicType, DataLayerType>>();
        }

        public bool IsColumnForeignKey(string columnName)
        {
            Type l2sqlType = typeof(DataLayerType);
            MethodInfo fetchMethod = l2sqlType.GetMethod("IsColumnForeignKey", BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            bool result = (bool)fetchMethod.Invoke(null, new object[] { this.DatabaseTable, columnName });

            return result;
        }

        public static W FetchAll<W>() where W : BusinessLogicList<BusinessLogicType, DataLayerType>, new() 
        {
            //fetch from datalayer
            Type l2sqlType = typeof(DataLayerType);
            // TODO: Programatically figure out the method name
            MethodInfo fetchMethod = l2sqlType.GetMethod("FetchAll", BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            DataLayerType[] results = fetchMethod.Invoke(null, null) as DataLayerType[];

            W items = new W();

            foreach (DataLayerType dataItem in results)
            {
                BusinessLogicType item = new BusinessLogicType();
                item.SuspendPropertyChangeNotifications();
                item.PopulateBusinessObject(dataItem);
                item.ResumePropertyChangeNotifications();
                items.Add(item);
            }

            return items;
        }

        public static BusinessLogicList<BusinessLogicType, DataLayerType> FetchLastHundred()
        {
            return FetchLastHundred<BusinessLogicList<BusinessLogicType, DataLayerType>>();
        }

        public static W FetchLastHundred<W>() where W : BusinessLogicList<BusinessLogicType, DataLayerType>, new()
        {
            //fetch from datalayer
            Type l2sqlType = typeof(DataLayerType);
            // TODO: Programatically figure out the method name
            MethodInfo fetchMethod = l2sqlType.GetMethod("FetchLastHundred", BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            DataLayerType[] results = fetchMethod.Invoke(null, null) as DataLayerType[];

            W items = new W();

            foreach (DataLayerType dataItem in results)
            {
                BusinessLogicType item = new BusinessLogicType();
                item.SuspendPropertyChangeNotifications();
                item.PopulateBusinessObject(dataItem);
                item.ResumePropertyChangeNotifications();
                items.Add(item);
            }

            return items;
        }

        public static BusinessLogicType FetchMostRecent()
        {
            //fetch from datalayer
            Type l2sqlType = typeof(DataLayerType);
            // TODO: Programatically figure out the method name
            MethodInfo fetchMethod = l2sqlType.GetMethod("FetchSingleMostRecent", BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            DataLayerType result = fetchMethod.Invoke(null, null) as DataLayerType;

            BusinessLogicType newobj = null;

            if (result != null)
            {
                newobj = new BusinessLogicType();
                newobj.SuspendPropertyChangeNotifications();
                newobj.PopulateBusinessObject(result);
                newobj.ResumePropertyChangeNotifications();
            }

            return newobj;
        }

        public static BusinessLogicType FetchByNumber(long? number)
        {
            if (number == null || number == 0)
            {
                return null;
            }

            //fetch from datalayer
            Type l2sqlType = typeof(DataLayerType);
            // TODO: Programatically figure out the method name
            MethodInfo fetchMethod = l2sqlType.GetMethod("FetchSingleByNumber", BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            DataLayerType result = fetchMethod.Invoke(null, new object[] { number }) as DataLayerType;

            BusinessLogicType newobj = null;

            if (result != null)
            {
                newobj = new BusinessLogicType();
                newobj.SuspendPropertyChangeNotifications();
                newobj.PopulateBusinessObject(result);
                newobj.ResumePropertyChangeNotifications();
            }

            return newobj;
        }

        public static BusinessLogicType FetchByNumberIncludeDeleted(long? number)
        {
            if (number == null || number == 0)
            {
                return null;
            }

            //fetch from datalayer
            Type l2sqlType = typeof(DataLayerType);
            // TODO: Programatically figure out the method name
            MethodInfo fetchMethod = l2sqlType.GetMethod("FetchSingleByNumberIncludeDeleted", BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            DataLayerType result = fetchMethod.Invoke(null, new object[] { number }) as DataLayerType;

            BusinessLogicType newobj = null;

            if (result != null)
            {
                newobj = new BusinessLogicType();
                newobj.SuspendPropertyChangeNotifications();
                newobj.PopulateBusinessObject(result);
                newobj.ResumePropertyChangeNotifications();
            }

            return newobj;
        }

        public static BusinessLogicType FetchByNumberAndConnection(long? Number, string Server, string Database)
        {
            if (Number == null || Number == 0 || string.IsNullOrEmpty(Server)|| string.IsNullOrEmpty(Database))
            {
                return null;
            }

            //fetch from datalayer
            Type l2sqlType = typeof(DataLayerType);
            // TODO: Programatically figure out the method name
            MethodInfo fetchMethod = l2sqlType.GetMethod("FetchSingleByNumberAndConnection", BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            DataLayerType result = fetchMethod.Invoke(null, new object[] { Number, Server , Database }) as DataLayerType;

            BusinessLogicType newobj = null;

            if (result != null)
            {
                newobj = new BusinessLogicType();
                newobj.SuspendPropertyChangeNotifications();
                newobj.PopulateBusinessObject(result);
                newobj.ResumePropertyChangeNotifications();
            }

            return newobj;
        }

        private List<ValidationException> _validationExceptions;

        public List<ValidationException> ValidationExceptions
        {
            get
            {
                if (_validationExceptions == null)
                {
                    _validationExceptions = new List<ValidationException>();
                }

                return _validationExceptions;
            }
        }

        public static Dictionary<string, ValidationAttributeBase> GetFieldValidationAttributes()
        {
            Dictionary<string, ValidationAttributeBase> fieldValidation = new Dictionary<string, ValidationAttributeBase>();

            BusinessLogicType temp = new BusinessLogicType();
            Type myType = temp.GetType();
            foreach (PropertyInfo prop in myType.GetProperties())
            {
                foreach (object Att in prop.GetCustomAttributes(typeof(ValidationAttributeBase), true))
                {
                    if (Att is ValidationAttributeBase)
                    {
                        fieldValidation.Add(prop.Name, (ValidationAttributeBase)Att);
                    }
                }
            }

            return fieldValidation;
        }

        public virtual bool IsValid()
        {
            ValidationExceptions.Clear();
            bool isValid = true;
            bool tempValid = true;
            Type myType = this.GetType();

            foreach (PropertyInfo prop in myType.GetProperties())
            {
                foreach (object Att in prop.GetCustomAttributes(typeof(ValidationAttributeBase), true))
                {
                    ValidationException validationException = null;
                    if (Att is VCustomValidation)
                    {
                        try
                        {
                            tempValid = CustomValidation(prop.GetValue(this, null), prop.Name);
                            if (!tempValid)
                            {
                                validationException = new FieldCustomValidationFailedException((Att as ValidationAttributeBase).ValidationFailedString(prop.Name), prop.Name, myType.Name);
                            }
                        }
                        catch(NotImplementedException)
                        {
                            tempValid = false;
                            validationException = new FieldCustomValidationMissingException((Att as ValidationAttributeBase).ValidationFailedString(prop.Name), prop.Name, myType.Name);
                        }
                    }
                    else if (Att is ValidateSelfBase)
                    {
                        tempValid = (Att as ValidateSelfBase).Validate(prop.GetValue(this, null), prop.Name, myType.Name, out validationException);
                    }
                    else if (Att is ValidationAttributeBase)
                    {
                        tempValid = (Att as ValidationAttributeBase).Validate(prop.Name, myType.Name, out validationException);
                    }

                    if (!tempValid)
                    {
                        isValid = false;
                        ValidationExceptions.Add(validationException);
                    }
                }
            }

            return isValid;
        }

        public virtual bool CustomValidation(object self, string name)
        {
            throw new NotImplementedException();
        }

        public virtual BusinessLogicType Save()
        {
            return Save(true, true);
        }

        public virtual BusinessLogicType Save(bool saveChildren = true, bool validateFields = true)
        {
            ////Save the header
            Debug.WriteLine("Saving: " + this.GetType().Name + " - " + this.ToString());
            AwesomeUtilities.AwesomeDebug.initElapsedTime();

            if (UseValidation)
            {
                //if (!newIsValid())
                //{
                //    throw new InvalidOperationException("Object is not valid");
                //}
                if (validateFields)
                {
                    if (!IsValid())
                    {
                        MSCInvalidOperationException ex = new MSCInvalidOperationException("Object is not valid", this.ValidationExceptions);
                        throw ex;
                    }
                }
            }
            _changedBy = GlobalState.UserNumber;
            _changedStation = GlobalState.WorkStationNumber;
            DateTime serverDateTime = DateTime.Now;
            //It looks like the linq to sql layer already sets the createdon... verify and remove
            if (IsNew)
            {
                _createdBy = GlobalState.UserNumber;
                _createdStation = GlobalState.WorkStationNumber;

                if(this is ITriggerless)
                {
                    _createdOn = serverDateTime;

                }
            }

            if(this is ITriggerless)
            {
                (this as ITriggerless).CustomTriggerLogic();
            }

            DataLayerType dest = new DataLayerType();
            PopulateDataObject(dest);

            try
            {
                AwesomeUtilities.AwesomeDebug.elapsedTime("Pre-DB Save");
                dest.Save(FetchedObject);
                AwesomeUtilities.AwesomeDebug.elapsedTime("Post-DB Save");
                PopulateBusinessObject(dest);
                AwesomeUtilities.AwesomeDebug.elapsedTime("Post-Populate");
            }
            catch (ItemChangedException<DataLayerType> ex)
            {
                AwesomeUtilities.AwesomeDebug.elapsedTime("Pre-DB Error");
                BusinessLogicType original = new BusinessLogicType();
                original.PopulateBusinessObject(ex.Original);
                BusinessObjectChangedException newException = new BusinessObjectChangedException($"Business object changed exception. Type: {original.GetType().Name}", original);
                AwesomeUtilities.AwesomeDebug.elapsedTime("Post-DB Error");
                throw newException;
            }
            
            this.Number = dest.Number;
            
            //TODO: Error!  On undelete, changes child, then saves child, works, then tries to undelete parent, which fails because child gets saved again? Maybe?
            if (saveChildren)
            {
                AwesomeUtilities.AwesomeDebug.elapsedTime("Pre-DB Save Children");
                foreach (PropertyInfo prop in this.GetType().GetProperties())
                {
                    //TODO: Compute the class name of the list
                    //string typeName = typeof(BusinessLogicList<BusinessLogicBase<).Name;
                    bool skip = prop.IsDefined(typeof(IgnoreForSave), true);
                    if (!skip)
                    {
                        if (prop.PropertyType.IsGenericType && prop.PropertyType.Name.Contains("BusinessLogicList") ||
                            (prop.PropertyType.BaseType != null && prop.PropertyType.BaseType.IsGenericType && prop.PropertyType.BaseType.Name.Contains("BusinessLogicList")))
                        {
                            IEnumerable list = prop.GetValue(this, null) as IEnumerable;
                            if (list != null)
                            {
                                foreach (object item in list)
                                {
                                    Type childType = item.GetType();

                                    MethodInfo updateIDMethod = childType.GetMethod("UpdateParentIdInChild", new Type[] { typeof(long), typeof(string) });
                                    updateIDMethod.Invoke(item, new object[] { this.Number, this.GetType().Name });

                                    MethodInfo saveMethod = childType.GetMethod("Save", new Type[] { });
                                    saveMethod.Invoke(item, null);
                                }
                            }
                        }
                    }
                }
                AwesomeUtilities.AwesomeDebug.elapsedTime("Post-DB Save Children");
            }

            ClearLazyLoadedLists();

            _hasChanged = false;
            ChangedProperties.Clear();
            //AwesomeUtilities.AwesomeDebug.elapsedTime("Pre-DB Fetch");
            //BusinessLogicType savedObject = FetchByNumberIncludeDeleted(this.Number);
            //AwesomeUtilities.AwesomeDebug.elapsedTime("Post-DB Fetch");
            BusinessLogicType savedObject = this as BusinessLogicType;
            return savedObject;
        }
        //object Att in prop.GetCustomAttributes(typeof(ValidationAttributeBase), true)
        internal void ClearLazyLoadedLists()
        {
            foreach (FieldInfo field in this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                foreach(object att in field.GetCustomAttributes(typeof(LazyLoaded), true))
                {
                    if(att is LazyLoaded)
                    {
                        field.SetValue(this, null);
                    }
                } 
            }
        }

        public static BusinessLogicType FetchByCode(string code)
        {
            DataLayerType dataItem = SharedAppsDataObject<DataLayerType>.FetchSingleByCode(code);

            BusinessLogicType businessItem = null;

            if (dataItem != null)
            {
                businessItem = new BusinessLogicType();
                businessItem.PopulateBusinessObject(dataItem);
            }

            return businessItem;
        }

        public static BusinessLogicType TESTING_FetchRandomSingle()
        {
            DataLayerType dataItem = SharedAppsDataObject<DataLayerType>.FetchRandomSingle();

            BusinessLogicType businessItem = null;

            if (dataItem != null)
            {
                businessItem = new BusinessLogicType();
                businessItem.PopulateBusinessObject(dataItem);
            }

            return businessItem;
        }

        public static long FetchNumberByCode(string code)
        {
            DataLayerType dataItem = SharedAppsDataObject<DataLayerType>.FetchSingleByCode(code);
            BusinessLogicType businessItem = new BusinessLogicType();
            businessItem.PopulateBusinessObject(dataItem);
            return businessItem.Number;
        }

        private static System.Threading.Semaphore sema = new System.Threading.Semaphore(1, 1);
        public static long? FetchNullableNumberByCode(string code)
        {
            long? result = null;

            if (code != null)
            {
                string dataKey = typeof(BusinessLogicType).Name + ":" + code;
                BusinessLogicType businessItem = null;
                bool inCache = _codeCache.ContainsKey(dataKey);

                if (inCache)
                {
                    businessItem = _codeCache[dataKey];
                }

                if (businessItem == null)
                {
                    DataLayerType dataItem = SharedAppsDataObject<DataLayerType>.FetchSingleByCode(code);
                    
                    if (dataItem != null)
                    {
                        businessItem = new BusinessLogicType();
                        businessItem.PopulateBusinessObject(dataItem);
                    }
                }

                if (businessItem != null)
                {
                    if (!inCache)
                    {
                        sema.WaitOne();
                        if (!(_codeCache.ContainsKey(dataKey)))
                        {
                            _codeCache.Add(dataKey, businessItem);
                        }
                        sema.Release();
                    }

                    result = businessItem.Number;
                }

                if(result == null)
                {
                    BusinessLogicType dummyItem = new BusinessLogicType();
                    throw new CodeLookupFailedException(dummyItem.GetType().Name);
                }
            }

            return result;
        }

        public static long FetchNumberByCodeIncludeDeleted(string code)
        {
            DataLayerType dataItem = SharedAppsDataObject<DataLayerType>.FetchSingleByCodeIncludeDeleted(code);
            BusinessLogicType businessItem = new BusinessLogicType();
            businessItem.PopulateBusinessObject(dataItem);
            return businessItem.Number;
        }

        public static long? FetchNullableNumberByCodeIncludeDeleted(string code)
        {
            long? result = null;

            if (code != null)
            {
                DataLayerType dataItem = SharedAppsDataObject<DataLayerType>.FetchSingleByCodeIncludeDeleted(code);
                if (dataItem != null)
                {
                    BusinessLogicType businessItem = new BusinessLogicType();
                    businessItem.PopulateBusinessObject(dataItem);
                    result = businessItem.Number;
                }
            }

            return result;
        }

 
       

        public string ToAwesomeScript()
        {
            StringBuilder script = new StringBuilder();
            string defaultTemplate = "item.{0} = {1};\r\n";
            string stringTemplate = "item.{0} = \"{1}\";\r\n";
            string dateTemplate = "item.{0} = DateTime.Parse(\"{1}\");\r\n";

            PropertyInfo[] properties = this.GetType().GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                bool include = prop.PropertyType.Name.Contains("BusinessLogicList") == false;

                if (include && prop.PropertyType.BaseType != null && prop.PropertyType.BaseType.Name.Contains("BusinessLogicList"))
                {
                    include = false;
                }

                //TODO: Compute the class name of the list
                if (include)
                {
                    object value;
                    try
                    {
                        value = prop.GetValue(this, null);
                    }
                    catch
                    {
                        value = null;
                    }
                    string selectedTemplate = defaultTemplate;

                    if (prop.PropertyType == typeof(string))
                    {
                        selectedTemplate = stringTemplate;
                    }
                    else if (prop.PropertyType == typeof(DateTime?))
                    {
                        if (value != null)
                        {
                            selectedTemplate = dateTemplate;
                        }
                        else
                        {
                            selectedTemplate = defaultTemplate;
                        }
                    }

                    string valueString;
                    if (value != null)
                    {
                        if (value.ToString() == "False")
                        {
                            valueString = "false";
                        }
                        else if (value.ToString() == "True")
                        {
                            valueString = "true";
                        }
                        else
                        {
                            valueString = value.ToString();
                        }
                    }
                    else
                    {
                        valueString = "null";
                    }

                    string propertyStatement = string.Format(selectedTemplate, prop.Name, valueString);
                    script.Append(propertyStatement);
                }
            }

            return script.ToString();
        }

        private bool _notifyPropertyChanges = true;
        public void SuspendPropertyChangeNotifications()
        {
            _notifyPropertyChanges = false;
        }
        public void ResumePropertyChangeNotifications()
        {
            _notifyPropertyChanges = true;
        }

        private bool _hasChanged = true;
        public bool HasChanged
        {
            set
            {
                SetField(ref _hasChanged, value);
                if (_hasChanged == false)
                {
                    ChangedProperties.Clear();
                }
            }
            get
            {
                return _hasChanged;
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string property)
        {
            if (_notifyPropertyChanges && ChangedProperties.Contains(property) == false)
            {
                if (property != nameof(HasChanged) || (property == nameof(HasChanged) && _hasChanged))
                {
                    ChangedProperties.Add(property);
                    HasChanged = true;
                }
            }
            if (PropertyChanged != null && _notifyPropertyChanges)
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs(property);
                PropertyChanged(this, args);
            }
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}:{2}", Number, Code, Description);
        }

        public virtual BusinessLogicType Clone()
        {
            BusinessLogicType blt = new BusinessLogicType();

            DataLayerType dlt = new DataLayerType();
            long oldNumber = dlt.Number;

            this.PopulateDataObject(dlt);
            dlt.Number = oldNumber;

            blt.PopulateBusinessObject(dlt);
            blt.FetchedObject = null;
            blt._hasChanged = true;
            return blt;
        }

        public virtual DataLayerType ToDataType()
        {
            DataLayerType dataObject = new DataLayerType();

            PopulateDataObject(dataObject);

            return dataObject;
        }

        

        public virtual void UpdateParentIdInChild(long parentId, string parentClassName)
        {
        }

       

       

        public static int NumRecordsToImport(ImportStatus importStatus)
        {
            int numRecords = 0;

            Type sqlType = typeof(DataLayerType);
            string importTypeName = string.Format("{0}_IMPORT", sqlType.Name);
            string importAssemblyQualifiedName = sqlType.AssemblyQualifiedName.Replace(sqlType.Name, importTypeName);
            Type importType = Type.GetType(importAssemblyQualifiedName);
            object o = Activator.CreateInstance(importType);
            Type intType = Type.GetType("System.Int32");
            MethodInfo numRecordsMI = importType.GetMethod("NumRecordsToImport", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy, null, new Type[] { intType }, null);

            int importStatusNumber = 0;
            if (importStatus == ImportStatus.SUCCESSFUL)
            {
                importStatusNumber = 1;
            }
            if (importStatus == ImportStatus.FAILED)
            {
                importStatusNumber = 2;
            }
            object[] parameters = new object[] { importStatusNumber };
            numRecords = (int)numRecordsMI.Invoke(null, parameters);

            return numRecords;
        }

     
        public static BusinessLogicType FetchNext(long currentNumber)
        {
            Type l2sqlType = typeof(DataLayerType);
            MethodInfo fetchMethod = l2sqlType.GetMethod("FetchNext", BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            DataLayerType result = fetchMethod.Invoke(null, new object[] { currentNumber }) as DataLayerType;

            BusinessLogicType newobj = null;

            if (result != null)
            {
                newobj = new BusinessLogicType();
                newobj.SuspendPropertyChangeNotifications();
                newobj.PopulateBusinessObject(result);
                newobj.ResumePropertyChangeNotifications();
            }

            return newobj;
        }

        public static BusinessLogicType FetchPrevious(long currentNumber)
        {
            Type l2sqlType = typeof(DataLayerType);
            MethodInfo fetchMethod = l2sqlType.GetMethod("FetchPrevious", BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            DataLayerType result = fetchMethod.Invoke(null, new object[] { currentNumber }) as DataLayerType;

            BusinessLogicType newobj = null;

            if (result != null)
            {
                newobj = new BusinessLogicType();
                newobj.SuspendPropertyChangeNotifications();
                newobj.PopulateBusinessObject(result);
                newobj.ResumePropertyChangeNotifications();
            }

            return newobj;
        }

        private bool inEdit;
        private DataLayerType backupCopy;

        public void BeginEdit()
        {
            Debug.WriteLine("BeginEdit");

            if (!inEdit)
            {
                inEdit = true;
                backupCopy = new DataLayerType();
                this.PopulateDataObject(backupCopy);
            }
        }

        public void CancelEdit()
        {
            Debug.WriteLine("CancelEdit");

            if (inEdit)
            {
                inEdit = false;
                this.PopulateBusinessObject(backupCopy);
                this.HasChanged = false;
            }
        }

        public void EndEdit()
        {
            Debug.WriteLine("EndEdit");

            if (inEdit)
            {
                inEdit = false;
                backupCopy = null;
            }
        }

      

        public static int DeleteByGUID(Guid guid)
        {
            Type l2sqlType = typeof(DataLayerType);
            MethodInfo deleteMethod = l2sqlType.GetMethod("DeleteByGUID", BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            int result = (int)deleteMethod.Invoke(null, new object[] { guid });

            return result;
        }
    }
}
