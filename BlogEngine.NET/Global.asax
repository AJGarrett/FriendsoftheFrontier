<%@ Application Language="C#" %>
<%@ Import Namespace="System.Threading" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="System.Net" %>
<%@ Import Namespace="BlogEngine.Core" %>

<script runat="server">
  
  /// <summary>
  /// Application Error handler
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
    void Application_Error(object sender, EventArgs e)
    {
         // Code that runs when an unhandled error occurs
        Exception error = HttpContext.Current.Server.GetLastError();
        try
        {
            if (error.InnerException.ToString() != "")
            {
                Exception myError = Server.GetLastError();
                myError = myError.GetBaseException();

                System.Net.Mail.MailMessage myMail = new System.Net.Mail.MailMessage();
                myMail.From = new System.Net.Mail.MailAddress("clrfrontiersmen@gmail.com");
                myMail.To.Add("andyjgarrett+FOTF@gmail.com");

                myMail.Subject = "FOTF Error";
                myMail.Body = "<b>An error occured on page:</b> " + Request.Path.ToString() + "<p>" + "<p><b>Server: </b>" + Request.Url.Host.ToString() + "<p>" + error.InnerException.ToString();
                myMail.IsBodyHtml = true;

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings["SMTPServer"].ToString());
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("CLRFOTF", "437d04f4-bc44-48c3-8f8a-2fd511597197");

                try
                {
                    smtp.Send(myMail);
                }
                catch (Exception ex)
                {

                }
            }
        }
        catch (NullReferenceException) { }  

    }

    void Application_Start(object sender, EventArgs e)
    {
        // intentionally not using Application_Start.  instead application
        // start code is below in FirstRequestInitialization.  this is to
        // workaround IIS7 integrated mode issue where HttpContext.Request
        // is not available during Application_Start.

        RegisterRoutes(RouteTable.Routes);
    }

    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("",
            "members/{gbtype}/",
            "~/members/guestbook.aspx");
    }

    void Application_BeginRequest(object source, EventArgs e)
    {
        HttpApplication app = (HttpApplication)source;
        HttpContext context = app.Context;
        
        // Attempt to perform first request initialization
        FirstRequestInitialization.Initialize(context);
    }
        
    /// <summary>
    /// Sets the culture based on the language selection in the settings.
    /// </summary>
    void Application_PreRequestHandlerExecute(object sender, EventArgs e)
    {
        var culture = BlogSettings.Instance.Culture;
        if (!string.IsNullOrEmpty(culture) && !culture.Equals("Auto"))
        {
            CultureInfo defaultCulture = Utils.GetDefaultCulture();
            Thread.CurrentThread.CurrentUICulture = defaultCulture;
            Thread.CurrentThread.CurrentCulture = defaultCulture;
        }
    }

    private class FirstRequestInitialization
    {
        private static bool _initializedAlready = false;
        private readonly static object _SyncRoot = new Object();

        // Initialize only on the first request
        public static void Initialize(HttpContext context)
        {
            if (_initializedAlready) { return; }

            lock (_SyncRoot)
            {
                if (_initializedAlready) { return; }

                Utils.LoadExtensions();
                _initializedAlready = true;
            }
        }
    }
    
</script>