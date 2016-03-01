<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductRecommendations.ascx.cs" Inherits="ProductRecommendations" %>
<asp:Label ID="recommendationsHeader" runat="server" CssClass="RecommendationHead" ForeColor="White" />
<asp:DataList ID="list" runat="server" CellPadding="4" ForeColor="#333333">
    <AlternatingItemStyle BackColor="White" />
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <ItemStyle BackColor="#EFF3FB" />
  <ItemTemplate>
    <table cellpadding="0" cellspacing="0">
      <tr>
        <td width="170px">
          <a class="RecommendationLink" href='Product.aspx?ProductID=<%# Eval("ProductID") %>'>
            <%# Eval("Name") %>
          </a>  
        </td>
        <td class="RecommendationText" valign="top">
          <%# Eval("Description") %>
        </td>
      </tr>
    </table>
  </ItemTemplate>
    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
</asp:DataList>
