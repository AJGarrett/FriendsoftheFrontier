﻿<%@ control language="C#" autoeventwireup="true" inherits="Admin.Posts.Menu, App_Web_jggckyyx" %>
<ul>
    <li <%=Current("Add_entry.aspx")%>><a href="Add_entry.aspx" class="new"><%=Resources.labels.writeNewPost %></a></li>
    <li <%=Current("Posts.aspx")%>><a href="Posts.aspx"><%=Resources.labels.posts %></a></li>
    <li <%=Current("Categories.aspx")%>><a href="Categories.aspx"><%=Resources.labels.categories %></a></li>
    <li <%=Current("Tags.aspx")%>><a href="Tags.aspx"><%=Resources.labels.tags %></a></li>
</ul>