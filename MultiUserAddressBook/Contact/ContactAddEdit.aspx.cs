using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MultiUserAddressBook_Contact_ContactAddEdit : System.Web.UI.Page
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

        #region is Post Back

        if (!Page.IsPostBack)
        {
            #region Fill All Drop Down List
            FillCountryDropDownList();
            FillCBLContactCategoryID();
            #endregion Fill All Drop Down List

            if (Request.QueryString["ContactID"] != null)
            {
                lblMessage.Text = "<strong>Contact Add-Edit Page | Edit  Mode</strong> | ContactID = " + Request.QueryString["ContactID"].ToString();
                FillControls(Convert.ToInt32(Request.QueryString["ContactID"]));
                FillStateDropDownList();
                FillCityDropDownList();
            }
            else
            {
                lblMessage.Text = "<h3>Contact Add-Edit Page | Add Mode</h3>";
            }
        }
        #endregion is Post Back
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region File Content
        String ContactPhotoPath = "";
        String Attribute = "";

        if (fuFileContactPhotoPath.HasFile)
        {
            ContactPhotoPath = "~/MultiUserAddressBook/UserContent/" + DateTime.Now.ToString("ddMMyyyyhhmmssffftt") + fuFileContactPhotoPath.FileName.ToString().Trim();
            System.Drawing.Image img = System.Drawing.Image.FromStream(fuFileContactPhotoPath.PostedFile.InputStream);
            decimal size = Math.Round(((decimal)fuFileContactPhotoPath.PostedFile.ContentLength / (decimal)1024), 2);
            string FileExtn = System.IO.Path.GetExtension(fuFileContactPhotoPath.PostedFile.FileName);
            string ext = Path.GetExtension(FileExtn);
            //int sizeRestricted = fuFileContactPhotoPath.PostedFile.ContentLength;
            int ActualWidth = img.Width;
            int ActualHeight = img.Height;

            Attribute = "File Size - " + size + " KB "
                   + " Height - " + ActualHeight + " px "
                   + " Width - " + ActualWidth + " px "
                  + " File Type - " + ext + " File ";

        }
        if (!Directory.Exists(Server.MapPath("~/MultiUserAddressBook/UserContent/")))
        {
            Directory.CreateDirectory(Server.MapPath("~/MultiUserAddressBook/UserContent/"));
        }
        #endregion File Content

        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());
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
        SqlString strLinkedINID = SqlString.Null;
        SqlString strOldAttribute = SqlString.Null;
        string LogicalPath = "~/MultiUserAddressBook/UserContent/" + DateTime.Now.ToString("ddMMyyyyhhmmssffftt");
        string AbsolutePath = "";
        SqlInt32 strUserID = SqlInt32.Null;
        #endregion Local Variables

        try
        {
            #region Server Side Validation
            //Server Side Validation

            string strErrorMessage = "";
            if (ddlCountryID.SelectedIndex == 0)
                strErrorMessage += "-Select Country <br/>";

            if (ddlStateID.SelectedIndex == 0)
                strErrorMessage += "-Select State <br/>";

            if (ddlCityID.SelectedIndex == 0)
                strErrorMessage += "-Select City <br/>";

            if (cblContactCategoryID.SelectedIndex == 0)   // aya pan change karel che
                strErrorMessage += "-Select ContactCategory <br/>";

            if (txtContactName.Text.Trim() == "")
                strErrorMessage += "- Enter Contact Name <br/>";

            if (txtContactNo.Text.Trim() == "")
                strErrorMessage += "- Enter Contact No <br/>";

            if (txtEmail.Text.Trim() == "")
                strErrorMessage += "- Enter Email <br/>";

            if (txtAddress.Text.Trim() == "")
                strErrorMessage += "- Enter Address <br/>";

            if (strErrorMessage != "")
            {
                lblMessage.Text = strErrorMessage;
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

            if (cblContactCategoryID.SelectedIndex > 0)  // aya pan change karel che
                strContactCategoryID = Convert.ToInt32(cblContactCategoryID.SelectedValue);   // aya pan change karel che

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

            if (txtLinkedINID.Text.Trim() != "")
                strLinkedINID = txtLinkedINID.Text.Trim();

            if (fuFileContactPhotoPath.HasFile)
            {
                AbsolutePath = Server.MapPath(LogicalPath);
            }
            if (hfAttribute.Value.Trim() != "")
            {
                strOldAttribute = hfAttribute.Value.Trim();

            }

            if (Session["UserID"] != null)
            {
                strUserID = Convert.ToInt32(Session["UserID"]);
            }
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
            objCmd.Parameters.AddWithValue("@UserID", strUserID);
            objCmd.Parameters.AddWithValue("@LinkedINID", strLinkedINID);

            #endregion Set Connection & Command Object

            #region Edit Mode
            if (Request.QueryString["ContactID"] != null)
            {
                #region Update Record
                //Edit mode

                #region Update Image
                if (fuFileContactPhotoPath.HasFile)
                {
                    FileInfo file = new FileInfo(Server.MapPath(hfContactPhotoPath.Value.ToString()));
                    if (file.Exists)
                        file.Delete();
                    fuFileContactPhotoPath.SaveAs(AbsolutePath + fuFileContactPhotoPath.FileName);
                    objCmd.Parameters.AddWithValue("ContactPhotoPath", LogicalPath + fuFileContactPhotoPath.FileName);
                    objCmd.Parameters.AddWithValue("@PhotoAttribute", Attribute);

                }
                else
                {
                    objCmd.Parameters.AddWithValue("ContactPhotoPath", hfContactPhotoPath.Value.ToString());
                    objCmd.Parameters.AddWithValue("@PhotoAttribute", strOldAttribute);
                }
                #endregion Update Image

                objCmd.Parameters.AddWithValue("@ContactID", Request.QueryString["ContactID"].ToString().Trim());
                objCmd.CommandText = "[dbo].[PR_Contact_UpdateByUserIContactID]";
                lblMessage.Text = "Data Edited Successfully";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/MultiUserAddressBook/Contact/ContactList.aspx", true);
                #endregion Update Record
            }
            #endregion Edit Mode

            #region Add Mode
            else
            {
                //Add mode
                if (!fuFileContactPhotoPath.HasFile)
                {
                    strErrorMessage += "-Please Upload Photo <br/>";
                }
                else
                {
                    objCmd.CommandText = "[dbo].[PR_Contact_Insert]";
                    objCmd.Parameters.AddWithValue("ContactPhotoPath", LogicalPath + fuFileContactPhotoPath.FileName);
                    objCmd.Parameters.AddWithValue("@PhotoAttribute", Attribute);

                    objCmd.Parameters.Add("@ContactID",SqlDbType.Int, 4).Direction = ParameterDirection.Output; ; // a both line change kari che
                    //objCmd.Parameters["@ContactID"].Direction = ParameterDirection.Output; // a both line change kari che

                    objCmd.ExecuteNonQuery();
                    #region Save Image to Directory
                    fuFileContactPhotoPath.SaveAs(AbsolutePath + fuFileContactPhotoPath.FileName);
                    #endregion Save Image to Directory

                    SqlInt32 ContactID = 0;  // aya pan change karel che
                    ContactID = Convert.ToInt32(objCmd.Parameters["@ContactID"].Value);  // aya pan change karel che

                    Response.Redirect("~/MultiUserAddressBook/Contact/ContactList.aspx", true);
                    ddlCountryID.SelectedIndex = 0;
                    ddlStateID.SelectedIndex = 0;
                    ddlCityID.SelectedIndex = 0;
                    cblContactCategoryID.SelectedIndex = 0;
                    txtContactName.Text = "";
                    txtContactNo.Text = "";
                    txtWhatsAppNo.Text = "";
                    txtBirthDate.Text = "";
                    txtEmail.Text = "";
                    txtAge.Text = "";
                    txtAddress.Text = "";
                    txtBloodGroup.Text = "";
                    txtFacebookID.Text = "";
                    txtLinkedINID.Text = "";
                    ddlCountryID.Focus();

                    lblMessage.Text = "Data Inserted Successfully with ContactID = "+ ContactID.ToString() ;

                }
                if (strErrorMessage.Trim() != "")
                {
                    lblMessage.Text = strErrorMessage;
                    return;
                }
            }
            #endregion Add Mode

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
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_Country_SelectForDropDownList]";
            if (Session["UserID"] != "")
            {
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            }
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
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@CountryID", Convert.ToInt32(ddlCountryID.SelectedValue));
            objCmd.CommandText = "[dbo].[PR_City_StateDropdownList]";

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
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();


            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@StateID", Convert.ToInt32(ddlStateID.SelectedValue));

            objCmd.CommandText = "[dbo].[PR_City_SelectStateDropdownList]";

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


    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MultiUserAddressBook/Contact/ContactList.aspx", true);
    }
    #endregion Button : Cancel

    #region Fill Controls
    private void FillControls(SqlInt32 ContactID)
    {
        String Attribute = "";
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
            objCmd.CommandText = "[dbo].[PR_Contact_SelectByUserIContactID]";
            objCmd.Parameters.AddWithValue("@ContactID", ContactID.ToString().Trim());
            // objCmd.Parameters.AddWithValue("@UserID", strUserID.ToString());
            #endregion Set Connection & Command Object

            #region Read the Value and set the controls

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (objSDR["StateID"].Equals(DBNull.Value) != true)
                    {
                        ddlStateID.SelectedValue = objSDR["StateID"].ToString().Trim();
                    }
                    ddlCountryID.Focus();
                    if (objSDR["CountryID"].Equals(DBNull.Value) != true)
                    {
                        ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
                    }
                    if (objSDR["CityID"].Equals(DBNull.Value) != true)
                    {
                        ddlCityID.SelectedValue = objSDR["CityID"].ToString().Trim();
                    }
                    if (objSDR["ContactCategoryID"].Equals(DBNull.Value) != true)
                    {
                        cblContactCategoryID.SelectedValue = objSDR["ContactCategoryID"].ToString().Trim();
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
                        txtLinkedINID.Text = objSDR["LinkedINID"].ToString().Trim();
                    }
                    if (objSDR["ContactPhotoPath"].Equals(DBNull.Value) != true)
                    {
                        hfContactPhotoPath.Value = objSDR["ContactPhotoPath"].ToString().Trim();
                    }
                    if (objSDR["PhotoAttribute"].Equals(DBNull.Value) != true)
                    {
                        Attribute = objSDR["PhotoAttribute"].ToString().Trim();
                        hfAttribute.Value = objSDR["PhotoAttribute"].ToString().Trim();
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

    #region ddl CountryID : SelectIndexChanged
    protected void ddlCountryID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlStateID.Items.Clear();
        FillStateDropDownList();

    }
    #endregion ddl CountryID : SelectIndexChanged

    #region ddl StateID : SelectIndexChanged
    protected void ddlStateID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCityID.Items.Clear();
        FillCityDropDownList();
    }
    #endregion ddl StateID : SelectIndexChanged

    #region FillCBLContactCategoryID
    private void FillCBLContactCategoryID()  // aya akhu j  change karel che
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_ContactCategory_SelectForDropDownList]";
            #endregion Set Connection & Command Object

            if (Session["UserID"] != "")
            {
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            }
            #region Read the Value and set the controls
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                cblContactCategoryID.DataTextField = "ContactCategoryName";
                cblContactCategoryID.DataValueField = "ContactCategoryID";
                cblContactCategoryID.DataSource = objSDR;
                cblContactCategoryID.DataBind();
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
    #endregion FillCBLContactCategoryID

    //#region Fill CountryCategory DropDown List
    //protected void FillContactCategoryDropDownList()
    //{
    //    SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());
    //    try
    //    {
    //        #region Set Connection & Command Object
    //        if (objConn.State != ConnectionState.Open)
    //            objConn.Open();

    //        SqlCommand objCmd = objConn.CreateCommand();
    //        objCmd.CommandType = CommandType.StoredProcedure;
    //        objCmd.CommandText = "[dbo].[PR_ContactCategory_SelectForDropDownList]";

    //        if (Session["UserID"] != "")
    //        {
    //            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
    //        }
    //        SqlDataReader objSDR = objCmd.ExecuteReader();
    //        #endregion Set Connection & Command Object

    //        if (objSDR.HasRows == true)
    //        {
    //            cblContactCategoryID.DataSource = objSDR;
    //            cblContactCategoryID.DataValueField = "ContactCategoryID";
    //            cblContactCategoryID.DataTextField = "ContactCategoryName";
    //            cblContactCategoryID.DataBind();
    //        }
    //        ddlContactCategoryID.Items.Insert(0, new ListItem("Select ContactCategory", "-1"));
    //        if (objConn.State == ConnectionState.Open)
    //            objConn.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMessage.Text = ex.Message;
    //    }
    //    finally
    //    {
    //        if (objConn.State == ConnectionState.Open)
    //            objConn.Close();
    //    }
    //}
    //#endregion Fill Country DropDown List


}