<%@ Page Title="" Language="C#" MasterPageFile="~/contant/AddressBook.master" AutoEventWireup="true" CodeFile="CountryList.aspx.cs" Inherits="AdminPanel_Country_CountryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="row">
        <div class="col-md-12">
               <h2>Country List</h2> 
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div style="text-align:left;">
                <asp:HyperLink runat="server" ID="hlAddCountry" Text="Add New Country" CssClass="btn btn-dark btn-sm" NavigateUrl="~/AdminPanel/Country/CountryAddEdit.aspx" />
            </div>
            <div>
                <asp:GridView ID="gvCountry" runat="server" OnRowCommand="gvCountry_RowCommand" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="CountryID" HeaderText="ID"/>
                        <asp:BoundField DataField="CountryName" HeaderText="Country"/>
                        <asp:BoundField DataField="CountryCode" HeaderText="Country Code"/>
                        <asp:TemplateField HeaderText="Delete"> 
                            <ItemTemplate>
                                <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("CountryID").ToString() %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" NavigateUrl='<%# "~/AdminPanel/Country/CountryAddEdit.aspx?CountryID=" + Eval("CountryID").ToString().Trim() %>' />
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

