using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Server
{
    public partial class FrmServer : Form
    {

        // Thread signal.
        private readonly ManualResetEvent allDone = new ManualResetEvent(false);
        private Socket m_Listener;
        private bool m_Listening;

        /// <summary>
        /// Main entry point of the application
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new FrmServer());
        }

        public FrmServer()
        {
            InitializeComponent();
        }

        private void cmdStart_Click(object sender, System.EventArgs e)
        {
            var myThreadDelegate = new ThreadStart(Listen);
            var myThread = new Thread(myThreadDelegate);
            myThread.Start();
        }

        private void cmdStop_Click(object sender, EventArgs e)
        {
            m_Listening = false;
            allDone.Set();
            //allDone.Reset();
        }

        private void Listen()
        {
            var localEndPoint = new IPEndPoint(IPAddress.Any, 5222);

            // Create a TCP/IP socket.
            m_Listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


            // Bind the socket to the local endpoint and listen for incoming connections.
            try
            {
                m_Listener.Bind(localEndPoint);
                m_Listener.Listen(10);

                m_Listening = true;

                while (m_Listening)
                {
                    // Set the event to nonsignaled state.
                    allDone.Reset();

                    // Start an asynchronous socket to listen for connections.
                    Console.WriteLine("Waiting for a connection...");
                    m_Listener.BeginAccept(AcceptCallback, null);

                    // Wait until a connection is made before continuing.
                    allDone.WaitOne();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        public void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.
            allDone.Set();
            // Get the socket that handles the client request.
            Socket newSock = m_Listener.EndAccept(ar);

            var con = new XmppSeverConnection(newSock);
            //listener.BeginReceive(buffer, 0, BUFFERSIZE, 0, new AsyncCallback(ReadCallback), null);
        }
    }
}
