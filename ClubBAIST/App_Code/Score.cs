using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Score
/// </summary>
public class Score
{
    public string Tee { get; set; }
    public List<int> scores { get; set; }
    public int Total { get; set; }
    public double HandicapDifferential { get; set; }
    public Score(string tee, int total)
    {
        Tee = tee;
        Total = total;
        scores = new List<int>();
    }
}


