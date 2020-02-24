using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TeeTime
/// </summary>
public class TeeTime
{
    public DateTime Date { get; set; }
    public DateTime Time { get; set; }
    public string MemberName1 { get; set; }
    public string MemberName2 { get; set; }
    public string MemberName3 { get; set; }
    public string MemberName4 { get; set; }
    public int MemberNumber { get; set; }
    public int NumberOfPlayers { get; set; }
    public string PhoneNumber { get; set; }
    public int NumberOfCarts { get; set; }
    public string EmployeeName { get; set; }

    public TeeTime(DateTime date, DateTime time, string membername1, string membername2, string membername3, string membername4)
    {
        Date = date;
        Time = time;
        MemberName1 = membername1;
        MemberName2 = membername2;
        MemberName3 = membername3;
        MemberName4 = membername4;
    }

    public TeeTime(DateTime date, DateTime time, int membernumber, string membername1, string membername2, string membername3, string membername4)
    {
        Date = date;
        Time = time;
        MemberNumber = membernumber;
        MemberName1 = membername1;
        MemberName2 = membername2;
        MemberName3 = membername3;
        MemberName4 = membername4;
    }

    public TeeTime(DateTime date, DateTime time, string membername1, string membername2, string membername3, string membername4, int membernumber,
                    int numberofplayers, string phonenumber, int numberofcarts, string employeename)
    {
        Date = date;
        Time = time;
        MemberName1 = membername1;
        MemberName2 = membername2;
        MemberName3 = membername3;
        MemberName4 = membername4;
        MemberNumber = membernumber;
        NumberOfPlayers = numberofplayers;
        PhoneNumber = phonenumber;
        NumberOfCarts = numberofcarts;
        EmployeeName = employeename;
    }
    public TeeTime() { }
}
