using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace server_app
{
    public partial class Server : Form
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        private const int SC_MONITORPOWER = 0xF170;
        private const int MONITOR_OFF = 2;
        private const int MONITOR_ON = -1;
        private TcpListener serverSocket;
        private Thread listenerThread;
        public Server()
        {
            InitializeComponent();
        }
        private void StartServer()
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse("192.168.0.109");
                int port = 8888;
                serverSocket = new TcpListener(ipAddress, port);
                serverSocket.Start();
                Log("Server started...");
                while (true)
                {
                    TcpClient clientSocket = serverSocket.AcceptTcpClient();
                    Log("Client connected...");
                    Thread clientThread = new Thread(() => HandleClient(clientSocket));
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Log("Error starting server: " + ex.Message);
            }
        }
        private void HandleClient(TcpClient clientSocket)
        {
            try
            {
                NetworkStream stream = clientSocket.GetStream();
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string command = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Log("Received command: " + command);

                // Execute command (simplified example)
                if (command == "restart")
                {
                    // Add logic here to move the mouse
                    
                    Log("Restarting...");
                    Process.Start("shutdown", "/r /t 0");
                }
                else if (command == "open application")
                {
                    // Add logic here to open an application
                    Log("Opening application...");
                }
                else if (command=="Display off")
                {
                    SendMessage(IntPtr.Zero, SC_MONITORPOWER, (IntPtr)MONITOR_OFF, IntPtr.Zero);
                }
                else if (command=="Display on")
                {
                    SendMessage(IntPtr.Zero, SC_MONITORPOWER, (IntPtr)MONITOR_ON, IntPtr.Zero);
                }
                // Add more commands and corresponding actions as needed

                clientSocket.Close();
            }
            catch (Exception ex)
            {
                Log("Error handling client: " + ex.Message);
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

        private void Server_Load(object sender, EventArgs e)
        {
            listenerThread = new Thread(StartServer);
            listenerThread.Start();
        }
        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            serverSocket.Stop();
            if (listenerThread != null && listenerThread.IsAlive)
            {
                listenerThread.Abort();
            }
        }
    }
}