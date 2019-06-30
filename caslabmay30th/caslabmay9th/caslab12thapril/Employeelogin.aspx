<%@ Page Title="" Language="C#" MasterPageFile="~/Admin2.Master" AutoEventWireup="true" CodeBehind="Employeelogin.aspx.cs" Inherits="caslab12thapril.Employee_login" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1 style="color:red;">Employee login</h1>
    
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
                                        <asp:GridView ID="GridView1"  DataSourceID="SqlDataSource1"  runat="server" class="table table-striped table-bordered" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False"  >
                                            <Columns>
                                                 <asp:TemplateField HeaderText="Select">
<ItemTemplate>
<%--<input name="RadioButton1" type="radio" value='<%# Eval("id") %>' onclick="javascript.myselection(this.id)" />--%>
  <asp:RadioButton runat="server" id="RadioButton1" value='<%# Eval("id") %>' OnCheckedChanged="RadioButton1_CheckedChanged1" onclick="javascript:CheckOtherIsCheckedByGVID(this)" />
</ItemTemplate>
</asp:TemplateField>
                                                <asp:BoundField DataField="Ecode" HeaderText="Ecode" SortExpression="Ecode" />
                                                <asp:BoundField DataField="Name_" HeaderText="Name_" SortExpression="Name_" />
                                                <asp:BoundField DataField="LoginID_" HeaderText="LoginID_" SortExpression="LoginID_" />
                                                <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                                                <asp:BoundField DataField="EmailID_" HeaderText="EmailID_" SortExpression="EmailID_" />

                                                </Columns>
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            <EditRowStyle BackColor="#999999" />
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

                                        </asp:GridView>

                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MatreyPharmaConnectionString %>" SelectCommand="SELECT [id], [Ecode], [Name ] AS Name_, [LoginID ] AS LoginID_, [Password], [EmailID ] AS EmailID_ FROM [employeelogindetails]"></asp:SqlDataSource>
                                        <br />
                                        
 
  </div><br />
         
                              <div class="modal fade" id="Creatpasswor" tabindex="-1" role="dialog">
                  <div class="modal-dialog">
                     <div class="modal-content">
                        <div class="modal-header modal-header-primary">
                           <button type="button"  class="close" data-dismiss="modal" aria-hidden="true">×</button>
                           <h3><i class="fa fa-plus m-r-5"></i> Create Employee </h3>
                        </div>
                        <div class="modal-body">
                           <div class="row">
                              <div class="col-md-12">
                                 <div class="form-horizontal">
                                    <fieldset>
                                       <!-- Text input-->
                                      
                                      
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">E-code </asp:label>
                                             <asp:DropDownList runat="server" ID="ecode" ValidationGroup="addrawmaterial" class="form-control" OnSelectedIndexChanged="OnSelectedIndexChanged" AppendDataBoundItems="true" AutoPostBack="true">
                                
                                             </asp:DropDownList>
                                       </div>
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label"> Name</asp:label>
                                          <asp:textbox runat="server" ID="txtname" ValidationGroup="addrawmaterial" type="text" placeholder="Name" class="form-control"/>
                                       </div>
                                       
                                      
                                      
                                         
									    <div class="col-md-6 form-group">
									   
                                 <asp:label runat="server" class="control-label">Login ID</asp:label>
                                 <asp:textbox runat="server"  type="text" ID="txtlogin" ValidationGroup="addrawmaterial" placeholder="Information"  class="form-control"></asp:textbox>
							  </div>

                                           
                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Password</asp:label>
                                          <asp:textbox runat="server" ID="txtpass" type="text" ValidationGroup="addrawmaterial" class="form-control"/>
                                       </div>


                                           <div class="col-md-6 form-group">
									   
                                 <asp:label runat="server" class="control-label">Email ID</asp:label>
                                 <asp:textbox runat="server"  type="text" ID="email" placeholder="Information" ValidationGroup="addrawmaterial" class="form-control"></asp:textbox>
							  </div>
                                        




                                       <div class="col-md-12 form-group user-form-group">
                                          <div class="pull-right">
                                             <button type="button" class="btn btn-danger btn-sm">Cancel</button>
                                            <asp:Button runat="server" ID="Submit" Text="Submit" OnClick="Submit_Click" ValidationGroup="addrawmaterial" CausesValidation="false" />
                                               <%--<asp:LinkButton ID="lnksubmit" Text="submit"   runat="server"  class="btn btn-primary" OnClick="lnksubmit_Click"/>--%>
                                          </div>
                                       </div>
                                    </fieldset>
                                 </div>
                              </div>
                           </div>
                        </div>
                        <div class="modal-footer">
                           <button type="button" class="btn btn-danger pull-left" data-dismiss="modal">Close</button>
                        </div>
                     </div>
                     <!-- /.modal-content -->
                  </div>
                  <!-- /.modal-dialog -->
               </div>
              
                              
                            
            
         <div class="modal fade" id="Createnew" tabindex="-1" role="dialog">
                  <div class="modal-dialog">
                     <div class="modal-content">
                        <div class="modal-header modal-header-primary">
                           <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                           <h3>Warning</h3>
                            <h5>Do you want to create new login</h5>
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
                                              <button type="button" class="btn btn-primary"  data-toggle="modal" data-dismiss="modal"  data-target="#Creatpasswor"><i class="fa fa-file-plus"></i> Add </button>
                                              
                                            <%--<button type="button"  class="btn btn-primary"  data-toggle="modal" data-dismiss="modal"  data-target="#addrawmaterial"><i class="fa fa-file-plus"></i> Add </button>--%>

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


                                  <div class="modal fade" id="updateemployee" tabindex="-1" role="dialog">
                  <div class="modal-dialog">
                     <div class="modal-content">
                        <div class="modal-header modal-header-primary">
                           <button type="button"  class="close" data-dismiss="modal" aria-hidden="true">×</button>
                           <h3><i class="fa fa-plus m-r-5"></i> Edit Details </h3>
                        </div>
                        <div class="modal-body">
                           <div class="row">
                              <div class="col-md-12">
                                 <div class="form-horizontal">
                                    <fieldset>
                                       <!-- Text input-->
                                      
                                      
                                        <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label"> E-Code</asp:label>
                                          <asp:textbox runat="server" ID="editcode" ReadOnly="true" ValidationGroup="updateemployee" type="text" placeholder="Name" class="form-control"/>
                                       </div>
                                       
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label"> Name</asp:label>
                                          <asp:textbox runat="server" ID="editname" ReadOnly="true" ValidationGroup="updateemployee" type="text" placeholder="Name" class="form-control"/>
                                       </div>
                                       
                                      
                                      
                                         
									    <div class="col-md-6 form-group">
									   
                                 <asp:label runat="server" class="control-label">Login ID</asp:label>
                                 <asp:textbox runat="server"  type="text" ID="editloginid" ReadOnly="true" ValidationGroup="updateemployee" placeholder="Information"  class="form-control"></asp:textbox>
							  </div>

                                           
                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Password</asp:label>
                                          <asp:textbox runat="server" ID="editpassword" type="text" ValidationGroup="updateemployee" class="form-control"/>
                                       </div>


                                           <div class="col-md-6 form-group">
									   
                                 <asp:label runat="server" class="control-label">Email ID</asp:label>
                                 <asp:textbox runat="server"  type="text" ID="editemail" placeholder="enter mailid" ValidationGroup="updateemployee" class="form-control"></asp:textbox>
							  </div>
                                        




                                       <div class="col-md-12 form-group user-form-group">
                                          <div class="pull-right">
                                                 <%--<button type="button" class="btn btn-primary"  data-toggle="modal" data-dismiss="modal"  data-target="#edit"><i class="fa fa-file-plus"></i> Submit </button>--%>

                                             <button type="button" class="btn btn-danger btn-sm">Cancel</button>
                                            <asp:Button runat="server" ID="editbutton" OnClick="editbutton_Click1" Text="Submit"  ValidationGroup="updateemployee" CausesValidation="false" />
                                               <%--<asp:LinkButton ID="lnksubmit" Text="submit"   runat="server"  class="btn btn-primary" OnClick="lnksubmit_Click"/>--%>
                                          </div>
                                       </div>
                                    </fieldset>
                                 </div>
                              </div>
                           </div>
                        </div>
                        <div class="modal-footer">
                           <button type="button" class="btn btn-danger pull-left" data-dismiss="modal">Close</button>
                        </div>
                     </div>
                     <!-- /.modal-content -->
                  </div>
                  <!-- /.modal-dialog -->
               </div>
              

     <div class="modal fade" id="Update" tabindex="-1" role="dialog">
                  <div class="modal-dialog">
                     <div class="modal-content">
                        <div class="modal-header modal-header-primary">
                           <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                           <h3>Warning</h3>
                            <h5>Do you want to update Employee login details</h5>
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
                                           <button type="button" class="btn btn-primary"  data-toggle="modal" data-dismiss="modal"  data-target="#updateemployee"><i class="fa fa-file-plus"></i> Update </button>
                                             <%--<asp:Button runat="server" ID="Button1"  class="form-control" Text="Edit" OnClick="Button1_Click"  CausesValidation="false" ValidationGroup="#updateemployee" />
  --%>
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
                             


          <div class="buttonexport">
                                 
                             <%--<asp:Button ID="Button2" runat="server" Text="Edit" class="fa fa-file-text" CausesValidation="false" OnClick="Button2_Click"  />--%>

                <%--<a href="#" class="btn btn-add" data-toggle="modal" data-target="#Editrow"><i class="fa fa-file-text"></i> Edit </a> 
                               <a href="#" class="btn btn-add" data-toggle="modal" data-target="#"><i class="fa fa-file-text"></i> Export </a> 
                               <a href="#" class="btn btn-add" data-toggle="modal" data-target="#"><i class="fa fa-file-text"></i> Disable/Enable </a>--%> 
                               <a href="#" class="btn btn-add" data-toggle="modal" data-target="#Lock/Unlock"><i class="fa fa-file-text"></i> Lock/Unlock </a> 
                            <asp:Button runat="server" ID="editpopup" class="btn btn-primary" ValidationGroup="buttons" Text="Edit" data-toggle="modal" OnClick="editpopup_Click"  data-target="#updateemployee" />
                               <a href="#" class="btn btn-add" data-toggle="modal" data-target="#Createnew"><i class="fa fa-file-text"></i> Create new </a>

								 
                              </div>
                     
                     </div>
                  </div>
               </div>
            </div>
            <!-- /.content -->
         </div>
         <!-- /.content-wrapper -->
                                        </div>



     <script language="javascript" type="text/javascript">
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
</script>  

</asp:Content>
