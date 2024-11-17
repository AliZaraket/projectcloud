using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace RemoteDesktopServer
{
    internal class Server
    {
        private TcpListener listener;

        public Server()
        {
            listener = new TcpListener(IPAddress.Any, 12345);
        }

        public void Start()
        {
            listener.Start();
            Console.WriteLine("Server started. Waiting for connections...");

            while (true)
            {
                using (TcpClient client = listener.AcceptTcpClient())
                using (NetworkStream stream = client.GetStream())
                {
                    SendDesktop(stream);
                }
            }
        }

        private void SendDesktop(NetworkStream stream)
        {
            Bitmap screen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(screen);
            graphics.CopyFromScreen(0, 0, 0, 0, screen.Size);

            using (MemoryStream ms = new MemoryStream())
            {
                screen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] bytes = ms.ToArray();
                stream.Write(bytes, 0, bytes.Length);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Start();
        }
    }
}
