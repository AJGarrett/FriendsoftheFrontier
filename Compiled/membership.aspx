<%@ page title="" language="C#" masterpagefile="~/themes/FOTF/site.master" autoeventwireup="true" inherits="membership, App_Web_dnnsanpd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" Runat="Server">
    <script type="text/javascript" src="/scripts/maskedinput.js"></script>
    <script type="text/javascript" src="/scripts/formee.js"></script>
    <script type="text/javascript" src="/scripts/jQuery.validity.min.js"></script>
    <script type="text/javascript" src="/scripts/jquery.alphanumeric.pack.js"></script>
    <script src="/themes/FOTF/js/ajaxupload.js" type="text/javascript"></script>
    <script src="/themes/FOTF/js/jquery.Jcrop.min.js" type="text/javascript"></script>
    <link href="/themes/FOTF/css/jquery.Jcrop.css" rel="stylesheet" type="text/css" />
    <p>Membership in Friends of the Frontier is exclusivly for members of the Chief Logan Reservation Frontiersman Program. If you are not a member, please come out to camp next summer, and join the program. It's a BLAST! For members of the program, please fill out the below form, and you will recieve a confirmation e-mail with more information.</p>
    <asp:Panel Visible="false" runat="server" ID="pnlSuccess">
        <div class="formee">
            <div class="grid-12-12">
                <div class="formee-msg-success">
                    Successfully Saved!
                    <ul></ul>
                </div>
            </div>
        </div>    
    </asp:Panel>
    <asp:Panel Visible="false" runat="server" ID="pnlError">
        <div class="formee">
            <div class="grid-12-12">
                <div class="formee-msg-error">
                    Something is missing.   Please enable javascript for more information.
                    <ul></ul>
                </div>
            </div>
        </div>    
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlGeneral">
        <div class="formee">
            <div class="grid-4-12">
                <label>First Name<em class="formee-req">*</em></label>
                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            </div>
            <div class="grid-4-12">
                <label>Last Name<em class="formee-req">*</em></label>
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            </div>
            <div class="grid-4-12">
                <label>Nickname</label>
                <asp:TextBox ID="txtNickname" runat="server"></asp:TextBox>
            </div>
            <div class="grid-8-12">
                <label>Email<em class="formee-req">*</em></label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </div>
            <div class="grid-4-12">
                <label>Birthday<em class="formee-req">*</em></label>
                <asp:TextBox ID="txtBirthday" runat="server"></asp:TextBox>
            </div>
            <div class="grid-6-12">
                <label>Password<em class="formee-req">*</em></label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div class="grid-6-12">
                <label>Confirm Password<em class="formee-req">*</em></label>
                <asp:TextBox ID="txtPasswordConfirm" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div class="grid-12-12">
                <label>Address<em class="formee-req">*</em></label>
                <asp:TextBox ID="txtAddress" CssClass="formee-medium" runat="server"></asp:TextBox>
            </div>
            <div class="grid-4-12">
                <label>City<em class="formee-req">*</em></label>
                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
            </div>
            <div class="grid-4-12">
                <label>State<em class="formee-req">*</em></label>
                <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
            </div>
            <div class="grid-4-12">
                <label>Zip<em class="formee-req">*</em></label>
                <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
            </div>
            <div class="grid-6-12">
                <label>Troop<em class="formee-req">*</em></label>
                <asp:TextBox ID="txtTroop" runat="server"></asp:TextBox>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlGeneral2" runat="server">
        <div class="formee">
            <div class="grid-6-12">
                <label>Former Troop</label>
                <asp:TextBox ID="txtFormerTroop" runat="server"></asp:TextBox>
            </div>
            <div class="grid-6-12">
                <label>Highest Rank</label>
                <asp:TextBox ID="txtRank" runat="server"></asp:TextBox>
            </div>
            <div class="grid-4-12">
                <label>Website</label>
                <asp:TextBox ID="txtWebsite" runat="server" class="jq_watermark" placeholder="http://"></asp:TextBox>
            </div>
            <div class="grid-4-12">
                <label>Facebook</label>
                <asp:TextBox ID="txtFacebook" runat="server" class="jq_watermark" placeholder="http://"></asp:TextBox>
            </div>
            <div class="grid-4-12">
                <label>Twitter</label>
                <asp:TextBox ID="txtTwitter" runat="server" class="jq_watermark" placeholder="@"></asp:TextBox>
            </div>
            <div class="grid-6-12">
                <label>Current Image</label>
                <asp:Image runat="server" ID="imgProfile" />
            </div>
            <div class="grid-6-12">
                <label>New Image</label>
                <a href="#" id="FformNew" class="formee-button">Upload A New Photo</a>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlFrontier1" runat="server">
        <div class="formee">
            <div class="grid-6-12">
                <label>Pioneer Year<em class="formee-req">*</em></label>
                <asp:DropDownList ID="ddl_PioneerYear" runat="server"></asp:DropDownList> 
            </div>
            <div class="grid-6-12">
                <label>Week<em class="formee-req">*</em></label>
                <asp:TextBox ID="txtPioneerWeek" CssClass="formee-small" runat="server"></asp:TextBox>
            </div>
            <div class="grid-6-12">
                <label>Trapper Year</label>
                <asp:DropDownList ID="ddl_TrapperYear" runat="server"></asp:DropDownList>
            </div>
            <div class="grid-6-12">
                <label>Week</label>
                <asp:TextBox ID="txtTrapperWeek" CssClass="formee-small" runat="server"></asp:TextBox>
            </div>
            <div class="grid-6-12">
                <label>Mountain Man</label>
                <asp:DropDownList ID="ddl_MMYear" runat="server"></asp:DropDownList>
            </div>
            <div class="grid-6-12">
                <label>Week</label>
                <asp:TextBox ID="txtMMWeek" CssClass="formee-small" runat="server"></asp:TextBox>
            </div>
            <div class="grid-12-12">
                <label>Comments:</label>
                <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlMM" runat="server">
        <div class="formee">
            <div class="grid-6-12">
                <label>Who gave you your MM Claws?</label>
                <asp:TextBox ID="txtMMClaws" runat="server"></asp:TextBox>
            </div>
            <div class="grid-6-12">
                <label>Who did your MM Ceremony?</label>
                <asp:TextBox ID="txtMMCeremony" runat="server"></asp:TextBox>
            </div>
        </div>
    </asp:Panel>
    <div class="formee">
        <div class="grid-6-12">
    	    <label>Please write the following code: <span id="txtCaptchaDiv" style="color:#F00"></span>
            <input type="hidden" id="txtCaptcha" /></label><asp:TextBox ID="txtCaptchaInput" CssClass="formee-medium" runat="server"></asp:TextBox>
    	</div>
        <div class="grid-6-12">
            <asp:Button ID="btnSubmit" runat="server" CssClass="formee-button" OnClick="btnSubmit_Click" Text="Submit" 
                OnClientClick="this.value='Saving....'; if (!validate()) { this.value='Submit'; return false; };" />
        </div>
        <div class="grid-12-12">
            <div class="validity-summary-container formee-msg-error">
                Here's a summary of the validation failures:
                <ul></ul>
            </div>
            <div class="formee-msg-error" id="emailValid" style="display: none;">
                Your email address is improperly formatted or You already have an account, please login to update your profile.
            </div>
        </div>
    </div>
    <div title="Image Crop" id="crop">
        <image id="crp"></image>
        <span class="hidden" id="crpType"></span><span class="hidden" id="crpURL"></span>
    </div>
    <span id="imgURL" class="hidden"></span>
    <span id="hfX" class="hidden"></span>
    <span id="hfY" class="hidden"></span>
    <span id="hfHeight" class="hidden"></span>
    <span id="hfWidth" class="hidden"></span>
    <script type="text/javascript">
        $('#pagename h2 span').append("Membership Form");
        $('#pagename p').append("Become A Member of FOTF");
        var a = Math.ceil(Math.random() * 9) + '';
        var b = Math.ceil(Math.random() * 9) + '';
        var c = Math.ceil(Math.random() * 9) + '';
        var d = Math.ceil(Math.random() * 9) + '';
        var e = Math.ceil(Math.random() * 9) + '';
        var code = a + b + c + d + e;
        document.getElementById("txtCaptcha").value = code;
        document.getElementById("txtCaptchaDiv").innerHTML = code;

        function ValidCaptcha() {
            var str1 = removeSpaces(document.getElementById('txtCaptcha').value);
            var str2 = removeSpaces(document.getElementById('#ctl00_cphBody_txtCaptchaInput').value);
            if (str1 == str2) {
                return true;
            } else {
                return false;
            }
        }


        function validate() {
            $(this).attr("disabled", true);
            $.validity.setup({ outputMode: "summary" });
            $.validity.clear();
            $.validity.start();
            $('#ctl00_cphBody_txtFirstName').require("First Name is required.");
            $('#ctl00_cphBody_txtLastName').require("Last Name is required.");
            $('#ctl00_cphBody_txtEmail').require("Email is required.").match("email");
            $('#ctl00_cphBody_txtAddress').require("Address is required.");
            $('#ctl00_cphBody_txtState').require("State is required.");
            $('#ctl00_cphBody_txtCity').require("City is required.");
            $('#ctl00_cphBody_txtZip').require("Zip Code is required.");
            $('#ctl00_cphBody_txtTroop').require("Troop # is required.");
            $('#ctl00_cphBody_txtTroopHometown').require("Hometown is required.");
            $('#ctl00_cphBody_ddl_PioneerYear').require("Year you became a Pioneer is required.");

            if (!$('#ctl00_cphBody_txtPassword').hasClass("nr") || $('#ctl00_cphBody_txtPassword').val() != "") {
                $('#ctl00_cphBody_txtPassword').require("Password is Required").minLength(8, "Passwords must be a minimum of 8 alphanumeric characters long");
                $('#ctl00_cphBody_txtPasswordConfirm').require("Please confirm the password");
                $('#ctl00_cphBody_txtPasswordConfirm').assert($('#ctl00_cphBody_txtPasswordConfirm').val() == $('#ctl00_cphBody_txtPassword').val(), "Passwords must match");
            }

            if (!$('#ctl00_cphBody_txtCaptchaInput').hasClass("nr")) {
                $('#ctl00_cphBody_txtCaptchaInput').require("Security Code is required - NO BOTS Allowed!").assert($('#txtCaptcha').val() == $('#ctl00_cphBody_txtCaptchaInput').val(), "Security Code is incorrect.");
            }


            var result = $.validity.end();

            if (result.valid == false) {
                $(this).attr("disabled", false);
                //alert("You are missing some required fields.  Please review the form and resubmit.");
                return false;
            } else {
                return true;
            }
        }

        //Check for Dup email
        $(document).ready(function () {
            $('#ctl00_cphBody_txtTrapperWeek').numeric();
            $('#ctl00_cphBody_txtPioneerWeek').numeric();
            $('#ctl00_cphBody_txtMMWeek').numeric();
            if ($('#ctl00_cphBody_txtBirthday').val() == "") {
                $('#ctl00_cphBody_txtBirthday').mask("99/99/9999");
            }

            if ($('#ctl00_cphBody_txtEmail').val() != "") {
                $('#ctl00_cphBody_txtPassword').addClass("nr")
                $('#ct100_cphBody_txtCAPTCHAInput').addClass("nr")
            }

            $('#ctl00_cphBody_txtEmail').change(function () {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "/Services/Validate.asmx/CheckEmail",
                    data: "{'emailaddress' : '" + $('#ctl00_cphBody_txtEmail').val() + "'}",
                    dataType: "json",
                    success: function (resultsvc) {
                        if (resultsvc.d == false) {
                            $('#ctl00_cphBody_btnSubmit').show();
                            $('#ctl00_cphBody_txtPassword').removeClass("nr")
                            $('#emailValid').attr("style", "display: none;");
                        } else {
                            $('#ctl00_cphBody_btnSubmit').hide();
                            $('#emailValid').removeAttr("style");
                        }
                    }
                });
            });

            var button = $('#FformNew'), interval;
            new AjaxUpload(button, {
                action: '/Services/FileHandler.ashx',
                name: 'myfile',
                onSubmit: function (file, ext) {
                    // change button text, when user selects file			
                    button.text('Uploading');

                    // If you want to allow uploading only 1 file at time,
                    // you can disable upload button
                    this.disable();

                    // Uploding -> Uploading. -> Uploading...
                    interval = window.setInterval(function () {
                        var text = button.text();
                        if (text.length < 13) {
                            button.text(text + '.');
                        } else {
                            button.text('Uploading');
                        }
                    }, 200);
                },
                onComplete: function (file, response) {
                    button.text('Upload a New Image');
                    $('#crp').attr("src", "/assets/temp/" + file);
                    $('#crpURL').html("/assets/temp/" + file);
                    $('#crpType').html(file);
                    $('#crop').dialog("open");
                    jcropapi = $('#crp').Jcrop({
                        onSelect: updateCoords,
                        onChange: updateCoords,
                        setSelect: [0, 0, 100, 150],
                        minSize: [100 / 150],
                        aspectRatio: 100 / 150
                    }, function () {
                        jcrop_api = this;
                    });
                    window.clearInterval(interval);
                }
            });
            function updateCoords(c) {
                $('#hfX').html(c.x);
                $('#hfY').html(c.y);
                $('#hfHeight').html(c.h);
                $('#hfWidth').html(c.w);
            }

            $('#crop').dialog({
                autoOpen: false,
                width: 800,
                bgiframe: false,
                modal: true,
                buttons: {
                    "Save": function () {
                        varService = "members.asmx/SaveImage";
                        varData = "{'URL' : '" + $('#crpURL').html() + "', 'hfX' : '" + $('#hfX').html() + "', 'hfY' : '" + $('#hfY').html() + "', 'hfHeight' : '" + $('#hfHeight').html() + "', 'hfWidth' : '" + $('#hfWidth').html() + "'}";
                        cbfunction = function (result) {
                            $('#ctl00_cphBody_imgProfile').attr("src", "/assets/members/" + result.d);
                            $('#crop').dialog("close");
                        };
                        CallService();
                    }
                }
            });
        });
    </script>
</asp:Content>

