<%@ Page Title="" Language="C#" MasterPageFile="~/themes/FOTF/site.master" AutoEventWireup="true" CodeFile="Lookup.aspx.cs" Inherits="members_Lookup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" Runat="Server">
    <table id="memberTable" class="tablesorter">
        <thead>
            <tr><th class="header">Name</th><th class="header">Troop</th><th class="header">Hometown</th><th class="header">Pioneer</th><th class="header">Trapper</th><th class="header">Mountain Man</th><th>Actions</th></tr>
        </thead>
        <tbody>
            <% foreach (string s in memberList) { Response.Write(s); } %>
        </tbody>
    </table>
    <div id="pager">
			<a class="btn_no_text btn ui-state-default ui-corner-all first" title="First Page" href="#">
				<<
			</a>
			<a class="btn_no_text btn ui-state-default ui-corner-all prev" title="Previous Page" href="#">
				<
			</a>
							
			<input type="text" class="pagedisplay"/>
			<a class="btn_no_text btn ui-state-default ui-corner-all next" title="Next Page" href="#">
				>
			</a>
			<a class="btn_no_text btn ui-state-default ui-corner-all last" title="Last Page" href="#">
				>>
			</a>
			<select class="pagesize">
				<option value="10" selected="selected">50 results</option>
				<option value="20">100 results</option>
				<option value="30">150 results</option>
				<option value="40">200 results</option>
			</select>								
	</div>

    <div id="details" title="Member Info">
        
    </div>
    <asp:HiddenField ID="admin" runat="server" />
    <script src="/themes/FOTF/js/jquery.tablesorter.min.js" type="text/javascript"></script>
    <script src="/themes/FOTF/js/jquery.tablesorter.pager.js" type="text/javascript"></script>
    <script type="text/javascript">
        $('#pagename h2 span').append("Member Lookup");
        $('#pagename p').append("Re-Connect with an ole' Friend");

        $('#memberTable').tablesorter({ widgets: ['zebra'] }).tablesorterPager({ container: $("#pager") }); ;
        $(document).ready(function () {
            $('#details').dialog({
                autoOpen: false,
                width: 800,
                bgiframe: true,
                modal: true,
                buttons: {
                    "OK": function () {
                        $(this).dialog("close");
                    }
                }
            });

            $('#memberTable').delegate('.view', 'click', function () {
                var ID = $(this).closest("tr").find(".mid").text();
                varService = "members.asmx/GetMemberInfo";
                varData = "{'MemberID' : '" + ID + "'}";
                cbfunction = function (result) {
                    $("#details").html("");
                    $("#details").append(GetProfile(result));
                    if ($('#ctl00_cphBody_admin').val() == "true") {
                        $("#details").append("<p style=\"float: right;\"><a href=\"/membership.aspx?member=" + result.d.Email + "\">Edit</a> | <a href=\"#\" class=\"del\">Delete</a><span class=\"hidden Mid\">" + result.d.MemberID + "</span></p>");
                    }
                    $("#details").dialog('open');

                    $(".del").click(function () {
                        var ID = $('.Mid').text();
                        if (confirm("Are you sure?")) {
                            varService = "members.asmx/DeleteMember";
                            varData = "{'MemberID' : '" + ID + "'}";
                            cbfunction = function (result) {
                                location.reload(true);
                            }
                            CallService();
                        }
                    });
                };
                CallService();
            });
        });
    </script>
</asp:Content>

