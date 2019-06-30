<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ReviewerNotifications.aspx.cs" Inherits="caslab12thapril.Notifications" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="col-lg-1">
      <label style="float:right;" for="sel1">EmployeeId</label>
      
      </div>
    <div class="col-lg-2">
   <asp:TextBox runat="server" ID="employeeid" ReadOnly="true" class="form-control"></asp:TextBox>      
      </div>
      <table class="auto-style1">
            <tr>
                <td class="auto-style2">SELECT TASK ID</td>
                <td> <asp:DropDownList runat="server" ID="taskids"  AutoPostBack="true" AppendDataBoundItems="true" class="list-group-item" OnSelectedIndexChanged="taskids_SelectedIndexChanged"></asp:DropDownList>

                </td>
            </tr>
          </table>
     <br />
    <br />
      <asp:Panel ID="Panel1" runat="server" Visible="False">
     <table class="auto-style5">
                    <tr>
                        <td class="auto-style6">TASK ID</td>
                        <td class="auto-style3">
                            <asp:Label ID="Label1" runat="server" ></asp:Label>
                        </td>
                    </tr>
          <tr>
                        <td class="auto-style6">Reviewer Status</td>
                        <td class="auto-style3">
                            <asp:Label ID="Label2" runat="server" ></asp:Label>
                        </td>
                    </tr>

          <tr>
                        <td class="auto-style6">Reviewer comments</td>
                        <td class="auto-style3">
                            <asp:Label ID="Label3" runat="server" ></asp:Label>
                        </td>
                    </tr>
         </table>
          </asp:Panel>
</asp:Content>
