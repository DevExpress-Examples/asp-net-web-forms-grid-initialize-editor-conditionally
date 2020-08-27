<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="WebApplication_GridTest._Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxMenu" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<dx:ASPxMenu ID="ASPxMenu1" runat="server" RenderMode="Lightweight" Orientation="Vertical" Width="170px">
				<Items>
					<dx:MenuItem NavigateUrl="~/CustomEditForm.aspx" Text="Custom EditForm Template">
					</dx:MenuItem>
					<dx:MenuItem NavigateUrl="~/CustomEditItem.aspx" Text="Custom EditItem Template">
					</dx:MenuItem>
				</Items>
			</dx:ASPxMenu>
		</div>
	</form>
</body>
</html>
