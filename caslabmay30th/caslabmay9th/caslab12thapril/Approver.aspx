<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Approver.aspx.cs" Inherits="caslab12thapril.Approver" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="col-lg-11">
   <form>
       

         <div class="col-lg-4">
      <label style="float:right;" for="sel1">Approver Id</label>
      
      </div>
    <div class="col-lg-6">
        <asp:TextBox runat="server" ID="employeeid" placeholder="Enter Approver Employee Id"  class="form-control"></asp:TextBox>
        </div>
                <br />
                <br />
                <div class="col-lg-4">
      <label style="float:right;" for="sel1">Approver</label>
      
      </div>
    <div class="col-lg-6">
     


     <asp:DropDownList runat="server" ID="appr" DataSourceID="SqlDataSource3" DataTextField="Approver" DataValueField="Approver" AppendDataBoundItems="true" AutoPostBack="true" class="form-control">

     </asp:DropDownList>
      </div>

      <br />
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

<asp:RadioButtonList ID="status" runat="server">
     <asp:ListItem Text="Accept"  />
    <asp:ListItem Text="Reject"  />
 </asp:RadioButtonList>
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
                                        
                                         <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:MatreyPharmaConnectionString %>" SelectCommand="proc_GetReviwerdetailsByEmpid1" SelectCommandType="StoredProcedure">
           <SelectParameters>
               <asp:SessionParameter Name="EmpId" SessionField="Session[&quot;EmpId&quot;]" Type="String" />
           </SelectParameters>
        </asp:SqlDataSource>
            <asp:SqlDataSource runat="server" ID="Sqldatasource2" ConnectionString="<%$ ConnectionStrings:MatreyPharmaConnectionString %>" SelectCommand="proc_GetReviewerTaskDetailsByEmpid" SelectCommandType="StoredProcedure">
                                                 <SelectParameters>
                                                     <asp:SessionParameter Name="EmpId" SessionField="Session[&quot;EmpId&quot;]" Type="String" />
                                                 </SelectParameters>
                                                </asp:SqlDataSource>                        
  </form>
  
  
</div>																						

</asp:Content>
