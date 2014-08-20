<%@ control language="C#" autoeventwireup="true" inherits="admin.Widgets.Menu, App_Web_lb0crfte" %>
<ul>
    <li <%=Current("Blogroll.aspx")%>><a href="Blogroll.aspx"><%=Resources.labels.blogroll %></a></li>
    <li <%=Current("Controls.aspx")%>><a href="Controls.aspx"><%=Resources.labels.commonControls %></a></li>
</ul>