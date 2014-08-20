<%@ page title="" language="C#" masterpagefile="~/themes/FOTF/site.master" autoeventwireup="true" inherits="members_Default, App_Web_l0l3n5ph" %>
<%@ Register Src="/User controls/PostList.ascx" TagName="PostList" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" Runat="Server">
  <div id="divError" runat="Server" />
  <uc1:PostList ID="PostList1" runat="server" />
    <script type="text/javascript">
        $('#pagename h2 span').append("Members Home Page");
        
    </script>
</asp:Content>

