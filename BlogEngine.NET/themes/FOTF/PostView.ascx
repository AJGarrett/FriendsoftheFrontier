<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="false" Inherits="BlogEngine.Core.Web.Controls.PostViewBase" %>

<div class="post xfolkentry" id="post<%=Index %>">
    <h3><a href="<%=Post.RelativeLink %>"><%=Server.HtmlEncode(Post.Title) %></a></h3>
    <div class="meta">
        <span class="category"><%=CategoryLinks(" | ") %></span>
        <span class="date"><%=Post.DateCreated.ToString("d. MMMM yyyy HH:mm") %></span>
        <span class="comments"><a href="#"><%=Post.ApprovedComments.Count %></a></span>
    </div>
    <div class="text"><asp:PlaceHolder ID="BodyContent" runat="server" /></div>
    <div class="footer">    
    <div class="bookmarks">
      
    </div>
    
    <%=AdminLinks %>
    
    <% if (BlogEngine.Core.BlogSettings.Instance.ModerationType == BlogEngine.Core.BlogSettings.Moderation.Disqus)
       { %>
    <a rel="nofollow" href="<%=Post.PermaLink %>#disqus_thread"><%=Resources.labels.comments %></a>
    <%}
       else
       { %>
    <a rel="bookmark" href="<%=Post.PermaLink %>" title="<%=Server.HtmlEncode(Post.Title) %>">Permalink</a> |
    <a rel="nofollow" href="<%=Post.RelativeLink %>#comment"><%=Resources.labels.comments %> (<%=Post.ApprovedComments.Count %>)</a>   
    <%} %>
    </div>
</div>
