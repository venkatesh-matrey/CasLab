<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeFile="CreateTask.aspx.cs" Inherits="caslab12thapril.CreateTask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script> --%>



    <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>  	
	
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>

    
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="buttonexport">
         <%-- <asp:textbox ID="Textbox2" ReadOnly="true"  runat="server"  class="form-control"/>--%>
        
                           
                                                  <div class="form-group">
															
								
                            <div class="form-group">
							<div class="col-lg-3">
								<asp:label runat="server" Visible="false" >Employee Name:</asp:label>
							</div>
							<div class="col-lg-3">
								<asp:TextBox runat="server" ReadOnly="true"   class="form-control" id="empname"  />
								</div>
								<div class="col-lg-3"></div>
								</div><br/><br/>
                            <div class="form-group">
                            <div class="col-lg-3">
								<asp:label runat="server" >Project ID:</asp:label>
							</div>
							<div class="col-lg-3">
							
                                <asp:DropDownList runat="server" ID="Projectid" class="form-control" AppendDataBoundItems="true" AutoPostBack="true">

                                </asp:DropDownList>
                                	
								</div>
                                <div class="col-lg-3"></div>
								
								</div>
                                                      </div><br/><br/>
						<div class="form-group">
                            <div class="row">
							<div class="col-lg-3">
								<asp:label runat="server" >Task ID:</asp:label>
							</div>
							<div class="col-lg-3">
								<asp:TextBox runat="server" ReadOnly="true"   class="form-control" id="Taskid" />
								</div>
                            <div class="col-lg-3"></div>
								
								</div>
                            </div><br/><br/>
                       
                        	
                            
								<div class="form-group">
                                    <div class="row">
                                    <div class="col-lg-3">
									<asp:label runat="server" >Task Description:</asp:label>
                                        </div>
                                    <div class="col-lg-3">
								<asp:TextBox runat="server" ID="TaskDescription" TextMode="multiline" columns="60" style='text-transform:uppercase' Rows="3"></asp:TextBox>
								</div>
                                   <div class="col-lg-3"></div>
                                    </div>
                                    </div>
                                                    
                                                      <br/><br/>

         

       
         <div class="form-group" style="margin-left:290px" >
            <asp:GridView ID="GridView2" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDataBound="GridView2_RowDataBound"  ShowGridLines="False"  BorderStyle="None">
                 <Columns>
                     <asp:BoundField DataField="RowNumber" HeaderText="Row Number"  Visible="false"/>
                     
                     <asp:TemplateField HeaderText="Chemicals">
                         <ItemTemplate>
                             <%--<asp:Label ID="lblchemical" runat="server" Text='<%# Eval("Chemical") %>' Visible = "false" />--%>
                         <asp:DropDownList ID="chemical" runat="server"></asp:DropDownList>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField  HeaderText="Quantity">
                         <ItemTemplate>
                             <asp:TextBox  style="margin-left:5px" ID="qun" runat="server"></asp:TextBox>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Units">
                         <ItemTemplate>
                             <asp:DropDownList  style="margin-left:5px" ID="units" runat="server">
                                 <asp:listitem text="units" value="1"></asp:listitem>
     <asp:listitem text="MilliLiters" value="2"></asp:listitem>
     <asp:listitem text="Micro liters" value="3"></asp:listitem>
     <asp:listitem text="Grams" value="4"></asp:listitem>
     <asp:listitem text="milliGrams" value="5"></asp:listitem>
                                 <asp:listitem text="Liters" value="5"></asp:listitem>
                             </asp:DropDownList>
                         </ItemTemplate>
                         <FooterStyle HorizontalAlign="Right" />
                         <FooterTemplate>
                             <asp:Button ID="btnadd" runat="server" OnClick="btnadd_Click"  class="btn btn-primary" Text="+"></asp:Button>
                         </FooterTemplate>
                     </asp:TemplateField>
                 </Columns>
             </asp:GridView>

       


           



         </div>
         <br />

              <div class="form-group">
         <asp:Button ID="Button1" runat="server"  style="margin-left:460px" Text="Submit"  class="btn btn-primary" OnClick="Button1_Click" />
                  </div>
    <div class="form-group">
                                    <div class="col-lg-3">
																<asp:label runat="server" Visible="false" >ID:</asp:label>
															</div>
															<div class="col-lg-3">
																<asp:textbox ID="Textbox1" ReadOnly="true" Visible="false"  runat="server"  class="form-control"/>
																</div>
															<div class="col-lg-3"></div>
																</div><br/><br/>
                            	<div class="form-group">
							<div class="col-lg-3">
								<asp:label runat="server" Visible="false" >Employee ID:</asp:label>
							</div>
							<div class="col-lg-6">
								<asp:TextBox runat="server" ReadOnly="true" visible="false"  class="form-control" id="empid"  />
								</div>
                                    </div>
								
             
					                                      
                                        
								
						
											<br/>
												
										
									

</asp:Content>
