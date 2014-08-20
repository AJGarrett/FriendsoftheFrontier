namespace Admin.Users
{
    using System;
    using BlogEngine.Core;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Security;
    using System.Web.Services;

    using CLR;

    /// <summary>
    /// The Users.
    /// </summary>
    public partial class Users : System.Web.UI.Page
    {
        #region Public Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckSecurity();

            phNewUserRoles.Visible = Security.IsAuthorizedTo(BlogEngine.Core.Rights.EditOtherUsersRoles);
        }

        private static void CheckSecurity()
        {
            Security.DemandUserHasRight(AuthorizationCheck.HasAll, true, new[] {
                BlogEngine.Core.Rights.AccessAdminPages,
                BlogEngine.Core.Rights.EditOtherUsers
            });
            
        }

        protected void CreateLogins_Click(object sender, EventArgs e)
        {
            MembershipUserCollection allUsers = Membership.GetAllUsers();
            List<CLR.Members> allMembers = CLR.Members.GetAll();

            foreach (MembershipUser u in allUsers)
            {
                CLR.Members m1 = allMembers.Find(delegate(Members m) { return m.Email.Trim() == u.Email; });

                if (m1 != null)
                    allMembers.Remove(m1);
            }

            string emailedlist = "";
            string bademails = "";

            foreach (Members m in allMembers)
            {
                FrontierHistory f = FrontierHistory.GetSingle(m.MemberID);

                try
                {
                    Membership.CreateUser(m.Email.Trim(), "CLRFOTF" + f.PioneerYr.ToString(), m.Email.Trim());
                    //System.Web.Security.Roles.AddUserToRole(m.Email, "Registered");
                    if (!System.Web.Security.Roles.IsUserInRole(m.Email.Trim(), "FOTFUser"))
                        System.Web.Security.Roles.AddUserToRole(m.Email.Trim(), "FOTFUser");
                    if (f.MMYr != 0 && !System.Web.Security.Roles.IsUserInRole(m.Email, "MountainMan"))
                        System.Web.Security.Roles.AddUserToRole(m.Email, "MountainMan");

                    FormatEmail mail = new FormatEmail();
                    mail.To = m.Email;
                    mail.Subject = "Your Friends of the Frontier Login";
                    mail.Text = "Dear " + m.FirstName + "<p>This is an automated email.  Due to a potential issue with our membership database, we realized your " +
                        "login may have been deleted.   We have automatically recreated it for you.   You should be able to login now using this email address and the " +
                        "password <b>CLRFOTF" + f.PioneerYr.ToString() + "</b>.   <br /><br /><br /> Thanks, The FOTF Team!";
                    mail.Send();

                    emailedlist += m.Email + ", ";
                }
                catch (MembershipCreateUserException cu)
                {
                    bademails += m.Email + " (Reason: " + cu.StatusCode.ToString() + "), ";
                }
            }


            FormatEmail log = new FormatEmail();
            log.To = "andyjgarrett+FOTF@gmail.com";
            log.Subject = "Admin User re-create script";
            log.Text = "The following users were re-created: " + emailedlist + "<p> The following users failed: " + bademails;
            log.Send();

        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>The users.</returns>
        [WebMethod]
        public static List<MembershipUser> GetUsers()
        {
            CheckSecurity();

            int count;
            var userCollection = Membership.Provider.GetAllUsers(0, 999, out count);
            var users = userCollection.Cast<MembershipUser>().ToList();

            users.Sort((u1, u2) => string.Compare(u1.UserName, u2.UserName));

            return users;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets RolesList.
        /// </summary>
        protected string RolesList
        {
            get
            {
                var ret = string.Empty;
                const string Ptrn = "<input type=\"checkbox\" id=\"{0}\" class=\"chkRole\" /><span class=\"lbl\">{0}</span>";
                var allRoles = System.Web.Security.Roles.GetAllRoles().Where(r => !r.Equals(BlogConfig.AnonymousRole, StringComparison.OrdinalIgnoreCase));
                return allRoles.Aggregate(ret, (current, r) => current + string.Format(Ptrn, r, string.Empty));
            }
        }

        #endregion
    }
}