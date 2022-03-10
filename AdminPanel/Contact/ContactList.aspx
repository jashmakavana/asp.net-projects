<%@ Page Title="" Language="C#" MasterPageFile="~/contant/AddressBook.master" AutoEventWireup="true" CodeFile="ContactList.aspx.cs" Inherits="AdminPanel_Contact_ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <style>
        .scroll
        {
            width:90%;
            overflow:scroll;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="row">
        <div class="col-md-12">
               <h2>Contact List</h2> 
        </div>
    </div>
    <div class="container-fluid">
             <div class="row">
                <div class="col-md-12">
                    <div style="text-align: left;">   <!--<div align="right"; >-->
                        <asp:HyperLink runat="server" ID="hlAddContact" Text="Add New Contact" CssClass="btn btn-dark btn-sm" NavigateUrl="~/AdminPanel/Contact/ContactAddEdit.aspx" />
                    </div>
                    <div>
                        <div class="scroll">
                        <asp:GridView ID="gvContact" runat="server" OnRowCommand="gvContact_RowCommand" AutoGenerateColumns="false" CssClass="table table-hover">
                            <Columns>
                                <asp:BoundField DataField="ContactID" HeaderText="ID"/>
                                <asp:BoundField DataField="CountryName" HeaderText="Country Name"/>
                                <asp:BoundField DataField="StateName" HeaderText="StateName"/>
                                <asp:BoundField DataField="CityName" HeaderText="CityName"/>
                                <asp:BoundField DataField="ContactCategoryName" HeaderText="ContactCategoryName"/>
                                <asp:BoundField DataField="ContactName" HeaderText="Contact"/>
                                <asp:BoundField DataField="ContactNo" HeaderText="Contact No"/>
                                <asp:BoundField DataField="WhatsAppNo" HeaderText="WhatsAppNo"/>
                                <asp:BoundField DataField="BirthDate" HeaderText="BirthDate"
                                                    DataFormatString="{0:dd/MM/yyyy}"  />
                                <asp:BoundField DataField="Email" HeaderText="Email"/>
                                <asp:BoundField DataField="Age" HeaderText="Age"/>
                                <asp:BoundField DataField="Address" HeaderText="Address"/>
                                <asp:BoundField DataField="BloodGroup" HeaderText="BloodGroup"/>
                                <asp:BoundField DataField="FacebookID" HeaderText="FacebookID"/>
                                <asp:BoundField DataField="LinkedINID" HeaderText="LinkedINID"/>
                                <asp:TemplateField HeaderText="Delete"> 
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactID").ToString() %>'/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" NavigateUrl='<%# "~/AdminPanel/Contact/ContactAddEdit.aspx?ContactID=" + Eval("ContactID").ToString().Trim() %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                            </div>
                    </div>
                </div><br />
            </div>
    
    <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" ForeColor="red" ID="lblMessage" EnableViewState="false"></asp:Label>
        </div>
    </div>
    </div>
</asp:Content>

