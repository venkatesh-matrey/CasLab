<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="viewstatus.aspx.cs" Inherits="caslab12thapril.viewstatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-11">
  <br/>
	  <br/><br/>
	  <br/>
   <div class="col-lg-4">
      <asp:label  runat="server" id="userdata" Visible="false"  ></asp:label>
       <asp:label  runat="server" id="reviewerdata" Visible="false"  ></asp:label>
      <asp:label  runat="server" id="taskid"  Visible="false"></asp:label>
       <asp:label  runat="server" id="taskstatus"  Visible="false"></asp:label> 
      </div>
    <div class="col-lg-6">
       <asp:GridView ID="GridView1" runat="server" class="table table-striped table-bordered" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound"  BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" DataSourceID="SqlDataSource1">
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <Columns>
                       
                        <asp:BoundField DataField="TaskId" HeaderText="TaskId" SortExpression="TaskId" />
                        <asp:BoundField DataField="Reviewerstatus" HeaderText="Reviewerstatus" SortExpression="Reviewerstatus"/>
                         <asp:BoundField DataField="Status" HeaderText="Approverstatus" SortExpression="Status"/>
                      
                    </Columns>
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <SortedAscendingCellStyle BackColor="#F4F4FD" />
                    <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                    <SortedDescendingCellStyle BackColor="#D8D8F0" />
                    <SortedDescendingHeaderStyle BackColor="#3E3277" />
                </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MatreyPharmaConnectionString %>" SelectCommand="SELECT distinct [TaskId], [Reviewerstatus], [Status] FROM [Inboxdetails] WHERE ([EmployeeName] = @EmployeeName)">
            <SelectParameters>
                <asp:SessionParameter Name="EmployeeName" SessionField="UserName" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
      </div>
	  </div>
</asp:Content>
 