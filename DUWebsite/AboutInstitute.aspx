<%@ Page Title="" Language="C#" MasterPageFile="~/contant/DUMasterPage.master" AutoEventWireup="true" CodeFile="AboutInstitute.aspx.cs" Inherits="DUWebsite_AboutDU" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpnHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpnMainContent" Runat="Server">
    <br />
<div class="container-fluid">
    <div class="row">
        <div class="col-md-12" style="background-color:black">
            <h2 class="text-white">About Institute</h2>
         </div>
    </div>
        <br />

     <div class="row">
        <div class="col-md-12">
               <h4>About Darshan Institute of Engineering & Technology</h4><hr />
        </div>      
        <div class="col-md-12 text-justify">
            <p>Darshan Institute of Engineering & Technology is a prominent institute offers a broad slate of academic programs and professional courses for undergraduate, graduate and postgraduate programs in engineering. Our institute is Located in peaceful and sylvan surroundings with distinctive collegiate structure, about 19 km from Rajkot, Gujarat, India.
            <br />
            <br />
            The Institute is affiliated to the Gujarat Technological University and approved by the AICTE, New Delhi. The Institute was established in the year 2009, by Shree G.N.Patel Education & Charitable Trust.
                <br /><br />
            Darshan is managed by the technical experienced & well-qualified management team, under the leadership of Dr. R.G. Dhamsaniya. From its inception, the college has grown steadily and is imparting quality technical education.
                <br /><br />
            The Institute has well experienced, highly qualified and dedicated faculty for committed education. All head of the departments and senior faculties are reputed industrial consultants.
                <br /><br />
            We, the team of Darshan perceive that for education to be consistently significant, it needs to be managed efficiently. The management team at Darshan drafts strategies and guidelines oversees its implementation and takes charge of the regulated administration together with long-term plans.
            </p><br /><br />
        </div>
        <div class="row">
                     <div class="col-md-6 text-center">
                        <div class="col-md-12">                          
                            <span>Affiliated to</span><br />
                            <strong>Gujarat Technological University
                           (GTU) <br />Ahmedabad</strong><br />
                           <hr />
                            <asp:Image ID="imgGtuLogo" runat="server" ImageUrl="~/contant/images/GTU.png" Height="150px" Width="180px" />
                        </div>
                    </div>                    
                    <div class="col-md-6 text-center ">
                            <div class="col-md-12">
                                 Approved by<br />
                                <strong>All India Council for Technical<br />
                                Education (AICTE), New Delhi<br /></strong><hr />
                                <asp:Image ID="imgLogo" runat="server" ImageUrl="~/contant/images/AICTE.png" Height="150px" Width="180px" />
                            </div>                           
                    </div>
            </div>             
     </div><br /><br /><br /><br />
  </div> 
</asp:Content>

