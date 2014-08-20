<%@ control language="C#" autoeventwireup="true" inherits="Admin.Comments.Menu, App_Web_51t2zlqw" %>
<%@ Import Namespace="BlogEngine.Core" %>
<ul>
    <% if(BlogSettings.Instance.EnableCommentsModeration){ %>
    <li <%=Current("Pending.aspx")%>><a href="Pending.aspx"><%=Resources.labels.pending %> (<span id="pending_counter"><%=PendingCount%></span>)</a></li>
    <% } %>
    <li <%=Current("Approved.aspx")%>><a href="Approved.aspx"><%=Resources.labels.approved %> (<span id="comment_counter"><%=CommentCount%></span>)</a></li>
    <li <%=Current("Spam.aspx")%>><a href="Spam.aspx"><%=Resources.labels.spam %> (<span id="spam_counter"><%=SpamCount%></span>)</a></li>
</ul>