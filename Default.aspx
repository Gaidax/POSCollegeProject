<%@ Page Language="C#" MasterPageFile="~/BalloonShop.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Welcome to BalloonShop!" %>

<%@ Register Src="UserControls/ProductsList.ascx" TagName="ProductsList" TagPrefix="uc1" %>
<asp:Content ID="content" ContentPlaceHolderID="contentPlaceHolder" Runat="server">
  <span class="CatalogTitle"> </span> 
  
    
  <span class="CatalogDescription" > <p align="center"> </span> <br /> <br />
   <span class="coverimage"> <img src="Images/cover.jpg" height="200px"" width="800px"  > </img> </span> </p>
  <br />
  <uc1:ProductsList ID="ProductsList1" runat="server" />
</asp:Content>

