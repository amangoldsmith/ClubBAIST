using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Logon : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Login_Click(object sender, EventArgs e)
    {
        int membernumber = 0;
        if (MemberNumber.Text == "madhuri1234" || Password.Text == "Madhuri2018" || !int.TryParse(MemberNumber.Text, out membernumber))
            Message.Text = "Please Enter a VALID Member Number and Password.";
        else
        {
            SqlConnection ClubBAIST = new SqlConnection();
            ClubBAIST.ConnectionString =
                ConfigurationManager.ConnectionStrings["MadhuriKathiriaClubBAIST"].ConnectionString;
            ClubBAIST.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = ClubBAIST;
            command.CommandText = "GetLoginInfo";
            command.CommandType = CommandType.StoredProcedure;
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@MemberNumber";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = membernumber;
            command.Parameters.Add(parameter);

            SqlParameter password = new SqlParameter();
            password.ParameterName = "@Password";
            password.SqlDbType = SqlDbType.NVarChar;
            password.Value = "";
            password.Size = 200;
            password.Direction = ParameterDirection.Output;
            command.Parameters.Add(password);

            SqlParameter name = new SqlParameter();
            name.ParameterName = "@MemberName";
            name.SqlDbType = SqlDbType.NVarChar;
            name.Value = " ";
            name.Size = 40;
            name.Direction = ParameterDirection.Output;
            command.Parameters.Add(name);

            SqlParameter tier = new SqlParameter();
            tier.ParameterName = "@MembershipTier";
            tier.SqlDbType = SqlDbType.VarChar;
            tier.Value = "";
            tier.Size = 40;
            tier.Direction = ParameterDirection.Output;
            command.Parameters.Add(tier);

            SqlParameter level = new SqlParameter();
            level.ParameterName = "@MembershipLevel";
            level.SqlDbType = SqlDbType.NVarChar;
            level.Value = "";
            level.Size = 6;
            level.Direction = ParameterDirection.Output;
            command.Parameters.Add(level);

            SqlParameter isshareholder = new SqlParameter();
            isshareholder.ParameterName = "@IsShareholder";
            isshareholder.SqlDbType = SqlDbType.Bit;
            isshareholder.Value = 0;
            isshareholder.Direction = ParameterDirection.Output;
            command.Parameters.Add(isshareholder);

            SqlParameter sex = new SqlParameter();
            sex.ParameterName = "@Sex";
            sex.SqlDbType = SqlDbType.Char;
            sex.Value = ' ';
            sex.Direction = ParameterDirection.Output;
            command.Parameters.Add(sex);

            SqlParameter standing = new SqlParameter();
            standing.ParameterName = "@Standing";
            standing.SqlDbType = SqlDbType.Char;
            standing.Value = ' ';
            standing.Direction = ParameterDirection.Output;
            command.Parameters.Add(standing);

            command.ExecuteNonQuery();

            try
            {
                if (Password.Text == (string)password.Value)
                {

                    FormsAuthentication.SetAuthCookie(membernumber.ToString(), false);
                    Session["MemberNumber"] = membernumber;
                    Session["MemberName"] = name.Value.ToString();
                    Session["MembershipLevel"] = level.Value.ToString();
                    Session["IsShareholder"] = isshareholder.Value;
                    Session["Sex"] = sex.Value;
                    Session["MembershipLevel"] = level.Value.ToString();
                    ClubBAIST.Close();
                    Response.Redirect("~/HomePage.aspx");
                }
                else
                {
                    ClubBAIST.Close();
                    Message.Text = "Incorrect Password";
                }
            }
            catch (Exception)
            {

                Message.Text = "Member Is Not Exist";
            }


        }
    }
}















