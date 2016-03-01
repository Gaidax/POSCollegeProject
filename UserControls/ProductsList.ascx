<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductsList.ascx.cs"
  Inherits="ProductsList"%>
<style type="text/css">
    .auto-style1 {
        width: 120px;
    }
</style>
<asp:Label ID="pagingLabel" runat="server" CssClass="PagingText" Visible="false" />
&nbsp;&nbsp;
<asp:HyperLink ID="previousLink" runat="server" CssClass="PagingText" Visible="false">Previous</asp:HyperLink>
&nbsp;&nbsp;
<asp:HyperLink ID="nextLink" runat="server" CssClass="PagingText" Visible="false">Next</asp:HyperLink>
<asp:DataList ID="list" Runat="server" RepeatColumns="2" EnableViewState="False" OnItemCommand="DataList_ItemCommand">
  <ItemTemplate>
    <table cellPadding="0" align="left" style="height: 143px">
      <tr height="105">
        <td align="center" class="auto-style1">
          <a href='Product.aspx?ProductID=<%# Eval("ProductID")%>'>
            <img width="100" src='ProductImages/<%# Eval("Thumbnail") %>' border="0"/>
          </a>
        </td>
        <td vAlign="top" width="250">
          <a class="ProductName" href='Product.aspx?ProductID=<%# Eval("ProductID")%>'>
            <%# Eval("Name") %>
          </a>
          <br/>
          <span class="ProductDescription">
            <%# Eval("Description") %>
            <br/><br/>
            Price: 
          </span>
          <span class="ProductPrice">
            <%# Eval("Price", "{0:c}") %>
          </span>
          <br />
          <asp:Button ID="addToCartButton" runat="server" CommandName="list_ItemCommand" Text="Add to Cart" CommandArgument='<%# Eval("ProductID") %>' CssClass="SmallButtonText"/>
            <br />
          <span class="ProductDescription">
            <asp:Label ID="ratingLabel" runat="server" ToolTip='<%# Eval("ProductID") %>'></asp:Label>
            <br />
            Rated: <asp:Label ID="ratesLabel" runat="server" ToolTip="Rating"></asp:Label> times
              </span>
           <br />
            &nbsp;<span class="ProductDescription">
                <asp:ListBox ID="RatingBox" runat="server" Height="80px" Width="31px">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
            </asp:ListBox>
            <asp:Button ID="addRatingButton" runat="server" CommandName="rate_Command" CommandArgument='<%# Eval("ProductID") %>' CssClass="SmallButtonText" Text="Rate" />
            </span>
        </td>
      </tr>
    </table>
  </ItemTemplate>

</asp:DataList>
