using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace RemoteDesktopServer
{
    public partial class ServerForm : Form
    {
        // Set the IP address and port
        private IPAddress ipAddress = IPAddress.Parse("192.168.0.121"); // Use your desktop's IP address
        private int port = 8888;
        private TcpListener listener;

        public ServerForm()
        {
            InitializeComponent();
            listener = new TcpListener(ipAddress, port);
            listener.Start();
            Log("Server started...");
            AcceptClient();
        }

        private void AcceptClient()
        {
            listener.BeginAcceptTcpClient(HandleClient, null);
        }

        private void HandleClient(IAsyncResult ar)
        {
            TcpClient client = listener.EndAcceptTcpClient(ar);
            Log("Client connected...");
            NetworkStream stream = client.GetStream();

            byte[] data = new byte[256];
            int bytes = stream.Read(data, 0, data.Length);
            string receivedCommand = Encoding.Unicode.GetString(data, 0, bytes);
            Log("Received command: " + receivedCommand);

            PerformCommand(receivedCommand);

            stream.Close();
            client.Close();

            AcceptClient(); // Accept next client
        }

        private void PerformCommand(string command)
        {
            // Perform action based on the command
            switch (command.ToLower())
            {
                case "move mouse left":
                    // Code to move mouse left
                    Cursor.Position = new System.Drawing.Point(Cursor.Position.X - 100, Cursor.Position.Y);
                    Log("Moving mouse left...");
                    break;
                // Add cases for other commands as needed
                default:
                    // Handle unrecognized command
                    Log("Unrecognized command: " + command);
                    break;
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

        private TextBox textBoxLog;

        private void InitializeComponent()
        {
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxLog
            // 
            this.textBoxLog.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBoxLog.Location = new System.Drawing.Point(136, 92);
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(317, 27);
            this.textBoxLog.TabIndex = 0;
            // 
            // ServerForm
            // 
            this.ClientSize = new System.Drawing.Size(635, 253);
            this.Controls.Add(this.textBoxLog);
            this.Name = "ServerForm";
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ServerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
