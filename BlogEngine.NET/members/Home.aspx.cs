using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BlogEngine.Core;

public partial class members_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Category c = Category.Categories.Find(delegate(Category cat) { return cat.Title == "Members Only"; });
        PostList1.ContentBy = ServingContentBy.Category;
        PostList1.Posts = Post.GetPostsByCategory(c.Id).ConvertAll(new Converter<Post, IPublishable>(delegate(Post p) { return p as IPublishable; }));   
    }
}