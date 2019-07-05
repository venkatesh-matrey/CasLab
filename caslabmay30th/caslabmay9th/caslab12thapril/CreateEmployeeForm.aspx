<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeFile="CreateEmployeeForm.aspx.cs" Inherits="caslab12thapril.CreateEmployeeForm" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <div id="searchmaterail">
        <div class="row">
            <div class="col-md-12">
        
       <div class="col-md-6" >
                                         <h1 style="color:red;">Employee Details</h1>
                                         </div>
                                       
                         
                </div>
            </div>
        </div>
  
      <div class="content-wrapper">
            <!-- Content Header (Page header) -->
           
            <!-- Main content -->
            <div class="content">
               <div class="row">
                  <div class="col-sm-12 col-md-12">
                     <div class="panel panel-bd lobidrag">
                      
                        <div class="panel-body" >

                                	<div  class="table-responsive" style="width:1100px; height:300px; overflow:auto;" >
<div >
   

                                        <asp:GridView ID="GridView1"   runat="server"   class="table table-striped table-bordered" AutoGenerateColumns="False" CellPadding="4"  ForeColor="#333333" GridLines="None" DataSourceID="SqlDataSource1"  >
                                            <Columns>
                                             <asp:TemplateField HeaderText="Select">
                                                 <HeaderTemplate>SELECT ALL:
<br/>
  <asp:RadioButton ID="chkAll" runat="server" />

</HeaderTemplate>
<ItemTemplate>
<%--<input name="RadioButton1" type="radio" value='<%# Eval("id") %>' onclick="javascript.myselection(this.id)" />--%>
  <asp:RadioButton runat="server" ID="RadioButton1"  OnCheckedChanged="RadioButton1_CheckedChanged"  />
</ItemTemplate>
</asp:TemplateField>
                                                 <asp:BoundField DataField="EmpId" HeaderText="E-Code" SortExpression="EmpId" />
                                                <asp:BoundField DataField="EmpName" HeaderText="Name" SortExpression="EmpName" />
                                                <asp:BoundField DataField="dateofjoining" HeaderText="Date Of Joining" SortExpression="dateofjoining" />
                                                <asp:BoundField DataField="lastdateinthecompany" HeaderText="Last Date In The Company" SortExpression="lastdateinthecompany" />
                                                <asp:BoundField DataField="Department" HeaderText="Department" SortExpression="Department" />
                                                <asp:BoundField DataField="address" HeaderText="Address" SortExpression="address" />
                                                <asp:BoundField DataField="Phone" HeaderText="Contact Number" SortExpression="Phone" />
                                                 <asp:BoundField DataField="EmpPosition" HeaderText="Status" SortExpression="Phone" />
                                            </Columns>
                                            <AlternatingRowStyle BackColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#EFF3FB" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                        </asp:GridView>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MatreyPharmaConnectionString %>" SelectCommand="SELECT [id],[EmpId], [EmpName], [dateofjoining], [lastdateinthecompany], [Department], [address], [Phone],[EmpPosition] FROM [AddEmployee]"></asp:SqlDataSource>

																							</div>

  </div><br />

         
                              <div class="modal fade" id="addrawmaterial" tabindex="-1" role="dialog" style="overflow-y:auto" >
                  <div class="modal-dialog">
                     <div class="modal-content">
                        <div class="modal-header modal-header-primary">
                           <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                           <h3><i class="fa fa-plus m-r-5"></i> Add Employee Details </h3>
                        </div>
                        <div class="modal-body">
                           <div class="row">
                              <div class="col-md-12">
                                 <form class="form-horizontal">
                                    <fieldset>
                                       <!-- Text input-->
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">E-Code</asp:label>
                                          <asp:textbox runat="server" ID="empcode" ReadOnly="true"  type="text" class="form-control"/>

                                       </div>
                                      
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Name</asp:label>
                                          <asp:textbox runat="server" ID="name"  ValidationGroup="addrawmaterial"  type="text" placeholder="Name" class="form-control"/>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ValidationGroup="addrawmaterial"  runat="server" ControlToValidate="name" ErrorMessage="This Field Is Requried"></asp:RequiredFieldValidator>

                                       </div>
                                       
                                      
                                      
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Fathers Name </asp:label>
                                            <asp:textbox runat="server" ID="fname" ValidationGroup="addrawmaterial"  type="text" placeholder="Fathers Name" class="form-control"/>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="addrawmaterial" runat="server" ForeColor="Red" ControlToValidate="fname" ErrorMessage="This Field Is Requiried"></asp:RequiredFieldValidator>
                                       
                                          
                                       </div>
                                            <div class="col-md-6  form-group">
                                                
                                          <asp:label runat="server" class="control-label"> Address </asp:label>
                                          <asp:textbox runat="server" ID="address"  type="text" ValidationGroup="addrawmaterial" placeholder="Quantity" class="form-control"/>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" ValidationGroup="addrawmaterial"  runat="server" ErrorMessage="This Field Is Requried" ControlToValidate="address"></asp:RequiredFieldValidator>

                                        
                                          
                                        
                                       </div>
                                            <div class="col-md-6 form-group">
                                         <asp:label runat="server" class="control-label">  Personal Email </asp:label>
                                            <asp:textbox runat="server" ValidationGroup="addrawmaterial" ID="email"  type="text" placeholder="Personal Email" class="form-control"/>
                                           <asp:RequiredFieldValidator ValidationGroup="addrawmaterial" ID="RequiredFieldValidator11" runat="server" ForeColor="Red" ControlToValidate="email" ErrorMessage="This Field Is Requiried"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="validateEmail"    
  runat="server" ErrorMessage="Invalid email." ForeColor="Red"
  ControlToValidate="email" 
  ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" />
                                           
                                                </div>
									    <div class="col-md-6 form-group">
									   
                                 <asp:label runat="server" class="control-label">Phone Number</asp:label>
                                <asp:textbox runat="server" ValidationGroup="addrawmaterial" ID="phnum"  type="number" placeholder="Phone Number" class="form-control"/>
                                           <asp:RequiredFieldValidator ValidationGroup="addrawmaterial" ID="RequiredFieldValidator5" runat="server" ForeColor="Red" ControlToValidate="phnum" ErrorMessage="This Field Is Requiried"></asp:RequiredFieldValidator>
                                       <asp:RegularExpressionValidator ValidationGroup="addrawmaterial" ID="RegularExpressionValidator1" runat="server"  
ControlToValidate="phnum" ErrorMessage="Enter Valid Number" ForeColor="Red"  
ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>  
							  </div>

                                           <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Pan Number</asp:label>
                                           <asp:textbox runat="server" ValidationGroup="addrawmaterial" ID="pan"  type="number" placeholder="Pan Number" class="form-control"/>
                                           <asp:RequiredFieldValidator ValidationGroup="addrawmaterial" ID="RequiredFieldValidator6" runat="server" ForeColor="Red" ControlToValidate="pan" ErrorMessage="This Field Is Requiried"></asp:RequiredFieldValidator>
                                      
                                       </div>
                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Aadhar Number</asp:label>
                                               <asp:textbox runat="server" ValidationGroup="addrawmaterial" ID="aadharnum"  type="number" placeholder="Aadhar Number" class="form-control"/>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ValidationGroup="addrawmaterial" runat="server" ForeColor="Red" ControlToValidate="aadharnum" ErrorMessage="This Field Is Requiried"></asp:RequiredFieldValidator>
                                       
                                          
                                         
                                       </div>
                                    

                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Blood Group</asp:label>
                                           <asp:DropDownList runat="server" ID="bloodgroup" ValidationGroup="addrawmaterial" class="form-control">
                                                 <asp:listitem Text="Select Group" Value=""></asp:listitem>
                                     <asp:ListItem Text="A+ve" ></asp:ListItem>
                                     <asp:ListItem Text="B+ve" ></asp:ListItem>
                                     <asp:ListItem Text="A-ve" ></asp:ListItem>
                                     <asp:ListItem Text="B-ve" ></asp:ListItem>
                                     <asp:ListItem Text="AB-ve" ></asp:ListItem>
                                     <asp:ListItem Text="AB+ve" ></asp:ListItem>
                                     <asp:ListItem Text="O-ve" ></asp:ListItem>
                                     <asp:ListItem Text="O+ve" ></asp:ListItem>

                                             </asp:DropDownList>
                                              <asp:RequiredFieldValidator ValidationGroup="addrawmaterial" ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ControlToValidate="bloodgroup" ErrorMessage="This Field Is Requiried"></asp:RequiredFieldValidator>

                                       </div>

                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Matrial Status</asp:label>
                                           <asp:DropDownList runat="server" ValidationGroup="addrawmaterial" ID="mattrialstatus" class="form-control">
                                                 <asp:listitem Text="select" Value=""></asp:listitem>
                                     <asp:ListItem Text="Single" ></asp:ListItem>
                                     <asp:ListItem Text="Married" ></asp:ListItem>
                                    
                                             </asp:DropDownList>
                                              <asp:RequiredFieldValidator ValidationGroup="addrawmaterial" ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="mattrialstatus" ErrorMessage="This Field Is Requiried"></asp:RequiredFieldValidator>

                                       </div>

                                         <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Department</asp:label>
                                             <asp:DropDownList runat="server" ValidationGroup="addrawmaterial" ID="department" class="form-control">
                                                 <asp:listitem Text="Select Department" Value=""></asp:listitem>
                                     <asp:ListItem Text="Finance" ></asp:ListItem>
                                     <asp:ListItem Text="HR" ></asp:ListItem>
                                     <asp:ListItem Text="IT" ></asp:ListItem>
                                             </asp:DropDownList>
                                           <asp:RequiredFieldValidator ValidationGroup="addrawmaterial" ID="RequiredFieldValidator10" runat="server" ForeColor="Red" ControlToValidate="department" ErrorMessage="This Field Is Requiried"></asp:RequiredFieldValidator>

                                       </div>

                                        <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Gender</asp:label>
                                             <asp:DropDownList ValidationGroup="addrawmaterial" runat="server" ID="gender" class="form-control">
                                                 <asp:listitem Text="Select Gender" Value=""></asp:listitem>
                                     <asp:ListItem Text="Male" ></asp:ListItem>
                                     <asp:ListItem Text="Female" ></asp:ListItem>
                                  
                                             </asp:DropDownList>
                                           <asp:RequiredFieldValidator ValidationGroup="addrawmaterial" ID="RequiredFieldValidator8" runat="server" ForeColor="Red" ControlToValidate="gender" ErrorMessage="This Field Is Requiried"></asp:RequiredFieldValidator>

                                       </div>

                                         <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Photo</asp:label>
                                          <%--<asp:textbox runat="server" ID="txtbatch" type="text"  class="form-control"/>--%>
                                              <asp:FileUpload  ValidationGroup="addrawmaterial" ID="photo" class="form-control" runat="server" />

                                       </div>

                                         <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Date Of Joining</asp:label>
                                          <asp:textbox runat="server" ValidationGroup="addrawmaterial" ID="date"   class="form-control"/>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="addrawmaterial" runat="server" ForeColor="Red" ControlToValidate="date" ErrorMessage="This Field Is Requiried"></asp:RequiredFieldValidator>

                                       </div>

                                        
                                          <%--<div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Last Date In The Company</asp:label>
                                          <asp:textbox runat="server" ValidationGroup="employeedata" ID="lastdate"   class="form-control"/>
                                          <%-- <asp:RequiredFieldValidator ValidationGroup="employeedata" ID="RequiredFieldValidator13" runat="server" ForeColor="Red" ControlToValidate="lastdate" ErrorMessage="This Field Is Requiried"></asp:RequiredFieldValidator>--%>

                                       </>
                                        
                                        
                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Work Location</asp:label>
                                          <asp:textbox runat="server" ValidationGroup="addrawmaterial" ID="WorkLocation"   class="form-control"/>
                                           <asp:RequiredFieldValidator ValidationGroup="addrawmaterial" ID="RequiredFieldValidator14" runat="server" ForeColor="Red" ControlToValidate="WorkLocation" ErrorMessage="This Field Is Requiried"></asp:RequiredFieldValidator>

                                       </div>




                                       <div class="col-md-12 form-group user-form-group">
                                          <div class="pull-right">
                                            
                                            <asp:Button runat="server" ID="Save" class="btn btn-primary" Text="Submit"  ValidationGroup="addrawmaterial" OnClick="Save_Click" />
                                              <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal">Cancel</button>
                                          </div>
                                       </div>
                                  
                                    </fieldset>
                                 </form>
                              </div>
                           </div>
                        </div>
                        <%--<div class="modal-footer">
                           <button type="button" class="btn btn-danger pull-left" data-dismiss="modal">Close</button>
                        </div>--%>
                     </div>
                     <!-- /.modal-content -->
                  </div>
                  <!-- /.modal-dialog -->
               </div>
               <!-- /.modal -->
							
                            
            
         <div class="modal fade" id="addtask" tabindex="-1" role="dialog">
                  <div class="modal-dialog">
                     <div class="modal-content">
                        <div class="modal-header modal-header-primary">
                           <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                           <h3>Warning</h3>
                            <h5>Do You want to add RawMaterial to the list</h5>
                        </div>
                        <div class="modal-body">
                           <div class="row">
                              <div class="col-md-3">
                                 <div class="form-horizontal">
                                    <fieldset>
                                       <!-- Text input-->
                                
                                   
                                          
                                      <div class="col-md-12 form-group user-form-group">
                                          <div class="pull-right">
                                               <button type="button" data-dismiss="modal" class="btn btn-primary">Cancel</button>
                                            
                                          </div>
                                       </div>
                                        <div class="col-md-12 form-group user-form-group">
                                          <div class="pull-right">
                                                
                                            <button type="button" class="btn btn-primary" data-toggle="modal" data-dismiss="modal"  data-target="#addrawmaterial"><i class="fa fa-file-plus"></i> Add </button>

                                              </div>
                                        </div>
                                        
                                    </fieldset>
                                 </div>
                              </div>
                           </div>
                        </div>
                        
                     </div>
                     <!-- /.modal-content -->
                  </div>
                  <!-- /.modal-dialog -->
               </div>
               <!-- /.modal -->


                                   <div class="modal fade" id="listofrawmaterialedit" tabindex="-1" role="dialog">
                  <div class="modal-dialog">
                     <div class="modal-content">
                        <div class="modal-header modal-header-primary">
                           <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                            <div class="row">
                                <div class="col-md-8">
                           <h3><i class="fa fa-plus m-r-5"></i> Edit Employee Details </h3></div>
                                
                                 <div class="col-md-4">
                            <asp:image id="picture" runat="server"  Height="100" Width="100"/><br /><br />
                                </div>
                                </div>
                        </div>
                        <div class="modal-body">
                           <div class="row">
                              <div class="col-md-12">
                                 <div class="form-horizontal">
                                    <fieldset>
                                       <!-- Text input-->
                                       
                                        
                                   <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">E-Code</asp:label>
                                          <asp:textbox runat="server" ID="Textbox1" ReadOnly="true"  type="text" class="form-control"/>

                                       </div>
                                      
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Name</asp:label>
                                          <asp:textbox runat="server" ID="Textbox2"  ValidationGroup="listofrawmaterialedit"  type="text" placeholder="Name" class="form-control"/>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ForeColor="Red" ValidationGroup="listofrawmaterialedit"  runat="server" ControlToValidate="Textbox2" ErrorMessage="This Field Is Requried"></asp:RequiredFieldValidator>

                                       </div>
                                       
                                      
                                      
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Fathers Name </asp:label>
                                            <asp:textbox runat="server" ID="Textbox3" ValidationGroup="listofrawmaterialedit"  type="text" placeholder="Fathers Name" class="form-control"/>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ValidationGroup="listofrawmaterialedit" runat="server" ForeColor="Red" ControlToValidate="Textbox3" ErrorMessage="This Field Is Requiried"></asp:RequiredFieldValidator>
                                       
                                          
                                       </div>
                                            <div class="col-md-6  form-group">
                                                
                                          <asp:label runat="server" class="control-label"> Address </asp:label>
                                          <asp:textbox runat="server" ID="Textbox4"  type="text" ValidationGroup="listofrawmaterialedit" placeholder="Address" class="form-control"/>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ForeColor="Red" ValidationGroup="listofrawmaterialedit"  runat="server" ErrorMessage="This Field Is Requried" ControlToValidate="Textbox4"></asp:RequiredFieldValidator>

                                        
                                          
                                        
                                       </div>
                                            <div class="col-md-6 form-group">
                                         <asp:label runat="server" class="control-label">  Personal Email </asp:label>
                                            <asp:textbox runat="server" ValidationGroup="listofrawmaterialedit" ID="Textbox5"  type="text" placeholder="Personal Email" class="form-control"/>
                                           <asp:RequiredFieldValidator ValidationGroup="listofrawmaterialedit" ID="RequiredFieldValidator17" runat="server" ForeColor="Red" ControlToValidate="Textbox5" ErrorMessage="This Field Is Requiried"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2"    
  runat="server" ErrorMessage="Invalid email." ForeColor="Red"
  ControlToValidate="email" 
  ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" />
                                           
                                                </div>
									    <div class="col-md-6 form-group">
									   
                                 <asp:label runat="server" class="control-label">Phone Number</asp:label>
                                <asp:textbox runat="server" ValidationGroup="listofrawmaterialedit" ID="Textbox6"  type="number" placeholder="Phone Number" class="form-control"/>
                                           <asp:RequiredFieldValidator ValidationGroup="listofrawmaterialedit" ID="RequiredFieldValidator18" runat="server" ForeColor="Red" ControlToValidate="Textbox6" ErrorMessage="This Field Is Requiried"></asp:RequiredFieldValidator>
                                       <asp:RegularExpressionValidator ValidationGroup="listofrawmaterialedit" ID="RegularExpressionValidator3" runat="server"  
ControlToValidate="phnum" ErrorMessage="Enter Valid Number" ForeColor="Red"  
ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>  
							  </div>

                                           <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Pan Number</asp:label>
                                           <asp:textbox runat="server" ValidationGroup="listofrawmaterialedit" ID="Textbox7"  type="number" placeholder="Pan Number" class="form-control"/>
                                           <asp:RequiredFieldValidator ValidationGroup="listofrawmaterialedit" ID="RequiredFieldValidator19" runat="server" ForeColor="Red" ControlToValidate="Textbox7" ErrorMessage="This Field Is Requiried"></asp:RequiredFieldValidator>
                                      
                                       </div>
                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Aadhar Number</asp:label>
                                               <asp:textbox runat="server" ValidationGroup="listofrawmaterialedit" ID="Textbox8"  type="number" placeholder="Aadhar Number" class="form-control"/>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator20" ValidationGroup="listofrawmaterialedit" runat="server" ForeColor="Red" ControlToValidate="Textbox8" ErrorMessage="This Field Is Requiried"></asp:RequiredFieldValidator>
                                       
                                          
                                         
                                       </div>
                                    

                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Blood Group</asp:label>
                                           <asp:DropDownList runat="server" ID="DropDownList1" ValidationGroup="listofrawmaterialedit" class="form-control">
                                                 <asp:listitem Text="Select Group" Value=""></asp:listitem>
                                     <asp:ListItem Text="A+ve" ></asp:ListItem>
                                     <asp:ListItem Text="B+ve" ></asp:ListItem>
                                     <asp:ListItem Text="A-ve" ></asp:ListItem>
                                     <asp:ListItem Text="B-ve" ></asp:ListItem>
                                     <asp:ListItem Text="AB-ve" ></asp:ListItem>
                                     <asp:ListItem Text="AB+ve" ></asp:ListItem>
                                     <asp:ListItem Text="O-ve" ></asp:ListItem>
                                     <asp:ListItem Text="O+ve" ></asp:ListItem>

                                             </asp:DropDownList>
                                              <asp:RequiredFieldValidator ValidationGroup="listofrawmaterialedit" ID="RequiredFieldValidator21" runat="server" ForeColor="Red" ControlToValidate="DropDownList1" ErrorMessage="This Field Is Requiried"></asp:RequiredFieldValidator>

                                       </div>

                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Matrial Status</asp:label>
                                           <asp:DropDownList runat="server" ValidationGroup="listofrawmaterialedit" ID="DropDownList2" class="form-control">
                                                 <asp:listitem Text="select" Value=""></asp:listitem>
                                     <asp:ListItem Text="Single" ></asp:ListItem>
                                     <asp:ListItem Text="Married" ></asp:ListItem>
                                    
                                             </asp:DropDownList>
                                              <asp:RequiredFieldValidator ValidationGroup="listofrawmaterialedit" ID="RequiredFieldValidator22" runat="server" ForeColor="Red" ControlToValidate="DropDownList2" ErrorMessage="This Field Is Requiried"></asp:RequiredFieldValidator>

                                       </div>

                                         <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Department</asp:label>
                                             <asp:DropDownList runat="server" ValidationGroup="listofrawmaterialedit" ID="DropDownList3" class="form-control">
                                                 <asp:listitem Text="Select Department" Value=""></asp:listitem>
                                     <asp:ListItem Text="Finance" ></asp:ListItem>
                                     <asp:ListItem Text="HR" ></asp:ListItem>
                                     <asp:ListItem Text="IT" ></asp:ListItem>
                                             </asp:DropDownList>
                                           <asp:RequiredFieldValidator ValidationGroup="listofrawmaterialedit" ID="RequiredFieldValidator23" runat="server" ForeColor="Red" ControlToValidate="DropDownList3" ErrorMessage="This Field Is Requiried"></asp:RequiredFieldValidator>

                                       </div>

                                        <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Gender</asp:label>
                                             <asp:DropDownList ValidationGroup="listofrawmaterialedit" runat="server" ID="DropDownList4" class="form-control">
                                                 <asp:listitem Text="Select Gender" Value=""></asp:listitem>
                                     <asp:ListItem Text="Male" ></asp:ListItem>
                                     <asp:ListItem Text="Female" ></asp:ListItem>
                                  
                                             </asp:DropDownList>
                                           <asp:RequiredFieldValidator ValidationGroup="listofrawmaterialedit" ID="RequiredFieldValidator24" runat="server" ForeColor="Red" ControlToValidate="DropDownList4" ErrorMessage="This Field Is Requiried"></asp:RequiredFieldValidator>

                                       </div>

                                       <%--  <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Photo</asp:label>
                                          <%--<asp:textbox runat="server" ID="txtbatch" type="text"  class="form-control"/>--%>
                                             <%-- <asp:FileUpload  ValidationGroup="listofrawmaterialedit" ID="FileUpload1" class="form-control" runat="server" />

                                       </div>--%>

                                         <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Date Of Joining</asp:label>
                                          <asp:textbox runat="server" ValidationGroup="listofrawmaterialedit" ID="Textbox9"   class="form-control"/>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator25" ValidationGroup="listofrawmaterialedit" runat="server" ForeColor="Red" ControlToValidate="Textbox9" ErrorMessage="This Field Is Requiried"></asp:RequiredFieldValidator>

                                       </div>

                                        
                                          <%--<div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Last Date In The Company</asp:label>
                                          <asp:textbox runat="server" ValidationGroup="employeedata" ID="lastdate"   class="form-control"/>
                                          <%-- <asp:RequiredFieldValidator ValidationGroup="employeedata" ID="RequiredFieldValidator13" runat="server" ForeColor="Red" ControlToValidate="lastdate" ErrorMessage="This Field Is Requiried"></asp:RequiredFieldValidator>--%>

                                       </>
                                        
                                        
                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Work Location</asp:label>
                                          <asp:textbox runat="server" ValidationGroup="listofrawmaterialedit" ID="Textbox10"   class="form-control"/>
                                           <asp:RequiredFieldValidator ValidationGroup="listofrawmaterialedit" ID="RequiredFieldValidator26" runat="server" ForeColor="Red" ControlToValidate="Textbox10" ErrorMessage="This Field Is Requiried"></asp:RequiredFieldValidator>

                                       </div>
                                       <div class="col-md-12 form-group user-form-group">
                                          <div class="pull-right">
                                             <asp:Button runat="server" ID="EditButton" class="btn btn-primary" ValidationGroup="listofrawmaterialedit" Text="Edit" OnClick="EditButton_Click"  CausesValidation="false"  />
                                               
                                            
                                          </div>
                                       </div>
                                    </fieldset>
                                 </div>
                              </div>
                           </div>
                        </div>
                        
                     </div>
                     <!-- /.modal-content -->
                  </div>
                  <!-- /.modal-dialog -->
               </div>
               <!-- /.modal -->
							


                           <div class="modal fade" id="edit" tabindex="-1" role="dialog">
                  <div class="modal-dialog">
                     <div class="modal-content">
                        <div class="modal-header modal-header-primary">
                           <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                           <h3>Warning</h3>
                            <h5>Do You want to Edit EmployeeDetails to the list</h5>
                        </div>
                        <div class="modal-body">
                           <div class="row">
                              <div class="col-md-3">
                                 <div class="form-horizontal">
                                    <fieldset>
                                       <!-- Text input-->
                                
                                          
                                       <div class="col-md-12 form-group user-form-group">
                                          <div class="pull-right">
                                               <button type="button" data-dismiss="modal" class="btn btn-danger btn-sm">Cancel</button>
                                            <button type="button" class="btn btn-primary"  data-toggle="modal" data-dismiss="modal"  data-target="#edit"><i class="fa fa-file-plus"></i> Submit </button>
                                           
                                            

                                           <%-- <button type="button" class="btn btn-primary"  data-toggle="modal" data-dismiss="modal"  data-target="#listofrawmaterialedit"><i class="fa fa-file-plus"></i> Edit </button>--%>

                                          </div>
                                       </div>
                                    </fieldset>
                                 </div>
                              </div>
                           </div>
                        </div>
                        
                     </div>
                     <!-- /.modal-content -->
                  </div>
                  <!-- /.modal-dialog -->
               </div>
               <!-- /.modal -->



                              <div class="modal fade" id="deleteramaterial" tabindex="-1" role="dialog">
                  <div class="modal-dialog">
                     <div class="modal-content">
                        <div class="modal-header modal-header-primary">
                           <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                           <h3><i class="fa fa-plus m-r-5"></i>Employee Resigned Form</h3>
                        </div>
                        <div class="modal-body">
                           <div class="row">
                              <div class="col-md-12">
                                 <form class="form-horizontal">
                                    <fieldset>
                                       <!-- Text input-->
                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">E-Code</asp:label>
                                          <asp:textbox runat="server" ID="codedelete" ReadOnly="true" ValidationGroup="deleteramaterial"    class="form-control"/>
                                       </div>
                                      
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label"> Name</asp:label>
                                          <asp:textbox runat="server" ID="namedelete" ReadOnly="true"  ValidationGroup="deleteramaterial"  class="form-control"/>
                                       </div>
                                       
                                      
                                      
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Date of joining </asp:label>
                                           <asp:textbox runat="server" ID="materialdelete" ReadOnly="true" ValidationGroup="deleteramaterial"   class="form-control"/>
                                       </div>
                                            <div class="col-md-6 form-group">
                                                
                                          <asp:label runat="server" class="control-label"> Last date in the company </asp:label>
                                          <asp:textbox runat="server" ID="quandelete" ReadOnly="true" ValidationGroup="deleteramaterial"   class="form-control"/>
                                        
                                          
                                        
                                       </div>
									   <div class="col-md-6 form-group">
                                                
                                          <asp:label runat="server" class="control-label">   Department </asp:label>
                                          <asp:textbox runat="server" ID="unitsdelete" ReadOnly="true" ValidationGroup="deleteramaterial"   class="form-control"/>
                                        
                                          
                                        
                                       </div>
                                            

                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label"> Address</asp:label>
                                          <asp:textbox runat="server" ID="documentdelete" type="text" ValidationGroup="deleteramaterial" ReadOnly="true"   class="form-control"/>
                                       </div>

                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Contact number</asp:label>
                                          <asp:textbox runat="server" ID="datedelete" type="text"  ValidationGroup="deleteramaterial"  class="form-control"/>
                                       </div>


                                         <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Risgned Date</asp:label>
                                          <asp:textbox runat="server" ID="reasondelete" type="text"  ValidationGroup="deleteramaterial"  class="form-control"/>
                                       </div>






                                       <div class="col-md-12 form-group user-form-group">
                                          <div class="pull-right">
                                           
                                            <button type="button" class="btn btn-primary"  data-toggle="modal" data-dismiss="modal"  data-target="#deleterow"><i class="fa fa-file-plus"></i> Delete </button>


                                          </div>
                                       </div>
                                    </fieldset>
                                 </form>
                              </div>
                           </div>
                        </div>
                       
                     </div>
                     <!-- /.modal-content -->
                  </div>
                  <!-- /.modal-dialog -->
               </div>
               <!-- /.modal -->


                          
                           
							



                             <div class="modal fade" id="deleterow" tabindex="-1" role="dialog">
                  <div class="modal-dialog">
                     <div class="modal-content">
                        <div class="modal-header modal-header-primary">
                           <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                           <h3>Warning</h3>
                            <h5>Do You want to Resigned</h5>
                        </div>
                        <div class="modal-body">
                           <div class="row">
                              <div class="col-md-3">
                                 <div class="form-horizontal">
                                    <fieldset>
                                       <!-- Text input-->
                                
                                   
                                          
                                       <div class="col-md-12 form-group user-form-group">
                                          <div class="pull-right">
                                               <button type="button" data-dismiss="modal" class="btn btn-danger btn-sm">Cancel</button>
                                    <asp:Button runat="server" ID="Delete" Text="YES" class="btn btn-primary" OnClick="Delete_Click" ValidationGroup="deleteramaterial" CausesValidation="false" />
                                              

                                          </div>
                                       </div>
                                    </fieldset>
                                 </div>
                              </div>
                           </div>
                        </div>
                        
                     </div>
                     <!-- /.modal-content -->
                  </div>
                  <!-- /.modal-dialog -->
               </div>
               <!-- /.modal -->
							  		  	  
			


                            
                           


          <div class="buttonexport" id="buttons">
                                 
                             <%--<asp:Button ID="Button2" runat="server" Text="Edit" class="fa fa-file-text" CausesValidation="false" OnClick="Button2_Click"  />--%>

             <%--   <a href="#" class="btn btn-add" data-toggle="modal" data-target="#edit"><i class="fa fa-file-text"></i> Edit </a> --%>
               <asp:Button runat="server" ID="editpopup" class="btn btn-primary" ValidationGroup="buttons" Text="Edit" data-toggle="modal" OnClick="editpopup_Click" data-target="#listofrawmaterialedit" />
              <asp:Button runat="server" Text="Export" ID="exporttoexcel" class="btn btn-primary" OnClick="exporttoexcel_Click" ValidationGroup="buttons" CausesValidation="false" />
                             <%--  <a href="#" class="btn btn-add" data-toggle="modal" data-target="#"><i class="fa fa-file-text"></i> Export </a> --%>
                             <%--  <a href="#" class="btn btn-add" data-toggle="modal" data-target="#"><i class="fa fa-file-text"></i> Disable/Enable </a>--%> 

<%--     <asp:Button runat="server" ID="enablepopup" ValidationGroup="buttons" class="btn btn-primary" CausesValidation="false"  Text="Enable" data-toggle="modal"  data-target="#enableramaterial" OnClick="enablepopup_Click"/>

                 <asp:Button runat="server" ID="disablepopup" ValidationGroup="buttons" class="btn btn-primary" CausesValidation="false"  Text="Disable" data-toggle="modal"  data-target="#disableramaterial" OnClick="disablepopup_Click"/>
--%>

                              <%-- <a href="#" class="btn btn-add" data-toggle="modal" data-target="#Replace"><i class="fa fa-file-text"></i> Replace </a> --%>
                                            <%--<button type="button" class="btn btn-primary"  data-toggle="modal" data-dismiss="modal"  data-target="#Replace"><i class="fa fa-file-plus"></i> Replace </button>--%>

                         
               <asp:Button runat="server" ID="popupdelete" ValidationGroup="buttons" class="btn btn-primary" CausesValidation="false"  Text="Resigned" data-toggle="modal"  data-target="#deleteramaterial" OnClick="popupdelete_Click" />

                                            <button type="button" class="btn btn-primary"  data-toggle="modal" data-dismiss="modal"  data-target="#addtask"><i class="fa fa-file-plus"></i> Add </button>
								
                              </div>
                     
                     </div>
                  </div>
               </div>
            </div>
            <!-- /.content -->
         </div>
         <!-- /.content-wrapper -->
                                        </div>

  <%--<script language="javascript" type="text/javascript">
        function myselection(rbtnid) {
            var rbtn = document.getElementById(rbtnid);
            var rbtnlist = document.getElementsByTagName("input");
            for (i = 0; i < rbtnlist.length; i++) {
                if (rbtnlist[i].text == "radio" && rbtnlist[i].id != rbtn.id) {
                    rbtnlist[i].checked = false;
                    

                }
            }
        }
    </script>

    <script type="text/javascript">  
            function CheckOtherIsCheckedByGVID(spanChk) {  
                var IsChecked = spanChk.checked;  
                if (IsChecked) {                   
                    //spanChk.parentElement.parentElement.style.backgroundColor = '';  
                   // spanChk.parentElement.parentElement.style.color = 'white';  
                }  
                var CurrentRdbID = spanChk.id;  
                var Chk = spanChk;  
                Parent = document.getElementById("<%=GridView1.ClientID%>");  
                var items = Parent.getElementsByTagName('input');  
                for (i = 0; i < items.length; i++) {  
                    if (items[i].id != CurrentRdbID && items[i].type == "radio") {  
                        if (items[i].checked) {  
                            items[i].checked = false;
                            items[i].parentElement.parentElement.style.backgroundColor = 'white'   
                            items[i].parentElement.parentElement.style.color = 'black';  
                        }  
                    }  
                }  
            }  
</script>--%>  


</asp:Content>
