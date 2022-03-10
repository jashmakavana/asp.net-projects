<%@ Page Title="" Language="C#" MasterPageFile="~/contant/AddressBook.master" AutoEventWireup="true" CodeFile="ContactFileLists.aspx.cs" Inherits="AdminPanel_ContactFileUpload_ContactFileLists" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
     <div class="container">
                <div class="row">
                    <div class="col-md-12">
                           <h2>Contact File Upload List</h2> 
                    </div>
                </div>
            </div><br />
        <div class="container">
             <div class="row">
                <div class="col-md-12">
                    <div style="text-align: left;">   <!--<div align="right"; >-->
                        <asp:HyperLink runat="server" ID="hlAddCity" Text="Add New Contact File " CssClass="btn btn-dark btn-sm" NavigateUrl="~/AdminPanel/ContactFileUpload/ContactFileUploadAddEdit.aspx" />
                    </div>
                    <asp:GridView ID="gvContactFileUpload" runat="server" BorderWidth="2" BorderColor="Blue" BorderStyle="dashed" AutoGenerateColumns="false" CssClass="table table-hover " CellPadding="4" ForeColor="#333333" OnRowCommand="gvContactFileUpload_RowCommand" >                            
                            <Columns>    
                                <asp:BoundField DataField="ContactFileUploadID"     HeaderText="Contact File UploadID"  />         
                                <asp:BoundField DataField="ContactName" HeaderText="Contact Name"/>
                                <asp:TemplateField HeaderText="Contact Image">
                                    <ItemTemplate>
                                        <asp:Image runat="server" ID="imgContactPhotoPath"  style="padding:3px;" ImageUrl='<%# Eval("ContactPhotoPath") %>' Height="100"/> <!-- Visible="false" -->
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="btnDelete" CssClass="alert-dark" CommandName="DeletePhoto" CommandArgument='<%# Eval("ContactPhotoPath") %>' Text="Delete" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ContactPhotoPath" HeaderText="Contact Photo Path" />
                            </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="true" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="true" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" HorizontalAlign="Center" ForeColor="White" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="true" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                    <asp:Label runat="server" ID="lblMessage" EnableViewState="false" ForeColor="Red"></asp:Label>
                </div>
            </div>
    </div>
       <%-- <div class="row">
                        <div class="col-md-12">
                    <asp:DataList runat="server" ID="dlContact" DataKeyField="ContactFileUploadID">
                        <ItemTemplate>
                            Contact File UploadID : 
                            <asp:Label runat="server" ID="lblContactFileUploadID" Text='<%# Eval("ContactFileUploadID") %>'></asp:Label>
                            <br />
                            Contact Name : 
                            <asp:Label runat="server" ID="lblContactName" Text='<%# Eval("ContactName") %>'></asp:Label>
                            <br />
                            Contact Photo Path : 
                            <asp:Label runat="server" ID="lblContactPhotoPath" Text='<%# Eval("ContactPhotoPath") %>'></asp:Label>
                            <br />
                        </ItemTemplate>
                    </asp:DataList>
                        </div>
                    </div>--%>
</asp:Content>

