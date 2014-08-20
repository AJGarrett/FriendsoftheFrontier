$(document).ready(function() {
	bluz_engage();
	bluz_minor();
	bluz_social_footer();
	bluz_switch_view();
	bluz_complete();


});

function bluz_switch_view(){
	$("a.switch_thumb").toggle(function(){
        $(this).addClass("swap");
        $("ul.grid").fadeOut("fast", function() {
			$(this).removeClass("grid");
            $(this).fadeIn("fast").addClass("list");
        });
    }, function () {
        $(this).removeClass("swap");
        $("ul.list").fadeOut("fast", function() {
			$(this).removeClass("list");
            $(this).fadeIn("fast").addClass("grid");
        });
    });
}

function bluz_engage(){
	Cufon.replace('h1, h2, h3, h4, h5, h6, p.tagline'); // enabling cufon
	$('#tabs').tabs({ fx: { opacity: 'toggle', height: 'toggle' } }); // make the tabs work
	$('ul.sf-menu').superfish({ 
        delay:       250                          // one second delay on mouseout 
	});
	$("a[rel^='prettyPhoto']").prettyPhoto(); // makes lightbox work
}

function bluz_social_footer(){
	$('.footer-widget .social-links a:has(img)').fadeTo("fast","0.7");
	$('.footer-widget .social-links a:has(img)').hover(function() {
		$(this).stop().fadeTo("fast","1");
		}, function() {
		$(this).stop().fadeTo("fast","0.7");
	});
}

function bluz_minor(){
	$('span.close').click(function() {
		$(this).parent().fadeOut(400);					   
	});
	$('#content img').hide();//hide all the images on the page
}

function bluz_complete(){
	$('ul.sf-menu').before('<div id="nav-finish"></div>');
	$('#pagename h2 span').after('<img src="/themes/FOTF/images/pagename-right.png" alt="" id="pagename-finish" />');
}


var i = 0;//initialize
var int=0;//Internet Explorer Fix
$(window).bind("load", function() {//The load event will only fire if the entire page or document is fully loaded
	var int = setInterval("preload(i)",300);//500 is the fade in speed in milliseconds
});	

function preload() {
	var images = $('#content img').length;//count the number of images on the page
	if (i >= images) {// Loop the images
		clearInterval(int);//When it reaches the last image the loop ends
	}
	$('#content img:hidden').eq(0).fadeIn(500);//fades in the hidden images one by one
	
	i++;//add 1 to the count
}

var varService;
var varData;
var cbfunction

function CallService() {
    $.ajax({
        type: "POST",
        url: "/Services/" + varService, // Location of the service
        data: varData, //Data sent to server
        contentType: "application/json; charset=utf-8", // content type sent to server
        dataType: "json", //Expected data format from server
        success: function (result) {//On Successfull service call
            if (cbfunction) {
                cbfunction(result);
            }
        },
        error: function (request, status, errorThrown) {
            alert("There was an issue with the request");
        } // When Service call fails
    });
}

function GetTitle(f) {
    if (f.MMYr != 0) {
        return "Mountain Man";
    } else if (f.TrapperYr != 0) {
        return "Trapper";
    } else {
        return "Pioneer";
    }
}

function WriteDate(date) {
    if (date != null) {
        var d = new Date(parseInt(date.toString().substr(6)));
        var curr_date = d.getDate();
        var curr_month = d.getMonth() + 1; //months are zero based
        var curr_year = d.getFullYear();

        if (curr_year != 1)
            return curr_date + "/" + curr_month + "/" + curr_year;
        else
            return "";
    } else {
        return "";
    }
}

function isNull(value) {
    if (value == null)
        return "";
    else
        return value;
}

function GetProfile(result) {
    var profile = "<img src=\"/assets/members/" + result.d.image + "\" width=\"100\" style=\"float: right;\"><h3>" + GetTitle(result.d.FrontiersmanDetail) + " " + result.d.FirstName + " " + result.d.LastName + "</h3>"
    if (result.d.Nickname != "" && result.d.Nickname != null) {
        profile += "<h4>AKA: " + result.d.Nickname + "</h4>";
    }
    profile += "<table width=\"100%\"><tr><td width=\"50%\"><b>Details:</b><br/>Email:  <a href=\"mailto:" + result.d.Email + "\">" + result.d.Email + "</a>";
    profile += "<br />Birthday: " + WriteDate(result.d.Birthday) + "<br />Current Troop: " + isNull(result.d.CurrentTroop);
    if (result.d.FormerTroop != "" && result.d.FormerTroop != null) {
        profile += "<br />Former Troop: " + result.d.FormerTroop;
    }
    if (result.d.HighestRank != "" && result.d.HighestRank != null) {
        profile += "<br />Rank: " + result.d.HighestRank;
    }
    if (result.d.FrontiersmanDetail.PioneerYr != 0) {
        profile += "<br />Pioneer: " + result.d.FrontiersmanDetail.PioneerYr.toString() + " / Week: " + result.d.FrontiersmanDetail.PioneerWk.toString();
    }
    if (result.d.FrontiersmanDetail.TrapperYr != 0) {
        profile += "<br />Trapper: " + result.d.FrontiersmanDetail.TrapperYr.toString() + " / Week: " + result.d.FrontiersmanDetail.TrapperWk.toString();
    }
    if (result.d.FrontiersmanDetail.MMYr != 0) {
        profile += "<br />Trapper: " + result.d.FrontiersmanDetail.MMYr.toString() + " / Week: " + result.d.FrontiersmanDetail.MMWk.toString();
    }

    profile += "</td><td><b>Other Sites:</b>";
    if (result.d.Website != "" && result.d.Website != null) {
        var add = "";
        if (result.d.Website.substring(0, 7) != "http://") { add = "http://"; }
        profile += "<br />Web: <a href=\"" + add + result.d.Website + "\">" + add + result.d.Website + "</a>";
    }
    if (result.d.Facebook != "" && result.d.Facebook != null) {
        var add = "";
        if (result.d.Facebook.substring(0, 7) != "http://") { add = "http://"; }
         profile += "<br />Facebook: <a href=\"" + add + result.d.Facebook + "\">" + add + result.d.Facebook + "</a>"
    }
    if (result.d.Twitter != "" && result.d.Twitter != null) {
        profile += "<br />Rank: <a href=\"http://twitter.com/" + result.d.Twitter + "\">" + result.d.Twitter + "</a>"
    }


    profile += "</td></tr></table>";
    if (result.d.Comments != "" && result.d.Comments != null) {
        profile += "<br /><b>Comments:</b><br /> " + result.d.Comments;
    }
   
   return profile;
}