<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebIndexControlDemo.aspx.cs" Inherits="WebIndex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/contant/css/bootstrap.min.css" rel="stylesheet" />
    <link href="~/contant/css/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="/contant/js/bootstrap.bundle.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div >
        <h2>Index</h2>
        <ul>
        <li><asp:HyperLink ID="hlHome" runat="server" NavigateUrl="~/ServerControlsDemo/WebIndexControlDemo.aspx#home">Home</asp:HyperLink></li>
        <li><asp:HyperLink ID="hlAbout" runat="server" NavigateUrl="~/ServerControlsDemo/WebIndexControlDemo.aspx#about">About University!</asp:HyperLink></li>
        <li><asp:HyperLink ID="hlCourse" runat="server" NavigateUrl="~/ServerControlsDemo/WebIndexControlDemo.aspx#course">Courese run by university</asp:HyperLink></li>
        <li><asp:HyperLink ID="hlDepartment" runat="server" NavigateUrl="~/ServerControlsDemo/WebIndexControlDemo.aspx#department">Department</asp:HyperLink></li>
        <li><asp:HyperLink ID="hlStaff" runat="server" NavigateUrl="~/ServerControlsDemo/WebIndexControlDemo.aspx#staff">Staff</asp:HyperLink></li>
        <li><asp:HyperLink ID="hlNews" runat="server" NavigateUrl="~/ServerControlsDemo/WebIndexControlDemo.aspx#news">News</asp:HyperLink></li>
        <li><asp:HyperLink ID="hlContect" runat="server" NavigateUrl="~/ServerControlsDemo/WebIndexControlDemo.aspx#contect">Contect</asp:HyperLink></li>
        </ul>
    </div>
        <div style="text-align:center;">
            
            <div id="home"><h3>Home</h3>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Consectetur libero id faucibus nisl. Amet purus gravida quis blandit turpis cursus in hac. Purus ut faucibus pulvinar elementum integer enim neque volutpat ac. Risus sed vulputate odio ut enim blandit. Vulputate sapien nec sagittis aliquam. Tincidunt id aliquet risus feugiat in ante metus. Non consectetur a erat nam at lectus urna duis convallis. Justo donec enim diam vulputate ut pharetra sit. Dignissim sodales ut eu sem integer vitae justo eget magna. Aliquam faucibus purus in massa tempor nec feugiat nisl pretium. Neque laoreet suspendisse interdum consectetur libero id faucibus nisl. Senectus et netus et malesuada. Ut ornare lectus sit amet est placerat in. Nisl rhoncus mattis rhoncus urna neque viverra justo 
            </div>
            <div id="about"><h3>About University!</h3>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Consectetur libero id faucibus nisl. Amet purus gravida quis blandit turpis cursus in hac. Purus ut faucibus pulvinar elementum integer enim neque volutpat ac. Risus sed vulputate odio ut enim blandit. Vulputate sapien nec sagittis aliquam. Tincidunt id aliquet risus feugiat in ante metus. Non consectetur a erat nam at lectus urna duis convallis. Justo donec enim diam vulputate ut pharetra sit. Dignissim sodales ut eu sem integer vitae justo eget magna. Aliquam faucibus purus in massa tempor nec feugiat nisl pretium. Neque laoreet suspendisse interdum consectetur libero id faucibus nisl. Senectus et netus et malesuada. Ut ornare lectus sit amet est placerat in. Nisl rhoncus mattis rhoncus urna neque viverra justo nec.
            </div>
            <div id="course"><h3>Courese run by university</h3>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Consectetur libero id faucibus nisl. Amet purus gravida quis blandit turpis cursus in hac. Purus ut faucibus pulvinar elementum integer enim neque volutpat ac. Risus sed vulputate odio ut enim blandit. Vulputate sapien nec sagittis aliquam. Tincidunt id aliquet risus feugiat in ante metus. Non consectetur a erat nam at lectus urna duis convallis. Justo donec enim diam vulputate ut pharetra sit. Dignissim sodales ut eu sem integer vitae justo eget magna. Aliquam faucibus purus in massa tempor nec feugiat nisl pretium. Neque laoreet suspendisse interdum consectetur libero id faucibus nisl. Senectus et netus et malesuada. Ut ornare lectus sit amet est placerat in. Nisl rhoncus mattis rhoncus urna neque viverra justo nec.
            </div>
            <div id="department"><h3>Department</h3>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Consectetur libero id faucibus nisl. Amet purus gravida quis blandit turpis cursus in hac. Purus ut faucibus pulvinar elementum integer enim neque volutpat ac. Risus sed vulputate odio ut enim blandit. Vulputate sapien nec sagittis aliquam. Tincidunt id aliquet risus feugiat in ante metus. Non consectetur a erat nam at lectus urna duis convallis. Justo donec enim diam vulputate ut pharetra sit. Dignissim sodales ut eu sem integer vitae justo eget magna. Aliquam faucibus purus in massa tempor nec feugiat nisl pretium. Neque laoreet suspendisse interdum consectetur libero id faucibus nisl. Senectus et netus et malesuada. Ut ornare lectus sit amet est placerat in. Nisl rhoncus mattis rhoncus urna neque viverra justo 
            </div>
            <div id="staff"><h3>Staff</h3>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Consectetur libero id faucibus nisl. Amet purus gravida quis blandit turpis cursus in hac. Purus ut faucibus pulvinar elementum integer enim neque volutpat ac. Risus sed vulputate odio ut enim blandit. Vulputate sapien nec sagittis aliquam. Tincidunt id aliquet risus feugiat in ante metus. Non consectetur a erat nam at lectus urna duis convallis. Justo donec enim diam vulputate ut pharetra sit. Dignissim sodales ut eu sem integer vitae justo eget magna. Aliquam faucibus purus in massa tempor nec feugiat nisl pretium. Neque laoreet suspendisse interdum consectetur libero id faucibus nisl. Senectus et netus et malesuada. Ut ornare lectus sit amet est placerat in. Nisl rhoncus mattis rhoncus urna neque viverra justo 
            </div>
            <div id="news"><h3>News</h3>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Consectetur libero id faucibus nisl. Amet purus gravida quis blandit turpis cursus in hac. Purus ut faucibus pulvinar elementum integer enim neque volutpat ac. Risus sed vulputate odio ut enim blandit. Vulputate sapien nec sagittis aliquam. Tincidunt id aliquet risus feugiat in ante metus. Non consectetur a erat nam at lectus urna duis convallis. Justo donec enim diam vulputate ut pharetra sit. Dignissim sodales ut eu sem integer vitae justo eget magna. Aliquam faucibus purus in massa tempor nec feugiat nisl pretium. Neque laoreet suspendisse interdum consectetur libero id faucibus nisl. Senectus et netus et malesuada. Ut ornare lectus sit amet est placerat in. Nisl rhoncus mattis rhoncus urna neque viverra justo 
            </div>
            <div id="contect"><h3>contect</h3>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Consectetur libero id faucibus nisl. Amet purus gravida quis blandit turpis cursus in hac. Purus ut faucibus pulvinar elementum integer enim neque volutpat ac. Risus sed vulputate odio ut enim blandit. Vulputate sapien nec sagittis aliquam. Tincidunt id aliquet risus feugiat in ante metus. Non consectetur a erat nam at lectus urna duis convallis. Justo donec enim diam vulputate ut pharetra sit. Dignissim sodales ut eu sem integer vitae justo eget magna. Aliquam faucibus purus in massa tempor nec feugiat nisl pretium. Neque laoreet suspendisse interdum consectetur libero id faucibus nisl. Senectus et netus et malesuada. Ut ornare lectus sit amet est placerat in. Nisl rhoncus mattis rhoncus urna neque viverra justo 
            </div>
        </div>
    </form>
</body>
</html>
