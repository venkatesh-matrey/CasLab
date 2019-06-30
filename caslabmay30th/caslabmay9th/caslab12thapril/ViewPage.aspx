<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPage.aspx.cs" Inherits="caslab12thapril.ViewPage" %>

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
                                          <%--<button type="button" class="btn btn-primary"><a  style="color:white;" href="Approver1.aspx" >Approver</a>  </button>
                                         <button type="button" class="btn btn-primary"><a  style="color:white;" href="ApproverInbox.aspx" >Approver Inbox</a>  </button>--%>
                                      
                                         <%--<button type="button" class="btn btn-primary"><a  style="color:white;" href="Logout.aspx" >Log out</a>  </button>--%>


									</div>
									<div class="col-md-2" style="float:right;" >
                                       <h4 style="color:blue; font-style:italic">
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
											<asp:DropDownList runat="server" ID="idproject"  Width="217px" ForeColor="WhiteSmoke" BackColor="CornflowerBlue" DataSourceID="Sqldatasource1" DataTextField="ProjectId" DataValueField="ProjectId" OnSelectedIndexChanged="project_SelectedIndexChanged" AppendDataBoundItems="true"  AutoPostBack="true"  class="list-group-item">
                                               
												</asp:DropDownList>
                                             <asp:SqlDataSource runat="server" ID="Sqldatasource1" ConnectionString="<%$ ConnectionStrings:MatreyPharmaConnectionString %>" SelectCommand="proc_GetProjectDetailsByEmpid" SelectCommandType="StoredProcedure">
                                                 <SelectParameters>
                                                     <asp:SessionParameter Name="EmpId" SessionField="Session[&quot;EmpId&quot;]" Type="String" />
                                                 </SelectParameters>
                                                </asp:SqlDataSource>
                                          <%-- <asp:TreeView ID="TreeView1"  runat="server" ImageSet="XPFileExplorer" NodeIndent="15"></asp:TreeView>--%>                                         
											</div>

                                        
                                         

											
										</div>
									</div>

									<div class="col-lg-10 two" >


                                            <table class="auto-style1">
            <tr>
                <td class="auto-style2">SELECT TASK ID</td>
                <td> <asp:DropDownList runat="server" ID="taskids"  AutoPostBack="true" AppendDataBoundItems="true" class="list-group-item" OnSelectedIndexChanged="taskids_SelectedIndexChanged"></asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <%--<td>
                    <asp:Button ID="Button1" runat="server" Height="31px"  Text="Get" OnClick="Button1_Click" Width="109px" />
                    <br />
                    <asp:Label ID="Label9" runat="server"></asp:Label>
                </td>--%>
            </tr>
        </table>

<%--                                          <div class="form-group">
															<div class="col-lg-4">
																<asp:label runat="server" >Select TaskId's:</asp:label>
															</div>
															<div class="col-lg-6">
																<asp:DropDownList runat="server" ID="taskids" DataSourceID="SqlDataSource2" DataTextField="TaskId" DataValueField="TaskId" AutoPostBack="true" AppendDataBoundItems="true" class="list-group-item" OnSelectedIndexChanged="taskids_SelectedIndexChanged" ></asp:DropDownList>
																</div>
																<br/>
				                          </div> --%>



                                        
                                                        
                                                        
                   <asp:Panel ID="Panel1" runat="server" Visible="False">
            <div class="auto-style3">
                <div class="auto-style4">
                    <strong>
                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="25px" Text="Task Details"></asp:Label>
                    </strong>
                    <br />
                </div>
               
                <div class="col-lg-1">
      <label style="float:right;" for="sel1">EmployeeId</label>
      
      </div>
    <div class="col-lg-2">
   <asp:TextBox runat="server" ID="employeeid" ReadOnly="true" class="form-control"></asp:TextBox>      
      </div>

                <table class="auto-style5">
                    <tr>
                        <td class="auto-style6">TASK ID</td>
                        <td class="auto-style3">
                            <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                  
                      <tr>
                        <td class="auto-style6">PROJECT ID</td>
                        <td class="auto-style3">
                            <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6">TASK TITLE</td>
                        <td class="auto-style3">
                            <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6">TASK DESCRIPTION</td>
                        <td class="auto-style3">
                            <asp:Label ID="Label12" runat="server"></asp:Label>
                        </td>
                    </tr>

                     <tr>
                        <td class="auto-style6">CHEMICAL</td>
                        <td class="auto-style3">
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td class="auto-style6">QUNTATITY</td>
                        <td class="auto-style3">
                            <asp:Label ID="Label2" runat="server"></asp:Label>
                        </td>
                    </tr>

                </table>
                <br />
                <br />
                <br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="TaskId" HeaderText="TASK ID" />
                        <asp:BoundField DataField="ProjectId" HeaderText="PROJECT ID" />
                        <asp:BoundField DataField="TaskTitle" HeaderText="TASK TITLE" />
                        <asp:BoundField DataField="Chemical" HeaderText="CHEMICAL" />
                        <asp:BoundField DataField="Quantatity" HeaderText="QUNTATITY" />
                        <asp:BoundField DataField="Units" HeaderText="UNITS" />
                    </Columns>
                </asp:GridView>
             
                    <br />
                   
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />




                     </asp:Panel>                                       
                                                        
            
   
    </div>
    </form>


     <script>


$(document).ready(function() {
    $('#example').DataTable();
} );
</script>

<script type = "text/javascript" src = "https://code.jquery.com/jquery-3.3.1.js" ></script>

<script type = "text/javascript" src = "https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js" ></script>

<script type = "text/javascript" src = "https://cdn.datatables.net/1.10.19/js/dataTables.bootstrap.min.js" ></script>																																																				
</body>
</html>
