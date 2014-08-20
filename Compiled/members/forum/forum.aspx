<%@ page title="" language="C#" masterpagefile="~/themes/FOTF/site.master" autoeventwireup="true" inherits="members_forum_Default, App_Web_1i4eiyqm" %>
<%@ Register TagPrefix="YAF" Assembly="YAF" Namespace="YAF" %> 


<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" Runat="Server">
    <YAF:Forum runat="server" ID="forum" BoardID="1"> 

    </YAF:Forum> 
    <script type="text/javascript">
        $('#pagename h2 span').append("Forums");
        //$('#pagename p').append("Get er' Done!");
    </script>
</asp:Content> 

