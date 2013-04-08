using System;
using System.Drawing;
using System.Windows.Forms;

using Matrix;
using Matrix.Xml;
using Matrix.Xmpp;
using Matrix.Xmpp.Client;
using Weather.Settings;

namespace Weather
{
    public partial class FrmMain : Form
    {
        private Settings.Settings settings;
        private Login login;

        public FrmMain()
        {
            InitializeComponent();

            SetLicense();

            RegisterCustomElements();
            InitSettings();
        }

        private static void RegisterCustomElements()
        {
            Factory.RegisterElement<Weather>("ag-software:weather", "weather");

            Factory.RegisterElement<Settings.Settings>("ag-software:settings", "Settings");
            Factory.RegisterElement<Login>("ag-software:settings", "Login");
        }

        private void InitSettings()
        {
            settings = Util.LoadSettings();
            if (settings.Login == null)
                settings.Login = new Login();
            
            login = settings.Login;
            
            if (login != null)
            {
                if (!string.IsNullOrEmpty(login.User))
                    txtUsername.Text = login.User;

                if (!string.IsNullOrEmpty(login.Server))
                    txtServer.Text = login.Server;
                
                if (!string.IsNullOrEmpty(login.Password))
                    txtPassword.Text    = login.Password;
            }
        }

        /// <summary>
        /// Sets the license and activate the evaluation.
        /// </summary>
        private static void SetLicense()
        {
            /*
            const string LIC =@"your licence code we sent you";
            Matrix.License.LicenseManager.SetLicense(LIC);
            */
        }
       
        private void cmdConnect_Click(object sender, System.EventArgs e)
        {
            xmppClient.SetUsername(txtUsername.Text);
            xmppClient.SetXmppDomain(txtServer.Text);
            xmppClient.Password = txtPassword.Text;

            xmppClient.Status = "I'm chatty";
            xmppClient.Show = Matrix.Xmpp.Show.chat;

            // set settings
            login.User = txtUsername.Text;
            login.Server = txtServer.Text;
            login.Password = txtPassword.Text;

            
            xmppClient.Open();
        }

        private void xmppClient_OnError(object sender, ExceptionEventArgs e)
        {
            DisplayEvent("OnError");
        }

        private void xmppClient_OnLogin(object sender, Matrix.EventArgs e)
        {
            DisplayEvent("OnLogin");   
        }

        private void DisplayEvent(string ev)
        {
            listEvents.Items.Add(ev);
            listEvents.SelectedIndex = listEvents.Items.Count - 1;
        }

        private void xmppClient_OnBind(object sender, JidEventArgs e)
        {
            DisplayEvent("OnBind");
        }

        private void xmppClient_OnClose(object sender, Matrix.EventArgs e)
        {
            DisplayEvent("OnClose");
        }

        private void xmppClient_OnRosterStart(object sender, Matrix.EventArgs e)
        {

        }

        private void xmppClient_OnRosterEnd(object sender, Matrix.EventArgs e)
        {
            DisplayEvent("OnRosterEnd");
        }

        private void xmppClient_OnRosterItem(object sender, Matrix.Xmpp.Roster.RosterEventArgs e)
        {
            DisplayEvent(string.Format( "OnRosterItem\t{0}\t{1}", e.RosterItem.Jid, e.RosterItem.Name ));
        }

        private void xmppClient_OnPresence(object sender, PresenceEventArgs e)
        {
            DisplayEvent(string.Format("OnPresence\t{0}", e.Presence.From));
        }

        private void xmppClient_OnIq(object sender, IqEventArgs e)
        {
            DisplayEvent("OnIq");

            if (e.Iq.Type == IqType.get &&
                e.Iq.Query is Weather)
            {
                var weather = e.Iq.Query as Weather;
                string zip = weather.Zip;
                // here you should lookup the weather information for the given zip code in a database or webservice
                // we just return some random numbers
                
                var temp = new Random().Next(-10, 40);
                var humidity = new Random().Next(10, 90);

                var wiq = new WeatherIq
                              {
                                  To = e.Iq.From,
                                  Type = IqType.result,
                                  Weather = new Weather {Temperature = temp, Humidity = humidity}
                              };
                // send the response
                xmppClient.Send(wiq);
            }
        }

        private void xmppClient_OnMessage(object sender, MessageEventArgs e)
        {
            DisplayEvent("OnMessage");
        }

        private void xmppClient_OnValidateCertificate(object sender, CertificateEventArgs e)
        {
            // always accept cert
            e.AcceptCertificate = true;
        }
       
        private void cmdDisconnect_Click(object sender, System.EventArgs e)
        {
            xmppClient.Close();
        }

        private void xmppClient_OnAuthError(object sender, Matrix.Xmpp.Sasl.SaslEventArgs e)
        {
            DisplayEvent("OnAuthError");
            xmppClient.Close();
        }
       
        private void xmppClient_OnReceiveXml(object sender, TextEventArgs e)
        {
            rtfDebug.SelectionStart = rtfDebug.Text.Length;
            rtfDebug.SelectionLength = 0;
            rtfDebug.SelectionColor = Color.Red;
            rtfDebug.AppendText("RECV: ");
            rtfDebug.SelectionColor = Color.Black;
            rtfDebug.AppendText(e.Text);
            rtfDebug.AppendText("\r\n"); 
        }

        private void xmppClient_OnSendXml(object sender, TextEventArgs e)
        {
            rtfDebug.SelectionStart = rtfDebug.Text.Length;
            rtfDebug.SelectionLength = 0;
            rtfDebug.SelectionColor = Color.Blue;
            rtfDebug.AppendText("SEND: ");
            rtfDebug.SelectionColor = Color.Black;
            rtfDebug.AppendText(e.Text);
            rtfDebug.AppendText("\r\n");
        }
       
        private void xmppClient_OnStreamError(object sender, StreamErrorEventArgs e)
        {
            DisplayEvent("OnStreamError");
        }

      
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Util.SaveSettings(settings);
        }

        private void cmdRequestWeatherInfo_Click(object sender, System.EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtZip.Text) && 
                !String.IsNullOrEmpty(txtRequestFrom.Text))
                RequestWeatherInfo(txtRequestFrom.Text, txtZip.Text);
        }

        private void RequestWeatherInfo(Jid from, string zip)
        {
            var wiq = new WeatherIq
                          {
                              Type = IqType.get,
                              To = from,
                              Weather = new Weather { Zip = zip }
                          };
            // we pass the zip code as state object to the IqFilter
            xmppClient.IqFilter.SendIq(wiq, WeatherInfoResponse, zip);
        }

        private void WeatherInfoResponse(object sender, IqEventArgs e)
        {
            var iq = e.Iq;

            if (iq.Type == IqType.result)
            {
                var weather = iq.Element<Weather>();
                if (weather != null)
                {
                    var zip = e.State as string;

                    MessageBox.Show(String.Format("weather info for zip code: {0}\r\n\r\nHumidity: {1}\r\nTemperature: {2}",
                                                  zip, weather.Humidity, weather.Temperature));
                }
            }
            else if (iq.Type == IqType.error)
            {
                // process errors here
            }
        }
    }
}