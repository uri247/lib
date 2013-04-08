Imports Matrix.Xml

Public Class Weather
	Inherits XmppXElement
	Public Sub New()
		MyBase.New("ag-software:weather", "weather")
	End Sub

	Public Property Humidity() As Integer
		Get
			Return GetTagInt("humidity")
		End Get
		Set
			SetTag("humidity", value)
		End Set
	End Property

	Public Property Temperature() As Integer
		Get
			Return GetTagInt("temperature")
		End Get
		Set
			SetTag("temperature", value)
		End Set
	End Property

	Public Property Zip() As String
		Get
			Return GetTag("zip")
		End Get
		Set
			SetTag("zip", value)
		End Set
	End Property
End Class