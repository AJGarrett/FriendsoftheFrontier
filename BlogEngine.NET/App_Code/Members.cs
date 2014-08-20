using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Security;

using System.IO;
using System.Drawing;

using CLR;
using CLR.Utilities;

/// <summary>
/// Summary description for Members
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class Members : System.Web.Services.WebService {

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public CLR.Members GetMemberInfo(int MemberID)
    {
        return CLR.Members.GetSingle(MemberID).Frontiersman();
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void PostComment(int GBID, string text)
    {
        CLR.Members m = CLR.Members.GetSingle(HttpContext.Current.User.Identity.Name);

        text = HttpUtility.UrlDecode(text);

        new CLR.GuestbookComments(GBID, m.MemberID, text).Save();
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<CLR.GuestbookComments> next50(int GBID, int Count)
    {
        return GuestbookComments.GetAll(GBID).Next50(Count + 1).withDetail();
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void DeleteGuestbookComment(int CommentID)
    {
        GuestbookComments.GetSingle(CommentID).Delete();
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void DeleteMember(int MemberID)
    {
        CLR.Members m = CLR.Members.GetSingle(MemberID);

        Membership.DeleteUser(m.Email, true);

        IEnumerable<YAF.Types.Objects.TypedUserList> dt = YAF.Classes.Data.LegacyDb.UserList(1, null, null, null, null, null);

        YAF.Types.Objects.TypedUserList user = dt.ToList().Find(delegate(YAF.Types.Objects.TypedUserList u) { return u.Email == m.Email; });

        if (user != null && user.ProviderUserKey != "") { YAF.Classes.Data.LegacyDb.user_delete(user.UserID); }

        m.Delete();
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string SaveImage(string URL, string hfX, string hfY, string hfHeight, string hfWidth)
    {
        CLR.Members m = CLR.Members.GetSingle(HttpContext.Current.User.Identity.Name);

        int x, y, w, h;
        if (!int.TryParse(hfX, out x))
        {
            //Set default x value
            x = 0;
        }

        if (!int.TryParse(hfY, out y))
        {
            //Set default y value
            y = 0;
        }

        if (!int.TryParse(hfHeight, out h))
        {
            //Set default height value
            h = 0;
        }

        if (!int.TryParse(hfWidth, out w))
        {
            //Set default width value
            w = 0;
        }

        int markCharacter = URL.LastIndexOf(@".");
        string ext = URL.Substring(markCharacter + 1);

        CropImage(URL, x, y, w, h, ConfigurationManager.AppSettings["Storage"].ToString() + m.LastName + "-" + m.MemberID.ToString() + "." + ext);
        File.Delete(Server.MapPath("../") + URL);

        m.image = m.LastName + "-" + m.MemberID.ToString() + "." + ext;
        m.Save();

        return m.image;
    }

    public void CropImage(string path, int X, int Y, int Width, int Height, string savePath)
    {
        using (System.Drawing.Image img = System.Drawing.Image.FromFile(Server.MapPath("../") + path))
        {
            string ImgName = System.IO.Path.GetExtension(path);
            using (Bitmap bmpCropped = new Bitmap(Width, Height))
            {
                using (Graphics g = Graphics.FromImage(bmpCropped))
                {
                    Rectangle rectDestination = new Rectangle(0, 0, bmpCropped.Width, bmpCropped.Height);
                    Rectangle rectCropArea = new Rectangle(X, Y, Width, Height);
                    g.DrawImage(img, rectDestination, rectCropArea, GraphicsUnit.Pixel);
                    string SaveTo = savePath;
                    bmpCropped.Save(SaveTo);
                    if (bmpCropped.Width > 100 || bmpCropped.Height > 150)
                    {
                        ScaleImage((System.Drawing.Image)bmpCropped, 100, 150, savePath);
                    }
                }
            }
        }
    }
    protected void ScaleImage(System.Drawing.Image FullsizeImage, int NewWidth, int MaxHeight, string savePath)
    {
        //System.Drawing.Image FullsizeImage = System.Drawing.Image.FromFile(Server.MapPath("../../") + @"assets/LargeFiles/dogs.jpg");

        // Prevent using images internal thumbnail
        FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
        FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);

        if (FullsizeImage.Width > NewWidth || FullsizeImage.Height > MaxHeight)
        {
            if (FullsizeImage.Width <= NewWidth)
            {
                NewWidth = FullsizeImage.Width;
            }
        }

        int NewHeight = FullsizeImage.Height * NewWidth / FullsizeImage.Width;
        if (NewHeight > MaxHeight)
        {
            // Resize with height instead
            NewWidth = FullsizeImage.Width * MaxHeight / FullsizeImage.Height;
            NewHeight = MaxHeight;
        }

        System.Drawing.Image NewImage = FullsizeImage.GetThumbnailImage(NewWidth, NewHeight, null, IntPtr.Zero);

        // Clear handle to original file so that we can overwrite it if necessary
        FullsizeImage.Dispose();

        // Save resized picture
        NewImage.Save(savePath);
    }

}
