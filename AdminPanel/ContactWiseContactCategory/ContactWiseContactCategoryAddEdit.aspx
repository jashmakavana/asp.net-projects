<%@ Page Title="" Language="C#" MasterPageFile="~/contant/AddressBook.master" AutoEventWireup="true" CodeFile="ContactWiseContactCategoryAddEdit.aspx.cs" Inherits="AdminPanel_ContactWiseContactCategory_ContactWiseContactCategoryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>Contact Wise ContactCategory Add Edit Page</h2>
        </div>
    </div><br />
    <div class="row">
          <div class="col-md-8">
            <div class="row">
                    <div class="col-md-4">
                        Contact Name : 
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" ID="txtContactName" CssClass="form-control" />
                            <asp:RequiredFieldValidator id="rfvContactName" runat="server"
                            ControlToValidate="txtContactName"
                            ErrorMessage="Please field Country name."
                            ForeColor="Red">
                            </asp:RequiredFieldValidator>
                    </div>
                </div>
                <br />
            <div class="row">
                    <div class="col-md-4">
                        Upload Photo : 
                    </div>
                    <div class="col-md-8">
                        <asp:FileUpload ID="fuContactPhotoPath" runat="server" /> 
                        <!-- <asp:TextBox runat="server" ID="txtContactPhotoPath" CssClass="form-control" />
            
                            <asp:RequiredFieldValidator id="rfvContactPhotoPath" runat="server"
                            ControlToValidate="txtContactPhotoPath"
                            ErrorMessage="Please field Contact Photo."
                            ForeColor="Red">
                            </asp:RequiredFieldValidator>-->
                    </div>
                </div> 
            <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-8">
                        <asp:Label runat="server" CssClass="btn-outline-danger" ID="lblMessage" EnableViewState="false" />
                    </div>
                </div>
                <br />
            <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-8">
                        <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-dark btn-sm" OnClick="btnSave_Click" />       
                    </div>
                </div>
        </div>
          
    </div>
    <div class="col-md-12">
            <h5>Contact Category</h5>  
            <asp:CheckBoxList runat="server" ID="cblContactCategoryID"/>       
          </div>
</asp:Content>

