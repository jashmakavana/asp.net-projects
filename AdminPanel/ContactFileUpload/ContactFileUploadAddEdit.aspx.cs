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

public partial class AdminPanel_ContactFileUpload_ContactFileUploadAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        String ContactPhotoPath = "";
        if (fuContactPhotoPath.HasFile)
        {
            ContactPhotoPath = "~/UserContent/" + fuContactPhotoPath.FileName.ToString().Trim();
            fuContactPhotoPath.SaveAs(Server.MapPath(ContactPhotoPath ));
        }

        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        SqlString strContactName = SqlString.Null;
        SqlString strContactPhotoPath = SqlString.Null;
        SqlInt32 strContactFileUploadID = SqlInt32.Null;
        #endregion Local Variables
        
        try 
        {

            #region Server Side Validation
            string strErrorMessge = "";
            
            if (strErrorMessge != "")
            {
                lblMessage.Text = strErrorMessge;
                return;
            }
            #endregion Server Side Validation

            #region Gather the Information
            /*if (txtContactPhotoPath.Text.Trim() != "")
            {
                strContactPhotoPath = txtContactPhotoPath.Text.Trim();            
            }*/
            if(txtContactName.Text.Trim() != "")
            {
                strContactName = txtContactName.Text.Trim();
            }
            #endregion Gather the Information

            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType =  CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_ContactFileUpload_Insert]";
            objCmd.Parameters.AddWithValue("@ContactName",txtContactName.Text.Trim());
            objCmd.Parameters.AddWithValue("@ContactPhotoPath", ContactPhotoPath);
            objCmd.Parameters.AddWithValue("@ContactFileUploadID" ,strContactFileUploadID);
            objCmd.ExecuteNonQuery();     
            txtContactName.Text = "";
            lblMessage.Text = "Data Inserted Successfully";
            #endregion Set Connection & Command Object

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
            Response.Redirect("~/AdminPanel/ContactFileUpload/ContactFileLists.aspx", true);
        }
        catch(Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close(); 
        }
    }
    #endregion Button : Save

  /*
    #region Fill Controls

    private void FillControls(SqlInt32 CountryID)
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        #endregion Local Variables
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_Country_SelecetByPK]";
            objCmd.Parameters.AddWithValue("@ContactFileUploadID", ContactFileUploadID.ToString().Trim());
            #endregion Set Connection & Command Object

            #region Read the Value and set the controls

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (objSDR["ContactName"].Equals(DBNull.Value) != true)
                    //if(!objSDR["StateName"].Equals(DBNull.Value))      
                    {
                        txtContactName.Text = objSDR["ContactName"].ToString().Trim();
                    }
                    txtContactName.Focus();
                    if (objSDR["ContactPhotoPath"].Equals(DBNull.Value) != true)
                    {
                        txtContactPhotoPath.Text = objSDR["ContactPhotoPath"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data available for the ContactFileUploadID" + ContactFileUploadID.ToString();
            }
            #endregion Read the Value and set the controls
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }

    }
    #endregion Fill Controls
    */
}