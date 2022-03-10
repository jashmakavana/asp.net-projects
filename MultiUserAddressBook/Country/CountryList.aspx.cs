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

public partial class MultiUserAddressBook_Country_CountryList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        #region chech valid user
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/MultiUserAddressBook/Login.aspx", true);
        }
        #endregion check valid user
        if (!Page.IsPostBack)
        {
            FillGridView();
        }
    }
    #endregion Load Event

    #region Fill GridView
    private void FillGridView()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectByUserID";

            if(Session["UserID"]!="")
            {
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            }     
            #endregion Set Connection & Command Object

            #region Read the Value and set the controls
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                gvCountry.DataSource = objSDR;
                gvCountry.DataBind();
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
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }
    }
    #endregion Fill GridView

    #region gvCountry : RowCommand
    protected void gvCountry_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        #region Delete Record

        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteCountry(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
        #endregion Delete Record
    }
    #endregion gvCountry : RowCommand

    #region Delete Country
    private void DeleteCountry(SqlInt32 CountryID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlInt32 strUserID = SqlInt32.Null;
            if (Session["UserID"] != null)
            {
                strUserID = Convert.ToInt32(Session["UserID"]);
            }

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@CountryID", CountryID.ToString());
            objCmd.Parameters.AddWithValue("@UserID", strUserID);
            objCmd.CommandText = "[dbo].[PR_Country_DeleteByUserIDCountryID]";
            objCmd.ExecuteNonQuery();

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
            lblMessage.Text = "Deleted Successfully";

            #endregion Set Connection & Command Object
            
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
            {
                objConn.Close();

            }
        }

        FillGridView();
    }
    #endregion Delete Country
}