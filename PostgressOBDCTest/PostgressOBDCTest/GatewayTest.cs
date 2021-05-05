using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostgressOBDCTest
{
    public partial class GatewayTest : Form
    {
        public GatewayTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Selecttest();

            UpdateTest();
        }

        private static void Selecttest()
        {
// Create the ODBC connection using the unique name you specified when 
            // creating your DSN. If desired you may input less information at the
            // DSN entry stage and put more in the "DSN=" line below.
            //OdbcConnection connection = new OdbcConnection("DSN=PostgreSQL");
            //OdbcConnection connection = new OdbcConnection("DSN=PostgreSQLInvera");
            OdbcConnection connection = new OdbcConnection("DSN=PostgreSQL30");//64 bit

            // "DSN=MyDSN;UID=Admin;PWD=Test" (UID = User name, PWD = password.)



            connection.Open();
            System.Console.WriteLine("State: " + connection.State.ToString());


            // Create an ODBC SQL command that will be executed below. Any SQL 
            // command that is valid with PostgreSQL is valid here (I think, 
            // but am not 100 percent sure. Every SQL command I've tried works).
            string query = "select * from scrcva_rec where cva_cus_ven_id = '5142'";
            OdbcCommand command = new OdbcCommand(query, connection);


            // Execute the SQL command and return a reader for navigating the results.
            OdbcDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);


            // This loop will output the entire contents of the results, iterating
            // through each row and through each field of the row.
            while (reader.Read() == true)
            {
                Console.WriteLine("New Row:");
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    // Console.WriteLine(reader.GetString(i));
                    var test = reader.GetValue(i);
                }
            }

            // Close the reader and connection (commands are not closed).
            reader.Close();
            connection.Close();
        }

        public void UpdateTest()
        {

            // string MyConString = "DRIVER={MySQL ODBC 3.51 Driver};" + "SERVER=localhost;" + "DATABASE=new_db;" + "UID=root;" + "PASSWORD=password;" + "OPTION=3";

            // OdbcConnection connection = new OdbcConnection("DSN=PostgreSQLInvera");

            OdbcConnection connection = new OdbcConnection("DSN=PostgreSQL30");
            connection.Open();
            string Query = "INSERT INTO xcti18_rec" +
                           "(" +
                           "i18_intchg_no," +
                           "i18_crtd_dtts," +
                           " i18_trpln_whs," +
                           " i18_trrte," +
                           "i18_dlvy_mthd," +
                           "i18_cmpy_id," +
                           "i18_intchg_pfx," +
                           "i18_rte_clr," +
                           "i18_crr_nm," +
                           "i18_frt_exrt," +
                           "i18_frt_ex_rt_typ," +
                           "i18_sch_rmk," +
                           "i18_lic_pl," +
                           "i18_drvr_1," +
                           "i18_drvr_2," +
                           "i18_trctr," +
                           "i18_trlr_typ," +
                           "i18_max_stp," +
                           "i18_max_wgt," +
                           "i18_max_wdth," +
                           "i18_max_lgth," +
                           "i18_appt_no," +
                           "i18_gt_dck," +
                           "i18_transp_no," +
                           "i18_crr_ref_no," +
                           "i18_frt_cry," +
                           "i18_frt_ven_id," +
                           "i18_sch_dtts" +
                           ")" +
                           " VALUES" +
                           "(" +
                           "'1122', " +
                           "'2021-05-05 11:58:03', " +
                           "'ERI', " +
                           "'-     ', " +
                           "'OC', " +
                           "'HSP', " +
                           "'XI'," +
                           " ''," +
                           " 'RUAN'," +
                           " 1.00000000," +
                           " 'V'," +
                           " 'remark'," +
                           " ''," +
                           " '', " +
                           "''," +
                           " 1," +
                           " 'CC'," +
                           " 0, " +
                           "0," +
                           " 0," +
                           " 0, " +
                           "''," +
                           " '', " +
                           "74," +
                           " 'R34535'," +
                           " 'USD', " +
                           "'1000', " +
                           "'2021-05-04 20:06:31'" +
                           ");" +
                           " insert into xcti00_rec values" +
                           "(" +
                           "'HSP', 'XI', 1122, 'ATN', 'jcross', '2021-05-04 10:58:00', 0, NULL,0, 'N', 0, 'E') ";


            OdbcCommand cmd = new OdbcCommand(Query, connection);

            

            cmd.ExecuteNonQuery();

            connection.Close();

        }

        public static OdbcDataAdapter CreateDataAdapter(
            OdbcConnection connection)
        {
            string selectCommand =
                "SELECT CustomerID, CompanyName FROM Customers";

            OdbcDataAdapter adapter = new OdbcDataAdapter(
                selectCommand, connection);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            // Create the Insert, Update and Delete commands.
            adapter.InsertCommand = new OdbcCommand(
                "INSERT INTO Customers (CustomerID, CompanyName) " +
                "VALUES (?, ?)");

            adapter.UpdateCommand = new OdbcCommand(
                "UPDATE Customers SET CustomerID = ?, CompanyName = ? " +
                "WHERE CustomerID = ?");

            adapter.DeleteCommand = new OdbcCommand(
                "DELETE FROM Customers WHERE CustomerID = ?");

            // Create the parameters.
            adapter.InsertCommand.Parameters.Add("@CustomerID",
                OdbcType.Char, 5, "CustomerID");
            adapter.InsertCommand.Parameters.Add("@CompanyName",
                OdbcType.VarChar, 40, "CompanyName");

            adapter.UpdateCommand.Parameters.Add("@CustomerID",
                OdbcType.Char, 5, "CustomerID");
            adapter.UpdateCommand.Parameters.Add("@CompanyName",
                OdbcType.VarChar, 40, "CompanyName");
            adapter.UpdateCommand.Parameters.Add("@oldCustomerID",
                    OdbcType.Char, 5, "CustomerID").SourceVersion =
                DataRowVersion.Original;

            adapter.DeleteCommand.Parameters.Add("@CustomerID",
                    OdbcType.Char, 5, "CustomerID").SourceVersion =
                DataRowVersion.Original;

            return adapter;
        }

    }
}
