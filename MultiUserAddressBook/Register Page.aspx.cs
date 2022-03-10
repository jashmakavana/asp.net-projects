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

public partial class MultiUserAddressBook_Register_Page : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        
        #region local variable
       // SqlInt32 strUserID = SqlInt32.Null;
        SqlString strUserName = SqlString.Null;
        SqlString strEmail = SqlString.Null;
        SqlString strPassword = SqlString.Null;
        SqlString strDisplayName = SqlString.Null;
        SqlString strMobileNo = SqlString.Null;

        #endregion local variable

        #region Server side validation
        string strErrorMessage = "";
        
        if (txtUserName.Text.Trim() == "")
        //if(txtUserNameLogin.Text.Trim()==String.Empty)
        {
            strErrorMessage += "- Enter User Name<br/>";
        }
        if (txtPassword.Text.Trim() == "")
        //if(txtUserNameLogin.Text.Trim()==String.Empty)
        {
            strErrorMessage += "- Enter Password <br/>";
        }

        if (txtDisplayName.Text.Trim() == "")
        //if(txtDisplayName.Text.Trim()==String.Empty)
        {
            strErrorMessage += "- Enter Display Name<br/>";
        }
        
        if (txtMobileNo.Text.Trim() == "")
        //if(txtUserNameLogin.Text.Trim()==String.Empty)
        {
            strErrorMessage += "- Enter Mobile No<br/>";
        }

        if (txtEmail.Text.Trim() == "")
        //if(txtUserNameLogin.Text.Trim()==String.Empty)
        {
            strErrorMessage += "- Enter Email<br/>";
        }
        
        if (strErrorMessage != "")
        {
            lblMessage.Text = "Kindly Solve following Error(s) <br/>" + strErrorMessage;
            return;
        }
        #endregion Server side validation 

        #region Assign the Value

        /*if (txtUserNameLogin.Text.Trim() != "")
        {
            strUserName = txtUserNameLogin.Text.Trim();
        }*/
        if (txtEmail.Text.Trim() != "")
        {
            strEmail = txtEmail.Text.Trim();
        }
        if (txtDisplayName.Text.Trim() != "")
        {
            strDisplayName = txtDisplayName.Text.Trim();
        }
        if (txtMobileNo.Text.Trim() != "")
        {
            strMobileNo = txtMobileNo.Text.Trim();
        }
        if (txtPassword.Text.Trim() != "")
        {
            strPassword = txtPassword.Text.Trim();
        }
        if (txtUserName.Text.Trim() != "")
        {
            strUserName = txtUserName.Text.Trim();
        }
        #endregion Assion the Value

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            #region Parameters
            objCmd.Parameters.AddWithValue("@UserName", strUserName);
            objCmd.Parameters.AddWithValue("@Email", strEmail);
            objCmd.Parameters.AddWithValue("@Password", strPassword);
            objCmd.Parameters.AddWithValue("@MobileNo", strMobileNo);
            objCmd.Parameters.AddWithValue("@DisplayName" , strDisplayName);
            #endregion Parameters

            #region Add Mode
            //Add mode
            objCmd.CommandText = "[dbo].[PR_User_Insert]";
            objCmd.ExecuteNonQuery();
            txtUserName.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtMobileNo.Text = "";
            txtDisplayName.Text = "";
            txtUserName.Focus();
            lblMessage.Text = "Data Inserted Successfully";

            Response.Redirect("~/MultiUserAddressBook/Login.aspx");
            #endregion Add Mode

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
            /*if (objConn.State != ConnectionState.Closed)
                objConn.Close();*/
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MultiUserAddressBook/Login.aspx");
    }
}