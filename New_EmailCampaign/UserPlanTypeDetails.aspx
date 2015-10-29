<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPlanTypeDetails.aspx.cs" Inherits="New_EmailCampaign.UserPlanTypeDetails" %>
<%@ Register TagPrefix="uc" TagName="Spinner" Src="~/Common_Menu.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Email Campaign</title>
    <link href='http://fonts.googleapis.com/css?family=Lato:400,700' rel='stylesheet' type='text/css'>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/stylesheet.css" rel="stylesheet" />
    <link href="css/bootstrap-datetimepicker.min.css" rel="stylesheet" />

    <script src="js/jqueryv11.2.js"></script>
    <script src="js/bootstrap-datetimepicker.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
         <uc:Spinner ID="Spinner1"
            runat="server"
            MinValue="1"
            MaxValue="10" />

        <div class="container new_campaign">
            <div class="list-contact">
                <span>
                    <a class="btn btn-default active" href="UserPlanType.aspx" role="button">New Plan</a>

                </span>
            </div>

            <div class="col-md-12 new_bg list-delete">
                <div class="row">
                    <span>
                        <asp:Button ID="btndelete" CssClass="btn btn-default" Style="margin-right: 10px;" runat="server" Text="Delete" OnClick="btndelete_Click" OnClientClick="return confirm('Are you sure you want to delete?');" />

                        <asp:Button ID="btnreload" CssClass="btn btn-default" runat="server" Text="Reload" OnClick="btnreload_Click" />

                        <a class="glyphicon glyphicon-search" data-toggle="collapse" href="#collapseExample" onclick="return Clearuserinput();" aria-expanded="false" aria-controls="collapseExample"></a>


                    </span>
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
                                                                <input name="txtCampName" id="txtCampName" placeholder="Plan Name" oncontextmenu="return false;" type="text" runat="server" />
                                                            </td>
                                                            <td style="width: 18%; padding: 4px;">
                                                                <p class="text-center">
                                                                    <asp:Button ID="Button1" CssClass="btn btn-default red" runat="server" Text="Filter" OnClick="Button1_Click" />
                                                                    <asp:Button ID="Button2" CssClass="btn btn-default gray" runat="server" Text="Cancel" OnClick="Button2_Click" />

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
                                    Width="100%" Style="margin-right: 0px" CssClass="table" OnDataBound="gvcampaign_DataBound" OnPageIndexChanging="gvcampaign_PageIndexChanging" OnSorting="gvcampaign_Sorting" OnPreRender="gvcampaign_PreRender">


                                    <RowStyle CssClass="grid-sample" />
                                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                    <SortedDescendingHeaderStyle BackColor="#242121" />

                                    <Columns>

                                        <asp:TemplateField HeaderText="" ItemStyle-Width="3%">
                                            <ItemTemplate>
                                                <asp:HyperLink runat="server" CssClass="boder0" NavigateUrl='<%# string.Format("~/UserPlanType.aspx?PlantypId={0}", HttpUtility.UrlEncode(Eval("PK_PlanID").ToString())) %>'
                                                    Text="Edit" />
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="grid-header01" Width="3%" />
                                            <ItemStyle CssClass="grid-item" Width="3%" />
                                            <FooterStyle Width="3%" />
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
                                            <FooterStyle Width="2%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Serial" Visible="false">

                                            <ItemTemplate>

                                                <asp:Label ID="lblThirdPartyId" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PK_PlanID") %>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Plan Name" SortExpression="PlanName">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("~/UserPlanType.aspx?PlantypId={0}",HttpUtility.UrlEncode(Eval("PK_PlanID").ToString())) %>' Text='<%# Bind("PlanName") %>'></asp:HyperLink>

                                            </ItemTemplate>
                                            <HeaderStyle CssClass="grid-header03" Width="30%" />
                                            <ItemStyle CssClass="grid-item" Width="30%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Single User">
                                            <ItemTemplate>
                                                <asp:Image ID="imgEmployeeImage" runat="server" ImageUrl='<%# "~/images/Tick_inside_a_circle_24(1).png" %>' Visible='<%# Eval("IsSingleUser").ToString() == "True" ? true : false %>' Width="30px" Height="30px" />
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="grid-header02" Width="13%" />
                                            <ItemStyle CssClass="grid-item" Width="13%" />
                                        </asp:TemplateField>

                                        <asp:BoundField SortExpression="Planrate" DataField="Planrate" HeaderText="Plan Rate ($)" HeaderStyle-CssClass="grid-header04" HeaderStyle-Width="10%" ItemStyle-CssClass="grid-item" ItemStyle-Width="30%">

                                            <HeaderStyle CssClass="grid-header04" Width="10%" />
                                            <ItemStyle CssClass="grid-item" Width="10%" />
                                        </asp:BoundField>

                                        <asp:BoundField SortExpression="NOC" DataField="NOC" HeaderText="Number of Subscribers" HeaderStyle-CssClass="grid-header05" HeaderStyle-Width="15%" ItemStyle-CssClass="grid-item" ItemStyle-Width="30%" FooterStyle-CssClass="grid-item">



                                            <FooterStyle CssClass="grid-item" />
                                            <HeaderStyle CssClass="grid-header05" Width="15%" />
                                            <ItemStyle CssClass="grid-item" Width="15%" />
                                        </asp:BoundField>
                                        <asp:BoundField SortExpression="AllowedMails" DataField="AllowedMails" HeaderText="Allowed Mails" HeaderStyle-CssClass="grid-header05" HeaderStyle-Width="15%" ItemStyle-CssClass="grid-item" ItemStyle-Width="15%" FooterStyle-CssClass="grid-item">



                                            <FooterStyle CssClass="grid-item" />
                                            <HeaderStyle CssClass="grid-header05" Width="15%" />
                                            <ItemStyle CssClass="grid-item" Width="15%" />
                                        </asp:BoundField>

                                        <asp:TemplateField HeaderText="Is Active">
                                            <ItemTemplate>
                                                <asp:Image ID="imgIsActive" runat="server" ImageUrl='<%# "~/images/Tick_inside_a_circle_24(1).png" %>' Visible='<%# Eval("IsActive").ToString() == "True" ? true : false %>' Width="30px" Height="30px" />
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="grid-header02" Width="12%" />
                                            <ItemStyle CssClass="grid-item" Width="12%" />
                                        </asp:TemplateField>

                                    </Columns>

                                    <EmptyDataRowStyle BackColor="#edf5ff" Height="300px" VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <EmptyDataTemplate>
                                        No Records Found
                                    </EmptyDataTemplate>
                                    <HeaderStyle CssClass="grid-view" />

                                    <PagerStyle CssClass="grid-item" />

                                    <PagerTemplate>
                                        <table width="100%" style="padding-top: 10px;">
                                            <tr>
                                                <td style="width: 42%;">
                                                    <b>Page Size: </b>
                                                    <asp:DropDownList ID="ddPageSize" Style="width: auto;" runat="server" EnableViewState="true" OnSelectedIndexChanged="ddPageSize_SelectedIndexChanged" AutoPostBack="true">
                                                        <asp:ListItem Text="10"></asp:ListItem>
                                                        <asp:ListItem Text="20"></asp:ListItem>
                                                        <asp:ListItem Text="30"></asp:ListItem>
                                                        <asp:ListItem Text="40"></asp:ListItem>
                                                        <asp:ListItem Text="50"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="imgPageFirst" runat="server"
                                                        ImageUrl="~/images/first.png"
                                                        CommandArgument="First" CommandName="Page"
                                                        OnCommand="imgPageFirst_Command"></asp:ImageButton>
                                                    <asp:ImageButton ID="imgPagePrevious"
                                                        runat="server" ImageUrl="~/images/previous.png"
                                                        CommandArgument="Prev" CommandName="Page"
                                                        OnCommand="imgPagePrevious_Command"></asp:ImageButton>


                                                    <asp:Label ID="lblTotalPage" runat="server" CssClass="Normal"></asp:Label>
                                                    <asp:ImageButton ID="imgPageNext" runat="server"
                                                        ImageUrl="~/images/next.png"
                                                        CommandArgument="Next" CommandName="Page"
                                                        OnCommand="imgPageNext_Command"></asp:ImageButton>
                                                    <asp:ImageButton ID="imgPageLast" runat="server"
                                                        ImageUrl="~/images/last.png"
                                                        CommandArgument="Last" CommandName="Page"
                                                        OnCommand="imgPageLast_Command"></asp:ImageButton>
                                                </td>
                                                <td class="text-right">
                                                    <asp:Label ID="Label1" runat="server" CssClass="Normal"></asp:Label>
                                                    <asp:Label ID="lblPageCount" runat="server"></asp:Label>
                                                </td>
                                            </tr>

                                        </table>
                                    </PagerTemplate>

                                    <RowStyle CssClass="grid-item" />
                                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                    <SortedDescendingHeaderStyle BackColor="#242121" />

                                </asp:GridView>
                                <div class="AlphabetPager">
                                    <asp:Repeater ID="rptAlphabets" runat="server">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" Text='<%#Eval("Value")%>' Visible='<%# !Convert.ToBoolean(Eval("Selected"))%>'
                                                OnClick="Alphabet_Click" />
                                            <asp:Label runat="server" Text='<%#Eval("Value")%>' Visible='<%# Convert.ToBoolean(Eval("Selected"))%>' />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
        <!-- end campaign section -->
    </form>
</body>
</html>
