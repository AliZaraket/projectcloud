// ClientForm.cs
using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace RemoteDesktopClient
{
    public partial class ClientForm : Form
    {
        private TcpClient client;

        public ClientForm()
        {
            InitializeComponent();
            client = new TcpClient();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                client.Connect("192.168.0.121", 8888);
                Log("Connected to server...");
            }
            catch (Exception ex)
            {
                Log("Error connecting to server: " + ex.Message);
            }
        }

        private void buttonMoveLeft_Click(object sender, EventArgs e)
        {
            SendCommand("move mouse left");
        }

        private void buttonClickIcon_Click(object sender, EventArgs e)
        {
            SendCommand("click on icon");
        }

        private void buttonOpenApp_Click(object sender, EventArgs e)
        {
            SendCommand("open application");
        }

        private void SendCommand(string command)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] data = Encoding.Unicode.GetBytes(command);
                stream.Write(data, 0, data.Length);
                Log("Sent command: " + command);
            }
            catch (Exception ex)
            {
                Log("Error sending command: " + ex.Message);
            }
        }

        private void Log(string message)
        {
            if (textBoxLog.InvokeRequired)
            {
                textBoxLog.Invoke((MethodInvoker)(() => Log(message)));
            }
            else
            {
                textBoxLog.AppendText(message + Environment.NewLine);
            }
        }

        private Button button1;
        private Button button2;
        private Button button3;
        private TextBox textBoxLog;

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(80, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "Move Mouse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonMoveLeft_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(304, 96);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 29);
            this.button2.TabIndex = 1;
            this.button2.Text = "OpenApp";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonOpenApp_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(578, 96);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(127, 29);
            this.button3.TabIndex = 2;
            this.button3.Text = "ClickIcon";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.buttonClickIcon_Click);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(166, 235);
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(380, 27);
            this.textBoxLog.TabIndex = 3;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(339, 172);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 29);
            this.button4.TabIndex = 4;
            this.button4.Text = "connect";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // ClientForm
            // 
            this.ClientSize = new System.Drawing.Size(762, 395);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "ClientForm";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void ClientForm_Load(object sender, EventArgs e)
        {

        }

        private Button button4;

        
    }
}

