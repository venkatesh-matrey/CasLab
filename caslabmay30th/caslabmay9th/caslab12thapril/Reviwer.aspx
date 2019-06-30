<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Reviwer.aspx.cs" Inherits="caslab12thapril.Reviwer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="col-lg-11">
   <form>
        <div class="col-lg-4">
      <label style="float:right;" for="sel1">Employee Id</label>
      
      </div>
    <div class="col-lg-6">
        <asp:TextBox runat="server" ID="emplyeeid" placeholder="Enter Reviewer Id"  class="form-control"></asp:TextBox>

       <%--<asp:DropDownList runat="server" ID="emplyeeid" AppendDataBoundItems="true" AutoPostBack="true" class="form-control"></asp:DropDownList>--%>
        </div>
     <%--  <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:MatreyPharmaConnectionString %>" SelectCommand="proc_GetInboxdetailsByApproverandReviwer" SelectCommandType="StoredProcedure">
           <SelectParameters>
               <asp:SessionParameter Name="Reviwername" SessionField="Session[&quot;EmpId&quot;]" Type="String" />
           </SelectParameters>
        </asp:SqlDataSource>--%>

   <div class="col-lg-4">
      <label style="float:right;" for="sel1">Reviewer</label>
      
      </div>
    <div class="col-lg-6">
  <asp:DropDownList ID="revi" runat="server" DataSourceID="SqlDataSource2" DataTextField="Reviewer" DataValueField="Reviewer" AppendDataBoundItems="true" AutoPostBack="true" class="form-control">


  </asp:DropDownList>
</div>
       <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MatreyPharmaConnectionString %>" SelectCommand="proc_GetReviwerdetailsByEmpid1" SelectCommandType="StoredProcedure">
           <SelectParameters>
               <asp:SessionParameter Name="EmpId" SessionField="Session[&quot;EmpId&quot;]" Type="String" />
           </SelectParameters>
        </asp:SqlDataSource>

    <br />
	 <br />
	 <br />
	 <br />
	<%--  <div class="col-lg-4">
      <label style="float:right;" for="sel1">Approver</label>
      
      </div>
    <div class="col-lg-6">
      
     <asp:DropDownList runat="server" ID="appr" DataSourceID="SqlDataSource3" DataTextField="Approver" DataValueField="Approver" AppendDataBoundItems="true" AutoPostBack="true" class="form-control">

     </asp:DropDownList>
      </div>

       <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:MatreyPharmaConnectionString %>" SelectCommand="proc_GetReviwerdetailsByEmpid1" SelectCommandType="StoredProcedure">
           <SelectParameters>
               <asp:SessionParameter Name="EmpId" SessionField="Session[&quot;EmpId&quot;]" Type="String" />
           </SelectParameters>
        </asp:SqlDataSource>--%>
    <br />
        <br />
        <br />
          <div class="col-lg-4">
      <label style="float:right;" for="sel1">Select TaskId</label>
      
      </div>
    <div class="col-lg-6">
      
     <asp:DropDownList runat="server" ID="tasks" DataSourceID="SqlDataSource1" DataTextField="TaskId" DataValueField="TaskId" AppendDataBoundItems="true" AutoPostBack="true" class="form-control">

     </asp:DropDownList>
      </div>

        <div class="col-lg-4">
            <asp:Button runat="server" ID="submit" OnClick="submit_Click" Text="Submit" class="btn btn-default" />
            </div>
         <div class="col-lg-4">
             <asp:Label ID="label1" runat="server"></asp:Label>

             </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MatreyPharmaConnectionString %>" SelectCommand="proc_GetProjectDetailsByEmpid1" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter Name="EmpId" SessionField="Session[&quot;EmpId&quot;]" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
  </form>
  
  
</div>																																																																			</div>
						
</asp:Content>
