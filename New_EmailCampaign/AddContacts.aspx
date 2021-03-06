﻿
<%@ Page  Language="C#" AutoEventWireup="true" CodeBehind="AddContacts.aspx.cs" Inherits="New_EmailCampaign.AddContacts" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Email Campaign</title>

    <link href="css/bootstrap.css" rel="stylesheet" />
  <link href="css/style.css" rel="stylesheet" />
     <link href="css/stylesheet.css" rel="stylesheet" />
  <link href="css/colorbox.css" rel="stylesheet" />
<link href="css/bootstrap-datetimepicker.min.css" rel="stylesheet" />

    <script src="js/jqueryv11.2.js"></script> 
   <script src="js/bootstrap-datetimepicker.min.js"></script> 
  <script src="js/jquery.colorbox.js"></script> 
     <script src="js/bootstrap.min.js"></script>   

    <script type="text/javascript">

        $(function () {
            $('#datetimepicker1,#datetimepicker2').datetimepicker({
                pickTime: false
            });
        });

       
        function Check_Click(objRef) {
           
            var row = document.getElementById("<%=gvAddContacts.ClientID %>");           
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
            
            var GridView = document.getElementById("<%=gvAddContacts.ClientID %>");
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

        function Clearuserinput1() {
            $('input[type=text], textarea').each(function () {
                $(this).val('');
            });
        }

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

        function Clearuserinput11() {
            $('input[type=text], textarea').each(function () {
                $(this).val('');
            });
            $("#form1 select").val("-- Select --");
            alert('Information Successfully Saved');
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
          <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="add-02">
          <h1>Choose Recipients</h1>
      </div>
      <div class="">
              
          <div id="Div10" class="add-contact">
              <div class="col-md-12 new_bg list-delete">     
        <div class="row">
           <span>
            
 <asp:Button ID="btnreload" CssClass="btn btn-default" runat="server" Text="Reload"  OnClick="btnreload_Click"/>
               <a class="glyphicon glyphicon-search" data-toggle="collapse" href="#collapseExample" onclick="return Clearuserinput1();" aria-expanded="false" aria-controls="collapseExample"></a>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" >
    <ContentTemplate>
               <p style="margin-top:2px;padding: 0;"><asp:Label ID="lblcontact" CssClass="" runat="server" Text=""></asp:Label></p>

        </ContentTemplate>
          </asp:UpdatePanel>
       </span> 
            <div class="table-responsive" style="border-radius: 0px;">
        
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
    <asp:GridView ID="gvAddContacts" runat="server" AutoGenerateColumns="False" AllowSorting="True"  AllowPaging="True" 
               Width="100%" style="margin-right: 0px"  CssClass="table" OnDataBound="gvAddContacts_DataBound" OnPageIndexChanging="gvAddContacts_PageIndexChanging" OnSorting="gvAddContacts_Sorting" OnPreRender="gvAddContacts_PreRender" OnRowDataBound="gvAddContacts_RowDataBound">
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
 
                         
<asp:BoundField SortExpression="ContactName" DataField="ContactName" HeaderText="Name" HeaderStyle-CssClass="grid-contact04" ItemStyle-CssClass="grid-item">
                   <HeaderStyle CssClass="grid-contact03" Width="15%" />
                           <ItemStyle CssClass="grid-item" Width="15%" />
                           </asp:BoundField>
             <asp:BoundField SortExpression="Designation" DataField="Designation" HeaderText="Designation" HeaderStyle-CssClass="grid-contact04" ItemStyle-CssClass="grid-item">
                   <HeaderStyle CssClass="grid-contact04" Width="10%" />
                           <ItemStyle CssClass="grid-item" Width="10%" />
                           </asp:BoundField>

                 <asp:BoundField SortExpression="ContactNo" DataField="ContactNo" HeaderText="Contact No." HeaderStyle-CssClass="grid-contact04" ItemStyle-CssClass="grid-item">
                 <HeaderStyle CssClass="grid-contact05" Width="10%" />
                           <ItemStyle CssClass="grid-item" Width="10%" />
                           </asp:BoundField>

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
                <asp:Button ID="btngridsubmit" class="btn btn-primary btn-sm" runat="server" Style="margin-top:10px;" Text="Submit" OnClick="btngridsubmit_Click" />  
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
