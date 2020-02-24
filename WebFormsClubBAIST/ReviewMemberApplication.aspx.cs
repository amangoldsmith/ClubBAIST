using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
public partial class ReviewMemberApplication : System.Web.UI.Page
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
                Response.Redirect("~/Logpn.aspx");
            }
        }

        ClubBAISTRequestDirector CBRD = new ClubBAISTRequestDirector();
        List<Application> Applications = CBRD.GetApplications();
        foreach (Application item in Applications)
        {

            TableRow Row = new TableRow();
            TableCell Cell = new TableCell();

            Cell.Text = item.ApplicationID.ToString();
            Row.Cells.Add(Cell);

            Cell = new TableCell();
            Cell.Text = item.LastName;
            Row.Cells.Add(Cell);

            Cell = new TableCell();
            Cell.Text = item.FirstName;
            Row.Cells.Add(Cell);

            Cell = new TableCell();
            Cell.Text = item.Address;
            Row.Cells.Add(Cell);

            Cell = new TableCell();
            Cell.Text = item.PostalCode;
            Row.Cells.Add(Cell);

            Cell = new TableCell();
            Cell.Text = item.Phone;
            Row.Cells.Add(Cell);

            Cell = new TableCell();
            Cell.Text = item.AltPhone;
            Row.Cells.Add(Cell);

            Cell = new TableCell();
            Cell.Text = item.Email;
            Row.Cells.Add(Cell);

            Cell = new TableCell();
            Cell.Text = item.BirthDate.ToShortDateString();
            Row.Cells.Add(Cell);

            Cell = new TableCell();
            Cell.Text = item.Occupation;
            Row.Cells.Add(Cell);

            Cell = new TableCell();
            Cell.Text = item.CompanyName;
            Row.Cells.Add(Cell);

            Cell = new TableCell();
            Cell.Text = item.CompanyAddress;
            Row.Cells.Add(Cell);

            Cell = new TableCell();
            Cell.Text = item.CompanyPostalCode;
            Row.Cells.Add(Cell);

            Cell = new TableCell();
            Cell.Text = item.CompanyPhone;
            Row.Cells.Add(Cell);

            Cell = new TableCell();
            Cell.Text = item.SubmitDate.ToShortDateString();
            Row.Cells.Add(Cell);

            Cell = new TableCell();
            Cell.Text = item.Sex.ToString();
            Row.Cells.Add(Cell);

            Cell = new TableCell();
            Cell.Text = item.WantsShare ? "Yes" : "No";
            Row.Cells.Add(Cell);

            Cell = new TableCell();
            Cell.Text = item.Waitlisted ? "Yes" : "No";
            Row.Cells.Add(Cell);

            Cell = new TableCell();
            Cell.Text = item.Onhold ? "Yes" : "No";
            Row.Cells.Add(Cell);

            Cell = new TableCell();
            Cell.Text = item.ShareholderName1;
            Row.Cells.Add(Cell);

            Cell = new TableCell();
            Cell.Text = item.ShareholderDate1.ToShortDateString();
            Row.Cells.Add(Cell);

            Cell = new TableCell();
            Cell.Text = item.ShareholderName2;
            Row.Cells.Add(Cell);

            Cell = new TableCell();
            Cell.Text = item.ShareholderDate2.ToShortDateString();
            Row.Cells.Add(Cell);

            ApplicationsTable.Rows.Add(Row);
        }


      }
    protected void Accept_Click (object sender,EventArgs e)
    {
        ClubBAISTRequestDirector CBRD = new ClubBAISTRequestDirector();
        int MemberID = 0;
        MemberID = CBRD.AcceptApplication(int.Parse(ApplicationID.Text));
        if (MemberID != 0)
        {
            Message.Text = "Application was accepted successfully...... MemberID = " + MemberID.ToString();
            Message.ForeColor = System.Drawing.Color.Green;

        }
          else
            Message.Text = "Application could not be accepted.";
        Message.ForeColor = System.Drawing.Color.Red;
    }

    protected void Deny_Click(object sender, EventArgs e)
    {
        ClubBAISTRequestDirector CBRD = new ClubBAISTRequestDirector();
        if (CBRD.DenyApplication(int.Parse(ApplicationID.Text)))
            Message.Text = "Application was denied successfully.";
        else
            Message.Text = "Application could not be denied.";
    }

    protected void Waitlist_Click(object sender, EventArgs e)
    {
        ClubBAISTRequestDirector CBRD = new ClubBAISTRequestDirector();
        if (CBRD.WaitlistApplication(int.Parse(ApplicationID.Text)))
            Message.Text = "Application was waitlisted successfully.";
        else
            Message.Text = "Application could not be waitlisted.";
    }
    protected void OnHold_Click(object sender, EventArgs e)
    {
        ClubBAISTRequestDirector CBRD = new ClubBAISTRequestDirector();
        if (CBRD.HoldApplication(int.Parse(ApplicationID.Text)))
            Message.Text = "Application was put on hold successfully.";
        else
            Message.Text = "Application could not be put on hold.";
    }
    protected void SignOut_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Session["MemberNumber"] = null;
        Response.Redirect("~/Logon.aspx");
    }
}
