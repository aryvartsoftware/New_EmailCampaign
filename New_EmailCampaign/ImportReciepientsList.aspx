<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportReciepientsList.aspx.cs" Inherits="New_EmailCampaign.ImportReciepientsList" %>

<%@ Register TagPrefix="uc" TagName="Spinner" Src="~/Common_Menu.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Import Contacts List :: Aryvart Campaign</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <script src="js/jqueryv11.2.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script type="text/javascript">
        var validFilesTypes = ["xlsx", "xls"];
        function ValidateFile() {
            var label = document.getElementById("<%=Label1.ClientID%>")
            if ($('#FileUpload1').val() == '') {
                label.innerHTML = "Browse and select a file!";
                label.className = "alert alert-danger";
                return false;
            }
            else {
                var file = document.getElementById("<%=FileUpload1.ClientID%>");
                ;
                var path = file.value;
                var ext = path.substring(path.lastIndexOf(".") + 1, path.length).toLowerCase();
                var isValidFile = false;
                for (var i = 0; i < validFilesTypes.length; i++) {
                    if (ext == validFilesTypes[i]) {
                        isValidFile = true;
                        break;
                    }
                }
                if (!isValidFile) {
                    label.innerHTML = "Invalid File. Please upload Acceptable file types";
                    label.className = "alert alert-danger";
                    return false;
                }
                else {
                    if (DD1.selectedIndex == 0 && DD2.selectedIndex == 0 && DD3.selectedIndex == 0 && DD4.selectedIndex == 0 && DD5.selectedIndex == 0 && DD6.selectedIndex == 0 && DD7.selectedIndex == 0 && DD8.selectedIndex == 0 && DD9.selectedIndex == 0) {
                        alert('Map your fields by selecting coresponding column.');
                        return false;
                    }
                    else if (DD1.selectedIndex != 2 && DD2.selectedIndex != 2 && DD3.selectedIndex != 2 && DD4.selectedIndex != 2 && DD5.selectedIndex != 2 && DD6.selectedIndex != 2 && DD7.selectedIndex != 2 && DD8.selectedIndex != 2 && DD9.selectedIndex != 2) {
                        alert('Map your fields by selecting Emailid is mandatory!');
                        return false;
                    }
                    else
                        return true;
                }
            }
        }

        function validatecontrolDD() {
            if (DD1.selectedIndex == 0 && DD2.selectedIndex == 0 && DD3.selectedIndex == 0 && DD4.selectedIndex == 0 && DD5.selectedIndex == 0 && DD6.selectedIndex == 0 && DD7.selectedIndex == 0 && DD8.selectedIndex == 0 && DD9.selectedIndex == 0) {
                alert('Map your fields by selecting coresponding column.');
                return false;
            }
            else if (DD1.selectedIndex == 2 && DD2.selectedIndex == 2 && DD3.selectedIndex == 2 && DD4.selectedIndex == 2 && DD5.selectedIndex == 2 && DD6.selectedIndex == 2 && DD7.selectedIndex == 2 && DD8.selectedIndex == 2 && DD9.selectedIndex == 2) {
                alert('Map your fields by selecting Emailid is mandatory!');
                return false;
            }
            else
                return true;

        }

        function Clearuserinput() {
            $('#FileUpload1').val('');
            $("#form1 select").val("0");
            $('#Label1').text('');
            document.getElementById("<%=Label1.ClientID%>").className = "";
        }

        function checkselectexist(selectid) {
            var e = document.getElementById(selectid);
            if (e.selectedIndex != 0) {
                for (var h = 1; h < 10; h++) {
                    var dyne = document.getElementById("DD" + h);

                    if (dyne.selectedIndex != 0) {
                        if (selectid != dyne.id) {

                            if (e.selectedIndex == dyne.selectedIndex) {
                                alert('Choose some other column, already it is choosen!');
                                e.selectedIndex = 0;
                            }
                        }
                    }
                }
            }

        }

        function Clearuserinputselect() {
            var theAnswer = confirm("Are you sure you want to clear the input?");

            if (theAnswer) {
                $('#FileUpload1').val('');
                $('#Label1').text('');
                document.getElementById("<%=Label1.ClientID%>").className = "";
                $("#form1 select").val("0");
            }
            else {
                return false;
            }
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <uc:Spinner ID="Spinner1"
            runat="server"
            MinValue="1"
            MaxValue="10" />
        <div class="container-fluid bg">
            <div class="row">
                <div class="container new_campaign">
                    <div class="row">
                        <h1>Import Contacts</h1>
                        <div class="col-md-12  new_bg import2">
                            <div>
                                <img src="images/excel.jpg" class="img-responsive">
                            </div>
                            <div class="row">
                                <div class="col-md-8 import-list">
                                    <div class="import">
                                        <span class="glyphicon glyphicon-info-sign"></span>
                                        <h3>Import Disclaimer</h3>
                                        <p>
                                            Importing does not send any confirmation emails to your list. Make sure,<br>
                                            &#9658; Excel file should not contain empty row after column header.
                      <br>
                                            &#9658;The column in excel is described below,
                                        </p>

                                        <div class="col-md-4">
                                            <ul class="list-unstyled">
                                                <li>"Name" mandatory, </li>
                                                <li>"Emailid" mandatory, </li>
                                                <li>"ContactNo" optional, </li>
                                            </ul>
                                        </div>
                                        <div class="col-md-4">
                                            <ul class="list-unstyled">
                                                <li>"Designation" optional,</li>
                                                <li>"Address" optional.</li>
                                                <li>"City" optional, </li>
                                            </ul>
                                        </div>
                                        <div class="col-md-4">
                                            <ul class="list-unstyled">
                                                <li>"State" optional, </li>
                                                <li>"Country" optional,</li>
                                                <li>"Date of birth" optional</li>
                                            </ul>
                                        </div>

                                        <p><b>Duplicate instance of email address will be cleaned automatically</b>. So do not worry about that.</p>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="campaign import-file">
                                        <h3>Import file <span class="pull-right"><a>
                                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Download Empty Template</asp:LinkButton>
                                        </a></span></h3>
                                        <div class="form-group">
                                            <label for="exampleInputName3">Upload a file</label>
                                            <span></span>
                                            <asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server" required="required" Font-Size="Small" />
                                            <p>
                                                Acceptable file types: <b style="background-color: #ffff99;">(.xlsx, .xls)</b> &nbsp;&nbsp;&nbsp;                            
                                            </p>
                                            <p style="margin-top: 2px; padding: 0;">
                                                <asp:Label CssClass="" ID="Label1" runat="server" Text=""></asp:Label></p>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <div class="map-field" id="mapcol" style="">
                                <h3>Map Your Fields</h3>
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="create3 option01">
                                            <div class="form-group">
                                                <label for="exampleInputName1">Column1</label>
                                                <select class="form-control" runat="server" id="DD1" name="drop1" onchange="checkselectexist(this.id)">
                                                    <option value="0">-- Select --</option>
                                                    <option value="ContactName">Name</option>
                                                    <option value="email_id">Emailid</option>
                                                    <option value="ContactNo">ContactNo</option>
                                                    <option value="Designation">Designation</option>
                                                    <option value="Addressline1">Address</option>
                                                    <option value="City1">City</option>
                                                    <option value="State1">State</option>
                                                    <option value="Country1">Country</option>
                                                    <option value="DateofBirth">DateofBirth</option>
                                                </select>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Column2</label>
                                                <select class="form-control" runat="server" id="DD2" name="drop2" onchange="checkselectexist(this.id)">
                                                    <option value="0">-- Select --</option>
                                                    <option value="ContactName">Name</option>
                                                    <option value="email_id">Emailid</option>
                                                    <option value="ContactNo">ContactNo</option>
                                                    <option value="Designation">Designation</option>
                                                    <option value="Addressline1">Address</option>
                                                    <option value="City1">City</option>
                                                    <option value="State1">State</option>
                                                    <option value="Country1">Country</option>
                                                    <option value="DateofBirth">DateofBirth</option>
                                                </select>
                                            </div>

                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Column3</label>
                                                <select class="form-control" runat="server" id="DD3" name="drop3" onchange="checkselectexist(this.id)">
                                                    <option value="0">-- Select --</option>
                                                    <option value="ContactName">Name</option>
                                                    <option value="email_id">Emailid</option>
                                                    <option value="ContactNo">ContactNo</option>
                                                    <option value="Designation">Designation</option>
                                                    <option value="Addressline1">Address</option>
                                                    <option value="City1">City</option>
                                                    <option value="State1">State</option>
                                                    <option value="Country1">Country</option>
                                                    <option value="DateofBirth">DateofBirth</option>
                                                </select>
                                            </div>

                                        </div>
                                    </div>

                                    <div class="col-md-4">
                                        <div class="create3">
                                            <div class="form-group">
                                                <label for="exampleInputName3">Column4</label>
                                                <select class="form-control" runat="server" id="DD4" name="drop4" onchange="checkselectexist(this.id)">
                                                    <option value="0">-- Select --</option>
                                                    <option value="ContactName">Name</option>
                                                    <option value="email_id">Emailid</option>
                                                    <option value="ContactNo">ContactNo</option>
                                                    <option value="Designation">Designation</option>
                                                    <option value="Addressline1">Address</option>
                                                    <option value="City1">City</option>
                                                    <option value="State1">State</option>
                                                    <option value="Country1">Country</option>
                                                    <option value="DateofBirth">DateofBirth</option>
                                                </select>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleInputName3">Column5</label>
                                                <select class="form-control" runat="server" id="DD5" name="drop5" onchange="checkselectexist(this.id)">
                                                    <option value="0">-- Select --</option>
                                                    <option value="ContactName">Name</option>
                                                    <option value="email_id">Emailid</option>
                                                    <option value="ContactNo">ContactNo</option>
                                                    <option value="Designation">Designation</option>
                                                    <option value="Addressline1">Address</option>
                                                    <option value="City1">City</option>
                                                    <option value="State1">State</option>
                                                    <option value="Country1">Country</option>
                                                    <option value="DateofBirth">DateofBirth</option>
                                                </select>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleInputName3">Column6</label>
                                                <select class="form-control" runat="server" id="DD6" name="drop6" onchange="checkselectexist(this.id)">
                                                    <option value="0">-- Select --</option>
                                                    <option value="ContactName">Name</option>
                                                    <option value="email_id">Emailid</option>
                                                    <option value="ContactNo">ContactNo</option>
                                                    <option value="Designation">Designation</option>
                                                    <option value="Addressline1">Address</option>
                                                    <option value="City1">City</option>
                                                    <option value="State1">State</option>
                                                    <option value="Country1">Country</option>
                                                    <option value="DateofBirth">DateofBirth</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="create3">
                                            <div class="form-group">
                                                <label for="exampleInputName3">Column7</label>
                                                <select class="form-control" runat="server" id="DD7" name="drop7" onchange="checkselectexist(this.id)">
                                                    <option value="0">-- Select --</option>
                                                    <option value="ContactName">Name</option>
                                                    <option value="email_id">Emailid</option>
                                                    <option value="ContactNo">ContactNo</option>
                                                    <option value="Designation">Designation</option>
                                                    <option value="Addressline1">Address</option>
                                                    <option value="City1">City</option>
                                                    <option value="State1">State</option>
                                                    <option value="Country1">Country</option>
                                                    <option value="DateofBirth">DateofBirth</option>
                                                </select>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleInputName3">Column8</label>
                                                <select class="form-control" runat="server" id="DD8" name="drop8" onchange="checkselectexist(this.id)">
                                                    <option value="0">-- Select --</option>
                                                    <option value="ContactName">Name</option>
                                                    <option value="email_id">Emailid</option>
                                                    <option value="ContactNo">ContactNo</option>
                                                    <option value="Designation">Designation</option>
                                                    <option value="Addressline1">Address</option>
                                                    <option value="City1">City</option>
                                                    <option value="State1">State</option>
                                                    <option value="Country1">Country</option>
                                                    <option value="DateofBirth">DateofBirth</option>
                                                </select>
                                            </div>

                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Column9</label>
                                                <select class="form-control" runat="server" id="DD9" name="drop9" onchange="checkselectexist(this.id)">
                                                    <option value="0">-- Select --</option>
                                                    <option value="ContactName">Name</option>
                                                    <option value="email_id">Emailid</option>
                                                    <option value="ContactNo">ContactNo</option>
                                                    <option value="Designation">Designation</option>
                                                    <option value="Addressline1">Address</option>
                                                    <option value="City1">City</option>
                                                    <option value="State1">State</option>
                                                    <option value="Country1">Country</option>
                                                    <option value="DateofBirth">DateofBirth</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="create-list03">

                                        <div class="form-group form-btn padlft10 pull-left" style="margin-left: 16px;">
                                            <input id="Reset1" type="reset" onclick="return Clearuserinputselect();" value="Reset" class="btn btn-info btn-sm" /><%--"return validatefile('FileUpload1');"--%>
                                            <asp:Button ID="btnUpload" CssClass="btn btn-primary btn-sm mar-right15" runat="server" Text="Import" OnClientClick="return ValidateFile();" OnClick="btnUpload_Click" />

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
