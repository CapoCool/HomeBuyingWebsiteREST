<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PollutionPage.aspx.cs" Inherits="Webpages.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Pollution Check Page! </h2>
    <p>
        <asp:Label runat="server">Enter a zip code below to check pollution!</asp:Label>
    </p>

    <p>
        <asp:TextBox ID="zipBox" runat="server" Width="350px"></asp:TextBox>
    </p>

    <p>
        <asp:Button ID="PollutionButton" runat="server" OnClick="PollutionButton_Click"  Text="Get Pollution" />

    </p>

    <p>
        <asp:TextBox ID="pollutionBox" runat="server" Width="1000px" Height="600px" TextMode="MultiLine" Enabled="False"></asp:TextBox>


    </p>
        </div>
    </form>
</body>
</html>
