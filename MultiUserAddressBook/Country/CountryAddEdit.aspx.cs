using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MultiUserAddressBook_Country_CountryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        #region check Valid User
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/MultiUserAddressBook/Login.aspx", true);
        }
        #endregion check Valid User
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["CountryID"] != null)
            {
                lblMessage.Text = "<strong>Country Add-Edit Page | Edit  Mode </strong>| CountryID = " + Request.QueryString["CountryID"].ToString();
                FillControls(Convert.ToInt32(Request.QueryString["CountryID"]));
            }
            else
            {
                lblMessage.Text = "<h2>Country Add-Edit Page | Add Mode</h2>";
            }

        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());
        SqlString strCountryName = SqlString.Null;
        SqlString strCountryCode = SqlString.Null;
        SqlInt32 strUserID = SqlInt32.Null;
        #endregion Local Variables

        try
        {

            #region Server Side Validation
            //Validate the Data
            string strErrorMessge = "";

            if (txtCountryName.Text.Trim() == "")
                strErrorMessge += "- Enter Country Name <br/>";

            if (txtCountryCode.Text.Trim() == "")
                strErrorMessge += "- Enter Country Code <br/>";

            if (strErrorMessge != "")
            {
                lblMessage.Text = strErrorMessge;
                return;
            }
            #endregion Server Side Validation

            #region Gather the Information
            //Save the Country Data
            if (txtCountryName.Text.Trim() != "")
            {
                strCountryName = txtCountryName.Text.Trim();
            }
            if (txtCountryCode.Text.Trim() != "")
            {
                strCountryCode = txtCountryCode.Text.Trim();
            }
            if (Session["UserID"] != null)
            {
                strUserID = Convert.ToInt32(Session["UserID"]);
            }
            #endregion Gather the Information

            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            //Pass the Parameters in sp 
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@CountryName", strCountryName);
            objCmd.Parameters.AddWithValue("@CountryCode", strCountryCode);
            objCmd.Parameters.AddWithValue("@UserID", strUserID); //---aya edit kayru

            #endregion Set Connection & Command Object

            if (Request.QueryString["CountryID"] != null)
            {
                #region Update Record
                //edit mode
                objCmd.Parameters.AddWithValue("@CountryID", Request.QueryString["CountryID"].ToString().Trim());
                objCmd.CommandText = "[dbo].[PR_Country_UpdateByUserIDCountryID]";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/MultiUserAddressBook/Country/CountryList.aspx", true);
                #endregion Update Record
            }
            else
            {
                #region Insert Record
                //Add Mode
                objCmd.CommandText = "[dbo].[PR_Country_Insert]";
                objCmd.ExecuteNonQuery();                                                                           //--a chale che 
                lblMessage.Text = "Data Inserted Successfully";
                Response.Redirect("~/MultiUserAddressBook/Country/CountryList.aspx", true);
                txtCountryName.Text = "";
                txtCountryCode.Text = "";
                txtCountryName.Focus();
                #endregion Insert Record
            }
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
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
    #endregion Button : Save

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MultiUserAddressBook/Country/CountryList.aspx", true);
    }
    #endregion Button : Cancel

    #region Fill Controls
    private void FillControls(SqlInt32 CountryID)
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());
        #endregion Local Variables
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_Country_SelectByUserIDCountryID]";
            objCmd.Parameters.AddWithValue("@CountryID", CountryID.ToString().Trim());
           // objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
            #endregion Set Connection & Command Object

            #region Read the Value and set the controls

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (objSDR["CountryName"].Equals(DBNull.Value) != true)
                    //if(!objSDR["StateName"].Equals(DBNull.Value))      
                    {
                        txtCountryName.Text = objSDR["CountryName"].ToString().Trim();
                    }
                    txtCountryName.Focus();
                    if (objSDR["CountryCode"].Equals(DBNull.Value) != true)
                    {
                        txtCountryCode.Text = objSDR["CountryCode"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data available for the CountryID" + CountryID.ToString();
            }
            #endregion Read the Value and set the controls

            if (objConn.State == ConnectionState.Open)
            {
                objConn.Close();
            }
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
}