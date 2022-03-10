<%@ Page Title="" Language="C#" MasterPageFile="~/contant/AddressBook.master" AutoEventWireup="true" CodeFile="ContactCategoryList.aspx.cs" Inherits="AdminPanel_ContactCategory_ContactCategoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="row">
        <div class="col-md-12">
               <h2>ContactCategory List</h2> 
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div style="text-align: left;">   <!--<div align="right"; >-->
                <asp:HyperLink runat="server" ID="hlAddContactCategory" Text="Add New Contact Category" CssClass="btn btn-dark btn-sm" NavigateUrl="~/AdminPanel/ContactCategory/ContactCategoryAddEdit.aspx" />
            </div>
            <div>
                <asp:GridView ID="gvContactCategory" runat="server" OnRowCommand="gvContactCategory_RowCommand" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="ContactCategoryID" HeaderText="ID"/>
                        <asp:BoundField DataField="ContactCategoryName" HeaderText="ContactCategory"/>
                        <asp:TemplateField HeaderText="Delete"> 
                            <ItemTemplate>
                                <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactCategoryID").ToString() %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" NavigateUrl='<%# "~/AdminPanel/ContactCategory/ContactCategoryAddEdit.aspx?ContactCategoryID=" + Eval("ContactCategoryID").ToString().Trim() %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div><br />
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" ForeColor="red" ID="lblMessage" EnableViewState="false"></asp:Label>
        </div>
    </div>
</asp:Content>

