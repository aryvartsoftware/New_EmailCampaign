<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MassUpdate.aspx.cs" Inherits="New_EmailCampaign.MassUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Email Campaign</title>

    <style type="text/css">
        .labelsuccess {
            background-color: #dff0d8;
            border-color: #d6e9c6;
            color: #3c763d;
            padding: 3px;
        }

        .btnclr {
            border-radius: 3px;
            font-size: 12px;
            line-height: 1.5;
            padding: 5px 10px;
            background-color: #337ab7;
            border-color: #2e6da4;
            color: #fff;
            border: 1px solid transparent;
        }
    </style>

    <script type="text/javascript">
        function checkEmail() {
            var rad = document.getElementById('<%=ddlcolumn.ClientID %>').value;
             var email = document.getElementById('<%=txtCampName.ClientID %>');

             if (rad == "0")
                 alert('Select column name !');
             else {
                 if (rad == "4") {

                     var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

                     if (!filter.test(email.value)) {
                         alert('Please provide a valid email address');
                         email.focus;
                         return false;
                     }
                 }
             }
         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="add-02">
        </div>
        <div class="">

            <div id="Div10" class="add-contact">
                <div class="col-md-12 new_bg list-delete">
                    <div class="row">
                        <span>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                                <ContentTemplate>
                                    <p style="margin-top: -10px; padding: 0;">
                                        <asp:Label ID="lblcontact" CssClass="" runat="server" Text=""></asp:Label></p>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </span>
                        <div class="table-responsive" style="border-radius: 0px;">

                            <asp:UpdatePanel ID="upGrdCustomers" runat="server" UpdateMode="Always">
                                <ContentTemplate>
                                    <div class="collapse" id="collapseExample" runat="server">
                                        <div class="well">
                                            <div class="grid-campaign">
                                                <div class="table-responsive">
                                                    <asp:DropDownList ID="ddlcolumn" Style="width: 200px; height: 30px" required="required" runat="server">
                                                        <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                                        <asp:ListItem Value="1">Campaign Name</asp:ListItem>
                                                        <asp:ListItem Value="2">From Name</asp:ListItem>
                                                        <asp:ListItem Value="3">Title / Subject</asp:ListItem>
                                                        <asp:ListItem Value="4">From Email</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <input type="text" class="form-control" id="txtCampName" style="width: 300px; height: 20px;" name="txtCampName" runat="server" required oncontextmenu="return false;" />


                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <asp:Button ID="btngridsubmit" class="btnclr" runat="server" Style="margin-top: 10px;" Text="Submit" OnClientClick="return checkEmail();" OnClick="btngridsubmit_Click" />
                                    <asp:Label ID="lblsubmit" runat="server" Text=""></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
