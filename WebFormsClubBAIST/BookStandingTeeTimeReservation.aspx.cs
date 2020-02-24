using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class BookStandingTeeTimeReservation : System.Web.UI.Page
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
               

            }
        }
       
       
      }
    protected void AMorPM_SelectedIndexChanged(object sender, EventArgs e)
    {
        Hour.Items.Clear();
        if (Hour.SelectedIndex == 0)
        {
            Hour.Items.Add("6");
            Hour.Items.Add("7");
            Hour.Items.Add("8");
            Hour.Items.Add("9");
            
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
           
        }
    }
    protected void BookStandingReservation_Click(object Sender, EventArgs e)
    {
     

      }
    }