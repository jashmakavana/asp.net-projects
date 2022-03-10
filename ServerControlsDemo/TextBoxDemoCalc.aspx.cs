using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ServerControlsDemo_TextBoxDemoCalc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (txtNo1.Text == "0")
        {
            lblMsg3.Text = "You have entered 0";
        }
        else if (txtNo2.Text == "0")
        {
            lblMsg3.Text = "You have entered 0";
        }
        else if (txtNo1.Text == "")
        {
            lblMsg1.Text = "Kindly enter a number";
        }
        else if (txtNo2.Text == "")
        {
            lblMsg2.Text = "Kindly enter a number";
        }
        else
        {
            lblAnswer.Text = Convert.ToString(Convert.ToInt32(txtNo1.Text) + Convert.ToInt32(txtNo2.Text));

            lblMsg2.Text = "";
            lblMsg1.Text = "";
            lblMsg3.Text = "";
        }

       
    }
    protected void btnSub_Click(object sender, EventArgs e)
    {
        if (txtNo1.Text == "0")
        {
            lblMsg3.Text = "You have entered 0";
        }
        else if (txtNo2.Text == "0")
        {
            lblMsg3.Text = "You have entered 0";
        }
        else if (txtNo1.Text == "")
        {
            lblMsg1.Text = "Kindly enter a number";
        }
        else if (txtNo2.Text == "")
        {
            lblMsg2.Text = "Kindly enter a number";
        }
        else
        {
            lblAnswer.Text = Convert.ToString(Convert.ToInt32(txtNo1.Text) - Convert.ToInt32(txtNo2.Text));
            lblMsg2.Text = "";
            lblMsg1.Text = "";
            lblMsg3.Text = "";
        }
    }
    protected void btnMul_Click(object sender, EventArgs e)
    {
        if (txtNo1.Text == "0")
        {
            lblMsg3.Text = "You have entered 0";
        }
        else if (txtNo2.Text == "0")
        {
            lblMsg3.Text = "You have entered 0";
        }
        else if (txtNo1.Text == "")
        {
            lblMsg1.Text = "Kindly enter a number";
        }
        else if (txtNo2.Text == "")
        {
            lblMsg2.Text = "Kindly enter a number";
        }
        else
        {
            lblAnswer.Text = Convert.ToString(Convert.ToDouble(txtNo1.Text) * Convert.ToDouble(txtNo2.Text));
            lblMsg2.Text = "";
            lblMsg1.Text = "";
            lblMsg3.Text = "";
        }
    }
    protected void btnDiv_Click(object sender, EventArgs e)
    {
        if (txtNo1.Text == "0")
        {
            lblMsg3.Text = "You have entered 0";
        }
        else if (txtNo2.Text == "0")
        {
            lblMsg3.Text = "You have entered 0";
        }
        else if (txtNo1.Text == "")
        {
            lblMsg1.Text = "Kindly enter a number";
        }
        else if (txtNo2.Text == "")
        {
            lblMsg2.Text = "Kindly enter a number";
        }
        else
        {
            lblAnswer.Text = Convert.ToString(Convert.ToDecimal(txtNo1.Text) / Convert.ToDecimal(txtNo2.Text));
            lblMsg2.Text = "";
            lblMsg1.Text = "";
            lblMsg3.Text = "";
        }
    }
}