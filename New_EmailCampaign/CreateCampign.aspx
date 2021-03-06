﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateCampign.aspx.cs" Inherits="New_EmailCampaign.CreateCampign" ValidateRequest="false"  %>
<%@ Register TagPrefix="uc" TagName="Spinner" Src="~/Common_Menu.ascx" %>
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
    <script src="js/jquery.akordeon.js"></script>
    <script src="js/jquery.colorbox.js"></script> 
    <script src="ckeditor/ckeditor.js"></script>
    <style type="text/css">
     .hidden
     {
         display:none;
     }
</style>

     <script type="text/javascript">
         $(document).ready(function () {
             $('#buttons').akordeon();
             $('#button-less').akordeon({ buttons: false, toggle: true, itemsOrder: [2, 0, 1] });
         });
    </script>
  <script src="js/bootstrap.min.js"></script>
  <script type="text/javascript">   
          
      $("#Collapse1").click(function () {
          $('#<%=hidAccordionIndex.ClientID %>').val("1");
          var activeIndex = parseInt($('#<%=hidAccordionIndex.ClientID %>').val("1"));
          alert(activeIndex)
          }); 

      $(function () {
          $('#datetimepicker1').datetimepicker({
              language: 'pt-BR',
              pick12HourFormat: true
          });
      });

      $(document).ready(function () {
          $(".iframe").colorbox({ iframe: true, width: "90%", height: "90%" });
      });

      function showlater() {
              $("#divsendlater").show();
          return false;
      }

      function validatetimezone() {
          var rad = document.getElementById('<%=ddlTimeZone.ClientID %>').value;
          var txtareadate = document.getElementById('<%=dtScheduledatetime.ClientID %>').value;
          if (rad == "0" || txtareadate == "") {
              alert("Select time zone or date & time !");
              return false;
          }
          else
              return true;
         
      }

      $(document).ready(function () {
          $("#RadioButtonList1").change(function () { 
          var rad = document.getElementById('<%=RadioButtonList1.ClientID %>');
          var radio = rad.getElementsByTagName("input");

          for (var i = 0; i < radio.length; i++) {
              if (radio[0].checked == true) {
                  $("#divupload").show();
              }
              else if (radio[1].checked == true) {
                  $("#divupload").hide();
              }
          }
          });
          return false;

      });
      
      function Enablevalidation()
      {
          var form = document.getElementById("form1");
          form.noValidate = false;
      }
      function disablevalidation() {
          var form = document.getElementById("form1");
          form.noValidate = true;
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

      function Clearuserinput1() {
          $('input[type=text], textarea').each(function () {
              $(this).val('');
          });
          $("#form1 select").val("-- Select --");
          alert('Information Successfully Saved');
      }

    </script>

</head>

<body>
    <form id="form1" runat="server" >
        
     <uc:Spinner ID="Spinner1"
            runat="server"
            MinValue="1"
            MaxValue="10" />
  <div class="container-fluid bg">
    <div class="row">
      <div class="container new_campaign">
        <div class="row">
          <h1>Campaign Email </h1>
          <h4>Provide the basic details about your email</h4>
          <div class="col-md-12  create"> 
            <div class="row">
              <div class="akordeon" id="buttons">
            <div class="akordeon-item expanded" id="Collapse1" runat="server">
                <div class="akordeon-item-head">
                    <div class="akordeon-item-head-container">
                        <div class="akordeon-heading">
                            Step 1
                        </div>
                    </div>
                </div>
                <div class="akordeon-item-body">
                    <div class="akordeon-item-content">
                    <div class="col-md-6">
                    <div class="campaign">
                    <div class="form-group">
                      <label for="exampleInputName1">Campaign Name</label>
                      <input type="text" class="form-control" id="txtCampaignName" name="txtCampaignName" runat="server" readonly oncontextmenu="return false;" />
                      <span id="helpBlock" class="help-block">Internal use only. Ex: "Newsletter Test#4".</span>
                    </div>
                    <div class="form-group">
                      <label for="exampleInputName2">Title / Subject</label>  
                      <input type="text" class="form-control" id="txtTitle" name="txtTitle" runat="server" readonly oncontextmenu="return false;" />
                      <span id="helpBlock1" class="help-block">How do I write a good subject line? • Emoji support</span>
                    </div> 
                   
                </div>
              </div>

              <div class="col-md-6">
                <div class="campaign">            
                  
                    <div class="form-group">
                      <label for="exampleInputName3">From Name</label>
                      <input type="text" class="form-control" id="FromName" readonly runat="server"/>
                      <span id="helpBlock" class="help-block">Use something subscribers will instantly recognize, like your company name.</span>
                    </div>
                    <div class="form-group">
                      <label for="exampleInputEmail1">From Email</label>  
                      <input type="text" class="form-control" id="EmailID" readonly runat="server"/>
                      <span id="helpBlock" class="help-block">Enter your email address</span>
                    </div>
                  
                </div>
              </div> 
                      
            </div>
          </div>
        </div>
          <div class="akordeon-item" id="Collapse2" runat="server">
                <div class="akordeon-item-head">
                    <div class="akordeon-item-head-container">
                        <div class="akordeon-heading">
                            Step 2
                        </div>
                    </div>
                </div>
               <div class="table-responsive">  
      
                <div class="akordeon-item-body">
                    <div class="akordeon-item-content">
                  
                      <div class="col-md-12">
           
                          <a style="font-size:16px;" class="iframe" data-toggle="modal" href="AddContacts.aspx"> Choose Recipients </a>
                            <div id="Div10" class="add-contact">

            <div class="table-responsive" style="border-radius: 0px;">                          
                         <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="upGrdCustomers" runat="server" UpdateMode="Always" >
    <ContentTemplate>
                    <asp:GridView ID="gvAddContacts" runat="server" 
               AutoGenerateColumns="False" 
               Width="100%" 
                     style="margin-right: 0px;"
         onpageindexchanging="gvAddContacts_PageIndexChanging" AllowSorting="True" AllowPaging="True">
                        <RowStyle CssClass="GridItem gridcampitem" />
                        <Columns>                          
                            <asp:TemplateField HeaderText="PK_ContactID" Visible="false">

                        <ItemTemplate>

                            <asp:Label ID="lblThirdPartyId" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PK_ContactID") %>'></asp:Label>

                        </ItemTemplate>
</asp:TemplateField> 
                           
                            <asp:BoundField DataField="ContactName" HeaderText="Name" >
                                <HeaderStyle CssClass="GridHeaderStyle" Width="10%"/>
                            <ControlStyle CssClass="GridItem gridcampitem" Width="10%" />
                                </asp:BoundField>

                            <asp:BoundField DataField="Designation" HeaderText="Designation" >
                                <HeaderStyle CssClass="GridHeaderStyle" Width="10%"/>
                            <ControlStyle CssClass="GridItem gridcampitem" Width="10%" />
                                </asp:BoundField>

                             <asp:BoundField DataField="DateofBirth" HeaderText="Date of Birth" DataFormatString="{0:dd/MM/yyyy}" >
                                <HeaderStyle CssClass="GridHeaderStyle" Width="10%"/>
                            <ControlStyle CssClass="GridItem gridcampitem" Width="10%" />
                                </asp:BoundField>

                             <asp:BoundField DataField="ContactNo" HeaderText="Contact No." >
                                <HeaderStyle CssClass="GridHeaderStyle" Width="10%"/>
                            <ControlStyle CssClass="GridItem gridcampitem" Width="10%" />
                                </asp:BoundField>

                             <asp:BoundField DataField="email_id" HeaderText="Email ID" >
                                <HeaderStyle CssClass="GridHeaderStyle" Width="18%"/>
                            <ControlStyle CssClass="GridItem gridcampitem" Width="18%" />
                                </asp:BoundField>

                             <asp:BoundField DataField="Addressline1" HeaderText="Address" >
                                <HeaderStyle CssClass="GridHeaderStyle" Width="10%"/>
                            <ControlStyle CssClass="GridItem gridcampitem" Width="10%" />
                                </asp:BoundField>

                             <asp:BoundField DataField="City1" HeaderText="City" >
                                <HeaderStyle CssClass="GridHeaderStyle" Width="10%"/>
                            <ControlStyle CssClass="GridItem gridcampitem" Width="10%" />
                                </asp:BoundField>

                             <asp:BoundField DataField="State1" HeaderText="State" >
                                <HeaderStyle CssClass="GridHeaderStyle" Width="10%"/>
                            <ControlStyle CssClass="GridItem gridcampitem" Width="10%" />
                                </asp:BoundField>

                             <asp:BoundField DataField="Country1" HeaderText="Country" >
                                <HeaderStyle CssClass="GridHeaderStyle" Width="10%"/>
                            <ControlStyle CssClass="GridItem gridcampitem" Width="10%" />
                                </asp:BoundField>
                        </Columns>
          <HeaderStyle CssClass="GridHeaderStyle"   HorizontalAlign="Center"
                                                                VerticalAlign="Middle" />
            <RowStyle CssClass="GridItem gridcampitem" />
                        <FooterStyle CssClass="GridItem gridcampitem" />
                        <PagerStyle  CssClass="GridItem gridcampitem" BackColor="#d1d2d1"/>
          </asp:GridView>
</ContentTemplate>
          </asp:UpdatePanel>

        </div>
          </div> 
                         
        

                   </div>
                  </div>
                </div>
          

    </div>
              </div>
                      <div class="akorhei akordeon-item" id="Collapse3" runat="server">
                <div class="akordeon-item-head">
                    <div class="akordeon-item-head-container">
                        <div class="akordeon-heading">
                            Step 3
                        </div>
                    </div>
                </div>
                <div class="akordeon-item-body">
                    <div class="akordeon-item-content">
                        <div class="form-group form-radio-btns pad10">
<asp:RadioButtonList ID="RadioButtonList1" CssClass="radio_btns input-inline" runat="server" RepeatDirection="Horizontal">
    <asp:ListItem CssClass="radio_btn_label" Value="1">Import HTML File</asp:ListItem>
    <asp:ListItem CssClass="radio_btn_label" Value="2">Empty Template</asp:ListItem>
                            </asp:RadioButtonList>

                             <div class="form-group">
                                  <div class="padtb10" id="divupload" style="display:none;">
                  <input type="file" id="FileUpload1" class="input-inline" name="FileUpload1" runat="server" accept=".html,.txt," />
                                 <asp:Button ID="btnupload" class="input-inline btn btn-primary" runat="server" Text="Upload" OnClick="btnupload_Click" />
                    <b style="background-color:#ffff99;">(.html, .txt)</b>
                                      </div>
                                 <textarea runat="server" name="txta9" id="txta9" class="ckeditor" required></textarea>

                                 <asp:Button ID="Button1" class="btn btn-danger input-inline" runat="server" Style="margin-top:10px;" Text="Send Now" OnClick="Button1_Click"  />
                                 <asp:Button ID="Button2" class="btn btn-info input-inline" runat="server" Style="margin-top:10px;" Text="Send Later" OnClientClick="showlater(); return false;" OnClick="Button2_Click"  />
                                
                </div>
                            <div class="row" id="divsendlater" style="display:none;">
                                <div class="col-md-4">
                      <label for="exampleInputEmail1">Select Time Zone</label>  
                        <asp:DropDownList ID="ddlTimeZone" style="width:330px;" required="required" runat="server" AppendDataBoundItems="true">
                        </asp:DropDownList>                    
                            
                    </div>  
                    
                    <div class="col-md-4">
                        <label for="exampleInputEmail1">Select Date &amp; Time</label>
                    <div class="date-time">
                      <div id="datetimepicker1"  class="input-append">                       
                        <input id="dtScheduledatetime" style="width:180px;"  data-format="dd/MM/yyyy hh:mm:ss PP" runat="server" type="text" />
                        <span class="add-on">
                          <i data-time-icon="icon-time" data-date-icon="icon-calendar">
                          </i>
                        </span>
                      </div>
                    </div>
                        </div>
                         <asp:Button ID="btngridsubmit" class="btn btn-primary btn-sm" runat="server" Style="margin-top:30px;" Text="Submit" OnClientClick="return validatetimezone();" OnClick="btngridsubmit_Click" />  

                            </div>

                    </div> 
   
                </div>
              </div> 
 </div>
              
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
        <asp:HiddenField ID="hidAccordionIndex" runat="server" Value="0" />
    </div>
  </div>
      <!-- start content section -->  
    </form>
</body>
</html>
