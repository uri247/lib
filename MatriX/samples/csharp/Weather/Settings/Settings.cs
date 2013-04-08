using Matrix.Xml;

namespace Weather.Settings
{
    public class Settings : XmppXElement
    {
        public Settings() : base("ag-software:settings", "Settings")
        {            
        }

        public Login Login
        {
            get { return Element<Login>(); }
            set { Replace(value); }
        }
    }
}