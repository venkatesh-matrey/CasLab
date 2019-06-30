<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="caslab12thapril.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <title>CAS Lab</title>
     <script type="text/javascript">
        function noBack()
         {
             window.history.forward()
         }
        noBack();
        window.onload = noBack;
        window.onpageshow = function(evt) { if (evt.persisted) noBack() }
        window.onunload = function() { void (0) }
    </script>
  
   <meta charset="utf-8"/>
			<meta name="viewport" content="width=device-width, initial-scale=1"/>
				<link rel="stylesheet" href="assets/bootstrap.min.css"/>
					<link rel="stylesheet" href="assets/custom.css"/>
						<link href="assets/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
							<script src="assets/jquery.min.js"></script>
							<script src="assets/bootstrap.min.js"></script>
     <style type="text/css">
        .auto-style1 {
            width: 41%;
        }
        .auto-style2 {
            width: 179px;
        }
        .auto-style3 {
            text-align: left;
        }
        .auto-style4 {
            text-align: left;
        }
        .auto-style5 {
            width: 99%;
            height: 125px;
        }
        .auto-style6 {
            width: 172px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <nav  class="navbar navbar-inverse">
								<div class="container-fluid">
									<div class="navbar-header">
										<button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
											<span class="icon-bar"></span>
											<span class="icon-bar"></span>
											<span class="icon-bar"></span>
										</button>
										<%--<a style="color:white;" class="navbar-brand" href="#">CAS LAB</a>--%>
                                        <a style="color:white; padding: 1px;" class="navbar-brand" href="#"><img src="img/logo.png"></a>
									</div>
									<div class="collapse navbar-collapse" id="myNavbar">
										<ul class="nav navbar-nav">
											<li class="active">
												<a href="#">Home</a>
											</li>
											<li class="dropdown">
												<a class="dropdown-toggle" data-toggle="dropdown" href="#">File 
													<span class="caret"></span>
												</a>
												<ul class="dropdown-menu">
													
													<li>
														<a href="#">Link 1</a>
													</li>
													<li>
														<a href="#">Link 2</a>
													</li>
												</ul>
											</li>
											<li>
												<a href="#">Edit</a>
											</li>
											<li>
												<a href="#">Tools</a>
											</li>
                                            <li class="dropdown">
												<a class="dropdown-toggle" data-toggle="dropdown" href="#">Notifications 
													<span class="caret"></span>
												</a>
												<ul class="dropdown-menu">
													
													<li>
														<a href="ReviewerNotifications.aspx">Reviewer Notification</a>
													</li>
													<li>
														<a href="ApproverNotification.aspx">Approver Notification</a>
													</li>
												</ul>
											</li>
                                            
										</ul>
										<ul class="nav navbar-nav navbar-right">
											 <li class="dropdown">
												<a class="dropdown-toggle" data-toggle="dropdown" href="#"><i style="float:right; font-size:medium " class="fa fa-power-off" aria-hidden="true"></i>
 
													<span class="caret"></span>
												</a>
												<ul class="dropdown-menu">
													
													<li>
														<a href="Logout.aspx">Logout</a>
													</li>
													<li>
														<a href="WebForm1.aspx">Cancle</a>
													</li>
												</ul>
											</li>
                                           </li>
										</ul>
									</div>
								</div>
							</nav>
							<div style="background-color:lavender;" class="container-fluid">
								<div class="row">
									<div class="col-sm-4" >
										<div class="btn-group">
											 <button type="button" class="btn btn-primary"><a style="color:white;" href="CreateProject.aspx">Create Project</a></button>
                                           
                                        
                                            <button type="button" class="btn btn-primary"><a style="color:white;" href="CreateTask.aspx">Create Task</a></button>
											
                                        
										</div>
									</div>
									<div class="col-sm-6"  >
									<button type="button" class="btn btn-primary active"><a style="color:white;" href="WebForm1.aspx">Home</a>   </button>
										<button type="button" class="btn btn-primary"><a  style="color:white;" href="Inbox.aspx">Inbox	</a>			
										</button>
										<button type="button" class="btn btn-primary"><a  style="color:white;" href="ViewPage.aspx" >View</a>  </button>
                                        	<button type="button" class="btn btn-primary"><a  style="color:white;" href="Reviewer1.aspx" >Reviwer</a>  </button>
                                          <button type="button" class="btn btn-primary"><a  style="color:white;" href="Approver1.aspx" >Approver</a>  </button>
                                         <button type="button" class="btn btn-primary"><a  style="color:white;" href="ApproverInbox.aspx" >Approver Inbox</a>  </button>
                                      
                                         <%--<button type="button" class="btn btn-primary"><a  style="color:white;" href="Logout.aspx" >Log out</a>  </button>--%>
                                         <button type="button" class="btn btn-primary"><a  style="color:white;" href="WebForm3.aspx" >Log out</a>  </button>


									</div>
									<div class="col-md-2" style="float:right;" >
                                       
                                       <h4 style="color:blue; font-style:italic"> User Name:
										<asp:Label runat="server" ID="username" Text="USERNAME"> </asp:Label>
                                          </h4>  
									</div>
								</div>
							</div>
							<div style="position:relative;" class="container-fluid">
								<div class="row">
									<div style="background-color:#f1f1f1;     padding-right: 2px;
    padding-left: 2px" class="col-lg-2 one" >
										<div class="list-group list-group-tree well" >
											<a class="list-group-item active" aria-expanded="true" data-toggle="collapse">
												<i class="fa fa fa-chevron"></i> Project Name
  
											</a>
                                            <br />
										<div class="list-group  " aria-expanded="true"  >
											



                                            <asp:TreeView ID="TreeView1" runat="server" ImageSet="XPFileExplorer" NodeIndent="15">
    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px"
        NodeSpacing="0px" VerticalPadding="2px"></NodeStyle>
    <ParentNodeStyle Font-Bold="False" />
    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
        VerticalPadding="0px" />
</asp:TreeView>
                                          <%-- <asp:TreeView ID="TreeView1"  runat="server" ImageSet="XPFileExplorer" NodeIndent="15"></asp:TreeView>--%>                                         
											</div>

                                        
                                         

											
										</div>
									</div>

									<div class="col-lg-10 two" >
    </div>
    </form>
</body>
</html>
