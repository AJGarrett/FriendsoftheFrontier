﻿<%@ Import Namespace="BlogEngine.Core" %>
<%@ control language="C#" autoeventwireup="true" inherits="Widgets.BlogRoll.Widget, App_Web_rfcu3bw4" %>
<blog:Blogroll ID="Blogroll1" runat="server" />
<a href="<%=Utils.AbsoluteWebRoot %>opml.axd" style="display: block; text-align: right"
    title="Download OPML file">Download OPML file <img src="<%=Utils.ApplicationRelativeWebRoot %>pics/opml.png"
        alt="OPML" /></a>