<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FreeAccountSignUp.aspx.cs" Inherits="New_EmailCampaign.FreeAccountSignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Aryvart Campaign</title>

    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />

    <script src="js/jqueryv11.2.js"></script>
    <script type="text/javascript">
        function changeType() {
            document.forms['myform'].txtPassword.type = (document.forms['myform'].option.value = (document.forms['myform'].option.value == 1) ? '-1' : '1') == '1' ? 'text' : 'password';
        }

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
                            <h1>Get started with a Free Account</h1>
                            <p>No credit card required.</p>
                        </div>
                        <div class="signin">
                            <div class="failure"><span>
                                <asp:Label ID="lblerrormsg" runat="server" Text=""></asp:Label></span>.</div>
                            <p>User Name</p>
                            <li class="base">
                                <input type="text" value="" required placeholder="Username" id="txtUserName" runat="server" />
                            </li>
                            <p>Email</p>
                            <li class="base">
                                <input type="text" value="" required pattern="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" placeholder="someone@example.com" id="txtEmail" runat="server" />
                            </li>
                            <p>
                                Password
                                <label class="show-password" for="showpasscheckbox-1" title="Show the password as plain text" style="float: right">
                                    <input type="checkbox" id="option" name="option" title="Show the password as plain text" onclick="changeType();" />
                                    <span>Show Password</span>
                                </label>
                            </p>

                            <li class="base">
                                <input type="password" required placeholder="Password" id="txtPassword" value="" name="txtPassword" pattern="(?=^.{8,20}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$" title="Minmimum 8 character with atleast 1 lowercase, 1 uppercase, 1 number and 1 special character." runat="server" maxlength="20" />
                            </li>
                            <p>Company Name</p>
                            <li class="base">
                                <input type="text" required placeholder="Company Name" id="txtCompanyName" runat="server" />
                            </li>
                            <p>Contact Number</p>
                            <li class="base">
                                <input type="text" required placeholder="Contact Number" id="txtContactNumber" runat="server" title="The format must be ex:- 91-9999999999" pattern="[0-9]{2}-[0-9]{10}(?!.*\s).*$" maxlength="14" />
                            </li>
                            <div class="remember">
                                <div class="col-md-12">
                                    <div class="checkbox">
                                        <label>
                                            <input id="chkNewsLetter" name="chkNewsLetter" runat="server" type="checkbox">
                                            Subscribe to Aryvart Newsletter.
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="submit-signin">
                                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Create My Account" />
                            </div>
                            <div class="submit-signin">
                            </div>
                            <div class="term">
                                <h5 class="privacy sign">By clicking 'Create My Account', I agree to the <a href="#">Terms of Service</a> and <a href="#">Privacy Policy</a></h5>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
