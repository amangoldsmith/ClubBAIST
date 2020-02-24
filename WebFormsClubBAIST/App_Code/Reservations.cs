using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;


/// <summary>
/// Summary description for Reservations
/// </summary>
public class Reservations
{

    public bool AddDailyReservationSheet(DateTime Day)
    {
        bool Success = true;
        SqlConnection MadhuriKathiriaClubBAIST = new SqlConnection();
        MadhuriKathiriaClubBAIST.ConnectionString = ConfigurationManager.ConnectionStrings["MadhuriKathiriaClubBAIST"].ConnectionString;
        MadhuriKathiriaClubBAIST.Open();

        SqlCommand Command = new SqlCommand();
        Command.CommandText = "GenerateReservationSheet";
        Command.CommandType = CommandType.StoredProcedure;
        Command.Connection = MadhuriKathiriaClubBAIST;

        SqlParameter parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.Date;
        parameter.Value = Day.Date;
        parameter.ParameterName = "@Day";
        Command.Parameters.Add(parameter);

        try
        {
            Command.ExecuteNonQuery();
        }
        catch (Exception)
        {
            Success = false;
        }

        SqlCommand CommandGet = new SqlCommand();
        CommandGet.CommandText = "GetStandingReservationsForGenerate";
        CommandGet.CommandType = CommandType.StoredProcedure;
        CommandGet.Connection = MadhuriKathiriaClubBAIST;

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.Date;
        parameter.Value = Day.Date;
        parameter.ParameterName = "@Date";
        CommandGet.Parameters.Add(parameter);

        SqlDataReader reader = CommandGet.ExecuteReader();

        List<TeeTime> TeeTimes = new List<TeeTime>();

        if (reader.HasRows)
        {
            TeeTime StandingTeeTime = new TeeTime();
            while (reader.Read())
            {
                TeeTimes.Add(new TeeTime(DateTime.Parse(Day.ToString()), DateTime.Parse(reader[0].ToString()), int.Parse(reader[1].ToString()), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString()));
            }
        }

        reader.Close();

        SqlCommand CommandUpdate = new SqlCommand();
        SqlParameter Updateparameter = new SqlParameter();

        foreach (TeeTime a in TeeTimes)
        {

            CommandUpdate = new SqlCommand();
            CommandUpdate.CommandText = "UpdateTeeTimesByStandingReservations";
            CommandUpdate.CommandType = CommandType.StoredProcedure;
            CommandUpdate.Connection = MadhuriKathiriaClubBAIST;

            Updateparameter = new SqlParameter();
            Updateparameter.SqlDbType = SqlDbType.DateTime;
            Updateparameter.Value = a.Date;
            Updateparameter.ParameterName = "@Date";
            CommandUpdate.Parameters.Add(Updateparameter);

            Updateparameter = new SqlParameter();
            Updateparameter.SqlDbType = SqlDbType.DateTime;
            Updateparameter.Value = a.Time;
            Updateparameter.ParameterName = "@RequestedTime";
            CommandUpdate.Parameters.Add(Updateparameter);

            Updateparameter = new SqlParameter();
            Updateparameter.SqlDbType = SqlDbType.Int;
            Updateparameter.Value = a.MemberNumber;
            Updateparameter.ParameterName = "@MemberNumber1";
            CommandUpdate.Parameters.Add(Updateparameter);

            Updateparameter = new SqlParameter();
            Updateparameter.SqlDbType = SqlDbType.NVarChar;
            Updateparameter.Value = a.MemberName1;
            Updateparameter.ParameterName = "@MemberName1";
            CommandUpdate.Parameters.Add(Updateparameter);

            Updateparameter = new SqlParameter();
            Updateparameter.SqlDbType = SqlDbType.NVarChar;
            Updateparameter.Value = a.MemberName2;
            Updateparameter.ParameterName = "@MemberName2";
            CommandUpdate.Parameters.Add(Updateparameter);

            Updateparameter = new SqlParameter();
            Updateparameter.SqlDbType = SqlDbType.NVarChar;
            Updateparameter.Value = a.MemberName3;
            Updateparameter.ParameterName = "@MemberName3";
            CommandUpdate.Parameters.Add(Updateparameter);

            Updateparameter = new SqlParameter();
            Updateparameter.SqlDbType = SqlDbType.NVarChar;
            Updateparameter.Value = a.MemberName4;
            Updateparameter.ParameterName = "@MemberName4";
            CommandUpdate.Parameters.Add(Updateparameter);

            CommandUpdate.ExecuteNonQuery();
        }
        MadhuriKathiriaClubBAIST.Close();
        return Success;
    }

    public List<TeeTime> GetTeeTimes(DateTime Date)
    {
        List<TeeTime> TeeTimes = new List<TeeTime>();
        SqlConnection MadhuriKathiriaClubBAIST = new SqlConnection();
        MadhuriKathiriaClubBAIST.ConnectionString = ConfigurationManager.ConnectionStrings["MadhuriKathiriaClubBAIST"].ConnectionString;
        MadhuriKathiriaClubBAIST.Open();

        SqlCommand command = new SqlCommand();
        command.CommandText = "GetTeeTimes";
        command.CommandType = CommandType.StoredProcedure;
        command.Connection = MadhuriKathiriaClubBAIST;

        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@Date";
        parameter.SqlDbType = SqlDbType.Date;
        parameter.Value = Date.Date;
        command.Parameters.Add(parameter);

        SqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                TeeTimes.Add(new TeeTime(DateTime.Parse(reader[0].ToString()), DateTime.Parse(reader[1].ToString()), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString()));
            }
        }
        reader.Close();
        MadhuriKathiriaClubBAIST.Close();
        return TeeTimes;
    }

    public void GetMemberReservations(int membernumber, ListBox Reservations)
    {
        SqlConnection MadhuriKathiriaClubBAIST = new SqlConnection();
        MadhuriKathiriaClubBAIST.ConnectionString = ConfigurationManager.ConnectionStrings["MadhuriKathiriaClubBAIST"].ConnectionString;
        MadhuriKathiriaClubBAIST.Open();

        SqlCommand command = new SqlCommand();
        command.CommandText = "GetMemberReservations";
        command.CommandType = CommandType.StoredProcedure;
        command.Connection = MadhuriKathiriaClubBAIST;

        SqlParameter parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Value = membernumber;
        parameter.ParameterName = "@MemberNumber";
        command.Parameters.Add(parameter);

        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            string ReservedText = reader[0].ToString();
            string ReservedValue = reader[0].ToString() + reader[1].ToString();
            ReservedValue = ReservedValue.Remove(9);
            ReservedValue = ReservedValue + reader[1].ToString();
            ReservedText = ReservedText.Remove(9);
            ReservedText = ReservedText + " ";
            ReservedText = ReservedText + reader[1].ToString();

            ListItem item = new ListItem(ReservedText.Insert(11, " at "), ReservedValue);
            Reservations.Items.Add(item);
        }
        reader.Close();
        MadhuriKathiriaClubBAIST.Close();
    }


    public bool AddReservation(TeeTime NewTeeTime, string MemberShipLevel)
    {
        bool Success = true;
        SqlConnection MadhuriKathiriaClubBAIST = new SqlConnection();
        MadhuriKathiriaClubBAIST.ConnectionString = ConfigurationManager.ConnectionStrings["MadhuriKathiriaClubBAIST"].ConnectionString;
        MadhuriKathiriaClubBAIST.Open();

        SqlCommand AddCommand = new SqlCommand();
        AddCommand.CommandText = "AddTeeTime";
        AddCommand.CommandType = CommandType.StoredProcedure;
        AddCommand.Connection = MadhuriKathiriaClubBAIST;

        SqlParameter parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.Date;
        parameter.Value = NewTeeTime.Date.Date;
        parameter.ParameterName = "@Date";
        AddCommand.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.Time;
        parameter.Value = NewTeeTime.Time.TimeOfDay;
        parameter.ParameterName = "@Time";
        AddCommand.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.NVarChar;
        parameter.Value = NewTeeTime.MemberName1;
        parameter.ParameterName = "@MemberName1";
        AddCommand.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.NVarChar;
        parameter.Value = NewTeeTime.MemberName2;
        parameter.ParameterName = "@MemberName2";
        AddCommand.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.NVarChar;
        parameter.Value = NewTeeTime.MemberName3;
        parameter.ParameterName = "@MemberName3";
        AddCommand.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.NVarChar;
        parameter.Value = NewTeeTime.MemberName4;
        parameter.ParameterName = "@MemberName4";
        AddCommand.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Value = NewTeeTime.MemberNumber;
        parameter.ParameterName = "@MemberNumber";
        AddCommand.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Value = NewTeeTime.NumberOfPlayers;
        parameter.ParameterName = "@NumberOfPlayers";
        AddCommand.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.VarChar;
        parameter.Value = NewTeeTime.PhoneNumber;
        parameter.ParameterName = "@PhoneNumber";
        AddCommand.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Value = NewTeeTime.NumberOfCarts;
        parameter.ParameterName = "@NumberOfCarts";
        AddCommand.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.VarChar;
        parameter.Value = MemberShipLevel;
        parameter.ParameterName = "@MemberShipLevel";
        AddCommand.Parameters.Add(parameter);

        try
        {
            AddCommand.ExecuteNonQuery();
        }
        catch (Exception)
        {
            Success = false;
        }
        MadhuriKathiriaClubBAIST.Close();
        return Success;
    }

    public bool CancelReservation(DateTime Date, DateTime Time, int MemberNumber)
    {
        bool success = true;
        SqlConnection MadhuriKathiriaClubBAIST = new SqlConnection();
        MadhuriKathiriaClubBAIST.ConnectionString = ConfigurationManager.ConnectionStrings["MadhuriKathiriaClubBAIST"].ConnectionString;
        MadhuriKathiriaClubBAIST.Open();

        SqlCommand command = new SqlCommand();
        command.CommandText = "CancelTeeTime";
        command.CommandType = CommandType.StoredProcedure;
        command.Connection = MadhuriKathiriaClubBAIST;

        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@Date";
        parameter.SqlDbType = SqlDbType.Date;
        parameter.Value = Date.Date;
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.ParameterName = "@Time";
        parameter.SqlDbType = SqlDbType.Time;
        parameter.Value = Time.TimeOfDay;
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.ParameterName = "@MemberNumber";
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Value = MemberNumber;
        command.Parameters.Add(parameter);

        try
        {
            command.ExecuteNonQuery();
        }
        catch (Exception)
        {
            success = false;
        }
        MadhuriKathiriaClubBAIST.Close();
        return success;
    }

    public bool AddStandingReservation(DateTime StartDate, DateTime EndDate, DateTime RequestedTime, string DayOfWeek,
            int MemberNumber1, int MemberNumber2, int MemberNumber3, int MemberNumber4, string MemberName1, string MemberName2,
            string MemberName3, string MemberName4)
    {
        bool success = true;

        SqlConnection MadhuriKathiriaClubBAIST = new SqlConnection();
        MadhuriKathiriaClubBAIST.ConnectionString = ConfigurationManager.ConnectionStrings["MadhuriKathiriaClubBAIST"].ConnectionString;
        MadhuriKathiriaClubBAIST.Open();

        SqlCommand command = new SqlCommand();
        command.CommandText = "AddStandingReservation";
        command.CommandType = CommandType.StoredProcedure;
        command.Connection = MadhuriKathiriaClubBAIST;

        SqlParameter parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.Date;
        parameter.Value = StartDate.Date;
        parameter.ParameterName = "@StartDate";
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.Date;
        parameter.Value = EndDate.Date;
        parameter.ParameterName = "@EndDate";
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.Time;
        parameter.Value = RequestedTime.TimeOfDay;
        parameter.ParameterName = "@RequestedTime";
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.NVarChar;
        parameter.Value = DayOfWeek;
        parameter.ParameterName = "@DayOfWeek";
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Value = MemberNumber1;
        parameter.ParameterName = "@MemberNumber1";
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Value = MemberNumber2;
        parameter.ParameterName = "@MemberNumber2";
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Value = MemberNumber3;
        parameter.ParameterName = "@MemberNumber3";
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Value = MemberNumber4;
        parameter.ParameterName = "@MemberNumber4";
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.NVarChar;
        parameter.Value = MemberName1;
        parameter.ParameterName = "@MemberName1";
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.NVarChar;
        parameter.Value = MemberName2;
        parameter.ParameterName = "@MemberName2";
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.NVarChar;
        parameter.Value = MemberName3;
        parameter.ParameterName = "@MemberName3";
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.NVarChar;
        parameter.Value = MemberName4;
        parameter.ParameterName = "@MemberName4";
        command.Parameters.Add(parameter);

        try
        {
            command.ExecuteNonQuery();
            MadhuriKathiriaClubBAIST.Close();
        }
        catch (Exception)
        {
            success = false;
            MadhuriKathiriaClubBAIST.Close();
        }

        return success;
    }
    public bool CancelStandingReservation(int MemberNumber, int Year)
    {
        bool success = true;
        SqlConnection MadhuriKathiriaClubBAIST = new SqlConnection();
        MadhuriKathiriaClubBAIST.ConnectionString = ConfigurationManager.ConnectionStrings["MadhuriKathiriaClubBAIST"].ConnectionString;
        MadhuriKathiriaClubBAIST.Open();

        SqlCommand command = new SqlCommand();
        command.CommandText = "CancelStandingReservation";
        command.CommandType = CommandType.StoredProcedure;
        command.Connection = MadhuriKathiriaClubBAIST;

        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@MemberNumber";
        parameter.Value = MemberNumber;
        parameter.SqlDbType = SqlDbType.Int;
        command.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.ParameterName = "@Year";
        parameter.Value = Year;
        parameter.SqlDbType = SqlDbType.Int;
        command.Parameters.Add(parameter);

        try
        {
            command.ExecuteNonQuery();
            MadhuriKathiriaClubBAIST.Close();
        }
        catch (Exception)
        {
            MadhuriKathiriaClubBAIST.Close();
            success = false;
        }

        return success;
    }
}



