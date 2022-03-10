<%@ Page Title="" Language="C#" MasterPageFile="~/contant/AddressBook.master" AutoEventWireup="true" CodeFile="StateList.aspx.cs" Inherits="AdminPanel_State_StateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server"> 
    <div class="row">
        <div class="col-md-12">
               <h2>State List</h2> 
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div style="text-align: left;">   <!--<div align="right"; >-->
                <asp:HyperLink runat="server" ID="hlAddState" Text="Add New State" CssClass="btn btn-dark btn-sm" NavigateUrl="~/AdminPanel/State/StateAddEdit.aspx" />
            </div>
            <div>
                <asp:GridView ID="gvState" runat="server" OnRowCommand="gvState_RowCommand" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="StateID" HeaderText="ID"/>
                        <asp:BoundField DataField="CountryName" HeaderText="Country"/>
                        <asp:BoundField DataField="StateName" HeaderText="State"/>
                        <asp:BoundField DataField="StateCode" HeaderText="StateCode"/>
                        <asp:TemplateField HeaderText="Delete"> 
                            <ItemTemplate>
                                <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("StateID").ToString() %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" NavigateUrl='<%# "~/AdminPanel/State/StateAddEdit.aspx?StateID=" + Eval("StateID").ToString().Trim() %>' />
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

