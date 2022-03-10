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

public partial class AdminPanel_ContactCategory_ContactCategoryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        #region is Post Back
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["ContactCategoryID"] != null)
            {
                lblMessage.Text = "Edit  Mode | ContactCategoryID = " + Request.QueryString["ContactCategoryID"].ToString();
                FillControls(Convert.ToInt32(Request.QueryString["ContactCategoryID"]));
            }
            else
            {
                lblMessage.Text = "Add Mode";
            }
        }
        #endregion is Post Back
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());       
        SqlString strContactCategoryName = SqlString.Null;
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
            strContactCategoryName = txtContactCategoryName.Text.Trim();
            #endregion Gather the Information

            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@ContactCategoryName", strContactCategoryName);
            #endregion Set Connection & Command Object


            if (Request.QueryString["ContactCategoryID"] != null)
            {
                #region Update Record
                //edit mode
                objCmd.Parameters.AddWithValue("@ContactCategoryID", Request.QueryString["ContactCategoryID"].ToString().Trim());
                objCmd.CommandText = "[dbo].[PR_ContactCategory_UpdateByPK]";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/ContactCategory/ContactCategoryList.aspx", true);
                #endregion Update Record
            }
            else
            {
                #region Insert Record
                //edit
                objCmd.CommandText = "[dbo].[PR_ContactCategory_Insert]";
                objCmd.ExecuteNonQuery();

                lblMessage.Text = "Data Inserted Successfully";
                Response.Redirect("~/AdminPanel/ContactCategory/ContactCategoryList.aspx", true);
                txtContactCategoryName.Text = "";
                txtContactCategoryName.Focus();
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

    

    #region Fill Controls
    private void FillControls(SqlInt32 ContactCategoryID)
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
            objCmd.CommandText = "[dbo].[PR_ContactCategory_SelecetByPK]";
            objCmd.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID.ToString().Trim());
            #endregion Set Connection & Command Object

            #region Read the Value and set the controls

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (objSDR["ContactCategoryName"].Equals(DBNull.Value) != true)      
                    {
                        txtContactCategoryName.Text = objSDR["ContactCategoryName"].ToString().Trim();
                    }
                    txtContactCategoryName.Focus();
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data available for the ContactCategoryID" + ContactCategoryID.ToString();
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
}