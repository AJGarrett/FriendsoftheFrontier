using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.IO;
using System.Drawing;

using CLR;
using MailChimp;

public partial class membership : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Load DropDwons
            int year = DateTime.Now.Year;

            if (DateTime.Now.Month < 6)
                year = year - 1;

            while (year >= 1980)
            {
                ddl_MMYear.Items.Add(new ListItem(year.ToString()));
                ddl_PioneerYear.Items.Add(new ListItem(year.ToString()));
                ddl_TrapperYear.Items.Add(new ListItem(year.ToString()));

                year--;
            }

            ddl_MMYear.Items.Insert(0, new ListItem());
            ddl_PioneerYear.Items.Insert(0, new ListItem());
            ddl_TrapperYear.Items.Insert(0, new ListItem());

            //is this an edit
            if (Request.QueryString.Count != 0 && Request.QueryString["member"] != null)
            {
                LoadMember(Request.QueryString["member"].ToString());
            }
            else if (User.Identity.IsAuthenticated)
            {
                LoadMember(User.Identity.Name);
            }
            else
            {
                pnlGeneral2.Visible = false;
                pnlMM.Visible = false;
            }
        }
    }

    protected void LoadMember(string email)
    {
        CLR.Members m = CLR.Members.GetSingle(email);
        FrontierHistory f = FrontierHistory.GetSingle(m.MemberID);

        txtFirstName.Text = m.FirstName;
        txtLastName.Text = m.LastName;
        txtNickname.Text = m.Nickname;
        txtEmail.Text = m.Email;
        txtAddress.Text = m.Address;
        txtCity.Text = m.City;
        txtState.Text = m.State;
        txtZip.Text = m.ZipCode;
        txtTroop.Text = m.CurrentTroop;
        txtComments.Text = m.Comments;

        imgProfile.ImageUrl = "/assets/members/" + m.image;
        imgProfile.Width = 100;
        imgProfile.Height = 149;

        txtFormerTroop.Text = m.FormerTroop;
        txtRank.Text = m.HighestRank;
        txtBirthday.Text = m.Birthday.ToShortDateString();
        txtWebsite.Text = m.Website;
        txtFacebook.Text = m.Facebook;
        txtTwitter.Text = m.Twitter;

        

        ddl_PioneerYear.SelectedValue = f.PioneerYr.ToString();
        txtPioneerWeek.Text = f.PioneerWk.ToString();
        ddl_TrapperYear.SelectedValue = f.TrapperYr.ToString();
        txtTrapperWeek.Text = f.TrapperWk.ToString();
        ddl_MMYear.SelectedValue = f.MMYr.ToString();
        txtMMWeek.Text = f.MMWk.ToString();

        txtMMClaws.Text = f.MMClaws;
        txtMMCeremony.Text = f.MMCeremony;

        if (f.MMWk != 0)
            pnlMM.Visible = true;
        else
            pnlMM.Visible = false;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        RegexUtilities r = new RegexUtilities();

        bool newuser = true;
        string username = "";

        //is this an edit
        if ((Request.QueryString.Count != 0 && Request.QueryString["member"] != null) && User.Identity.IsAuthenticated)
        {
            newuser = false;

            if (Request.QueryString.Count != 0 && Request.QueryString["member"] != null)
                username = Request.QueryString["member"].ToString();
            else
                username = User.Identity.Name;
        }
        bool changeEmail = false;
        string inputEmail = txtEmail.Text.Trim();
        bool valid = false;

        if (username != "" && inputEmail.Trim() != username)
            changeEmail = true;

        if (newuser && r.IsValidEmail(inputEmail) && txtCaptchaInput.Text != "" && TestINT(txtCaptchaInput.Text))
        {
            MembershipUser u = Membership.GetUser(inputEmail);
            if (u == null)
            {
                try
                {
                    Membership.CreateUser(inputEmail, txtPassword.Text, inputEmail);
                }
                catch (MembershipCreateUserException cu)
                {
                    FormatEmail fe = new FormatEmail();
                    fe.To = "andyjgarrett+FOTF@gmail.com";
                    fe.Subject = "Bad Email";
                    fe.Text = "This was submitted:  " + inputEmail;
                    fe.Send();
                }
                finally
                {
                    if (!User.IsInRole("FOTFUser")) 
                        Roles.AddUserToRole(inputEmail, "FOTFUser");

                    valid = true;
                }
                
            }
            else
            {
                if (!User.IsInRole("FOTFUser"))
                    Roles.AddUserToRole(inputEmail, "FOTFUser");

                valid = true;
            }
        }
        else if (changeEmail && r.IsValidEmail(inputEmail) && username != inputEmail.Trim())
        {
            string[] roles = Roles.GetRolesForUser(username);
            MembershipUser u = Membership.GetUser(inputEmail);
            if (u == null)
            {
                try
                {
                    Membership.CreateUser(inputEmail, txtPassword.Text, inputEmail);
                }
                catch (MembershipCreateUserException cu)
                {
                    FormatEmail fe = new FormatEmail();
                    fe.To = "andyjgarrett+FOTF@gmail.com";
                    fe.Subject = "Bad Email";
                    fe.Text = "This was submitted:  " + inputEmail;
                    fe.Send();
                }
                finally
                {
                    Roles.AddUserToRoles(inputEmail, roles);
                    if (!User.IsInRole("FOTFUser"))
                        Roles.AddUserToRole(inputEmail, "FOTFUser");
                    Membership.DeleteUser(username, true);
                    valid = true;
                }
            }

            
        }

        if (!newuser && !changeEmail && txtPassword.Text != "")
        {
            MembershipUser u = Membership.GetUser(inputEmail);
            if (u != null)
            {
                string temppw = u.ResetPassword();
                u.ChangePassword(temppw, txtPassword.Text);
            }
        }

        if (valid)
        {
            CLR.Members m = CLR.Members.GetSingle(inputEmail);
            FrontierHistory f;

            if (m == null || m.MemberID == 0)
            {
                m = new CLR.Members();
                f = new FrontierHistory();
                newuser = true;
            }
            else
            {
                f = FrontierHistory.GetSingle(m.MemberID);
            }

            m.FirstName = txtFirstName.Text;
            m.LastName = txtLastName.Text;
            m.Nickname = txtNickname.Text;
            m.Email = inputEmail;
            m.Address = txtAddress.Text;
            m.City = txtCity.Text;
            m.State = txtState.Text;
            m.ZipCode = txtZip.Text;
            m.CurrentTroop = txtTroop.Text;
            m.Comments = txtComments.Text;

            m.FormerTroop = txtFormerTroop.Text;
            m.HighestRank = txtRank.Text;
            DateTime test;
            if (DateTime.TryParse(txtBirthday.Text, out test))
                m.Birthday = Convert.ToDateTime(txtBirthday.Text);

            m.Website = txtWebsite.Text;
            m.Facebook = txtFacebook.Text;
            m.Twitter = txtTwitter.Text;

            //if (newPhoto.HasFile)
            //{
            //    m.image = NewImage();
            //}

            m.isFrontiersman = true;

            m.Save();

            f.MemberID = m.MemberID;
            if (TestINT(ddl_PioneerYear.SelectedValue))
                f.PioneerYr = Convert.ToInt32(ddl_PioneerYear.SelectedValue);
            if (TestINT(txtPioneerWeek.Text))
                f.PioneerWk = Convert.ToInt32(txtPioneerWeek.Text);
            if (TestINT(ddl_TrapperYear.SelectedValue))
                f.TrapperYr = Convert.ToInt32(ddl_TrapperYear.SelectedValue);
            if (TestINT(txtTrapperWeek.Text))
                f.TrapperWk = Convert.ToInt32(txtTrapperWeek.Text);
            if (TestINT(ddl_MMYear.SelectedValue))
                f.MMYr = Convert.ToInt32(ddl_MMYear.SelectedValue);
            if (TestINT(txtMMWeek.Text))
                f.MMWk = Convert.ToInt32(txtMMWeek.Text);

            f.MMClaws = txtMMClaws.Text;
            f.MMCeremony = txtMMCeremony.Text;

            f.Save();


            if (f.MMYr != 0 && !Roles.IsUserInRole(m.Email, "MountainMan"))
                Roles.AddUserToRole(m.Email, "MountainMan");


            //SEND EMAIL
            if (newuser)
            {
                FormatEmail email = new FormatEmail();
                email.From = "CLRFrontiersmen@gamil.com";
                email.To = m.Email;
                email.Subject = "Friends of the Frontier Comfirmation";
                email.Text = m.FirstName + " , <br /> " +
                    "<p>Thank you for joining Friends of the Frontier!  We hope you will enjoy the fellowship and service to the Frontier Code provided by FOTF. </p>" +
                    "<p>Check out the member’s link for new info and upcoming events!  Log in and see what’s going on with the CLR frontiersmen program!</p>" +
                    "<p>www.friendsofthefrontier.org/members/home.aspx</p>" +
                    "<p>If you have any questions, please email us at CLRFrontiersmen@gmail.com.</p>" +
                    "GRRR OUT!, FOTF Staff";

                email.Send();

                //RegexUtilities r = new RegexUtilities();
                var subscribeOptions =
                    new MailChimp.Types.Opt<MailChimp.Types.List.SubscribeOptions>(
                        new MailChimp.Types.List.SubscribeOptions
                        {
                            SendWelcome = false,
                            UpdateExisting = true,
                        });

                var merges = new MailChimp.Types.Opt<MailChimp.Types.List.Merges>(null);
                //new MailChimp.Types.Opt<MailChimp.Types.List.Merges>();
                //    new MailChimp.Types.List.Merges
                //        {
                //            {"NAME", "andyjgarrett@gmail.com"}
                //        });

                if (r.IsValidEmail(m.Email))
                {
                    MCApi m1 = new MCApi("a3182720930666de2d4cfaa730275f81-us2", true);
                    bool testSub = m1.ListSubscribe("c9ec97c24a", m.Email, merges, subscribeOptions);
                }

            }
            else if (changeEmail)
            {
                //RegexUtilities r = new RegexUtilities();
                var subscribeOptions =
                    new MailChimp.Types.Opt<MailChimp.Types.List.SubscribeOptions>(
                        new MailChimp.Types.List.SubscribeOptions
                        {
                            SendWelcome = false,
                            UpdateExisting = true,
                        });

                var merges =
                    new MailChimp.Types.Opt<MailChimp.Types.List.Merges>(
                        new MailChimp.Types.List.Merges
                            {
                                {"NAME", username}
                            });

                if (r.IsValidEmail(m.Email))
                {
                    MCApi m1 = new MCApi("a3182720930666de2d4cfaa730275f81-us2", true);
                    bool testSub = m1.ListSubscribe("c9ec97c24a", m.Email, merges, subscribeOptions);
                }
            }
            pnlError.Visible = false; 
            pnlSuccess.Visible = true;
        }
        else
        {
            pnlSuccess.Visible = false;
            pnlError.Visible = true;
        }
    }

    protected bool TestINT(string value)
    {
        int number;
        bool result = Int32.TryParse(value, out number);
        return result;
    }
}