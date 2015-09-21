<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs"  Inherits="New_EmailCampaign.UserLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Aryvart Campaign</title>
  <!-- start css -->
     <script type = "text/javascript" >
         function changeHashOnLoad() {
             window.location.href += "#";
             setTimeout("changeHashAgain()", "50");
         }
         </script>
    <link href="css/bootstrap.css" rel="stylesheet" />
 <link href="css/style.css" rel="stylesheet" />
  <!-- end css -->

  <!-- start js -->
  
<!-- end js -->
</head>
<body onload="changeHashOnLoad();">
    <form id="form1" runat="server">
    <div class="container-fluid login-bg">
    <div class="row">
      <div class="login">
        <div class="third-login">
          <h1><img src="images/aryvart_logo.png" alt=""/></h1>
          <div class="three">
              
              <div class="failure"><span><asp:Label ID="lblerrormsg" runat="server" Text=""></asp:Label></span>.</div>
              <p>Username / Email</p>
              <li class="base">
                <input id="txtUsername" runat="server" type="text" value="" required placeholder="Username / someone@example.com"/>
              </li>
              <p>Password</p>
              <li>
                <input id="txtpassword" runat="server" type="password" required placeholder="Password"/>
              </li>
              <div class="remember">
                <div class="col-md-6">
               <div class="checkbox">
                <label>
                  <input type="checkbox" id="chkRememberme" runat="server"/> Keep me signed in
                </label>
              </div>
              </div>
              <div class="col-md-6">
              <h6><a href="ForgotPassword.aspx">Can't access your account?</a></h6>
              </div>
              </div>
              <div class="submit-three">
                <%--<input type="submit"  value="Sign In" >--%>
                  <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Sign In" />
              </div>
              <div class="sign-up">
                <h5 class="new-sign sign">Don't have a Aryvart account? <a href="FreeAccountSignUp.aspx">Sign Up Now</a></h5>
                <h5 class=""></h5>
              </div>
          </div>
        </div>
      </div>
    </div>
  </div>
    </form>
</body>
</html>
