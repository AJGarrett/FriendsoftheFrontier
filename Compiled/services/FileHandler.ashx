<%@ WebHandler Language="C#" Class="FileHandler" %>

using System;
using System.Web;
using System.IO;

public class FileHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {

        string strFileName = Path.GetFileName(context.Request.Files[0].FileName);
        string strExtension = Path.GetExtension(context.Request.Files[0].FileName).ToLower();
        string strSaveLocation = context.Server.MapPath("/assets/temp/") + "" + strFileName;
        context.Request.Files[0].SaveAs(strSaveLocation);
        
        

        context.Response.ContentType = "text/plain";
        context.Response.Write("success");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}