
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Common_Menu.ascx.cs" Inherits="New_EmailCampaign.Common_Menu" %>
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
                       <%--<li class="dropdown">
                      <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Settings <span class="caret"></span></a>
                      <ul class="dropdown-menu" role="menu">
                          
 </ul>
                    </li>--%>
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
                  { 
                      if (Session["lstUserPlanType"] != null)
                {
                          string[] UPtype = new string[3];
                          UPtype = (string[])Session["lstUserPlanType"];
                          if(Convert.ToBoolean(UPtype[0]) == false)
                          { 
                      %> 
                          <li><a href="InviteUserList.aspx">Invite User</a></li>
                           <%}
                             }
                             }
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