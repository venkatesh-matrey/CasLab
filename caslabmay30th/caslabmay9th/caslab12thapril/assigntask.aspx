<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="assigntask.aspx.cs" Inherits="caslab12thapril.assigntask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div  class="col-lg-12" >
        <br /><br /><br /> <asp:Label ID="taskid" runat="server" Visible="false" />
									<div class="form-group">
															<div class="col-lg-3">
																<asp:label runat="server" >TASK ID</asp:label>
															</div>
															<div class="col-lg-6">
																<asp:textbox ID="Textbox3" ReadOnly="true" runat="server"  class="form-control"/>
																</div><br /><br /><br />
                                        <div class="form-group">
															<div class="col-lg-3">
																<asp:label runat="server" >EMPLOYEE ID</asp:label>
															</div>
															<div class="col-lg-6">
																<asp:textbox ID="empid"  runat="server"  class="form-control"/>
																</div>
									</div><br /><br /><div class="form-group">
															<div class="col-lg-3">
																<asp:label runat="server" >EMPLOYEE NAME</asp:label>
															</div>
															<div class="col-lg-6">
																<asp:textbox ID="employeename"  runat="server"  class="form-control"/>
																</div><br /><br /><br />
                                         <asp:Button runat="server" ID="taskdata"  style="margin-left:500px" Text="ASSIGN" class="btn btn-primary" OnClick="taskdata_Click"  />
                                        </div>
        </div>
</asp:Content>
