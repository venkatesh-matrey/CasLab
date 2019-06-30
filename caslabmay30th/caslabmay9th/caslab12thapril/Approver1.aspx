<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Approver1.aspx.cs" Inherits="caslab12thapril.Approver1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="col-lg-11">
   <form>
   <div class="col-lg-4">
      <label style="float:right;" for="sel1">Employee Id</label>
      
      </div>
    <div class="col-lg-6">
      
     <asp:TextBox runat="server" ID="employeeid" class="form-control"></asp:TextBox>
      </div>
	  <br/>
	  <br/>
	  <br/>
	  <div class="col-lg-4">
      <label style="float:right;" for="sel1">Approver Id</label>
      
      </div>
    <div class="col-lg-6">
      
      <asp:TextBox runat="server" ID="approverid"  class="form-control" >
        
      </asp:TextBox>
      
      </div>
     <div class="col-lg-4">
      <label style="float:right;" for="sel1">Approver</label>
      
      </div>
    <div class="col-lg-6">
        <asp:DropDownList runat="server" ID="approvername" AppendDataBoundItems="true" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="approvername_SelectedIndexChanged"></asp:DropDownList>
             

        </div>

       <br />
        <div class="col-lg-4">
      <label style="float:right;" for="sel1">Select tasks</label>
      
      </div>
    <div class="col-lg-6">
       
      


     <asp:DropDownList runat="server" ID="DropDownList1" DataSourceID="Sqldatasource2" DataTextField="TaskId" DataValueField="TaskId" AppendDataBoundItems="true" AutoPostBack="true" class="form-control">

     </asp:DropDownList>
        

      </div>

        <br />
                   
                    <br />
                    <br />
                <div class="col-lg-4">

                  <label style="float:right;" for="sel1">Comments</label>
      
      </div>
    <div class="col-lg-6">
                <asp:TextBox runat="server" ID="comments" Columns="120" Rows="5" placeholder="Write Comments"  class="form-control"></asp:TextBox>
        </div>

                    <br />
                    <br />
                    <br />
    <div class="col-lg-6">

<%--<asp:RadioButtonList ID="status" runat="server">
     <asp:ListItem  Text="Accept"  />
    <asp:ListItem Text="Reject"  />
 </asp:RadioButtonList>--%>

        <asp:RadioButton ID="Accept" GroupName="gp" Text="Accepect" runat="server"/>
        <asp:RadioButton ID="Reject" GroupName="gp" Text="Reject" runat="server" />
       
        </div>
                    <br />
                
                    <br />
                    <br />

                 <div class="col-lg-4">
            <asp:Button runat="server" ID="submit"  Text="Submit" class="btn btn-default" OnClick="submit_Click" />
            </div>
                  <div class="col-lg-4">
             <asp:Label ID="label1" runat="server"></asp:Label>

             </div>                         


        <asp:SqlDataSource runat="server" ID="Sqldatasource2" ConnectionString="<%$ ConnectionStrings:MatreyPharmaConnectionString %>" SelectCommand="proc_GetReviewerTaskDetailsByEmpid" SelectCommandType="StoredProcedure">
                                                 <SelectParameters>
                                                     <asp:SessionParameter Name="EmpId" SessionField="Session[&quot;EmpId&quot;]" Type="String" />
                                                 </SelectParameters>
                                                </asp:SqlDataSource> 
  </form>
  
  
</div>																																																																			</div>
						
</asp:Content>
