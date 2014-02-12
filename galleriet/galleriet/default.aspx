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
                <asp:Panel ID="LoadedPanel" runat="server">Bilden {0} har sparats.</asp:Panel>
            </asp:PlaceHolder>
            <asp:Repeater ID="Repeater" runat="server" ItemType="System.String" SelectMethod="Repeater_GetData">
                <ItemTemplate>
                    <%-- Hyperlink som presenteras som ImageUrl, där Item representerar Filen. NavigateUrl sätter genom "?&variabel=+ item filnamnet i adressfältet" --%>
                    <asp:HyperLink runat="server" Text='<%#: Item%>' ImageUrl='<%#"~/Files/Thumbnails/"+Item %>' NavigateUrl='<%# "?name=" + Item%>'></asp:HyperLink>
                </ItemTemplate>
            </asp:Repeater>

            <%-- Collection of errors --%>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" />
            <%-- Buttons for "fileUpload" wich is a built in "browse type button" and upload is normal button --%>
            <asp:PlaceHolder ID="ButtonPlaceHolder" runat="server">
                <asp:Button ID="Upload" runat="server" Text="Ladda upp" OnClick="Upload_Click" />
                <asp:FileUpload ID="FileUpload" runat="server" />

            </asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
