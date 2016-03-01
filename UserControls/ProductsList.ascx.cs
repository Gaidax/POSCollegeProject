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
using System.Collections.Specialized;
using System.Diagnostics;

public partial class ProductsList : System.Web.UI.UserControl
{
  protected void Page_Load(object sender, EventArgs e)
  {
    PopulateControls();
  }

  private void PopulateControls()
  {
    // Retrieve DepartmentID from the query string
    string departmentId = Request.QueryString["DepartmentID"];
    // Retrieve CategoryID from the query string
    string categoryId = Request.QueryString["CategoryID"];
    // Retrieve Page from the query string
    string productID = Request.QueryString["ProductID"];
    string page = Request.QueryString["Page"];
    if (page == null) page = "1";
    // Retrieve Search string from query string
    string searchString = Request.QueryString["Search"];
    // How many pages of products?
    int howManyPages = 1;
    // If performing a product search
    if (searchString != null)
    {
      // Retrieve AllWords from query string
      string allWords = Request.QueryString["AllWords"];
      // Perform search
      list.DataSource = CatalogAccess.Search(searchString, allWords, page, out howManyPages);
      list.DataBind();
      getRating();
    }
    // If browsing a category...
    else if (categoryId != null)
    {
      // Retrieve list of products in a category
      list.DataSource = CatalogAccess.GetProductsInCategory(categoryId, page, out howManyPages);
      list.DataBind();
      getRating();

    }
    else if (departmentId != null)
    {
      // Retrieve list of products on department promotion
      list.DataSource = CatalogAccess.GetProductsOnDepartmentPromotion(departmentId, page, out howManyPages);
      list.DataBind();
      getRating();
    }
    else
    {
      // Retrieve list of products on catalog promotion
      //list.DataSource = CatalogAccess.GetProductsOnCatalogPromotion(page, out howManyPages);
      list.DataBind();
      getRating();
    }
    // display paging controls
    if (howManyPages > 1)
    {
      // have the current page as integer
      int currentPage = Int32.Parse(page);
      // make controls visible
      pagingLabel.Visible = true;
      previousLink.Visible = true;
      nextLink.Visible = true;
      // set the paging text
      pagingLabel.Text = "Page " + page + " of " + howManyPages.ToString();
      // create the Previous link
      if (currentPage == 1)
        previousLink.Enabled = false;
      else
      {
        NameValueCollection query = Request.QueryString;
        string paramName, newQueryString = "?";
        for (int i = 0; i < query.Count; i++)
          if (query.AllKeys[i] != null)
            if ((paramName = query.AllKeys[i].ToString()).ToUpper() != "PAGE")
              newQueryString += paramName + "=" + query[i] + "&";
        previousLink.NavigateUrl = Request.Url.AbsolutePath + newQueryString + "Page=" + (currentPage - 1).ToString();
      }
      // create the Next link
      if (currentPage == howManyPages)
        nextLink.Enabled = false;
      else
      {
        NameValueCollection query = Request.QueryString;
        string paramName, newQueryString = "?";
        for (int i = 0; i < query.Count; i++)
          if (query.AllKeys[i] != null)
            if ((paramName = query.AllKeys[i].ToString()).ToUpper() != "PAGE")
              newQueryString += paramName + "=" + query[i] + "&";
        nextLink.NavigateUrl = Request.Url.AbsolutePath + newQueryString + "Page=" + (currentPage + 1).ToString();
      }
    }
  }


  protected void DataList_ItemCommand(Object sender, DataListCommandEventArgs e)
  {
      if (e.CommandName == "rate_Command")
      {
          int ind = e.Item.ItemIndex;
          Button bt = (Button)list.Items[ind].FindControl("addRatingButton");
          ListBox rt = (ListBox)list.Items[ind].FindControl("RatingBox");
          string rate = rt.Text;
          string productId = bt.CommandArgument.ToString();
          string user = (string)Session["id"];
          Debug.Write(user);
          if (RatingAccess.AddRating(productId, user, rate))
          {
              getRating();
          }

      }
      else
      {
          string productID = e.CommandArgument.ToString();
          // Add the product to the shopping cart
          ShoppingCartAccess.AddItem(productID);
      }
  }

  protected void getRating()
  {

      foreach (DataListItem item in list.Items)
      {
          AverageRating rat = new AverageRating();
          Label ratingLabel = (Label)item.FindControl("ratingLabel");
          Label ratesLabel = (Label)item.FindControl("ratesLabel");
          
          rat= RatingAccess.GetAverageRating(ratingLabel.ToolTip);

          ratesLabel.Text = rat.rates;
          ratingLabel.Text = rat.rating;
      }
  }
}