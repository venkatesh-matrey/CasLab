<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeFile="RawMaterial.aspx.cs" Inherits="caslab12thapril.RawMaterial" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     
     
    <div id="searchmaterail">
        <div class="row">
            <div class="col-md-12">
        
       <div class="col-md-6" >
                                         <h1 style="color:red;">Raw Material List</h1>
                                         </div>
                                       
                         <div class="col-md-3" style="margin-top:30px;margin-left:90px" >
                                         
                                          <asp:textbox runat="server" ID="Textbox16" Width="170px" ValidationGroup="searchmaterail" placeholder=" RawMaterial Name" class="form-control"/>
                            </div>
                             <div class="col-md-3"  style="margin-top:30px;margin-left:-90px"" >
                              <asp:Button runat="server" Text="Search" ID="searchbutton"  class="btn btn-primary"  ValidationGroup="searchmaterail"  OnClick="searchbutton_Click"  CausesValidation="false" />
                           
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
                                        <asp:GridView ID="GridView1"   runat="server"  OnRowDataBound="OnRowDataBound" class="table table-striped table-bordered" AutoGenerateColumns="False" CellPadding="4"  ForeColor="#333333" GridLines="None"  >
                                            <AlternatingRowStyle BackColor="White" />
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
                                                <asp:BoundField DataField="rawmaterialcode" HeaderText="Raw Material Code" SortExpression="rawmaterialcode" />
                                                <asp:BoundField DataField="rawmaterialname" HeaderText="Raw Material Name" SortExpression="rawmaterialname" />
                                                 <asp:TemplateField HeaderText="Raw Material Type" SortExpression="typeofmaterial">
                                                    <HeaderTemplate>
                Material Type:
                <asp:DropDownList ID="ddlCountry" runat="server" OnSelectedIndexChanged="CountryChanged" style="color:black;background-color:#507CD1"
                    AutoPostBack="true" AppendDataBoundItems="true">
                    <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>
                    <asp:ListItem Text="Top 10" Value="10"></asp:ListItem>
                    <asp:ListItem Text="SOLID" Value="SOLID"></asp:ListItem>
                    <asp:ListItem Text="LIQUID" Value="LIQUID"></asp:ListItem>
                    <asp:ListItem Text="GAS" Value="GAS"></asp:ListItem>
                </asp:DropDownList>
            </HeaderTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("typeofmaterial") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("typeofmaterial") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="quantity" HeaderText="Quantity" SortExpression="quantity" />
												<asp:BoundField DataField="intermsof" HeaderText=" In Terms Of" SortExpression="intermsof" />																					
                                                <asp:BoundField DataField="supplierinformation" HeaderText="Supplier Info" SortExpression="supplierinformation" />
                                                 <asp:BoundField DataField="status" HeaderText="Status"  SortExpression="BatchNumber" />
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
                                       <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MatreyPharmaConnectionString %>" SelectCommand="SELECT [id], [rawmaterialcode], [rawmaterialname], [typeofmaterial], [quantity],[intermsof], [supplierinformation],[status] FROM [AddRawmaterial]"></asp:SqlDataSource>
                                        <br />
																							</div>

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
                                          <asp:textbox runat="server" ID="txtcode" ReadOnly="true"  type="text" class="form-control"/>

                                       </div>
                                      
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Raw Material Name</asp:label>
                                          <asp:textbox runat="server" ID="txtname"  ValidationGroup="addrawmaterial"  type="text" placeholder="Name" class="form-control"/>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ValidationGroup="addrawmaterial"  runat="server" ControlToValidate="txtname" ErrorMessage="This Field Is Requried"></asp:RequiredFieldValidator>

                                       </div>
                                       
                                      
                                      
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Type Of Material </asp:label>
                                             <asp:DropDownList runat="server" ID="typeofmaterial"  ValidationGroup="addrawmaterial"  class="form-control">
                                                 <asp:listitem Text="select Material" Value=""></asp:listitem>
                                     <asp:ListItem Text="Solid" ></asp:ListItem>
                                     <asp:ListItem Text="Liquid" ></asp:ListItem>
                                     <asp:ListItem Text="Gas" ></asp:ListItem>
                                             </asp:DropDownList>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" ValidationGroup="addrawmaterial" runat="server" ControlToValidate="typeofmaterial" ErrorMessage="This Field Is Requried"></asp:RequiredFieldValidator>

                                       </div>
                                            <div class="col-md-3 form-group">
                                                
                                          <asp:label runat="server" class="control-label">  Quantity </asp:label>
                                          <asp:textbox runat="server" ID="quntatity"  type="text" ValidationGroup="addrawmaterial" placeholder="Quantity" class="form-control"/>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" ValidationGroup="addrawmaterial"  runat="server" ErrorMessage="This Field Is Requried" ControlToValidate="quntatity"></asp:RequiredFieldValidator>

                                        
                                          
                                        
                                       </div>
                                            <div class="col-md-3 form-group">
                                         <asp:label runat="server" class="control-label">  In Terms Of </asp:label>
                                          <asp:DropDownList runat="server" ID="termsof"   ValidationGroup="addrawmaterial"  class="form-control">
                                          <asp:listitem Text="select" Value=""></asp:listitem>
                                     <asp:ListItem Text="Liters" Value="1"></asp:ListItem>
                                     <asp:ListItem Text="Kgs" Value="2"></asp:ListItem>
                                     <asp:ListItem Text="Grams" Value="3"></asp:ListItem>
                                          </asp:DropDownList>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" ValidationGroup="addrawmaterial" ControlToValidate="termsof"  runat="server" ErrorMessage="This Field Is Requried"></asp:RequiredFieldValidator>

                                                </div>
									    <div class="col-md-6 form-group">
									   
                                 <asp:label runat="server" class="control-label">Supplier Information</asp:label>
                                 <asp:textbox runat="server"  type="text" ID="txtinforamation"   ValidationGroup="addrawmaterial" placeholder="Information"  class="form-control"></asp:textbox>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" ValidationGroup="addrawmaterial" ControlToValidate="txtinforamation"  runat="server" ErrorMessage="This Field Is Requried"></asp:RequiredFieldValidator>

							  </div>

                                           <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Minimum Quantity to mantain</asp:label>
                                          <asp:textbox runat="server" ID="txtmin" type="text"  ValidationGroup="addrawmaterial"  placeholder="Minimum Quantity" class="form-control"/>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ForeColor="Red" ValidationGroup="addrawmaterial"  runat="server" ControlToValidate="txtmin" ErrorMessage="This Field Is Requried"></asp:RequiredFieldValidator>

                                       </div>
                                          <div class="col-md-3 form-group">
                                          <asp:label runat="server" class="control-label">Expiry</asp:label>
                                              
                                          
                                         
                                       </div>
                                        <div class="col-md-3 form-group">
                                       
                                             <asp:RadioButton ID="RadioButton1"  ValidationGroup="addrawmaterial"  Text="Yes" runat="server" />
                                          
                                         
                                       </div>

                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Date</asp:label>
                                          <asp:textbox runat="server" ID="date" type="date"  ValidationGroup="addrawmaterial"   class="form-control"/>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ForeColor="Red" ValidationGroup="addrawmaterial"  runat="server" ControlToValidate="date" ErrorMessage="This Field Is Requried"></asp:RequiredFieldValidator>
                                         
                                       </div>

                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Info</asp:label>
                                          <asp:textbox runat="server" ID="info" placeholder="Info" class="form-control"/>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ForeColor="Red"  ValidationGroup="addrawmaterial"  runat="server" ControlToValidate="info" ErrorMessage="This Field Is Requried"></asp:RequiredFieldValidator>

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
                           <h3><i class="fa fa-plus m-r-5"></i> Edit Material </h3>
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
                                            <div class="col-md-3 form-group">
                                                
                                          <asp:label runat="server" class="control-label">  Quantity </asp:label>
                                          <asp:textbox runat="server" ID="editquantaity" ValidationGroup="listofrawmaterialedit"  type="text" placeholder="Quantity" class="form-control"/>
                                        
                                          
                                        
                                       </div>
									    <div class="col-md-3 form-group">
                                                
                                          <asp:label runat="server" class="control-label">  In Terms Of </asp:label>
                                          <asp:textbox runat="server" ID="editunits" ValidationGroup="listofrawmaterialedit"  type="text" placeholder="Units" class="form-control"/>
                                        
                                          
                                        
                                       </div>
                                            

                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">SupplierInformation </asp:label>
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
                                            <button type="button" class="btn btn-primary"  data-toggle="modal" data-dismiss="modal"  data-target="#edit"><i class="fa fa-file-plus"></i> Submit </button>
                                              
                                            
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
                                           
                                             <asp:Button runat="server" ID="EditButton" class="btn btn-primary" Text="Edit" OnClick="EditButton_Click"  CausesValidation="false" ValidationGroup="listofrawmaterialedit" />
                                             

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
                                            <div class="col-md-3 form-group">
                                                
                                          <asp:label runat="server" class="control-label">  Quantity </asp:label>
                                          <asp:textbox runat="server" ID="quandelete" ReadOnly="true" ValidationGroup="deleteramaterial"   class="form-control"/>
                                        
                                          
                                        
                                       </div>
									   <div class="col-md-3 form-group">
                                                
                                          <asp:label runat="server" class="control-label">   In Terms Of </asp:label>
                                          <asp:textbox runat="server" ID="unitsdelete" ReadOnly="true" ValidationGroup="deleteramaterial"   class="form-control"/>
                                        
                                          
                                        
                                       </div>
                                            

                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label"> Supplier Information</asp:label>
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
							  		  	  
							    <div class="modal fade" id="disableramaterial" tabindex="-1" role="dialog">
                  <div class="modal-dialog">
                     <div class="modal-content">
                        <div class="modal-header modal-header-primary">
                           <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                           <h3><i class="fa fa-plus m-r-5"></i> Disable RawMaterial</h3>
                        </div>
                        <div class="modal-body">
                           <div class="row">
                              <div class="col-md-12">
                                 <div class="form-horizontal">
                                    <fieldset>
                                       <!-- Text input-->
                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Raw Material Code</asp:label>
                                          <asp:textbox runat="server" ID="Textbox1" ReadOnly="true" ValidationGroup="disableramaterial"    class="form-control"/>
                                       </div>
                                      
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Raw Material Name</asp:label>
                                          <asp:textbox runat="server" ID="Textbox2" ReadOnly="true"  ValidationGroup="disableramaterial"  class="form-control"/>
                                       </div>
                                       
                                      
                                      
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Type Of Material </asp:label>
                                           <asp:textbox runat="server" ID="Textbox3" ReadOnly="true" ValidationGroup="disableramaterial"   class="form-control"/>
                                       </div>
                                            <div class="col-md-3 form-group">
                                                
                                          <asp:label runat="server" class="control-label">  Quantity </asp:label>
                                          <asp:textbox runat="server" ID="Textbox4" ReadOnly="true" ValidationGroup="disableramaterial"   class="form-control"/>
                                        
                                          
                                        
                                       </div>
                                              <div class="col-md-3 form-group">
                                                
                                          <asp:label runat="server" class="control-label">   In Terms Of </asp:label>
                                          <asp:textbox runat="server" ID="txtintermsof" ReadOnly="true" ValidationGroup="disableramaterial"   class="form-control"/>
                                        
                                          
                                        
                                       </div>
                                            

                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label"> Supplier Information</asp:label>
                                          <asp:textbox runat="server" ID="Textbox5" type="text" ValidationGroup="disableramaterial" ReadOnly="true"   class="form-control"/>
                                       </div>

                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Disable Date</asp:label>
                                          <asp:textbox runat="server" ID="Textbox6" type="text"  ValidationGroup="disableramaterial"  class="form-control"/>
                                       </div>


                                         <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Reason For Disable</asp:label>
                                          <asp:textbox runat="server" ID="Textbox7" type="text"  ValidationGroup="disableramaterial"  class="form-control"/>
                                       </div>






                                       <div class="col-md-12 form-group user-form-group">
                                          <div class="pull-right">
                                           
                                            <button type="button" class="btn btn-primary"  data-toggle="modal" data-dismiss="modal"  data-target="#disablerow"><i class="fa fa-file-plus"></i> Disable </button>


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
 


                             <div class="modal fade" id="disablerow" tabindex="-1" role="dialog">
                  <div class="modal-dialog">
                     <div class="modal-content">
                        <div class="modal-header modal-header-primary">
                           <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                           <h3>Warning</h3>
                            <h5>Do You want to Disable RawMaterial From list</h5>
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
                                    <asp:Button runat="server" ID="Button1" Text="YES" class="btn btn-primary" ValidationGroup="disableramaterial" CausesValidation="false" OnClick="Button1_Click" />
                                              

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

                            	  	  
							    <div class="modal fade" id="enableramaterial" tabindex="-1" role="dialog">
                  <div class="modal-dialog">
                     <div class="modal-content">
                        <div class="modal-header modal-header-primary">
                           <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                           <h3><i class="fa fa-plus m-r-5"></i> Disable RawMaterial</h3>
                        </div>
                        <div class="modal-body">
                           <div class="row">
                              <div class="col-md-12">
                                 <div class="form-horizontal">
                                    <fieldset>
                                       <!-- Text input-->
                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Raw Material Code</asp:label>
                                          <asp:textbox runat="server" ID="Textbox8" ReadOnly="true" ValidationGroup="enableramaterial"    class="form-control"/>
                                       </div>
                                      
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Raw Material Name</asp:label>
                                          <asp:textbox runat="server" ID="Textbox9" ReadOnly="true"  ValidationGroup="enableramaterial"  class="form-control"/>
                                       </div>
                                       
                                      
                                      
                                       <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Type Of Material </asp:label>
                                           <asp:textbox runat="server" ID="Textbox10" ReadOnly="true" ValidationGroup="enableramaterial"   class="form-control"/>
                                       </div>
                                            <div class="col-md-3 form-group">
                                                
                                          <asp:label runat="server" class="control-label">  Quantity </asp:label>
                                          <asp:textbox runat="server" ID="Textbox11" ReadOnly="true" ValidationGroup="enableramaterial"   class="form-control"/>
                                        
                                          
                                        
                                       </div>
									    <div class="col-md-3 form-group">
                                                
                                          <asp:label runat="server" class="control-label">   In Terms Of </asp:label>
                                          <asp:textbox runat="server" ID="intermsof" ReadOnly="true" ValidationGroup="enableramaterial"   class="form-control"/>
                                        
                                          
                                        
                                       </div>
                                            

                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label"> Supplier Information</asp:label>
                                          <asp:textbox runat="server" ID="Textbox12" type="text" ValidationGroup="enableramaterial" ReadOnly="true"   class="form-control"/>
                                       </div>

                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Enable Date</asp:label>
                                          <asp:textbox runat="server" ID="Textbox13" type="text"  ValidationGroup="enableramaterial"  class="form-control"/>
                                       </div>


                                         <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Reason For Enable</asp:label>
                                          <asp:textbox runat="server" ID="Textbox14" type="text"  ValidationGroup="enableramaterial"  class="form-control"/>
                                       </div>






                                       <div class="col-md-12 form-group user-form-group">
                                          <div class="pull-right">
                                           
                                            <button type="button" class="btn btn-primary"  data-toggle="modal" data-dismiss="modal"  data-target="#enablerow"><i class="fa fa-file-plus"></i> Enable </button>


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
 
                               <div class="modal fade" id="enablerow" tabindex="-1" role="dialog">
                  <div class="modal-dialog">
                     <div class="modal-content">
                        <div class="modal-header modal-header-primary">
                           <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                           <h3>Warning</h3>
                            <h5>Do You want to Enable RawMaterial From list</h5>
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
                                    <asp:Button runat="server" ID="enable" Text="YES" class="btn btn-primary" ValidationGroup="enableramaterial" CausesValidation="false" OnClick="enable_Click" />
                                              

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





                            
                                 <div class="modal fade" id="Replace" tabindex="-1" role="dialog">
                  <div class="modal-dialog">
                     <div class="modal-content">
                        <div class="modal-header modal-header-primary">
                           <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                           <h3><i class="fa fa-plus m-r-5"></i> Replace RawMaterial</h3>
                        </div>
                        <div class="modal-body">
                           <div class="row">
                              <div class="col-md-12">
                                 <div class="form-horizontal">
                                    <fieldset>
                                       <!-- Text input-->
                                          <div class="col-md-6 form-group">
                                          <asp:label runat="server" class="control-label">Raw Material Code</asp:label>
                                          <asp:textbox runat="server" ID="Textbox15" ReadOnly="true" ValidationGroup="Replace"    class="form-control"/>
                                       </div>
                                      
                                       <div class="col-md-9 form-group">
                                          <asp:label runat="server" ID="replacing" class="control-label">Replacing RawMaterial </asp:label>
                                             <asp:DropDownList runat="server" ID="DropDownList2" AppendDataBoundItems="true" AutoPostBack="true"  ValidationGroup="Replace"   class="form-control" OnSelectedIndexChanged="OnSelectedIndexChanged">
                                                
                                             </asp:DropDownList>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator19" ForeColor="Red" ValidationGroup="Replace"  runat="server" ControlToValidate="DropDownList2" ErrorMessage="This Field Is Requried"></asp:RequiredFieldValidator>
                                           
                                       </div>
                                       
                              <div class="col-md-9 form-group">
                                          <asp:label runat="server" class="control-label">Reason For Action</asp:label>
                                          <asp:textbox runat="server" ID="reasonforaction" type="text" Height="60px"  ValidationGroup="Replace"  class="form-control"/>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator20" ForeColor="Red" ValidationGroup="Replace"  runat="server" ControlToValidate="reasonforaction" ErrorMessage="This Field Is Requried"></asp:RequiredFieldValidator>
                                       
                              </div>


                                         <div class="col-md-9 form-group">
                                          <asp:label runat="server" class="control-label">Distribution List For Action</asp:label>
                                          <asp:textbox runat="server" ID="dis" Height="60px" type="text" ValidationGroup="Replace" class="form-control"/>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator21" ForeColor="Red" ValidationGroup="Replace"  runat="server" ControlToValidate="dis" ErrorMessage="This Field Is Requried"></asp:RequiredFieldValidator>
                                       
                                         </div>




                                       <div class="col-md-12 form-group user-form-group">
                                          <div class="pull-right">
                                          
                                            <%--<button type="button" class="btn btn-primary"  data-toggle="modal" data-dismiss="modal"  data-target="#replacematerial"><i class="fa fa-file-plus"></i> Replace </button>--%>

                                              <asp:Button runat="server" ID="replacepopreqried" Text="Replace"  class="btn btn-primary"  data-toggle="modal" data-dismiss="modal"  data-target="#replacematerial" ValidationGroup="Replace" />

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
                    


                            
                             <div class="modal fade" id="replacematerial" tabindex="-1" role="dialog">
                  <div class="modal-dialog">
                     <div class="modal-content">
                        <div class="modal-header modal-header-primary">
                           <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                           <h3>Warning</h3>
                            <h5>Do You want to Replace RawMaterial From list</h5>
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
                                    <asp:Button runat="server" ID="replacerawmaterail" Text="YES" class="btn btn-primary" ValidationGroup="Replace" CausesValidation="false" OnClick="replacerawmaterail_Click"  />
                                              

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

     <asp:Button runat="server" ID="enablepopup" ValidationGroup="buttons" class="btn btn-primary" CausesValidation="false"  Text="Enable" data-toggle="modal"  data-target="#enableramaterial" OnClick="enablepopup_Click"/>

                 <asp:Button runat="server" ID="disablepopup" ValidationGroup="buttons" class="btn btn-primary" CausesValidation="false"  Text="Disable" data-toggle="modal"  data-target="#disableramaterial" OnClick="disablepopup_Click"/>


                              <%-- <a href="#" class="btn btn-add" data-toggle="modal" data-target="#Replace"><i class="fa fa-file-text"></i> Replace </a> --%>
                                             <asp:Button runat="server" ID="replce" ValidationGroup="buttons" class="btn btn-primary" CausesValidation="false"  Text="Replace" data-toggle="modal"  data-target="#Replace" OnClick="replce_Click"/>

                         
               <asp:Button runat="server" ID="popupdelete" ValidationGroup="buttons" class="btn btn-primary" CausesValidation="false"  Text="Delete" data-toggle="modal"  data-target="#deleteramaterial" OnClick="popupdelete_Click" />

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
