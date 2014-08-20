using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Security;

/// <summary>
/// Summary description for Validate
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class Validate : System.Web.Services.WebService {

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public bool CheckEmail(string emailaddress) {
        RegexUtilities r = new RegexUtilities();
        if (!r.IsValidEmail(emailaddress) || Membership.GetUser(emailaddress) != null)
            return true;
        else
            return false;
    }
    
}
