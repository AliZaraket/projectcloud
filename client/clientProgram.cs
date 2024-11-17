using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

namespace RemoteDesktopClient
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private NetworkStream stream;

        public Form1()
        {
            InitializeComponent();
            ConnectToServer();
        }

        private void ConnectToServer()
        {
            try
            {
                client = new TcpClient("127.0.0.1", 12345); // Connect to server (change IP if needed)
                stream = client.GetStream();

                // Start receiving desktop image
                ReceiveDesktop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                Close();
            }
        }

        private void ReceiveDesktop()
        {
            try
            {
                while (true)
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        byte[] buffer = new byte[client.ReceiveBufferSize];
                        int bytesRead;
                        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            memoryStream.Write(buffer, 0, bytesRead);
                        }

                        Bitmap desktopImage = new Bitmap(memoryStream);
                        pictureBox.Image = desktopImage;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                Close();
            }
        }
    }
}
