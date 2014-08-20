using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Collections.Generic;

using BlogEngine.Core;

public partial class StandardSite : System.Web.UI.MasterPage
{
  protected void Page_Load(object sender, EventArgs e)
  {
      
  }

  public string GetPageMenu()
  {
      var queryString = this.Request.QueryString;
      var qsId = queryString["id"];
      BlogEngine.Core.Page page = BlogEngine.Core.Page.GetPage(new Guid(qsId));

      if (page.HasParentPage)
          page = BlogEngine.Core.Page.GetPage(page.Parent);

      string rv = "";
      if (page.HasChildPages)
      {
          rv += "<li class=\"widget\" id=\"PageMenu\"><div class=\"inside\"><h3>Pages</h3><ul>";
          rv += "<li><a href=\"" + page.AbsoluteLink + "\">" + page.Title + "</a></li>";
          
          List<BlogEngine.Core.Page> children = BlogEngine.Core.Page.Pages.FindAll(delegate (BlogEngine.Core.Page p) { return p.Parent == page.Id; });
          children.Sort(delegate(BlogEngine.Core.Page p1, BlogEngine.Core.Page p2) { return p1.Title.CompareTo(p2.Title); });
          foreach (BlogEngine.Core.Page p in children)
          {
              rv += "<li><a href=\"" + p.AbsoluteLink + "\">" + p.Title + "</a></li>";
          }

          rv += "</ul></div></li>";
      }
      
      return rv;
  }

}
