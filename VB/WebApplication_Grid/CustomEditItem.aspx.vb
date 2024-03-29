﻿Imports DevExpress.Web
Imports DevExpress.Web.Data
Imports System

Namespace WebApplication_GridTest
	Partial Public Class CustomEditItem
		Inherits System.Web.UI.Page

		Protected Sub ASPxGridView1_Init(ByVal sender As Object, ByVal e As EventArgs)
			Dim grid As ASPxGridView = DirectCast(sender, ASPxGridView)
			CType(grid.Columns("DataValue"), GridViewDataColumn).EditItemTemplate = New CustomEditItemTemplate()
		End Sub

		Protected Sub ASPxGridView1_RowUpdating(ByVal sender As Object, ByVal e As ASPxDataUpdatingEventArgs)
			Dim grid As ASPxGridView = DirectCast(sender, ASPxGridView)
			Dim dataType As DataType = CType(grid.GetRowValuesByKeyValue(e.Keys(0), "Type"), DataType)

			Dim editorID As String = String.Empty
			Select Case dataType
				Case WebApplication_GridTest.DataType.Text
					editorID = "txt"
				Case WebApplication_GridTest.DataType.DateTime
					editorID = "date"
				Case WebApplication_GridTest.DataType.Dictionary1
					editorID = "dict"
				Case WebApplication_GridTest.DataType.Dictionary2
					editorID = "dict"
			End Select

			Dim editor As ASPxEdit = CType(grid.FindEditRowCellTemplateControl(CType(grid.Columns("DataValue"), GridViewDataColumn), editorID), ASPxEdit)
			e.NewValues("DataValue") = editor.Value.ToString()
		End Sub

		Protected Sub ASPxGridView1_CustomColumnDisplayText(ByVal sender As Object, ByVal e As ASPxGridViewColumnDisplayTextEventArgs)
			Dim dataType As DataType = CType(e.GetFieldValue(e.VisibleRowIndex, "Type"), DataType)

			If e.Column.FieldName = "DataValue" Then
				Select Case dataType
					Case WebApplication_GridTest.DataType.Dictionary1
						e.DisplayText = DataProvider.GetDictionaryItem(dataType, Convert.ToInt32(e.Value)).Data
					Case WebApplication_GridTest.DataType.Dictionary2
						e.DisplayText = DataProvider.GetDictionaryItem(dataType, Convert.ToInt32(e.Value)).Data
				End Select
			End If
		End Sub
	End Class
End Namespace