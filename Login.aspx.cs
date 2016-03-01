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

public partial class Login : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    // get references to the button, checkbox and textboxes
    TextBox usernameTextBox = (TextBox)login.FindControl("UserName");
    TextBox passwordTextBox = (TextBox)login.FindControl("Password");
    CheckBox persistCheckBox = (CheckBox)login.FindControl("RememberMe");
    Button loginButton = (Button)login.FindControl("LoginButton");
    //Label WelcomeBackMessage = (Label)login.FindControl("WelcomeBackMessage");
    
    //String s = usernameTextBox.Text;
    // tie the two textboxes and the checkbox to the button
    Utilities.TieButton(this.Page, usernameTextBox, loginButton);
    Utilities.TieButton(this.Page, passwordTextBox, loginButton);
    Utilities.TieButton(this.Page, persistCheckBox, loginButton);
    // set the page title
    this.Title = BalloonShopConfiguration.SiteName + " : Login";
    // set focus on the username textbox when the page loads
    usernameTextBox.Focus();
  }

  protected void Login1_Authenticate(object sender, EventArgs e)
  {

      TextBox usernameTextBox = (TextBox)login.FindControl("UserName");
      TextBox passwordTextBox = (TextBox)login.FindControl("Password");
      Literal lit = (Literal)login.FindControl("FailureText");
      CheckBox persistCheckBox = (CheckBox)login.FindControl("RememberMe");
      String username = usernameTextBox.Text;
      String password = passwordTextBox.Text;
      Client cl = new Client();
      cl = UserAccess.LoginClient(username, password);
      
      if (cl.id==null) { 
          lit.Text = "Failed to find a user";
          lit.EnableViewState = true;
      }
      else
      {
          Session["name"] = cl.firstName;
          Session["lastname"] = cl.lastName;
          Session["id"] = cl.id;
          //FormsAuthentication.SetAuthCookie(cl.id, persistCheckBox.Checked);
          Response.Redirect("/Default.aspx");
      }
  }

}
