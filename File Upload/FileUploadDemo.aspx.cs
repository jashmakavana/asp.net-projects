using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class File_Upload_FileUploadDemo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        //check for selection of file
        if(fuFile.HasFile)
        {
           // lblMessages.Text = "File is Selectes - " + fuFile.FileName.ToString().Trim();
            String FolderPath = "~/UserContent/";
            String AbsolutePath = Server.MapPath(FolderPath);

            lblMessages.Text = "File will be Uploaded at the location " + AbsolutePath;

            if (!Directory.Exists(AbsolutePath))
                Directory.CreateDirectory(AbsolutePath);

            fuFile.SaveAs(AbsolutePath + fuFile.FileName.ToString().Trim()); //.Length.ToString()
        }
        else
        {
            lblMessages.Text = "You Have not Selected a File";
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        String FilePath = "~/UserContent/AbsolutePath";

        FileInfo file = new FileInfo(Server.MapPath(FilePath));

        if(file.Exists)
        {
            file.Delete();
        }
        else
        {
            lblMessages.Text = "File dose not Available";
        }
    }
}