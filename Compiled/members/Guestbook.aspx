<%@ page title="" language="C#" masterpagefile="~/themes/FOTF/site.master" autoeventwireup="true" inherits="members_Guestbook, App_Web_l0l3n5ph" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" Runat="Server">
<p id="submit">
    <a href="#" class="button view">Comment</a>
</p>
<div id="guestbook">
<% string admintext = "";
   if (HttpContext.Current.User.IsInRole("FOTFAdmin"))
       admintext = "<span style=\"float:right;\"><a href=\"#\" class=\"del\">Delete</a></span>";
    
    foreach (CLR.GuestbookComments g in intitialList)
   {
       Response.Write("<div class=\"gbc\" id=\"" + g.GBCommentID.ToString() + "\"><div class=\"bio\"><img src=\"/assets/members/" + g.Member.image + "\" width=\"100\"><p>" + g.Member.FirstName + " " + g.Member.LastName + "</p></div><div class=\"comment\">" + g.Comment + "<br /><span style=\"font-size: smaller; font-style:italic;\">Posted at: " + g.DateCreated.ToShortDateString() + "</span>" + admintext + "</div></div>");
   } %>
</div>
   <span id="count" class="hidden">50</span>
   <asp:Label ID="gbID" class="hidden" runat="server"></asp:Label>
   <asp:Label ID="admin" class="hidden" runat="server"></asp:Label>
<div id="lastPostsLoader">
    <div id="details" title="Post Comment">
        Leave a message: <br />
        <textarea id="txtComments" rows="5" cols="75"></textarea>
    </div>
</div>
<link href="/Styles/jquery.wysiwyg.css" rel="stylesheet" type="text/css" />
<script src="/Scripts/jquery.wysiwyg.js" type="text/javascript"></script>
<script type="text/javascript">
    if (window.location.pathname == "/members/gb/") {
        $('#pagename h2 span').append("Guestbook");
        $('#pagename p').append("Banter around the Ole' Campfire");
    } else {
        $('#pagename h2 span').append("Heart of the Bear");
        $('#pagename p').append("Recognizing those Living the Code");
    }
    $(document).ready(function () {
        $('#details').dialog({
            autoOpen: false,
            width: 600,
            bgiframe: true,
            modal: true,
            buttons: {
                "Post": function () {
                    varService = "members.asmx/PostComment";
                    varData = "{'GBID' : '" + $('#ctl00_cphBody_gbID').text() + "', 'text' : '" + escape($('#txtComments').val()) + "'}";
                    cbfunction = function (result) {
                        $("#details").dialog('close');
                        window.location.reload();
                    };
                    CallService();
                },
                "Cancel": function () {
                    $(this).dialog("close");
                }
            }
        });

        $('.view').click(function () {
            $('#txtComments').val("");
            $('.wysiwyg').remove();
            $("#details").dialog('open');
            $('#txtComments').wysiwyg();
        });

        $('.del').click(function () {
            var ID = $(this).parent().parent().parent().attr("id");
            if (confirm("Are you sure?")) {
                varService = "members.asmx/DeleteGuestbookComment";
                varData = "{'CommentID' : '" + ID + "'}";
                cbfunction = function () {
                    $('#' + ID).remove();
                }
                CallService();
            }
        });

        function lastPostFunc() {
            $('div#lastPostsLoader').html('<img src="/images/bigLoader.gif">');
            var admin = "";
            if ($('#ctl00_cphBody_admin').text() == "true") {
                admin = "<span style=\"float:right;\"><a href=\"#\" class=\"del\">Delete</a></span>";
            }
            varCount = $('#count').text();
            varService = "members.asmx/next50";
            varData = "{'GBID' : '" + $('#ctl00_cphBody_gbID').text() + "', 'Count' : '" + varCount + "'}";
            cbfunction = function (result) {
                var arrayd = (typeof result.d) == 'string' ? eval('(' + result.d + ')') : result.d;
                for (var i = 0; i < arrayd.length; i++) {
                    var date = new Date(parseInt(arrayd[i].DateCreated.toString().substr(6)));
                    var d = date
                    var curr_date = d.getDate();
                    var curr_month = d.getMonth() + 1; //months are zero based
                    var curr_year = d.getFullYear();
                    $('#guestbook').append("<div class=\"gbc\" id=\"" + arrayd[i].GBCommentID.toString() + "\"><div class=\"bio\"><img src=\"/assets/members/" + arrayd[i].Member.image + "\" width=\"100\"><p>" + arrayd[i].Member.FirstName + " " + arrayd[i].Member.LastName + "</p></div><div class=\"comment\">" + arrayd[i].Comment + "<br /><span style=\"font-size: smaller; font-style:italic;\">Posted at: " + curr_date + "/" + curr_month + "/" + curr_year + "</span>" + admin + "</div></div>");
                }
                var total = parseInt(varCount) + arrayd.length;
                $('#count').text(total.toString());
                $('div#lastPostsLoader').empty();
            };
            CallService();
        };

        var timerid = null;

        $(window).scroll(function () {
            if (timerid === null && $(window).scrollTop() >= $(document).height() - $(window).height() - 2000) {
                lastPostFunc();
                timerid = setTimeout(function () { timerid = null; }, 500);
            }
        });

    });
</script>
</asp:Content>

