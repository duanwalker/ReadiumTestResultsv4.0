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

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                String fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                String fileLocation = Server.MapPath("~/App_Data/" + fileName);
                FileUpload1.PostedFile.SaveAs(fileLocation);
                Response.Write("File: " + fileName + " has been uploaded to the site.");
            };
        }

    }
}