<%@ Page Title="" Language="C#" MasterPageFile="~/themes/FOTF/site.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="members_Default" %>
<%@ Register Src="/User controls/PostList.ascx" TagName="PostList" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" Runat="Server">
  <div id="divError" runat="Server" />
  <uc1:PostList ID="PostList1" runat="server" />
    <script type="text/javascript">
        $('#pagename h2 span').append("Members Home Page");
        
    </script>
</asp:Content>

