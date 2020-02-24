using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
public partial class RecordMemberApplication : System.Web.UI.Page
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
    protected void Submit_Click(object sender, EventArgs e)
    {
        ClubBAISTRequestDirector CBRD = new ClubBAISTRequestDirector();



        Application NewApplication = new Application(LastName.Text, FirstName.Text, Address.Text, PostalCode.Text, Phone.Text,
        AltPhone.Text, Email.Text, DateTime.Parse(DateofBirth.Text), Occupation.Text, CompanyName.Text, CompanyAddress.Text,
        CompanyPostalCode.Text, CompanyPhone.Text, DateTime.Parse(SubmitDate.Text), char.Parse(Sexlist.SelectedValue),
        Share.Checked, ShareholderName1.Text, ShareholderName2.Text, DateTime.Parse(ShareholderDate1.Text), DateTime.Parse(ShareholderDate2.Text), Password.Text);
        bool confirmation = CBRD.AddApplication(NewApplication);
        if (confirmation)
        {
            Message.Text = "Application successfully submitted";
        }
    }
    protected void SignOut_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Session["MemberNumber"] = null;
        Response.Redirect("~/Logon.aspx");
    }
}
