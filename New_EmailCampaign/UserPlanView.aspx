<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPlanView.aspx.cs" Inherits="New_EmailCampaign.UserPlanView" %>

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
</head>
<body>
    <form id="form1" runat="server">
        <uc:Spinner ID="Spinner1"
            runat="server"
            MinValue="1"
            MaxValue="10" />

        <div class="container bg">
            <div class="new_campaign">
                <h1>Plan Type</h1>
            </div>
            <div class="settings users">
                <div>
                    <div class="users-profile">

                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <asp:UpdatePanel ID="upGrdCustomers" runat="server" UpdateMode="Always">
                            <ContentTemplate>
                                <asp:Label ID="lblUsrPlan" runat="server" Text="Label"></asp:Label>
                                <asp:Repeater ID="RepDetails" runat="server">
                                    <HeaderTemplate>
                                        <table style="border: 1px solid #df5015; width: 500px" cellpadding="0">
                                            <tr style="background-color: #df5015; color: White">
                                                <td colspan="2">
                                                    <b>List of Plans</b>
                                                </td>
                                            </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr style="background-color: #EBEFF0">
                                            <td>
                                                <table style="background-color: #EBEFF0; border-top: 1px dotted #df5015; width: 500px">
                                                    <tr>
                                                        <td>Plan Name:
                                                            <asp:Label ID="lblSubject" runat="server" Text='<%#Eval("PlanName") %>' Font-Bold="true" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Plan Rate:
                                                <asp:Label ID="lblPlanRate" runat="server" Text='<%#Eval("Planrate") %>' />
                                            </td>
                                            <td>Number of Subscribers:
                                                <asp:Label ID="lblnos" runat="server" Text='<%#Eval("NOC") %>' />
                                            </td>
                                            <td>Allowed Mails:
                                                <asp:Label ID="lblComment" runat="server" Text='<%#Eval("AllowedMails") %>' />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table style="background-color: #EBEFF0; border-top: 1px dotted #df5015; border-bottom: 1px solid #df5015; width: 500px">
                                                    <tr>
                                                        <td>Is Single User:
                                                            <asp:Image ID="imgEmployeeImage" runat="server" ImageUrl='<%# "~/images/Tick_inside_a_circle_24(1).png" %>' Visible='<%# Eval("IsSingleUser").ToString() == "True" ? true : false %>' Width="30px" Height="30px" /></td>

                                                        <td>                                                             
                                                            <asp:Button ID="email" runat="server" Text="TRY THIS PLAN" CommandName="mail" OnClick="Button_Click" CommandArgument='<%# Eval("PK_PlanID") %>' /></td>                                                         
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">&nbsp;</td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </ContentTemplate>
                        </asp:UpdatePanel>


                    </div>
                </div>
            </div>
        </div>

        <div class="container">
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
    </form>
</body>
</html>
