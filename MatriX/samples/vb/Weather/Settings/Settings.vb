Imports Matrix.Xml

Namespace Settings
    Public Class Settings
	    Inherits XmppXElement
	    Public Sub New()
		    MyBase.New("ag-software:settings", "Settings")
	    End Sub

	    Public Property Login() As Login
		    Get
			    Return Element(Of Login)()
		    End Get
		    Set
			    Replace(value)
		    End Set
	    End Property
    End Class
End Namespace