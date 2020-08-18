<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="CustomEditItem.aspx.vb" Inherits="WebApplication_GridTest.CustomEditItem" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
			KeyFieldName="Id" OnInit="ASPxGridView1_Init" OnCustomColumnDisplayText="ASPxGridView1_CustomColumnDisplayText"
			OnRowUpdating="ASPxGridView1_RowUpdating">
			<Columns>
				<dx:GridViewCommandColumn VisibleIndex="0">
					<EditButton Visible="True">
					</EditButton>
				</dx:GridViewCommandColumn>
				<dx:GridViewDataTextColumn FieldName="Id" ReadOnly="true" VisibleIndex="1">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Type" ReadOnly="true" VisibleIndex="2">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="DataValue" VisibleIndex="3">
				</dx:GridViewDataTextColumn>
			</Columns>
			<SettingsEditing Mode="EditForm" />
		</dx:ASPxGridView>

		<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="WebApplication_GridTest.DataItem" SelectMethod="GetAll"
			TypeName="WebApplication_GridTest.DataProvider" UpdateMethod="Update">
			<UpdateParameters>
				<asp:Parameter Name="Id" Type="Int32" />
				<asp:Parameter Name="Type" Type="Object" />
				<asp:Parameter Name="DataValue" Type="Object" />
			</UpdateParameters>
		</asp:ObjectDataSource>
	</form>
</body>
</html>
