<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsPage.aspx.cs" Inherits="Webpages.NewsPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>News Check Page! </h2>
    <p>
        <asp:Label runat="server">Enter a state below to check local news!</asp:Label>
    </p>

    <p>
        <asp:Label runat ="server">State: </asp:Label>
        <asp:TextBox ID="zipBox" runat="server" Width="350px"></asp:TextBox>
    </p>

    <p>
        <asp:Button ID="newsButton" runat="server" OnClick="newsButton_Click"  Text="Get Local News" />
        <asp:Button ID="previousDataButton" runat ="server" OnClick="previousDataButton_Click" Text="Get Previous Data" />

    </p>

    <p>
        <asp:TextBox ID="newsBox" runat="server" Width="1000px" Height="600px" TextMode="MultiLine" Enabled="False"></asp:TextBox>


    </p>
        </div>
    </form>
</body>
</html>
