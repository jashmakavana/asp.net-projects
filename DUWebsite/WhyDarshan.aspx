<%@ Page Title="" Language="C#" MasterPageFile="~/contant/DUMasterPage.master" AutoEventWireup="true" CodeFile="WhyDarshan.aspx.cs" Inherits="DUWebsite_WhyDarshan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpnHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpnMainContent" Runat="Server">
    <br />
<div class="container-fluid">
    <div class="row">
        <div class="col-md-12" style="background-color:black">
            <h2 class="text-white">Why Study at Darshan ?</h2>
            
         </div>
    </div>
        <br /><br />
    <div class="row">
        <div class="col-md-6">
            <div class="col-md-12">
                <strong>Dedicated Faculties</strong>
                <p class="text-justify">We proudly hold the record of lowest attrition rate till date to accomplish dedication.</p><hr />
                <strong>Skill Development Activities</strong>
                <p class="text-justify">We address the opportunities and challenges to encounter new demands of changing global and innovative technologies.</p><hr />
                <strong>Excellent Placement Record</strong>
                <p class="text-justify">We proudly hold a good placement record and assure that each eligible student gets an opportunity to be placed in a recognized firm.</p><hr />
                <strong>Disciplined Environment</strong>
                <p class="text-justify">Mobile App for parents to track the progression of students. Mobile phones and related gadgets are strictly prohibited for students within the institute premises.</p><hr />
                <strong>Industry Interaction & Consultancy Work</strong>
                <p class="text-justify">We possess Civil Consultancy Cell, Energy Management Cell & ASWDC which provide a platform for students to enhance their technical & industrial skills.</p><hr />
                <strong>Extra-curricular</strong>
                <p class="text-justify">We provide a platform for the cultural fest Udaan (Annual day), Thanganaat (Navratri festival), Frolic (Technical Fest), Sprint (Annual Sports week), etc.</p><hr />

            </div>       
        </div>
        <div class="col-md-6">
            <div class="col-md-12 img-fluid">
                        <asp:Image ID="imgWhyDarshan" runat="server" ImageUrl="~/contant/images/WhyDarshan.jpg" Height="700" Width="642"/>                          
                      
            </div><br />
        </div>
        <div class="col-md-12">
            <h3>Our Pedagogy</h3><hr />
            <asp:Image ID="imgPedagogy" runat="server" ImageUrl="~/contant/images/Pedagogy.png" Height="700" Width="1150"/>
            <ul>
                <li>Coverage of syllabus within the time frame.</li>
                <li>Student centric approach in teaching, Extra tutorials for weak students.</li>
                <li>Students are encouraged to participate in seminars, workshops, projects, Technical and Non-Technical Events etc.</li>
                <li>Regular quality assessment through weekly test, mid-semester exams, viva etc.</li>
                <li>In-depth preparation of subject by teacher to make it more interesting and easy.</li>
                <li><b>Freedom to faculties for implementing innovative ideas in teaching & learning methodologies.</b></li>
                <li>Expert lectures by industry experts & top rated academicians.</li>
                <li>Industrial visits to various industries.</li>
                <li>Extensive use of cutting edge tools like Moodle, NPTEL videos etc.</li>
            </ul>
        </div>
    </div>
</div>  
</asp:Content>

