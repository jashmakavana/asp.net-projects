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

public partial class MultiUserAddressBook_City_CityList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridView();
        }
    }
    #endregion Load Event

    #region Fill Grid View
    private void FillGridView()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlInt32 strCityID = SqlInt32.Null;
           
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_City_SelectByUserID]";
            objCmd.Parameters.AddWithValue("@CityID", strCityID);
            
            if (Session["UserID"] != "")
            {
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            }
            #endregion Set Connection & Command Object

            #region Read the Value and set the controls
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                gvCity.DataSource = objSDR;
                gvCity.DataBind();
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
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion Fill Grid View

    #region gvCity
    protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        #region Delete Record
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteCity(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
                //DeleteCity(Convert.ToInt32(e.CommandArgument.ToString().Trim()), (Convert.ToInt32(Request.QueryString["UserID"])));
            }
        }
        #endregion Delete Record
    }
    #endregion gvCity

    #region Delete Country
    private void DeleteCity(SqlInt32 CityID) //private void DeleteCity(SqlInt32 CityID, SqlInt32 UserID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());
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
            objCmd.CommandText = "[dbo].[PR_City_DeleteByUserIDCityID]";
            objCmd.Parameters.AddWithValue("@CityID", CityID.ToString());
            objCmd.Parameters.AddWithValue("@UserID", strUserID.ToString());
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
                objConn.Close();
        }

        FillGridView();
    }
    #endregion Delete Country
}