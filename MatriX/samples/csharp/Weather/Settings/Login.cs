using Matrix;
using Matrix.Xml;

namespace Weather.Settings
{
    public class Login : XmppXElement
    {
        public Login() : base( "ag-software:settings", "Login" )
        {         
        }

        public string User
        {
            get { return GetTag("User"); }
            set { SetTag("User", value); }
        }

        public string Server
        {
            get { return GetTag("Server"); }
            set { SetTag("Server", value); }
        }

        public string Password
        {
            get { return GetTag("Password"); }
            set { SetTag("Password", value); }
        }

        public string Resource
        {
            get { return GetTag("Resource"); }
            set { SetTag("Resource", value); }
        }

        public int Priority
        {
            get { return GetAttributeInt("Priority"); }
            set { SetTag("Priority", value); }
        }

        public int Port
        {
            get { return GetTagInt("Port"); }
            set { SetTag("Port", value); }
        }

        public bool Tls
        {
            get { return GetTagBool("Tls"); }
            set { SetTag("Tls", value); }
        }
    }
}