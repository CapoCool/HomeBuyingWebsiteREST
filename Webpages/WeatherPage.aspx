<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WeatherPage.aspx.cs" Inherits="Webpages.WeatherPage" %>

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
        <asp:Label runat="server">Enter a zip code below to check local weather!</asp:Label>
    </p>

    <p>
        <asp:TextBox ID="zipBox" runat="server" Width="350px"></asp:TextBox>
    </p>

    <p>
        <asp:Button ID="weatherButton" runat="server" OnClick="weatherButton_Click"  Text="Get Local weather" />

    </p>

    <p>
        <asp:TextBox ID="weatherBox" runat="server" Width="1000px" Height="600px" TextMode="MultiLine" Enabled="False"></asp:TextBox>


    </p>
        </div>
    </form>
</body>
</html>
