<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication_GridTest._Default" %>

<%@ Register Assembly="DevExpress.Web.v22.2, Version=22.2.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>




<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxMenu ID="ASPxMenu1" runat="server" Orientation="Vertical" Width="170px">
                <Items>
                    <dx:MenuItem NavigateUrl="~/CustomEditForm.aspx" Text="Custom EditForm Template" />
                    <dx:MenuItem NavigateUrl="~/CustomEditItem.aspx" Text="Custom EditItem Template" />
                </Items>
            </dx:ASPxMenu>
        </div>
    </form>
</body>
</html>
