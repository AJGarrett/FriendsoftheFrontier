<%@ Page Title="" Language="C#" MasterPageFile="~/themes/FOTF/site.master" AutoEventWireup="true" CodeFile="photos.aspx.cs" Inherits="photos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" Runat="Server">
    <script src="Scripts/jquery.picasa.js" type="text/javascript"></script>
    <link href="Styles/prettyPhoto.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.prettyPhoto.js" type="text/javascript"></script>
    <style type="text/css">
			.picasa-albums li { 
				display: block;
				float: left;
				margin: 0px 5px 0px 0px;
				width: 180px;
				height: 160px;
				padding: 13px 13px 0px 13px;
				position: relative;
			}
			.picasa-album li { 
				display: block;
				float: left;
				margin: 0px 5px 0px 0px;
				width: 50px;
				height: 70px;
				padding: 13px 13px 0px 13px;
				position: relative;
			}
			
			.picasa-albums li div { /*, .picasa-album li  { */
				height: 134px;
				width: 181px;
			}
			.picasa-albums .frame {
				height: 134px;
				width: 181px;			
				background: url('/styles/brush-border.png') no-repeat;
				top: -1px;
				left: 2px;
				display: block;
				position: absolute;
			}
			.picasa-albums li div img { /* .picasa-album li a img { 
				border: 1px solid #ccc;
				padding: 0px;
				background: white; */
				width: 160px; 
				height: 110px;
				background: url('/styles/brush-border.png') no-repeat;
			}
			.picasa-albums li span, .picasa-album li span {
				display: block;
				text-align: center;
				margin: 0 auto;
				font: 9px verdana;
				color: Gray;
				height: 60px;
			}	
		</style>

    <p>Friends of the Frontiers is working on collecting photos from the history of the program.  If you have photos from camp involving frontiersmen in action, please email them to <a href="mailto:clrfrontiersmen.livethecode@picasaweb.com">our Picasa account</a>.</p>
    <div id="picasa"></div>
    <script type="text/javascript">
        $('#pagename h2 span').append("Photo Gallery");
        $('#pagename p').append("Remembering the Good 'Ole Days");
        
        $(document).ready(function () {
            $("#picasa").picasaAlbums("110816443951157810191", function (albums) {
                var picasa = "<ul class=\'picasa-albums\'>";
                $.each(albums, function (index, album) {
                    picasa += "<li id=\'" + album.id + "\'><span class=\'frame\'></span><div><img src=\'" + album.thumb + "\' /></div><span>" + album.title + "</span></li>";
                });
                picasa += "</ul>";
                $("#picasa").append(picasa);

                $('#picasa li[id]').click(function () {
                    $("#picasa").empty();
                    $("#picasa").picasaGallery("110816443951157810191", $(this).attr("id"), function(images) {
                        var animation, picasaAlbum;
                        picasaAlbum = "<ul class='picasa-album'>\n";
                        $.each(images, function(i, element) {
                            picasaAlbum += "  <li class='picasa-image'>\n";
                            picasaAlbum += "    <a class='picasa-image-large' rel='prettyPhoto[picasa]' href='" + element.url + "'>\n";
                            picasaAlbum += "      <img class='picasa-image-thumb' src='" + element.thumbs[0].url + "'/>\n";
                            picasaAlbum += "    </a>\n";
                            return picasaAlbum += "  </li>\n";
                        });
                        picasaAlbum += "</ul>";
                        $("#picasa").prepend(picasaAlbum);
                        animation = function() {
                            $(".picasa-image").each(function(index, element) {
                                return $(element).css("visibility", "visible").css("opacity", 0).delay(50 * index).animate({
                                opacity: 1
                                }, 300);
                            });
                        return $(".picasa-album a", $("#picasa")).prettyPhoto({
                                theme: 'dark_rounded',
                                social_tools: ''
                            });
                        };
                        return setTimeout(animation, 300);
                    });
                    return false;
                });
            });
        });

		</script>
</asp:Content>

