<%@ page language="C#" autoeventwireup="true" inherits="contact, App_Web_dnnsanpd" validaterequest="false" %>
<%@ Import Namespace="BlogEngine.Core" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" Runat="Server">
    <script type="text/javascript" src="/scripts/formee.js"></script>
    <div id="contact">
    <div id="divForm" class="formee" runat="server">
      <div style="font-size: larger;">
        <p>Friends of the Frontier was envisioned by C. David Walters.</p>
        <p>This project was realized by Josh Radcliffe and Andy Garrett. It is being supported by Cub Corwin, Rusty Penwell, and many other Black Beaders.</p>
        <p>You can also email us a <a href="mailto:clrfrontiersmen@gmail.com">clrfrontiersmen@gmail.com</a></p>
      </div>
      
      <div class="grid-12-12">
          <label for="<%=txtName.ClientID %>"><%=Resources.labels.name %></label>
          <asp:TextBox runat="server" id="txtName" cssclass="field" />
          <asp:requiredfieldvalidator runat="server" controltovalidate="txtName" ErrorMessage="<%$Resources:labels, required %>" validationgroup="contact" /><br />
      </div>

      <div class="grid-12-12">
          <label for="<%=txtEmail.ClientID %>"><%=Resources.labels.email %></label>
          <asp:TextBox runat="server" id="txtEmail" cssclass="field" />
          <asp:RegularExpressionValidator runat="server" ControlToValidate="txtEmail" display="dynamic" ErrorMessage="<%$Resources:labels, enterValidEmail %>" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" validationgroup="contact" />
          <asp:requiredfieldvalidator runat="server" controltovalidate="txtEmail" ErrorMessage="<%$Resources:labels, required %>" validationgroup="contact" /><br />
      </div>

      <div class="grid-12-12">
          <label for="<%=txtSubject.ClientID %>"><%=Resources.labels.subject %></label>
          <asp:TextBox runat="server" id="txtSubject" cssclass="field" />
          <asp:requiredfieldvalidator runat="server" controltovalidate="txtSubject" ErrorMessage="<%$Resources:labels, required %>" validationgroup="contact" /><br />
      </div>

      <div class="grid-12-12">
          <label for="<%=txtMessage.ClientID %>"><%=Resources.labels.message %></label>
          <asp:TextBox runat="server" id="txtMessage" textmode="multiline" rows="5" columns="30" />
          <asp:requiredfieldvalidator runat="server" controltovalidate="txtMessage" ErrorMessage="<%$Resources:labels, required %>" display="dynamic" validationgroup="contact" />    
      </div>

      <br /><br />
      <blog:RecaptchaControl runat="server" ID="recaptcha" />
      <asp:HiddenField runat="server" ID="hfCaptcha" />
      
      <asp:button runat="server" id="btnSend" Text="Send" OnClientClick="return beginSendMessage();" validationgroup="contact" />    
      <asp:label runat="server" id="lblStatus" visible="false">This form does not work at the moment. Sorry for the inconvenience.</asp:label>
    </div>
    
    <div id="thanks">
      <div id="divThank" runat="Server" visible="False">      
        <%=BlogSettings.Instance.ContactThankMessage %>
      </div>
    </div>
  </div>
  
  <script type="text/javascript">
    $('#pagename h2 span').append("Contact Us");
    $('#pagename p').append("We're quicker than snail mail!");

    function beginSendMessage()
    {
      if(!Page_ClientValidate('contact'))
          return false;

      var recaptchaResponseField = document.getElementById('recaptcha_response_field');
      var recaptchaResponse = recaptchaResponseField ? recaptchaResponseField.value : "";

      var recaptchaChallengeField = document.getElementById('recaptcha_challenge_field');
      var recaptchaChallenge = recaptchaChallengeField ? recaptchaChallengeField.value : "";
        
      var name = BlogEngine.$('<%=txtName.ClientID %>').value;
      var email = BlogEngine.$('<%=txtEmail.ClientID %>').value;
      var subject = BlogEngine.$('<%=txtSubject.ClientID %>').value;
      var message = BlogEngine.$('<%=txtMessage.ClientID %>').value;
      var sep = '-||-';
      var arg = name + sep + email + sep + subject + sep + message + sep + recaptchaResponse + sep + recaptchaChallenge;
      WebForm_DoCallback('__Page', arg, endSendMessage, 'contact', onSendError, false) 
      
      BlogEngine.$('<%=btnSend.ClientID %>').disabled = true;
      
      return false;
    }

    function endSendMessage(arg, context) {

        if (arg == "RecaptchaIncorrect") {
            displayIncorrectCaptchaMessage();
            BlogEngine.$('<%=btnSend.ClientID %>').disabled = false;

            if (document.getElementById('recaptcha_response_field')) {
                Recaptcha.reload();
            }
        }
        else {
            if (document.getElementById("spnCaptchaIncorrect")) document.getElementById("spnCaptchaIncorrect").style.display = "none";

            BlogEngine.$('<%=btnSend.ClientID %>').disabled = false;
            var form = BlogEngine.$('<%=divForm.ClientID %>')
            var thanks = BlogEngine.$('thanks');

            form.style.display = 'none';
            thanks.innerHTML = arg;
        }
    }

    function displayIncorrectCaptchaMessage() {
        if (document.getElementById("spnCaptchaIncorrect")) document.getElementById("spnCaptchaIncorrect").style.display = "";
    }

    function onSendError(err, context) {
        if (document.getElementById('recaptcha_response_field')) {
            Recaptcha.reload();
        }
        BlogEngine.$('<%=btnSend.ClientID %>').disabled = false;
        alert("Sorry, but the following occurred while attemping to send your message: " + err);
    }
  </script>
</asp:Content>