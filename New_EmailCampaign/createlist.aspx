<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createlist.aspx.cs" Inherits="New_EmailCampaign.createlist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Aryvart Campaign</title>
  <!-- start css -->
  <link href="css/bootstrap.css" rel="stylesheet" />
  <link href="css/style.css" rel="stylesheet" />
  <!-- end css -->

  <!-- start js -->
  <script src="js/jquery.min.js"></script>
  <script src="js/bootstrap.min.js"></script>

    <script type="text/javascript">
        function SubmitClear() {
            $('input[type=text], textarea').each(function () {
                $(this).val('');
            });
        }
     
        </script>
<!-- end js -->
</head>
<body>
    <form id="form1" runat="server">
    <div class="container-fluid bg">
    <div class="row">
      <div class="container">
        <div class="row">
          <h3>Create List</h3>
          <div class="col-md-12  new_bg"> <!-- start campaign section -->
            <div class="row">
              <div class="col-md-12">
                <div class="campaign">            
                  
                    <div class="form-group">
                      <label for="exampleInputName1">List Name</label>
                      <input type="text" class="form-control" runat="server" id="txtUserName" name="txtUserName" placeholder="Enter List Name." required oncontextmenu="return false;" />                     
                    </div>
                    <div class="form-group">
                      <label for="text1">Comments</label>
                      <textarea class="form-control" runat="server" name="txta11" id="txta11" rows="3"  oncontextmenu="return false;" placeholder="Enter text here.."></textarea>                  
                    </div> 
                     
                    <div class="form-group form-btn">                      
                        <input id="Reset1" type="reset" onclick="return Clearuserinput();" value="Clear All" value="Clear All" class="btn btn-info btn-sm"/>
                        <asp:Button ID="btnSubmit" class="btn btn-primary btn-sm" runat="server" OnClick="btnSubmit_Click" Text="Submit" />                           
                    </div> 
 <div class="form-group">
                      
     <asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="#006600"></asp:Label>
 </div> 
                </div>
              </div>

              
            </div>
          </div> <!-- start campaign section -->
        </div>
      </div> 

    </div>
  </div>
    </form>
</body>
</html>
