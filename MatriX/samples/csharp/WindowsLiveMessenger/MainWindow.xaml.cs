using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using Matrix.Xmpp.Client;
using Matrix.Xmpp.Sasl;
using Matrix.Xmpp.Sasl.Processor.LiveMessenger;
using Matrix.Xmpp.Stream.Errors;

namespace WindowsLiveMessenger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool redirect;
        private XmppClient xmppClient = new XmppClient();
        
        public MainWindow()
        {
            InitializeComponent();

            //SetLicense();

            // set the XMPP Domain for Windows Live
            xmppClient.XmppDomain = "messenger.live.com";
            
            // add some event handlers
            xmppClient.OnStreamError += xmppClient_OnStreamError;
            xmppClient.OnClose += xmppClient_OnClose;
            xmppClient.OnLogin += xmppClient_OnLogin;
            xmppClient.OnSendXml += xmppClient_OnSendXml;
            xmppClient.OnReceiveXml += xmppClient_OnReceiveXml;
            xmppClient.OnBeforeSasl += xmppClient_OnBeforeSasl;

            xmppClient.OnRosterStart += xmppClient_OnRosterStart;
            xmppClient.OnRosterItem += xmppClient_OnRosterItem;
            xmppClient.OnRosterEnd += xmppClient_OnRosterEnd;

            xmppClient.OnPresence += xmppClient_OnPresence;
            xmppClient.OnIq += xmppClient_OnIq;
            xmppClient.OnMessage += xmppClient_OnMessage;
        }

        void xmppClient_OnMessage(object sender, MessageEventArgs e)
        {
            DisplayEvent("OnMessage");
            DisplayEvent(String.Format("   ==> From:{0} Body:{1}", e.Message.From, e.Message.Body));
        }

        void xmppClient_OnPresence(object sender, PresenceEventArgs e)
        {
            DisplayEvent("OnPresence");
            DisplayEvent(String.Format("   ==> From:{0} Show:{1} Status:{2}", e.Presence.From, e.Presence.Show.ToString(), e.Presence.Status));
        }

        void xmppClient_OnIq(object sender, IqEventArgs e)
        {
            DisplayEvent("OnIq");
            DisplayEvent(String.Format("   ==> From:{0}", e.Iq.From));
        }

        void xmppClient_OnRosterEnd(object sender, Matrix.EventArgs e)
        {
            DisplayEvent("OnRosterEnd");
        }

        void xmppClient_OnRosterItem(object sender, Matrix.Xmpp.Roster.RosterEventArgs e)
        {
            DisplayEvent("OnRosterItem");
        }

        void xmppClient_OnRosterStart(object sender, Matrix.EventArgs e)
        {
            DisplayEvent("OnRosterStart");
        }

        private static void SetLicense()
        {
            string lic = @"Your license";
            Matrix.License.LicenseManager.SetLicense(lic);
        }

        void xmppClient_OnLogin(object sender, Matrix.EventArgs e)
        {
            DisplayEvent("OnLogin");
            btnSignOut.IsEnabled = true;
        }

        void xmppClient_OnClose(object sender, Matrix.EventArgs e)
        {
            DisplayEvent("OnClose");
            if (redirect)
            {
                redirect = false;
                xmppClient.Open();
            }
        }

        void xmppClient_OnStreamError(object sender, Matrix.StreamErrorEventArgs e)
        {
            DisplayEvent("OnStreamError");
            /*
                <stream:error xmlns:stream="http://etherx.jabber.org/streams">
                    <see-other-host xmlns="urn:ietf:params:xml:ns:xmpp-streams">BAYMSG1020127.gateway.edge.messenger.live.com</see-other-host>
                </stream:error>
             */
            if (e.Error.Condition == Matrix.Xmpp.Stream.ErrorCondition.SeeOtherHost)
            {
                var soh = e.Error.Element<SeeOtherHost>();
                xmppClient.Hostname = soh.Hostname;
                xmppClient.Port = soh.Port;
                xmppClient.ResolveSrvRecords = false;
                redirect = true;
            }
        }

        void xmppClient_OnBeforeSasl(object sender, SaslEventArgs e)
        {
            // this event is not thread safe because it is blocking, so invoke is required for UI updates.
            Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() => DisplayEvent("OnBeforeSasl")));
            
            if (Application.Current.Properties.Contains("responseData"))
            {
                var accessToken = Application.Current.Properties["access_token"] as string;
                
                e.Auto = false;
                e.SaslMechanism = SaslMechanism.X_MESSENGER_OAUTH2;
                e.SaslProperties = new LiveMessengerProperties
                           {
                               AccessToken = accessToken
                           };
            }
        }

        void xmppClient_OnReceiveXml(object sender, Matrix.TextEventArgs e)
        {
            AddDebugRecv(e.Text);
        }

        void xmppClient_OnSendXml(object sender, Matrix.TextEventArgs e)
        {
            AddDebugSend(e.Text);
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var browser = new BrowserWindow();
            browser.Closed += browser_Closed;
            browser.Show();
        }

        void browser_Closed(object sender, EventArgs e)
        {
            xmppClient.Open();
        }

        void AddDebugRecv(string text)
        {
            var para = new Paragraph { Margin = new Thickness(0) };
            var run1 = new Run
            {
                Text = "RECV:",
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush(Colors.Blue)
            };
            
            var run2 = new Run
            {
                Text = text,
                FontWeight = FontWeights.Normal,
                Foreground = new SolidColorBrush(Colors.Black)
            };

            para.Inlines.Add(run1);
            para.Inlines.Add(run2);

            rtfDebug.Document.Blocks.Add(para);
            ScrollDown();
        }

        void AddDebugSend(string text)
        {
            var para = new Paragraph { Margin = new Thickness(0) };
            var run1 = new Run
            {
                Text = "SEND:",
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush(Colors.Red)
            };

            var run2 = new Run
                           {
                Text = text,
                FontWeight = FontWeights.Normal,
                Foreground = new SolidColorBrush(Colors.Black)
            };

            para.Inlines.Add(run1);
            para.Inlines.Add(run2);

            rtfDebug.Document.Blocks.Add(para);
            ScrollDown();
        }

        public void ScrollDown()
        {
           scrollRtf.ScrollToVerticalOffset(double.MaxValue);
        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            xmppClient.Close();
        }

        private void DisplayEvent(string ev)
        {
            listEvents.Items.Add(ev);
            listEvents.SelectedIndex = listEvents.Items.Count - 1;
        }
    }
}
