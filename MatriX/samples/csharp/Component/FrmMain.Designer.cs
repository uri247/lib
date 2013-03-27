namespace Component
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdOpen = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listEvents = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rtfDebug = new System.Windows.Forms.RichTextBox();
            this.xmppComponent1 = new Matrix.Xmpp.Component.XmppComponent();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtHostname = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblHostname = new System.Windows.Forms.Label();
            this.txtXmppDomain = new System.Windows.Forms.TextBox();
            this.lblXmpDomain = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOpen
            // 
            this.cmdOpen.Location = new System.Drawing.Point(12, 112);
            this.cmdOpen.Name = "cmdOpen";
            this.cmdOpen.Size = new System.Drawing.Size(75, 23);
            this.cmdOpen.TabIndex = 0;
            this.cmdOpen.Text = "Open";
            this.cmdOpen.UseVisualStyleBackColor = true;
            this.cmdOpen.Click += new System.EventHandler(this.CmdOpenClick);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(93, 112);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 1;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.CmdCloseClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 146);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(473, 312);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listEvents);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(465, 286);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Events";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listEvents
            // 
            this.listEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listEvents.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listEvents.FormattingEnabled = true;
            this.listEvents.ItemHeight = 15;
            this.listEvents.Location = new System.Drawing.Point(3, 3);
            this.listEvents.Name = "listEvents";
            this.listEvents.Size = new System.Drawing.Size(459, 274);
            this.listEvents.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rtfDebug);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(465, 286);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Debug Xml";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rtfDebug
            // 
            this.rtfDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtfDebug.Location = new System.Drawing.Point(3, 3);
            this.rtfDebug.Name = "rtfDebug";
            this.rtfDebug.Size = new System.Drawing.Size(459, 280);
            this.rtfDebug.TabIndex = 0;
            this.rtfDebug.Text = "";
            // 
            // xmppComponent1
            // 
            this.xmppComponent1.Dispatcher = null;
            this.xmppComponent1.Hostname = null;
            this.xmppComponent1.ProxyHostname = null;
            this.xmppComponent1.ProxyPass = null;
            this.xmppComponent1.ProxyPort = 1080;
            this.xmppComponent1.ProxyType = Matrix.Net.Proxy.ProxyType.None;
            this.xmppComponent1.ProxyUser = null;
            this.xmppComponent1.ResolveSrvRecords = true;
            this.xmppComponent1.Transport = Matrix.Net.Transport.Socket;
            this.xmppComponent1.Uri = null;
            this.xmppComponent1.OnStreamError += new System.EventHandler<Matrix.StreamErrorEventArgs>(this.XmppComponentOnStreamError);
            this.xmppComponent1.OnLogin += new System.EventHandler<Matrix.EventArgs>(this.ComponentOnLogin);
            this.xmppComponent1.OnSendXml += new System.EventHandler<Matrix.TextEventArgs>(this.XmppComponentOnSendXml);
            this.xmppComponent1.OnMessage += new System.EventHandler<Matrix.Xmpp.Component.MessageEventArgs>(this.xmppComponent1_OnMessage);
            this.xmppComponent1.OnPresence += new System.EventHandler<Matrix.Xmpp.Component.PresenceEventArgs>(this.xmppComponent1_OnPresence);
            this.xmppComponent1.OnXmlError += new System.EventHandler<Matrix.ExceptionEventArgs>(this.XmppComponentOnXmlError);
            this.xmppComponent1.OnClose += new System.EventHandler<Matrix.EventArgs>(this.xmppComponent1_OnClose);
            this.xmppComponent1.OnAuthError += new System.EventHandler<Matrix.Xmpp.Sasl.SaslEventArgs>(this.XmppComponentOnAuthError);
            this.xmppComponent1.OnError += new System.EventHandler<Matrix.ExceptionEventArgs>(this.XmppComponentOnError);
            this.xmppComponent1.OnReceiveXml += new System.EventHandler<Matrix.TextEventArgs>(this.XmppComponentOnReceiveXml);
            this.xmppComponent1.OnIq += new System.EventHandler<Matrix.Xmpp.Component.IqEventArgs>(this.xmppComponent1_OnIq);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblPort);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtHostname);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.lblPassword);
            this.groupBox1.Controls.Add(this.lblHostname);
            this.groupBox1.Controls.Add(this.txtXmppDomain);
            this.groupBox1.Controls.Add(this.lblXmpDomain);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(473, 94);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Credentials";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(229, 16);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 13);
            this.lblPort.TabIndex = 7;
            this.lblPort.Text = "Port:";
            // 
            // txtPort
            // 
            this.txtPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPort.Location = new System.Drawing.Point(264, 13);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(129, 20);
            this.txtPort.TabIndex = 6;
            this.txtPort.Text = "5275";
            // 
            // txtHostname
            // 
            this.txtHostname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHostname.Location = new System.Drawing.Point(91, 39);
            this.txtHostname.Name = "txtHostname";
            this.txtHostname.Size = new System.Drawing.Size(129, 20);
            this.txtHostname.TabIndex = 5;
            this.txtHostname.Text = "vm-2k";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(91, 68);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(129, 20);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.Text = "secret";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(6, 71);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password:";
            // 
            // lblHostname
            // 
            this.lblHostname.AutoSize = true;
            this.lblHostname.Location = new System.Drawing.Point(6, 46);
            this.lblHostname.Name = "lblHostname";
            this.lblHostname.Size = new System.Drawing.Size(58, 13);
            this.lblHostname.TabIndex = 2;
            this.lblHostname.Text = "Hostname:";
            // 
            // txtXmppDomain
            // 
            this.txtXmppDomain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXmppDomain.Location = new System.Drawing.Point(91, 13);
            this.txtXmppDomain.Name = "txtXmppDomain";
            this.txtXmppDomain.Size = new System.Drawing.Size(129, 20);
            this.txtXmppDomain.TabIndex = 1;
            this.txtXmppDomain.Text = "comp1.vm-2k";
            // 
            // lblXmpDomain
            // 
            this.lblXmpDomain.AutoSize = true;
            this.lblXmpDomain.Location = new System.Drawing.Point(6, 20);
            this.lblXmpDomain.Name = "lblXmpDomain";
            this.lblXmpDomain.Size = new System.Drawing.Size(79, 13);
            this.lblXmpDomain.TabIndex = 0;
            this.lblXmpDomain.Text = "XMPP Domain:";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 470);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdOpen);
            this.Name = "FrmMain";
            this.Text = "XMPP Component Example";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdOpen;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox listEvents;
        private Matrix.Xmpp.Component.XmppComponent xmppComponent1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtHostname;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblHostname;
        private System.Windows.Forms.TextBox txtXmppDomain;
        private System.Windows.Forms.Label lblXmpDomain;
        private System.Windows.Forms.RichTextBox rtfDebug;
    }
}

