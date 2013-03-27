Imports Matrix.Xml

Namespace Settings
	'   
'    This class shows how MatriX could also be used read and write custom xml files.
'    Here we use it for the application settings which are stored in xml files.
'     
'    This works similar to the .NET serialization, but is much easier to use.
'    All you have to do is derive from XmppXElement and write down your properties
'    
'    creating you own Xmpp extensions works exactly in the same way
'    

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