<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="New_EmailCampaign.Dashboard" %>
<%@ Register TagPrefix="uc" TagName="Spinner" Src="~/Common_Menu.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

       <link href="assets/css/bootstrap.css" rel="stylesheet" />
    <link href="assets/css/font-awesome.css" rel="stylesheet" />
    <link href="assets/js/morris/morris-0.4.3.min.css" rel="stylesheet" />
    <link href="assets/css/custom-styles.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />

<script language="javascript">
     function Clearuserinput1() {       
          alert('Information Successfully Saved');
     }
    </script>
       <script src="assets/js/jquery-1.10.2.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    <script src="assets/js/jquery.metisMenu.js"></script>
    <script src="assets/js/morris/raphael-2.1.0.min.js"></script>
    <script src="assets/js/morris/morris.js"></script>
    <script src="assets/js/custom-scripts.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <uc:Spinner ID="Spinner1"
            runat="server"
            MinValue="1"
            MaxValue="10" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
    <div id="page-wrapper">
            <div id="page-inner">


                <div class="row padtp30">
                    <div class="col-md-12">
                        <h1 class="page-header">
                            Dashboard
                        </h1>
                    </div>
                </div>
                <!-- /. ROW  -->
				<div class="row">
                    <div class="clearfix padtp25">
                     	<div class="col-lg-6">
                          <div class="panel panel-default">
                                <div class="panel-heading">
                                    Donut Chart - Campaign Status
                                </div>
                                <div class="panel-body">
                                    <div id="morris-donut-chart"></div>
                                </div>
                          </div> 
                         </div>
                         <div class="col-lg-6">
                          <div class="panel panel-primary">
                                <div class="panel-heading">
                                   Campaign Status Details
                                </div>
                                <div class="panel-body">
                                    <p>The Email Dashboard will appear and display the status of any email sent from the
Email Campaign system.</p>
 <p><strong>Details:</strong>  Shows the full history on all emails that were processed through the system.</p>
 <p><strong>Emails:</strong> Shows the total number of emails that were processed.</p>
 <p><strong>Status:</strong> Shows how many emails were sent, how many emails failed, and how many
 emails, if any, bounced (email with failed delivery report).</p>
<p><strong>Created:</strong> Shows the date and time the email was created.</p>
<p><strong>Send:</strong>  Shows the date and time the email was sent</p>

                                     
                                </div>                                
                            </div> 
                         </div>                 
                     </div>              
                </div>
                <asp:UpdatePanel ID="upGrdCustomers" runat="server" UpdateMode="Always">
                                <ContentTemplate>
                                     <div class="well well-sm bg-well">
                 <div class="clearfix padbt15">
                    
                       <div class="col-lg-3"> <h4>Recently Sent Campaigns</h4></div>
                       <div class="col-lg-4 padtp15">
                       		<div class="dropdown">
                                   <asp:DropDownList ID="ddlCampaign" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCampaign_SelectedIndexChanged" AutoPostBack="True">

                                   </asp:DropDownList>
                            </div>
                       </div>
                     </div>                           
                     </div>  
                <div class="row subscribe">
                <div class="col-lg-12">
                	<div class="panel panel-info">
                            <div class="panel-heading text-center">
                               <strong>Sent To:</strong> <big><b><asp:Label ID="lblRecipients" runat="server"></asp:Label> Subscribe</b></big>
                            </div>
                            <div class="panel-body">
                             <div class="clearfix">
   <%--                           <div class="col-lg-4">
                              	<p>List :    <label><a href="#">XXX</a></label></p>
                              
                              </div>--%>
                               <div class="col-lg-4">
                               	<p>Subject : <asp:Label ID="lblSubject" runat="server" Text=""></asp:Label></p>
                               </div>
                              <div class="col-lg-4">
									<p>Delivered: <asp:Label ID="lblDelivered" runat="server" Text=""></asp:Label></p>                              	
                              </div>
                             </div>  
                                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                             
                             <!--click and opens-->
                             <div class="row padtp15 subscribe">
                                <div class="col-lg-6">
                                    <div class="panel panel-default">
                                            <div class="panel-heading">
                                               <strong>OPNES</strong>
                                               <span class="badge pull-right">5</span>
                                            </div>
                                            <div class="panel-body">
                                             <div class="clearfix">
                                                <p>List average    <label class="pull-right"><a href="#"> 25.0%</a></label></p>
                                                <p>Industry average () <label class="pull-right"><a href="#">17.2%</a></label></p>
                                             </div>                              
                                            </div>
                                        </div>
                                     </div>
                                     <div class="col-lg-6">
                                    <div class="panel panel-default">
                                            <div class="panel-heading">
                                               <strong>CLICKS</strong>
                                                <span class="badge pull-right">5</span>
                                            </div>
                                            <div class="panel-body">
                                                <div class="clearfix">
                                                    <p>List average    <label class="pull-right"><a href="#"> 25.0%</a></label></p>
                                                    <p>Industry average () <label class="pull-right"><a href="#">17.2%</a></label></p>
                                                 </div>                             
                                            </div>
                                        </div>
                                     </div>
                                </div>
                                
                                <%--<button type="button" class="btn btn-info"><i class="fa fa-tasks fa-fw"></i> View Report</button>--%>
                                <asp:Button ID="btnViewReport" runat="server" class="btn btn-info" Text="View Report" />
                                                         
                            </div>
                        </div>
                     </div>
                </div>
                  </ContentTemplate>
                            </asp:UpdatePanel>

                <div class="row padtp15">


                    <div class="col-md-9 col-sm-12 col-xs-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                Bar Chart - Six Recently Sent Campaign
                            </div>
                            <div class="panel-body">
                                <div id="morris-bar-chart"></div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-sm-12 col-xs-12">
                          <div class="panel panel-primary recentsentdetial">
                                <div class="panel-heading">
                                    Six Recently Sent Campaign Details 
                                </div>
                                <div class="panel-body">
                                    <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                                   
                                   <p><strong>Mail Sent:</strong>  Shows mail sent to total number of recipients.</p>
                                    <p><strong>Recipients:</strong>  Shows total number of recipients selected for this campaign.</p>
                                </div>                                
                            </div> 
                         </div>   

                </div>
            </div>
            <!-- /. PAGE INNER  -->
        </div>
    </form>
</body>
</html>
