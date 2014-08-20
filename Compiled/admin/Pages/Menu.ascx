<%@ control language="C#" autoeventwireup="true" inherits="Admin.Pages.Menu, App_Web_oarmeeu4" %>
<ul>
    <li <%=Current("EditPage.aspx")%>><a href="EditPage.aspx" class="new"><%=Resources.labels.addNewPage %></a></li>
    <li <%=Current("Pages.aspx")%>><a href="Pages.aspx"><%=Resources.labels.pages %></a></li>
</ul>