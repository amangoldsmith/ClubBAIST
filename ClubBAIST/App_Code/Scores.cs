
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Scores
/// </summary>
public class Scores
{
    public bool AddScore(int membernumber, Score score)
    {
        bool Success = true;
        SqlConnection MadhuriKathiriaClubBAIST = new SqlConnection();
        MadhuriKathiriaClubBAIST.ConnectionString = ConfigurationManager.ConnectionStrings["MadhuriKathiriaClubBAIST"].ConnectionString;
        MadhuriKathiriaClubBAIST.Open();

        SqlCommand AddCommand = new SqlCommand();
        AddCommand.CommandText = "AddScore";
        AddCommand.CommandType = CommandType.StoredProcedure;
        AddCommand.Connection = MadhuriKathiriaClubBAIST;

        SqlParameter parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.VarChar;
        parameter.Value = score.Tee;
        parameter.ParameterName = "@Tee";
        AddCommand.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Value = membernumber;
        parameter.ParameterName = "@MemberNumber";
        AddCommand.Parameters.Add(parameter);

        if (score.scores[17] == 0)
        {
            for (int i = 0; i < 9; i++)
            {
                string s = "@Hole";
                parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.Int;
                parameter.Value = score.scores[i];
                parameter.ParameterName = s + (i + 1);
                AddCommand.Parameters.Add(parameter);
            }
            for (int i = 9; i < 18; i++)
            {
                string s = "@Hole";
                parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.Int;
                parameter.Value = DBNull.Value;
                parameter.ParameterName = s + (i + 1);
                AddCommand.Parameters.Add(parameter);
            }
        }
        else
        {
            for (int i = 0; i < 18; i++)
            {
                string s = "@Hole";
                parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.Int;
                parameter.Value = score.scores[i];
                parameter.ParameterName = s + (i + 1);
                AddCommand.Parameters.Add(parameter);
            }
        }

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Value = score.Total;
        parameter.ParameterName = "@Total";
        AddCommand.Parameters.Add(parameter);

        parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.Float;
        parameter.Value = score.HandicapDifferential;
        parameter.ParameterName = "@HandicapDifferential";
        AddCommand.Parameters.Add(parameter);

        try
        {
            AddCommand.ExecuteNonQuery();
        }
        catch (Exception)
        {
            Success = false;
        }
        finally
        {
            MadhuriKathiriaClubBAIST.Close();
        }

        return Success;
    }

    public List<double> GetHandicapDifferentials(int membernumber)
    {
        List<double> differencials = new List<double>();
        SqlConnection MadhuriKathiriaClubBAIST = new SqlConnection();
        MadhuriKathiriaClubBAIST.ConnectionString = ConfigurationManager.ConnectionStrings["MadhuriKathiriaClubBAIST"].ConnectionString;
        MadhuriKathiriaClubBAIST.Open();

        SqlCommand AddCommand = new SqlCommand();
        AddCommand.CommandText = "GetHandiCapDifferentials";
        AddCommand.CommandType = CommandType.StoredProcedure;
        AddCommand.Connection = MadhuriKathiriaClubBAIST;

        SqlParameter parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Value = membernumber;
        parameter.ParameterName = "@MemberNumber";
        AddCommand.Parameters.Add(parameter);

        SqlDataReader reader = AddCommand.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                differencials.Add(double.Parse(reader["HandicapDifferential"].ToString()));
            }
        }
        reader.Close();
        MadhuriKathiriaClubBAIST.Close();
        return differencials;
    }

    public float GetCurrentHandicap(int membernumber)
    {
        SqlConnection MadhuriKathiriaClubBAIST = new SqlConnection();
        MadhuriKathiriaClubBAIST.ConnectionString = ConfigurationManager.ConnectionStrings["MadhuriKathiriaClubBAIST"].ConnectionString;
        MadhuriKathiriaClubBAIST.Open();

        SqlCommand Command = new SqlCommand();
        Command.CommandText = "GetCurrentHandicap";
        Command.CommandType = CommandType.StoredProcedure;
        Command.Connection = MadhuriKathiriaClubBAIST;

        SqlParameter parameter = new SqlParameter();
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Value = membernumber;
        parameter.ParameterName = "@MemberNumber";
        Command.Parameters.Add(parameter);

        SqlParameter handicap = new SqlParameter();
        handicap.SqlDbType = SqlDbType.Float;
        handicap.Value = 0.0;
        handicap.Size = 6;
        handicap.ParameterName = "@Handicap";
        handicap.Direction = ParameterDirection.Output;
        Command.Parameters.Add(handicap);

        try
        {
            Command.ExecuteNonQuery();
        }
        catch (Exception)
        {

        }
        finally
        {
            MadhuriKathiriaClubBAIST.Close();
        }
        return float.Parse(handicap.Value.ToString());
    }



}

