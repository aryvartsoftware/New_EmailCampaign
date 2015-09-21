<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Testreadmailcontent.aspx.cs" Inherits="New_EmailCampaign.Testreadmailcontent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <asp:ListBox ID="listBox1" runat="server" style="height:auto"></asp:ListBox>
    </div>
    </form>
</body>
</html>
