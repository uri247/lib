Imports System
Imports System.Windows.Forms
Imports Matrix
Imports Matrix.Xmpp.Client
Imports Matrix.Xmpp.Disco
Imports Matrix.Xmpp.PubSub

Public Partial Class FrmPubSub
    Inherits Form
    Private _dm As DiscoManager
    Private ReadOnly _pm As PubSubManager

    Public Sub New(client As XmppClient)
        InitializeComponent()

        XmppClient = client
        _pm = New PubSubManager(client)

        DiscoServer()
    End Sub

    Private Property XmppClient() As XmppClient
        Get
            Return m_XmppClient
        End Get
        Set
            m_XmppClient = Value
        End Set
    End Property
    Private m_XmppClient As XmppClient

    Private Sub DiscoServer()
        _dm = New DiscoManager(XmppClient)
        _dm.DiscoverItems(XmppClient.XmppDomain, New EventHandler(Of IqEventArgs)(AddressOf DiscoItemsResult))
    End Sub

    Private Sub DiscoItemsResult(sender As Object, e As IqEventArgs)
        '<iq from="vm-debian" to="alex@vm-debian/MatriX" id="MX_4" type="result" xmlns="jabber:client">
        '  <query xmlns="http://jabber.org/protocol/disco#items">
        '      <item jid="conference.vm-debian" />
        '      <item jid="irc.vm-debian" />
        '      <item jid="pubsub.vm-debian" />
        '      <item jid="vjud.vm-debian" />
        '  </query>
        '</iq>

        Dim query = e.Iq.Element(Of Xmpp.Disco.Items)()
        If query IsNot Nothing Then
            For Each itm As Xmpp.Disco.Item In query.GetItems()
                ' some servers have problems ifwe flood them weith too many packets here
                ' the sleep is a hack to avpid this problems.
                'System.Threading.Thread.Sleep(200);
                '_dm.DiscoverInformation(itm.Jid, itm.Node);
                _dm.DiscoverInformation(itm.Jid, itm.Node, New EventHandler(Of IqEventArgs)(AddressOf DiscoInfoResult))
            Next
        End If
    End Sub



    Private Sub DiscoInfoResult(sender As Object, e As IqEventArgs)
        Dim query = e.Iq.Element(Of Info)()
        If query IsNot Nothing Then
            For Each id As Xmpp.Disco.Identity In query.GetIdentities()
                If id.Category = "pubsub" Then
                    cboService.Items.Add(e.Iq.From)
                    Dim newnode = New DiscoNode(e.Iq.From, Nothing, e.Iq.From)
                    treeNodes.Nodes.Add(newnode)
                    DiscoPubSubNodes(e.Iq.From, Nothing, newnode)
                End If
            Next
        End If
    End Sub

    Private Sub DiscoPubSubNodes(jid As Jid, node As String, treenode As TreeNode)
        _dm.DiscoverItems(jid, node, New EventHandler(Of IqEventArgs)(AddressOf DiscoPubSubNodesResult), treenode)
    End Sub

    Private Sub DiscoPubSubNodesResult(sender As Object, e As IqEventArgs)
        '
'            <iq from="pubsub.vm-debian" type="result" to="alex@vm-debian/Alex-TP" id="aadda" >
'                <query xmlns="http://jabber.org/protocol/disco#items" node="/home" >
'                    <item node="/home/vm-debian" name="vm-debian" jid="pubsub.vm-debian" />
'                </query>
'            </iq>
'            

        Dim query = e.Iq.Element(Of Xmpp.Disco.Items)()
        If query IsNot Nothing Then
            For Each item As Xmpp.Disco.Item In query.GetItems()
                Dim newnode = New DiscoNode(item.Name, item.Node, item.Jid) With { _
                        .ContextMenuStrip = contextMenuStripNodes _
                        }
                DirectCast(e.State, TreeNode).Nodes.Add(newnode)
                DiscoPubSubNodes(item.Jid, item.Node, newnode)
            Next
        End If
    End Sub

    Private Sub cmdCreate_Click(sender As Object, e As System.EventArgs) Handles cmdCreate.Click
        _pm.CreateNode(cboService.Text, txtNode.Text, New EventHandler(Of IqEventArgs)(AddressOf CreateNodeResult))
    End Sub

    Private Sub CreateNodeResult(sender As Object, e As IqEventArgs)
        '
'            <iq from="pubsub.vm-debian" to="alex@vm-debian/MatriX" id="MX_9" type="result" xmlns="jabber:client">
'                <pubsub xmlns="http://jabber.org/protocol/pubsub">
'                    <create node="/home/vm-debian/alex" />
'                </pubsub>
'            </iq>
'            

        If e.Iq.Type = Xmpp.IqType.result Then
            Dim pubsub = e.Iq.Element(Of PubSub)()
            If pubsub IsNot Nothing Then
                If pubsub.Create IsNot Nothing Then
                    MessageBox.Show([String].Format("node {0} was created!", pubsub.Create.Node))
                End If
            End If
        ElseIf e.Iq.Type = Xmpp.IqType.[error] Then
            Dim node As String = ""

            Dim [error] = e.Iq.Element(Of [Error])()
            Dim pubsub = e.Iq.Element(Of PubSub)()
            If pubsub IsNot Nothing Then
                If pubsub.Create IsNot Nothing Then
                    node = pubsub.Create.Node
                End If
            End If

            If [error] IsNot Nothing Then

                Dim msg As String = [String].Format("creation of node {0} failed!" & vbCr & vbLf & "Error Condition: {1}" & vbCr & vbLf & "Error Type: {2}", node, [error].Condition, [error].Type)
                MessageBox.Show(msg)
            End If
        End If
    End Sub

    Private Sub treeNodes_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles treeNodes.AfterSelect
        If TypeOf e.Node Is DiscoNode Then
            Dim dn = TryCast(e.Node, DiscoNode)

            lblNode.Text = dn.Node
            lblJid.Text = dn.Jid
            lblName.Text = dn.Name
        End If
    End Sub

    Private Sub deleteToolStripMenuItem_Click(sender As Object, e As System.EventArgs) Handles deleteToolStripMenuItem.Click
        Dim pNode = TryCast(treeNodes.SelectedNode, DiscoNode)
        If pNode IsNot Nothing Then
            _pm.DeleteNode(cboService.Text, pNode.Node, AddressOf DeleteNodeResult, pNode)
        End If
    End Sub

    Private Sub DeleteNodeResult(sender As Object, e As IqEventArgs)
        If e.Iq.Type = Xmpp.IqType.result Then
            Dim pNode = TryCast(e.State, DiscoNode)
            If pNode IsNot Nothing Then
                MessageBox.Show(String.Format("node {0} was deleted!", pNode.Node))
                pNode.Remove()
            End If
            ' handle error here.
        ElseIf e.Iq.Type = Xmpp.IqType.error Then
        End If
    End Sub

    Private Sub cmdInstantNode_Click(sender As Object, e As System.EventArgs) Handles cmdInstantNode.Click
        _pm.CreateInstantNode(cboService.Text, AddressOf CreateInstantNodeResult)
    End Sub

    Private Sub CreateInstantNodeResult(sender As Object, e As IqEventArgs)
        If e.Iq.Type = Xmpp.IqType.result Then

            Dim pubsub = e.Iq.Element(Of PubSub)()
            If pubsub IsNot Nothing Then
                If pubsub.Create IsNot Nothing Then
                    MessageBox.Show([String].Format("node {0} was created!", pubsub.Create.Node))
                End If
            End If
            ' handle error here.
        ElseIf e.Iq.Type = Xmpp.IqType.[error] Then
        End If
    End Sub

    Private Sub subscribeToolStripMenuItem_Click(sender As Object, e As System.EventArgs) Handles subscribeToolStripMenuItem.Click
        ' subscibe to a node
        Dim pNode = TryCast(treeNodes.SelectedNode, DiscoNode)
        If pNode IsNot Nothing Then
            Dim myBareJid = New Jid() With { _
                    .User = XmppClient.Username, _
                    .Server = XmppClient.XmppDomain _
                    }
            _pm.Subscribe(cboService.Text, pNode.Node, myBareJid, AddressOf SubscribeResult, pNode.Node)
        End If
    End Sub

    Private Sub SubscribeResult(sender As Object, e As IqEventArgs)
        If e.Iq.Type = Matrix.Xmpp.IqType.result Then
            MessageBox.Show([String].Format("You are now subscribed to the node: {0}", TryCast(e.State, String)))
            ' handle error here.
        ElseIf e.Iq.Type = Matrix.Xmpp.IqType.[error] Then
        End If
    End Sub

    Private Sub publishToolStripMenuItem_Click(sender As Object, e As System.EventArgs) Handles publishToolStripMenuItem.Click
        Dim payload = InputBox("Enter the payload to publish!", "Payload", "")

        If payload = String.Empty Then
            Return
        End If

        Dim item = New Matrix.Xmpp.PubSub.Item() With { _
                .Value = payload _
                }

        'var item = new Matrix.Xmpp.PubSub.Item();
        'item.Add(new XmppXElement("mypaload", "mynamespace"));

        Dim pNode = TryCast(treeNodes.SelectedNode, DiscoNode)
        If pNode IsNot Nothing Then
            _pm.PublishItem(cboService.Text, pNode.Node, item, AddressOf PublishResult)
        End If
    End Sub

    Private Sub PublishResult(sender As Object, e As IqEventArgs)

        If e.Iq.Type = Xmpp.IqType.result Then
            ' handle error here.
        ElseIf e.Iq.Type = Xmpp.IqType.[error] Then
        End If
    End Sub

    Public Shared Function InputBox(prompt As String, title As String, defaultValue As String) As String
        Dim inputDialog = New InputDialog() With { _
                .FormPrompt = prompt, _
                .FormCaption = title, _
                .DefaultValue = defaultValue _
                }
        inputDialog.ShowDialog()

        Dim s As String = inputDialog.InputResponse
        inputDialog.Close()

        Return s
    End Function

End Class