 <%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Webpages._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>House Check Page! </h2>
    <p>
        <asp:Label runat="server">Enter a zip code below To check the local new, pollution, and weather!</asp:Label>
    </p>

    <p>
        <asp:Label runat="server">Zipcode: </asp:Label>
        <asp:TextBox ID ="zipBox" runat="server" Width ="350px"></asp:TextBox>
    </p>

    <p>
        <asp:Button ID="forecastButton" runat="server" OnClick="forecastButton_Click" Text="Get Forecast" />
        <asp:Button ID="newsButton" runat="server" OnClick="newsButton_Click" Text="Get Local News" />
        <asp:Button ID="PollutionButton" runat="server" OnClick="PollutionButton_Click"  Text="Get Pollution" />

    </p>

</asp:Content>
