<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DateTimeboot.aspx.cs" Inherits="New_EmailCampaign.DateTimeboot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <script src="js/jqueryv11.2.js"></script>
    <script src="js/bootstrap-datetimepicker.min.js"></script>
<script src="js/bootstrap.min.js"></script>
    

    <link href="css/bootstrapv2.css" rel="stylesheet" />
    
    <link href="css/bootstrap-datetimepicker.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="well">
  <div id="datetimepicker1" class="input-append date">
    <input id="dt1" data-format="dd/MM/yyyy hh:mm:ss PP" runat="server" type="text" />
    <span class="add-on">
      <i data-time-icon="icon-time" data-date-icon="icon-calendar">
      </i>
    </span>
  </div>
</div>
<script type="text/javascript">
    $(function () {
        $('#datetimepicker1').datetimepicker({
            language: 'pt-BR',
            pick12HourFormat: true
        });
    });
</script>
    </form>
</body>
</html>
