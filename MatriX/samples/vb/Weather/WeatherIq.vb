Imports Matrix.Xmpp.Client

Public Class WeatherIq
	Inherits Iq
	Public Sub New()
		GenerateId()
	End Sub

	Public Property Weather() As Weather
		Get
			Return Element(Of Weather)()
		End Get
		Set
			Replace(value)
		End Set
	End Property
End Class
