<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPlanSuccess.aspx.cs" Inherits="New_EmailCampaign.UserPlanSuccess" %>
<%@ Register TagPrefix="uc" TagName="Spinner"
    Src="~/Common_Menu.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Email Campaign</title>
    <link href='http://fonts.googleapis.com/css?family=Lato:400,700' rel='stylesheet' type='text/css'>
     <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
         <uc:Spinner ID="Spinner1"
            runat="server"
            MinValue="1"
            MaxValue="10" />
    <div>
    <section class="part">
  <div class="container">
    <div class="row">
      <div class="new_campaign text-center">
        <h1>We are integrated with the best payment gateways in the world!</h1>
      </div>
    </div>
    <div class="col-md-12 col-sm-12 col-xs-12 icons">
    <ul>
    <li><img src="img/authorize-net.png" class="img-responsive"></li>
    <li><img src="img/checkout.png" class="img-responsive"></li>
    <li><img src="img/payflow.png" class="img-responsive"></li>
    <li><img src="img/brain-tree.png" class="img-responsive"></li>
    <li><img src="img/stripe.png" class="img-responsive"></li>
    <li><img src="img/paypal.png" class="img-responsive"></li>
    </ul>
    </div>
    </div>
    </section>
    <div class="container">
    <div class="row part2">
    <div class="col-md-12 col-sm-12 col-xs-12 text-center">
    <h2>Start accepting online payments today!</h2>
    <%--<p class="try"><a href="#" class="bnt btn-danger pad10">Try it Free for 14 Days</a></p>--%>
        <asp:Button ID="Button1" runat="server" CssClass="bnt btn-danger pad10" OnClick="Button1_Click" Text="Approve the plan" />
    <p>Queries? Call us on +1 959 763 5889</p>
    </div>
    </div>
   </div>
   <section class="part">
  <div class="container">
    <div class="row part2">
    <div class="col-md-4 col-sm-4 col-xs-12">
    
    <img src="img/form1.jpg" class="img-responsive box">
    
    </div>
    <div class="col-md-4 col-sm-4 col-xs-12">
    
    <img src="img/form2.jpg" class="img-responsive box">
    
    </div>
    <div class="col-md-4 col-sm-4 col-xs-12">
    
    <img src="img/form3.jpg" class="img-responsive box">
    
    </div>
    </div>
    <div class="row">
    <div class="col-md-4 col-sm-4 col-xs-12 box1" >
    <h3>
Easy to Set up</h3>
    <p>In just a few clicks, start accepting online payments from your customers. There are no painful long forms to fill. All you need is your merchant account details and you are good to go!</p>
    
    </div>
    <div class="col-md-4 col-sm-4 col-xs-12 box1">
    <h3>Convenient to Use</h3>
    <p>Offer your customers the convenience to pay you from anywhere. No more standing in the queue or cash payments. Remember your payment is just a click away!</p>
    
    </div>
    <div class="col-md-4 col-sm-4 col-xs-12">
    <h3>Simple to Track</h3>
    <p>It's a tad difficult to keep track of the cash payments. Once you receive an online payment, Zoho Books will automatically map it to the correct invoice and mark it 'Paid'. Awesome isn't it</p>
    
    </div>
    </div>
     </div>
  </section>
        
    
    </div>
    </form>
</body>
</html>
