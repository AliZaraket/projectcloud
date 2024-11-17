using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

class RemoteDesktopServer
{
    private static readonly int PORT = 12345;

    static void Main(string[] args)
    {
        TcpListener listener = new TcpListener(IPAddress.Any, PORT);
        listener.Start();
        Console.WriteLine($"Server listening on port {PORT}");

        while (true)
        {
            using (TcpClient client = listener.AcceptTcpClient())
            using (NetworkStream stream = client.GetStream())
            {
                Console.WriteLine($"Client connected from {((IPEndPoint)client.Client.RemoteEndPoint).Address}");

                Thread thread = new Thread(() =>
                {
                    try
                    {
                        while (true)
                        {
                            SendScreenshot(stream);
                            Thread.Sleep(100); // Adjust capture frequency
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                });
                thread.Start();
            }
        }
    }

    static void SendScreenshot(NetworkStream stream)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (MemoryStream ms = new MemoryStream())
        {
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size);
            formatter.Serialize(ms, bitmap);
            ms.Position = 0;
            ms.CopyTo(stream);
        }
    }
}
