using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class RecordPlayerScore : System.Web.UI.Page
{
    List<TextBox> boxes;
    const double MENWHITERATING = 69.1;
    const double MENBLUERATING = 70.6;
    const int MENWHITESLOPE = 121;
    const int MENBLUESLOPE = 128;
    const double WOMENREDRATING = 73d;
    const double WOMENWHITERATING = 75.3;
    const int WOMENREDSLOPE = 127;
    const int WOMENWHITESLOPE = 131;
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
        boxes = new List<TextBox>() { S1, S2, S3, S4, S5, S6, S7, S8, S9, S10, S11, S12, S13, S14, S15, S16, S17, S18 };
        if (Session["Sex"].ToString() == "M")
            TeeList.Items.Remove("Red");
        else
            TeeList.Items.Remove("Blue");
        TeeList.SelectedValue = "White";
    }



    protected void HandicapFactor_Click(object sender, EventArgs e)
    {
        ClubBAISTRequestDirector CBRD = new ClubBAISTRequestDirector();
        float factor = CBRD.GetCurrentHandicap((int)Session["MemberNumber"]);
        HandicapFactorLabel.Text = "Handicap Factor: " + factor;
    }

    protected void Record_Click(object sender, EventArgs e)
    {
        int total = int.Parse(Front9Total.Text) + int.Parse(Back9Total.Text);
        Score NewScore = new Score(TeeList.SelectedValue, total);
        foreach (TextBox item in boxes)
        {
            try
            {
                NewScore.scores.Add(int.Parse(item.Text));
            }
            catch (Exception)
            {
                Message.Text = "Your scores are not correct";
            }
        }

        if (NewScore.scores.Count == 18)
            NewScore.HandicapDifferential = Math.Round(((NewScore.Total - float.Parse(Rating.Text)) * 113) / float.Parse(Slope.Text), 1);


        ClubBAISTRequestDirector CBRD = new ClubBAISTRequestDirector();
        if (CBRD.RecordScore((int)Session["MemberNumber"], NewScore))
            Message.Text = "Score was recorded successfully";
        else
            Message.Text = "There seems to be an error in your score.";
    }

    protected void CalculateTotal_Click(object sender, EventArgs e)
    {
        int fronttotal = 0;
        for (int i = 0; i < 9; i++)
        {
            fronttotal += int.Parse(boxes[i].Text);
        }
        Front9Total.Text = fronttotal.ToString();

        int backtotal = 0;
        for (int i = 9; i < 18; i++)
        {
            backtotal += int.Parse(boxes[i].Text);
        }
        Back9Total.Text = backtotal.ToString();
        foreach (TextBox item in boxes)
        {
            item.ReadOnly = true;
        }
        Record.Enabled = true;
        Edit.Enabled = true;
        CalculateTotal.Enabled = false;
    }

    protected void Edit_Click(object sender, EventArgs e)
    {
        foreach (TextBox item in boxes)
        {
            item.ReadOnly = false;
        }
        CalculateTotal.Enabled = true;
        Record.Enabled = false;
        Edit.Enabled = false;
    }

    protected void SignOut_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Session["MemberNumber"] = null;
        Response.Redirect("~/Logon.aspx");
    }
}
