using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Diagnostics;

public partial class Product : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    // don't reload data during postbacks
    if (!IsPostBack)
    {
      PopulateControls();
    }
  }

  // Fill the control with data
  private void PopulateControls()
  {
    // Retrieve ProductID from the query string
    string productId = Request.QueryString["ProductID"];

    // stores product details
    ProductDetails pd;
    AverageRating ar;
    RatingDetails rd;
    // Retrieve product details 
    pd = CatalogAccess.GetProductDetails(productId);
    ar = RatingAccess.GetAverageRating(productId);
    rd = RatingAccess.GetProductRatingDetails(productId);
    // Display product details
    titleLabel.Text = pd.Name;
    ratingLabel.Text = ar.rating;
    ratesLabel.Text = ar.rates;
    descriptionLabel.Text = pd.Description;
    priceLabel.Text = String.Format("{0:c}", pd.Price);
    productImage.ImageUrl = "ProductImages/" + pd.Image2FileName;
    // Set the title of the page
    this.Title = BalloonShopConfiguration.SiteName +
                 " : Product : " + pd.Name;
  }

  // Add the product to cart
  protected void addToCartButton_Click(object sender, EventArgs e)
  {
    // Retrieve ProductID from the query string
    string productId = Request.QueryString["ProductID"];
    // Add the product to the shopping cart
    ShoppingCartAccess.AddItem(productId);
  }

  protected void addCommentButton(object sender, EventArgs e)
  {
      string comment = CommentTextBox.Text;
      string productId = Request.QueryString["ProductID"];
      string user = (string)Session["id"];
      if (user != null)
      {
          try { CommentAccess.addComment(comment, productId, user); }
          catch
          {
              Page.Response.Redirect(Page.Request.Url.ToString(), true);
          }

          Server.TransferRequest(Request.Url.AbsolutePath, false);
      }
      Page.Response.Redirect(Page.Request.Url.ToString(), true);
  }

  // Redirects to the previously visited catalog page 
  protected void continueShoppingButton_Click(object sender, EventArgs e)
  {
    // redirect to the last visited catalog page
    object page;
    if ((page = Session["LastVisitedCatalogPage"]) != null)
      Response.Redirect(page.ToString());
    else
      Response.Redirect(Request.ApplicationPath);
  }

  protected void commentList_ItemCommand(Object sender, DataListCommandEventArgs e)
  {
      switch (e.CommandName)
      {
          case "deleteComment":

              int ind = e.Item.ItemIndex;
              Button bt = (Button)DataList2.Items[ind].FindControl("deleteButton");
              string id = bt.CommandArgument.ToString();
              string user = (String)Session["id"];

              CommentAccess.deleteRating(id, user);
              Page.Response.Redirect(Page.Request.Url.ToString(), true);
              break;

      }
  }
}
