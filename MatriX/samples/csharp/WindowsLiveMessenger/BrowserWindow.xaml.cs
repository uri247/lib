using System;
using System.Linq;
using System.Windows;
using System.Text.RegularExpressions;

namespace WindowsLiveMessenger
{
    public partial class BrowserWindow : Window
    {
        private const string SCOPE = "wl.messenger";

        // put your client Id here.
        // If you have no client Id yet then read here how to create one: http://msdn.microsoft.com/en-us/library/bb676626.aspx
        private const string CLIENT_ID = "PUT_YOUR_CLIENT_ID_HERE";
        
        // Your redirect Uri
        private const string REDIRECT_URI = "http://www.ag-software.de/";
        
        private static readonly Uri SignInUrl =
            new Uri(
                String.Format(
                    @"https://oauth.live.com/authorize?client_id={0}&redirect_uri={1}&response_type=token&scope={2}",
                    CLIENT_ID, REDIRECT_URI, SCOPE));

        public BrowserWindow()
        {
            InitializeComponent();
            webBrowser.Navigate(SignInUrl);
        }

        private void webBrowser_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (e.Uri.Fragment.Contains("access_token"))
            {
                if (Application.Current.Properties.Contains("responseData"))
                    Application.Current.Properties.Clear();

                Application.Current.Properties.Add("responseData", 1);
                string[] responseAll = Regex.Split(e.Uri.Fragment.Remove(0, 1), "&");

                for (int i = 0; i < responseAll.Count(); i++)
                {
                    var nvPair = Regex.Split(responseAll[i], "=");
                    Application.Current.Properties.Add(nvPair[0], nvPair[1]);
                }
                Close();
            }
        }
    }
}