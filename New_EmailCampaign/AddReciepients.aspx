
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddReciepients.aspx.cs" Inherits="New_EmailCampaign.AddReciepients" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Email Campaign</title>
  <!-- start css -->
  <link href="css/bootstrap.css" rel="stylesheet" />
  <link href="css/style.css" rel="stylesheet" />

   

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
      }

    </script>
</head>
<body>
    <form id="form1" runat="server" >
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
                    <li><a href="#about">List</a></li>
                    <li><a href="ImportReciepientsList.aspx">Upload Contacts</a></li>
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
  <!-- start content section -->
  <div class="container-fluid bg">
      
    <div class="row">
      <div class="container new_campaign">
        <div class="row">
          <h1>Add Recipients</h1>
         <%-- <div class="col-md-12 text-right">
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">Create List</button>
          </div>--%>        
            <div class="modal fade create-list" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
              <div class="modal-content">
                <div class="modal-header">
                  <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                  <h4 class="modal-title" id="exampleModalLabel">Create List</h4>
                </div>
                <div class="modal-body">                  
                    <div class="form-group">
                      <label for="recipient-name" class="control-label">List Name:</label>
                      <input type="text" class="form-control" id="name">
                    </div>
                    <div class="form-group">
                      <label for="message-text" class="control-label">Comments:</label>
                      <textarea class="form-control" id="message-text"></textarea>
                    </div>                 
                </div>
                <div class="modal-footer">
                  <input type="reset" value="Clear All" class="btn btn-info btn-sm"/>
                  <input class="btn btn-primary btn-sm" type="Submit" value="Submit"  />
                </div>
              </div>
            </div>
          </div>    
          <div class="col-md-12  new_bg"> <!-- start campaign section -->
            <div class="row">
              <div class="col-md-6">
                <div class="campaign">            
                  
                    <div class="form-group">
                      <label for="exampleInputName1">Contact Name</label>
                      
                        <input type="text" class="form-control" value="" required placeholder="Contactname" id ="txtContactName" runat="server"/>                    
                    </div>
                    <div class="form-group">
                      <label for="exampleInputName2">Designation</label>  
                      <input type="text" class="form-control" value="" placeholder="Designation" id ="txtDesignation" runat="server"/>                      
                    </div> 
                     <div class="form-group">
                      <label for="exampleInputName2">Address line</label>  
                      <input type="text" class="form-control" value="" placeholder="Address" id ="txtAddress" runat="server"/> 
                                            
                    </div>
                    <div class="form-group">
                      <label for="exampleInputEmail1">Email ID</label>  
                       <input type="text" class="form-control" value="" required placeholder="Email ID" id ="txtemailid" runat="server"/>                                       
                    </div>
                    
                </div>
              </div>

              <div class="col-md-6">
                <div class="campaign">            
                  
                    <div class="form-group">
                      <label for="exampleInputName3">City</label>
                      <input type="text" class="form-control" value="" placeholder="City" id ="txtCity" runat="server"/> 
                    </div>
                    <div class="form-group">
                      <label for="exampleInputEmail1">State</label>  
                      <input type="text" class="form-control" value="" placeholder="State" id ="txtState" runat="server"/> 
                    </div>
                     <div class="form-group">
                      <label for="exampleInputEmail1">Country</label>
                                            <input type="text" class="form-control" value="" placeholder="Country" id ="txtCountry" runat="server"/> 

                    </div>  
                    
                    <div class="form-group form-btn">                      
                        
                        <input id="Reset1" type="reset" onclick="return Clearuserinput();" value="Clear All" class="btn btn-info btn-sm" />
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSubmit" runat="server" Text="Submit"  />
                        
                    </div>                  
                </div>
              </div> 
              
            </div>
          </div> <!-- start campaign section -->
          
        </div>
      </div> 
    </div>
  </div>
      <!-- start content section -->  
    </form>
</body>
</html>
