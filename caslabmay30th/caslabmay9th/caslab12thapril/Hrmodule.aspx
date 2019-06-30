<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Hrmodule.aspx.cs" EnableEventValidation="false" Inherits="caslab12thapril.Hrmodule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
   <h1 style="color:red;">Employee Form</h1>
    
      <div class="content-wrapper">
            <!-- Content Header (Page header) -->
           
            <!-- Main content -->
            <div class="content">
               <div class="row">
                  <div class="col-sm-12 col-md-12">
                     <div class="panel panel-bd lobidrag">
                      
                        <div class="panel-body" >

                            <%--  <div class="table-responsive">--%>
                                	<div  class="table-responsive" >



                                        <br />
                                        
                                        <asp:GridView ID="GridView1" class="table table-striped table-bordered" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnPageIndexChanging = "OnPaging">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                 <asp:TemplateField HeaderText="Select">
<ItemTemplate>

  <asp:RadioButton runat="server" id="RadioButton1" OnCheckedChanged="RadioButton1_CheckedChanged" onclick="javascript:CheckOtherIsCheckedByGVID(this);" />
</ItemTemplate>
</asp:TemplateField>
                                                <asp:BoundField DataField="EmpId" HeaderText="EmpId" SortExpression="EmpId" />
                                                <asp:BoundField DataField="EmpName" HeaderText="EmpName" SortExpression="EmpName" />
                                                <asp:BoundField DataField="dateofjoining" HeaderText="dateofjoining" SortExpression="dateofjoining" />
                                                <asp:BoundField DataField="lastdateinthecompany" HeaderText="lastdateinthecompany" SortExpression="lastdateinthecompany" />
                                                <asp:BoundField DataField="Department" HeaderText="Department" SortExpression="Department" />
                                                <asp:BoundField DataField="address" HeaderText="address" SortExpression="address" />
                                                <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                                            </Columns>
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
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MatreyPharmaConnectionString %>" SelectCommand="SELECT [EmpId], [EmpName], [dateofjoining], [lastdateinthecompany], [Department], [address], [Phone] FROM [AddEmployee]"></asp:SqlDataSource>


  </div><br />

         
                              <div class="modal fade" id="addrawmaterial" tabindex="-1" role="dialog">
                  <div class="modal-dialog">
                     <div class="modal-content">
                        <div class="modal-header modal-header-primary">
                           <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                           <h3><i class="fa fa-plus m-r-5"></i> Add Employee </h3>
                        </div>
                        <div class="modal-body">
                           <div class="row">
                              <div class="col-md-12">
                                 <form class="form-horizontal">
                                    <fieldset>
                                       <!-- Text input-->
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Employee Code</asp:label>
                                          <asp:textbox runat="server" ID="empcode" ReadOnly="true" class="form-control"/>
                                       </div>
                                      
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Name</asp:label>
                                          <asp:textbox runat="server" ID="name"  type="text" placeholder="Name" class="form-control"/>
                                       </div>
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Fathers Name</asp:label>
                                          <asp:textbox runat="server" ID="fname"  type="text" placeholder="Fathers Name" class="form-control"/>
                                       </div>
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Address</asp:label>
                                          <asp:textbox runat="server" ID="address"  type="text" placeholder="Address" class="form-control"/>
                                       </div>
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Personal Email</asp:label>
                                          <asp:textbox runat="server" ID="email"  type="text" placeholder="Personal Email" class="form-control"/>
                                       </div>
                                         <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Phone Number</asp:label>
                                          <asp:textbox runat="server" ID="phnum"  type="text" placeholder="Phone Number" class="form-control"/>
                                       </div>
                                         <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Pan Number</asp:label>
                                          <asp:textbox runat="server" ID="pan"  type="text" placeholder="Pan Number" class="form-control"/>
                                       </div>
                                         <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Aadhar Number</asp:label>
                                          <asp:textbox runat="server" ID="aadharnum"  type="text" placeholder="Aadhar Number" class="form-control"/>
                                       </div>
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Blood Group </asp:label>
                                             <asp:DropDownList runat="server" ID="bloodgroup" class="form-control">
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
                                       </div>
                                         <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Mattrial Status </asp:label>
                                             <asp:DropDownList runat="server" ID="mattrialstatus" class="form-control">
                                                 <asp:listitem Text="select" Value=""></asp:listitem>
                                     <asp:ListItem Text="Single" ></asp:ListItem>
                                     <asp:ListItem Text="Married" ></asp:ListItem>
                                    
                                             </asp:DropDownList>
                                       </div> <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Department</asp:label>
                                             <asp:DropDownList runat="server" ID="department" class="form-control">
                                                 <asp:listitem Text="Select Department" Value=""></asp:listitem>
                                     <asp:ListItem Text="Finance" ></asp:ListItem>
                                     <asp:ListItem Text="HR" ></asp:ListItem>
                                     <asp:ListItem Text="IT" ></asp:ListItem>
                                             </asp:DropDownList>
                                       </div>
                                         <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Gender</asp:label>
                                             <asp:DropDownList runat="server" ID="gender" class="form-control">
                                                 <asp:listitem Text="Select Gender" Value=""></asp:listitem>
                                     <asp:ListItem Text="Male" ></asp:ListItem>
                                     <asp:ListItem Text="Female" ></asp:ListItem>
                                  
                                             </asp:DropDownList>
                                       </div>
                                         
                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Photo</asp:label>
                                          <%--<asp:textbox runat="server" ID="txtbatch" type="text"  class="form-control"/>--%>
                                              <asp:FileUpload ID="photo" class="form-control" runat="server" />

                                       </div>

                                        
                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Date Of Joining</asp:label>
                                          <asp:textbox runat="server" ID="date"   class="form-control"/>

                                       </div>

                                        
                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Last Date In The Company</asp:label>
                                          <asp:textbox runat="server" ID="lastdate"   class="form-control"/>

                                       </div>
                                        
                                        
                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Work Location</asp:label>
                                          <asp:textbox runat="server" ID="WorkLocation"   class="form-control"/>

                                       </div>



                                       <div class="col-md-12 form-group user-form-group">
                                          <div class="pull-right">
                                             
                                            <asp:Button runat="server" ID="Submit" Text="Submit" OnClick="Submit_Click" CausesValidation="false"  class="btn btn-primary"  />
                                             
                                            
                                          </div>

                                           <div class="pull-left">
                                             
                                               <button type="button" class="btn btn-danger pull-left" data-dismiss="modal">Close</button>
                                            
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
							
                            
            
         <div class="modal fade" id="addtask" tabindex="-1" role="dialog">
                  <div class="modal-dialog">
                     <div class="modal-content">
                        <div class="modal-header modal-header-primary">
                           <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                           <h3>Warning</h3>
                            <h5>Do You want to add Employee to the company</h5>
                        </div>
                        <div class="modal-body">
                           <div class="row">
                              <div class="col-md-3">
                                 <div class="form-horizontal">
                                    <fieldset>
                                       <!-- Text input-->
                                
                                   
                                          
                                       <div class="col-md-12 form-group user-form-group">
                                          <div class="pull-left">
                                              
                                            <button type="button" class="btn btn-primary"  data-toggle="modal" data-dismiss="modal"  data-target="#addrawmaterial"><i class="fa fa-file-plus"></i> Add </button>

                                          </div>
                                            <div class="pull-right">

                                               <button type="button" data-dismiss="modal" class="btn btn-danger pull-right">Cancel</button>

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


                            
                              <div class="modal fade" id="employeedetailsedit" tabindex="-1" role="dialog">
                  <div class="modal-dialog">
                     <div class="modal-content">
                        <div class="modal-header modal-header-primary">
                           <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                           <h3><i class="fa fa-plus m-r-5"></i> Edit EmployeeDetails </h3>
                        </div>
                        <div class="modal-body">
                           <div class="row">
                              <div class="col-md-12">
                                 <div class="form-horizontal">
                                    <fieldset>
                                       <!-- Text input-->
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Employee Code</asp:label>
                                          <asp:textbox runat="server" ID="editempid" ValidationGroup="employeedetailsedit" ReadOnly="true" class="form-control"/>
                                       </div>
                                      
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Name</asp:label>
                                          <asp:textbox runat="server" ID="editname" ValidationGroup="employeedetailsedit" type="text" placeholder="Name" class="form-control"/>
                                       </div>

                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Address</asp:label>
                                          <asp:textbox runat="server" ID="editaddress" ValidationGroup="employeedetailsedit"  type="text" placeholder="Address" class="form-control"/>
                                       </div>
                                       
                                         <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Phone Number</asp:label>
                                          <asp:textbox runat="server" ID="editphone" ValidationGroup="employeedetailsedit" type="text" placeholder="Phone Number" class="form-control"/>
                                       </div>
                                         <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Department</asp:label>
                                          <asp:textbox runat="server" ID="editdepartment" ValidationGroup="employeedetailsedit" type="text" placeholder="Pan Number" class="form-control"/>
                                       </div>
                                        
                                      

                                        
                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Date Of Joining</asp:label>
                                          <asp:textbox runat="server" ID="editdate" ValidationGroup="employeedetailsedit"  class="form-control"/>

                                       </div>

                                        
                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Last Date In The Company</asp:label>
                                          <asp:textbox runat="server" ID="editlastdate" ValidationGroup="employeedetailsedit"  class="form-control"/>

                                       </div>
                                        
                                        
                                          



                                       <div class="col-md-12 form-group user-form-group">
                                          <div class="pull-right">
                                             
                                          <%--  <asp:Button runat="server" ID="Button1" Text="Submit" OnClick="Submit_Click" CausesValidation="false"  class="btn btn-primary"  />
                                             --%>
                                              <button type="button" class="btn btn-primary"  data-toggle="modal" data-dismiss="modal"  data-target="#editempid"><i class="fa fa-file-plus"></i> Edit </button>

                                          </div>

                                           <div class="pull-left">
                                             
                                               <button type="button" class="btn btn-danger pull-left" data-dismiss="modal">Close</button>
                                            
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

     <div class="modal fade" id="Editrow" tabindex="-1" role="dialog">
                  <div class="modal-dialog">
                     <div class="modal-content">
                        <div class="modal-header modal-header-primary">
                           <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                           <h3>Warning</h3>
                            <h5>Do You want to Edit EmployeeDetails From list</h5>
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
                                              <asp:Button runat="server" ID="Button2" Text="Update" class="btn btn-danger btn-sm" ValidationGroup="employeedetailsedit" />
                                  <%-- <asp:Button runat="server" ID="deletebtn" Text="delete" OnClick="deletebtn_Click" class="btn btn-danger btn-sm" />
                                              <asp:LinkButton ID="lnkDelete" Text="Delete"   runat="server"  class="btn btn-danger btn-sm" Onclick="lnkDelete_Click"/>
                                              --%>

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
                            <%-- <div class="modal fade" id="deleterow" tabindex="-1" role="dialog">
                  <div class="modal-dialog">
                     <div class="modal-content">
                        <div class="modal-header modal-header-primary">
                           <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                           <h3>Warning</h3>
                            <h5>Do You want to Delete RawMaterial From list</h5>
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
                                              <asp:Button runat="server" ID="delete" Text="delete" OnClick="delete_Click" class="btn btn-danger btn-sm" causesValidation="false" />
                                  <%-- <asp:Button runat="server" ID="deletebtn" Text="delete" OnClick="deletebtn_Click" class="btn btn-danger btn-sm" />
                                              <asp:LinkButton ID="lnkDelete" Text="Delete"   runat="server"  class="btn btn-danger btn-sm" Onclick="lnkDelete_Click"/>
                                              

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
               </div>--%>
               <!-- /.modal -->
							  		  	  
							  



          <div class="buttonexport" id="employeebuttons">
                                 
                             <%--<asp:Button ID="Button2" runat="server" Text="Edit" class="fa fa-file-text" CausesValidation="false" OnClick="Button2_Click"  />--%>
              <asp:Button ID="excel" runat="server" Text="Export" class="fa fa-file-text" CausesValidation="false" OnClick="excel_Click" />
                <%--<a href="#" class="btn btn-add" data-toggle="modal" data-target="#Editrow"><i class="fa fa-file-text"></i> Export </a> --%>
              <asp:Button runat="server" ID="employeeeditpopup" class="btn btn-primary" ValidationGroup="employeebuttons" Text="Edit" data-toggle="modal" CausesValidation="false" OnClick="employeeeditpopup_Click"  data-target="#employeedetailsedit" />                

                               <a href="#" class="btn btn-add" data-toggle="modal" data-target="#"><i class="fa fa-file-text"></i> Resigned </a> 
                             <%--  <a href="#" class="btn btn-add" data-toggle="modal" data-target="#addtask"><i class="fa fa-file-text"></i> Replace </a> 
                           <a href="#" class="btn btn-add" data-toggle="modal" data-target="#deleterow"><i class="fa fa-file-text"></i> Delete </a>--%>
                               <a href="#" class="btn btn-add" data-toggle="modal" data-target="#addtask"><i class="fa fa-file-text"></i> Add </a>

								 
                              </div>
                     
                     </div>
                  </div>
               </div>
            </div>
            <!-- /.content -->
         </div>
         <!-- /.content-wrapper -->
                                        </div>
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
</script>  

</asp:Content>
