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

public partial class AdminPanel_ContactFileUpload_ContactFileLists : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridView();
        }
    }
    #endregion Page Load

    #region Fill GridView
    private void FillGridView()
    {

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString); //Integrated Security=False; User ID=sa;Password=9081;
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_ContactFileUpload_SelecetAll]";
            #endregion Set Connection & Command Object

            #region Read the Value and set the controls
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                gvContactFileUpload.DataSource = objSDR;
                gvContactFileUpload.DataBind();
            }
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
            #endregion Read the Value and set the controls
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            objConn.Close();
        }

    }
    #endregion Fill GridView

    #region Delete Contact File Upload
    private void DeleteContactFileUpload(SqlString filePath)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlInt32 strContactFileUploadID = SqlInt32.Null;

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@ContactPhotoPath", filePath);
            objCmd.Parameters.AddWithValue("@ContactFileUploadID", strContactFileUploadID);
            objCmd.CommandText = "[dbo].[PR_ContactFileUpload_DeleteByPK]";
            objCmd.ExecuteNonQuery();


            lblMessage.Text = "Data deleted successful";
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
            #endregion Set Connection & Command Object
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            objConn.Close();
        }

        FillGridView();
    }
    #endregion Delete Contact File Upload

    #region gvContactFileUpload : RowCommand
    protected void gvContactFileUpload_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        #region Delete Record
        //if (e.CommandName == "DeleteRecord")
        //{
        //    if (e.CommandArgument.ToString() != "")
        //    {
        //        DeleteContactFileUpload(Convert(e.CommandArgument.ToString().Trim()));
        //    }
        //} 
        /*if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteContactFileUpload(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }*/
        if (e.CommandName == "DeletePhoto")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeletePhoto(e.CommandArgument.ToString());
            }
        } 

        #endregion Delete Record
    }
    #endregion gvContactFileUpload : RowCommand

    private void DeletePhoto(string e)
    {

        FileInfo file = new FileInfo(Server.MapPath(e));

        if(file.Exists)
        {
            file.Delete();
            
        }
        DeleteContactFileUpload(Convert.ToString(file));
    }
}