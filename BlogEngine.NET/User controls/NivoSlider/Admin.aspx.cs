/* 
Author: rtur (http://rtur.net)
NivoSlider implementation for BlogEngine.NET (http://nivo.dev7studios.com)
*/

using System;
using System.IO;
using BlogEngine.Core;
using BlogEngine.Core.Web.Extensions;

namespace rtur.net.NivoSlider
{
    public partial class SliderAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            App_Code.WebUtils.CheckIfPrimaryBlog(false);

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                    DeleteItem(Request.QueryString["id"]);

                if (Request.QueryString["ctrl"] != null)
                    txtConrolId.Text = Request.QueryString["ctrl"];
            }
        }

        protected void SaveItem(object sender, EventArgs e)
        {
            try
            {
                Upload();

                var src = txtUploadImage.FileName.ToLowerInvariant();

                NivoSettings.ImageData.AddValues(new[] { txtConrolId.Text + ":" + src, txtUrl.Text, txtTitle.Text });

                ExtensionManager.SaveSettings(Constants.ExtensionName, NivoSettings.ImageData);
            }
            catch (Exception ex)
            {
                Utils.Log("rtur.net.SliderAdmin.SaveItem", ex);
            }
            Response.Redirect(Request.RawUrl);
        }

        protected void DeleteItem(string id)
        {
            var table = NivoSettings.ImageData.GetDataTable();
            
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (table.Rows[i][Constants.UID].ToString() == id)
                {
                    foreach (ExtensionParameter par in NivoSettings.ImageData.Parameters)
                    {
                        par.DeleteValue(i);
                    }

                    ExtensionManager.SaveSettings(Constants.ExtensionName, NivoSettings.ImageData);
                    break;
                }
            }

            // delete image
            string[] uid = id.Split(':');
            if (uid.GetUpperBound(0) < 1) return;

            var folder = Server.MapPath(Blog.CurrentInstance.StorageLocation + Constants.ImageFolder);
            var imgPath = Path.Combine(folder, uid[1]);
            File.Delete(imgPath);
        }

        private void Upload()
        {
            var folder = Server.MapPath(Blog.CurrentInstance.StorageLocation + Constants.ImageFolder);
            
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            txtUploadImage.PostedFile.SaveAs(Path.Combine(folder, txtUploadImage.FileName));
        }

    }
}
