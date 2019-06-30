<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewPage1.aspx.cs" Inherits="caslab12thapril.ViewPage1" EnableEventValidation="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
                                            <table class="auto-style1">
            <tr>
                <td class="auto-style2">SELECT TASK ID</td>
                <td> <asp:DropDownList runat="server" ID="taskids"  AutoPostBack="true" AppendDataBoundItems="true" class="list-group-item" OnSelectedIndexChanged="taskids_SelectedIndexChanged"></asp:DropDownList>

                </td>
            </tr>
            
                <td class="auto-style2">&nbsp;</td>
                                                
                   <asp:Panel ID="Panel1" runat="server" Visible="False">
            <div class="auto-style3">
                <div class="auto-style4">
                    <strong>
                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="25px" Text="Task Details"></asp:Label>
                    </strong>
                    <br />
                </div>
               
                <div class="col-lg-1">
      <label style="float:right;" for="sel1">EmployeeId</label>
      
      </div>
    <div class="col-lg-2">
   <asp:TextBox runat="server" ID="employeeid" ReadOnly="true" class="form-control"></asp:TextBox>      
      </div>

                <table class="auto-style5">
                    <tr>
                        <td class="auto-style6">TASK ID</td>
                        <td class="auto-style3">
                            <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                  
                      
                    <tr>
                        <td class="auto-style6">TASK TITLE</td>
                        <td class="auto-style3">
                            <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6">TASK DESCRIPTION</td>
                        <td class="auto-style3">
                            <asp:Label ID="Label12" runat="server"></asp:Label>
                        </td>
                    </tr>

                     <tr>
                        <td class="auto-style6">CHEMICAL</td>
                        <td class="auto-style3">
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td class="auto-style6">QUNTATITY</td>
                        <td class="auto-style3">
                            <asp:Label ID="Label2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6">UNITS</td>
                        <td class="auto-style3">
                            <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="TaskId" HeaderText="TASK ID" />
                        <asp:BoundField DataField="ProjectId" HeaderText="PROJECT ID" />
                        <asp:BoundField DataField="TaskTitle" HeaderText="TASK TITLE" />
                        <asp:BoundField DataField="Chemical" HeaderText="CHEMICAL" />
                        <asp:BoundField DataField="Quantatity" HeaderText="QUNTATITY" />
                        <asp:BoundField DataField="Units" HeaderText="UNITS" />
                    </Columns>
                </asp:GridView>
             
                    <br />
                   
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />




                     </asp:Panel>                                    

</asp:Content>
