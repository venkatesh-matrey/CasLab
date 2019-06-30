<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="status.aspx.cs" Inherits="caslab12thapril.status" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-11">
  <br/>
	  <br/><br/>
	  <br/>
   <div class="col-lg-4">
      
       <asp:label style="float:right;" runat="server" id="reviewerdata"  ></asp:label>
      <asp:label style="float:right;" runat="server" id="taskid"  ></asp:label>
       <asp:label style="float:right;" runat="server" id="taskstatus" ></asp:label> 
      </div>
    <div class="col-lg-6">
       
      </div>
	  </div>
</asp:Content>
