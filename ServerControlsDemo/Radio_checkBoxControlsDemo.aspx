<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Radio_checkBoxControlsDemo.aspx.cs" Inherits="Radio_check" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
        <div>

<%---------------------------------------------RADIO---------------------------------------------%>

    
            <asp:RadioButton ID="rbDiet" runat="server" Text="DIET" GroupName="Department" AutoPostBack="True" OnCheckedChanged="rbDiet_CheckedChanged"/>
            <asp:RadioButton ID="rbDietds" runat="server" Text="DIETDS  " GroupName="Department" AutoPostBack="True" OnCheckedChanged="rbDietds_CheckedChanged" /><br /><br />
       
             <div><asp:RadioButton ID="rbCS" runat="server" Text="Degree - Computer Engineering" visible="false" GroupName="Degree"/></div>
             <div><asp:RadioButton ID="rbME" runat="server" Text="Degree - Mechanical Engineering" visible="false" GroupName="Degree"/></div>
             <div><asp:RadioButton ID="rbEE" runat="server" Text="Degree - Electrical Engineering" visible="false" GroupName="Degree"/></div>
             <div><asp:RadioButton ID="rbCE" runat="server" Text="Degree - Civil Engineering" visible="false" GroupName="Degree"/></div>
        
            <div>
             <div><asp:RadioButton ID="rbDCS" runat="server" Text="Diploma - Computer Engineering" visible="false" GroupName="Deploma"/></div>
             <div><asp:RadioButton ID="rbDME" runat="server" Text="Diploma - Mechannical Engineering" visible="false" GroupName="Deploma"/></div>
             <div><asp:RadioButton ID="rbDEE" runat="server" Text="Diploma - Electrical Engineering" visible="false" GroupName="Deploma"/> </div>
             <div><asp:RadioButton ID="rbDCE" runat="server" Text="Diploma - Civil Engineering" visible="false" GroupName="Deploma"/></div>
            </div>
            <asp:Button ID="btnClickR" runat="server" Text="Submit" OnClick="btnClickR_Click"/><br /><br />
            <asp:Label ID="lblMsgR" runat="server" ForeColor="#FF3300" ></asp:Label>

        <hr />

<%---------------------------------------------CHECK-BOX---------------------------------------------%>

        <div>
        <asp:CheckBox ID="chkDiet" runat="server"  Text="DIET" AutoPostBack="True" OnCheckedChanged="chkDiet_CheckedChanged" />
        <asp:CheckBox ID="chkDietds" runat="server" Text="DIETDS" AutoPostBack="True" OnCheckedChanged="chkDietds_CheckedChanged" />
        <asp:CheckBox ID="chkAll" runat="server" Text="Select All" AutoPostBack="True" OnCheckedChanged="chkAll_CheckedChanged"  />

         <div><asp:CheckBox ID="chkCS" runat="server" Text="Degree - Computer Engineering" visible="false" /></div>
         <div><asp:CheckBox ID="chkME" runat="server" Text="Degree - Mechanical Engineering" visible="false" /></div>
         <div><asp:CheckBox ID="chkEE" runat="server" Text="Degree - Electrical Engineering" visible="false" /></div>
         <div><asp:CheckBox ID="chkCE" runat="server" Text="Degree - Civil Engineering" visible="false" /></div>

         <div><asp:CheckBox ID="chkDCS" runat="server" Text="Diploma - Computer Engineering" visible="false" /></div>
         <div><asp:CheckBox ID="chkDME" runat="server" Text="Diploma - Mechannical Engineering" visible="false" /></div>
         <div><asp:CheckBox ID="chkDEE" runat="server" Text="Diploma - Electrical Engineering" visible="false" /> </div>
         <div><asp:CheckBox ID="chkDCE" runat="server" Text="Diploma - Civil Engineering" visible="false" /></div>
        

         <asp:Button ID="btnClickc" runat="server" Text="Submit" OnClick="btnClickc_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            &nbsp;
        

        
            <asp:Label ID="lblMsgChk" runat="server" ForeColor="#FF3300" ViewStateMode="Enabled" ></asp:Label>
            
        </div>


        
    </div>
    </form>
</body>
</html>
