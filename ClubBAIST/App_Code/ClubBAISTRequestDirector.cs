using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for BAISTClubCodeHandler
/// </summary>
public class ClubBAISTRequestDirector
{
    public bool AddDailyReservationSheet(DateTime Day)
    {
        Reservations ReservationManager = new Reservations();
        return ReservationManager.AddDailyReservationSheet(Day);
    }
    public bool AddApplication(Application NewApplication)
    {
        Applications ApplicationManager = new Applications();
        return ApplicationManager.AddApplication(NewApplication);
    }

    public List<Application> GetApplications()
    {
        Applications ApplicationManager = new Applications();
        return ApplicationManager.GetApplications();
    }

    public int AcceptApplication(int ApplicationID)
    {
        Applications ApplicationManager = new Applications();
        return ApplicationManager.AcceptApplication(ApplicationID);
    }
    public bool DenyApplication(int ApplicationID)
    {
        Applications ApplicationManager = new Applications();
        return ApplicationManager.DenyApplication(ApplicationID);
    }
    public bool WaitlistApplication(int ApplicationID)
    {
        Applications ApplicationManager = new Applications();
        return ApplicationManager.WaitlistApplication(ApplicationID);
    }

    public bool HoldApplication(int ApplicationID)
    {
        Applications ApplicationManager = new Applications();
        return ApplicationManager.HoldApplication(ApplicationID);
    }

    public void ViewEntries(int MemberNumber, Table tb)
    {
        Members AccountManager = new Members();
        AccountManager.GetEntries(MemberNumber, tb);
    }

    public double ViewBalance(int MemberNumber)
    {
        Members AccountManager = new Members();
        return AccountManager.GetCurrentBalance(MemberNumber);
    }

    public bool AddEntry(int MemberNumber, DateTime ActivityDate, string Description, double Amount)
    {
        Members AccountManager = new Members();
        return AccountManager.AddEntry(MemberNumber, ActivityDate, Description, Amount);
    }

    public List<TeeTime> ViewTeeTimes(DateTime Date)
    {
        Reservations TeeTimeManager = new Reservations();
        return TeeTimeManager.GetTeeTimes(Date);
    }
    public bool ReserveTeeTime(TeeTime NewTeeTime, string MembershipLevel)
    {
        bool Confirmation;
        Reservations ReservationManager = new Reservations();
        Confirmation = ReservationManager.AddReservation(NewTeeTime, MembershipLevel);
        return Confirmation;
    }

    public void DisplayMemberReservations(int MemberNumber, ListBox MemberReservations)
    {
        Reservations ReservationManager = new Reservations();
        ReservationManager.GetMemberReservations(MemberNumber, MemberReservations);
    }

    public bool CancelReservation(DateTime Date, DateTime Time, int MemberNumber)
    {
        bool Confirmation = true;
        Reservations ReservationManager = new Reservations();
        Confirmation = ReservationManager.CancelReservation(Date, Time, MemberNumber);
        return Confirmation;
    }

    public bool BookTeeTimeStandingReservation(DateTime StartDate, DateTime EndDate, DateTime RequestedTime, string DayOfWeek,
            int MemberNumber1, int MemberNumber2, int MemberNumber3, int MemberNumber4, string MemberName1, string MemberName2,
            string MemberName3, string MemberName4)
    {
        Reservations ReservationManager = new Reservations();
        bool Confirmation = ReservationManager.AddStandingReservation(StartDate, EndDate, RequestedTime, DayOfWeek,
        MemberNumber1, MemberNumber2, MemberNumber3, MemberNumber4, MemberName1, MemberName2,
        MemberName3, MemberName4);
        return Confirmation;
    }

    public bool CancelStandingReservation(int MemberNumber, int Year)
    {
        Reservations ReservationManager = new Reservations();
        bool Confirmation = ReservationManager.CancelStandingReservation(MemberNumber, Year);
        return Confirmation;
    }

    public float GetCurrentHandicap(int membernumber)
    {
        Scores HandicapManager = new Scores();
        return HandicapManager.GetCurrentHandicap(membernumber);
    }

    public bool RecordScore(int MemberNumber, Score score)
    {
        Scores ScoreManager = new Scores();
        return ScoreManager.AddScore(MemberNumber, score);
    }

}

