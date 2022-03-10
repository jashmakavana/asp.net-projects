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

public partial class AdminPanel_Contact_ContactAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        #region is Post Back        

        if (!Page.IsPostBack)
        {
            #region Fill All Drop Down List
                FillCountryDropDownList();
                FillStateDropDownList();            
                FillCityDropDownList();
                FillContactCategoryDropDownList();
            #endregion Fill All Drop Down List
                
            if (Request.QueryString["ContactID"] != null)
            {
                lblMessage.Text = "Edit  Mode | ContactID = " + Request.QueryString["ContactID"].ToString();
                FillControls(Convert.ToInt32(Request.QueryString["ContactID"]));
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
        SqlInt32 strCountryID = SqlInt32.Null;
        SqlInt32 strStateID = SqlInt32.Null;
        SqlInt32 strCityID = SqlInt32.Null;
        SqlInt32 strContactCategoryID = SqlInt32.Null;
        SqlString strContactName = SqlString.Null;
        SqlString strContactNo = SqlString.Null;
        SqlString strWhatsAppNo = SqlString.Null;
        SqlDateTime strBirthDate = SqlDateTime.Null;
        SqlString strEmail = SqlString.Null;
        SqlString strAge = SqlString.Null;
        SqlString strAddress = SqlString.Null;
        SqlString strBloodGroup = SqlString.Null;
        SqlString strFacebookID = SqlString.Null;
        SqlString strLinkedinID = SqlString.Null;
        #endregion Local Variables

        try
        {
            #region Server Side Validation
            //Server Side Validation

            string strErrorMessge = "";
            if (ddlCountryID.SelectedIndex == 0)
                strErrorMessge += "-Select Country <br/>";

            if (ddlStateID.SelectedIndex == 0)
                strErrorMessge += "-Select State <br/>";

            if (ddlCityID.SelectedIndex == 0)
                strErrorMessge += "-Select City <br/>";

            if (ddlContactCategoryID.SelectedIndex == 0)
                strErrorMessge += "-Select ContactCategory <br/>";

            if (txtContactName.Text.Trim() == "")
                strErrorMessge += "- Enter Contact Name <br/>";

            if (txtContactNo.Text.Trim() == "")
                strErrorMessge += "- Enter Contact No <br/>";

            if (txtEmail.Text.Trim() == "")
                strErrorMessge += "- Enter Email <br/>";

            if (txtAddress.Text.Trim() == "")
                strErrorMessge += "- Enter Address <br/>";

            if (strErrorMessge != "")
            {
                lblMessage.Text = strErrorMessge;
                return;
            }
            #endregion Server Side Validation

            #region Gather the Information
            //Gather the Information

            if (ddlCountryID.SelectedIndex > 0)
                strCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);

            if (ddlStateID.SelectedIndex > 0)
                strStateID = Convert.ToInt32(ddlStateID.SelectedValue);

            if (ddlCityID.SelectedIndex > 0)
                strCityID = Convert.ToInt32(ddlCityID.SelectedValue);

            if (ddlContactCategoryID.SelectedIndex > 0)
                strContactCategoryID = Convert.ToInt32(ddlContactCategoryID.SelectedValue);

            if (txtContactName.Text.Trim() != "")
                strContactName = txtContactName.Text.Trim();

            if (txtContactNo.Text.Trim() != "")
                strContactNo = txtContactNo.Text.Trim();

            if (txtWhatsAppNo.Text.Trim() != "")
                strWhatsAppNo = txtWhatsAppNo.Text.Trim();

            if (txtBirthDate.Text.Trim() != "")
                strBirthDate = Convert.ToDateTime(txtBirthDate.Text.Trim());

            if (txtEmail.Text.Trim() != "")
                strEmail = txtEmail.Text.Trim();

            if (txtAge.Text.Trim() != "")
                strAge = txtAge.Text.Trim();

            if (txtAddress.Text.Trim() != "")
                strAddress = txtAddress.Text.Trim();

            if (txtBloodGroup.Text.Trim() != "")
                strBloodGroup = txtBloodGroup.Text.Trim();

            if (txtFacebookID.Text.Trim() != "")
                strFacebookID = txtFacebookID.Text.Trim();

            if (txtLinkedinID.Text.Trim() != "")
                strLinkedinID = txtLinkedinID.Text.Trim();
            #endregion Gather the Information

            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@CountryID", strCountryID);
            objCmd.Parameters.AddWithValue("@StateID", strStateID);
            objCmd.Parameters.AddWithValue("@CityID", strCityID);
            objCmd.Parameters.AddWithValue("@ContactCategoryID", strContactCategoryID);
            objCmd.Parameters.AddWithValue("@ContactName", strContactName);
            objCmd.Parameters.AddWithValue("@ContactNo", strContactNo);
            objCmd.Parameters.AddWithValue("@WhatsAppNo", strWhatsAppNo);
            objCmd.Parameters.AddWithValue("@BirthDate", strBirthDate);
            objCmd.Parameters.AddWithValue("@Email", strEmail);
            objCmd.Parameters.AddWithValue("@Age", strAge);
            objCmd.Parameters.AddWithValue("@Address", strAddress);
            objCmd.Parameters.AddWithValue("@BloodGroup", strBloodGroup);
            objCmd.Parameters.AddWithValue("@FacebookID", strFacebookID);
            objCmd.Parameters.AddWithValue("@LinkedINID", strLinkedinID);
            #endregion Set Connection & Command Object

            if (Request.QueryString["ContactID"] != null)
            {
                #region Update Record
                //edit mode
                objCmd.Parameters.AddWithValue("@ContactID", Request.QueryString["ContactID"].ToString().Trim());
                objCmd.CommandText = "[dbo].[PR_Contact_UpdateByPK]";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/Contact/ContactList.aspx", true);
                #endregion Update Record
            }
            else
            {
                #region Insert Record
                objCmd.CommandText = "[dbo].[PR_Contact_Insert]";           
                objCmd.ExecuteNonQuery();

                lblMessage.Text = "Data Inserted Successfully";
                Response.Redirect("~/AdminPanel/Contact/ContactList.aspx", true);
                txtContactName.Text = "";
                txtContactNo.Text = "";
                txtWhatsAppNo.Text = "";
                txtBirthDate.Text = "";
                txtEmail.Text = "";
                txtAge.Text = "";
                txtAddress.Text = "";
                txtBloodGroup.Text = "";
                txtFacebookID.Text = "";
                txtLinkedinID.Text = "";
                ddlCountryID.SelectedIndex = 0;
                ddlCountryID.Focus();
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

    #region Fill Country DropDown List
    protected void FillCountryDropDownList()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectForDropDownList";
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Set Connection & Command Object

            if (objSDR.HasRows == true)
            {
                ddlCountryID.DataSource = objSDR;
                ddlCountryID.DataValueField = "CountryID";
                ddlCountryID.DataTextField = "CountryName";
                ddlCountryID.DataBind();
            }

            ddlCountryID.Items.Insert(0, new ListItem("Select Country", "-1"));
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
    #endregion Fill Country DropDown List

    #region Fill State DropDown List
    protected void FillStateDropDownList()
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
    #endregion Fill State DropDown List

    #region Fill City DropDown List
    protected void FillCityDropDownList()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_City_SelectForDropDownList";
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Set Connection & Command Object

            if (objSDR.HasRows == true)
            {
                ddlCityID.DataSource = objSDR;
                ddlCityID.DataValueField = "CityID";
                ddlCityID.DataTextField = "CityName";
                ddlCityID.DataBind();
            }

            ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
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
    #endregion Fill Country DropDown List

    #region Fill CountryCategory DropDown List
    protected void FillContactCategoryDropDownList()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_SelectForDropDownList";
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Set Connection & Command Object

            if (objSDR.HasRows == true)
            {
                ddlContactCategoryID.DataSource = objSDR;
                ddlContactCategoryID.DataValueField = "ContactCategoryID";
                ddlContactCategoryID.DataTextField = "ContactCategoryName";
                ddlContactCategoryID.DataBind();
            }
            ddlContactCategoryID.Items.Insert(0, new ListItem("Select ContactCategory", "-1"));
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
    #endregion Fill Country DropDown List

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Contact/ContactList.aspx", true);
    }
    #endregion Button : Cancel

    #region Fill Controls
    private void FillControls(SqlInt32 ContactID)
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
            objCmd.CommandText = "[dbo].[PR_Contact_SelecetByPK]";
            objCmd.Parameters.AddWithValue("@ContactID", ContactID.ToString().Trim());
            #endregion Set Connection & Command Object

            #region Read the Value and set the controls

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (objSDR["StateID"].Equals(DBNull.Value) != true)      
                    {
                        ddlStateID.Text = objSDR["StateID"].ToString().Trim();
                    }
                    ddlCountryID.Focus();
                    if (objSDR["CountryID"].Equals(DBNull.Value) != true)
                    {
                        ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
                    }
                    if (objSDR["CityID"].Equals(DBNull.Value) != true)
                    {
                        ddlCityID.Text = objSDR["CityID"].ToString().Trim();
                    }
                    if (objSDR["ContactCategoryID"].Equals(DBNull.Value) != true)
                    {
                        ddlContactCategoryID.SelectedValue = objSDR["ContactCategoryID"].ToString().Trim();
                    }
                    if (objSDR["ContactName"].Equals(DBNull.Value) != true)
                    {
                        txtContactName.Text = objSDR["ContactName"].ToString().Trim();
                    }
                    if (objSDR["ContactNo"].Equals(DBNull.Value) != true)
                    {
                        txtContactNo.Text = objSDR["ContactNo"].ToString().Trim();
                    }
                    if (objSDR["WhatsAppNo"].Equals(DBNull.Value) != true)
                    {
                        txtWhatsAppNo.Text = objSDR["WhatsAppNo"].ToString().Trim();
                    }
                    if (objSDR["BirthDate"].Equals(DBNull.Value) != true)
                    {
                        txtBirthDate.Text = Convert.ToDateTime(objSDR["BirthDate"]).Date.ToString("yyyy-MM-dd");
                    }
                    if (objSDR["Email"].Equals(DBNull.Value) != true)
                    {
                        txtEmail.Text = objSDR["Email"].ToString().Trim();
                    }
                    if (objSDR["Age"].Equals(DBNull.Value) != true)
                    {
                        txtAge.Text = objSDR["Age"].ToString().Trim();
                    }
                    if (objSDR["Address"].Equals(DBNull.Value) != true)
                    {
                        txtAddress.Text = objSDR["Address"].ToString().Trim();
                    }
                    if (objSDR["BloodGroup"].Equals(DBNull.Value) != true)
                    {
                        txtBloodGroup.Text = objSDR["BloodGroup"].ToString().Trim();
                    }
                    if (objSDR["FacebookID"].Equals(DBNull.Value) != true)
                    {
                        txtFacebookID.Text = objSDR["FacebookID"].ToString().Trim();
                    }
                    if (objSDR["LinkedINID"].Equals(DBNull.Value) != true)
                    {
                        txtLinkedinID.Text = objSDR["LinkedINID"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data available for the ContactID" + ContactID.ToString();
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