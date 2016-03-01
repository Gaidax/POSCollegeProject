<%@ Page Language="C#" MasterPageFile="~/BalloonShop.master" AutoEventWireup="true"
  CodeFile="Product.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="Product" Title="Untitled Page" %>

<%@ Register Src="UserControls/ProductRecommendations.ascx" TagName="ProductRecommendations"
  TagPrefix="uc1" %>
<asp:Content ID="content" ContentPlaceHolderID="contentPlaceHolder" runat="Server">
    <br />
  <asp:Label CssClass="ProductTitle" ID="titleLabel" runat="server" Text="Label"></asp:Label>
  <br />
  <br />
  <asp:Image ID="productImage" runat="server" />
  <br />
  <asp:Label CssClass="ProductDescription" ID="descriptionLabel" runat="server" Text="Label"></asp:Label>
  <br />
  <br />
  <span class="ProductDescription">Price:</span>&nbsp;
  <asp:Label CssClass="ProductPrice" ID="priceLabel" runat="server" Text="Label" />
  <br />
  <asp:Button ID="addToCartButton" runat="server" Text="Add to Cart" CssClass="SmallButtonText" OnClick="addToCartButton_Click" />
  <asp:Button ID="continueShoppingButton" CssClass="SmallButtonText" runat="server" Text="Continue Shopping" OnClick="continueShoppingButton_Click" />
  <br />
  <span class="ProductDescription">Rating:</span>&nbsp;
  <asp:Label CssClass="ProductPrice" ID="ratingLabel" runat="server" Text="Label" />
  <br />
    <span class="ProductDescription">Rated:</span>&nbsp;
    <asp:Label CssClass="ProductPrice" ID="ratesLabel" runat="server" Text="Label" />
    <br />
    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333">
        <AlternatingItemStyle BackColor="White" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <ItemStyle BackColor="#E3EAEB" />
        <ItemTemplate>
            One:
            <asp:Label ID="OneLabel" runat="server" Text='<%# Eval("One") %>' />
            <br />
            Two:
            <asp:Label ID="TwoLabel" runat="server" Text='<%# Eval("Two") %>' />
            <br />
            Three:
            <asp:Label ID="ThreeLabel" runat="server" Text='<%# Eval("Three") %>' />
            <br />
            Four:
            <asp:Label ID="FourLabel" runat="server" Text='<%# Eval("Four") %>' />
            <br />
<br />
        </ItemTemplate>
        <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BalloonShopConnectionString %>" SelectCommand="getRatingDetailsList" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="ProductID" QueryStringField="ProductID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:TextBox ID="CommentTextBox" runat="server" Height="86px" Width="206px"></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="addCommentButton" Text="Add Comment" />
    <br />
    <br />
    <asp:DataList ID="DataList2" runat="server"  AllowPaging="true" PageSize="3" OnItemCommand="commentList_ItemCommand" DataSourceID="SqlDataSource2" CellPadding="4" ForeColor="#333333">
        <AlternatingItemStyle BackColor="White" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <ItemStyle BackColor="#E3EAEB" />
        <ItemTemplate>
            <br />
            <asp:Label ID="First_NameLabel" runat="server" Text='<%# Eval("First_Name") %>' />
            &nbsp;<asp:Label ID="Last_NameLabel" runat="server" Text='<%# Eval("Last_Name") %>' />
            &nbsp; wrote:<br /> &nbsp;<br /> <asp:Label ID="CommentLabel" runat="server" Text='<%# Eval("Comment") %>' />
            <br />
            <br />
            <asp:Button ID="deleteButton"  CommandName="deleteComment" runat="server" Text="Delete" CommandArgument='<%# Eval("id") %>' />
            <br />
        </ItemTemplate>
        <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:BalloonShopConnectionString %>" SelectCommand="SELECT [Comment].[id], [Comment], [First_Name], [Last_Name] FROM [Comment], [Client] WHERE ([product_id] = @product_id and [client_id] =[Client].[id])">
        <SelectParameters>
            <asp:QueryStringParameter Name="product_id" QueryStringField="ProductID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <br />
  <uc1:ProductRecommendations id="ProductRecommendations1" runat="server">
  </uc1:ProductRecommendations>
  </asp:Content>
