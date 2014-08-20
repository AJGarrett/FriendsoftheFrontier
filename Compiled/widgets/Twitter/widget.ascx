﻿<%@ control language="C#" autoeventwireup="true" inherits="Widgets.Twitter.Widget, App_Web_wfoygrcv" %>
<asp:Repeater runat="server" ID="repItems" OnItemDataBound="RepItemsItemDataBound">
  <ItemTemplate>
    <img src="<%=BlogEngine.Core.Utils.RelativeWebRoot %>widgets/Twitter/twitter.ico" alt="Twitter" />
    <asp:Label runat="server" ID="lblDate" style="color:gray" /><br />
    <asp:Label runat="server" ID="lblItem" /><br /><br />
  </ItemTemplate>
</asp:Repeater>

<asp:HyperLink runat="server" ID="hlTwitterAccount" Text="Follow me on Twitter" rel="me" />