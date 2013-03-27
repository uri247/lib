using System.Drawing;
using System.Windows.Forms;

using Matrix;
using Matrix.Xmpp;
using Matrix.Xmpp.Client;
using Matrix.Xmpp.Muc.User;
using EventArgs = System.EventArgs;

namespace MiniClient
{
    public partial class FrmGroupChat : Form
    {
        private MucManager mm;
        #region << Constructors >>        
        public FrmGroupChat(XmppClient xmppClient, Jid roomJid, string nickname)
        {
            InitializeComponent();   
            
            _roomJid = roomJid;
            _xmppClient = xmppClient;
            _nickname = nickname;

            mm = new MucManager(xmppClient);

            // Setup new Message Callback using the MessageFilter
            _xmppClient.MessageFilter.Add(roomJid, new BareJidComparer(), MessageCallback);
            
            // Setup new Presence Callback using the PresenceFilter
            _xmppClient.PresenceFilter.Add(roomJid, new BareJidComparer(), PresenceCallback);

        }
        #endregion

        private readonly Jid                     _roomJid;
        private readonly XmppClient              _xmppClient;
        private readonly string                  _nickname;

        private void FrmGroupChat_Load(object sender, EventArgs e)
        {
            if (_roomJid != null)
            {
                mm.EnterRoom(_roomJid, _nickname);
            }
        }

        private void FrmGroupChat_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_roomJid != null)
            {
                mm.ExitRoom(_roomJid, _nickname);
                
                // Remove the Message Callback in the MessageFilter
                _xmppClient.MessageFilter.Remove(_roomJid);

                // Remove the Presence Callback in the MessageFilter
                _xmppClient.PresenceFilter.Remove(_roomJid);
            }

        }
       
        private void MessageCallback(object sender, MessageEventArgs e)
        {
            if (e.Message.Type == MessageType.groupchat)
                IncomingMessage(e.Message);
        }

      
        private void PresenceCallback(object sender, PresenceEventArgs e)
        {

            var mucX = e.Presence.MucUser;
            
            // check for status code 201, this means the room is not ready to use yet
            // we request an instant room and accept the and accept the default configuration by the server
            if (mucX.HasStatus(201)) // 201 =  room is awaiting configuration.
                mm.RequestInstantRoom(_roomJid);
           

            var lvi = FindListViewItem(e.Presence.From);
            if (lvi != null)
            {
                if (e.Presence.Type == PresenceType.unavailable)
                {
                    lvi.Remove();
                }
                else
                {
                    int imageIdx = Util.GetRosterImageIndex(e.Presence);
                    lvi.ImageIndex = imageIdx;
                    lvi.SubItems[1].Text = (e.Presence.Status ?? "");
                    
                    var u = e.Presence.MucUser;
                    if (u != null)
                    {
                        lvi.SubItems[2].Text = u.Item.Affiliation.ToString();
                        lvi.SubItems[3].Text = u.Item.Role.ToString();
                    }
                }
            }
            else
            {
                int imageIdx = Util.GetRosterImageIndex(e.Presence);
                
                var lv = new ListViewItem(e.Presence.From.Resource) {Tag = e.Presence.From.ToString()};

                lv.SubItems.Add(e.Presence.Status ?? "");
                
                var u = e.Presence.MucUser;
                if (u != null)
                {
                    lv.SubItems.Add(u.Item.Affiliation.ToString());
                    lv.SubItems.Add(u.Item.Role.ToString());
                }
                lv.ImageIndex = imageIdx;
                lvwRoster.Items.Add(lv);
            }
        }

        private ListViewItem FindListViewItem(Jid jid)
        {
            foreach (ListViewItem lvi in lvwRoster.Items)
            {
                if (jid.ToString().ToLower() == lvi.Tag.ToString().ToLower())
                    return lvi;
            }
            return null;
        }

        private void IncomingMessage(Matrix.Xmpp.Client.Message msg)
        {
            if (msg.Type == MessageType.error)
            {
                //Handle errors here
                // we dont handle them in this example
                return;
            }

            if (msg.Subject != null)
            {
                txtSubject.Text = msg.Subject;

                rtfChat.SelectionColor = Color.DarkGreen;
                // The Nickname of the sender is in GroupChat in the Resource of the Jid
                rtfChat.AppendText(msg.From.Resource + " changed subject: ");
                rtfChat.SelectionColor = Color.Black;                
                rtfChat.AppendText(msg.Subject);
                rtfChat.AppendText("\r\n");
            }
            else
            {
                if (msg.Body == null)
                    return;

                rtfChat.SelectionColor = Color.Red;
                // The Nickname of the sender is in GroupChat in the Resource of the Jid
                rtfChat.AppendText(msg.From.Resource + " said: ");
                rtfChat.SelectionColor = Color.Black;
                rtfChat.AppendText(msg.Body);
                rtfChat.AppendText("\r\n");
            }
        }

        private void cmdSend_Click(object sender, EventArgs e)
        {
            // Make sure that the users send no empty messages
            if (rtfSend.Text.Length > 0)
            {
                var msg = new Matrix.Xmpp.Client.Message
                              {
                                  Type = MessageType.groupchat,
                                  To = _roomJid,
                                  Body = rtfSend.Text
                              };

                _xmppClient.Send(msg);

                rtfSend.Clear();
            }
        }

        /// <summary>
        /// Changing the subject in a chatroom in MUC rooms this could return an error when you are a normal user and not allowed
        /// to change the subject.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdChangeSubject_Click(object sender, EventArgs e)
        {
            var msg = new Matrix.Xmpp.Client.Message
                          {
                              Type = MessageType.groupchat,
                              To = _roomJid,
                              Subject = txtSubject.Text
                          };

            _xmppClient.Send(msg);
        }
    }
}