<%@ Page Title="" Language="C#" MasterPageFile="~/contant/AddressBook.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="AdminPanel_City_CityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="row">
        <div class="col-md-12">
               <h2>City List</h2> 
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div style="text-align: left;">   <!--<div align="right"; >-->
                <asp:HyperLink runat="server" ID="hlAddCity" Text="Add New City" CssClass="btn btn-dark btn-sm" NavigateUrl="~/AdminPanel/City/CityAddEdit.aspx" />
            </div>
            <div>
                <asp:GridView ID="gvCity" runat="server"  OnRowCommand="gvCity_RowCommand" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="CityID" HeaderText="ID"/>                       
                        <asp:BoundField DataField="StateName" HeaderText="State Name"/>
                        <asp:BoundField DataField="CityName" HeaderText="City Name"/>
                        <asp:BoundField DataField="StdCode" HeaderText="STD Code"/>
                        <asp:BoundField DataField="PinCode" HeaderText="Pin Code"/>
                        <asp:TemplateField HeaderText="Delete"> 
                            <ItemTemplate>
                                <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("CityID").ToString() %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" NavigateUrl='<%# "~/AdminPanel/City/CityAddEdit.aspx?CityID=" + Eval("CityID").ToString().Trim() %>' />
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

