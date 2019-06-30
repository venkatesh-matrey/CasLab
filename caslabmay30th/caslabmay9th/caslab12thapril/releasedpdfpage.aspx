<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="releasedpdfpage.aspx.cs" Inherits="caslab12thapril.releasedpdfpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="taskid" runat="server" />
    <asp:GridView ID="GridView3" runat="server" class="table table-striped table-bordered" AutoGenerateColumns="False"  OnRowDataBound="GridView3_RowDataBound"   BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3"   GridLines="Horizontal" DataSourceID="SqlDataSource3">
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <Columns>
                       
                        
                         <asp:BoundField DataField="TaskId" HeaderText="TaskId" SortExpression="TaskId" ItemStyle-Width="100px" />
                         <asp:BoundField DataField="Reviewerstatus" HeaderText="Reviewerstatus" SortExpression="Reviewerstatus"  />
                        <asp:BoundField DataField="Approverstatus" HeaderText="Approverstatus" SortExpression="Approverstatus"  />
                        <asp:BoundField DataField="filename" HeaderText="filename" SortExpression="filename"/>
                    <asp:BoundField DataField="frontpdf" HeaderText="frontpdf" SortExpression="frontpdf" />
                        <asp:BoundField DataField="Reviewer" HeaderText="Reviewer" SortExpression="Reviewer"/>
                       
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
                                           <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:MatreyPharmaConnectionString %>" SelectCommand="SELECT [TaskId], [Reviewerstatus], [Approverstatus], [filename], [frontpdf], [Reviewer] FROM [Inboxdetails] WHERE (([Reviewer] = @Reviewer) AND ([Reviewerstatus] = @Reviewerstatus) AND ([Approverstatus] = @Approverstatus))">
                                               <SelectParameters>
                                                   <asp:SessionParameter Name="Reviewer" SessionField="Reviewer" Type="String" />
                                                   <asp:QueryStringParameter DefaultValue="ACCEPTED" Name="Reviewerstatus" QueryStringField="ACCEPTED" Type="String" />
                                                   <asp:QueryStringParameter DefaultValue="RELEASED" Name="Approverstatus" QueryStringField="RELEASED" Type="String" />
                                               </SelectParameters>
                                           </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
