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

public partial class AdminPanel_Contact_ContactList : System.Web.UI.Page
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
            objCmd.CommandText = "[dbo].[PR_Contact_SelecetAll]";
            #endregion Set Connection & Command Object

            #region Read the Value and set the controls
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                gvContact.DataSource = objSDR;
                gvContact.DataBind();
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

    #region gvContact : RowCommand
    protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        #region Delete Record
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteContact(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
        #endregion Delete Record
    }
    #endregion gvContact : RowCommand

    #region Delete Contact
    private void DeleteContact(SqlInt32 ContactID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_Contact_DeleteByPK]";
            objCmd.Parameters.AddWithValue("@ContactID", ContactID.ToString());
            objCmd.ExecuteNonQuery();

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
    #endregion Delete Contact

}