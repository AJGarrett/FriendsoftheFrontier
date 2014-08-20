<%@ control language="C#" autoeventwireup="true" inherits="Admin.Tracking.Menu, App_Web_shk1ctse" %>
<ul>
    <li <%=Current("Pingbacks.aspx")%>><a href="Pingbacks.aspx"><%=Resources.labels.pingbacksAndTrackbacks %></a></li>
    <li <%=Current("referrers.aspx")%>><a href="referrers.aspx"><%=Resources.labels.referrers %></a></li>
</ul>