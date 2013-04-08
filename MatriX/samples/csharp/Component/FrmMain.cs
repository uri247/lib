using System.Drawing;
using System.Windows.Forms;
using Matrix;
using EventArgs=System.EventArgs;

namespace Component
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void CmdOpenClick(object sender, EventArgs e)
        {
            xmppComponent1.Hostname = txtHostname.Text;
            xmppComponent1.XmppDomain = txtXmppDomain.Text;
            xmppComponent1.Password = txtPassword.Text;
            xmppComponent1.Port = System.Int16.Parse(txtPort.Text);
            
            xmppComponent1.Open();
        }
        
        private void CmdCloseClick(object sender, EventArgs e)
        {
            xmppComponent1.Close();
        }

        private void ComponentOnLogin(object sender, Matrix.EventArgs e)
        {
            DisplayEvent("OnLogin");
        }

       

        private void DisplayEvent(string ev)
        {
            listEvents.Items.Add(ev);
            listEvents.SelectedIndex = listEvents.Items.Count - 1;
        }

        private void XmppComponentOnError(object sender, ExceptionEventArgs e)
        {
            DisplayEvent("OnError");
        }

        private void XmppComponentOnStreamError(object sender, StreamErrorEventArgs e)
        {
            DisplayEvent("OnStreamError");
        }

        private void XmppComponentOnXmlError(object sender, ExceptionEventArgs e)
        {
            DisplayEvent("OnXmlError");
        }

        private void XmppComponentOnAuthError(object sender, Matrix.Xmpp.Sasl.SaslEventArgs e)
        {
            DisplayEvent("OnAuthError");
        }

        private void xmppComponent1_OnClose(object sender, Matrix.EventArgs e)
        {
            DisplayEvent("OnClose");
        }

        private void xmppComponent1_OnIq(object sender, Matrix.Xmpp.Component.IqEventArgs e)
        {
            DisplayEvent("OnIq");
        }

        private void xmppComponent1_OnMessage(object sender, Matrix.Xmpp.Component.MessageEventArgs e)
        {
            DisplayEvent("OnMessage");
        }

        private void xmppComponent1_OnPresence(object sender, Matrix.Xmpp.Component.PresenceEventArgs e)
        {
            DisplayEvent("OnPresence");
        }
        
        private void XmppComponentOnReceiveXml(object sender, TextEventArgs e)
        {
            rtfDebug.SelectionStart = rtfDebug.Text.Length;
            rtfDebug.SelectionLength = 0;
            rtfDebug.SelectionColor = Color.Red;
            rtfDebug.AppendText("RECV: ");
            rtfDebug.SelectionColor = Color.Black;
            rtfDebug.AppendText(e.Text);
            rtfDebug.AppendText("\r\n");
        }

        private void XmppComponentOnSendXml(object sender, TextEventArgs e)
        {
            rtfDebug.SelectionStart = rtfDebug.Text.Length;
            rtfDebug.SelectionLength = 0;
            rtfDebug.SelectionColor = Color.Blue;
            rtfDebug.AppendText("SEND: ");
            rtfDebug.SelectionColor = Color.Black;
            rtfDebug.AppendText(e.Text);
            rtfDebug.AppendText("\r\n");
        }
    }
}