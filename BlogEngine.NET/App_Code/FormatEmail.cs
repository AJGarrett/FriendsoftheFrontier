using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
/// <summary>
/// Summary description for FormatEmail
/// </summary>
public class FormatEmail
{
    private string _Text, _Subject, _To, _From, _CC;

    public string Text
    {
        get {return _Text;}
        set {_Text = value;}
    }
    public string Subject
    {
        get {return _Subject;}
        set {_Subject = value;}
    }
    public string To
    {
        get { return _To; }
        set { _To = value; }
    }
    public string From
    {
        get { return _From; }
        set { _From = value; }
    }
    public string CC
    {
        get { return _CC;  }
        set { _CC = value;  }
    }
    
    public bool Send()
    {
        return SendMail(this);
    }

    public static bool SendMail(FormatEmail theEmail)
    {
        try
        {
            if (theEmail.From == "")
                theEmail.From = "clrfrontiersmen@gmail.com";

            if (theEmail.To != "" && theEmail.From != "" && theEmail.Subject != "" && theEmail.Text != "")
            {
                MailMessage myMail = new MailMessage();
                myMail.From = new MailAddress("clrfrontiersmen@gmail.com");
                myMail.To.Add(theEmail.To);
                
                if (theEmail.CC != null && theEmail.CC != "")
                    myMail.CC.Add(theEmail.CC);

                myMail.Subject = theEmail.Subject;
                myMail.Body = theEmail.Text;
                

                myMail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient(ConfigurationManager.AppSettings["SMTPServer"].ToString());
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("CLRFOTF", "437d04f4-bc44-48c3-8f8a-2fd511597197");
                smtp.Send(myMail);
                return true;
            }
            else
            {
                return false;
            }

        }
        catch (SmtpException smtpex)
        {
            return false;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
