<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactsView.aspx.cs" Inherits="New_EmailCampaign.ContactsView" %>

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
    <script src="js/bootstrap.min.js"></script>
    <script src="js/ModalPopupWindow.js"></script>
      <style type="text/css">
        .errorClass
        {
            border: 1px solid red;
        }
    </style>
    <script type="text/javascript">
        var modalWin = new CreateModalPopUpObject();
        modalWin.SetLoadingImagePath("images/loading.gif");
        modalWin.SetCloseButtonImagePath("images/close_icon.png");
        //Uncomment below line to make look buttons as link
        //modalWin.SetButtonStyle("background:none;border:none;textDecoration:underline;cursor:pointer");

        function ShowNewPage(rr) {


            var callbackFunctionArray = new Array(EnrollNow, EnrollLater);

            if (rr.indexOf('MassUpdateContact.aspx') >= 0)
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
        //Grid view check all clicked all check box in grid will be checked
        function Check_Click(objRef) {
            //var row = objRef.parentNode.parentNode;
            var row = document.getElementById("<%=gvCampaign.ClientID %>");
            //Get the reference of GridView
            var GridView = row.parentNode;

            //Get all input elements in Gridview
            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {
                //The First element is the Header Checkbox
                var headerCheckBox = inputList[0];

                //Based on all or none checkboxes
                //are checked check/uncheck Header Checkbox
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
            //var GridView = objRef.parentNode.parentNode.parentNode;
            var GridView = document.getElementById("<%=gvCampaign.ClientID %>");
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                //Get the Cell To find out ColumnIndex
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        //If the header checkbox is checked
                        //check all checkboxes
                        //and highlight all rows

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
        //-----------------
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
    <div class="row">
      <div class="container">
        <div class="row">
          <!-- Fixed navbar -->
          <div class="main-menu"> <!-- start menu section -->
            <nav class="navbar navbar-default navbar-fixed-top">
              <div class="container">
                <div class="navbar-header">
                  <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                  </button>
                  <a class="navbar-brand" href="#">Menus</a>
                </div>
                <div id="navbar" class="navbar-collapse collapse">
                  <ul class="nav navbar-nav">
                    <li><a href="CreateCampaignList.aspx">Campaign</a></li>
                    
                    <li class="active"><a href="ContactsView.aspx">Contacts</a></li>
                      
                        <% if (Session["vewrpts"] != null)
              {
                  if (Convert.ToInt32(Session["vewrpts"].ToString()) == 1)
                  { %> 
                      <li><a href="CampaignReportList.aspx">Report</a></li>
                       <%}
              }%>
                  </ul>
                  <ul class="nav navbar-nav navbar-right">
                    <li><a href="#">Help</a></li>
                    <li class="dropdown">
                      <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Exit <span class="caret"></span></a>
                      <ul class="dropdown-menu" role="menu">
                          <li><a href="CreateProfile.aspx">Profile</a></li>
                        <li><a href="#">Dashboard</a></li>
                        <li><a href="CreateCampaignList.aspx">Campaign</a></li>
                        <li><a href="RoleDetails.aspx">Role</a></li> 
                        <li><a href="RoleSettings.aspx">Access Settings</a></li>
                          <li><a href="RoleSettings.aspx">Role Access</a></li>
                           <% if (Session["crtusr"] != null)
              {
                  if (Convert.ToInt32(Session["crtusr"].ToString()) == 1)
                  { %> 
                          <li><a href="InviteUserList.aspx">Invite User</a></li>
                           <%}
              }%>
                        <li class="divider"></li>
                        <li><a href="UserLogin.aspx">Log Out </a></li>
                      </ul>
                    </li>
                  </ul>
                </div><!--/.nav-collapse -->
              </div>
            </nav>
          </div> <!-- end menu section -->          
        </div>
      </div>
    </div>
  </div>
        <div class="container-fluid bg">
    <div class="container new_campaign">  <!-- start campaign section --> 
      <div class="list-contact">
       <span>
            <%--<a class="btn btn-default active" href="ContactsAdd.aspx" role="button" on>New Contact</a> --%>
           <asp:Button ID="btnnewcontact" class="btn btn-default active" runat="server" Text="New Contact" OnClick="btnnewcontact_Click" />
           <% if (Session["lstexprts"] != null)
              {
                  if (Convert.ToInt32(Session["lstexprts"].ToString()) == 1)
                  { %>   
           <a class="btn btn-default" href="ImportReciepientsList.aspx" role="button">Import Contacts</a> 
            <%}
              }%>
           <asp:Button ID="Button3" CssClass="btn btn-default" runat="server" Text="Mass Update" style="display:;" OnClick="Button3_Click"/>
       </span>
      </div>
      <div class="col-md-12 new_bg list-delete">     
        <div class="row">
           <span>
            <asp:Button ID="btndelete" CssClass="btn btn-default" Style="margin-right:10px;" runat="server" Text="Delete" OnClick="btndelete_Click" OnClientClick="return confirm('Are you sure you want to delete?');" />
 <asp:Button ID="btnreload" CssClass="btn btn-default" runat="server" Text="Reload"  OnClick="btnreload_Click"/>
               <a class="glyphicon glyphicon-search" data-toggle="collapse" href="#collapseExample" onclick="return Clearuserinput();" aria-expanded="false" aria-controls="collapseExample"></a>


       </span> 
    <div class="table-responsive">  
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="upGrdCustomers" runat="server" UpdateMode="Always" >
    <ContentTemplate>
         <div class="collapse" id="collapseExample" runat="server">
  <div class="well">
   <div class="grid-campaign">
           <div class="table-responsive">  
         <table>
            <tbody>
              <tr>
                <td class="grid-item01"></td>
                <td class="grid-item02">
                  <input type="text" oncontextmenu="return false;" runat="server" id="txtCampName" name="txtCampName" placeholder="Name" />
                </td>
                 <td class="grid-item03">
                  <input type="text" oncontextmenu="return false;" runat="server" id="txtTitle" name="txtTitle" placeholder="Designation" />
                </td>
                <td class="grid-item05">                  
                  <input type="text" oncontextmenu="return false;" runat="server" id="txtStatus" name="txtStatus" placeholder="Contact No" />
                </td>               
                <td class="grid-item06">
                <input type="text" oncontextmenu="return false;" runat="server" id="txtemail" name="txtemail" placeholder="Email ID" />
                </td>               
                <td class="grid-item07">
                  <input type="text" oncontextmenu="return false;" runat="server" id="txtcity" name="txtcity" placeholder="City" />
                </td>
                <td class="grid-item08">
                  <input type="text" oncontextmenu="return false;" runat="server" id="txtState" name="txtState" placeholder="State" />
                </td>
                <td class="grid-item09">
                  <input type="text" oncontextmenu="return false;" runat="server" id="txtCountry" name="txtCountry" placeholder="Country" />
                </td> 
                  
              </tr>
            </tbody>
          </table> 
                </div>
       <p class="text-right" style="margin:0;">
            <asp:Button ID="Button1" CssClass="btn btn-default red" runat="server" Text="Filter" OnClick="Button1_Click" />
        <asp:Button ID="Button2" CssClass="btn btn-default gray" runat="server" Text="Cancel" OnClick="Button2_Click" />
        </p> 
         
          </div>
  </div>
</div>
    <asp:GridView ID="gvCampaign" runat="server" AutoGenerateColumns="False" AllowSorting="True"  AllowPaging="True" 
               Width="100%" style="margin-right: 0px"  CssClass="table" OnDataBound="gvCampaign_DataBound" OnPageIndexChanging="gvCampaign_PageIndexChanging" OnSorting="gvCampaign_Sorting" OnPreRender="gvCampaign_PreRender">
              <RowStyle CssClass="grid-sample" />
                       <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                       <SortedAscendingCellStyle BackColor="#F7F7F7" />
                       <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                       <SortedDescendingCellStyle BackColor="#E5E5E5" />
                       <SortedDescendingHeaderStyle BackColor="#242121" />

                      
        <EmptyDataRowStyle BackColor="#edf5ff" Height="300px" VerticalAlign="Middle" HorizontalAlign="Center" />
                    <EmptyDataTemplate >
                        No Records Found
                    </EmptyDataTemplate> 
            <Columns>
                   <asp:TemplateField HeaderText = "" ItemStyle-Width="30">
            <ItemTemplate>
                <asp:HyperLink runat="server" NavigateUrl='<%# string.Format("~/ContactsAdd.aspx?CntId={0}", HttpUtility.UrlEncode(Eval("PK_ContactID").ToString())) %>'
                    Text="Edit" />
            </ItemTemplate>
                       <HeaderStyle CssClass="grid-contact01" Width="5%"/>
                               <ItemStyle Width="5%"/>
        </asp:TemplateField>

                <asp:TemplateField>
            <HeaderTemplate>
                <asp:CheckBox ID="checkAll" onclick="checkAll(this);" runat="server" style="width:95%" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox ID="CheckBox1" runat="server" onclick="Check_Click(this)" style="width:95%"/>
            </ItemTemplate>
                      <HeaderStyle CssClass="grid-contact02" Width="2%"/>
              <ItemStyle CssClass="grid-item" Width="2%"/>
        </asp:TemplateField>
 
            <asp:TemplateField HeaderText="CntID" Visible="false">
              <ItemTemplate>
                <asp:Label ID="lblEmpID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PK_ContactID") %>' ></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
              
 
            <asp:TemplateField HeaderText="Name" SortExpression="ContactName">
             
              <ItemTemplate>
                   <asp:HyperLink ID="HyperLink1" runat="server"  Text='<%# Bind("ContactName") %>' ></asp:HyperLink>
                <%--NavigateUrl='<%# string.Format("~/ContactsAdd.aspx?CntnamID={0}",HttpUtility.UrlEncode(Eval("PK_ContactID").ToString())) %>'--%>
              </ItemTemplate>
            <HeaderStyle CssClass="grid-contact03" Width="15%" />
                           <ItemStyle CssClass="grid-item" Width="15%" />
            </asp:TemplateField>                

             <asp:BoundField SortExpression="Designation" DataField="Designation" HeaderText="Designation" HeaderStyle-CssClass="grid-contact04" ItemStyle-CssClass="grid-item">
                   <HeaderStyle CssClass="grid-contact04" Width="10%" />
                           <ItemStyle CssClass="grid-item" Width="10%" />
                           </asp:BoundField>

                 <asp:BoundField SortExpression="ContactNo" DataField="ContactNo" HeaderText="Contact No." HeaderStyle-CssClass="grid-contact04" ItemStyle-CssClass="grid-item">
                 <HeaderStyle CssClass="grid-contact05" Width="10%" />
                           <ItemStyle CssClass="grid-item" Width="10%" />
                           </asp:BoundField>


             <%--   <asp:TemplateField HeaderText="Email ID" SortExpression="email_id">
             
              <ItemTemplate>
                   
                                  <asp:TextBox ID="lblEmailID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "email_id") %>' Width="100%"></asp:TextBox>
              
              </ItemTemplate>
            <HeaderStyle CssClass="grid-contact06" Width="15%" />
                           <ItemStyle CssClass="grid-item" Width="15%" />
            </asp:TemplateField>   --%>
<asp:BoundField SortExpression="email_id" DataField="email_id" HeaderText="Email ID" HeaderStyle-CssClass="grid-contact04" ItemStyle-CssClass="grid-item">
                   <HeaderStyle CssClass="grid-contact06" Width="15%" />
                           <ItemStyle CssClass="grid-item" Width="15%" />
                           </asp:BoundField>

              <asp:BoundField SortExpression="City1" DataField="City1" HeaderText="City" HeaderStyle-CssClass="grid-contact04" ItemStyle-CssClass="grid-item">
                 <HeaderStyle CssClass="grid-contact07" Width="14%" />
                           <ItemStyle CssClass="grid-item" Width="14%" />
                           </asp:BoundField>

                <asp:BoundField SortExpression="State1" DataField="State1" HeaderText="State" HeaderStyle-CssClass="grid-contact04" ItemStyle-CssClass="grid-item">
                   <HeaderStyle CssClass="grid-contact08" Width="14%" />
                           <ItemStyle CssClass="grid-item" Width="14%" />
                           </asp:BoundField>

                <asp:BoundField SortExpression="Country1" DataField="Country1" HeaderText="Country" HeaderStyle-CssClass="grid-contact04" ItemStyle-CssClass="grid-item">
                   <HeaderStyle CssClass="grid-contact09" Width="15%" />
                           <ItemStyle CssClass="grid-item" Width="15%" />
                           </asp:BoundField>
                 
            </Columns>

         <HeaderStyle CssClass="grid-view grid-text" />

               <PagerTemplate>
                   <table width="100%" style="padding-top:10px;">
                            <tr>
                                <td style="width:42%;">
                                    <b>Page Size: </b>
                                    <asp:DropDownList ID="ddPageSize" style="width:auto;" runat="server" EnableViewState="true" OnSelectedIndexChanged="ddPageSize_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Text="10" ></asp:ListItem>
                                        <asp:ListItem Text="20" ></asp:ListItem>
                                        <asp:ListItem Text="30" ></asp:ListItem>
                                        <asp:ListItem Text="40" ></asp:ListItem>
                                        <asp:ListItem Text="50" ></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                     <asp:ImageButton ID="imgPageFirst" runat="server" 
		ImageUrl="~/images/first.png"
		CommandArgument="First" CommandName="Page" 
		OnCommand="imgPageFirst_Command">
	</asp:ImageButton>
	<asp:ImageButton ID="imgPagePrevious" 
		runat="server" ImageUrl="~/images/previous.png"
		CommandArgument="Prev" CommandName="Page" 
		OnCommand="imgPagePrevious_Command">
	</asp:ImageButton>
    
	
    <asp:Label ID="lblTotalPage" runat="server"  CssClass="Normal"></asp:Label>
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
            <PagerStyle CssClass = "grid-item"  />
                       <%--<SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                       <SortedAscendingCellStyle BackColor="#F7F7F7" />
                       <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                       <SortedDescendingCellStyle BackColor="#E5E5E5" />
                       <SortedDescendingHeaderStyle BackColor="#242121" />--%>

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
    </div>   <!-- end campaign section -->    

    <div class="container new_footer"> <!-- start footer section --> 
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
          <p><img src="images/footer_tick.png"> Getting Started </p>
         <p><img src="images/footer-vids.png"> Video Tutorials</p>
         <p><img src="images/footer-andy.png"> Email Campaign Business Blog</p>
        </div>
        <div class="col-md-5 faq">
          <h3><img src="images/footer-faq.png"> Frequently Asked Questions</h3>
          <ul class="list-unstyled">
            <li>How do I personalize the subject line of my email?</li>
            <li>Why is my email campaign "Under Review"?</li>
            <li>Can I Add Google Analytics Tracking To My Email Campaigns?</li>
            <li>More Help Articles</li>
          </ul>
        </div>
      </div>
    </div>  <!-- end footer section -->  
    
  </div>
    </form>
</body>
</html>
