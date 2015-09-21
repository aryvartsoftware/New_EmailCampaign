<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExcelColumnMapping.aspx.cs" Inherits="New_EmailCampaign.ExcelColumnMapping" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
  <div class="col-md-6">
                    <div class="campaign">
                    <div class="form-group">
                      <label for="exampleInputName1">Campaign Name</label>
                      <input type="text" class="form-control" id="txtCampaignName" name="txtCampaignName" runat="server" required oncontextmenu="return false;" />
                      <span id="helpBlock" class="help-block">Internal use only. Ex: "Newsletter Test#4".</span>
                    </div>
                    <div class="form-group">
                      <label for="exampleInputName2">Title / Subject</label>  
                      <input type="text" class="form-control" id="txtTitle" name="txtTitle" runat="server" required oncontextmenu="return false;" />
                      <span id="helpBlock1" class="help-block">How do I write a good subject line? • Emoji support</span>
                    </div> 
                    <div class="form-group">
                      <label for="exampleInputEmail1">Select Time Zone</label>  
                        <asp:DropDownList ID="ddlTimeZone" required="required" runat="server">
                        </asp:DropDownList> 
                       <asp:RequiredFieldValidator runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="ddlTimeZone" ForeColor="Red" InitialValue="-- Select --" SetFocusOnError="True" ValidationGroup="vg1"></asp:RequiredFieldValidator>                 
                    </div> 
                    <div class="form-group form-btn">
                    <%--<button type="button" class="btn btn-info btn-sm pull-right">Clear</button>--%>
                        <input id="Reset1" type="reset" onclick="return Clearuserinput();" value="Clear All" class="btn btn-primary" style="background-color:mediumseagreen;"/>
                        <%--<asp:Button ID="btnCancel" class="btn btn-primary" runat="server" Text="Clear" onclick="return Clearuserinput();"/>  --%>              
                    </div>
                </div>
              </div>
    </form>
</body>
</html>
