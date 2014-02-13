<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="galleriet._default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style/style.css" rel="stylesheet" />
</head>
<body>
    <h1>Galleriet</h1>
    <form id="form1" runat="server" defaultbutton="Upload">
        <div class="content">
            <%-- Save Confirmation Message --%>
            <asp:PlaceHolder ID="ConfirmPlaceHolder" runat="server">
                <asp:Literal ID="Literal" runat="server" Visible="false"></asp:Literal>
            </asp:PlaceHolder>

            <%-- Image control --%>
            <div id="image">
                <asp:Image ID="CurrentImage" runat="server" Width="800" />
            </div>

            <%-- Repeater generating thumbnails with properties. --%>
            <div class="thumbnails">
            <asp:Repeater ID="Repeater" runat="server" ItemType="System.String" SelectMethod="Repeater_GetData">
                <ItemTemplate>
                    <%-- Hyperlink which present images throug imageurl, the "Item" is the picture. And Navigateurl "# "?" + Item" expression set filename in browser field. --%>
                    <asp:HyperLink runat="server" Text='<%#: Item%>' ImageUrl='<%#"~/Files/Thumbnails/"+Item %>' NavigateUrl='<%# "?" + Item%>'></asp:HyperLink>
                </ItemTemplate>
            </asp:Repeater>
                </div>
            <%-- Two validators checking a regular expression and not emty filename toward Fileupload control --%>
            <asp:RegularExpressionValidator Visible="false" ID="RegularExpressionValidator1" runat="server" Text="*" ErrorMessage="Bilden måste vara av typen gif|jpg|png" ControlToValidate="Select" Display="Static" ValidationExpression="^.*\.(gif|jpg|png)$"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator Visible="false" ID="RequiredFieldValidator1" runat="server" Text="*" ErrorMessage="Välj först bild, sedan tryck sedan på ladda upp." ControlToValidate="Select"></asp:RequiredFieldValidator>

            <%-- Collection of errors --%>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" />
            <%-- Buttons for "fileUpload" wich is a built in "browse type button" and upload is normal button --%>
            <asp:PlaceHolder ID="ButtonPlaceHolder" runat="server">
                <asp:FileUpload ID="Select" runat="server"  />
                <asp:Button ID="Upload" runat="server" Text="Ladda upp" OnClick="Upload_Click"  />
                <asp:Button ID="DeleteButton" runat="server" Text="Radera" OnClick="DeleteButton_Click" />
            </asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
