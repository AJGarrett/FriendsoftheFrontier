<%@ page language="C#" autoeventwireup="true" masterpagefile="~/admin/admin.master" inherits="rtur.net.NivoSlider.SliderAdmin, App_Web_02cvpub2" %>
<%@ MasterType VirtualPath="~/admin/admin.master" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="rtur.net.NivoSlider" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
<div class="content-box-outer">
    <div class="content-box-full">
        
        <div class="info" style="float: right; width: 500px; position: relative; top: 35px">
            <h4>NivoSlider Help</h4>
            <p>To use slider, anywhere in your post add this token:</p>
            <p>	
	            [SLIDER:slider1]
            </p>
            <p>For more supported scenarios and usage examples visit <a href="http://rtur.net">rtur.net</a></p>
        </div>
        
        <div>
            <h1>Settings: Slider</h1>
            <div style="float: left; width: 500px">
                <p>
                    <span style="width: 120px; display:inline-block;">Control ID:</span>
                    <asp:TextBox ID="txtConrolId" runat="server" MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="reqCtrlId" ValidationGroup="data" ControlToValidate="txtConrolId" Text="<%$ Resources:labels, required %>" />
                </p>
                <p>
                    <span style="width: 120px; display:inline-block;">Site URL:</span>
                    <asp:TextBox ID="txtUrl" Width="300" runat="server" MaxLength="250"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="reqSiteUrl" ValidationGroup="data" ControlToValidate="txtUrl" Text="<%$ Resources:labels, required %>" />
                </p>
                <p>
                    <span style="width: 120px; display:inline-block;"><%=Resources.labels.title %>:</span>
                    <asp:TextBox ID="txtTitle" Width="300" runat="server" MaxLength="250"></asp:TextBox>
                </p>
                <p>
                    <span style="width: 120px; display:inline-block;"><%=Resources.labels.upload %>:</span>
                    <asp:FileUpload runat="server" id="txtUploadImage" />
                    <asp:RequiredFieldValidator runat="server" ID="reqUpload" ValidationGroup="data" ControlToValidate="txtUploadImage" Text="<%$ Resources:labels, required %>" />
                </p>
                <p>
                    <span style="width: 120px; display:inline-block;">&nbsp;</span>
                    <asp:button runat="server" ValidationGroup="data" CssClass="btn primary" id="btnSave" Text=" Add " OnClick="SaveItem" />    
                </p>
            </div>

            <div class="clear"></div>
            
            <div>
                <table id="RoleService" class="beTable rounded">
                  <thead>
                    <tr>
                      <th width="25">&nbsp;</th>
                      <th width="120">Conrol Id</th>
                      <th width="200">Image File</th>
	                  <th width="250">Title</th>
                      <th width="auto">URL</th>
                      <th width="120">&nbsp;</th>
                    </tr>
                  </thead>
                  <tbody>
                    <%
                    var i = 0;
                    foreach (DataRow row in NivoSettings.ImageData.GetDataTable().Rows)
                    {
                        var cls = i%2 == 0 ? "" : "alt";
                        string[] uid = row[Constants.UID].ToString().Split(':');
                        if (uid.GetUpperBound(0) < 1) continue;
                        var ctrl = uid[0];
                        var src = uid[1];
                    %>
                    <tr class="<%=cls %>">
                      <td><%=i + 1 %></td>
                      <td><%= ctrl %></td>
                      <td><%= src %></td>
	                  <td><%= row[Constants.Title] %></td>
                      <td><%= row[Constants.Url] %></td>
                      <td align="center" style="vertical-align:middle"><a class="deleteAction" href="?id=<%=row[Constants.UID].ToString() %>">Delete</a></td>
                    </tr>
                    <% i++; } %>
                  </tbody>
                </table>
            </div>
        
        </div>
    </div>
</div>
</asp:Content>