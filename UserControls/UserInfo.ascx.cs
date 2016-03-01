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

public partial class UserInfo : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userName = (string)Session["name"];
        string state = "Logout";
        Button bt = (Button)LoginView1.FindControl("LoginButton");
        if (userName == null)
        {
            userName = "Stranger";
            state = "Login";
            
        }
        Label userLabel = (Label)LoginView1.FindControl("userLabel");
        userLabel.Text ="Welcome, "+userName;     
        bt.Text = state;
           }


    protected void Logout(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("Login.aspx");
    }
}
