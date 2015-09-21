
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateProfile.aspx.cs" Inherits="New_EmailCampaign.CreateProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Email Campaign</title>
      <link href="css/bootstrap.css" rel="stylesheet" />
  <link href="css/style.css" rel="stylesheet" />
  <link href="css/stylesheet.css" rel="stylesheet" />
  <link href="css/bootstrap-datetimepicker.min.css" rel="stylesheet" />
  <!-- end css -->

  <!-- start js -->
  <%--<script src="js/jquery.min.js"></script>--%>
  <script src="js/jqueryv11.2.js"></script>
  <script src="js/bootstrap-datetimepicker.min.js"></script>
  <script src="js/bootstrap.min.js"></script>
    

  <!-- start css -->
 

    <script type="text/javascript">

        $(function () {
            $('#datetimepicker1').datetimepicker({
                language: 'pt-BR',
                pickTime: false
            });
        });

        //Image Upload
        $(function () {
            $('#FileUpload1').change(function () {
                //$('#Image1').hide();
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#Image1').show();
                    $('#Image1').attr("src", e.target.result);
                    
                    //$('#Image1').Jcrop({
                    //    onChange: SetCoordinates,
                    //    onSelect: SetCoordinates
                    //});
                }

                
                if ($(this)[0].files[0].type.toString().contains('image/jpeg') || $(this)[0].files[0].type.toString().contains('image/jpg') || $(this)[0].files[0].type.toString().contains('image/png') || $(this)[0].files[0].type.toString().contains('image/gif'))
                    reader.readAsDataURL($(this)[0].files[0]);
                else
                    alert('The upload file is not a valid image file!.');
                
            });
        });




        //--------------------
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
        </script>
</head>
<body>
   <form id="form1" runat="server" >        
     <div class="container-fluid">
    <div class="row">
      <div class="container">
        <div class="row">
            <!-- Fixed navbar --><div class="main-menu"> <!-- start menu section -->
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
          <h1>Profile</h1>
          

          <div class="col-md-12  new_bg"> <!-- start campaign section -->
            <div class="row">
               
              <div class="col-md-12">
                   <div class="media profile" style="padding-top:0;">
              <div class="media-left">
                <a href="#">
                  <img id="Image1" class="img-circle" runat="server" src="images/unknown.png" alt="">
                </a>
              </div>
              <div class="media-body">
                <h4 class="media-heading">Upload your photo</h4>
                <p>Image should be at least 300px × 300px</p>
                <div class="form-group">
                  <input type="file" id="FileUpload1" name="FileUpload1" runat="server" accept=".jpg,.png,.jpeg,.gif" />
                    <b style="background-color:#ffff99;">(.jpg, .jpeg, .png, .gif)</b>
                </div>
              </div>
            </div>
                <div class="campaign">            
                  <div class="col-md-6">
                    <div class="form-group">
                      <label for="exampleInputName1">User Name</label>
                      <input type="text" class="form-control" id="txtUserName" name="txtUserName" runat="server" required oncontextmenu="return false;"  />
                    </div>
                    <div class="form-group">
                      <label for="exampleInputName3">Last Name</label>  
                      <input type="text" class="form-control" id="txtLastName" name="txtLastName" runat="server" required oncontextmenu="return false;" />
                    </div>
                      <div class="form-group">
                      <label for="exampleInputEmail1">Email ID</label>  
                      <%--<input type="text" class="form-control" id="txtEmailID" name="txtEmailID" runat="server" required oncontextmenu="return false;" />--%>
                         <input type="text" class="form-control" value=""  required pattern="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" placeholder="someone@example.com" id ="txtEmail" runat="server"/>
                    </div>
                   <div class="form-group">
                      <label for="exampleInputName4">Role</label>  
                       <%-- <asp:Label ID="lblUserType" runat="server" Text=""></asp:Label>--%>
                                            <%-- <input type="text" class="form-control" id="txtrole" name="txtAddress" runat="server" required oncontextmenu="return false;" />--%>
                       <asp:DropDownList ID="ddlrole" style="width:300px;" required="required" runat="server" AppendDataBoundItems="true">
                        </asp:DropDownList> 
                       <%--<asp:DropDownList ID="roleid" --%>

                    </div>
                    <div class="form-group">
                      <label for="exampleInputName7">Address Line1</label>  
                      <input type="text" class="form-control" id="txtAddress" name="txtAddress" runat="server" required oncontextmenu="return false;" />
                    </div>
                      <div class="form-group">
                      <label for="exampleInputName9">State</label>  
                      <input type="text" class="form-control" id="txtState" name="txtState"  runat="server" required oncontextmenu="return false;" />
                    </div>
                       <div class="form-group">
                      <label for="exampleInputName11">Contact Number</label>  
                      <%--<input type="text" class="form-control" id="txtContactNumber" name="txtContactNumber" runat="server" required oncontextmenu="return false;" />--%>
                        <input type="text" class="form-control" required placeholder="Contact Number" id ="txtContactNumber" runat="server" title="The format must be ex:- 91-9999999999" pattern="[0-9]{2}-[0-9]{10}(?!.*\s).*$" maxlength="14"/>
                    </div>
                  </div>

                  <div class="col-md-6">
                    <div class="form-group">
                      <label for="exampleInputName2">First Name</label>  
                      <input type="text" class="form-control" id="txtFirstName" name="txtFirstName" runat="server" required oncontextmenu="return false;" />
                    </div>
                    
                    <div class="form-group">
                      <label for="exampleInputName6">Date of Birth</label>  
                      <%--<input type="text" class="form-control" id="txtDOB" name="txtDOB" runat="server" required oncontextmenu="return false;" />--%>
                         <div class="date-time">
                      <div id="datetimepicker1" class="input-append">                       
                        <input id="dtScheduledatetime" data-format="dd/MM/yyyy" runat="server" style=" margin-bottom: 10px;width: 163px;" required type="text" />
                        <span class="add-on">
                          <i data-time-icon="icon-time" data-date-icon="icon-calendar">
                          </i>
                        </span>
                      </div>
                    </div>
                    </div>
                      <div class="form-group">
                      <label for="exampleInputName5">Designation</label>  
                      <input type="text" class="form-control" id="txtDesignation" name="txtDesignation" runat="server" required oncontextmenu="return false;" />
                    </div>
                 <div class="form-group">
                      <label for="exampleInputName8">City</label>  
                      <input type="text" class="form-control" id="txtCity" name="txtCity"  runat="server" required oncontextmenu="return false;" />
                    </div> 
                     <div class="form-group">
                      <label for="exampleInputName10">Country</label>  
                      <input type="text" class="form-control" id="txtCountry" name="txtCountry"  runat="server" required oncontextmenu="return false;" />
                    </div> 
                      <div class="form-group">
                      <label for="exampleInputName12">Alternative Number</label>  
                      <input type="text" class="form-control" id="txtAlternativeNumber" name="txtAlternativeNumber" runat="server" title="The format must be ex:- 91-9999999999" pattern="[0-9]{2}-[0-9]{10}(?!.*\s).*$" maxlength="14" />
                    </div> 
                    
                  </div>
                  
                  
                  <div class="col-md-12">  
                     
                    <div class="form-group form-btn padlft10">
                         <input id="Reset1" type="reset" onclick="return Clearuserinput();" value="Clear All" class="btn btn-info btn-sm"/>
                    <%--<button type="button" class="btn btn-primary btn-sm">Submit</button>  --%>
                        <asp:Button ID="btnSubmit" class="btn btn-primary btn-sm" runat="server" OnClick="btnSubmit_Click" Text="Submit" /> 
                    <%--<button type="button" class="btn btn-info btn-sm">Clear all</button>    --%>         
                       
                    </div>  
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
      <!-- start content section -->  
    </form>
</body>
</html>
