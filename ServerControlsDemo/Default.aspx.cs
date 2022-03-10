using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        foreach(ListItem li in lbCountry.Items)
        {
            if (li.Selected == true)
            {
                lblMessage.Text += "<strong>" + li.Value.Trim() + "-" +
                    li.Text.Trim() + "</strong><br />";
            }
            else
            {
                lblMessage.Text += li.Value.Trim() + " - " +
                                   li.Text.Trim() + "<br />";
            }
        }
        }

    protected void btnRight_Click(object sender, EventArgs e)
    {
        foreach (ListItem li in lbCountry.Items)
        {
            if (li.Selected == true)
            {
                
                
                lb2Country.Items.Add(li);
                lblList.Text = "";
            }
            else
            {
                lblList.Text = "Please select atleast one country";
            }
        }
        foreach (ListItem li in lb2Country.Items)
        {
            if (li.Selected == true)
            {

                lbCountry.Items.Remove(li);
                lblList.Text = "";
                
            }
            else
            {
                lblList.Text = "Please selecet atleast one country";
            }
        }   
        
    }



    protected void btnLeft_Click(object sender, EventArgs e)
    {
        foreach (ListItem li in lb2Country.Items)
        {
            if (li.Selected == true)
            {
                lbCountry.Items.Add(li);
                lblList.Text = "";
            }
            else
            {
                lblList.Text = "Please select atleast one country";

            }
        }
        foreach (ListItem li in lbCountry.Items)
        {
            if (li.Selected == true)
            {
                lb2Country.Items.Remove(li);
                lblList.Text = "";
            }
            else
            {
                lblList.Text = "Please select atleast one country";
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (txt1.Text == "")
        {
            lblStatus.Text = "Enter country name";
        }
        else if (txt2.Text == "")
        {
            lblStatus.Text = "Enter country code";
        }
        else if (txt1.Text == "" && txt2.Text == "")
        {
            lblStatus.Text = "Enter value of country and code";
        }
        else { 
        //lbCountry.Items.Add(new ListItem(txt1.Text, txt2.Text));
        //txt1.Text = "";
        //txt2.Text = "";
        Boolean a = false;
        foreach (ListItem li in lbCountry.Items)
        {
            if (li.Text == txt1.Text && li.Value == txt2.Text)
            {
                a=true;
                break;
            }
        }
        if (txt1.Text == "" && txt2.Text == "")
        {
            lblStatus.Text = "Kindly Enter Value";
        }
        else if (!a)
        {
            lbCountry.Items.Add(new ListItem(txt1.Text, txt2.Text));
            lblStatus.Text = "Record inserted successfully";
            lblList.Text = "";
        }
        
        else
        {
            lblStatus.Text = "Record is already inserted";
        }
        txt1.Text = "";
        txt2.Text = "";
    }
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        //lbCountry.Items.Remove(new ListItem(txt1.Text, txt2.Text));
        //txt1.Text = "";
        //txt2.Text = "";
        
        

            Boolean a = false;
            foreach (ListItem li in lbCountry.Items)
            {
                if (li.Text == txt1.Text && li.Value == txt2.Text)
                {
                    a = true;
                    break;
                }
            }
            if (txt1.Text == "" && txt2.Text == "")
            {
                lblStatus.Text = "Kindly enter value";
            }


            else if (a)
            {
                lbCountry.Items.Remove(new ListItem(txt1.Text, txt2.Text));
                lblStatus.Text = "Record remove successfully";
            }
            else if (txt1.Text == "")
            {
                lblStatus.Text = "Enter country name";
            }
            else if (txt2.Text == "")
            {
                lblStatus.Text = "Enter value of code";
            }
            else
            {
                lblStatus.Text = "Value not found";
            }
            txt1.Text = "";
            txt2.Text = "";
        }
    

    protected void btnAllRight_Click(object sender, EventArgs e)
    {
        foreach (ListItem li in lbCountry.Items)
        {
                lb2Country.Items.Add(li);
                lblList.Text = "";
           
        }
        foreach (ListItem li in lb2Country.Items)
        {
                lbCountry.Items.Remove(li);
                lblList.Text = "";
            
        }
    }
    protected void btnAllLeft_Click(object sender, EventArgs e)
    {
        foreach (ListItem li in lb2Country.Items)
        {
            lbCountry.Items.Add(li);
            lblList.Text = "";

        }
        foreach (ListItem li in lbCountry.Items)
        {
            lb2Country.Items.Remove(li);
            lblList.Text = "";

        }
    }
    protected void btncChange_Click(object sender, EventArgs e)
    {
        //if(txt2.Text==newtxt2.Text)
        if (txt2.Text !="" && txt1.Text!="" && newtxt1.Text!="" && newtxt2.Text!="")
        {
            lbCountry.Items.Remove(new ListItem(txt1.Text,txt2.Text));
            lbCountry.Items.Add(new ListItem(newtxt1.Text,newtxt2.Text));
            lblList.Text = "";
            txt1.Text = "";
            txt2.Text = "";
            newtxt1.Text = "";
            newtxt2.Text = "";
        }
        else
        {
            lblList.Text = "Please enter correct country code";
        }
        

        
    }
    protected void lbCountry_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}