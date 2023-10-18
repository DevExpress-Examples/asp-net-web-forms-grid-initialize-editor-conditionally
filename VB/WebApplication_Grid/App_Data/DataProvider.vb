Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace WebApplication_GridTest
	Public Class DataProvider
		Private Shared result As IList(Of DataItem)
		Private Shared result2 As List(Of DictionaryItem)
		Private Shared result3 As List(Of DictionaryItem)
		Shared Sub New()
			result = New List(Of DataItem)()
			result.Add(New DataItem(1, DataType.Text, "Example Text"))
			result.Add(New DataItem(2, DataType.DateTime, DateTime.Now.ToShortDateString()))
			result.Add(New DataItem(3, DataType.Dictionary1, "1"))
			result.Add(New DataItem(4, DataType.Dictionary2, "11"))

			result2 = New List(Of DictionaryItem)()
			result2.Add(New DictionaryItem(1, "Combo Data 1"))
			result2.Add(New DictionaryItem(2, "Combo Data 2"))
			result2.Add(New DictionaryItem(3, "Combo Data 3"))

			result3 = New List(Of DictionaryItem)()
			result3.Add(New DictionaryItem(11, "Combo Data 11"))
			result3.Add(New DictionaryItem(22, "Combo Data 22"))
			result3.Add(New DictionaryItem(33, "Combo Data 33"))
		End Sub

		Public Shared Function GetAll() As IList(Of DataItem)
			Return result
		End Function

		Public Shared Function GetDictionaryData(ByVal dataType As DataType) As IList(Of DictionaryItem)
			Return If(dataType = WebApplication_GridTest.DataType.Dictionary1, result2, result3)
		End Function

		Public Shared Function GetDictionaryItem(ByVal dataType As DataType, ByVal itemId As Integer) As DictionaryItem
			Dim target = If(dataType = WebApplication_GridTest.DataType.Dictionary1, result2, result3)
			Return (
				From q In target
				Where q.Id = itemId
				Select q).FirstOrDefault()
		End Function

		Public Shared Function Update(ByVal Id As Integer, ByVal type As DataType, ByVal datavalue As String) As Boolean
			Dim item As DataItem = result.Where(Function(i) i.Id = Id).FirstOrDefault()
			item.Type = type
			item.DataValue = datavalue
			Return True
		End Function
	End Class

	Public Class DataItem
		Public Property Id() As Integer
		Public Property Type() As DataType
		Public Property DataValue() As String

		Public Sub New(ByVal id As Integer, ByVal type As DataType, ByVal dataValue As String)
			Me.Id = id
			Me.Type = type
			Me.DataValue = dataValue
		End Sub
	End Class

	Public Enum DataType As Integer
		Text
		DateTime
		Dictionary1
		Dictionary2
	End Enum

	Public Class DictionaryItem
		Public Property Id() As Integer
		Public Property Data() As String
		Public Sub New(ByVal id As Integer, ByVal data As String)
			Me.Id = id
			Me.Data = data
		End Sub
	End Class
End Namespace