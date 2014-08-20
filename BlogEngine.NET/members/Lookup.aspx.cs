using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CLR;
using CLR.Utilities;

public partial class members_Lookup : System.Web.UI.Page
{
    public List<string> memberList;

    protected void Page_Load(object sender, EventArgs e)
    {
        memberList = new List<string>();

        foreach (CLR.Members m in CLR.Members.GetAll().Frontiersman())
        {
            string pioneer, trapper, mtmn;

            pioneer = m.FrontiersmanDetail.PioneerYr.ToString();

            if (m.FrontiersmanDetail.TrapperYr == 0)
                trapper = "";
            else
                trapper = m.FrontiersmanDetail.TrapperYr.ToString();

            if (m.FrontiersmanDetail.MMYr == 0)
                mtmn = "";
            else
                mtmn = m.FrontiersmanDetail.MMYr.ToString();
            memberList.Add("<tr><td>" + m.FirstName + " " + m.LastName + "</td><td>" +
                m.FormerTroop + "</td><td>" + m.City + "</td><td>" + pioneer + "</td><td>" + trapper + "</td><td>" + mtmn + "</td><td><span class=\"hidden mid\">" + m.MemberID.ToString() + "</span><a href=\"#\" class=\"view\">(view more details)</a></td></tr>");
        }

        if (User.IsInRole("FOTFAdmin"))
            admin.Value = "true";
    }
}