Imports System.Windows.Forms
Imports Matrix

Class DiscoNode
    Inherits TreeNode
    Public Shadows Property Name() As String
        Get
            Return m_Name
        End Get
        Set
            m_Name = Value
        End Set
    End Property
    Private Shadows m_Name As String
    Public Property Node() As String
        Get
            Return m_Node
        End Get
        Set
            m_Node = Value
        End Set
    End Property
    Private m_Node As String
    Public Property Jid() As Jid
        Get
            Return m_Jid
        End Get
        Set
            m_Jid = Value
        End Set
    End Property
    Private m_Jid As Jid

    Public Sub New(argName As String, argNode As String, argJid As Jid)
        Name = argName
        Node = argNode
        Jid = argJid

        Text = Name + " / " + Node + " / " + Jid.ToString
    End Sub
End Class