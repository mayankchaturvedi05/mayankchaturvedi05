using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;
using System.Data.SqlClient;
//using SharedApps.DataLayer.Exchange;
using System.Diagnostics;

using System.Collections;
//using MSC.AwesomeMessageBox;
using System.Data.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Transactions;
using StratixRuanInterfaces;

namespace StratixRuanDataLayer.Linq2SQL
{
    public abstract class SharedAppsDataObject<DerivedType>: IHaveNumberCodeDescription where DerivedType : SharedAppsDataObject<DerivedType>, new()
    {
        public virtual string GetFieldPrefix()
        {
            string className = typeof(DerivedType).Name;

            if (className.StartsWith("SMCODE"))
            {
                className = className.Replace("SMCODE", "SM");
            }

            int length = 5;
            if (className.Length < length)
            {
                length = className.Length;
            }

            return className.Substring(0, length);
        }

        private static string _fieldPrefix = null;

        public static string FieldPrefix
        {
            get
            {
                if (_fieldPrefix == null)
                {
                    DerivedType t = new DerivedType();
                    _fieldPrefix = t.GetFieldPrefix();
                }

                return _fieldPrefix;
            }
            set { _fieldPrefix = value; }
        }

        public virtual string GetTableName()
        {
            return typeof(DerivedType).Name;
        }

        //11/09/2017 DMB MSC-2612 Added tableName property.  Before each time in the class that the table name was required it got the table name from the Derived type.  This property was added so that the tableName can be set before the fucntions are called.
        //                        This was done to allow a generic form to be used for code maintenance.  The property begins with a lower case letter to avoid conflict with another variable that already uses the TableName         
        private static string _tableName = null;

        public static string tableName
        {
            get
            {
                if (_tableName == null)
                {
                    DerivedType t = new DerivedType();
                    _tableName = t.GetTableName();
                }

                return _tableName;
            }
            set { _tableName = value; }
        }

        public long Number
        {
            get
            {
                string propertyName = FieldPrefix + "Number";


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
                string propertyName = FieldPrefix + "Number";

              

                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(this, value, null);
                }
            }
        }
        
        public long? Division
        {
            get
            {
                string propertyName = "ADDIVNumber";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                long? division = null;
                if (propertyInfo != null)
                {
                    division = propertyInfo.GetValue(this, null) as long?;
                }
                return division;
            }
            set
            {
                string propertyName = "ADDIVNumber";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(this, value, null);
                }
            }
        }

        public string Code
        {
            get
            {
                string propertyName = FieldPrefix + "Code";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                string code = string.Empty;
                if (propertyInfo != null)
                {
                    code = "" + propertyInfo.GetValue(this, null);
                }
                return code;
            }
            set
            {
                string propertyName = FieldPrefix + "Code";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(this, value, null);
                }
            }
        }

        public string Description
        {
            get
            {
                string propertyName = FieldPrefix + "Desc";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                string desc = string.Empty;
                if (propertyInfo != null)
                {
                    desc = "" + propertyInfo.GetValue(this, null);
                }
                return desc;
            }
            set
            {
                string propertyName = FieldPrefix + "Desc";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(this, value, null);
                }
            }
        }

        //TODO: Test with null deletedby
        public long? CreatedBy
        {
            get
            {
                string propertyName = FieldPrefix + "CreatedBy";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                long? number = null;
                if (propertyInfo != null)
                {
                    object o = propertyInfo.GetValue(this, null);
                    number = o as long?;
                }
                return number;
            }
            set
            {
                string propertyName = FieldPrefix + "CreatedBy";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(this, value, null);
                }
            }
        }

        public long? CreatedWS
        {
            get
            {
                string propertyName = FieldPrefix + "CreatedWS";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                long? number = null;
                if (propertyInfo != null)
                {
                    object o = propertyInfo.GetValue(this, null);
                    number = o as long?;
                }
                return number;
            }
            set
            {
                string propertyName = FieldPrefix + "CreatedWS";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(this, value, null);
                }
            }
        }

        public DateTime? CreatedAt
        {
            get
            {
                string propertyName = FieldPrefix + "CreatedAt";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                DateTime? dateTime = null;
                if (propertyInfo != null)
                {
                    object o = propertyInfo.GetValue(this, null);
                    dateTime = o as DateTime?;
                }
                return dateTime;
            }
            set
            {
                string propertyName = FieldPrefix + "CreatedAt";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(this, value, null);
                }
            }
        }

        public DateTime? CreatedOn
        {
            get
            {
                string propertyName = FieldPrefix + "CreatedOn";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                DateTime? dateTime = null;
                if (propertyInfo != null)
                {
                    object o = propertyInfo.GetValue(this, null);
                    dateTime = o as DateTime?;
                }
                return dateTime;
            }
            set
            {
                string propertyName = FieldPrefix + "CreatedOn";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(this, value, null);
                }
            }
        }

        public long? LastChangedBy
        {
            get
            {
                string propertyName = FieldPrefix + "LastChgBy";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                long? number = null;
                if (propertyInfo != null)
                {
                    object o = propertyInfo.GetValue(this, null);
                    number = o as long?;
                }
                return number;
            }
            set
            {
                string propertyName = FieldPrefix + "LastChgBy";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(this, value, null);
                }
            }
        }

        public long? LastChangedWS
        {
            get
            {
                string propertyName = FieldPrefix + "LastChgWS";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                long? number = null;
                if (propertyInfo != null)
                {
                    object o = propertyInfo.GetValue(this, null);
                    number = o as long?;
                }
                return number;
            }
            set
            {
                string propertyName = FieldPrefix + "LastChgWS";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(this, value, null);
                }
            }
        }

        public DateTime? LastChangedAt
        {
            get
            {
                string propertyName = FieldPrefix + "LastChgAt";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                DateTime? dateTime = null;
                if (propertyInfo != null)
                {
                    object o = propertyInfo.GetValue(this, null);
                    dateTime = o as DateTime?;
                }
                return dateTime;
            }
            set
            {
                string propertyName = FieldPrefix + "LastChgAt";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(this, value, null);
                }
            }
        }

        public DateTime? LastChangedOn
        {
            get
            {
                string propertyName = FieldPrefix + "LastChgOn";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                DateTime? dateTime = null;
                if (propertyInfo != null)
                {
                    object o = propertyInfo.GetValue(this, null);
                    dateTime = o as DateTime?;
                }
                return dateTime;
            }
            set
            {
                string propertyName = FieldPrefix + "LastChgOn";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(this, value, null);
                }
            }
        }

        public long? PostedBy
        {
            get
            {
                string propertyName = FieldPrefix + "PostedBy";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                long? number = null;
                if (propertyInfo != null)
                {
                    object o = propertyInfo.GetValue(this, null);
                    number = o as long?;
                }
                return number;
            }
            set
            {
                string propertyName = FieldPrefix + "PostedBy";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(this, value, null);
                }
            }
        }

        public long? PostedWS
        {
            get
            {
                string propertyName = FieldPrefix + "PostedWS";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                long? number = null;
                if (propertyInfo != null)
                {
                    object o = propertyInfo.GetValue(this, null);
                    number = o as long?;
                }
                return number;
            }
            set
            {
                string propertyName = FieldPrefix + "PostedWS";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(this, value, null);
                }
            }
        }

        public DateTime? PostedAt
        {
            get
            {
                string propertyName = FieldPrefix + "PostedAt";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                DateTime? dateTime = null;
                if (propertyInfo != null)
                {
                    object o = propertyInfo.GetValue(this, null);
                    dateTime = o as DateTime?;
                }
                return dateTime;
            }
            set
            {
                string propertyName = FieldPrefix + "PostedAt";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(this, value, null);
                }
            }
        }

        public DateTime? PostedOn
        {
            get
            {
                string propertyName = FieldPrefix + "PostedOn";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                DateTime? dateTime = null;
                if (propertyInfo != null)
                {
                    object o = propertyInfo.GetValue(this, null);
                    dateTime = o as DateTime?;
                }
                return dateTime;
            }
            set
            {
                string propertyName = FieldPrefix + "PostedOn";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(this, value, null);
                }
            }
        }

        public long? DeletedBy
        {
            get
            {
                string propertyName = FieldPrefix + "DeletedBy";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                long? number = null;
                if (propertyInfo != null)
                {
                    object o = propertyInfo.GetValue(this, null);
                    number = o as long?;
                }
                return number;
            }
            set
            {
                string propertyName = FieldPrefix + "DeletedBy";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(this, value, null);
                }
            }
        }

        public long? DeletedWS
        {
            get
            {
                string propertyName = FieldPrefix + "DeletedWS";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                long? number = null;
                if (propertyInfo != null)
                {
                    object o = propertyInfo.GetValue(this, null);
                    number = o as long?;
                }
                return number;
            }
            set
            {
                string propertyName = FieldPrefix + "DeletedWS";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(this, value, null);
                }
            }
        }

        public DateTime? DeletedAt
        {
            get
            {
                string propertyName = FieldPrefix + "DeletedAt";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                DateTime? dateTime = null;
                if (propertyInfo != null)
                {
                    object o = propertyInfo.GetValue(this, null);
                    dateTime = o as DateTime?;
                }
                return dateTime;
            }
            set
            {
                string propertyName = FieldPrefix + "DeletedAt";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(this, value, null);
                }
            }
        }

        public DateTime? DeletedOn
        {
            get
            {
                string propertyName = FieldPrefix + "DeletedOn";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                DateTime? dateTime = null;
                if (propertyInfo != null)
                {
                    object o = propertyInfo.GetValue(this, null);
                    dateTime = o as DateTime?;
                }
                return dateTime;
            }
            set
            {
                string propertyName = FieldPrefix + "DeletedOn";
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(this, value, null);
                }
            }
        }
        public virtual bool Auditable
        {
            get { return true; }
        }
        protected virtual List<string> GetAuditFieldNames()
        {
            var auditFieldNames = new List<string>(
                new string[]
                {
                    FieldPrefix + "CreatedOn",
                    FieldPrefix + "CreatedAt",
                    FieldPrefix + "CreatedBy",
                    FieldPrefix + "CreatedWS",
                    FieldPrefix + "LastChgOn",
                    FieldPrefix + "LastChgAt",
                    FieldPrefix + "LastChgBy",
                    FieldPrefix + "LastChgWS",
                    FieldPrefix + "PostedOn",
                    FieldPrefix + "PostedAt",
                    FieldPrefix + "PostedBy",
                    FieldPrefix + "PostedWS"
                }
            );
            return auditFieldNames;
        }

        protected virtual List<string> GetReservedPropertyNames()
        {
            var reservedPropertyNames = new List<string>(
                new string[]
                {
                    FieldPrefix + "Number",
                    "Number",
                    "Division",
                    "Code",
                    "Description",
                    "DeletedBy",
                    "DeletedWS",
                    "IMPORT_ID"
                }
            );
            return reservedPropertyNames;
        }

        public class PropertyChangedInfo
        {
            public string PropertyName;
            public object SourceValue;
            public object DestValue;
        }

        public List<PropertyChangedInfo> CopyTo(DerivedType dest, bool forceUpdate = false)
        {
            List<PropertyChangedInfo> changes = new List<PropertyChangedInfo>();
            Type type = typeof(DerivedType);
            bool changed = false;

            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (!forceUpdate && prop.IsDefined(typeof(NonUpdatableAttribute), true))
                {
                    continue;
                }

                object valueSrc = prop.GetValue(this, null);
                object valueDst = prop.GetValue(dest, null);
                bool sameValue = false;

                if (prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(DateTime?))
                {
                    if (valueSrc == null && valueDst == null)
                    {
                        sameValue = true;
                    }
                    else if (valueSrc == null || valueDst == null)
                    {
                        sameValue = false;
                    }
                    else
                    {
                        DateTime dtSrc = (DateTime) valueSrc;
                        DateTime dtDst = (DateTime) valueDst;

                        sameValue = dtSrc.Equals(dtDst);
                    }
                }
                else
                {
                    string valueSrcString = (valueSrc != null) ? valueSrc.ToString() : "";
                    string valueDstString = (valueDst != null) ? valueDst.ToString() : "";

                    sameValue = (valueSrcString == valueDstString);
                }

                //if (!sameValue && !GetReservedPropertyNames().Contains(prop.Name) && !GetAuditFieldNames().Contains(prop.Name))
                if (!sameValue && !GetReservedPropertyNames().Contains(prop.Name))
                {
                    prop.SetValue(dest, valueSrc, null);
                    changed = true;
                    changes.Add(new PropertyChangedInfo() {PropertyName = prop.Name, DestValue = valueDst, SourceValue = valueSrc});
                }
            }

            if (changed)
            {
                //populate last changed on field
            }

            return changes;
        }

        public SharedAppsDataObject<DerivedType> Clone()
        {
            return MemberwiseClone() as SharedAppsDataObject<DerivedType>;
        }

        public static DerivedType[] FetchAll()
        {
            using (SharedAppsDataContext db = new SharedAppsDataContext())
            {
                Type type = typeof(DerivedType);

                DerivedType temp = new DerivedType();
                string theTableName = temp.GetTableName();
                temp = null;
                if (string.IsNullOrWhiteSpace(theTableName))
                {
                    theTableName = type.Name;
                }

                string SQL = "SELECT * FROM " + theTableName;

               
                {
                    SQL += " WHERE " + FieldPrefix + "DeletedOn IS NULL";

                    string propertyName = "ADDIVNumber";
                    PropertyInfo propertyInfo = type.GetProperty(propertyName);

                    if (propertyInfo != null && type.Name.ToUpper() != "ADDIVISION")
                    {
                        SQL += " AND ADDIVNumber = " + SharedAppsDataContext.DivisionNumber;
                    }
                }

                DerivedType[] result = db.ExecuteQuery<DerivedType>(SQL).ToArray();
                return result;
            }
        }

        public static DerivedType[] FetchAllForImport(string importbatchID)
        {
            using (SharedAppsDataContext db = new SharedAppsDataContext())
            {
                Type type = typeof(DerivedType);

                DerivedType temp = new DerivedType();
                string theTableName = temp.GetTableName();
                temp = null;

                if (string.IsNullOrWhiteSpace(theTableName))
                {
                    theTableName = type.Name;
                }

                string SQL = "SELECT * FROM " + theTableName + " WHERE (IMPORT_STATUS is null or IMPORT_STATUS = 0) AND IMPORT_BATCH_ID = " + importbatchID;

                DerivedType[] result = db.ExecuteQuery<DerivedType>(SQL).ToArray();
                return result;
            }
        }


        public static DerivedType[] FetchLastHundred()
        {
            using (SharedAppsDataContext db = new SharedAppsDataContext())
            {
                Type type = typeof(DerivedType);

                DerivedType temp = new DerivedType();
                string theTableName = temp.GetTableName();
                temp = null;
                if (string.IsNullOrWhiteSpace(theTableName))
                {
                    theTableName = type.Name;
                }

                string SQL = "SELECT TOP 100 * FROM " + theTableName;

                
                {
                    SQL += " WHERE " + FieldPrefix + "DeletedOn IS NULL";

                    string propertyName = "ADDIVNumber";
                    PropertyInfo propertyInfo = type.GetProperty(propertyName);

                    if (propertyInfo != null && type.Name.ToUpper() != "ADDIVISION")
                    {
                        SQL += " AND ADDIVNumber = " + SharedAppsDataContext.DivisionNumber;
                    }

                    SQL += " ORDER BY " + FieldPrefix + "CreatedOn DESC";
                }

                DerivedType[] result = db.ExecuteQuery<DerivedType>(SQL).ToArray();
                return result;
            }
        }

        public static DerivedType FetchSingleMostRecent()
        {
            using (SharedAppsDataContext db = new SharedAppsDataContext())
            {
                Type type = typeof(DerivedType);

                DerivedType temp = new DerivedType();
                string theTableName = temp.GetTableName();
                temp = null;
                if (string.IsNullOrWhiteSpace(theTableName))
                {
                    theTableName = type.Name;
                }

                string SQL = "SELECT TOP 1 * FROM " + theTableName;

                {
                    string deletedProperty = FieldPrefix + "DeletedOn";
                    if (type.GetProperty(deletedProperty) != null)
                    {
                        SQL += " WHERE " + deletedProperty + " IS NULL";
                    }

                    SQL += " ORDER BY " + FieldPrefix + "Number DESC";
                }

                DerivedType result = null;
                try
                {
                    result = db.ExecuteQuery<DerivedType>(SQL).FirstOrDefault();
                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("Invalid column name") && ex.Message.Contains("DeletedOn"))
                    {
                        string SQL2 = "SELECT TOP 1 * FROM " + theTableName + " ORDER BY " + FieldPrefix + "Number DESC";
                        result = db.ExecuteQuery<DerivedType>(SQL2).FirstOrDefault();
                    }
                    else
                    {
                        throw ex;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return result;
            }
        }

        public static DerivedType FetchSingleByNumber(long number)
        {
            using (SharedAppsDataContext db = new SharedAppsDataContext())
            {
                Type type = typeof(DerivedType);

                DerivedType temp = new DerivedType();
                string theTableName = temp.GetTableName();
                temp = null;
                if (string.IsNullOrWhiteSpace(theTableName))
                {
                    theTableName = type.Name;
                }

                string SQL = "SELECT * FROM " + theTableName;

               
                {
                    SQL += " WHERE " + FieldPrefix + "Number = {0}";

                    string deletedProperty = FieldPrefix + "DeletedOn";
                    if (type.GetProperty(deletedProperty) != null)
                    {
                        SQL += " AND " + deletedProperty + " IS NULL";
                    }
                }

                DerivedType result = null;
                try
                {
                    result = db.ExecuteQuery<DerivedType>(SQL, number).FirstOrDefault();
                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("Invalid column name") && ex.Message.Contains("DeletedOn"))
                    {
                        string SQL2 = "SELECT * FROM " + theTableName + " WHERE " + FieldPrefix + "Number = {0}";
                        result = db.ExecuteQuery<DerivedType>(SQL2, number).FirstOrDefault();
                    }
                    else
                    {
                        throw ex;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return result;
            }
        }

        public static DerivedType FetchSingleByNumberAndConnection(long number, string Server, string Database)
        {
            using (SharedAppsDataContext db = new SharedAppsDataContext())
            {
                Type type = typeof(DerivedType);
                string SQL = string.Format("SELECT * FROM [{0}].{1}.dbo.{2}", Server, Database, type.Name);

                
                {
                    SQL += " WHERE " + FieldPrefix + "Number = {0}";

                    string deletedProperty = FieldPrefix + "DeletedOn";
                    if (type.GetProperty(deletedProperty) != null)
                    {
                        SQL += " AND " + deletedProperty + " IS NULL";
                    }
                }

                DerivedType result = null;
                try
                {
                    result = db.ExecuteQuery<DerivedType>(SQL, number).FirstOrDefault();
                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("Invalid column name") && ex.Message.Contains("DeletedOn"))
                    {
                        string SQL2 = "SELECT * FROM " + type.Name + " WHERE " + FieldPrefix + "Number = {0}";
                        result = db.ExecuteQuery<DerivedType>(SQL2, number).FirstOrDefault();
                    }
                    else
                    {
                        throw ex;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return result;
            }
        }

        public static bool IsColumnForeignKey(string tableName, string columnName)
        {
            bool isKey = false;

            using (SharedAppsDataContext db = new SharedAppsDataContext())
            {
                string sql = @"
SELECT KCU1.CONSTRAINT_NAME AS 'ContraintName',
       KCU1.TABLE_NAME AS 'FKTableName',
       KCU1.COLUMN_NAME AS 'FKColumnName',
       KCU1.ORDINAL_POSITION AS 'FKOrdinalPosition',
       KCU2.CONSTRAINT_NAME AS 'UQConstraintName',
       KCU2.TABLE_NAME AS 'UQTableName',
       KCU2.COLUMN_NAME AS 'UQColumnName',
       KCU2.ORDINAL_POSITION AS 'UQOrdinalPosition'
 FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS RC
      JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE KCU1 ON KCU1.CONSTRAINT_CATALOG = RC.CONSTRAINT_CATALOG 
                                                   AND KCU1.CONSTRAINT_SCHEMA = RC.CONSTRAINT_SCHEMA
                                                   AND KCU1.CONSTRAINT_NAME = RC.CONSTRAINT_NAME
      JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE KCU2 ON KCU2.CONSTRAINT_CATALOG = RC.UNIQUE_CONSTRAINT_CATALOG 
                                                   AND KCU2.CONSTRAINT_SCHEMA = RC.UNIQUE_CONSTRAINT_SCHEMA
                                                   AND KCU2.CONSTRAINT_NAME = RC.UNIQUE_CONSTRAINT_NAME
                                                   AND KCU2.ORDINAL_POSITION = KCU1.ORDINAL_POSITION
 WHERE KCU1.TABLE_NAME = {0}
   AND KCU1.COLUMN_NAME = {1}
";
                var result = db.ExecuteQuery<ForeignKeyInfo>(sql, tableName, columnName);
                if (result.Count() > 0)
                {
                    isKey = true;
                }
            }

            return isKey;
        }

        public static DerivedType FetchSingleByNumberIncludeDeleted(long number)
        {
            using (SharedAppsDataContext db = new SharedAppsDataContext())
            {
                Type type = typeof(DerivedType);

                DerivedType temp = new DerivedType();
                string theTableName = temp.GetTableName();
                temp = null;
                if (string.IsNullOrWhiteSpace(theTableName))
                {
                    theTableName = type.Name;
                }

                 string SQL = "SELECT * FROM " + theTableName;

              
                {
                    SQL += " WHERE " + FieldPrefix + "Number = {0}";
                }

                DerivedType result = db.ExecuteQuery<DerivedType>(SQL, number).FirstOrDefault();
                return result;
            }
        }

        public static DerivedType FetchSingleByCode(string code)
        {
            if (code == null || code == "")
            {
                return null;
            }
           
            using (SharedAppsDataContext db = new SharedAppsDataContext())
            {
                Type type = typeof(DerivedType);

                DerivedType temp = new DerivedType();
                string theTableName = temp.GetTableName();
                temp = null;
                if (string.IsNullOrWhiteSpace(theTableName))
                {
                    theTableName = type.Name;
                }

                string SQL = "SELECT * FROM " + theTableName + " WHERE " + FieldPrefix + "Code = CONVERT(VARCHAR(100), {0}) AND " + FieldPrefix + "DeletedOn IS NULL";

                string propertyName = "ADDIVNumber";
                PropertyInfo propertyInfo = type.GetProperty(propertyName);

                if (propertyInfo != null && type.Name.ToUpper() != "ADDIVISION")
                {
                    SQL += " AND ADDIVNumber = " + SharedAppsDataContext.DivisionNumber;
                }

                DerivedType result = db.ExecuteQuery<DerivedType>(SQL, code).FirstOrDefault();
                return result;
            }
        }

        public static DerivedType FetchSingleByCodeIncludeDeleted(string code)
        {
            using (SharedAppsDataContext db = new SharedAppsDataContext())
            {
                Type type = typeof(DerivedType);

                DerivedType temp = new DerivedType();
                string theTableName = temp.GetTableName();
                temp = null;
                if (string.IsNullOrWhiteSpace(theTableName))
                {
                    theTableName = type.Name;
                }

                string SQL = "SELECT * FROM " + theTableName + " WHERE " + FieldPrefix + "Code = CONVERT(VARCHAR(100), {0})";
                DerivedType result = db.ExecuteQuery<DerivedType>(SQL, code).FirstOrDefault();
                return result;
            }
        }

        public static long FetchNumberByCode(string code)
        {
            using (SharedAppsDataContext db = new SharedAppsDataContext())
            {
                Type type = typeof(DerivedType);

                DerivedType temp = new DerivedType();
                string theTableName = temp.GetTableName();
                temp = null;
                if (string.IsNullOrWhiteSpace(theTableName))
                {
                    theTableName = type.Name;
                }

                string SQL = "SELECT " + FieldPrefix + "Number FROM " + theTableName + " WHERE " + FieldPrefix + "Code = CONVERT(VARCHAR(100), {0}) AND " + FieldPrefix + "DeletedOn IS NULL";
                try
                {
                    long result = db.ExecuteQuery<long>(SQL, code).FirstOrDefault();
                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Returns the Number for the previous object in the list using the current object's code. Returns 0 if no previous object.
        /// </summary>
        /// <returns>sdfad</returns>
        public static long? FetchPrevNumberUsingCode(string code)
        {
            using (SharedAppsDataContext db = new SharedAppsDataContext())
            {
                try
                {
                    long? result = null;
                    Type type = typeof(DerivedType);

                    DerivedType temp = new DerivedType();
                    string theTableName = temp.GetTableName();
                    temp = null;
                    if (string.IsNullOrWhiteSpace(theTableName))
                    {
                        theTableName = type.Name;
                    }

                    if (type.GetProperty(FieldPrefix + "Code") != null)
                    {
                        string SQL = "SELECT TOP 1 " + FieldPrefix + "Number FROM " + theTableName
                                     + " WHERE " + FieldPrefix + "Code < CONVERT(VARCHAR(100), {0}) AND " + FieldPrefix
                                     + "DeletedOn IS NULL ORDER BY " + FieldPrefix + "Code DESC";
                        result = db.ExecuteQuery<long>(SQL, code).FirstOrDefault();
                    }
                    else
                    {
                        throw new Exception("Invalid property exception: " + FieldPrefix + "Code is not a property of " + theTableName + ". To fetch by code, the object type must have a code field.");
                    }

                    return result == 0 ? null : result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        /// <summary>
        /// Returns the Number for the next object in the list using the current object's code. Returns 0 if no next object.
        /// </summary>
        /// <returns></returns>
        public static long? FetchNextNumberUsingCode(string code)
        {
            using (SharedAppsDataContext db = new SharedAppsDataContext())
            {
                try
                {
                    long? result = null;
                    Type type = typeof(DerivedType);

                    DerivedType temp = new DerivedType();
                    string theTableName = temp.GetTableName();
                    temp = null;
                    if (string.IsNullOrWhiteSpace(theTableName))
                    {
                        theTableName = type.Name;
                    }

                    if (type.GetProperty(FieldPrefix + "Code") != null)
                    {
                        string SQL = "SELECT TOP 1 " + FieldPrefix + "Number FROM " + theTableName
                                     + " WHERE " + FieldPrefix + "Code > CONVERT(VARCHAR(100), {0}) AND " + FieldPrefix
                                     + "DeletedOn IS NULL ORDER BY " + FieldPrefix + "Code ASC";
                        result = db.ExecuteQuery<long>(SQL, code).FirstOrDefault();
                    }
                    else
                    {
                        throw new Exception("Invalid property exception: " + FieldPrefix + "Code is not a property of " + theTableName + ". To fetch by code, the object type must have a code field.");
                    }
                    return result == 0 ? null : result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static long FetchNumberByCodeIncludeDeleted(string code)
        {
            using (SharedAppsDataContext db = new SharedAppsDataContext())
            {
                Type type = typeof(DerivedType);


                DerivedType temp = new DerivedType();
                string theTableName = temp.GetTableName();
                temp = null;
                if (string.IsNullOrWhiteSpace(theTableName))
                {
                    theTableName = type.Name;
                }

                string SQL = "SELECT " + FieldPrefix + "Number FROM " + theTableName + " WHERE " + FieldPrefix + "Code = CONVERT(VARCHAR(100), {0})";
                long result = db.ExecuteQuery<long>(SQL, code).FirstOrDefault();
                return result;
            }
        }

        public static int NumRecordsToImport(int importStatus)
        {
            int result = 0;

            using (SharedAppsDataContext db = new SharedAppsDataContext())
            {
                Type type = typeof(DerivedType);


                DerivedType temp = new DerivedType();
                string theTableName = temp.GetTableName();
                temp = null;
                if (string.IsNullOrWhiteSpace(theTableName))
                {
                    theTableName = type.Name;
                }

                string SQL = @"
                SELECT COUNT(*)
                  FROM " + theTableName;

                if (importStatus > 0)
                {
                    SQL = SQL + @"
                 WHERE IMPORT_STATUS = {0}";
                }
                else
                {
                    SQL = SQL + @"
                 WHERE IMPORT_STATUS IS NULL
                    OR IMPORT_STATUS = {0}";
                }

                try
                {
                    result = db.ExecuteQuery<int>(SQL, importStatus).SingleOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return result;
            }
        }

        public virtual void Save()
        {
            Save(null);
        }

        public static DataItemList<DerivedType> BulkSave(DataItemList<DerivedType> dataItems)
        {
            Type type = typeof(DerivedType);
            DerivedType temp = new DerivedType();
            string theTableName = temp.GetTableName();
            temp = null;
            if (string.IsNullOrWhiteSpace(theTableName))
            {
                theTableName = type.Name;
            }

            List<Tuple<DerivedType, List<PropertyChangedInfo>>> fullChanges = new List<Tuple<DerivedType, List<PropertyChangedInfo>>>();

            foreach (DataItem<DerivedType> dataItem in dataItems)
            {
                DerivedType item = dataItem.Current;

                if ((item.Division == null || item.Division == 0))
                {
                    item.Division = SharedAppsDataContext.DivisionNumber;
                }

                if (dataItem.Original == null)
                {
                    string SQL = "SELECT * FROM " + theTableName;

                   
                    {
                        SQL += " WHERE " + FieldPrefix + "Number = {0}";
                    }

                    try
                    {
                        if (item.Number > 0)
                        {
                            TransactionOptions transactionOptions = new TransactionOptions();
                            transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
                            using (new TransactionScope(TransactionScopeOption.RequiresNew, transactionOptions))
                            {
                                using (SharedAppsDataContext db = new SharedAppsDataContext())
                                {
                                    dataItem.Original = db.ExecuteQuery<DerivedType>(SQL, item.Number).FirstOrDefault();
                                }
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            using (SharedAppsDataContext db = new SharedAppsDataContext())
            {
                foreach (DataItem<DerivedType> dataItem in dataItems)
                {
                    DerivedType item = dataItem.Current;
                    DerivedType original = null;
                    bool inserting = false;
                    List<PropertyChangedInfo> changes = null;

                    if (dataItem.Original != null)
                    {
                        original = dataItem.Original;
                        db.GetTable(type).Attach(original);
                    }

                    if (original == null)
                    {
                        original = new DerivedType();
                        db.GetTable(type).InsertOnSubmit(original);
                        inserting = true;
                    }
                    else
                    {
                        if (!original.LastChangedOn.Equals(item.LastChangedOn))
                        {
                            throw new ItemChangedException<DerivedType>(original);
                        }
                    }

                    changes = item.CopyTo(original);

                    if (!inserting && item.Auditable && changes.Count > 0)
                    {
                        fullChanges.Add(new Tuple<DerivedType, List<PropertyChangedInfo>>(item, changes));
                    }

                    if (changes != null && changes.Count > 0)
                    {
                        DateTime now = DateTime.Now;
              
                        long? userNumber = SharedAppsDataContext.UserNumber;
                        long? workstationNumber = SharedAppsDataContext.WorkstationNumber;

                        original.LastChangedBy = userNumber;
                        original.LastChangedWS = workstationNumber;
                        original.LastChangedAt = now;
                        original.LastChangedOn = now;

                        if (inserting)
                        {
                            original.CreatedBy = userNumber;
                            original.CreatedWS = workstationNumber;
                            original.CreatedAt = now;
                            original.CreatedOn = now;
                        }
                    }

                    dataItem.Result = original;
                }

                try
                {
                    db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                }
                catch (System.InvalidOperationException ex)
                {
                    if (ex.Message == "The null value cannot be assigned to a member with type System.Int64 which is a non-nullable value type.")
                    {
                        Debug.WriteLine("The problem is the insert trigger");
                    }

                    throw ex;
                }
                catch (ChangeConflictException)
                {
                    throw new ItemChangedException<DerivedType>(dataItems.FirstOrDefault()?.Original);
                }
            }

            //refetching item is necessary because of triggers on tables and trigger cannot be removed until old bo's are gone or their 
            //insert update delete stored procedures are removed
            String numbers = String.Join(", ", dataItems.Select(t => t.Result).Select(t => t.Number));
            List<DerivedType> fetchedDerivedTypes = FetchAllByNumbers(numbers);

            foreach (DataItem<DerivedType> dataItem in dataItems)
            {
                dataItem.Result = fetchedDerivedTypes.FirstOrDefault(t => t.Number == dataItem.Result.Number);
            }

            if (fullChanges.Count > 0)
            {
                DateTime time = DateTime.Now;

                long tableNumber;
                try
                {
                    ADTABLE table = SharedAppsDataContext.TableCache.FirstOrDefault(i => i.ADTBLCode == theTableName);
                    if (table != null)
                    {
                        tableNumber = (long)table.Number;
                    }
                    else
                    {
                        throw new Exception($"Table {theTableName} not found.");
                    }
                }
                catch
                {
                    throw;
                    //did not use awesome message box here because it is in the business logic
                    //AwesomeMessageBox.Show("Unable to save Audit Trail", "Audit Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Get call stack
                StackTrace stackTrace = new StackTrace();
                string formName = "";
                string stackData = "";
                for (int i = stackTrace.FrameCount - 1; i > 0; i--)
                {
                    StackFrame tempFrame = stackTrace.GetFrame(i);
                    string tempFormName = "";
                    if (tempFrame != null)
                    {
                        MethodBase tempMethod = tempFrame.GetMethod();
                        if (tempMethod != null)
                        {
                            Type tempType = tempMethod.DeclaringType;
                            if (tempType != null)
                            {
                                tempFormName = tempType.Name;
                            }
                            stackData = tempFormName + "|" + stackData;
                        }
                    }
                    if (string.Equals(tempFormName.Substring(0, 3), "frm"))
                    {
                        formName = tempFormName;
                    }

                    if (string.IsNullOrWhiteSpace(formName) && !string.IsNullOrWhiteSpace(stackData))
                    {
                        formName = stackData;
                        if (stackData.Length > 50)
                        {
                            formName = stackData.Substring(0, 50);
                        }
                    }
                }

               }

            return dataItems;
        }

        private static List<DerivedType> FetchAllByNumbers(string numbers)
        {
            List<DerivedType> result = new List<DerivedType>();
            using (SharedAppsDataContext db = new SharedAppsDataContext())
            {
                Type type = typeof(DerivedType);

                DerivedType temp = new DerivedType();
                string theTableName = temp.GetTableName();
                temp = null;
                if (string.IsNullOrWhiteSpace(theTableName))
                {
                    theTableName = type.Name;
                }

                string SQL = "SELECT * FROM " + theTableName;

                SQL += " WHERE " + FieldPrefix + "DeletedOn IS NULL AND " + FieldPrefix + "Number in (" + numbers +")" ;

                string propertyName = "ADDIVNumber";
                PropertyInfo propertyInfo = type.GetProperty(propertyName);

                if (propertyInfo != null && type.Name.ToUpper() != "ADDIVISION")
                {
                    SQL += " AND ADDIVNumber = " + SharedAppsDataContext.DivisionNumber;
                }

                result = db.ExecuteQuery<DerivedType>(SQL).ToList();
            }

            return result;
        }

        public virtual void Save(DerivedType Fetchedobject = null)
        {
            DerivedType original = new DerivedType(); // set to an instance to use for table name (used to be null)
            List<PropertyChangedInfo> changes = null;
            Type type = typeof(DerivedType);

            string theTableName = original.GetTableName();
            original = null; // now that we have table name, set back to null as later logic relies on it being null at this point.

            if (string.IsNullOrWhiteSpace(theTableName))
            {
                theTableName = type.Name;
            }

             if ((this.Division == null || this.Division == 0) )
            {
                this.Division = SharedAppsDataContext.DivisionNumber;
            }

            bool inserting = false;

            if (Fetchedobject == null)
            {
                string SQL = "SELECT * FROM " + theTableName;

                {
                    SQL += " WHERE " + FieldPrefix + "Number = {0}";
                }

                try
                {
                    if (this.Number > 0)
                    {
                        TransactionOptions transactionOptions = new TransactionOptions();
                        transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
                        using (new TransactionScope(TransactionScopeOption.RequiresNew, transactionOptions))
                        {
                            using (SharedAppsDataContext db = new SharedAppsDataContext())
                            {
                                original = db.ExecuteQuery<DerivedType>(SQL, this.Number).FirstOrDefault();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                original = Fetchedobject;
            }


            using (SharedAppsDataContext db = new SharedAppsDataContext())
            {
                if (original != null)
                {
                    db.GetTable(type).Attach(original);
                }

                if (original == null)
                {
                    original = new DerivedType();
                    db.GetTable(type).InsertOnSubmit(original);
                    inserting = true;
                }
                else
                {
                    if (!original.LastChangedOn.Equals(this.LastChangedOn))
                    {
                        throw new ItemChangedException<DerivedType>(original);
                    }
                }

                changes = this.CopyTo(original);

                if (changes != null && changes.Count > 0)
                {
                    DateTime now = DateTime.Now;
                    long? userNumber = SharedAppsDataContext.UserNumber;
                    long? workstationNumber = SharedAppsDataContext.WorkstationNumber;

                    original.LastChangedBy = userNumber;
                    original.LastChangedWS = workstationNumber;
                    original.LastChangedAt = now;
                    original.LastChangedOn = now;

                    if (inserting)
                    {
                        original.CreatedBy = userNumber;
                        original.CreatedWS = workstationNumber;
                        original.CreatedAt = now;
                        original.CreatedOn = now;
                    }
                }
                
                try
                {
                    db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                }
                catch (System.InvalidOperationException ex)
                {
                    if (ex.Message == "The null value cannot be assigned to a member with type System.Int64 which is a non-nullable value type.")
                    {
                        Debug.WriteLine("The problem is the insert trigger");
                    }

                    throw ex;
                }
                catch (ChangeConflictException)
                {
                    throw new ItemChangedException<DerivedType>(original);
                }
                catch (Exception e)
                {
                    var test = e;
                    throw;
                }
            }

            if (changes != null && changes.Count > 0 && Auditable && !inserting)
            {
                DateTime time = DateTime.Now;

                long tableNumber = 0;
                try
                {
                    ADTABLE table = SharedAppsDataContext.TableCache.FirstOrDefault(i => i.ADTBLCode == theTableName);
                    if (table != null)
                    {
                        tableNumber = (long)table.Number;
                    }
                    else
                    {
                        throw new Exception($"Table {theTableName} not found.");
                    }
                }
                catch (Exception exc)
                {
                    //did not use awesome message box here because it is in the business logic
                    
                }


                // Get call stack
                StackTrace stackTrace = new StackTrace();
                string formName = "";
                for (int i = stackTrace.FrameCount - 1; i > 0; i--)
                {
                    string tempFormName = "";
                    StackFrame tempFrame = stackTrace.GetFrame(i);
                    if (tempFrame != null)
                    {
                        MethodBase tempMethod = tempFrame.GetMethod();
                        if (tempMethod != null)
                        {
                            Type tempType = tempMethod.DeclaringType;
                            if (tempType != null)
                            {
                                tempFormName = tempType.Name;
                            }
                        }
                    }
                    if (tempFormName.ToLower().StartsWith("frm"))
                    {
                        formName = tempFormName;
                    }
                }

                int errorCount = 0;
               
            }
            if (original != null && this.Number != original.Number)
            {
                this.Number = original.Number;
            }

            DerivedType savedObject = FetchSingleByNumberIncludeDeleted(this.Number);
            if (savedObject != null)
            {
                savedObject.CopyTo(this as DerivedType, true);
            }
        }

        protected void Insert()
        {
            Type type = typeof(DerivedType);

            if ((this.Division == null || this.Division == 0))
            {
                this.Division = SharedAppsDataContext.DivisionNumber;
            }

            using (SharedAppsDataContext db = new SharedAppsDataContext())
            {
                db.GetTable(type).InsertOnSubmit(this);

                DateTime now = DateTime.Now;
                long? userNumber = SharedAppsDataContext.UserNumber;
                long? workstationNumber = SharedAppsDataContext.WorkstationNumber;

                this.LastChangedBy = userNumber;
                this.LastChangedWS = workstationNumber;
                this.LastChangedAt = now;
                this.LastChangedOn = now;
                this.CreatedBy = userNumber;
                this.CreatedWS = workstationNumber;
                this.CreatedAt = now;
                this.CreatedOn = now;
                try
                {
                    db.SubmitChanges();
                }
                catch (System.InvalidOperationException ex)
                {
                    if (ex.Message == "The null value cannot be assigned to a member with type System.Int64 which is a non-nullable value type.")
                    {
                        Debug.WriteLine("The problem is the insert trigger");
                    }

                    throw ex;
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                    throw;
                }
            }
        }

        public virtual int Delete(bool isTriggerless = false)
        {
            int deletedCount = 0;
            if (Number != 0)
            {
                using (SharedAppsDataContext db = new SharedAppsDataContext())
                {
                    if (!this.DeletedOn.HasValue || !this.DeletedAt.HasValue)
                    {
                        Type type = typeof(DerivedType);
                        DateTime now = DateTime.Now;
                        db.GetTable(type).Attach(this);

                        this.DeletedBy = SharedAppsDataContext.UserNumber;
                        this.DeletedWS = SharedAppsDataContext.WorkstationNumber;
                        this.DeletedOn = now;
                        this.DeletedAt = now;
                        this.LastChangedBy = SharedAppsDataContext.UserNumber;
                        this.LastChangedWS = SharedAppsDataContext.WorkstationNumber;
                        this.LastChangedOn = now;
                        this.LastChangedAt = now;

                        try
                        {
                            //should probably call .save here instead so we audit and arent mainting 2 submits
                            //if is replaced by the save remove the last changed on code above since the save sets those fields
                            db.SubmitChanges(ConflictMode.FailOnFirstConflict);
                        }
                        catch (ChangeConflictException)
                        {
                            throw new ItemChangedException<DerivedType>(this as DerivedType);
                        }
                    }
                }
            }

            return deletedCount;
        }

        public virtual int DeletePermanently()
        {
            int deletedCount = 0;
            if (Number != 0)
            {
                using (SharedAppsDataContext db = new SharedAppsDataContext())
                {
                    Type type = typeof(DerivedType);
                    DerivedType temp = new DerivedType();
                    string theTableName = temp.GetTableName();
                    temp = null;
                    if (string.IsNullOrWhiteSpace(theTableName))
                    {
                        theTableName = type.Name;
                    }

                    if (DeletedBy == null && DeletedWS == null)
                    {
                        DeletedBy = SharedAppsDataContext.UserNumber;
                        DeletedWS = SharedAppsDataContext.WorkstationNumber;

                        Save();
                    }
                    string SQL = "DELETE FROM " + theTableName + " WHERE " + FieldPrefix + "Number = {0}";
                    deletedCount = db.ExecuteCommand(SQL, this.Number);

                    // When permanently deleting, most tables have a trigger to just update a deleted flag.  A second
                    // delete will actually remove the record.  The second delete here is in a try catch
                    // to account for situations where this trigger is not there.
                    try
                    {
                        deletedCount = db.ExecuteCommand(SQL, this.Number);
                    }
                    catch
                    {
                    }
                }
            }

            return deletedCount;
        }

        public static DataTable ConvertToDataTable(IEnumerable<DerivedType> entities)
        {
            entities = entities.ToArray();

            var table = new DataTable();
            Type t = typeof(DerivedType);
            //Get Schema
            var adapter = new SqlDataAdapter("SELECT * FROM " + t.Name, SharedAppsDataContext.ConnectionString);
            adapter.FillSchema(table, SchemaType.Source);

            foreach (var entity in entities)
            {
                DataRow row = table.NewRow();

                foreach (DataColumn column in table.Columns)
                {
                    if (column.AutoIncrement == false)
                    {
                        // Populate values
                        PropertyInfo property = t.GetProperty(column.ColumnName);
                        row[column] = GetPropertyValue(property.GetValue(entity, null));
                    }
                }

                table.Rows.Add(row);
            }

            return table;
        }

        private static bool EventTypeFilter(System.Reflection.PropertyInfo p)
        {
            var attribute = Attribute.GetCustomAttribute(p,
                typeof(AssociationAttribute)) as AssociationAttribute;

            if (!Attribute.IsDefined(p, typeof(ColumnAttribute))) return false;

            if (attribute == null) return true;
            if (attribute.IsForeignKey == false) return true;

            return false;
        }

        private static object GetPropertyValue(object o)
        {
            if (o == null)
                return DBNull.Value;
            return o;
        }

      

        
       

        public RollbackChange UpdateFieldValueByColumnName(string columnName, string newValue, string oldValue)
        {
            Type objectType = GetType();
            PropertyInfo property = objectType.GetProperty(columnName, BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance);
            Type propertyType = property.PropertyType;

            if (propertyType.Name == "String")
            {
                property.SetValue(this, newValue, null);
            }
            else
            {
                Type convertType;

                if (propertyType.Name.StartsWith("Nullable"))
                {
                    convertType = Nullable.GetUnderlyingType(propertyType);
                }
                else
                {
                    convertType = propertyType;
                }

                if (newValue == null)
                {
                    property.SetValue(this, null, null);
                }
                else
                {
                    string dummyArg = "";
                    MethodInfo parseMethod = convertType.GetMethod("Parse", new Type[] { dummyArg.GetType() });
                    var v = parseMethod.Invoke(null, new object[] { newValue });

                    if (newValue == "0")
                    {
                        bool isKey = IsColumnForeignKey(this.GetType().Name, columnName);
                        if (isKey)
                        {
                            v = null;
                        }
                    }

                    property.SetValue(this, v, null);
                }
            }

            RollbackChange change = new RollbackChange(columnName, newValue, oldValue);
            return change;
        }


        public static DerivedType FetchRandomSingle()
        {
            using (SharedAppsDataContext db = new SharedAppsDataContext())
            {
                Type type = typeof(DerivedType);
                DerivedType temp = new DerivedType();
                string theTableName = temp.GetTableName();
                temp = null;
                if (string.IsNullOrWhiteSpace(theTableName))
                {
                    theTableName = type.Name;
                }

                string SQL = "SELECT TOP 1 * FROM " + theTableName + " WHERE " + FieldPrefix + "DeletedOn IS NULL";

                string propertyName = "ADDIVNumber";
                PropertyInfo propertyInfo = type.GetProperty(propertyName);

                if (propertyInfo != null && type.Name.ToUpper() != "ADDIVISION")
                {
                    SQL += " AND ADDIVNumber = " + SharedAppsDataContext.DivisionNumber;
                }

                PropertyInfo[] properties = type.GetProperties();

                foreach (PropertyInfo pi in properties)
                {
                    if (pi.Name.ToUpper().Contains("DONOTUSEFROM"))
                    {
                        SQL += " AND " + FieldPrefix + "DoNotUseFrom IS NULL";
                        break;
                    }
                }

                SQL += " ORDER BY NEWID()";

                DerivedType result = db.ExecuteQuery<DerivedType>(SQL).SingleOrDefault();
                return result;
            }
        }

        public static DerivedType FetchNext(long currentNumber)
        {
            Type type = typeof(DerivedType);

            DerivedType result = new DerivedType();
            string theTableName = result.GetTableName();
            if (string.IsNullOrWhiteSpace(theTableName))
            {
                theTableName = type.Name;
            }

            result = null;

            using (SharedAppsDataContext db = new SharedAppsDataContext())
            {
                string SQL = @"
                SELECT TOP 1 *
                  FROM " + theTableName + @"
                 WHERE " + FieldPrefix + @"DeletedOn IS NULL
                   AND " + FieldPrefix + @"Number > {0}
                 ORDER BY " + FieldPrefix + @"Number ASC
                ";
                result = db.ExecuteQuery<DerivedType>(SQL, currentNumber).SingleOrDefault();
            }

            return result;
        }

        public static DerivedType FetchPrevious(long currentNumber)
        {
            Type type = typeof(DerivedType);

            DerivedType result = new DerivedType();
            string theTableName = result.GetTableName();
            if (string.IsNullOrWhiteSpace(theTableName))
            {
                theTableName = type.Name;
            }

            result = null;

            using (SharedAppsDataContext db = new SharedAppsDataContext())
            {
                string SQL = @"
                SELECT TOP 1 *
                  FROM " + theTableName + @"
                 WHERE " + FieldPrefix + @"DeletedOn IS NULL
                   AND " + FieldPrefix + @"Number < {0}
                 ORDER BY " + FieldPrefix + @"Number DESC
                ";
                result = db.ExecuteQuery<DerivedType>(SQL, currentNumber).SingleOrDefault();
            }

            return result;
        }

        public static int DeleteByGUID(Guid guid)
        {
            using (SharedAppsDataContext db = new SharedAppsDataContext())
            {
                DerivedType temp = new DerivedType();
                Type type = typeof(DerivedType);
                string SQL = $@"
                declare @guid UniqueIdentifier = {{0}}

                delete
                  from {temp.GetTableName()}
                 where {temp.GetFieldPrefix()}Guid = @guid";

                int result = 0;
                try
                {
                    result = db.ExecuteCommand(SQL, guid);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return result;
            }
        }
    }

    public class RollbackChange
    {
        public string ColumnName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }

        public RollbackChange(string columnName, string oldValue, string newValue)
        {
            ColumnName = columnName;
            OldValue = oldValue;
            NewValue = newValue;
        }

        public override string ToString()
        {
            return string.Format("{0} changed from {1} to {2}", ColumnName, OldValue, NewValue);
        }
    }

    public class ForeignKeyInfo
    {
        public string ContraintName { get; set; }
        public string FKTableName { get; set; }
        public string FKColumnName { get; set; }
        public int FKOrdinalPosition { get; set; }
        public string UQConstraintName { get; set; }
        public string UQTableName { get; set; }
        public string UQColumnName { get; set; }
        public int UQOrdinalPosition { get; set; }
    }
}
