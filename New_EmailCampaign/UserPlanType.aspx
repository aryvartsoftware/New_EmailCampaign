<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPlanType.aspx.cs" Inherits="New_EmailCampaign.UserPlanType" %>

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
        function Clearuserinput() {
            var theAnswer = confirm("Are you sure you want to clear the input?");

            if (theAnswer) {
                $('input[type=text], textarea').each(function () {
                    $(this).val('');
                });
                $("#form1 select").val("-- Select --");

                document.getElementById('chkactive').checked = false;
                var radb = document.getElementsByName("rbuserselect");
               
                radb[0].checked = false;
                radb[1].checked = false;

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
            window.location.href = "SignupSuccess.html";
        }

        function Clearuserinput2() {
            $('input[type=text], textarea').each(function () {
                $(this).val('');
            });
            $("#form1 select").val("-- Select --");
            document.getElementById('chkactive').checked = false;
            var radb = document.getElementsByName("rbuserselect");

            radb[0].checked = false;
            radb[1].checked = false;
            alert('Information Successfully Saved');
            window.location.href = "UserPlanTypeDetails.aspx";
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
         <div class="container-fluid">
    <div class="row">
      <div class="container">
        <div class="row">
            i<!-- Fixed navbar --><div class="main-menu"> <!-- start menu section -->
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
                    <li class="active"><a href="UserPlanTypeDetails.aspx">Plan Type</a></li>
                   
                  </ul>
                  <ul class="nav navbar-nav navbar-right">
                    <li><a href="#">Help</a></li>
                    <li class="dropdown">
                      <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Exit <span class="caret"></span></a>
                      <ul class="dropdown-menu" role="menu">
                        
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
          <h1>Plan Type Details</h1>
          <h4>Provide the basic details about plan type</h4>
          <div class="col-md-12  new_bg"> <!-- start campaign section -->
            <div class="row">
              <div class="col-md-6">
                <div class="campaign">
                    <div class="form-group">
                      <label for="exampleInputName1">Plan Name</label>
                      <input type="text" class="form-control" id="txtCampaignName" required name="txtCampaignName" runat="server" placeholder="Plan Name" oncontextmenu="return false;" />                      
                    </div>
                    <div class="form-group">
                      <label for="exampleInputEmail1">User Type</label>
                      <div class="date-time" style="padding-bottom:5px;">
                      <div id="datetimepicker1" class="input-append">                       
                          <asp:RadioButtonList ID="rbuserselect" runat="server" required RepeatDirection="Horizontal">
                              <asp:ListItem Value="1">Single User</asp:ListItem>
                              <asp:ListItem Value="0">Multi User</asp:ListItem>
                          </asp:RadioButtonList>
                       
                      </div>
                    </div>
                    </div>  
                    
                    <div class="form-group">
                      <label for="exampleInputEmail1">Plan Rate ($)</label>  
                      <input type="text" class="form-control" id="txtPlanRate" oncontextmenu="return false;" placeholder="Plan Rate" title="Only numbers were allowed" required pattern="^[0-9]*$" maxlength="14" runat="server"/>
                    </div>
                                        
                </div>
              </div>

              <div class="col-md-6">
                <div class="campaign">  
                    <div class="form-group">
                      <label for="exampleInputName3">Number of Subscribers</label>
                      <%--<select class="form-control" style="width:50%;height:26px;padding: 2px 7px;">
                        <option>Select city</option>
                        <option>Coimbatore</option>
                      </select>--%>
                        <input type="text" class="form-control" id="txtnosubscribers" oncontextmenu="return false;" required title="Only numbers were allowed" pattern="^[0-9]*$" maxlength="10"  placeholder="Number of Subscribers" runat="server"/>
                    </div>
                    <div class="form-group">
                      <label for="exampleInputName3">Number of Mails</label>
                  <%--    <select class="form-control" style="width:50%;height:26px;padding: 2px 7px;">
                        <option>Select Country</option>
                        <option>India</option>
                      </select>--%>
                         <input type="text" class="form-control" id="txtnomails" oncontextmenu="return false;" placeholder="Number of Mails" title="Only numbers were allowed" required pattern="^[0-9]*$" maxlength="10" runat="server"/>
                    </div>
                    <div class="form-group">
                      <label for="exampleInputName3">Is Active</label>
                        <asp:CheckBox ID="chkactive" required runat="server" />
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

      

    </div>
  </div>
    </form>
</body>
</html>
