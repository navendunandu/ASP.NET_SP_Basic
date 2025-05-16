<%@ Page Title="" Language="C#" MasterPageFile="~/Basics/BasicMaster.master" AutoEventWireup="true" CodeFile="ImageMap.aspx.cs" Inherits="Basics_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ImageMap ID="ImageMap1" runat="server" ImageUrl="https://www.mapsofindia.com/world-map/world-political-map-2020.jpg" HotSpotMode="Navigate">
    <asp:CircleHotSpot X="1300" Y="50" Radius="30" NavigateUrl="https://en.wikipedia.org/wiki/North_America" AlternateText="North America" />
    <asp:RectangleHotSpot Left="150" Top="100" Right="250" Bottom="200" NavigateUrl="https://en.wikipedia.org/wiki/South_America" AlternateText="South America" />
    <asp:PolygonHotSpot Coordinates="300,50,350,100,320,150" NavigateUrl="https://en.wikipedia.org/wiki/Europe" AlternateText="Europe" />
</asp:ImageMap>

</asp:Content>

