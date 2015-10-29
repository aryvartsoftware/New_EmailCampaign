<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvitieUser.aspx.cs" Inherits="New_EmailCampaign.InvitieUser" %>

<%@ Register TagPrefix="uc" TagName="Spinner"
    Src="~/Common_Menu.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Email Campaign</title>
    <link href='http://fonts.googleapis.com/css?family=Lato:400,700' rel='stylesheet' type='text/css'>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/stylesheet.css" rel="stylesheet" />

    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script type="text/javascript">
        function Clearuserinput() {
            var theAnswer = confirm("Are you sure you want to clear the input?");

            if (theAnswer) {
                $('input[type=text], textarea').each(function () {
                    $(this).val('');
                });
                $("#form1 select").val("-- Select --");
                //$("#chkactive")
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
            //alert('Information Successfully Saved');
            window.location.href = "SignupSuccess.html";
        }

        function Clearuserinput2() {
            $('input[type=text], textarea').each(function () {
                $(this).val('');
            });
            $("#form1 select").val("-- Select --");
            alert('Information Successfully Saved');
            window.location.href = "InviteUserList.aspx";
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <uc:Spinner ID="Spinner1"
            runat="server"
            MinValue="1"
            MaxValue="10" />

        <div class="container bg">
            <div class="new_campaign">
                <h1>Invite a user</h1>
            </div>
            <div class="settings">
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="invite">
                        <div class="form-group">
                            <div class="failure"><span>
                                <asp:Label ID="lblerrormsg" runat="server" Text=""></asp:Label></span></div>
                            <label for="exampleInputName2">Email Address</label>



                            <% if (Request.QueryString["CampInvtusrId"] != null)
                               { %>
                            <input type="text" class="form-control" id="Text1" readonly runat="server" />
                            <% }
                               else
                               { %>
                            <input type="text" class="form-control" id="EmailID" required pattern="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server" />
                            <% } %>

                            <label for="exampleInputName2">Role Name</label>
                            <asp:DropDownList class="form-control" ID="ddlrole" Style="width: 300px;" required="required" runat="server" AppendDataBoundItems="true">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="invite">
                        <div class="form-group">
                            <label for="exampleInputName2">A message from you (optional)</label>
                            <% if (Request.QueryString["CampInvtusrId"] != null)
                               { %>
                            <textarea class="form-control" id="txta1" placeholder="Hi. Join our Email Campaign account." readonly runat="server" style="resize: none;" rows="5"></textarea>
                            <% }
                               else
                               { %>
                            <textarea class="form-control" placeholder="Hi. Join our Email Campaign account." id="txtmessage" runat="server" name="txtmessage" style="resize: none;" rows="5"></textarea>
                            <% } %>
                        </div>
                        <div class="form-group form-btn">
                            <input id="Reset1" type="reset" onclick="return Clearuserinput();" value="Cancel" class="btn btn-info btn-sm" />

                            <asp:Button ID="btnSubmit" class="btn btn-primary btn-sm" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="container">
            <!-- start footer section -->
            <div class="new_footer">
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
                        <p>
                            <img src="images/footer_tick.png">
                            Getting Started </p>
                        <p>
                            <img src="images/footer-vids.png">
                            Video Tutorials</p>
                        <p>
                            <img src="images/footer-andy.png">
                            Email Campaign Business Blog</p>
                    </div>
                    <div class="col-md-5 faq">
                        <h3>
                            <img src="images/footer-faq.png">
                            Frequently Asked Questions</h3>
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
        <!-- end footer section -->
    </form>
</body>
</html>
