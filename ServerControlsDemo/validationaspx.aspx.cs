using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class validationaspx : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
     protected void btnSave_Click(object sender, EventArgs e)
    {
        
        if( txtName.Text == "" && txtEnrollmentNo.Text == "" && ddlInstitute.SelectedValue == "-1" && ddlDepartment.SelectedValue == "-1" && txtBirthDate.Text == "" &&
            txtEmail.Text == "" && txtMobile.Text == "" && txtSemester.Text == "" && txtPassword.Text == "" && txtReTypePassword.Text == "")
       {
           lblSave.Text = "Please Solve this errors";
       }

        else
        {
            if (cbTerms.Checked == true)
            {
                lblSave.Text = "Your Data is saved successfully";
               
               
                cbTerms.Checked = false;
            }

            else
            {
                lblSave.Text = "Please Solve this error";
            }
            
        }

        txtName.Text = "";
        txtEnrollmentNo.Text = "";
        txtBirthDate.Text = "";
        txtPassword.Text = "";
        txtReTypePassword.Text = "";
        txtSemester.Text = "";
        txtEmail.Text = "";
        txtMobile.Text = "";
        
    }
    protected void cuvTerms_ServerValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = cbTerms.Checked;
        
    }

   
  
    

}