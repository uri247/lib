using System;
using System.Text;
using System.Net.Sockets;
using Matrix.Xmpp.Bind;
using Matrix.Xmpp.Client;
using Matrix.Xmpp.Roster;
using Matrix.Xmpp.Sasl;
using Matrix.Xmpp.Session;
using Matrix.Xmpp.Stream;
using Matrix.Xml;
using Matrix.Xmpp;
using Matrix;

using Iq = Matrix.Xmpp.Base.Iq;
using Message = Matrix.Xmpp.Base.Message;
using MxAuth = Matrix.Xmpp.Sasl.Auth;
using Presence = Matrix.Xmpp.Base.Presence;

namespace Server
{
	/// <summary>
	/// Zusammenfassung für XMPPSeverConnection.
	/// </summary>
	public class XmppSeverConnection
	{
		#region << Constructors >>
		public XmppSeverConnection()
		{
		    SessionId = null;
		    streamParser = new XmppStreamParser();
            
            streamParser.OnStreamStart += streamParser_OnStreamStart;
            streamParser.OnStreamEnd += streamParser_OnStreamEnd;
            streamParser.OnStreamElement += streamParser_OnStreamElement;
		}

		public XmppSeverConnection(Socket sock) : this()
		{	
			m_Sock = sock;
			m_Sock.BeginReceive(buffer, 0, BUFFERSIZE, 0, ReadCallback, null);		
		}
		#endregion
        private XmppStreamParser			streamParser;
		private Socket					m_Sock;
        private const int BUFFERSIZE = 1024;
        private byte[] buffer = new byte[BUFFERSIZE];
                
	
		public void ReadCallback(IAsyncResult ar) 
		{        
			// Retrieve the state object and the handler socket
			// from the asynchronous state object

			// Read data from the client socket. 
			int bytesRead = m_Sock.EndReceive(ar);

			if (bytesRead > 0) 
			{				
                //streamParser.Push(buffer, 0, bytesRead);
                streamParser.Write(buffer, 0, bytesRead);
				// Not all data received. Get more.
				m_Sock.BeginReceive(buffer, 0, BUFFERSIZE, 0, ReadCallback, null);
			}
			else
			{
				m_Sock.Shutdown(SocketShutdown.Both);
				m_Sock.Close();
			}
            
		}

		private void Send(string data) 
		{
			// Convert the string data to byte data using ASCII encoding.
			byte[] byteData = Encoding.UTF8.GetBytes(data);

			// Begin sending the data to the remote device.
			m_Sock.BeginSend(byteData, 0, byteData.Length, 0, SendCallback, null);
		}

		private void SendCallback(IAsyncResult ar) 
		{
			try 
			{
				// Complete sending the data to the remote device.
				int bytesSent = m_Sock.EndSend(ar);
				Console.WriteLine("Sent {0} bytes to client.", bytesSent);

			} 
			catch (Exception e) 
			{
				Console.WriteLine(e.ToString());
			}
		}
	
		
		public void Stop()
		{
			Send("</stream:stream>");
//			client.Close();
//			_TcpServer.Stop();

			m_Sock.Shutdown(SocketShutdown.Both);
			m_Sock.Close();
		}
			
		
		#region << Properties and Member Variables >>
//		private int			m_Port			= 5222;		

	    public const string XmppDomain = "localhost";
        public string   User            { get; set; }
        public string   Resource        { get; set; }
	    public string   SessionId       { get; set; }
        public bool     IsAuthenticated { get; set; }
        public bool     IsBinded        { get; set; }
        
	    #endregion

        void streamParser_OnStreamEnd(object sender, Matrix.EventArgs e)
        {
            throw new NotImplementedException();
        }

        void streamParser_OnStreamElement(object sender, StanzaEventArgs e)
        {
            Console.WriteLine("OnStreamElement: " + e);

            if (e.Stanza is Presence)
            {
                // route presences here and handle all subscription stuff
            }
            else if (e.Stanza  is Message)
            {
                // route the messages here
            }
            else if (e.Stanza is Iq)
            {
                ProcessIq(e.Stanza as Iq);
            }

            if (e.Stanza is MxAuth)
            {
                var auth = e.Stanza as MxAuth;
                if (auth.SaslMechanism == SaslMechanism.PLAIN)
                    ProcessSaslPlainAuth(auth);
            }
        }

        void streamParser_OnStreamStart(object sender, StanzaEventArgs e)
        {
            SendStreamHeader();
            Send(BuildStreamFeatures());
        }

		private void ProcessIq(Iq iq)
		{
            if (iq.Query is Roster)
                ProcessRosterIq(iq);
            else if (iq.Query is Bind)
                ProcessBind(iq);
            else if (iq.Query is Session)
                ProcessSession(iq);
		}

		private void ProcessRosterIq(Iq iq)
		{
			if (iq.Type == IqType.get)
			{
				// Send the roster
				// we send a dummy roster here, you should retrieve it from a
				// database or some kind of directory (LDAP, AD etc...)
				iq.SwitchDirection();
				iq.Type = IqType.result;
				for (int i=1; i<11;i++)
				{
				    var ri = new RosterItem {Jid = new Jid("item" + i.ToString() + "@" + XmppDomain)};
				    ri.Name = "Item " + i.ToString();
				    ri.Subscription = Subscription.both;
				    ri.AddGroup("Group 1");
					iq.Query.Add(ri);
				}
				for (int i=1; i<11;i++)
				{
				    var ri = new RosterItem
				                 {
				                     Name = "Item JO " + i.ToString(),
				                     Subscription = Subscription.both,
				                     Jid = new Jid("item" + i.ToString() + "@jabber.org")
				                 };

				    ri.AddGroup("JO");
					iq.Query.Add(ri);
				}
				Send(iq);
			}
		}

        private void ProcessSaslPlainAuth(MxAuth auth)
        {
            string pass = null;
            string user = null;

            byte[] bytes = Convert.FromBase64String(auth.Value);
            string sasl = Encoding.UTF8.GetString(bytes);
            // trim nullchars
            sasl = sasl.Trim((char) 0);
            string[] split = sasl.Split((char) 0);

            if (split.Length == 3)
            {
                user = split[1];
                pass = split[2];
            }
            else if (split.Length == 2)
            {
                user = split[0];
                pass = split[1];
            }
         
            // here you should get the password from youdatabase or auth provider
            const string dbPass = "secret";
            if (pass != dbPass)
            {
                // user does not exist or wrong password
                Send(new Failure(FailureCondition.not_authorized));
            }
            else if(pass == dbPass)
            {
                // pass correct
                User = user;
                streamParser.Reset();
                IsAuthenticated = true;
                Send(new Success());    
            }
        }

        public void ProcessBind(Iq iq)
        {
            var bind = iq.Query as Bind;

            string res = bind.Resource;
            if (!String.IsNullOrEmpty(res))
            {
                var jid = new Jid(User, XmppDomain, res);
                var resIq = new BindIq
                {
                    Id = iq.Id,
                    Type = IqType.result,
                    Bind = { Jid = jid }
                };

                Send(resIq);
                Resource = res;
                IsBinded = true;
            }
            else
            {
                // return error
            }

        }

        public void ProcessSession(Iq iq)
        {
            /*            
                <iq type="set" id="aabca" >
                    <session xmlns="urn:ietf:params:xml:ns:xmpp-session"/>
                </iq>            
             */
            if (iq.Type == IqType.set)
                Send(new SessionIq { Id = iq.Id, Type = IqType.result });
        }
    
        /// <summary>
        /// sends the XMPP stream header
        /// </summary>
		private void SendStreamHeader()
		{
            var stream = new Stream
            {
                Version = "1.0",
                From = XmppDomain,
                Id = Guid.NewGuid().ToString()
            };

            Send(stream.StartTag());
		}

        private XmppXElement BuildStreamFeatures()
        {
            var feat = new StreamFeatures();
            //feat.Add(new StartTls());
            
            if (!IsAuthenticated)
            {
                var mechs = new Mechanisms();
                mechs.AddMechanism(SaslMechanism.PLAIN);
                feat.Mechanisms = mechs;
            }
            else if (!IsBinded && IsAuthenticated)
            {
                feat.Add(new Bind());
            }

            return feat;
        }

	    

	    private void Send(XmppXElement el)
		{
			Send(el.ToString(false));
		}

	}
}