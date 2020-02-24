using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

public partial class CancelTeeTimeReservation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int MemberNumber = 0;
            ClubBAISTRequestDirector CBRD = new ClubBAISTRequestDirector();
            try
            {
                MemberNumber = int.Parse(Session["MemberNumber"].ToString());
            }
          }


            catch (Exception)
            {

                Response.Redirect("~/Logon.aspx");
            }

            CBRD.DisplayMemberReservations(MemberNumber, ReservationList);
        }
    }
    protected void CancelReservation_Click(object sender, EventArgs e)
    {
        string SelectedItem = ReservationList.SelectedItem.Value;
        DateTime reservation = DateTime.Parse(SelectedItem);
        ClubBAISTRequestDirector CBRD = new ClubBAISTRequestDirector();
        Message.Text = CBRD.CancelReservation(reservation, reservation, int.Parse(Session["MemberNumber"].ToString())).ToString();
    }
    protected void SignOut_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Session["MemberNumber"] = null;
        Response.Redirect("~/Logon.aspx");
    }
}
