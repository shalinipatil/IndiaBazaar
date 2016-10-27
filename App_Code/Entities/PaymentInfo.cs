using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PaymentInfo
/// </summary>
public class PaymentInfo
{
    public int PaymentId { get; set; }
    public int UserId { get; set; }
    public string CardType { get; set; }
    public string  HolderName{ get; set; }
    public string CardNumber { get; set; }
    public string Cvv { get; set; }
    public DateTime Date { get; set; }
    public int OrderNo{get;set;}
    

    public PaymentInfo(int payment,int id, string cardtype, string holdername, string cardnumber, string cvv, DateTime date, int orderno)
    {
        PaymentId = payment;
        UserId = id;
        CardType=cardtype;
        HolderName = holdername;
        CardNumber = cardnumber;
        Cvv = cvv;
        Date = date;
        OrderNo = orderno;
        
    }

    public PaymentInfo(int id, string cardtype, string holdername, string cardnumber, string cvv, DateTime date,int orderno)
    {

        UserId = id;
        CardType = cardtype;
        HolderName = holdername;
        CardNumber = cardnumber;
        Cvv = cvv;
        Date = date;
        OrderNo = orderno;
        

    }

}