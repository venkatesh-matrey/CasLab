<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EmployeesList.aspx.cs" Inherits="caslab12thapril.EmployeesList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <br /><br />
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" class="table table-striped table-bordered"
  ForeColor="#333333" GridLines="None">
                          <AlternatingRowStyle BackColor="White" />
                          <Columns>
                              <asp:TemplateField HeaderText="EmpId">
                                  <EditItemTemplate>
                                      <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("EmpId") %>'></asp:TextBox>
                                  </EditItemTemplate>
                                  <ItemTemplate>
                                      <asp:Label ID="Label1" runat="server" Text='<%# Bind("EmpId") %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="EmpName">
                                  <EditItemTemplate>
                                      <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("EmpName") %>'></asp:TextBox>
                                  </EditItemTemplate>
                                  <ItemTemplate>
                                      <asp:Label ID="Label2" runat="server" Text='<%# Bind("EmpName") %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Email">
                                  <EditItemTemplate>
                                      <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                                  </EditItemTemplate>
                                  <ItemTemplate>
                                      <asp:Label ID="Label3" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="UserName">
                                  <EditItemTemplate>
                                      <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("UserName") %>'></asp:TextBox>
                                  </EditItemTemplate>
                                  <ItemTemplate>
                                      <asp:Label ID="Label4" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Password">
                                  <EditItemTemplate>
                                      <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Password") %>'></asp:TextBox>
                                  </EditItemTemplate>
                                  <ItemTemplate>
                                      <asp:Label ID="Label5" runat="server" Text='<%# Bind("Password") %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              
                              <asp:TemplateField HeaderText="Reviewer">
                                  <EditItemTemplate>
                                       <asp:CheckBox ID="reviewerlabel" runat="server" />
                                  </EditItemTemplate>
                                   <ItemTemplate>
                                      <asp:CheckBox ID="reviewerlabel" runat="server" />
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Approver">
                                  <EditItemTemplate>
                                      <asp:CheckBox ID="approverlabel" runat="server" />
                                  </EditItemTemplate>
                                   <ItemTemplate>
                                      <asp:CheckBox ID="approverlabel" runat="server" />
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Position">
                                  <EditItemTemplate>
                                      <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("position") %>'></asp:TextBox>
                                  </EditItemTemplate>
                                  <ItemTemplate>
                                      <asp:Label ID="Label6" runat="server" Text='<%# Bind("position") %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
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

    <asp:button runat="server" ID="save" text="SAVE"  style="margin-left:474px" class="btn btn-primary" OnClick="save_Click1" CausesValidation="false"></asp:button>
</asp:Content>
