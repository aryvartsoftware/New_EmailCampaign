<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserSignup.aspx.cs" Inherits="New_EmailCampaign.UserSignup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Aryvart Campaign</title>
  <!-- start css -->
  <link href="css/bootstrap.css" rel="stylesheet" />
  <link href="css/style.css" rel="stylesheet" />

    <script src="js/jqueryv11.2.js"></script>
    <script type="text/javascript" >

        //This is for "Show Password Text"
        //add a show password checkbox to the demo-field


        function changeType() {
            document.forms['myform'].txtPassword.type = (document.forms['myform'].option.value = (document.forms['myform'].option.value == 1) ? '-1' : '1') == '1' ? 'text' : 'password';
        }

        //test the submitted value
        //document.getElementById('form1').onsubmit = function () {
        //    alert('pword = "' + this.pword.value + '"');
        //    return false;
        //};
        //------------------

        function Clearuserinput() {
            var theAnswer = confirm("Are you sure you want to clear the input?");

            if (theAnswer) {
                $('input[type=text], textarea').each(function () {
                    $(this).val('');
                });
                $("#myform select").val("-- Select --");
            }
            else {
                return false;
            }
            return false;
        }

        function Clearuserinput1() {
            $('input[type=text], [type=password] textarea').each(function () {
                $(this).val('');
            });

            window.location.href = "SignupSuccess.html";
            //alert('Account Created Successfully.');
        }

    </script>
</head>
<body>
    <form id="myform" runat="server">
     <div class="container-fluid login-bg">
    <div class="row">
      <div class="signup">
        <div class="logo-bg">
          <img src="images/new_logo.png" alt="">
        </div>
        <div class="third-signup">
          <div class="third">
          <h1>invited to join <asp:Label ID="lblcompany" runat="server" Text=""></asp:Label> account.</h1>
          </div>
          <div class="signin">
             <div class="failure"><span><asp:Label ID="lblerrormsg" runat="server" Text=""></asp:Label></span>.</div>
              <p>User Name</p>
              <li class="base">
                <input type="text" value="" required placeholder="Username" id ="txtUserName" runat="server"/>
              </li>
             
              <p>Password <label class="show-password" for="showpasscheckbox-1" title="Show the password as plain text" style="float:right">
        <input type="checkbox" id="option" name="option" title="Show the password as plain text" onclick="changeType();" />
        <span>Show Password</span>
    </label></p>
             
              <li class="base">
                <input type="password" required placeholder="Password" id ="txtPassword" value="" name="txtPassword"  pattern="(?=^.{8,20}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$" title="Minmimum 8 character with atleast 1 lowercase, 1 uppercase, 1 number and 1 special character." runat="server" maxlength="20" />
                  <%--<input type="text" id="txtPassword" autocomplete="off" style="display:none;" />--%>
              </li>
              <p>First Name</p>
              <li class="base">
                <input type="text" required placeholder="First Name" id ="txtFirstName" runat="server"/>
              </li>
               <p>Last Name</p>
              <li class="base">
                <input type="text" required placeholder="Last Name" id ="txtLastNam" runat="server"/>
              </li>
              <div class="submit-signin">
                <%--<input type="submit"  value="Create My Account">--%>
                  <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Create Account" />
              </div> 
               <div class="submit-signin">
                    <%--<button type="button" class="btn btn-info btn-sm pull-right">Clear</button>--%>
                        <%--<input id="Reset1" type="reset" onclick="return Clearuserinput();" value="Clear All" class="btn btn-primary" style="background-color:mediumseagreen;"/>--%>
                        <%--<asp:Button ID="btnCancel" class="btn btn-primary" runat="server" Text="Clear" onclick="return Clearuserinput();"/>  --%>              
                    </div>
              <div class="term">
                <h5 class="privacy sign">By clicking 'Create Account', I agree to the <a href="#"> Terms of Service</a> and <a href="#"> Privacy Policy</a></h5>
              </div>             
          </div>
        </div>
      </div>
    </div>
  </div>
    </form>
</body>
</html>
