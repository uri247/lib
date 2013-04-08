Imports System
Imports System.Windows.Forms

''' <summary>
''' Summary description for InputBox.
'''</summary>
    Public Partial Class InputDialog
    Inherits Form

#Region "Windows Contols and Constructor"
    Public Sub New()
        '
        ' Required for Windows Form Designer support
        '
        InitializeComponent()
    End Sub

#End Region


#Region "Private Variables"
    Private m_formCaption As String = String.Empty
    Private m_formPrompt As String = String.Empty
    Private m_inputResponse As String = String.Empty
    Private m_defaultValue As String = String.Empty
#End Region

#Region "Public Properties"
    Public Property FormCaption() As String
        Get
            Return m_formCaption
        End Get
        Set
            m_formCaption = value
        End Set
    End Property

    Public Property FormPrompt() As String
        Get
            Return m_formPrompt
        End Get
        Set
            m_formPrompt = value
        End Set
    End Property

    Public Property InputResponse() As String
        Get
            Return m_inputResponse
        End Get
        Set
            m_inputResponse = value
        End Set
    End Property

    Public Property DefaultValue() As String
        Get
            Return m_defaultValue
        End Get
        Set
            m_defaultValue = value
        End Set
    End Property

#End Region


    Private Sub InputBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtInput.Text = m_defaultValue
        lblPrompt.Text = m_formPrompt
        Text = m_formCaption
        txtInput.SelectionStart = 0
        txtInput.SelectionLength = txtInput.Text.Length
        txtInput.Focus()
    End Sub

    Private Sub BtnOKClick(sender As Object, e As EventArgs) Handles btnOK.Click
        InputResponse = txtInput.Text
        Close()
    End Sub

    Private Sub BtnCancelClick(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub
End Class