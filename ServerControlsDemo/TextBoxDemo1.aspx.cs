using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ServerControlsDemo_TextBoxDemo1aspx : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCopy_Click(object sender, EventArgs e)
    {
        txtNo2.Text = txtNo1.Text;
    }
}