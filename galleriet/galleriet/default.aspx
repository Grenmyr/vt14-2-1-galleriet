<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="galleriet._default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Galleriet</h1>
    <form id="form1" runat="server">
        <div>
             <%-- Save Message --%>
            <asp:PlaceHolder ID="ConfirmPlaceHolder" runat="server">
                <asp:Panel ID="LoadedPanel" runat="server" >Bilden {0} har sparats.</asp:Panel>
            </asp:PlaceHolder>
             <%-- Collection of errors --%>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" />
            <%-- Buttons for Brows and upload --%>
            <asp:PlaceHolder ID="ButtonPlaceHolder" runat="server">
                <asp:Button ID="Browse" runat="server" Text="Välj fil" />
                <asp:Button ID="Upload" runat="server" Text="Ladda upp" />
            </asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
