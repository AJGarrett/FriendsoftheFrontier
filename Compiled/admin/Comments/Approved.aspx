﻿<%@ page title="" language="C#" masterpagefile="~/admin/admin.master" autoeventwireup="true" inherits="Admin.Comments.Approved, App_Web_0aeb0y0x" %>
<%@ Register src="Menu.ascx" tagname="TabMenu" tagprefix="menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server"> 
    <script type="text/javascript">
        LoadComments(1);
    </script>
    
	<div class="content-box-outer">
		<div class="content-box-right">
			<menu:TabMenu ID="TabMenu" runat="server" />
		</div>
		<div class="content-box-left">
            <h1><%=Resources.labels.approvedComments %></h1>
            <div class="tableToolBox">
                <div class="Pager"></div>
            </div>
            <div id="Container"></div>
            <div class="Pager"></div>
		</div>
	</div>      
</asp:Content>