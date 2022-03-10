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

public partial class AdminPanel_City_CityAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();

            if (Request.QueryString["CityID"] != null)
            {
                lblMessage.Text = "Edit  Mode | CityID = " + Request.QueryString["CityID"].ToString();
                FillControls(Convert.ToInt32(Request.QueryString["CityID"]));
            }
            else
            {
                lblMessage.Text = "Add Mode";
            }
            
        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());        
        SqlInt32 strStateID = SqlInt32.Null;
        SqlString strCityName = SqlString.Null;
        SqlString strStdCode = SqlString.Null;
        SqlString strPinCode = SqlString.Null;
        #endregion Local Variables

        try
        {
            #region Server Side Validation

            string strErrorMessge = "";
            if (ddlStateID.SelectedIndex == 0)
                strErrorMessge += "-Select State <br/>";

            if (txtCityName.Text.Trim() == "")
                strErrorMessge += "- Enter City Name <br/>";

            if (txtStdCode.Text.Trim() == "")
                strErrorMessge += "- Enter STD Code <br/>";

            if (txtPinCode.Text.Trim() == "")
                strErrorMessge += "- Enter PIN Code <br/>";

            if (strErrorMessge != "")
            {
                lblMessage.Text = strErrorMessge;
                return;
            }
            #endregion Server Side Validation

            #region Gather the Information
            if (ddlStateID.SelectedIndex > 0)
                strStateID = Convert.ToInt32(ddlStateID.SelectedValue);

            if (txtCityName.Text.Trim() != "")
                strCityName = txtCityName.Text.Trim();

            if (txtStdCode.Text.Trim() != "")
                strStdCode = txtStdCode.Text.Trim();

            if (txtPinCode.Text.Trim() != "")
                strPinCode = txtPinCode.Text.Trim();
            #endregion Gather the Information

            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
           
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
       
            objCmd.Parameters.AddWithValue("@StateID", strStateID);
            objCmd.Parameters.AddWithValue("@CityName", strCityName);
            objCmd.Parameters.AddWithValue("@STDCode", strStdCode);
            objCmd.Parameters.AddWithValue("@PinCode", strPinCode);
            #endregion Set Connection & Command Object

            if(Request.QueryString["CityID"] != null)
            {
                #region Update Record
                //edit mode
                objCmd.Parameters.AddWithValue("@CityID", Request.QueryString["CityID"].ToString().Trim());
                objCmd.CommandText = "[dbo].[PR_City_UpdateByPK]";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/City/CityList.aspx", true);
                #endregion Update Record
            }
            else
            {
                //Add mode
                #region Insert Record
                objCmd.CommandText = "[dbo].[PR_City_Insert]";
                objCmd.ExecuteNonQuery();

                lblMessage.Text = "Data Inserted Successfully";
                Response.Redirect("~/AdminPanel/City/CityList.aspx", true);
                txtCityName.Text = "";
                txtPinCode.Text = "";
                txtStdCode.Text = "";
                ddlStateID.SelectedIndex = 0;
                ddlStateID.Focus();
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

    #region Fill DropDownList
    protected void FillDropDownList()
    {

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_SelectForDropDownList";
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Set Connection & Command Object

            if (objSDR.HasRows == true)
            {
                ddlStateID.DataSource = objSDR;
                ddlStateID.DataValueField = "StateID";
                ddlStateID.DataTextField = "StateName";
                ddlStateID.DataBind();
            }

            ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));

            if (objConn.State == ConnectionState.Open)
                objConn.Close(); 
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
    #endregion Fill DropDownList

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/City/CityList.aspx", true);
    }
    #endregion Button : Cancel

    #region Fill Controls
    private void FillControls(SqlInt32 CityID)
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
            objCmd.CommandText = "[dbo].[PR_City_SelecetByPK]";
            objCmd.Parameters.AddWithValue("@CityID", CityID.ToString().Trim());
            #endregion Set Connection & Command Object

            #region Read the Value and set the controls

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (objSDR["CityName"].Equals(DBNull.Value) != true)   
                    {
                        txtCityName.Text = objSDR["CityName"].ToString().Trim();
                    }
                    txtCityName.Focus();
                    if (objSDR["StateID"].Equals(DBNull.Value) != true)
                    {
                        ddlStateID.SelectedValue = objSDR["StateID"].ToString().Trim();
                    }
                    if (objSDR["STDCode"].Equals(DBNull.Value) != true)
                    {
                        txtStdCode.Text = objSDR["STDCode"].ToString().Trim();
                    }
                    if (objSDR["PinCode"].Equals(DBNull.Value) != true)
                    {
                        txtPinCode.Text = objSDR["PinCode"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data available for the CityID" + CityID.ToString();
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