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

public partial class MultiUserAddressBook_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "Data Inserted Successfully";

        // validate user OrderedParallelQuery not Validate User
        //UserName, Password
        #region Server side validation
        string strErrorMessage = "";

        if(txtUserNameLogin.Text.Trim()=="")
        //if(txtUserNameLogin.Text.Trim()==String.Empty)
        {
            strErrorMessage += "- Enter User Name<br/>";
        }
        if (txtPasswordLogin.Text.Trim() == "")
        //if(txtUserNameLogin.Text.Trim()==String.Empty)
        {
            strErrorMessage += "- Enter Password<br/>";
        }

        if(strErrorMessage!="")
        {
            lblMessage.Text = "Kindly Solve following Error(s) <br/>" + strErrorMessage;
            return;
        }
        #endregion Server side validation

        #region local variable

        SqlString strUserName = SqlString.Null;
        SqlString strPassWord = SqlString.Null;

        #endregion local variable

        #region Assign the Value

        if(txtUserNameLogin.Text.Trim()!="")
        {
            strUserName = txtUserNameLogin.Text.Trim();
        }
        if (txtPasswordLogin.Text.Trim() != "")
        {
            strPassWord = txtPasswordLogin.Text.Trim();
        }
        #endregion Assion the Value

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType= CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_User_SelectByUserNamePassword]";
            objCmd.Parameters.AddWithValue("@UserName",strUserName);
            objCmd.Parameters.AddWithValue("@Password",strPassWord);

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if(objSDR.HasRows)
            {
                //valid User
                lblMessage.Text = "Valid User";
                while (objSDR.Read())
                {
                    if (!objSDR["UserID"].Equals(DBNull.Value))
                    {
                        Session["UserID"] = objSDR["UserID"].ToString().Trim();
                    }
                    if (!objSDR["DisplayName"].Equals(DBNull.Value))
                    {
                        Session["DisplayName"] = objSDR["DisplayName"].ToString().Trim();
                    }
                    break;
                }
                Response.Redirect("~/MultiUserAddressBook/Default.aspx");
            }
            else
            {
                lblMessage.Text = "Either Username or password is not valid, Try Again With Different Detail !";
            }
            /*if (objConn.State != ConnectionState.Closed)
                objConn.Close();*/
            
            if (objConn.State == ConnectionState.Open)
            {
                objConn.Close();
            }
        }
        catch(Exception ex)
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

}