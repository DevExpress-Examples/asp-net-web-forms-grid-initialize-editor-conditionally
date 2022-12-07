Imports Microsoft.VisualBasic
Imports DevExpress.Web
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.HtmlControls

Namespace WebApplication_GridTest
	Public Class CustomEditFormTemplate
		Implements ITemplate
		Public Sub InstantiateIn(ByVal _container As Control) Implements ITemplate.InstantiateIn
			Dim container As GridViewEditFormTemplateContainer = TryCast(_container, GridViewEditFormTemplateContainer)
			Dim values() As Object = CType(container.Grid.GetRowValues(container.VisibleIndex, New String() { "Id", "Type", "DataValue" }), Object())
			Dim id As String = Convert.ToString(values(0))
			Dim dataType As String = Convert.ToString(values(1))
			Dim dataValue As String = Convert.ToString(values(2))

			Dim tb As New ASPxTextBox()
			tb.ID = "id"
			container.Controls.Add(tb)
			tb.Text = values(0).ToString()
			tb.ReadOnly = True

			tb = New ASPxTextBox()
			tb.ID = "datatype"
			container.Controls.Add(tb)
			tb.Text = values(1).ToString()
			tb.ReadOnly = True

			Select Case dataType
				Case "Text"
					Dim txt As New ASPxTextBox()
					txt.ID = "txt"
					container.Controls.Add(txt)
					txt.Text = dataValue
				Case "DateTime"
					Dim [date] As New ASPxDateEdit()
					[date].ID = "date"
					container.Controls.Add([date])
					[date].Date = Convert.ToDateTime(dataValue)
				Case "Dictionary1"
					Dim cmb As New ASPxComboBox()
					cmb.ID = "dict"
					container.Controls.Add(cmb)
					cmb.DataSource = DataProvider.GetDictionaryData(WebApplication_GridTest.DataType.Dictionary1)
					cmb.TextField = "Data"
					cmb.ValueField = "Id"
					cmb.DataBind()
					cmb.Value = dataValue
				Case "Dictionary2"
					Dim cmb2 As New ASPxComboBox()
					cmb2.ID = "dict"
					container.Controls.Add(cmb2)
                    cmb2.DataSource = DataProvider.GetDictionaryData(WebApplication_GridTest.DataType.Dictionary2)
					cmb2.TextField = "Data"
					cmb2.ValueField = "Id"
					cmb2.DataBind()
					cmb2.Value = dataValue
			End Select

			Dim updateBtn As New ASPxGridViewTemplateReplacement()
			updateBtn.ReplacementType = GridViewTemplateReplacementType.EditFormUpdateButton
			container.Controls.Add(updateBtn)

			Dim cancelBtn As New ASPxGridViewTemplateReplacement()
			cancelBtn.ReplacementType = GridViewTemplateReplacementType.EditFormCancelButton
			container.Controls.Add(cancelBtn)
		End Sub
	End Class
End Namespace