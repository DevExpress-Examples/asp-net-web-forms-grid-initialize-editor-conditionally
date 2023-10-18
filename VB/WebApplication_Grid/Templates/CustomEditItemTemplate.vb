Imports DevExpress.Web
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI

Namespace WebApplication_GridTest
	Public Class CustomEditItemTemplate
		Implements ITemplate

		Public Sub InstantiateIn(ByVal _container As Control) Implements ITemplate.InstantiateIn
			Dim container As GridViewEditItemTemplateContainer = TryCast(_container, GridViewEditItemTemplateContainer)
			Dim values() As Object = CType(container.Grid.GetRowValues(container.VisibleIndex, New String() { "Type", "DataValue" }), Object())
			Dim dataType As String = Convert.ToString(values(0))
			Dim dataValue As String = Convert.ToString(values(1))

			Select Case dataType
				Case "Text"
					Dim txt As New ASPxTextBox()
					txt.ID = "txt"
					txt.Text = dataValue
					container.Controls.Add(txt)

				Case "DateTime"
					Dim [date] As New ASPxDateEdit()
					[date].ID = "date"
					[date].Date = Convert.ToDateTime(dataValue)
					container.Controls.Add([date])

				Case "Dictionary1"
					Dim cmb As New ASPxComboBox()
					cmb.ID = "dict"
					cmb.DataSource = DataProvider.GetDictionaryData(WebApplication_GridTest.DataType.Dictionary1)
					cmb.TextField = "Data"
					cmb.ValueField = "Id"
					cmb.DataBind()
					cmb.Value = dataValue
					container.Controls.Add(cmb)
				Case "Dictionary2"
					Dim cmb2 As New ASPxComboBox()
					cmb2.ID = "dict"
					cmb2.DataSource = DataProvider.GetDictionaryData(WebApplication_GridTest.DataType.Dictionary2)
					cmb2.TextField = "Data"
					cmb2.ValueField = "Id"
					cmb2.DataBind()
					cmb2.Value = dataValue
					container.Controls.Add(cmb2)
			End Select
		End Sub
	End Class
End Namespace