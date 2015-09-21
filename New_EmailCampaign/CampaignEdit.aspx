<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CampaignEdit.aspx.cs" Inherits="New_EmailCampaign.CampaignEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Email Campaign</title>
  <!-- start css -->
  <link href="css/bootstrap.css" rel="stylesheet" />
  <link href="css/style.css" rel="stylesheet" />
  <link href="css/stylesheet.css" rel="stylesheet" />
    <link href="css/bootstrap-datetimepicker.min.css" rel="stylesheet" />

    <script src="js/jqueryv11.2.js"></script>
  <script src="js/bootstrap-datetimepicker.min.js"></script>

    <script type="text/javascript">
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
          window.location = "CreateCampaignList.aspx";
      }
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
                    <li class="active"><a href="CreateCampaignList.aspx">Campaign</a></li>
                    <%--<li><a href="#about">List</a></li>--%>
                    <li><a href="ContactsView.aspx">Contacts</a></li>
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
  <!-- start content section -->
  <div class="container-fluid bg">
    <div class="row">
      <div class="container new_campaign">
        <div class="row">
          <h1>Campaign</h1>
          <h4>Provide the basic details about your campaign</h4>
          <div class="col-md-12  new_bg"> <!-- start campaign section -->
            <div class="row">
              <div class="col-md-6">
                <div class="campaign">
                    <div class="form-group">
                      <label for="exampleInputName1">Campaign Name</label>
                      <input type="text" class="form-control" id="txtCampaignName" name="txtCampaignName" runat="server" required oncontextmenu="return false;" />
                      <span id="helpBlock" class="help-block">Internal use only. Ex: "Newsletter Test#4".</span>
                    </div>
                    <div class="form-group">
                      <label for="exampleInputName2">Title / Subject</label>  
                      <input type="text" class="form-control" id="txtTitle" name="txtTitle" runat="server" required oncontextmenu="return false;" />
                      <span id="helpBlock1" class="help-block">How do I write a good subject line? • Emoji support</span>
                    </div> 
                   <%-- <div class="form-group">
                      <label for="exampleInputEmail1">Select Time Zone</label>  
                        <asp:DropDownList ID="ddlTimeZone" required="required" runat="server">
                        </asp:DropDownList> 
                       <asp:RequiredFieldValidator runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="ddlTimeZone" ForeColor="Red" InitialValue="-- Select --" SetFocusOnError="True" ValidationGroup="vg1"></asp:RequiredFieldValidator>                 
                    </div> --%>
                    <div class="form-group form-btn">
                    <%--<button type="button" class="btn btn-info btn-sm pull-right">Clear</button>--%>
                        <input id="Reset1" type="reset" onClick="return Clearuserinput();" value="Clear All" class="btn btn-primary" style="background-color:mediumseagreen;"/>
                        <%--<asp:Button ID="btnCancel" class="btn btn-primary" runat="server" Text="Clear" onclick="return Clearuserinput();"/>  --%>              
                    </div>
                </div>
              </div>

              <div class="col-md-6">
                <div class="campaign">            
                  
                    <div class="form-group">
                      <label for="exampleInputName3">From Name</label>
                      <input type="text" class="form-control" id="FromName" required runat="server"/>
                      <span id="helpBlock" class="help-block">Use something subscribers will instantly recognize, like your company name.</span>
                    </div>
                    <div class="form-group">
                      <label for="exampleInputEmail1">From Email</label>  
                      <input type="text" class="form-control" id="EmailID" required pattern="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server"/>
                      <span id="helpBlock" class="help-block">Enter your email address</span>
                    </div>
                   <%--  <div class="form-group">
                      <label for="exampleInputEmail1">Select Date &amp; Time</label>
                    </div> 
                    <div class="date-time">
                      <div id="datetimepicker1" class="input-append">                       
                        <input id="dtScheduledatetime" data-format="dd/MM/yyyy hh:mm:ss PP" runat="server" required type="text" />
                        <span class="add-on">
                          <i data-time-icon="icon-time" data-date-icon="icon-calendar">
                          </i>
                        </span>
                      </div>
                    </div> --%>
                    <div class="form-group form-btn">
                    <%--<button type="button" class="btn btn-primary btn-sm">Submit</button>   --%>
                         <asp:Button ID="btnSubmit" class="btn btn-primary" runat="server"  OnClick="btnSubmit_Click" Text="Submit" />                
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
