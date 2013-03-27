using System;
using Matrix.Xmpp;
using Matrix.Xmpp.Client;

namespace SendMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            var xmppClient = new XmppClient
                                 {
                                     XmppDomain = "jabber.org",
                                     Username = "user1",
                                     Password = "secret"
                                 };

            xmppClient.OnRosterEnd += delegate
                                          {
                                              xmppClient.Send(new Message
                                                                  {
                                                                      To = "user2@jabber.org",
                                                                      Type = MessageType.chat,
                                                                      Body = "Hello World"
                                                                  });

                                          };
            xmppClient.Open();
            
            Console.WriteLine("Press return key to exit the application");
            Console.ReadLine();
            
            xmppClient.Close();
        }
    }
}