using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestResultsWeb2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //String strConnection = "ConnectionString";
            string connectionString = "";
            string getExcelSheetName = "";

            if (FileUpload1.HasFile)
            {
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                string fileLocation = Server.MapPath("~/App_Data/" + fileName);
                FileUpload1.SaveAs(fileLocation);
                if (fileExtension == ".xls")
                {
                    connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                      fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                }
                else if (fileExtension == ".xlsx")
                {
                    connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                      fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                }
                OleDbConnection con = new OleDbConnection(connectionString);
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;
                OleDbDataAdapter dAdapter = new OleDbDataAdapter(cmd);
                DataTable dtExcelRecords = new DataTable();
                //dtExcelRecords.Columns.Add("Tester");
                //dtExcelRecords.Columns.Add("Date");
                //dtExcelRecords.Columns.Add("CR Version");
                //dtExcelRecords.Columns.Add("Device");
                //dtExcelRecords.Columns.Add("OS");
                //dtExcelRecords.Columns.Add("Locale");
                //dtExcelRecords.Columns.Add("Browser");
                //dtExcelRecords.Columns.Add("Score");
                
               
                try
                {
                    con.Open();
                    DataTable dtExcelSheetName = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    getExcelSheetName = dtExcelSheetName.Rows[0]["Table_Name"].ToString();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} Exception caught.", ex);
                }
                cmd.CommandText = "SELECT * FROM [" + getExcelSheetName + "]";
                dAdapter.SelectCommand = cmd;
                try
                {
                    dAdapter.Fill(dtExcelRecords);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} Exception caught.", ex);
                }

                try
                {
                    string tester = dtExcelRecords.Rows[4][3].ToString();
                    Response.Write(tester);
                    string date = dtExcelRecords.Rows[7][3].ToString();
                    Response.Write(date);
                    string crVersion = dtExcelRecords.Rows[9][3].ToString();
                    Response.Write(crVersion);
                    string device = dtExcelRecords.Rows[16][3].ToString();
                    Response.Write(device);
                    string os = dtExcelRecords.Rows[18][3].ToString();
                    Response.Write(os);
                    string locale = dtExcelRecords.Rows[19][3].ToString();
                    Response.Write(locale);
                    string browser = dtExcelRecords.Rows[20][3].ToString();
                    Response.Write(browser);
                    string score = dtExcelRecords.Rows[37][2].ToString();
                    Response.Write(score);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} Exception caught.", ex);
                }

                con.Close();

                GridView1.DataSource = dtExcelRecords;
                GridView1.DataBind();
            };
        }
    }
}