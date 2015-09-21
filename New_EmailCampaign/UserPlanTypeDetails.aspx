<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPlanTypeDetails.aspx.cs" Inherits="New_EmailCampaign.UserPlanTypeDetails" %>

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
                    <li class="active"><a href="UserPlanTypeDetails.aspx">Plan Type</a></li>
                   
                  </ul>
                  <ul class="nav navbar-nav navbar-right">
                    <li><a href="#">Help</a></li>
                    <li class="dropdown">
                      <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Exit <span class="caret"></span></a>
                      <ul class="dropdown-menu" role="menu">
                        
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
    <div class="container new_campaign">  <!-- start campaign section --> 
      <div class="list-contact">
       <span> 
           <a class="btn btn-default active" href="UserPlanType.aspx" role="button">New Plan</a>             
           
           </span>
      </div>
        
      <div class="col-md-12 new_bg list-delete">     
        <div class="row">
           <span>
                <%--<% if (Session["cmpdelete"] != null)
              {
                  if (Convert.ToInt32(Session["cmpdelete"].ToString()) == 1)
                  { %> --%>
            <asp:Button ID="btndelete" CssClass="btn btn-default" Style="margin-right:10px;" runat="server" Text="Delete" OnClick="btndelete_Click" OnClientClick="return confirm('Are you sure you want to delete?');" />
             <%--  <%}
              }%>--%>
            <asp:Button ID="btnreload" CssClass="btn btn-default" runat="server" Text="Reload"  OnClick="btnreload_Click"/>
                                            
                                           <%-- <a style="font-size:16px;" class="iframe" onclick="return validatecheck();" href=""> Mass Update </a> --%>
               
               
               <%--<asp:LinkButton ID="LinkButton1" CssClass="iframe"  runat="server">LinkButton</asp:LinkButton>  iframe cboxElement  OnClientClick="ShowNewPage('MassUpdate.aspx');"  --%>
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
              <table class="table" rules="all" id="gvcampaignss" style="width:100%;border-collapse:collapse;margin-right: 0px" border="1" cellspacing="0">
                <tbody>
                  <tr>
                    <td style="width:5%; padding: 4px;"></td>
                    <td style="width:2%;padding: 4px;"></td>
                    <td style="width:25%; padding: 4px;">
                      <input name="txtCampName" id="txtCampName" placeholder="Campaign Name" oncontextmenu="return false;" type="text" runat="server" />
                    </td>
                    <%-- <td style="width:25%; padding: 4px;">
                      <input name="txtTitle" id="txtTitle" placeholder="Title / Subject" oncontextmenu="return false;" type="text" runat="server" />
                    </td>
                    <td style="width:25%; padding: 4px;"> 
                      <input  name="txtStatus" id="txtStatus" placeholder="From Name" oncontextmenu="return false;" type="text" runat="server" />  
                    </td>--%>
                    <td style="width:18%; padding: 4px;">
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
        
       <%--  <input type="text" id="txtCampName" name="txtCampName" placeholder="Campaign Name"  oncontextmenu="return false;" runat="server" />
        <input type="text" id="txtTitle" name="txtTitle" placeholder="Title / Subject"  oncontextmenu="return false;" runat="server" />
        <input type="text" id="txtStatus" name="txtStatus" placeholder="From Name"  oncontextmenu="return false;" runat="server" />

        <asp:Button ID="Button1" runat="server" Text="Filter" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Cancel" OnClick="Button2_Click" />

        <%--DataSourceID="odsCustomers"--%>
          <asp:GridView ID="gvcampaign" runat="server" AutoGenerateColumns="False" AllowSorting="True"  AllowPaging="True" 
               Width="100%" style="margin-right: 0px"  CssClass="table" OnDataBound="gvcampaign_DataBound" OnPageIndexChanging="gvcampaign_PageIndexChanging" OnSorting="gvcampaign_Sorting" OnPreRender="gvcampaign_PreRender" >
            
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

                           <asp:TemplateField HeaderText = "" ItemStyle-Width="3%">
            <ItemTemplate>
                <asp:HyperLink runat="server" CssClass="boder0" NavigateUrl='<%# string.Format("~/UserPlanType.aspx?PlantypId={0}", HttpUtility.UrlEncode(Eval("PK_PlanID").ToString())) %>'
                    Text="Edit" />
            </ItemTemplate>
                               <HeaderStyle CssClass="grid-header01" Width="3%"/>
                               <ItemStyle CssClass="grid-item" Width="3%" />
                               <FooterStyle Width="3%" />
        </asp:TemplateField>

                <asp:TemplateField>
            <HeaderTemplate>
                <asp:CheckBox ID="checkAll" onclick="checkAll(this);" runat="server" style="width:95%" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox ID="CheckBox1" runat="server" onclick="Check_Click(this)" style="width:95%"/>
<%--                ,<%#DataBinder.Eval(Container.DataItem, "PK_PlanID")%>   Enabled="true" AutoPostBack="true"  OnCheckedChanged="CheckBox1_CheckedChanged"--%>
            </ItemTemplate>
                      <HeaderStyle CssClass="grid-header02" Width="2%"/>
              <ItemStyle CssClass="grid-item" Width="2%"/>
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
                          
           <%-- <asp:BoundField SortExpression="CampaignName" DataField="CampaignName" HeaderText="Campaign Name" HeaderStyle-CssClass="grid-header03" HeaderStyle-Width="33%" ItemStyle-CssClass="grid-item" ItemStyle-Width="33%" > --%>
               
                                <HeaderStyle CssClass="grid-header03" Width="30%" />
                           <ItemStyle CssClass="grid-item" Width="30%" />
                          <%-- </asp:BoundField>--%>
                                 </asp:TemplateField>

                           <asp:TemplateField HeaderText="Single User">                   
                        <ItemTemplate>
                            <%--<asp:Image ID="imgPreview" ImageUrl='<%#
                            "ImageHandler.ashx?imgID="+ Eval("userphoto") %>' runat="server"
                                Height="80px" Width="80px" />
                            <img src="<%#Eval("userphoto")%>" width="80px" height="80px"/>--%>
                            <%--<asp:Image ID="imgEmployeeImage" runat="server" ImageUrl='<%#Server.MapPath(@"UserImage\" + Eval("userphoto")) %>' width="80px" height="80px"/>--%>
                            <asp:Image ID="imgEmployeeImage" runat="server" ImageUrl='<%# "~/images/Tick_inside_a_circle_24(1).png" %>' Visible = '<%# Eval("IsSingleUser").ToString() == "True" ? true : false %>' width="30px" height="30px"/>
                        </ItemTemplate>
                               <HeaderStyle CssClass="grid-header02" Width="13%"/>
              <ItemStyle CssClass="grid-item" Width="13%"/>
                    </asp:TemplateField>

                                <asp:BoundField SortExpression="Planrate" DataField="Planrate" HeaderText="Plan Rate ($)" HeaderStyle-CssClass="grid-header04" HeaderStyle-Width="10%" ItemStyle-CssClass="grid-item" ItemStyle-Width="30%" >

                           <HeaderStyle CssClass="grid-header04" Width="10%" />
                           <ItemStyle CssClass="grid-item" Width="10%" />
                           </asp:BoundField>

                <asp:BoundField SortExpression="NOC" DataField="NOC" HeaderText="Number of Subscribers" HeaderStyle-CssClass="grid-header05" HeaderStyle-Width="15%" ItemStyle-CssClass="grid-item" ItemStyle-Width="30%" FooterStyle-CssClass="grid-item" >

         
   
                           <FooterStyle CssClass="grid-item" />
                           <HeaderStyle CssClass="grid-header05" Width="15%" />
                           <ItemStyle CssClass="grid-item" Width="15%" />
                           </asp:BoundField>
                             <asp:BoundField SortExpression="AllowedMails" DataField="AllowedMails" HeaderText="Allowed Mails" HeaderStyle-CssClass="grid-header05" HeaderStyle-Width="15%" ItemStyle-CssClass="grid-item" ItemStyle-Width="15%" FooterStyle-CssClass="grid-item" >

         
   
                           <FooterStyle CssClass="grid-item" />
                           <HeaderStyle CssClass="grid-header05" Width="15%" />
                           <ItemStyle CssClass="grid-item"  Width="15%" />
                           </asp:BoundField>

                            <asp:TemplateField HeaderText="Is Active">                   
                        <ItemTemplate>
                            <%--<asp:Image ID="imgPreview" ImageUrl='<%#
                            "ImageHandler.ashx?imgID="+ Eval("userphoto") %>' runat="server"
                                Height="80px" Width="80px" />
                            <img src="<%#Eval("userphoto")%>" width="80px" height="80px"/>--%>
                            <%--<asp:Image ID="imgEmployeeImage" runat="server" ImageUrl='<%#Server.MapPath(@"UserImage\" + Eval("userphoto")) %>' width="80px" height="80px"/>--%>
                            <asp:Image ID="imgIsActive" runat="server" ImageUrl='<%# "~/images/Tick_inside_a_circle_24(1).png" %>' Visible = '<%# Eval("IsActive").ToString() == "True" ? true : false %>' width="30px" height="30px"/>
                        </ItemTemplate>
                               <HeaderStyle CssClass="grid-header02" Width="12%"/>
              <ItemStyle CssClass="grid-item" Width="12%"/>
                    </asp:TemplateField>
                           
</Columns>           
         
              <EmptyDataRowStyle BackColor="#edf5ff" Height="300px" VerticalAlign="Middle" HorizontalAlign="Center" />
                    <EmptyDataTemplate >
                        No Records Found
                    </EmptyDataTemplate> 
              <HeaderStyle CssClass="grid-view" />

            <PagerStyle CssClass = "grid-item"  />

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
    </form>
</body>
</html>
