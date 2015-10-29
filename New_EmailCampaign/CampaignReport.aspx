<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CampaignReport.aspx.cs" Inherits="New_EmailCampaign.CampaignReport" %>
<%@ Register TagPrefix="uc" TagName="Spinner" Src="~/Common_Menu.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Email Campaign</title>
  <!-- start css -->
  <link href='http://fonts.googleapis.com/css?family=Lato:400,700' rel='stylesheet' type='text/css'>
  <link href="css/bootstrap.css" rel="stylesheet" />
  <link href="css/style.css" rel="stylesheet" />

     <script src="js/jquery.min.js"></script>
  <script src="js/bootstrap.min.js"></script>



</head>
<body>
    <form id="form1" runat="server" >
        <asp:ScriptManager EnablePartialRendering="true"
 ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <uc:Spinner id="Spinner1" 
        runat="server" 
        MinValue="1" 
        MaxValue="10" />
  <!-- start content section -->
  <div class="container bg">
    <div class="row">
      <div class="new_campaign">
        <h1><asp:Label ID="lblCampname" runat="server" Text=""></asp:Label></h1>
      </div>
    </div>
    <div class="col-md-12 col-sm-12 col-xs-12 report">
      <h4><asp:Label ID="lblRecipients" runat="server" Text=""></asp:Label> Recipients</h4>
      <div class="col-md-3 col-sm-4 col-xs-12">
        <div class="report01">
          <p>From Name: <span><asp:Label ID="lblfromname" runat="server" Text=""></asp:Label></span></p>
          <p>Subject: <span><asp:Label ID="lblSubject" runat="server" Text=""></asp:Label></span></p>
          <p>Delivered: <span><asp:Label ID="lblDelivered" runat="server" Text=""></asp:Label></span></p>
        </div>
        <div class="report-links">
          <h3>Sent <asp:Label CssClass="label label-danger" ID="lblSent" runat="server" Text=""></asp:Label></h3>
          <h3>Clicked <asp:Label CssClass="label label-danger" ID="lblClick" runat="server" Text=""></asp:Label></h3>
          <h3 style="padding-bottom: 8px;">Bounced <asp:Label CssClass="label label-danger" ID="lblbounced" runat="server" Text=""></asp:Label>
            <ul class="list-unstyled">
              <li>Soft Bounce <asp:Label CssClass="label label-danger" ID="lblsoftbounce" runat="server" Text=""></asp:Label></li>
              <li>Hard Bounce <asp:Label CssClass="label label-danger" ID="lblhardbounce" runat="server" Text=""></asp:Label></li>
            </ul>
          </h3>
          <h3>Unsubscribed <span class="label label-danger">0</span></h3>
        </div>
      </div>

                            
    

      <div class="col-md-6 col-sm-6 col-xs-12">
        <div class="report02">
          <ul class="list-unstyled">
            <li> 
              <h5>Deliver Rate <asp:Label CssClass="label label-danger" ID="lbltotalsentmail" runat="server" Text=""></asp:Label></h5>
              <div class="meter">
                <span id="spdelrate" runat="server" style="width:0%"></span>
                <p> </p>
              </div>
              <p>List average <asp:Label CssClass="label label-danger" ID="lbltotalsentmailpercent" runat="server" Text=""></asp:Label></p>
            </li>
            <li> 
              <h5>Open Rate <asp:Label CssClass="label label-danger" ID="lblopenrate" runat="server" Text=""></asp:Label></h5>             
              <div class="meter">
                <span id="spopenrate" runat="server" style="width:0%"></span>
                <p> </p>
              </div>
              <p>List average <asp:Label CssClass="label label-danger" ID="lblopenratepercent" runat="server" Text=""></asp:Label></p>
            </li>
          </ul>
        </div>

        <div class="report-prograss"><%--onclick="chartshow(40,30,30);"--%>
            <input id="btn" type="reset" runat="server" value="Generate Graph" class="btn btn-primary"  style="background-color:mediumseagreen;"/>
         <div id="container" style="min-width: 310px; height: 400px; max-width: 600px; margin: 0 auto"></div>
        </div>
      </div>
        

      <div class="col-md-3 col-sm-12 col-xs-12">
        <div class="report-percentage">        
          <ul class="list-unstyled">
              <li>Successful deliveries <asp:Label ID="lblsuccdeliver" runat="server" Text=""></asp:Label></li>
              <li>Total opens <asp:Label ID="lbltotopens" runat="server" Text=""></asp:Label></li>
              <li>Forwarded <span>0</span></li>
              <li>Not yet open <asp:Label ID="lblnotopen" runat="server" Text=""></asp:Label></li>
              <li>Total clicks <asp:Label ID="lbltotclicks" runat="server" Text=""></asp:Label></li>
              <li>Abuse reports <span>0</span></li>
            </ul>
        </div>
      </div>
      
    </div>

  </div>
      <!-- start content section -->  
</form>
    
        
    <script src="http://code.highcharts.com/highcharts.js"></script>
<script src="http://code.highcharts.com/modules/exporting.js"></script>
<script type="text/javascript">

    //function chartmake()
    //{
    //    alert('ok');
    //    document.getElementById('btn').onclick();

    //}
   
    function chartshow(hardbouncepercent, softbouncepercent, unbouncepercent) {
        //$('#btn').click(function () {
        
        //var sentmail = (document.getElementById('lblSent').value / document.getElementById('lblsuccdeliver').value) * 100;
       <%-- var unbnd = document.getElementById('<%= lblSent.ClientID %>').value - (document.getElementById('<%= lblhardbounce.ClientID %>').value + document.getElementById('<%= lblsoftbounce.ClientID %>').value);
        var hardbouncepercent = (document.getElementById('<%= lblhardbounce.ClientID %>').value / document.getElementById('<%= lblSent.ClientID %>').value) * 100;
        var softbouncepercent = (document.getElementById('<%= lblsoftbounce.ClientID %>').value / document.getElementById('<%= lblSent.ClientID %>').value) * 100;
        var unbouncepercent = (unbnd / document.getElementById('<%= lblSent.ClientID %>').value) * 100;--%>
        //alert(hardbouncepercent, softbouncepercent, unbouncepercent);
            $('#container').highcharts({
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false
                },
                title: {
                    text: 'Campaign status chart'
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: false
                        },
                        showInLegend: true
                    }
                },
                series: [{
                    type: 'pie',
                    name: 'Mail Percentage',
                    data: [
                       ['Soft Bounced', softbouncepercent],
                        ['Hard Bounced', hardbouncepercent],
                        {
                            name: 'Unbounced',
                            y: unbouncepercent,
                            sliced: true,
                            selected: true
                        },
                        //['Sent Mail', sentmail]
                        //['IE', 26.8],
                        //{
                        //    name: 'Chrome',
                        //    y: 12.8,
                        //    sliced: true,
                        //    selected: true
                        //},
                        //['Safari', 8.5],
                        //['Opera', 6.2],
                        //['Others', 0.7]
                    ]
                }],
                credits: false
            });

       
      //  });
    //});
    }
   
</script> 

</body>
</html>
