<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inbox.aspx.cs" Inherits="caslab12thapril.Inbox1" %>

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
                                    <div class="collapse navbar-collapse" id="myNavbar" style="margin-left:100px">
										<ul class="nav navbar-nav">
											
											<li class="dropdown">
												<a class="dropdown-toggle" data-toggle="dropdown" href="#">File 
													<span class="caret"></span>
												</a>
												<ul class="dropdown-menu">
													
													<li>
														<a href="CreateProject.aspx">Create Project</a>
													</li>
													<li>
														<a href="CreateTask.aspx">Create Task</a>
													</li>
                                                    <li>
														<a href="ViewPage2.aspx">View</a>
													</li>
                                                    <li>
														<a href="Reviewer2.aspx">Reviewer</a>
													</li>
												</ul>
											</li>
											<li>
												<a href="#">Edit</a>
											</li>
											<li>
												<a href="#">Tools</a>
											</li>
                                           
                                            
										</ul>
										<ul class="nav navbar-nav navbar-right">
											 <li>
												<a  href="Logout.aspx"><i style="float:right; font-size:medium; color:red "  class="fa fa-close" aria-hidden="true"></i>
 
											
												</a>
												
											</li>
                                           
										</ul>
									</div>
							
										</div>
							</nav>
							<div style="background-color:lavender;" class="container-fluid">
								<div class="row">
									<div class="col-sm-4" >
										<div class="btn-group">
											 <asp:button runat="server"  id="homebutton"  style="color:white;" class="btn btn-primary" Width="60px" Text="Home" OnClick="homebutton_Click"></asp:button>
                                     
                                         <asp:button runat="server"  id="Button1"  style="color:white;margin-left:5px" class="btn btn-primary" Width="70px"  OnClick="Button1_Click" ></asp:button>
                                      <asp:button runat="server"  id="Button2"  style="color:white;margin-left:5px" class="btn btn-primary" Width="70px"  Text="Review" OnClick="Button2_Click1" ></asp:button>
                                     
                                         <asp:Label runat="server" ID="countnumber"   style="margin-left:10px"></asp:Label>
                                      <asp:Label ID="label10" runat="server" />
										</div>
									</div>
									
									<div class="col-md-2" style="float:right;" >
                                       
                                     <h4 style="color:blue; font-style:italic">
										<asp:Label runat="server" ID="username" Text="USERNAME"> </asp:Label>
                                         
											
<%-- <asp:Label ID="Label3" runat="server" Text="Labev   ></asp:Label>--%>
                                          <%--<asp:Label ID="Label4" runat="server" Text="Label"   Visible="true" ></asp:Label>--%>
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
											<%--<asp:DropDownList runat="server" ID="revappr" AppendDataBoundItems="true" AutoPostBack="true"  Width="217px" ForeColor="WhiteSmoke" BackColor="CornflowerBlue"   class="list-group-item" OnSelectedIndexChanged="revappr_SelectedIndexChanged">
                                               
												</asp:DropDownList>--%>

                                            <asp:BulletedList ID="bull1" DataSourceID="sql1"  DataTextField="TaskId" DataValueField="TaskId" runat="server" DisplayMode="LinkButton" OnClick="bull1_Click1"></asp:BulletedList>
                                      <%--   <asp:RadioButtonList runat="server" ID="rd1" AutoPostBack="true" AppendDataBoundItems="true" Width="217px" ForeColor="WhiteSmoke" BackColor="CornflowerBlue"   class="list-group-item"  ></asp:RadioButtonList>
                                         --%>
                                            <asp:Label ID="Label3" runat="server" Text="Label"  Visible="false" ></asp:Label> 
                                            <asp:SqlDataSource ID="sql1" runat="server" ConnectionString="<%$ ConnectionStrings:MatreyPharmaConnectionString %>"
                                                 SelectCommand="proc_gettask" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:SessionParameter Name="Reviewer" SessionField="Session[&quot;UserName&quot;]" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                                                               
											</div>

                                            <asp:BulletedList ID="BulletedList1" DataSourceID="sql2"  DataTextField="TaskId" DataValueField="TaskId" runat="server" DisplayMode="LinkButton" OnClick="BulletedList1_Click"></asp:BulletedList>
                                        
                                    <asp:SqlDataSource runat="server" ID="sql2" ConnectionString="<%$ ConnectionStrings:MatreyPharmaConnectionString %>" SelectCommand="proc_gettaskforApprover" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="Approver" SessionField="Session[&quot;UserName&quot;]" Type="String" />
                                        </SelectParameters>
                                            </asp:SqlDataSource>
                              
                                            <asp:BulletedList ID="BulletedList2" DataSourceID="sql3"  DataTextField="TaskId" DataValueField="TaskId" runat="server" DisplayMode="LinkButton" OnClick="BulletedList2_Click"></asp:BulletedList>
                                            <asp:SqlDataSource runat="server" ID="sql3" ConnectionString="<%$ ConnectionStrings:MatreyPharmaConnectionString %>" SelectCommand="proc_gettaskforEmployee" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:SessionParameter Name="EmployeeName" SessionField="Session[&quot;UserName&quot;]" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>

											
										</div>
									</div>
                                    <br /><br />
                                     <asp:Label ID="taskid" runat="server" Visible="false" />
									<div class="col-lg-10 two" >

                                          <div class="col-lg-2" style="height: 60px; width: 938px">
                                              <br /><br />
                                              <a id="viewstatus" href="viewstatus.aspx" runat="server" >VIEW STATUS</a>
                                        </div>
                                       <div class="col-lg-6">
                                          
     <%--  <asp:GridView ID="GridView1" runat="server" class="table table-striped table-bordered" AutoGenerateColumns="False"   BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3"  GridLines="Horizontal" DataSourceID="SqlDataSource1">
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <Columns>
                        
                         <asp:BoundField DataField="TaskId" HeaderText="TaskId" SortExpression="TaskId" ItemStyle-Width="100px" />
                        
                        <asp:BoundField DataField="Reviewer" HeaderText="Reviewer" SortExpression="Reviewer" visible="false" />
                        <asp:BoundField DataField="Reviewerstatus" HeaderText="Reviewerstatus" SortExpression="Reviewerstatus" Visible="false" />
                    <asp:BoundField DataField="filename" HeaderText="filename" SortExpression="filename" />
                      <asp:TemplateField ItemStyle-HorizontalAlign = "Center">
            <ItemTemplate>
                    <asp:LinkButton ID="pdfdo" runat="server" Text="VIEW PDF"  ItemStyle-Width="900px" OnClick="pdfdo_Click"  ></asp:LinkButton>
                                           
            </ItemTemplate>


                        </asp:TemplateField> 
                        <asp:TemplateField ItemStyle-HorizontalAlign = "Center">
                       <ItemTemplate>
                  <asp:LinkButton ID="send" runat="server" Text="SEND" OnClick="send_Click1"   ></asp:LinkButton>
   
            </ItemTemplate>

        </asp:TemplateField> 
                        
                           </Columns>
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <SortedAscendingCellStyle BackColor="#F4F4FD" />
                    <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                    <SortedDescendingCellStyle BackColor="#D8D8F0" />
                    <SortedDescendingHeaderStyle BackColor="#3E3277" />
                </asp:GridView>
        
                                           <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MatreyPharmaConnectionString %>" SelectCommand="proc_getreviewerpdf " SelectCommandType="StoredProcedure">
                                               <SelectParameters>
                                                   <asp:SessionParameter Name="Reviewer" SessionField="Reviewer" Type="String" DefaultValue="" />
                                               </SelectParameters>
                                              
                                           </asp:SqlDataSource>--%>
                       
                 
                                      
      <%--     <asp:GridView ID="GridView2" runat="server" class="table table-striped table-bordered" AutoGenerateColumns="False"     BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3"   GridLines="Horizontal" DataKeyNames="TaskId" DataSourceID="SqlDataSource2">
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <Columns>
                       
                        
                         <asp:BoundField DataField="Reviewer" HeaderText="Reviewer" SortExpression="Reviewer"  Visible="False" ItemStyle-Width="100px" />
                        
                        <asp:BoundField DataField="TaskId" HeaderText="TaskId" SortExpression="TaskId"  />
                        <asp:BoundField DataField="Reviewerstatus" HeaderText="Reviewerstatus" SortExpression="Reviewerstatus"   Visible="False"/>
                    <asp:BoundField DataField="filename" HeaderText="filename" SortExpression="filename" />
                        <asp:BoundField DataField="frontpdf" HeaderText="frontpdf" SortExpression="frontpdf" Visible="false"/>
                       <asp:TemplateField ItemStyle-HorizontalAlign = "Center">
            <ItemTemplate>
                   <asp:LinkButton ID="pdfdocapp" runat="server" Text="VIEW PDF"  ItemStyle-Width="900px" OnClick="pdfdocapp_Click1" ></asp:LinkButton>
            </ItemTemplate>


                        </asp:TemplateField> 
                        <asp:TemplateField ItemStyle-HorizontalAlign = "Center">
                       <ItemTemplate>
                     <asp:LinkButton ID="send" runat="server" Text="SEND" OnClick="send_Click"  ></asp:LinkButton>
            </ItemTemplate>


        </asp:TemplateField> 
                           </Columns>

                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <SortedAscendingCellStyle BackColor="#F4F4FD" />
                    <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                    <SortedDescendingCellStyle BackColor="#D8D8F0" />
                    <SortedDescendingHeaderStyle BackColor="#3E3277" />
                </asp:GridView>

                                           <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MatreyPharmaConnectionString %>" SelectCommand="SELECT distinct  [TaskId],[Reviewer],  [Reviewerstatus], [filename], [frontpdf] FROM [Inboxdetails] WHERE (([Reviewer] = @Reviewer) AND ([Reviewerstatus] = @Reviewerstatus))">
                                               <SelectParameters>
                                                   <asp:SessionParameter Name="Reviewer" SessionField="Reviewer" Type="String" />
                                                   <asp:QueryStringParameter DefaultValue="ACCEPTED" Name="Reviewerstatus" QueryStringField="ACCEPTED" Type="String" />
                                               </SelectParameters>
                                           </asp:SqlDataSource>--%>


                                            
      </div>
                                        <br/>

                                                                      
                                           
    </div>
    </form>
</body>
</html>
