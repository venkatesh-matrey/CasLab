<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editor.aspx.cs" Inherits="caslab12thapril.editor"   %>





<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   
    <script src="https://cdn.ckeditor.com/4.11.4/full/ckeditor.js"></script>
   <%-- <script src="scripts/customckeditor.js"></script>--%>
    <script>
        CKEDITOR.plugins.addExternal('save-to-pdf', 'https://rawgit.com/Api2Pdf/api2pdf.ckeditor4/master/plugins/save-to-pdf/', 'plugin.js');
        
    </script>
    
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Textbox id="newtext" runat="server">
            
        </asp:Textbox>
         <asp:Button runat="server" ID="backbutton" Text="Back"   class="btn btn-primary" OnClick="backbutton_Click" />
      <asp:Label ID="taskid" runat="server"  Visible="false"/>
        <asp:Label ID="labeldata" runat="server" Visible="false" />
          <script type="text/javascript">
              CKEDITOR.replace('newtext',
                 {
                     extraPlugins: 'save-to-pdf',
                     pdfHandler: '/SaveToPdf.ashx',

                 });
             
              



            
        </script>
    </div>
    </form>
</body>
</html>

