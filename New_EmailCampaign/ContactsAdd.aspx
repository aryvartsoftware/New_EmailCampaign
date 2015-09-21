<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactsAdd.aspx.cs" Inherits="New_EmailCampaign.ContactsAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Email Campaign</title>
     <link href='http://fonts.googleapis.com/css?family=Lato:400,700' rel='stylesheet' type='text/css'>
  <link href="css/bootstrap.css" rel="stylesheet" />
  <link href="css/style.css" rel="stylesheet" />
  <link href="css/stylesheet.css" rel="stylesheet" />
  <link href="css/bootstrap-datetimepicker.min.css" rel="stylesheet" />

    <script src="js/jqueryv11.2.js"></script>
     <script src="js/bootstrap-datetimepicker.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
     <script type="text/javascript">
         $(function () {
             // Bootstrap DateTimePicker v3
             $('#dtScheduledatetime').datetimepicker({
                 pickTime: false
             });
         });
         function Clearuserinput() {
             var theAnswer = confirm("Are you sure you want to clear the input?");

             if (theAnswer) {
                 $('input[type=text], textarea').each(function () {
                     $(this).val('');
                 });
                 $("#form1 select").val("-- Select --");
             }
             else {
                 return false;
             }

             return false;
         }

         function Clearuserinput1() {
             $('input[type=text], textarea').each(function () {
                 $(this).val('');
             });
             $("#form1 select").val("-- Select --");
             alert('Information Successfully Saved');
             window.location = "ContactsView.aspx";
         }
         $(function () {
             $('#datetimepicker1').datetimepicker({
                 language: 'pt-BR',
                 pick12HourFormat: true
             });
         });
    </script>
</head>
<body>
    <form id="form1" runat="server">
         <div class="container-fluid">
    <div class="row">
      <div class="container">
        <div class="row">
          <!-- Fixed navbar -->
          <div class="main-menu"> <!-- start menu section -->
            <nav class="navbar navbar-default navbar-fixed-top">
              <div class="container">
                <div class="navbar-header">
                  <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                  </button>
                  <a class="navbar-brand" href="#">Menus</a>
                </div>
                <div id="navbar" class="navbar-collapse collapse">
                  <ul class="nav navbar-nav">
                    <li><a href="CreateCampaignList.aspx">Campaign</a></li>
                    <li class="active"><a href="ContactsView.aspx">Contacts</a></li>
                      <% if (Session["vewrpts"] != null)
              {
                  if (Convert.ToInt32(Session["vewrpts"].ToString()) == 1)
                  { %> 
                      <li><a href="CampaignReportList.aspx">Report</a></li>
                       <%}
              }%>
                  </ul>
                  <ul class="nav navbar-nav navbar-right">
                    <li><a href="#">Help</a></li>
                    <li class="dropdown">
                      <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Exit <span class="caret"></span></a>
                      <ul class="dropdown-menu" role="menu">
                          <li><a href="CreateProfile.aspx">Profile</a></li>
                        <li><a href="#">Dashboard</a></li>
                        <li><a href="CreateCampaignList.aspx">Campaign</a></li>
                        <li><a href="RoleDetails.aspx">Role</a></li> 
                        <li><a href="RoleSettings.aspx">Access Settings</a></li>
                          <li><a href="RoleSettings.aspx">Role Access</a></li>
                           <% if (Session["crtusr"] != null)
              {
                  if (Convert.ToInt32(Session["crtusr"].ToString()) == 1)
                  { %> 
                          <li><a href="InviteUserList.aspx">Invite User</a></li>
                           <%}
              }%>
                        <li class="divider"></li>
                        <li><a href="UserLogin.aspx">Log Out </a></li>
                      </ul>
                    </li>
                  </ul>
                </div><!--/.nav-collapse -->
              </div>
            </nav>
          </div> <!-- end menu section -->          
        </div>
      </div>
    </div>
  </div>

   <div class="container-fluid bg">
    <div class="row">
      <div class="container new_campaign">
        <div class="row">
          <h1>Recipient Details</h1>
          <h4>Provide the basic details about your recipient contact</h4>
          <div class="col-md-12  new_bg"> <!-- start campaign section -->
            <div class="row">
              <div class="col-md-6">
                <div class="campaign">
                    <div class="form-group">
                      <label for="exampleInputName1">Name</label>
                      <input type="text" class="form-control" id="txtCampaignName" name="txtCampaignName" runat="server" placeholder="Name" oncontextmenu="return false;" />                      
                    </div>
                    <div class="form-group">
                      <label for="exampleInputEmail1">Date of Birth</label>
                      <div class="date-time" style="padding-bottom:5px;">
                      <div id="datetimepicker1" class="input-append">                       
                        <input id="dtScheduledatetime" class="date-time-pic" data-format="dd/MM/yyyy" runat="server" placeholder="Date of Birth"  type="text" />
                        <span class="add-on">
                          <i data-time-icon="icon-time" data-date-icon="icon-calendar">
                          </i>
                        </span>
                      </div>
                    </div>
                    </div>  
                    
                    <div class="form-group">
                      <label for="exampleInputEmail1">Email ID</label>  
                      <input type="text" class="form-control" id="EmailID" oncontextmenu="return false;" placeholder="Email ID" required runat="server"/>
                    </div>
                    <div class="form-group">
                      <label for="exampleInputName3">City</label>
                      <%--<select class="form-control" style="width:50%;height:26px;padding: 2px 7px;">
                        <option>Select city</option>
                        <option>Coimbatore</option>
                      </select>--%>
                        <input type="text" class="form-control" id="City" oncontextmenu="return false;" placeholder="City" runat="server"/>
                    </div>
                    <div class="form-group">
                      <label for="exampleInputName3">Country</label>
                  <%--    <select class="form-control" style="width:50%;height:26px;padding: 2px 7px;">
                        <option>Select Country</option>
                        <option>India</option>
                      </select>--%>
                         <input type="text" class="form-control" id="Country" oncontextmenu="return false;" placeholder="Country" runat="server"/>
                    </div>                    
                </div>
              </div>

              <div class="col-md-6">
                <div class="campaign">  
                    <div class="form-group">
                      <label for="exampleInputName3">Designation</label>
                      <input type="text" class="form-control" id="Designation" oncontextmenu="return false;" placeholder="Designation" runat="server"/>
                    </div>
                    <div class="form-group">
                      <label for="exampleInputName3">Contact No</label>
                      <input type="text" class="form-control" id="ContactNo" oncontextmenu="return false;" placeholder="Contact No" runat="server"/>
                    </div>
                    <div class="form-group">
                      <label for="exampleInputName3">Address</label>
                      <input type="text" class="form-control" id="Address" oncontextmenu="return false;" placeholder="Address" runat="server"/>
                    </div>

                    <div class="form-group">
                      <label for="exampleInputEmail1">State</label>  
                      <input type="text" class="form-control" id="State" oncontextmenu="return false;" placeholder="State" runat="server"/>
                    </div>
                     
                    <div class="form-group form-btn" style="padding-top: 16px;">
                      <label></label>
                        <%--<button type="button" class="btn btn-info btn-sm" style="margin-right:10px;">Clear</button>--%>
                         <input id="Reset1" type="reset" onClick="return Clearuserinput();" value="Clear All" class="btn btn-info btn-sm" style="margin-right:10px;"/>
                        <asp:Button ID="btnSubmit" class="btn btn-primary btn-sm" runat="server"  OnClick="btnSubmit_Click" Text="Submit" /> 
                        <%--<button type="button" class="btn btn-primary btn-sm">Submit</button>    --%>  
                    </div>                  
                </div>
              </div> 
            </div>
          </div> <!-- start campaign section -->
        </div>
      </div>      

      <div class="container new_footer">
        <div class="row">
          <div class="col-md-4">
            <h3>Email Campaign</h3>
            <ul class="list-unstyled">
              <li>Lorem Ipsum,simply</li>
              <li>Dummy text</li>
              <li>Standard - 600 600</li>
            </ul>
           <p>Phone: +91 9865 4321 10</p>
           <p>Mail: info@domail.com</p>
          </div>
          <div class="col-md-3 blog">
            <p><img src="images/footer_tick.png"> Getting Started </p>
           <p><img src="images/footer-vids.png"> Video Tutorials</p>
           <p><img src="images/footer-andy.png"> Email Campaign Business Blog</p>
          </div>
          <div class="col-md-5 faq">
            <h3><img src="images/footer-faq.png"> Frequently Asked Questions</h3>
            <ul class="list-unstyled">
              <li>How do I personalize the subject line of my email?</li>
              <li>Why is my email campaign "Under Review"?</li>
              <li>Can I Add Google Analytics Tracking To My Email Campaigns?</li>
              <li>More Help Articles</li>
            </ul>
          </div>
        </div>
      </div>

    </div>
  </div>
    </form>
</body>
</html>
