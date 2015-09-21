<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListView.aspx.cs" Inherits="New_EmailCampaign.ListView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Email Campaign</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
  <link href="css/style.css" rel="stylesheet" />

    <script src="js/jquery.min.js"></script>
  <script src="js/jqueryv11.2.js"></script> 
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager EnablePartialRendering="true"
 ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
                    <li class="active"><a href="CreateCampign.aspx">Campaign</a></li>
                    <li><a href="#about">List</a></li>
                    <li><a href="#contact">Editor</a></li>
                  </ul>
                  <ul class="nav navbar-nav navbar-right">
                    <li><a href="#">Help</a></li>
                    <li class="dropdown">
                      <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Save and Exit <span class="caret"></span></a>
                      <ul class="dropdown-menu" role="menu">
                             <li><a href="CreateProfile.aspx">Profile</a></li>
                        <li><a href="#">Dashboard</a></li>
                        <li><a href="#">Campaigns</a></li>
                        <li><a href="#">Lists</a></li>
                        <li><a href="#">Reports</a></li>
                        <li class="divider"></li>
                        <li><a href="#">Log Out </a></li>
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
  <!-- start content section -->
  <div class="container-fluid bg">
      
    <div class="row">
      <div class="container new_campaign">
        <div class="row">
          <h1>Add List for set of recipients</h1>
              <div class="col-md-12 text-right">
            <button type="button" class="btn btn-primary iframe" data-toggle="modal" href="createlist.aspx">Create List</button>
          </div> 
           
            


    <asp:GridView ID="gvlist" runat="server" 
               AutoGenerateColumns="False" 
               Width="100%" 
                     style="margin-right: 0px" ShowFooter="True" 
          onrowcommand="gvlist_RowCommand" 
            onrowcancelingedit="gvlist_RowCancelingEdit" 
            onrowediting="gvlist_RowEditing" 
            onrowupdating="gvlist_RowUpdating" 
            onrowdeleting="gvlist_RowDeleting" onpageindexchanging="gvlist_PageIndexChanging" AllowSorting="True" AllowPaging="true" PageSize="8">
            <RowStyle CssClass="GridItem" />
            <Columns>
            <asp:TemplateField HeaderText="CntID" Visible="false">
              <ItemTemplate>
                <asp:Label ID="lblEmpID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PK_ContactID") %>' style="word-wrap:break-word;"></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="S.No" ControlStyle-Width="5%">
              <ItemTemplate> <%#Container.DataItemIndex + 1 %> </ItemTemplate>
              <ControlStyle Width="5%"  CssClass="seralign"/>
              <FooterStyle Width="5%" CssClass="seralign"/>
              <HeaderStyle Width="5%" BackColor="#8db3e2" />
              <ItemStyle Width="5%" CssClass="seralign"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="List Name" ControlStyle-Width="10%">
              <FooterTemplate>
                <input type="text" class="form-control" id="txtappnamef" name="txtappnamef" runat="server" />
              </FooterTemplate>
              <EditItemTemplate>
                <input type="text" class="form-control" id="txtappnamee" name="txtappnamee" runat="server" value=<%# Bind("ListName") %> />
              </EditItemTemplate>
              <ItemTemplate>
                <asp:Label ID="lbltxtappname" runat="server" Text=<%# Bind("ListName") %> style="word-wrap:break-word;width:85px;"></asp:Label>
              </ItemTemplate>
              <ControlStyle Width="10%" CssClass="seralign"/>
              <FooterStyle Width="10%" CssClass="seralign"/>
              <HeaderStyle Width="10%" BackColor="#8db3e2"/>
              <ItemStyle Width="10%" CssClass="seralign"/>
            </asp:TemplateField>

                <asp:TemplateField HeaderText="Created By" ControlStyle-Width="10%">
              <FooterTemplate>
                <input type="text" class="form-control" id="txtcntNof" name="txtcntNof" runat="server" />
              </FooterTemplate>
              <EditItemTemplate>
                <input type="text" class="form-control" id="txtcntNoe" name="txtcntNoe" runat="server" value=<%# Bind("CreatedBy") %> />
              </EditItemTemplate>
              <ItemTemplate>
                <asp:Label ID="lbltxtcntNo" runat="server" Text=<%# Bind("CreatedBy") %> style="word-wrap:break-word;width:85px;"></asp:Label>
              </ItemTemplate>
              <ControlStyle Width="10%" CssClass="seralign"/>
              <FooterStyle Width="10%" CssClass="seralign"/>
              <HeaderStyle Width="10%" BackColor="#8db3e2"/>
              <ItemStyle Width="10%" CssClass="seralign"/>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Total Count" ControlStyle-Width="10%">
              <FooterTemplate>
                <input type="text" class="form-control" id="txtpasswordf" name="txtpasswordf" runat="server"  />
              </FooterTemplate>
              <EditItemTemplate>
                <input type="text" class="form-control" id="txtpassworde" name="txtpassworde" runat="server" value=<%# Bind("TotalCount") %>   />
              </EditItemTemplate>
              <ItemTemplate>
                <asp:Label ID="lblpassword" runat="server" Text=<%# Bind("TotalCount") %> style="word-wrap:break-word;width:85px;"></asp:Label>
              </ItemTemplate>
              <ControlStyle Width="10%" CssClass="seralign"/>
              <FooterStyle Width="10%" CssClass="seralign"/>
              <HeaderStyle Width="10%" BackColor="#8db3e2"/>
              <ItemStyle Width="10%" CssClass="seralign"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Created On" ControlStyle-Width="10%">
              <ItemTemplate >
                <asp:Label ID="lbldec" runat="server" Text=<%# Bind("CreatedOn") %> style="word-wrap:break-word;width:85px;"></asp:Label>
              </ItemTemplate>
              <EditItemTemplate>
                <input type="text" class="form-control" id="txtddesce" name="txtddesce" runat="server" value=<%# Bind("CreatedOn") %>   />
              </EditItemTemplate>
              <FooterTemplate>
                <input type="text" class="form-control" id="txtddescf" name="txtddescf" runat="server"   />
              </FooterTemplate>
              <ControlStyle Width="10%" CssClass="seralign"/>
              <FooterStyle Width="10%" CssClass="seralign"/>
              <HeaderStyle CssClass="GridHeaderStyle" Font-Bold="True" Width="10%" BackColor="#8db3e2"  />
              <ItemStyle Width="10%" CssClass="seralign"/>
            </asp:TemplateField>
           <%-- <asp:TemplateField HeaderText="Address line" ControlStyle-Width="10%">
              <ItemTemplate>
                <asp:Label runat="server" Text=<%# Bind("Addressline1") %> ID="lblimpact" style="word-wrap:break-word;width:85px;"></asp:Label>
              </ItemTemplate>
              <EditItemTemplate>
                <input type="text" class="form-control" id="txtimpacte" name="txtimpacte" runat="server" value=<%# Bind("Addressline1") %>   />
              </EditItemTemplate>
              <FooterTemplate>
                <input type="text" class="form-control" id="txtimpactf" name="txtimpactf" runat="server"   />
              </FooterTemplate>
              <ControlStyle Width="10%" CssClass="seralign" />
              <FooterStyle Width="10%" CssClass="seralign"/>
              <HeaderStyle CssClass="GridHeaderStyle" Font-Bold="True" Width="10%" BackColor="#8db3e2" />
              <ItemStyle Width="10%" CssClass="seralign"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="City" ControlStyle-Width="10%">
              <EditItemTemplate>
                <input type="text" class="form-control" id="txtcritice" name="txtcritice" runat="server" value=<%# Bind("City1") %>  />
              </EditItemTemplate>
              <ItemTemplate>
                <asp:Label ID="lblcritic" runat="server" Text=<%# Bind("City1") %> style="word-wrap:break-word;width:85px;"></asp:Label>
              </ItemTemplate>
              <FooterTemplate>
                <input type="text" class="form-control" id="txtcriticf" name="txtcriticf" runat="server"   />
              </FooterTemplate>
              <ControlStyle Width="10%" CssClass="seralign" />
              <FooterStyle Width="10%" CssClass="seralign" />
              <HeaderStyle Width="10%" BackColor="#8db3e2" />
              <ItemStyle Width="10%" CssClass="seralign" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="State" ControlStyle-Width="10%">
              <EditItemTemplate>
                <input type="text" class="form-control" id="txtsernamee" name="txtsernamee" runat="server" value=<%# Bind("State1") %>  />
              </EditItemTemplate>
              <ItemTemplate>
                <asp:Label ID="lblsername" runat="server" Text=<%# Bind("State1") %> style="word-wrap:break-word;width:85px;"></asp:Label>
              </ItemTemplate>
              <FooterTemplate>
                <input type="text" class="form-control" id="txtsernamef" name="txtsernamef" runat="server"   />
              </FooterTemplate>
              <ControlStyle Width="10%" CssClass="seralign"/>
              <FooterStyle Width="10%" CssClass="seralign"/>
              <HeaderStyle Width="10%" BackColor="#8db3e2" />
              <ItemStyle Width="10%" CssClass="seralign"/>
            </asp:TemplateField>
            
                <asp:TemplateField HeaderText="Country" ControlStyle-Width="10%">
              <EditItemTemplate>
                <input type="text" runat="server" name="txtprevpasse" id="txtprevpasse" value=<%# Bind("Country1") %> />
              </EditItemTemplate>
              <ItemTemplate>
                <asp:Label ID="lblprevpassf" runat="server" Text=<%# Bind("Country1") %> style="word-wrap:break-word;width:85px;"></asp:Label>
              </ItemTemplate>
              <FooterTemplate>
                <input type="text" name="txtprevpassf"  runat="server" id="txtprevpassf" />
              </FooterTemplate>
              <ControlStyle Width="10%" CssClass="seralign"/>
              <FooterStyle Width="10%" CssClass="seralign"/>
              <HeaderStyle Width="10%" BackColor="#8db3e2" />
              <ItemStyle Width="10%" CssClass="seralign"/>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="Action  <br/> Edit &nbsp  Delete">
              <ItemTemplate>
                <asp:ImageButton ID="imgbtn1" ImageUrl="./images/icon-edit.png" runat="server" ToolTip=" Click here for edit."  CommandName="Edit" ImageAlign="AbsMiddle" />
                <asp:ImageButton ID="DeleteButton1" runat="server" ToolTip=" Click here for delete."
                    ImageUrl="./images/icon-delete.png" CausesValidation="false"
                    CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete?');"
                    AlternateText="Delete" ImageAlign="AbsMiddle"  />
              </ItemTemplate>
              <EditItemTemplate>
                <asp:LinkButton ID="lbtnupdate" runat="server" CommandName="Update" Text="Update" ></asp:LinkButton>
                <br>
                </br>
                <asp:LinkButton ID="lbtndelete" runat="server" CommandName="Cancel" Text="Cancel" ></asp:LinkButton>
              </EditItemTemplate>
              <FooterTemplate>
                <asp:LinkButton ID="lbtnAdd" runat="server" CommandName="ADD" Text="Add" ></asp:LinkButton>
              </FooterTemplate>
              <ControlStyle CssClass="seralign"/>
              <FooterStyle Width="10%" CssClass="seralign"/>
              <HeaderStyle Width="10%"  BackColor="#8db3e2"/>
              <ItemStyle CssClass="seralign"/>
            </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
              <table cellspacing="0" rules="all" style="width:100%;margin-right: 0px">
                <tr class="GridHeaderStyle" align="center" valign="middle" style="background-color:#8DB3E2;">
                  <th scope="col" style="background-color:#8DB3E2;width:5%;">S.No.</th>
                  <th scope="col" style="background-color:#8DB3E2;width:10%;">List Name</th>
                  <th class="GridHeaderStyle" scope="col" style="background-color:#8DB3E2;font-weight:bold;width:10%;">Total Count</th>
                    <th class="GridHeaderStyle" scope="col" style="background-color:#8DB3E2;font-weight:bold;width:10%;">Created By</th>
                  <th class="GridHeaderStyle" scope="col" style="background-color:#8DB3E2;font-weight:bold;width:10%;">Created On</th>
                  <%--<th scope="col" style="background-color:#8DB3E2;width:10%;">Address line</th>
                  <th scope="col" style="background-color:#8DB3E2;width:10%;">City</th>
                  <th scope="col" style="background-color:#8DB3E2;width:10%;">State</th>
                  <th scope="col" style="background-color:#8DB3E2;width:10%;">Country</th>--%>
                  <th scope="col" style="background-color:#8DB3E2;width:10%;">Action <br/>
                    Edit &nbsp  Delete</th>
                </tr>
                <tr class="GridItem" style="background-color:White;border-color:White;">
                  <td style="width:10%;" class="seralign">&nbsp;</td>
                  <td style="width:10%;" class="seralign"><input type="text" class="form-control" id="txtappnamef" name="txtappnamef" runat="server"  /></td>
                  <td style="width:10%;" class="seralign"><input type="text" class="form-control" id="txtpasswordf" name="txtpasswordf" runat="server"   /></td>
                    <td style="width:10%;" class="seralign"><input type="text" class="form-control" id="txtcntNof" name="txtcntNof" runat="server"   /></td>
                  <td style="width:10%;" class="seralign"><input type="text" class="form-control" id="txtddescf" name="txtddescf" runat="server" /></td>
                  <%--<td style="width:10%;" class="seralign"><input type="text" class="form-control" id="txtimpactf" name="txtimpactf" runat="server"   /></td>
                  <td style="width:10%;" class="seralign"><input type="text" class="form-control" id="txtcriticf" name="txtcriticf" runat="server"   /></td>
                  <td style="width:10%;" class="seralign"><input type="text" class="form-control" id="txtsernamef" name="txtsernamef" runat="server"   /></td>
                 <td style="width:10%;" class="seralign"><input type="text" class="form-control" id="txtprevpassf" name="txtprevpassf" runat="server"   /></td>--%>
                  <td class="seralign" style="width:10%;" ><asp:LinkButton ID="lbtnAdd" runat="server" CommandName="ADD" Text="Add" ></asp:LinkButton></td>
                </tr>
              </table>
            </EmptyDataTemplate>
            <HeaderStyle CssClass="GridHeaderStyle"   HorizontalAlign="Center"
                                                                VerticalAlign="Middle" />
            <RowStyle BorderColor="White" BackColor="White" CssClass="GridItem" />
          </asp:GridView>
    </div>
            </div> 
    </div>
  </div>
    </form>
</body>
</html>
