<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="caslab12thapril.Login1" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="utf-8"/>
        <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
        <meta name="viewport" content="width=device-width, initial-scale=1"/>
        <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
        <title>Cas Lab App</title>

        <!-- Favicon and touch icons -->
        <link rel="shortcut icon" href="assets1/dist/img/ico/favicon.png" type="image/x-icon"/>
        <!-- Bootstrap -->
        <link href="assets1/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
        <!-- Bootstrap rtl -->
        <!--<link href="assets1/bootstrap-rtl/bootstrap-rtl.min.css" rel="stylesheet" type="text/css"/>-->
        <!-- Pe-icon-7-stroke -->
        <link href="assets1/pe-icon-7-stroke/css/pe-icon-7-stroke.css" rel="stylesheet" type="text/css"/>
        <!-- style css -->
        <link href="assets1/dist/css/stylecrm.css" rel="stylesheet" type="text/css"/>
        <!-- Theme style rtl -->
        <!--<link href="assets1/dist/css/stylecrm-rtl.css" rel="stylesheet" type="text/css"/>-->
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div class="login-wrapper">
            
            <div class="container-center">
            <div class="login-area">
                <div class="panel panel-bd panel-custom">
                    <div class="panel-heading">
                        <div class="view-header">
                            <div class="header-icon">
                                <i class="pe-7s-unlock"></i>
                            </div>
                            <div class="header-title">
                                <h3>CAS Login</h3>
                                <small><strong>Please enter your credentials to login.</strong></small>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        
                            <div class="form-group">
                                <asp:label runat="server" class="control-label" ID="label1" for="username">USERNAME</asp:label>
                                <asp:textbox runat="server" type="text" placeholder="name" title="Please enter you username" required="" value="" name="username" id="txtUserName" class="form-control"/>
                                <%--<span class="help-block small">Your unique ID username to app</span>--%>
                            </div>
                            <div class="form-group">
                                <asp:label runat="server" ID="label2" class="control-label" for="password">Password</asp:label>
                                <asp:textbox runat="server" type="password" title="Please enter your password" placeholder="******" required="" value="" name="password" id="txtPassword" class="form-control"/>
                                <%--<span class="help-block small">Your strong password</span>--%>
                            </div>
                            <div>
                                <asp:button runat="server" ID="button1"  OnClick="button1_Click" Text="LOGIN" class="btn btn-add"></asp:button>
                                <!-- <a class="btn btn-warning" href="register.html">Forget</a> -->
                                <br />
                                <asp:Label ID="Label3" runat="server" />
                            </div>
                        
                        </div>
                        </div>
                </div>
            </div>
        </div>
    </div>
    </form>
    <script src="assets1/plugins/jQuery/jquery-1.12.4.min.js" type="text/javascript"></script>
        <!-- bootstrap js -->
        <script src="assets1/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
</body>
</html>
