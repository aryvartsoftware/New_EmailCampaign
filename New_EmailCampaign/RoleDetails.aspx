<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleDetails.aspx.cs" Inherits="New_EmailCampaign.RoleDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Email Campaign</title>
    <link href='http://fonts.googleapis.com/css?family=Lato:400,700' rel='stylesheet' type='text/css'/>
      <link href="css/bootstrap.css" rel="stylesheet" />
  <link href="css/style.css" rel="stylesheet" />

     <script src="js/jquery.min.js"></script>
  <script src="js/bootstrap.min.js"></script>

 <script type="text/javascript">
    function Clearuserinput11() {
            $('input[type=text], textarea').each(function () {
                $(this).val('');
            });
            alert('Information Successfully Saved');
    }

    function Clearuserinput() {
        $('input[type=text], textarea').each(function () {
            $(this).val('');
        });
        }

    function Check_Click(objRef) {
        //var row = objRef.parentNode.parentNode;
        var row = document.getElementById("<%=gvcampaign.ClientID %>");
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
          var GridView = document.getElementById("<%=gvcampaign.ClientID %>");
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
                    <li><a href="ContactsView.aspx">Contacts</a></li>
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
         <div class="container bg">
    <div class="row">
      <div class="new_campaign">
        <h1>Role</h1>
      </div>
    </div>
    <div class="col-md-12 col-sm-12 col-xs-12 role">
      <div class="col-md-5 col-sm-5 col-xs-12 pad10">      
        <div class="form-inline">
          <label for="exampleInputName2">Role Name</label> 
             <input type="text" class="form-control" id="txtRoleName" name="txtRoleName" runat="server" placeholder="Role Name" />       
        </div> 
      </div> 
      <div class="col-md-7 col-sm-7 col-xs-12">
        <div class="form-btn">
          <%--<button type="button" class="btn btn-info btn-sm" onclick="Clearuserinput();">Clear</button>--%>
            <asp:Button ID="clear" class="btn btn-info btn-sm" OnClientClick="Clearuserinput();" runat="server" Text="Clear" OnClick="clear_Click" />
            <asp:Button ID="btnSubmit" class="btn btn-primary" runat="server" Text="Submit" OnClick="Button1_Click" />
            </div> 
      </div>
        <div class="col-md-12 col-sm-12 col-xs-12 role">
      <div class="role-list">
         <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="upGrdCustomers" runat="server" UpdateMode="Always" >
    <ContentTemplate>
        <p style="margin-top:2px;padding: 0;"><asp:Label CssClass="" ID="Label1" runat="server" Text="" ></asp:Label></p>
       <%-- <div class="col-md-12 new_bg list-delete">     
        <div class="row">--%>
        <span class="list-delete">
     <asp:Button ID="btndelete" CssClass="btn btn-default" Style="margin-right:10px;" runat="server" Text="Delete" OnClick="btndelete_Click" OnClientClick="return confirm('Are you sure you want to delete?');" />    
            </span>
              <%--</div>
</div>--%>
       <%--  <input type="text" id="txtCampName" name="txtCampName" placeholder="Campaign Name"  oncontextmenu="return false;" runat="server" />
        <input type="text" id="txtTitle" name="txtTitle" placeholder="Title / Subject"  oncontextmenu="return false;" runat="server" />
        <input type="text" id="txtStatus" name="txtStatus" placeholder="From Name"  oncontextmenu="return false;" runat="server" />

        <asp:Button ID="Button1" runat="server" Text="Filter" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Cancel" OnClick="Button2_Click" />

        <%--DataSourceID="odsCustomers"--%>
          <asp:GridView ID="gvcampaign" runat="server" AutoGenerateColumns="False" AllowSorting="True"  AllowPaging="True" 
               Width="100%" style="margin-right: 0px"  CssClass="table" OnPageIndexChanging="gvcampaign_PageIndexChanging">
            
          <%--   <HeaderStyle CssClass="GridHeaderStyle"   HorizontalAlign="Center" Height="22px" OnSelectedIndexChanged="gvcampaign_SelectedIndexChanged"
                                                                VerticalAlign="Middle" BackColor="#8db3e2" />
                    <RowStyle BorderColor="White" BackColor="White" CssClass="grid-sample" />
            --%>

            <RowStyle CssClass="grid-sample" />
                       <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                       <SortedAscendingCellStyle BackColor="#F7F7F7" />
                       <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                       <SortedDescendingCellStyle BackColor="#E5E5E5" />
                       <SortedDescendingHeaderStyle BackColor="#242121" />

                       <Columns>

               <%-- <asp:HyperLinkField NavigateUrl="~/CreateCampign.aspx" Text="Edit" HeaderStyle-CssClass="grid-header02" HeaderStyle-Width="5%" ItemStyle-CssClass="grid-item" ItemStyle-Width="5%" />--%>

                           <asp:TemplateField HeaderText = "" ItemStyle-Width="30">
            <ItemTemplate>
                <asp:HyperLink runat="server" CssClass="boder0" NavigateUrl='<%# string.Format("~/RoleDetails.aspx?roleId={0}", HttpUtility.UrlEncode(Eval("PK_RoleID").ToString())) %>'
                    Text="Edit" />
            </ItemTemplate>
                               <HeaderStyle CssClass="grid-header01" Width="5%"/>
                               <ItemStyle CssClass="grid-item" Width="30px" />
        </asp:TemplateField>

                <asp:TemplateField>
            <HeaderTemplate>
                <asp:CheckBox ID="checkAll" onclick="checkAll(this);" runat="server" style="width:95%" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox ID="CheckBox1" runat="server" onclick="Check_Click(this)" style="width:95%"/>
<%--                ,<%#DataBinder.Eval(Container.DataItem, "PK_CampaignID")%>   Enabled="true" AutoPostBack="true"  OnCheckedChanged="CheckBox1_CheckedChanged"--%>
            </ItemTemplate>
                      <HeaderStyle CssClass="grid-header02" Width="2%"/>
              <ItemStyle CssClass="grid-item" Width="2%"/>
        </asp:TemplateField>
 
   <asp:TemplateField HeaderText="Serial" Visible="false">

                        <ItemTemplate>

                            <asp:Label ID="lblEmpID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PK_RoleID") %>'></asp:Label>

                        </ItemTemplate>
</asp:TemplateField>             
             
                            <asp:TemplateField HeaderText="Role Name" SortExpression="RoleName">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("~/RoleDetails.aspx?roleId={0}",HttpUtility.UrlEncode(Eval("PK_RoleID").ToString())) %>' Text='<%# Bind("RoleName") %>'></asp:HyperLink>
                                    <%--<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("~/RoleDetails.aspx",ViewState["roleId"] = Eval("PK_RoleID").ToString()) %>' Text='<%# Bind("RoleName") %>'></asp:HyperLink>--%>

                                </ItemTemplate>                     
                         
                                <HeaderStyle CssClass="grid-header03" Width="33%" />
                           <ItemStyle CssClass="grid-item" Width="33%" />
                          
                                 </asp:TemplateField>
                               <asp:BoundField SortExpression="CreatedOn" DataField="CreatedOn" HeaderText="Created On" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-CssClass="grid-header04" HeaderStyle-Width="30%" ItemStyle-CssClass="grid-item" ItemStyle-Width="30%" >

                           <HeaderStyle CssClass="grid-header04" Width="30%" />
                           <ItemStyle CssClass="grid-item" Width="30%" />
                           </asp:BoundField>

                 <asp:BoundField SortExpression="UpdatedOn" DataField="UpdatedOn" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Updated On" HeaderStyle-CssClass="grid-header05" HeaderStyle-Width="30%" ItemStyle-CssClass="grid-item" ItemStyle-Width="30%" FooterStyle-CssClass="grid-item" >
                          
   
                           <FooterStyle CssClass="grid-item" />
                           <HeaderStyle CssClass="grid-header05" Width="30%" />
                           <ItemStyle CssClass="grid-item" Width="30%" />
                           </asp:BoundField>
                           

</Columns>           
         
              <EmptyDataRowStyle BackColor="#edf5ff" Height="300px" VerticalAlign="Middle" HorizontalAlign="Center" />
                    <EmptyDataTemplate >
                        No Records Found
                    </EmptyDataTemplate> 
              <HeaderStyle CssClass="grid-view" />

            <PagerStyle CssClass = "grid-item"  />

              <%-- <PagerTemplate>
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
                    </PagerTemplate>--%>

             <%-- <RowStyle CssClass="grid-item" />--%>
                       <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                       <SortedAscendingCellStyle BackColor="#F7F7F7" />
                       <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                       <SortedDescendingCellStyle BackColor="#E5E5E5" />
                       <SortedDescendingHeaderStyle BackColor="#242121" />

          </asp:GridView>
        

      <%-- <div style="margin-top:5px">
                    <asp:DataPager  ID="pager" runat="server" PagedControlID="gvcampaign">
                        <Fields>                                            
                            <asp:NextPreviousPagerField FirstPageText="&lt;&lt;" LastPageText="&gt;&gt;" 
                                NextPageText="&gt;"  PreviousPageText="&lt;" ShowFirstPageButton="True"
                                ShowNextPageButton="False" ButtonCssClass="datapager" />
                            <asp:NumericPagerField ButtonCount="10"  NumericButtonCssClass="datapager" CurrentPageLabelCssClass="datapager"   />
                            <asp:NextPreviousPagerField LastPageText="&gt;&gt;" NextPageText="&gt;" 
                                ShowLastPageButton="True" ShowPreviousPageButton="False" ButtonCssClass="datapager" />
                        </Fields>
                    </asp:DataPager>
                </div>
         <br />--%>
               
     <%--<div class="AlphabetPager">
    <asp:Repeater ID="rptAlphabets" runat="server">
        <ItemTemplate>
            <asp:LinkButton runat="server" Text='<%#Eval("Value")%>' Visible='<%# !Convert.ToBoolean(Eval("Selected"))%>'
                OnClick="Alphabet_Click" />
            <asp:Label runat="server" Text='<%#Eval("Value")%>' Visible='<%# Convert.ToBoolean(Eval("Selected"))%>' />
        </ItemTemplate>
    </asp:Repeater>
</div>--%>
        
        </ContentTemplate>
          </asp:UpdatePanel>
      </div>

    </div>
    </div>

      

  </div>
      <!-- start content section -->  
    <%--footer--%>

         <div class="container"> <!-- start footer section --> 
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
      </div>
    </div>  <!-- end footer section -->  
    </form>
</body>
</html>
