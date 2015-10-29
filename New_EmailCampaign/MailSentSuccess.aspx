<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MailSentSuccess.aspx.cs" Inherits="New_EmailCampaign.MailSentSuccess" %>

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

    <script src="js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <uc:Spinner ID="Spinner1"
            runat="server"
            MinValue="1"
            MaxValue="10" />

        <div class="container bg">
            <div class="row">
                <div class="sent-mail">
                    <div class="sent-mail01">
                        <img src="images/sent-mail.png" class="img-responsive">
                    </div>
                    <div class="sent-mail02">
                        <h2>Aryvart Campaign!</h2>
                        <h3>Your campaign is in the
                            <br />
                            send queue and will go out shortly.</h3>
                        <p>visit at <a href="http://www.aryvart.com" target="_blank">www.aryvart.com</a></p>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
