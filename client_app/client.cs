using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace client_app
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        public Form1()
        {
            InitializeComponent();
            client = new TcpClient();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            try
            {
                client.Connect("192.168.0.109", 8888);
                Log("Connected to server...");
            }
            catch (Exception ex)
            {
                Log("Error connecting to server: " + ex.Message);
            }
        }

        private void Log(string message)
        {
          
            textBoxLog.AppendText(message + Environment.NewLine);
        }

        private void btn_restart_Click(object sender, EventArgs e)
        {
            SendCommand("Display off");

        }

        private void btn_shutdown_Click(object sender, EventArgs e)
        {
            SendCommand("Display on");
        }

        private void btn_sleep_Click(object sender, EventArgs e)
        {
            SendCommand("sleep");
        }
        private void SendCommand(string command)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] data = Encoding.ASCII.GetBytes(command);
                stream.Write(data, 0, data.Length);
                
                Log("Sent command: " + command);
            }
            catch (Exception ex)
            {
                Log("Error sending command: " + ex.Message);
            }
        }

        private void btn_edge_Click(object sender, EventArgs e)
        {
            SendCommand("Open_Edge");
        }

       
    }
}