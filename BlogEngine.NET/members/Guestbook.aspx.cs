using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CLR;
using CLR.Utilities;

using YAF.Classes;

public partial class members_Guestbook : System.Web.UI.Page
{
    public List<GuestbookComments> intitialList;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        intitialList = new List<GuestbookComments>();

        if (!IsPostBack)
        {
            int GBID = 0;
            if (Page.RouteData.Values["gbtype"].ToString() != "gb")
                GBID = 2;
            else
                GBID = 1;

            intitialList = GuestbookComments.GetAll(GBID).Next50(0).withDetail();

            gbID.Text = GBID.ToString();

            if (User.IsInRole("FOTFAdmin"))
                admin.Text = "true";
            else
                admin.Text = "false";
        }

        
    }
}