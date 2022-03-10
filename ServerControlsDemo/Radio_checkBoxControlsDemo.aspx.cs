using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Radio_check : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void rbDiet_CheckedChanged(object sender, EventArgs e)
    {
        rbCE.Checked = false;
        rbCS.Checked = false;
        rbME.Checked = false;
        rbEE.Checked = false;
        if (rbDiet.Checked == true)
        {
            rbCS.Visible = true;
            rbME.Visible = true;
            rbEE.Visible = true;
            rbCE.Visible = true;
            rbDCS.Visible = false;
            rbDME.Visible = false;
            rbDEE.Visible = false;
            rbDCE.Visible = false;
        }
    }
    protected void rbDietds_CheckedChanged(object sender, EventArgs e)
    {

        rbDCE.Checked = false;
        rbDCS.Checked = false;
        rbDME.Checked = false;
        rbDEE.Checked = false;
        if (rbDietds.Checked == true)
        {
            rbCS.Visible = false;
            rbME.Visible = false;
            rbEE.Visible = false;
            rbCE.Visible = false;
            rbDCS.Visible = true;
            rbDME.Visible = true;
            rbDEE.Visible = true;
            rbDCE.Visible = true;
        }

            
         
    }
    protected void btnClickR_Click(object sender, EventArgs e)
    {
        if (rbDiet.Checked == true)
        {
            if (rbCS.Checked == true)
            {
                lblMsgR.Text = "You are selected: Degree - Computer Engineering";
            }
            else if (rbME.Checked == true)
            {
                lblMsgR.Text = "You are selected: Degree - Mechanical Engineering";
            }
            else if (rbEE.Checked == true)
            {
                lblMsgR.Text = "You are selected: Degree - Electrical Engineering";
            }
            else if (rbCE.Checked == true)
            {
                lblMsgR.Text = "You are selected: Degree - Civil Engineering";
            }
            else
            {
                lblMsgR.Text = "please select any one branch";
            }
        }
        else if (rbDietds.Checked == true)
        {
            if (rbDCS.Checked == true)
            {
                lblMsgR.Text = "You are selected: Diploma - Computer Engineering";
            }
            else if (rbDME.Checked == true)
            {
                lblMsgR.Text = "You are selected: Diploma - Mechanical Engineering";
            }
            else if (rbDEE.Checked == true)
            {
                lblMsgR.Text = "You are selected: Diploma - Electrical Engineering";
            }
            else if (rbDCE.Checked == true)
            {
                lblMsgR.Text = "You are selected: Diploma - Civil Engineering";
            }
            else
            {
                lblMsgR.Text = "please select any one branch";
            }
        }
        else
        {
            lblMsgR.Text = "Please select any one Department DIET or DIETDS";
        }
    }



//#-----------------------------------------CHECK-BOX------------------------------------------#// 
   
    protected void chkDiet_CheckedChanged(object sender, EventArgs e)
    {

        if (chkDiet.Checked == true)
        {
            chkCS.Visible = true;
            chkME.Visible = true;
            chkEE.Visible = true;
            chkCE.Visible = true;
           
        }
        else if(chkDiet.Checked == false){
            chkCS.Visible = false;
            chkME.Visible = false;
            chkEE.Visible = false;
            chkCE.Visible = false;
            chkCS.Checked = false;
            chkME.Checked = false;
            chkEE.Checked = false;
            chkCE.Checked = false;
            chkAll.Checked = false;
        }
    }
    protected void chkDietds_CheckedChanged(object sender, EventArgs e)
    {
        if (chkDietds.Checked == true)
        {
            chkDCS.Visible = true;
            chkDME.Visible = true;
            chkDEE.Visible = true;
            chkDCE.Visible = true;
        }
        else if (chkDietds.Checked == false)
        {
            chkDCS.Visible = false;
            chkDME.Visible = false;
            chkDEE.Visible = false;
            chkDCE.Visible = false;
            chkDCS.Checked = false;
            chkDME.Checked = false;
            chkDEE.Checked = false;
            chkDCE.Checked = false;
            chkAll.Checked = false;
        }
    }



    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        if (chkAll.Checked == true)
        {
            chkDCS.Visible = true;
            chkDME.Visible = true;
            chkDEE.Visible = true;
            chkDCE.Visible = true;
            chkCS.Visible = true;
            chkME.Visible = true;
            chkEE.Visible = true;
            chkCE.Visible = true;
            chkCS.Checked = true;
            chkME.Checked = true;
            chkEE.Checked = true;
            chkCE.Checked = true;
            chkDCS.Checked = true;
            chkDME.Checked = true;
            chkDEE.Checked = true;
            chkDCE.Checked = true;
            chkDiet.Checked = true;
            chkDietds.Checked = true;
        }
        else if (chkAll.Checked == false)
        {
            chkDCS.Visible = false;
            chkDME.Visible = false;
            chkDEE.Visible = false;
            chkDCE.Visible = false;
            chkCS.Visible = false;
            chkME.Visible = false;
            chkEE.Visible = false;
            chkCE.Visible = false;
            chkCS.Checked = false;
            chkME.Checked = false;
            chkEE.Checked = false;
            chkCE.Checked = false;
            chkDCS.Checked = false;
            chkDME.Checked = false;
            chkDEE.Checked = false;
            chkDCE.Checked = false;
            chkDiet.Checked = false;
            chkDietds.Checked = false;
        }
    }

         protected void btnClickc_Click(object sender, EventArgs e)
            {
                lblMsgChk.Text = "";
                if (chkDiet.Checked || chkDietds.Checked || chkDiet.Checked && chkDietds.Checked)
                {
                    var checkBox = new List<System.Web.UI.WebControls.CheckBox>() { chkCS, chkEE, chkCE, chkME, chkDCE, chkDCS, chkDME, chkDEE };
                    var oncheckBox = new List<System.Web.UI.WebControls.CheckBox>() { };
                    foreach (CheckBox cb in checkBox)
                    {
                        if (cb.Checked)
                        {
                            oncheckBox.Add(cb);
                        }
                    }
                    if (oncheckBox.Count == 0)
                    {
                        lblMsgChk.Text = "Please Select any one Beanch";
                    }
                    else
                        foreach (CheckBox cb in oncheckBox)
                        {
                    {
                        lblMsgChk.Text += "Your are selected <br/>" + cb.Text + "<br/>";
                            //lblMsgChk.Text += cb.Text + "<br/>";
                        }
                    }
                }
                else
                {
                    lblMsgChk.Text = "Please select at least one Department";
                }
            }

         protected void btnClickr_Click(object sender, EventArgs e)
         {
             chkDCS.Visible = false;
             chkDME.Visible = false;
             chkDEE.Visible = false;
             chkDCE.Visible = false;
             chkCS.Visible = false;
             chkME.Visible = false;
             chkEE.Visible = false;
             chkCE.Visible = false;
             chkCS.Checked = false;
             chkME.Checked = false;
             chkEE.Checked = false;
             chkCE.Checked = false;
             chkDCS.Checked = false;
             chkDME.Checked = false;
             chkDEE.Checked = false;
             chkDCE.Checked = false;
             chkDiet.Checked = false;
             chkDietds.Checked = false;
             chkAll.Checked = false;
         }
    
}