using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Application
/// </summary>
public class Application
{
    public int ApplicationID { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Address { get; set; }
    public string PostalCode { get; set; }
    public string Phone { get; set; }
    public string AltPhone { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public string Occupation { get; set; }
    public string CompanyName { get; set; }
    public string Password { get; set; }
    public string CompanyAddress { get; set; }
    public string CompanyPostalCode { get; set; }
    public string CompanyPhone { get; set; }
    public DateTime SubmitDate { get; set; }
    public char Sex { get; set; }
    public bool WantsShare { get; set; }
    public bool Waitlisted { get; set; }
    public bool Onhold { get; set; }
    public string ShareholderName1 { get; set; }
    public string ShareholderName2 { get; set; }
    public DateTime ShareholderDate1 { get; set; }
    public DateTime ShareholderDate2 { get; set; }
    public Application() { }

    public Application(string lastname, string firstname, string address, string postalcode, string phone,
  string altphone, string email, DateTime birthdate, string occupation, string companyname, string companyaddress,
  string companypostalcode, string companyphone, DateTime submitdate, char sex, bool wantsshare,
  string shareholdername1, string shareholdername2, DateTime shareholderdate1, DateTime shareholderdate2, string password)
    {
        LastName = lastname;
        FirstName = firstname;
        Address = address;
        PostalCode = postalcode;
        Phone = phone;
        AltPhone = altphone;
        Email = email;
        BirthDate = birthdate;
        Occupation = occupation;
        CompanyName = companyname;
        CompanyAddress = companyaddress;
        CompanyPostalCode = companypostalcode;
        CompanyPhone = companyphone;
        SubmitDate = submitdate;
        Sex = sex;
        WantsShare = wantsshare;
        ShareholderName1 = shareholdername1;
        ShareholderName2 = shareholdername2;
        ShareholderDate1 = shareholderdate1;
        ShareholderDate2 = shareholderdate2;
        Password = password;
    }
    public Application(string lastname, string firstname, string address, string postalcode, string phone,
        string altphone, string email, DateTime birthdate, string occupation, string companyname, string companyaddress,
        string companypostalcode, string companyphone, DateTime submitdate, char sex, bool wantsshare,
        bool waitlisted, bool onhold, string shareholdername1, string shareholdername2, DateTime shareholderdate1, DateTime shareholderdate2, int applicationid = 0)
    {
        ApplicationID = applicationid;
        LastName = lastname;
        FirstName = firstname;
        Address = address;
        PostalCode = postalcode;
        Phone = phone;
        AltPhone = altphone;
        Email = email;
        BirthDate = birthdate;
        Occupation = occupation;
        CompanyName = companyname;
        CompanyAddress = companyaddress;
        CompanyPostalCode = companypostalcode;
        CompanyPhone = companyphone;
        SubmitDate = submitdate;
        Sex = sex;
        WantsShare = wantsshare;
        Waitlisted = waitlisted;
        Onhold = onhold;
        ShareholderName1 = shareholdername1;
        ShareholderName2 = shareholdername2;
        ShareholderDate1 = shareholderdate1;
        ShareholderDate2 = shareholderdate2;
    }
}

    
       
    
