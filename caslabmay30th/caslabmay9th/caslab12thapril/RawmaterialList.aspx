<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeFile="RawmaterialList.aspx.cs" Inherits="caslab12thapril.RawmaterialList" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <h1 style="color:red;">Raw Material List</h1>
    
      <div class="content-wrapper">
            <!-- Content Header (Page header) -->
           
            <!-- Main content -->
            <div class="content">
               <div class="row">
                  <div class="col-sm-12 col-md-12">
                     <div class="panel panel-bd lobidrag">
                      
                        <div class="panel-body" >

                        
                                	<div  class="table-responsive" >



                                        <br />


                                        <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged" class="table table-striped table-bordered" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:CommandField ShowSelectButton="True" />
                                                <asp:BoundField DataField="RawmaterialCode" HeaderText="RawmaterialCode" SortExpression="RawmaterialCode" />
                                                <asp:BoundField DataField="RawmaterialName" HeaderText="RawmaterialName" SortExpression="RawmaterialName" />
                                                <asp:BoundField DataField="RawmaterialType" HeaderText="RawmaterialType" SortExpression="RawmaterialType" />
                                                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                                                <asp:BoundField DataField="DocumentName" HeaderText="Document" SortExpression="DocumentName" />
                                                <asp:BoundField DataField="BatchNumber" HeaderText="BatchNumber" SortExpression="BatchNumber" />
                                                <asp:BoundField DataField="deletestatus"  SortExpression="BatchNumber" />

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

                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MatreyPharmaConnectionString %>" SelectCommand="SELECT [RawmaterialCode], [RawmaterialName], [RawmaterialType], [Quantity], [DocumentName], [BatchNumber], [deletestatus] FROM [Rawmaterial2]"></asp:SqlDataSource>
  
  </div><br />

         
                              <div class="modal fade" id="addrawmaterial" tabindex="-1" role="dialog">
                  <div class="modal-dialog">
                     <div class="modal-content">
                        <div class="modal-header modal-header-primary">
                           <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                           <h3><i class="fa fa-plus m-r-5"></i> Add Material </h3>
                        </div>
                        <div class="modal-body">
                           <div class="row">
                              <div class="col-md-12">
                                 <form class="form-horizontal">
                                    <fieldset>
                                       <!-- Text input-->
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Raw Material Code</asp:label>
                                          <asp:textbox runat="server" ID="txtcode" ReadOnly="true"  type="text" placeholder="Code" class="form-control"/>

                                       </div>
                                      
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Raw Material Name</asp:label>
                                          <asp:textbox runat="server" ID="txtname"    type="text" placeholder="Name" class="form-control"/>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" ControlToValidate="txtname" ErrorMessage="This Field Is Requried"></asp:RequiredFieldValidator>

                                       </div>
                                       
                                      
                                      
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Type Of Material </asp:label>
                                             <asp:DropDownList runat="server" ID="typeofmaterial"    class="form-control">
                                                 <asp:listitem Text="select Material" Value=""></asp:listitem>
                                     <asp:ListItem Text="Solid" ></asp:ListItem>
                                     <asp:ListItem Text="Liquid" ></asp:ListItem>
                                     <asp:ListItem Text="Gas" ></asp:ListItem>
                                             </asp:DropDownList>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  runat="server" ControlToValidate="typeofmaterial" ErrorMessage="This Field Is Requried"></asp:RequiredFieldValidator>

                                       </div>
                                            <div class="col-md-3 form-group">
                                                
                                          <asp:label runat="server" class="control-label">  Quantity </asp:label>
                                          <asp:textbox runat="server" ID="quntatity"  type="text" placeholder="Quantity" class="form-control"/>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator3"  runat="server" ErrorMessage="This Field Is Requried" ControlToValidate="quntatity"></asp:RequiredFieldValidator>

                                        
                                          
                                        
                                       </div>
                                            <div class="col-md-3 form-group">
                                         <asp:label runat="server" class="control-label">  In Terms Of </asp:label>
                                          <asp:DropDownList runat="server" ID="termsof"     class="form-control">
                                          <asp:listitem Text="select" Value=""></asp:listitem>
                                     <asp:ListItem Text="Liters" Value="1"></asp:ListItem>
                                     <asp:ListItem Text="Kgs" Value="2"></asp:ListItem>
                                     <asp:ListItem Text="Grams" Value="3"></asp:ListItem>
                                          </asp:DropDownList>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="termsof"  runat="server" ErrorMessage="This Field Is Requried"></asp:RequiredFieldValidator>

                                                </div>
									    <div class="col-md-6 form-group">
									   
                                 <asp:label runat="server" class="control-label">Supplier Information</asp:label>
                                 <asp:textbox runat="server"  type="text" ID="txtinforamation"    placeholder="Information"  class="form-control"></asp:textbox>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtinforamation"  runat="server" ErrorMessage="This Field Is Requried"></asp:RequiredFieldValidator>

							  </div>

                                           <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Minimum Quantity to mantain</asp:label>
                                          <asp:textbox runat="server" ID="txtmin" type="text"    placeholder="Minimum Quantity" class="form-control"/>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator6"  runat="server" ControlToValidate="txtmin" ErrorMessage="This Field Is Requried"></asp:RequiredFieldValidator>

                                       </div>
                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">UploadDocument</asp:label>
                                              <asp:FileUpload ID="documentupload" runat="server" />

                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator9"  runat="server" ControlToValidate="documentupload" ErrorMessage="Uploading File Should Be Non Editable only "></asp:RequiredFieldValidator>


                                       </div>

                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Document Name</asp:label>
                                          <asp:textbox runat="server" ID="documentname" type="text"   placeholder="Minimum Quantity" class="form-control"/>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator7"  runat="server" ControlToValidate="documentname" ErrorMessage="This Field Is Requried"></asp:RequiredFieldValidator>

                                       </div>

                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Batch Number</asp:label>
                                          <asp:textbox runat="server" ID="txtbatch" type="text"     class="form-control"/>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator8"  runat="server" ControlToValidate="txtbatch" ErrorMessage="This Field Is Requried"></asp:RequiredFieldValidator>

                                       </div>





                                       <div class="col-md-12 form-group user-form-group">
                                          <div class="pull-right">
                                             <button type="button" class="btn btn-danger btn-sm">Cancel</button>
                                            <asp:Button runat="server" ID="Submit" Text="Submit" OnClick="Submit_Click"  ValidationGroup="addrawmaterial"  />
                                             
                                          </div>
                                       </div>
                                    </fieldset>
                                 </form>
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
                                               <button type="button" data-dismiss="modal" class="btn btn-danger btn-sm">Cancel</button>
                                              
                                            <button type="button" class="btn btn-primary"  data-toggle="modal" data-dismiss="modal"  data-target="#addrawmaterial"><i class="fa fa-file-plus"></i> Add </button>

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
                           <h3><i class="fa fa-plus m-r-5"></i> Add Material </h3>
                        </div>
                        <div class="modal-body">
                           <div class="row">
                              <div class="col-md-12">
                                 <div class="form-horizontal">
                                    <fieldset>
                                       <!-- Text input-->
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Raw Material Code</asp:label>
                                          <asp:textbox runat="server" ID="editcode" ReadOnly="true" ValidationGroup="listofrawmaterialedit"  type="text" placeholder="Code" class="form-control"/>
                                       </div>
                                      
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Raw Material Name</asp:label>
                                          <asp:textbox runat="server" ID="editname"   ValidationGroup="listofrawmaterialedit"  type="text" placeholder="Name" class="form-control"/>
                                       </div>
                                       
                                      
                                      
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Type Of Material </asp:label>
                                           <asp:textbox runat="server" ID="editmaterial" ValidationGroup="listofrawmaterialedit"  type="text" placeholder="Name" class="form-control"/>
                                       </div>
                                            <div class="col-md-6 form-group">
                                                
                                          <asp:label runat="server" class="control-label">  Quantity </asp:label>
                                          <asp:textbox runat="server" ID="editquantaity" ValidationGroup="listofrawmaterialedit"  type="text" placeholder="Quantity" class="form-control"/>
                                        
                                          
                                        
                                       </div>
                                            

                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Document Name</asp:label>
                                          <asp:textbox runat="server" ID="editdocumentname" type="text" ValidationGroup="listofrawmaterialedit"   placeholder="Minimum Quantity" class="form-control"/>
                                       </div>

                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Modification Date</asp:label>
                                          <asp:textbox runat="server" ID="editdate" type="text"  ValidationGroup="listofrawmaterialedit"  class="form-control"/>
                                       </div>


                                         <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Reason For Edit</asp:label>
                                          <asp:textbox runat="server" ID="editreason" type="text" ValidationGroup="listofrawmaterialedit"  class="form-control"/>
                                       </div>




                                       <div class="col-md-12 form-group user-form-group">
                                          <div class="pull-right">
                                           
                                            <asp:Button runat="server" ID="EditButton"  class="form-control" Text="Submit" OnClick="EditButton_Click" CausesValidation="false" ValidationGroup="listofrawmaterialedit" />
                                             
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
               <!-- /.modal -->
							


                            <div class="modal fade" id="edit" tabindex="-1" role="dialog">
                  <div class="modal-dialog">
                     <div class="modal-content">
                        <div class="modal-header modal-header-primary">
                           <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                           <h3>Warning</h3>
                            <h5>Do You want to Edit RawMaterial to the list</h5>
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
                                              
                                            <button type="button" class="btn btn-primary"  data-toggle="modal" data-dismiss="modal"  data-target="#listofrawmaterialedit"><i class="fa fa-file-plus"></i> Edit </button>

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
                           <h3><i class="fa fa-plus m-r-5"></i> Delete RawMaterial</h3>
                        </div>
                        <div class="modal-body">
                           <div class="row">
                              <div class="col-md-12">
                                 <div class="form-horizontal">
                                    <fieldset>
                                       <!-- Text input-->
                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Raw Material Code</asp:label>
                                          <asp:textbox runat="server" ID="codedelete" ReadOnly="true" ValidationGroup="deleteramaterial"    class="form-control"/>
                                       </div>
                                      
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Raw Material Name</asp:label>
                                          <asp:textbox runat="server" ID="namedelete" ReadOnly="true"  ValidationGroup="deleteramaterial"  class="form-control"/>
                                       </div>
                                       
                                      
                                      
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Type Of Material </asp:label>
                                           <asp:textbox runat="server" ID="materialdelete" ReadOnly="true" ValidationGroup="deleteramaterial"   class="form-control"/>
                                       </div>
                                            <div class="col-md-6 form-group">
                                                
                                          <asp:label runat="server" class="control-label">  Quantity </asp:label>
                                          <asp:textbox runat="server" ID="quandelete" ReadOnly="true" ValidationGroup="deleteramaterial"   class="form-control"/>
                                        
                                          
                                        
                                       </div>
                                            

                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Document Name</asp:label>
                                          <asp:textbox runat="server" ID="documentdelete" type="text" ValidationGroup="deleteramaterial" ReadOnly="true"   class="form-control"/>
                                       </div>

                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Deleted Date</asp:label>
                                          <asp:textbox runat="server" ID="datedelete" type="text"  ValidationGroup="deleteramaterial"  class="form-control"/>
                                       </div>


                                         <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Reason For Delete</asp:label>
                                          <asp:textbox runat="server" ID="reasondelete" type="text"  ValidationGroup="deleteramaterial"  class="form-control"/>
                                       </div>






                                       <div class="col-md-12 form-group user-form-group">
                                          <div class="pull-right">
                                           
                                            <button type="button" class="btn btn-primary"  data-toggle="modal" data-dismiss="modal"  data-target="#deleterow"><i class="fa fa-file-plus"></i> Delete </button>


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
               <!-- /.modal -->


                          
                                   <div class="modal fade" id="Replace" tabindex="-1" role="dialog">
                  <div class="modal-dialog">
                     <div class="modal-content">
                        <div class="modal-header modal-header-primary">
                           <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                           <h3><i class="fa fa-plus m-r-5"></i> Replace RawMaterial </h3>
                        </div>
                        <div class="modal-body">
                           <div class="row">
                              <div class="col-md-12">
                                 <div class="form-horizontal">
                                    <fieldset>
                                       <!-- Text input-->
                                       
                                             
                                            

                                             <div class="col-md-9 form-group">
                                          <asp:label runat="server" class="control-label"> RawMaterial To Replace Or Obsolete </asp:label>
                                             <asp:DropDownList runat="server" ID="DropDownList1"    class="form-control">
                                                 <asp:listitem Text="select Material" Value=""></asp:listitem>
                                     <asp:ListItem Text="Solid" ></asp:ListItem>
                                     <asp:ListItem Text="Liquid" ></asp:ListItem>
                                     <asp:ListItem Text="Gas" ></asp:ListItem>
                                             </asp:DropDownList>
                                         
                                       </div>

                                          <div class="col-md-9 form-group">
                                          <asp:label runat="server" class="control-label">Replacing RawMaterial </asp:label>
                                             <asp:DropDownList runat="server" ID="DropDownList2"    class="form-control">
                                                 <asp:listitem Text="select Material" Value=""></asp:listitem>
                                     <asp:ListItem Text="Solid" ></asp:ListItem>
                                     <asp:ListItem Text="Liquid" ></asp:ListItem>
                                     <asp:ListItem Text="Gas" ></asp:ListItem>
                                             </asp:DropDownList>
                                           
                                       </div>

                                          <div class="col-md-9 form-group">
                                          <asp:label runat="server" class="control-label">Reason For Action</asp:label>
                                          <asp:textbox runat="server" ID="Textbox6" type="text" Height="60px"   class="form-control"/>
                                       </div>


                                         <div class="col-md-9 form-group">
                                          <asp:label runat="server" class="control-label">Disribution List For Action</asp:label>
                                          <asp:textbox runat="server" ID="Textbox7" Height="60px" type="text" class="form-control"/>
                                       </div>




                                       <div class="col-md-12 form-group user-form-group">
                                          <div class="pull-right">
                                          
                                            <asp:Button runat="server"  class="form-control" ID="Save" Text="Submit"  />
                                             
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
               <!-- /.modal -->
							 


                           
							



                             <div class="modal fade" id="deleterow" tabindex="-1" role="dialog">
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
                                    <asp:Button runat="server" ID="Delete" Text="YES" OnClick="Delete_Click" ValidationGroup="deleteramaterial" CausesValidation="false" />
                                              

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
							  		  	  
							  



          <div class="buttonexport">
                                 
                             <%--<asp:Button ID="Button2" runat="server" Text="Edit" class="fa fa-file-text" CausesValidation="false" OnClick="Button2_Click"  />--%>

                <a href="#" class="btn btn-add" data-toggle="modal" data-target="#edit"><i class="fa fa-file-text"></i> Edit </a> 
              <asp:Button runat="server" Text="Export" ID="exporttoexcel" OnClick="exporttoexcel_Click1" CausesValidation="false" />
                             <%--  <a href="#" class="btn btn-add" data-toggle="modal" data-target="#"><i class="fa fa-file-text"></i> Export </a> --%>
                               <a href="#" class="btn btn-add" data-toggle="modal" data-target="#"><i class="fa fa-file-text"></i> Disable/Enable </a> 
                               <a href="#" class="btn btn-add" data-toggle="modal" data-target="#Replace"><i class="fa fa-file-text"></i> Replace </a> 
                           <a href="#" class="btn btn-add" data-toggle="modal" data-target="#deleteramaterial"><i class="fa fa-file-text"></i> Delete </a>
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
   

</asp:Content>
