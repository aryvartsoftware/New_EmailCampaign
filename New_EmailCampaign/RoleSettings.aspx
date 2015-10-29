<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleSettings.aspx.cs" Inherits="New_EmailCampaign.RoleSettings" %>

<%@ Register TagPrefix="uc" TagName="Spinner"
    Src="~/Common_Menu.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Email Campaign</title>

    <link href='http://fonts.googleapis.com/css?family=Lato:400,700' rel='stylesheet' type='text/css' />
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script type="text/javascript">
        function Clearuserinput() {
            $('input[type=text], textarea').each(function () {
                $(this).val('');
            });
            $("#ddlrole").val("-- Select --");

        }
        function Check_Click(objRef) {
            var row = document.getElementById('chksetting');
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
            var GridView = document.getElementById('chksetting');
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
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <uc:Spinner ID="Spinner1"
            runat="server"
            MinValue="1"
            MaxValue="10" />

        <div class="container bg">
            <div class="new_campaign">
                <h1>Access Settings</h1>
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="upGrdCustomers" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <div class="settings">
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <div class="access">
                                <div class="form-inline">
                                    <label for="exampleInputName2">Role Name</label>
                                    <asp:DropDownList class="form-control" ID="ddlrole" Style="width: 300px;" required="required" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlrole_SelectedIndexChanged" AutoPostBack="True">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div id="chksetting">
                            <div class="col-md-6">
                                <div class="acc-setting">
                                    <div class="acc-setting06">
                                        <div class="form-inline">
                                            <label for="exampleInputName2">Select All</label>
                                            <input value="" type="checkbox" id="Chkselectall" onclick="checkAll(this);" name="Chkselectall" runat="server" />
                                        </div>
                                        <div class="form-inline">
                                            <label for="exampleInputName2">Invite User</label>
                                            <input value="" type="checkbox" id="Chkusr" onclick="Check_Click(this);" name="Chkusr" runat="server" />
                                        </div>
                                        <div class="form-inline">
                                            <label for="exampleInputName2">Campaign Delete</label>
                                            <input value="" type="checkbox" id="Chkcmpdelete" onclick="Check_Click(this);" name="Chkcmpdelete" runat="server" />
                                        </div>
                                        <div class="form-inline">
                                            <label for="exampleInputName2">Viewing Reports</label>
                                            <input value="" type="checkbox" id="Chkvwreports" onclick="Check_Click(this);" name="Chkvwreports" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="acc-setting">
                                    <div class="form-inline">
                                        <label for="exampleInputName2">Campaign Create</label>
                                        <input value="" type="checkbox" id="Chkcmpcreate" name="Chkcmpcreate" onclick="Check_Click(this);" runat="server" />
                                    </div>
                                    <div class="form-inline">
                                        <label for="exampleInputName2">Send Campaign</label>
                                        <input value="" type="checkbox" id="Chksendcmp" name="Chksendcmp" onclick="Check_Click(this);" runat="server" />
                                    </div>
                                    <div class="form-inline">
                                        <label for="exampleInputName2">List Exports</label>
                                        <input value="" type="checkbox" id="Chklstexports" name="Chklstexports" onclick="Check_Click(this);" runat="server" />
                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="col-md-12" id="lblc">
                            <asp:Label CssClass="" ID="Label1" runat="server" Text=""></asp:Label>

                        </div>
                        <div class="col-md-6">
                            <div class="form-group form-btn pull-left">


                                <asp:Button ID="btnclear" class="btn btn-info btn-sm" runat="server" OnClick="btnclear_Click" Text="Clear" />
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group form-btn ">

                                <asp:Button ID="btnSubmit" class="btn btn-primary btn-sm" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>



        <div class="container">
            <div class="new_footer">
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
                        <p>
                            <img src="images/footer_tick.png">
                            Getting Started </p>
                        <p>
                            <img src="images/footer-vids.png">
                            Video Tutorials</p>
                        <p>
                            <img src="images/footer-andy.png">
                            Email Campaign Business Blog</p>
                    </div>
                    <div class="col-md-5 faq">
                        <h3>
                            <img src="images/footer-faq.png">
                            Frequently Asked Questions</h3>
                        <ul class="list-unstyled">
                            <li>How do I personalize the subject line of my email?</li>
                            <li>Why is my email campaign "Under Review"?</li>
                            <li>Can I Add Google Analytics Tracking To My Email Campaigns?</li>
                            <li>More Help Articles</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
