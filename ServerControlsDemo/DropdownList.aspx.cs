using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class List : System.Web.UI.Page
{
    public object GetTabIndex { get; private set; }
    public string GetIndex { get; private set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        //PostBack : mean, is reload page second timed ?

        // if (Page.IsPostBack == false)
        if (!Page.IsPostBack)
        {
            
            ddlCountry.Items.Add(new ListItem("USA", "92"));
            ddlCountry.Items.Add(new ListItem("Canada", "99"));
        }

    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //if (txtCountry.Text != "" && txtCcode.Text != "")
        //{
        //    ddlCountry.Items.Add(new ListItem(txtCountry.Text, txtCcode.Text));
        //}
        //else
        //{
        //    lblMessage.Text = "Please enter valid Info.";
        //}
        //txtCountry.Text = "";
        //txtCcode.Text = string.Empty;

        if (txtCountry.Text == "" && txtCcode.Text == "")
        {
            lblMessage.Text = "Kindly fill value of country and code";
        }
        else if (txtCountry.Text == "")
        {
            lblMessage.Text = "Kindly fill value of country ";
        }
        else if (txtCcode.Text == "")
        {
            lblMessage.Text = "Kindly fill value of code ";
        }

        else
        {


            bool a = false;
            foreach (ListItem li in ddlCountry.Items)
            {
                if (li.Text == txtCountry.Text && li.Value == txtCcode.Text)
                {
                    a = true;
                    break;
                }
            }
            if (txtCountry.Text == "" && txtCountry.Text == "")
            {
                lblMessage.Text = "Kindly Enter Value";
            }
            else if (!a)
            {
                ddlCountry.Items.Add(new ListItem(txtCountry.Text, txtCcode.Text));
                lblMessage.Text = txtCountry.Text + " - " + txtCcode.Text + " :  " + " inserted successfully";
            }
            else
            {
                lblMessage.Text = "Record is already inserted";
            }
            txtCcode.Text = "";
            txtCountry.Text = "";
        }


    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {

        Boolean a = false;
        foreach (ListItem li in ddlCountry.Items)
        {
            if (li.Text == txtCountry.Text && li.Value == txtCcode.Text)
            {
                a = true;
                break;
            }
        }
        if (txtCountry.Text == "" && txtCcode.Text == "")
        {
            lblMessage.Text = "Kindly Enter Value OR Select Value";
        }
        else if (a)
        {
            ddlCountry.Items.Remove(new ListItem(txtCountry.Text, txtCcode.Text));
            lblMessage.Text = txtCountry.Text + " - " + txtCcode.Text + " <br/> " + " remove successfully";
        }
        else
        {
            lblMessage.Text = "Value Not Found";
        }
        txtCountry.Text = "";
        txtCcode.Text = "";

    



    //ddlCountry.Items.RemoveAt(ddlCountry.SelectedIndex);

    //txtCountry.Text = ""; 
    //txtCcode.Text = string.Empty;

    //ddlCountry.Items.Remove(new ListItem(txtCountry.Text, txtCcode.Text));


}

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        //TextBox1.Text = Convert.Tostring(DropdownList1.SelectedValue.Text);
        //TextBox1.Text = Convert.Tostring(DropdownList1.SelectedValue.VAlue);


        txtCcode.Text = ddlCountry.SelectedItem.Value.ToString();
        txtCountry.Text = ddlCountry.SelectedItem.Text.ToString();

        //btnAdd.Text = "Edit";



    }


    protected void btnShowDdl_Click(object sender, EventArgs e)
    {
        lblShowCountryList.Text = "";
        foreach (ListItem li in ddlCountry.Items)
        {
            if (li.Selected)
            {
                lblShowCountryList.Text += "<strong>" + li.Text.Trim() + " - " + li.Value.Trim() + "</strong><br/>";
            }
            else
            {
                lblShowCountryList.Text += li.Text.Trim() + " - " + li.Value.Trim() + "<br/>";
            }
        }
    }
    protected void btnClearAllDdl_Click(object sender, EventArgs e)
    {
        lblShowCountryList.Text = "";
    }
}