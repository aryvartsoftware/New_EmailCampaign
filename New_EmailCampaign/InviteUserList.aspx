<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InviteUserList.aspx.cs" Inherits="New_EmailCampaign.InviteUserList" %>

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
            window.location.href = "SignupSuccess.html";
        }

        function Check_Click(objRef) {
            var row = document.getElementById("<%=gvcampaign.ClientID %>");
            var GridView = row.parentNode;
            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {
                var headerCheckBox = inputList[0];
                var checked = true;
                if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                    if (!inputList[i].checked) {
                        checked = false;
                        break;
                    }
                }
            }
            headerCheckBox.checked = checked;

        }

        function checkAll(objRef) {
            var GridView = document.getElementById("<%=gvcampaign.ClientID %>");
            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {

                        inputList[i].checked = true;
                    }
                    else {
                        inputList[i].checked = false;
                    }
                }
            }

        }
        function MouseEvents(objRef, evt) {
            var checkbox = objRef.getElementsByTagName("input")[0];
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
                <h1>Users</h1>
            </div>
            <div class="settings users">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <h4>Users in
                        <asp:Label ID="lblcompanyname" runat="server" Text=""></asp:Label><span class="list-delete pull-right">
                            <asp:Button ID="btndelete" CssClass="btn btn-default" Style="margin-right: 10px;" runat="server" Text="Delete" OnClick="btndelete_Click" OnClientClick="return confirm('Are you sure you want to delete?');" />
                            <a class="btn btn-default" href="InvitieUser.aspx" role="button">Invite a user</a>
                        </span></h4>
                </div>
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="users-profile">
                        <div class="table-responsive">
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                            <asp:UpdatePanel ID="upGrdCustomers" runat="server" UpdateMode="Always">
                                <ContentTemplate>
                                    <div class="collapse" id="collapseExample" runat="server">
                                        <div class="well">
                                            <div class="grid-campaign">
                                                <div class="table-responsive">
                                                    <table class="table" rules="all" id="gvcampaignss" style="width: 100%; border-collapse: collapse; margin-right: 0px" border="1" cellspacing="0">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 5%; padding: 4px;"></td>
                                                                <td style="width: 2%; padding: 4px;"></td>
                                                                <td style="width: 25%; padding: 4px;">
                                                                    <input name="txtCampName" id="txtCampName" placeholder="Campaign Name" oncontextmenu="return false;" type="text" runat="server" />
                                                                </td>
                                                                <td style="width: 25%; padding: 4px;">
                                                                    <input name="txtTitle" id="txtTitle" placeholder="Title / Subject" oncontextmenu="return false;" type="text" runat="server" />
                                                                </td>
                                                                <td style="width: 25%; padding: 4px;">
                                                                    <input name="txtStatus" id="txtStatus" placeholder="From Name" oncontextmenu="return false;" type="text" runat="server" />
                                                                </td>
                                                                <td style="width: 18%; padding: 4px;">
                                                                    <p class="text-center">
                                                                    </p>
                                                                </td>

                                                            </tr>
                                                        </tbody>

                                                    </table>

                                                </div>

                                            </div>
                                        </div>
                                    </div>

                                    <asp:GridView ID="gvcampaign" runat="server" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True"
                                        Width="100%" Style="margin-right: 0px" CssClass="table" OnPageIndexChanging="gvcampaign_PageIndexChanging">

                                        <RowStyle CssClass="grid-sample" />
                                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                        <SortedDescendingHeaderStyle BackColor="#242121" />

                                        <Columns>

                                            <asp:TemplateField HeaderText="" ItemStyle-Width="5%">
                                                <ItemTemplate>
                                                    <asp:HyperLink runat="server" CssClass="boder0" NavigateUrl='<%# string.Format("~/InvitieUser.aspx?CampInvtusrId={0}", HttpUtility.UrlEncode(Eval("PK_UserID").ToString())) %>'
                                                        Text="Edit" />
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="grid-header01" Width="5%" />
                                                <ItemStyle CssClass="grid-item" Width="5%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="checkAll" onclick="checkAll(this);" runat="server" Style="width: 95%" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" onclick="Check_Click(this)" Style="width: 95%" />

                                                </ItemTemplate>
                                                <HeaderStyle CssClass="grid-header02" Width="2%" />
                                                <ItemStyle CssClass="grid-item" Width="2%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Serial" Visible="false">

                                                <ItemTemplate>

                                                    <asp:Label ID="lblEmpID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PK_UserID") %>'></asp:Label>

                                                </ItemTemplate>

                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Image">
                                                <ItemTemplate>

                                                    <asp:Image ID="imgEmployeeImage" runat="server" ImageUrl='<%# "~/UserImage/"+ Eval("userphoto") %>' Width="80px" Height="80px" />
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="grid-header02" Width="13%" />
                                                <ItemStyle CssClass="grid-item" Width="13%" />
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="User ID" SortExpression="UserName">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("~/InvitieUser.aspx?CampInvtusrId={0}",HttpUtility.UrlEncode(Eval("PK_UserID").ToString())) %>' Text='<%# Bind("UserName") %>'></asp:HyperLink>
                                                </ItemTemplate>

                                                <HeaderStyle CssClass="grid-header03" Width="30%" />
                                                <ItemStyle CssClass="grid-item" Width="30%" />

                                            </asp:TemplateField>
                                            <asp:BoundField SortExpression="email_id" DataField="email_id" HeaderText="Email id" HeaderStyle-CssClass="grid-header04" HeaderStyle-Width="30%" ItemStyle-CssClass="grid-item" ItemStyle-Width="30%" FooterStyle-CssClass="grid-item">
                                                <FooterStyle CssClass="grid-item" />
                                                <HeaderStyle CssClass="grid-header04" Width="30%" />
                                                <ItemStyle CssClass="grid-item" Width="30%" />
                                            </asp:BoundField>

                                            <asp:BoundField SortExpression="RoleName" DataField="RoleName" HeaderText="Account Type" HeaderStyle-CssClass="grid-header05" HeaderStyle-Width="20%" ItemStyle-CssClass="grid-item" ItemStyle-Width="20%" FooterStyle-CssClass="grid-item">


                                                <FooterStyle CssClass="grid-item" />
                                                <HeaderStyle CssClass="grid-header05" Width="20%" />
                                                <ItemStyle CssClass="grid-item" Width="20%" />
                                            </asp:BoundField>


                                        </Columns>

                                        <EmptyDataRowStyle BackColor="#edf5ff" Height="300px" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <EmptyDataTemplate>
                                            No Records Found
                                        </EmptyDataTemplate>
                                        <HeaderStyle CssClass="grid-view" />

                                        <PagerStyle CssClass="grid-item" />
                                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                        <SortedDescendingHeaderStyle BackColor="#242121" />

                                    </asp:GridView>

                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
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
