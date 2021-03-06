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

public partial class AdminPanel_State_StateList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
         if(!Page.IsPostBack)
         {
             FillGridView();
         }
    }
    #endregion Load Event

    #region Fill GridView
    private void FillGridView()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
       try
       {
           #region Set Connection & Command Object
           if (objConn.State != ConnectionState.Open)
               objConn.Open();

           SqlCommand objCmd = objConn.CreateCommand();
           objCmd.CommandType = CommandType.StoredProcedure;
           objCmd.CommandText = "[dbo].[PR_State_SelecetAll]";
           #endregion Set Connection & Command Object

           #region Read the Value and set the controls
           SqlDataReader objSDR = objCmd.ExecuteReader();
           if (objSDR.HasRows)
           {
               gvState.DataSource = objSDR;
               gvState.DataBind();
           }

           if (objConn.State == ConnectionState.Open)
               objConn.Close();
           #endregion Read the Value and set the controls
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
    #endregion Fill GridView

    #region gvState : RowCommand
    protected void gvState_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //lblMessage.Text = "Delete Button Clicked";
        #region Delete Record
        if (e.CommandName == "DeleteRecord")
        {
            if(e.CommandArgument.ToString()!="")
            {
                DeleteState(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
        #endregion Delete Record
    }
    #endregion gvState : RowCommand

    #region Delete Recod
    private void DeleteState(SqlInt32 StateID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_State_DeleteByPK]";
            objCmd.Parameters.AddWithValue("@StateID", StateID.ToString());
            objCmd.ExecuteNonQuery();

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
            #endregion Set Connection & Command Object
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

        FillGridView();
    }
    #endregion Delete Recod
}