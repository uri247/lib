Imports System.Collections.ObjectModel
Imports System.Windows.Forms

Public Class RosterListViewItem
    Inherits ListViewItem
    Public WithEvents Resources As New ObservableCollection(Of String)()

    Public Sub New(text As String, imageIndex As Integer, group As ListViewGroup)
        MyBase.New(text, imageIndex, group)
        AddHandler Resources.CollectionChanged, AddressOf ResourcesChanged
    End Sub

    Private Sub ResourcesChanged(sender As Object, e As Specialized.NotifyCollectionChangedEventArgs)
        Dim tt As String = ""
        For Each r As String In Resources
            If tt.Length > 0 Then
                tt += vbCr & vbLf
            End If

            tt += r
        Next

        ToolTipText = tt
    End Sub
End Class