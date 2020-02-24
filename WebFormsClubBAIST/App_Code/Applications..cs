using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


/// <summary>
/// Summary description for Applications
/// </summary>
public class Applications
{
    public bool AddApplication(Application NewApplication)
    {
        bool success = true;

        SqlConnection MadhuriKathiriaClubBAIST = new SqlConnection();
        MadhuriKathiriaClubBAIST.ConnectionString = ConfigurationManager.ConnectionStrings["MadhuriKathiriaClubBAIST"].ConnectionString;
        MadhuriKathiriaClubBAIST.Open();

        SqlCommand command = new SqlCommand();
        command.CommandText = "AddApplication";
        command.CommandType = CommandType.StoredProcedure;
        command.Connection = MadhuriKathiriaClubBAIST;
        SqlParameter parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.NVarChar;
        parameter.Value = NewApplication.LastName;
        parameter.ParameterName = "@LastName";
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.NVarChar;
        parameter.Value = NewApplication.FirstName;
        parameter.ParameterName = "@FirstName";
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.NVarChar;
        parameter.Value = NewApplication.Address;
        parameter.ParameterName = "@Address";
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.VarChar;
        parameter.Value = NewApplication.PostalCode;
        parameter.ParameterName = "@PostalCode";
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.VarChar;
        parameter.Value = NewApplication.Phone;
        parameter.ParameterName = "@Phone";
        command.Parameters.Add(parameter);
        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.VarChar;
        parameter.Value = NewApplication.AltPhone;
        parameter.ParameterName = "@AltPhone";
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.NVarChar;
        parameter.Value = NewApplication.Email;
        parameter.ParameterName = "@Email";
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.Date;
        parameter.Value = NewApplication.BirthDate.Date;
        parameter.ParameterName = "@BirthDate";
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.NVarChar;
        parameter.Value = NewApplication.Occupation;
        parameter.ParameterName = "@Occupation";
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.NVarChar;
        parameter.Value = NewApplication.CompanyName;
        parameter.ParameterName = "@CompanyName";
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.NVarChar;
        parameter.Value = NewApplication.CompanyAddress;
        parameter.ParameterName = "@CompanyAddress";
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.NVarChar;
        parameter.Value = NewApplication.CompanyPostalCode;
        parameter.ParameterName = "@CompanyPostalCode";
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.VarChar;
        parameter.Value = NewApplication.CompanyPhone;
        parameter.ParameterName = "@CompanyPhone";
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.Date;
        parameter.Value = NewApplication.SubmitDate;
        parameter.ParameterName = "@SubmitDate";
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.Char;
        parameter.Value = NewApplication.Sex;
        parameter.ParameterName = "@Sex";
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.NVarChar;
        parameter.Value = NewApplication.Password;
        parameter.ParameterName = "@Password";
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.Bit;
        parameter.Value = NewApplication.WantsShare;
        parameter.ParameterName = "@WantsShare";
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.NVarChar;
        parameter.Value = NewApplication.ShareholderName1;
        parameter.ParameterName = "@ShareholderName1";
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.Date;
        parameter.Value = NewApplication.ShareholderDate1.Date;
        parameter.ParameterName = "@ShareholderDate1";
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.NVarChar;
        parameter.Value = NewApplication.ShareholderName2;
        parameter.ParameterName = "@ShareholderName2";
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.Date;
        parameter.Value = NewApplication.ShareholderDate2.Date;
        parameter.ParameterName = "@ShareholderDate2";
        command.Parameters.Add(parameter);

        try
        {
            command.ExecuteNonQuery();
        }
        catch (Exception)
        {
            success = false;
        }
        finally
        {
            MadhuriKathiriaClubBAIST.Close();
        }

        return success;
    }
    public List<Application> GetApplications()
    {
        List<Application> Applications = new List<Application>();
        SqlConnection MadhuriKathiriaClubBAIST = new SqlConnection();
        MadhuriKathiriaClubBAIST.ConnectionString = ConfigurationManager.ConnectionStrings["MadhuriKathiriaClubBAIST"].ConnectionString;
        MadhuriKathiriaClubBAIST.Open();

        SqlCommand command = new SqlCommand();
        command.CommandText = "GetApplications";
        command.CommandType = CommandType.StoredProcedure;
        command.Connection = MadhuriKathiriaClubBAIST;

        SqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Application a = new Application();
                a.ApplicationID = int.Parse(reader["ApplicationID"].ToString());
                a.LastName = reader["LastName"].ToString();
                a.FirstName = reader["FirstName"].ToString();
                a.Address = reader["Address"].ToString();
                a.PostalCode = reader["PostalCode"].ToString();
                a.Phone = reader["Phone"].ToString();
                a.AltPhone = reader["AltPhone"].ToString();
                a.Email = reader["Email"].ToString();
                a.BirthDate = DateTime.Parse(reader["BirthDate"].ToString());
                a.Occupation = reader["Occupation"].ToString();
                a.CompanyName = reader["CompanyName"].ToString();
                a.CompanyAddress = reader["CompanyAddress"].ToString();
                a.CompanyPostalCode = reader["CompanyPostalCode"].ToString();
                a.CompanyPhone = reader["CompanyPhone"].ToString();
                a.SubmitDate = DateTime.Parse(reader["SubmitDate"].ToString());
                a.Sex = char.Parse(reader["Sex"].ToString());
                a.WantsShare = bool.Parse(reader["WantsShare"].ToString());
                a.Waitlisted = bool.Parse(reader["IsWaitlisted"].ToString());
                a.Onhold = bool.Parse(reader["IsOnhold"].ToString());
                a.ShareholderName1 = reader["ShareholderName1"].ToString();
                a.ShareholderName2 = reader["ShareholderName2"].ToString();
                a.ShareholderDate1 = DateTime.Parse(reader["ShareholderDate1"].ToString());
                a.ShareholderDate2 = DateTime.Parse(reader["ShareholderDate2"].ToString());
                Applications.Add(a);
            }
        }
        reader.Close();
        MadhuriKathiriaClubBAIST.Close();
        return Applications;
    }
    public bool DenyApplication(int ApplicationID)
    {
        bool success = true;
        SqlConnection MadhuriKathiriaClubBAIST = new SqlConnection();
        MadhuriKathiriaClubBAIST.ConnectionString = ConfigurationManager.ConnectionStrings["MadhuriKathiriaClubBAIST"].ConnectionString;
        MadhuriKathiriaClubBAIST.Open();

        SqlCommand command = new SqlCommand();
        command.CommandText = "DenyApplication";
        command.CommandType = CommandType.StoredProcedure;
        command.Connection = MadhuriKathiriaClubBAIST;

        SqlParameter parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Value = ApplicationID;
        parameter.ParameterName = "@ApplicationID";
        command.Parameters.Add(parameter);

        command.ExecuteNonQuery();
        MadhuriKathiriaClubBAIST.Close();
        return success;
    }

    public bool HoldApplication(int ApplicationID)
    {
        bool success = true;
        SqlConnection MadhuriKathiriaClubBAIST = new SqlConnection();
        MadhuriKathiriaClubBAIST.ConnectionString = ConfigurationManager.ConnectionStrings["MadhuriKathiriaClubBAIST"].ConnectionString;
        MadhuriKathiriaClubBAIST.Open();

        SqlCommand command = new SqlCommand();
        command.CommandText = "HoldApplication";
        command.CommandType = CommandType.StoredProcedure;
        command.Connection = MadhuriKathiriaClubBAIST;

        SqlParameter parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Value = ApplicationID;
        parameter.ParameterName = "@ApplicationID";
        command.Parameters.Add(parameter);

        command.ExecuteNonQuery();
        MadhuriKathiriaClubBAIST.Close();
        return success;
    }

    public bool WaitlistApplication(int ApplicationID)
    {

        bool success = true;
        SqlConnection MadhuriKathiriaClubBAIST = new SqlConnection();
        MadhuriKathiriaClubBAIST.ConnectionString = ConfigurationManager.ConnectionStrings["MadhuriKathiriaClubBAIST"].ConnectionString;
        MadhuriKathiriaClubBAIST.Open();

        SqlCommand command = new SqlCommand();
        command.CommandText = "WaitlistApplication";
        command.CommandType = CommandType.StoredProcedure;
        command.Connection = MadhuriKathiriaClubBAIST;

        SqlParameter parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Value = ApplicationID;
        parameter.ParameterName = "@ApplicationID";
        command.Parameters.Add(parameter);

        command.ExecuteNonQuery();
        MadhuriKathiriaClubBAIST.Close();
        return success;
    }

    public int AcceptApplication(int ApplicationID)
    {
        int MemberNumber = 0;

        SqlConnection MadhuriKathiriaClubBAIST = new SqlConnection();
        MadhuriKathiriaClubBAIST.ConnectionString = ConfigurationManager.ConnectionStrings["MadhuriKathiriaClubBAIST"].ConnectionString;
        MadhuriKathiriaClubBAIST.Open();

        SqlCommand command = new SqlCommand();
        command.CommandText = "AcceptApplication";
        command.CommandType = CommandType.StoredProcedure;
        command.Connection = MadhuriKathiriaClubBAIST;

        SqlParameter parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Value = ApplicationID;
        parameter.Direction = ParameterDirection.Input;
        parameter.ParameterName = "@ApplicationID";
        command.Parameters.Add(parameter);
        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Value = MemberNumber;
        parameter.Direction = ParameterDirection.Output;
        parameter.ParameterName = "@MemberNumber";
        command.Parameters.Add(parameter);

        command.ExecuteNonQuery();

        MemberNumber = (int)(command.Parameters["@MemberNumber"].Value);

        MadhuriKathiriaClubBAIST.Close();
        return MemberNumber;
    }
}
