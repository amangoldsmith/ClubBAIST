using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;


public partial class BookTeeTimeReservation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            NumberOfPlayers.SelectedIndex = 0;
            int MemberNumber = 0;
            ClubBAISTRequestDirector CBRD = new ClubBAISTRequestDirector();
            try
            {
                MemberNumber = int.Parse(Session["MemberNumber"].ToString());
            }
            catch (Exception)
            {
                Message.Text = "Login Violation in This Page ";
               
            }
        }
    }


    protected void NumberOfPlayers_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (NumberOfPlayers.SelectedIndex == 0)
        {
            MemberName2.Enabled = false;
            MemberName3.Enabled = false;
            MemberName4.Enabled = false;
            MemberName2.Text = "";
            MemberName3.Text = "";
            MemberName4.Text = "";
        }
        else if (NumberOfPlayers.SelectedIndex == 1)
        {
            MemberName2.Enabled = true;
            MemberName3.Enabled = false;
            MemberName4.Enabled = false;
            MemberName3.Text = "";
            MemberName4.Text = "";
        }
        else if (NumberOfPlayers.SelectedIndex == 2)
        {
            MemberName2.Enabled = true;
            MemberName3.Enabled = true;
            MemberName4.Enabled = false;
            MemberName4.Text = "";
        }
        else
        {
            MemberName2.Enabled = true;
            MemberName3.Enabled = true;
            MemberName4.Enabled = true;
        }
    }

    protected void AMorPM_SelectedIndexChanged(object sender, EventArgs e)
    {
        Hour.Items.Clear();
        if (AMorPM.SelectedIndex == 0)
        {
            Hour.Items.Add("6");
            Hour.Items.Add("7");
            Hour.Items.Add("8");
            Hour.Items.Add("9");
            Hour.Items.Add("10");
            Hour.Items.Add("11");
        }
        else
        {
            Hour.Items.Add("12");
            Hour.Items.Add("1");
            Hour.Items.Add("2");
            Hour.Items.Add("3");
            Hour.Items.Add("4");
            Hour.Items.Add("5");
            Hour.Items.Add("6");
            Hour.Items.Add("7");
            Hour.Items.Add("8");
        }
    }

    protected void DisplayTeeTime_Click(object sender, EventArgs e)
    {
        ClubBAISTRequestDirector CBRD = new ClubBAISTRequestDirector();
        try
        {
            List<TeeTime> Times = CBRD.ViewTeeTimes(DateTime.Parse(ViewTeeTimeBox.Text));

            for (int i = 0; i < Times.Count; i++)
            {
                TableRow Row = new TableRow();
                Row.Height = 10;
                TableCell Cell = new TableCell();

                Cell = new TableCell();

                if (i % 2 == 0)
                    Row.BackColor = System.Drawing.Color.LightGray;
                if (Times[i].MemberName1 != "N/A")
                {
                    Row.Font.Bold = true;
                }

                Cell.Text = Times[i].Time.ToShortTimeString();
                Row.Cells.Add(Cell);
                Cell = new TableCell();
                Cell.Text = Times[i].MemberName1;
                Row.Cells.Add(Cell);
                Cell = new TableCell();
                Cell.Text = Times[i].MemberName2;
                Row.Cells.Add(Cell);
                Cell = new TableCell();
                Cell.Text = Times[i].MemberName3;
                Row.Cells.Add(Cell);
                Cell = new TableCell();
                Cell.Text = Times[i].MemberName4;
                Row.Cells.Add(Cell);

                TeeTimesTable.Rows.Add(Row);
            }
        }
        catch (Exception)
        {
            Message.Text = "Please Enter a Valid Date";
        }
    }


    protected void BookTeeTime_Click(object sender, EventArgs e)
    {
        int hours = int.Parse(Hour.SelectedItem.Text);
        int minutes = int.Parse(Minute.SelectedItem.Text);

        if (AMorPM.SelectedItem.Text == "PM" && hours != 12)
            hours += 12;

        string datetime = Date.Text;
        datetime += " " + hours.ToString() + ":" + minutes.ToString();
        TeeTime NewTeeTime;
        DateTime DateT = DateTime.Parse(datetime);
        try
        {
            NewTeeTime = new TeeTime(DateT, DateT, Session["MemberName"].ToString(), MemberName2.Text, MemberName3.Text, MemberName4.Text, Convert.ToInt32(Session["MemberNumber"]), Convert.ToInt32(NumberOfPlayers.SelectedValue),
            PhoneNumber.Text, Convert.ToInt32(NumberOfCarts.Text), "N/A");
        }
        catch (Exception)
        {
            Message.Text = "Information was input incorrectly. Double check your fields";
            return;
        }


        ClubBAISTRequestDirector CBRD = new ClubBAISTRequestDirector();


        if (CBRD.ReserveTeeTime(NewTeeTime, Session["MembershipLevel"].ToString()))
            Message.Text = "Reservation was successfuly made.";
        else
            Message.Text = "Reservation could not be made.";
    }
    



    protected void SignOut_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Session["MemberNumber"] = null;
      
    }
}

