using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

public partial class HomePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int MemberNumber = 0;
            try
            {
                MemberNumber = int.Parse(Session["MemberNumber"].ToString());
            }
            catch (Exception)
            {

                Response.Redirect("~/Logon.aspx");
            }

        }
    }
    protected void SignOut_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Session["MemberNumber"] = null;
        Response.Redirect("~/Logon.aspx");
    }
}
