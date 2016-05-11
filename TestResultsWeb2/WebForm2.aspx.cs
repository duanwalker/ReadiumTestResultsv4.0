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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = "";
            //get array of files from App_Data folder
            string[] files = Directory.GetFiles(Server.MapPath("~/App_Data/" ));
            if (files.Length == 0)
            {
                Response.Write("no files in folder");
            }
            else
            {
                //create datatable and header columns for datatable
                DataTable dtExcelRecords = new DataTable();
                dtExcelRecords.Columns.Add("Tester");
                dtExcelRecords.Columns.Add("Date");
                dtExcelRecords.Columns.Add("CR Version");
                dtExcelRecords.Columns.Add("Device");
                dtExcelRecords.Columns.Add("OS");
                dtExcelRecords.Columns.Add("Locale");
                dtExcelRecords.Columns.Add("Browser");
                dtExcelRecords.Columns.Add("Score");

                //loop through each file in App_Data and parse data, thereby populating gridview1
                foreach (string fileName in files)
                {
                  //  Response.Write(fileName);
                    string fileExtension = Path.GetExtension(Server.MapPath("~/App_Data/" + fileName));
                    string fileLocation = Server.MapPath("~/App_Data/" + fileName);

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

                }
                //establish connection to excel
                OleDbConnection con = new OleDbConnection(connectionString);
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;
                OleDbDataAdapter dAdapter = new OleDbDataAdapter(cmd);
               
                

            }
           
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                if (Path.GetExtension(FileUpload1.PostedFile.FileName) == ".xls" || Path.GetExtension(FileUpload1.PostedFile.FileName) == ".xlsx")
                {
                    String fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    String fileLocation = Server.MapPath("~/App_Data/" + fileName);
                    FileUpload1.SaveAs(fileLocation);
                    System.Windows.Forms.MessageBox.Show("File: " + fileName + " has been uploaded to the site.");
                }
                else System.Windows.Forms.MessageBox.Show("No Excel file was selected.");
            }
            
        }

    }
}