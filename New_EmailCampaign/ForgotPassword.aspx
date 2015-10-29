<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="New_EmailCampaign.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cannot access account :: Aryvart Campaign</title>

    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />

    <script src="js/jqueryv11.2.js"></script>
</head>

<body>

    <form id="form1" runat="server">
        <div class="container-fluid login-bg">
            <div class="row">
                <div class="signup">
                    <div class="logo-bg">
                        <img src="images/new_logo.png" alt="">
                    </div>
                    <div class="third-signup access">
                        <div class="third">
                            <h1>Cannot Access your Account?</h1>
                        </div>
                        <div class="signin account">
                            <div class="failure"><span>
                                <asp:Label ID="lblerrormsg" runat="server" Text=""></asp:Label></span>.</div>

                            <p>Email</p>
                            <li class="base">
                                <input type="text" value="" required pattern="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" placeholder="someone@example.com" id="txtEmail" runat="server" />
                            </li>
                            <div class="submit-signin">
                                <%--<input type="submit"  value="Create My Account">--%>
                                <asp:Button ID="Button1" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
