<%@ Page Language="C#" MasterPageFile="~/BalloonShop.master" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="ShoppingCart" Title="Untitled Page" %>

<%@ Register Src="UserControls/ProductRecommendations.ascx" TagName="ProductRecommendations"
  TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder" Runat="Server">
    <asp:Label ID="titleLabel" runat="server" Text="Your Shopping Cart" CssClass="ShoppingCartTitle" />
  <br />
  <asp:Label ID="statusLabel" CssClass="AdminPageText" ForeColor="Red" runat="server" /><br />
  <asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID" Width="100%" BorderWidth="0px" OnRowDeleting="grid_RowDeleting">
    <Columns>
      <asp:BoundField DataField="Name" HeaderText="Product Name" ReadOnly="True" SortExpression="Name" >
        <ControlStyle Width="100%" />
      </asp:BoundField>
      <asp:BoundField DataField="Price" DataFormatString="{0:c}" HeaderText="Price" ReadOnly="True"
        SortExpression="Price" />
      <asp:TemplateField HeaderText="Quantity">
        <ItemTemplate>
          <asp:TextBox ID="editQuantity" runat="server" CssClass="GridEditingRow" Width="24px" MaxLength="2" Text='<%#Eval("Quantity")%>' />
        </ItemTemplate>
      </asp:TemplateField>
      <asp:BoundField DataField="Subtotal" DataFormatString="{0:c}" HeaderText="Subtotal"
        ReadOnly="True" SortExpression="Subtotal" />
      <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" >
        <ControlStyle CssClass="SmallButtonText " />
      </asp:ButtonField>
    </Columns>
  </asp:GridView>
  <table width="100%">
    <tr>
      <td>
        <span class="ProductDescription">
          Total amount:
        </span>
        <asp:Label ID="totalAmountLabel" runat="server" Text="Label" CssClass="ProductPrice" />
          <asp:Label ID="RandLabel" Visible ="false" runat="server" Text= '<%# offerId %>' CssClass="ProductPrice" />
      </td>
      <td align="right">
        <asp:Button ID="updateButton" runat="server" Text="Update Quantities" CssClass="SmallButtonText" OnClick="updateButton_Click" />
        <asp:Button ID="checkoutButton" runat="server" CssClass="SmallButtonText" Text="Proceed to Checkout" OnClick="checkoutButton_Click" />
      </td>
    </tr>
  </table>
  <br />
  <asp:Button ID="continueShoppingButton" runat="server" Text="Continue Shopping" CssClass="SmallButtonText" OnClick="continueShoppingButton_Click" /><br />
  <br />
  <uc1:ProductRecommendations id="ProductRecommendations1" runat="server">
  </uc1:ProductRecommendations>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:TemplateField HeaderText="Thumbnail" SortExpression="Thumbnail">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Thumbnail") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# "/Images/"+Eval("Thumbnail") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
   
   
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BalloonShopConnectionString %>" SelectCommand="SELECT * FROM [Offer] WHERE ([OfferID] = @OfferID)">
        <SelectParameters>
            <asp:ControlParameter ControlID="RandLabel" Name="OfferID" PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
   
   
</asp:Content>
