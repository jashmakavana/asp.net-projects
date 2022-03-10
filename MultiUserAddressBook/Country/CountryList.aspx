<%@ Page Title="" Language="C#" MasterPageFile="~/contant/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="CountryList.aspx.cs" Inherits="MultiUserAddressBook_Country_CountryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="row">
        <div class="col-md-12">
               <h2>Country List</h2> 
        </div>
    </div>
    <br/>
    <div class="row">
            <div class="col-md-12">
                <asp:Label runat="server" ForeColor="red" ID="lblMessage" EnableViewState="false"></asp:Label>
            </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div style="text-align:left;">
                <asp:HyperLink runat="server" ID="hlAddCountry" Text="Add New Country" CssClass="btn btn-dark btn-sm" NavigateUrl="~/MultiUserAddressBook/Country/CountryAddEdit.aspx" />
            </div>
            <div>
                <asp:GridView ID="gvCountry" runat="server" OnRowCommand="gvCountry_RowCommand" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
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
                                <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" NavigateUrl='<%# "~/MultiUserAddressBook/Country/CountryAddEdit.aspx?CountryID=" + Eval("CountryID").ToString().Trim() %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

