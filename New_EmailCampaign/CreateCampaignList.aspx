<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateCampaignList.aspx.cs" Inherits="New_EmailCampaign.CreateCampaignList" %>

<%@ Register TagPrefix="uc" TagName="Spinner" Src="~/Common_Menu.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Email Campaign</title>
    <link href='http://fonts.googleapis.com/css?family=Lato:400,700' rel='stylesheet' type='text/css'>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/stylesheet.css" rel="stylesheet" />
    <link href="css/modalwindow.css" rel="stylesheet" />
    <link href="css/bootstrap-datetimepicker.min.css" rel="stylesheet" />

    <script src="js/jqueryv11.2.js"></script>
    <script src="js/bootstrap-datetimepicker.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/ModalPopupWindow.js"></script>
    <script type="text/javascript">

        $(function () {
            $('#datetimepicker1').datetimepicker({
                language: 'pt-BR',
                pickTime: false
            });
        });

        var modalWin = new CreateModalPopUpObject();
        modalWin.SetLoadingImagePath("images/loading.gif");
        modalWin.SetCloseButtonImagePath("images/close_icon.png");

        function ShowNewPage(rr) {
            var callbackFunctionArray = new Array(EnrollNow, EnrollLater);

            if (rr.indexOf('MassUpdate.aspx') >= 0)
                modalWin.ShowURL(rr, 170, 550, '<b>Mass Update</b>', null, callbackFunctionArray);

        }

        function EnrollNow(msg) {
            modalWin.HideModalPopUp();
            modalWin.ShowMessage(msg, 200, 400, 'User Information', null, null);
        }

        function EnrollLater() {
            modalWin.HideModalPopUp();
            modalWin.ShowMessage(msg, 200, 400, 'User Information', null, null);
        }


        function HideModalWindow() {
            modalWin.HideModalPopUp();
        }
    </script>
    <script type="text/javascript">

        function Clearuserinput() {
            $('input[type=text], textarea').each(function () {
                $(this).val('');
            });

        }

        function Clearuserinputselect() {
            var theAnswer = confirm("Are you sure you want to clear the input?");

            if (theAnswer) {
                $('input[type=text], textarea').each(function () {
                    $(this).val('');
                });
                $("#form1 select").val("0");
            }
            else {
                return false;
            }
            return false;
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

        <div class="container-fluid bg">
            <div class="container new_campaign">
                <div class="list-contact">
                    <span>
                        <% if (Session["cmpcrte"] != null)
                           {
                               if (Convert.ToInt32(Session["cmpcrte"].ToString()) == 1)
                               { %>
                        <a class="btn btn-default active" href="CampaignEdit.aspx" role="button">New Campaign</a>  <%}
                           }%>
                        <asp:Button ID="Button3" CssClass="btn btn-default" runat="server" Text="Mass Update" Style="display: ;" OnClick="Button3_Click" />
                    </span>
                </div>

                <div class="col-md-12 new_bg list-delete">
                    <div class="row">
                        <span>
                            <% if (Session["cmpdelete"] != null)
                               {
                                   if (Convert.ToInt32(Session["cmpdelete"].ToString()) == 1)
                                   { %>
                            <asp:Button ID="btndelete" CssClass="btn btn-default" Style="margin-right: 10px;" runat="server" Text="Delete" OnClick="btndelete_Click" OnClientClick="return confirm('Are you sure you want to delete?');" />
                            <%}
                               }%>
                            <asp:Button ID="btnreload" CssClass="btn btn-default" runat="server" Text="Reload" OnClick="btnreload_Click" />

                            <a class="glyphicon glyphicon-search" data-toggle="collapse" href="#collapseExample" onclick="return Clearuserinput();" aria-expanded="false" aria-controls="collapseExample"></a>


                        </span>
                        <div class="table-responsive">

                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>

                            <div class="collapse" id="collapseExample" runat="server">
                                <div class="well">
                                    <div class="grid-campaign">
                                        <div class="table-responsive">
                                            <table class="table" rules="all" id="gvcampaignss" style="width: 100%; border-collapse: collapse; margin-right: 0px" border="1" cellspacing="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 2%; padding: 4px;"></td>
                                                        <td style="width: 20%; padding: 4px;">
                                                            <input name="txtCampName" id="txtCampName" placeholder="Campaign Name" oncontextmenu="return false;" type="text" runat="server" />
                                                        </td>
                                                        <td style="width: 20%; padding: 4px;">
                                                            <input name="txtTitle" id="txtTitle" placeholder="Title / Subject" oncontextmenu="return false;" type="text" runat="server" />
                                                        </td>
                                                        <td style="width: 20%; padding: 4px;">
                                                            <input name="txtStatus" id="txtStatus" placeholder="From Name" oncontextmenu="return false;" type="text" runat="server" />
                                                        </td>
                                                        <td style="width: 20%; padding: 4px;">
                                                            <div class="date-time">
                                                                <div id="datetimepicker1" class="input-append">
                                                                    <input id="dtScheduledatetime" style="width: 180px;" data-format="dd/MM/yyyy" runat="server" type="text" />
                                                                    <span class="add-on marg-top">
                                                                        <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
                                                                    </span>
                                                                </div>
                                                            </div>
                                                        </td>

                                                        <td style="width: 17%; padding: 4px;">
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

                            <asp:UpdatePanel ID="upGrdCustomers" runat="server" UpdateMode="Always">
                                <ContentTemplate>
                                    <asp:GridView ID="gvcampaign" runat="server" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True"
                                        Width="100%" Style="margin-right: 0px" CssClass="table" OnDataBound="gvcampaign_DataBound" OnPageIndexChanging="gvcampaign_PageIndexChanging" OnSorting="gvcampaign_Sorting" OnPreRender="gvcampaign_PreRender">

                                        <RowStyle CssClass="grid-sample" />
                                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                        <SortedDescendingHeaderStyle BackColor="#242121" />

                                        <Columns>

                                            <asp:TemplateField HeaderText="" ItemStyle-Width="30">
                                                <ItemTemplate>
                                                    <asp:HyperLink runat="server" CssClass="boder0" NavigateUrl='<%# string.Format("~/CampaignEdit.aspx?CampId={0}", HttpUtility.UrlEncode(Eval("PK_CampaignID").ToString())) %>'
                                                        Text="Edit" />
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="grid-header01" Width="5%" />
                                                <ItemStyle CssClass="grid-item" Width="30px" />
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

                                                    <asp:Label ID="lblThirdPartyId" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PK_CampaignID") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Campaign Name" SortExpression="CampaignName">
                                                <ItemTemplate>
                                                    <% if (Session["cmpsend"] != null)
                                                       {
                                                    %>
                                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("~/CreateCampign.aspx?CampgnID={0}",HttpUtility.UrlEncode(Eval("PK_CampaignID").ToString())) %>' Text='<%# Bind("CampaignName") %>'></asp:HyperLink>
                                                    <%}
                                                       else
                                                       {%>
                                                    <asp:Label ID="lblcmpname" runat="server" Text='<%# Bind("CampaignName") %>'></asp:Label>
                                                    <%}%>
                                                </ItemTemplate>

                                                <HeaderStyle CssClass="grid-header03" Width="30%" />
                                                <ItemStyle CssClass="grid-item" Width="30%" />
                                            </asp:TemplateField>
                                            <asp:BoundField SortExpression="Title" DataField="Title" HeaderText="Title / Subject" HeaderStyle-CssClass="grid-header04" HeaderStyle-Width="25%" ItemStyle-CssClass="grid-item" ItemStyle-Width="25%">

                                                <HeaderStyle CssClass="grid-header04" Width="25%" />
                                                <ItemStyle CssClass="grid-item" Width="25%" />
                                            </asp:BoundField>

                                            <asp:BoundField SortExpression="FromName" DataField="FromName" HeaderText="From Name" HeaderStyle-CssClass="grid-header05" HeaderStyle-Width="25%" ItemStyle-CssClass="grid-item" ItemStyle-Width="25%" FooterStyle-CssClass="grid-item">

                                                <FooterStyle CssClass="grid-item" />
                                                <HeaderStyle CssClass="grid-header05" Width="25%" />
                                                <ItemStyle CssClass="grid-item" Width="25%" />
                                            </asp:BoundField>

                                            <asp:BoundField SortExpression="CreatedOn" DataFormatString="{0:MM/dd/yyyy}" DataField="CreatedOn" HeaderText="Start Date" HeaderStyle-CssClass="grid-header05" HeaderStyle-Width="13%" ItemStyle-CssClass="grid-item" ItemStyle-Width="13%" FooterStyle-CssClass="grid-item">

                                                <FooterStyle CssClass="grid-item" />
                                                <HeaderStyle CssClass="grid-header05" Width="13%" />
                                                <ItemStyle CssClass="grid-item" Width="13%" />
                                            </asp:BoundField>

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

            <div class="container new_footer">
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
                            Getting Started
                        </p>
                        <p>
                            <img src="images/footer-vids.png">
                            Video Tutorials
                        </p>
                        <p>
                            <img src="images/footer-andy.png">
                            Email Campaign Business Blog
                        </p>
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
            <!-- end footer section -->

        </div>
    </form>
</body>
</html>
