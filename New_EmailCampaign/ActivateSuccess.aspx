<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActivateSuccess.aspx.cs" Inherits="New_EmailCampaign.ActivateSuccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome :: Aryvart Campaign</title>
     <link href="css/bootstrap.css" rel="stylesheet" />
 <link href="css/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container-fluid login-bg">
        <div class="row">
            <div class="login welcome">
                <span><img src="images/new_logo.png" alt="" /></span>
                <div class="third-login">
                    <div class="three">
                        <h3>Welcome to Aryvart Email Campaign</h3>
                        <p>
                            Thanks for Activation. To continue Aryvart Email Campaign,
                            <br/><a href='UserLogin.aspx' style='color: #00acec;'>Log in using your credential</a>.
                        </p>
                        <!--<div class="submit-three">
                          <input type="submit"  value="Active your account and Log In" onClick="window.location('http://www.aspsnippets.com/Articles/Send-email-using-Gmail-SMTP-Mail-Server-in-ASPNet.aspx');" >

                        </div>-->

                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
