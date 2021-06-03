using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;



namespace StratixRuanDataLayer.Linq2SQL
{
    public class SharedAppsDataContext : DataContext
    {
        public static string localConnectionString = string.Empty; //"Integrated Security=true;User ID=msc_user;Password=Msc*911;Initial Catalog=centaurdev-test;Data Source=.;Connection Timeout=150; Min Pool Size=20;";

        private static List<ADTABLE> _tableCache;
        public static List<ADTABLE> TableCache
        {
            get
            {
                return _tableCache;
            }
        }

        private static string _connectionString;
        public static string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            set
            {
                if (_connectionString != value)
                {
                    _connectionString = value;
                    _tableCache = null;
                }
            }
        }
        public static long DivisionNumber { get; set; }
        public static long LocationNumber { get; set; }
        public static long UserNumber { get; set; }
        public static long WorkstationNumber { get; set; }

        private static bool enableSqlLogging = false;
        public static bool EnableSqlLogging
        {
            get
            {
                return enableSqlLogging;
            }
            set
            {
                enableSqlLogging = value;
            }
        }

        public SharedAppsDataContext()
            : this(ConnectionString)
        {
#if DEBUG
            this.Log = new DebugTextWriter();
#endif
            this.CommandTimeout = this.Connection.ConnectionTimeout;
        }

        public SharedAppsDataContext(string connection)
            : base(connection)
        {
#if DEBUG
            this.Log = Console.Out;
#endif
            if(_tableCache == null)
            {
                _tableCache = ADTABLE.ToList();
            }
        }

        public void CreateBlankDatabase()
        {
            if (DatabaseExists())
                DeleteDatabase();

            CreateDatabase();
        }

        public Table<ADTABLE> ADTABLE
        {
            get
            {
                return GetTable<ADTABLE>();
            }
        }





        public int DeleteAll<T>(IEnumerable<T> entities)
        {
            Type t = typeof(T);
            string keyString = "";

            entities = entities.ToArray();

            var tableAttribute = (TableAttribute)t.GetCustomAttributes(
                typeof(TableAttribute), false).Single();

            string tableName = tableAttribute.Name ?? t.Name;

            var primaryKey = t.GetProperties().Where(PrimaryKeyFilter).FirstOrDefault();

            if (primaryKey == null)
            {
                return 0;
            }
            var keys = entities.Select(e => t.GetProperty(primaryKey.Name).GetValue(e, null));

            if (keys != null && keys.Count() > 0)
            {
                keyString = string.Join(",", keys);

                string sql = string.Format("DELETE {0} WHERE {1} IN ({2})", tableName, primaryKey.Name, keyString);

                return ExecuteCommand(sql, new object[] { });
            }
            else
            {
                return 0;
            }
        }

        public void BulkInsertAll<T>(IEnumerable<T> entities) where T : SharedAppsDataObject<T>, new()
        {
            Type t = typeof(T);
            var table = SharedAppsDataObject<T>.ConvertToDataTable(entities);
            var tableAttribute = (TableAttribute)t.GetCustomAttributes(typeof(TableAttribute), false).Single();

            var bulkCopy = new SqlBulkCopy(Connection.ConnectionString, SqlBulkCopyOptions.FireTriggers)
            {
                DestinationTableName = tableAttribute.Name ?? t.Name
            };


            bulkCopy.WriteToServer(table);
        }

        private bool PrimaryKeyFilter(System.Reflection.PropertyInfo p)
        {
            var attribute = Attribute.GetCustomAttribute(p,
                typeof(AssociationAttribute)) as AssociationAttribute;
            var columnAttribute = Attribute.GetCustomAttribute(p,
                typeof(ColumnAttribute)) as ColumnAttribute;

            if (!Attribute.IsDefined(p, typeof(ColumnAttribute))) return false;

            if (columnAttribute.IsPrimaryKey) return true;

            return false;
        }

        internal object ExecuteQuery<T1>(StringBuilder sql, long p)
        {
            throw new NotImplementedException();
        }
    }

    class DebugTextWriter : System.IO.TextWriter
    {
        public void TraceMessage(string message,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            string msg = string.Format("{0}({1})", sourceFilePath, sourceLineNumber);
            Debug.WriteLine(msg);
        }

        public override void Write(char[] buffer, int index, int count)
        {
            string msg = new String(buffer, index, count);

            try
            {
                if (msg.StartsWith("-- @p"))
                {
                    msg = msg.Replace(";", "");
                    //msg = msg.Replace(":", "");
                    msg = msg.Replace("(", "");
                    msg = msg.Replace(")", "");
                    msg = msg.Replace("[", "");
                    msg = msg.Replace("]", "");
                    msg = msg.Replace("\r\n", "");

                    string[] parts = msg.Split(' ');
                    string varType = parts[3];
                    parts[0] = parts[0].Replace(":", "");
                    parts[1] = parts[1].Replace(":", "");


                    if (varType == "VarChar" || varType == "NVarChar")
                    {
                        string format = "DECLARE {0} {1}({2}) = '{3}'\r\n";

                        if (parts[13] == "Null")
                        {
                            format = "DECLARE {0} {1}({2}) = {3}\r\n";
                        }

                        string varCharParts = "";
                        varCharParts = msg.Substring(msg.IndexOf(parts[13]));
                        msg = string.Format(format, parts[1], parts[3], parts[6], varCharParts);
                        //msg = string.Format(format, parts[1], parts[3], parts[6], parts[13]);
                    }
                    else if (varType == "DateTime")
                    {
                        if (parts.Length >= 15)
                        {
                            string format = "DECLARE {0} {1} = '{2} {3}'\r\n";
                            msg = string.Format(format, parts[1], parts[3], parts[13], parts[14]);
                        }
                        else
                        {
                            string format = "DECLARE {0} {1} = '{2}'\r\n";
                            msg = string.Format(format, parts[1], parts[3], parts[13]);
                        }
                    }
                    else
                    {
                        string format = "DECLARE {0} {1} = {2}\r\n";
                        msg = string.Format(format, parts[1], parts[3], parts[13]);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
                //ignore errors, it should default to the old message.
            }

            if (SharedAppsDataContext.EnableSqlLogging)
            {
                System.Diagnostics.Debug.Write(msg);
            }
        }

        public override void Write(string value)
        {
            System.Diagnostics.Debug.Write(value);
        }

        public override Encoding Encoding
        {
            get { return System.Text.Encoding.Default; }
        }
    }
}
