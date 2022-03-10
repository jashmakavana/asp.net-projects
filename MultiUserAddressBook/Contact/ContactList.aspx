<%@ Page Title="" Language="C#" MasterPageFile="~/contant/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactList.aspx.cs" Inherits="MultiUserAddressBook_Contact_ContactList" %>

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
     <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" ForeColor="red" ID="lblMessage" EnableViewState="false"></asp:Label>
        </div>
    </div>
    <br />
    <div class="container-fluid">
             <div class="row">
                <div class="col-md-12">
                    <div style="text-align: left;">   <!--<div align="right"; >-->
                        <asp:HyperLink runat="server" ID="hlAddContact" Text="Add New Contact" CssClass="btn btn-dark btn-sm" NavigateUrl="~/MultiUserAddressBook/Contact/ContactAddEdit.aspx" />
                    </div>
                    <div>
                        <div class="scroll">
                        <asp:GridView ID="gvContact" runat="server" OnRowCommand="gvContact_RowCommand" AutoGenerateColumns="False" CssClass="table table-hover" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="ContactID" HeaderText="ID"/>
                                <asp:BoundField DataField="CountryName" HeaderText="Country Name"/>
                                <asp:BoundField DataField="StateName" HeaderText="StateName"/>
                                <asp:BoundField DataField="CityName" HeaderText="CityName"/>
                                <asp:BoundField DataField="ContactCategoryName" HeaderText="ContactCategoryName"/>
                                <asp:BoundField DataField="ContactName" HeaderText="Contact"/>
                                <asp:BoundField DataField="ContactNo" HeaderText="Contact No"/>
                                <%--<asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="btnPhotosDelete" CssClass="alert-dark" CommandName="DeletePhoto" CommandArgument='<%# Eval("ContactPhotoPath") %>' Text="Delete" />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:BoundField DataField="WhatsAppNo" HeaderText="WhatsAppNo"/>
                                <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" DataFormatString="{0:dd/MM/yyyy}"  />
                                <asp:BoundField DataField="Email" HeaderText="Email"/>
                                <asp:BoundField DataField="Age" HeaderText="Age"/>
                                <asp:BoundField DataField="Address" HeaderText="Address"/>
                                <asp:BoundField DataField="BloodGroup" HeaderText="BloodGroup"/>
                                <asp:BoundField DataField="FacebookID" HeaderText="FacebookID"/>
                                <asp:BoundField DataField="LinkedINID" HeaderText="LinkedINID"/>
                                <asp:TemplateField HeaderText="Contact Image">
                                    <ItemTemplate>
                                        <asp:Image runat="server" ID="imgContactPhotoPath"  style="padding:3px;" ImageUrl='<%# Eval("ContactPhotoPath") %>' Height="100"/> <!-- Visible="false" -->
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:BoundField DataField="ContactPhotoPath" HeaderText="Contact PhotoPath"/>
                                --%>
                                <asp:BoundField DataField="PhotoAttribute" HeaderText="Photo Attribute" />
                                <asp:TemplateField HeaderText="Delete"> 
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactID").ToString() %>'/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" NavigateUrl='<%# "~/MultiUserAddressBook/Contact/ContactAddEdit.aspx?ContactID=" + Eval("ContactID").ToString().Trim() %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
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
                            </div>
                    </div>
                </div>
            </div>
    </div>
</asp:Content>

