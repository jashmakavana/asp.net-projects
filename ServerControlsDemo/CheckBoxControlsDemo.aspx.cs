using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ServerControlsDemo_CheckBoxControlsDemo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnDisplay_Click(object sender, EventArgs e)
    {
        if (chkCricket.Checked == true)
            lblMessage.Text += "Cricket,";
        if (ChkReading.Checked == true)
            lblMessage.Text += "Reading,";
        if (ChkDancing.Checked == true)
            lblMessage.Text += "Dancing,";
        
    }
}