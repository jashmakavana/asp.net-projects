using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MultiUserAddressBook_Contact_ContactList : System.Web.UI.Page
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
        if (!Page.IsPostBack)
        {
            FillGridView();
        }
    }
    #endregion Load Event

    #region Fill GridView
    private void FillGridView()
    {

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString); //Integrated Security=False; User ID=sa;Password=9081;
        //Establish the Connection
        //Create empty connection object
        //Read the connection string from web.config file
        try
        {
            //DESKTOP-TH5FB1M\\SQLEXPRESS ; This is source of data or Server name
            //AddressBook ; This is database name
            //Integrated Security ; if it is true then it is windows authentication and if it is false then it is sql authentication so we put the User id and password 
            //User Id = ****
            //Password = ****
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open(); // if Close the Connection so open connection

            SqlInt32 strContactID = SqlInt32.Null;

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_Contact_SelectByUserID]";
            objCmd.Parameters.AddWithValue("@ContactID", strContactID);

            if (Session["UserID"] != "")
            {
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            }
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
            if (objConn.State == ConnectionState.Open)
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
                lblMessage.Text = "Deleted Successfully";
            }
        }
        #endregion Delete Record

        //#region Delete Photo
        //if (e.CommandName == "DeletePhoto")
        //{
        //    if (e.CommandArgument.ToString() != "")
        //    {
        //        DeletePhoto(e.CommandArgument.ToString());
        //    }
        //}
        //#endregion Delete Photo

    }
    #endregion gvContact : RowCommand

    //#region Delete Photo
    //private void DeletePhoto(string e)
    //{

    //    FileInfo file = new FileInfo(Server.MapPath(e));

    //    if (file.Exists)
    //    {
    //        file.Delete();

    //    }
    //    DeletePhoto(Convert.ToString(file));
    //}
    //#endregion Delete Photo


    #region Delete Contact
    private void DeleteContact(SqlInt32 ContactID)
    {
        FillControls(ContactID);
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
            objCmd.Parameters.AddWithValue("@ContactID", ContactID.ToString());
            objCmd.Parameters.AddWithValue("@UserID", strUserID.ToString());
            objCmd.CommandText = "[dbo].[PR_Contact_DeleteByUserIContactID]";

            objCmd.ExecuteNonQuery();
            FillGridView();
            if (objConn.State == ConnectionState.Open)
                objConn.Close();

            #endregion Set Connection & Command Object
            FillGridView();
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
    #endregion Delete Contact

    #region Fill Controls
    private void FillControls(SqlInt32 ContactID)
    {
        #region Connection Establish
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());
        #region Try Block
        try
        {
            #region Connection
            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
            }
            #region Command Object
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_Contact_SelectByUserIContactID]";
            #region Parameters
            objCmd.Parameters.AddWithValue("@ContactID", ContactID.ToString().Trim());
            #endregion Parameters
            #region Read the Values and set the Controls
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #region Rows
            if (objSDR.HasRows)
            {
                #region Read
                while (objSDR.Read())
                {

                    if (objSDR["ContactPhotoPath"].Equals(DBNull.Value) != true)
                    {
                        String ContactPhotoPath = objSDR["ContactPhotoPath"].ToString().Trim();

                        FileInfo file = new FileInfo(Server.MapPath(ContactPhotoPath));
                        if (file.Exists)
                        {
                            file.Delete();
                        }
                    }
                    break;
                }
                #endregion Read
            }
            #endregion Rows
            #endregion Read the Values and set the Controls
            else
            {
                lblMessage.Text = "No Data available for the ContactID = " + ContactID.ToString();
            }
            #endregion Command Object
            if (objConn.State == ConnectionState.Open)
            {
                objConn.Close();
            }
            #endregion Connection
        }
        #endregion Try Block
        #region Catch Block
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        #endregion Catch Block
        #region Finally Block
        finally
        {
            if (objConn.State == ConnectionState.Open)
            {
                objConn.Close();
            }
        }
        #endregion Finally Block
        #endregion Connection Establish
    }
    #endregion Fill Controls

}