using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Security;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RegexUtilities r = new RegexUtilities();
        Response.Write(r.IsValidEmail("jamesy679p@gmail.com").ToString());
    }
}