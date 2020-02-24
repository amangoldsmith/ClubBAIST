using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class CancelStandingTeeTimeReservation : System.Web.UI.Page
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
        if (!(bool)Session["IsShareholder"])
        {
            Cancel.Visible = false;
            Message.Text = "You Are Not Allowed to Cancel Standing Tee Time Reservation Because You are not a Shareholder";
            Message.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        ClubBAISTRequestDirector CBRD = new ClubBAISTRequestDirector();
        Message.Text = CBRD.CancelStandingReservation(int.Parse(Session["MemberNumber"].ToString()), DateTime.Now.Year).ToString();
    }

    protected void SignOut_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Session["MemberNumber"] = null;
        Response.Redirect("~/Logon.aspx");
    }
}
