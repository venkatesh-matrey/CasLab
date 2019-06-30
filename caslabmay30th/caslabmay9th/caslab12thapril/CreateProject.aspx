<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CreateProject.aspx.cs" Inherits="caslab12thapril.CreateProject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="buttonexport">
                               
  	     <div class="form-group">
															
														<div class="form-group">
															<div class="col-lg-3">
																<asp:label runat="server" >Project ID:</asp:label>
															</div>
															<div class="col-lg-6">
																<asp:textbox ID="txtprojectid" runat="server"  ReadOnly="true" class="form-control"/>
																</div>
															
																</div>
                                                        	<br/><br/><br />
                                                        <div class="form-group">
															<div class="col-lg-3">
																<asp:label runat="server" >Project Title:</asp:label>
															</div>
															<div class="col-lg-6">
																<asp:textbox ID="txtprojectname" runat="server"   class="form-control"/>
																</div>
																
																</div>
                                                        <br /><br/>
																<%--<div class="form-group">
                                                                    <div class="col-lg-3">
																	<asp:label runat="server">Project Description:</asp:label>
                                                                        </div><br /><br />
																	<asp:TextBox runat="server" ID="txtcomment" TextMode="multiline" class="form-control"></asp:TextBox>
																</div>--%>

                <div class="form-group">
							<div class="col-lg-3">
								<asp:label runat="server" >Project Description:</asp:label>
							</div>
							<div class="col-lg-6">
								<asp:TextBox runat="server" TextMode="MultiLine"   class="form-control" id="txtcomment"  />
								</div>
								
								</div>
               <br />
               <br />
               <br />
               <br />
<br />
               <asp:button runat="server" ID="submit" text="submit" class="btn btn-primary" OnClick="submit_Click" Style="margin-left:350px"></asp:button>
																					
    </div>
     
   

    <div class="col-lg-3">
																<asp:label runat="server" Visible="false">ID:</asp:label>
															</div>
															<div class="col-lg-6">
																<asp:textbox ID="Textbox1" ReadOnly="true"  runat="server" Visible="false"  class="form-control"/>
																</div>
															
																</div><br/><br/>
                                                        <div class="form-group">
															<div class="col-lg-3">
																<asp:label runat="server" Visible="false">Employee ID:</asp:label>
															</div>
															<div class="col-lg-6">

																<asp:textbox ID="empid"  runat="server" Visible="false" ReadOnly="true" class="form-control"/>
																</div>
															
																</div><br/><br/>
                                                         <div class="form-group">
															<div class="col-lg-3">
																<asp:label runat="server" Visible="false" >Employee Name:</asp:label>
															</div>
															<div class="col-lg-6">
																<asp:textbox ID="empname" Visible="false"  runat="server"  ReadOnly="true" class="form-control"/>
																</div>
															
																</div><br/><br/>



</asp:Content>
