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

public partial class AdminPanel_ContactWiseContactCategory_ContactWiseContactCategoryAddEdit : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            FillCBLContactCategoryID();
        }
    }
    #endregion Page Load

    #region FillCBLContactCategoryID
    private void FillCBLContactCategoryID()
    {
 	    SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();           
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_ContactCategory_SelectForDropDownList]";
            #endregion Set Connection & Command Object

            #region Read the Value and set the controls
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if(objSDR.HasRows)
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

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
         String ContactPhotoPath = "";
        if (fuContactPhotoPath.HasFile)
        {
            ContactPhotoPath = "~/UserContent/" + fuContactPhotoPath.FileName.ToString().Trim();
            fuContactPhotoPath.SaveAs(Server.MapPath(ContactPhotoPath ));
        }

        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        SqlString strContactName = SqlString.Null;
        SqlString strContactPhotoPath = SqlString.Null;
       // SqlInt32 strContactFileUploadID = SqlInt32.Null;
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
            /*if (txtContactPhotoPath.Text.Trim() != "")
            {
                strContactPhotoPath = txtContactPhotoPath.Text.Trim();            
            }*/
            if(txtContactName.Text.Trim() != "")
            {
                strContactName = txtContactName.Text.Trim();
            }
            #endregion Gather the Information

            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType =  CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_ContactFileUpload_Insert]";

            //pass the parameters in the sp
            objCmd.Parameters.AddWithValue("@ContactName",txtContactName.Text.Trim());
            objCmd.Parameters.AddWithValue("@ContactPhotoPath", ContactPhotoPath);

            //out parameter
            objCmd.Parameters.Add("@ContactFileUploadID", SqlDbType.Int, 4);
            //objCmd.Parameters["@ContactFileUploadID"].Direction = ParameterDirection.Output;

            objCmd.ExecuteNonQuery();
            SqlInt32 ContactFileUploadID = 0;
            ContactFileUploadID = Convert.ToInt32(objCmd.Parameters["@ContactFileUploadID"].Value);

            txtContactName.Text = "";
            lblMessage.Text = "Data Inserted Successfully with ContactFileUploadID = " + ContactFileUploadID.ToString();
            #endregion Set Connection & Command Object

            
            foreach(ListItem liContactCategoryID in cblContactCategoryID.Items)
            {
                if(liContactCategoryID.Selected)
                {
                    SqlInt32 ContactID = 0;
                    ContactID = Convert.ToInt32(objCmd.Parameters["@ContactID"].Value);

                    SqlCommand objContactCategory = objConn.CreateCommand();
                    objContactCategory.CommandType = CommandType.StoredProcedure;
                    objContactCategory.CommandText = "[dbo].[PR_ContactWiseContactCategory_Insert]";
                    objContactCategory.Parameters.AddWithValue("@ContactID", ContactID.ToString());
                    objContactCategory.Parameters.AddWithValue("@ContactCategoryID", liContactCategoryID.Value.ToString());
                    objContactCategory.ExecuteNonQuery();
                }
            }
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
           // Response.Redirect("~/AdminPanel/ContactFileUpload/ContactFileLists.aspx", true);
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
    #endregion Button : Save
}

