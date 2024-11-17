using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

class RemoteDesktopClient : Form
{
    private const string SERVER_IP = "127.0.0.1";
    private const int PORT = 12345;

    private PictureBox pictureBox;

    public RemoteDesktopClient()
    {
        InitializeComponents();
        ConnectToServer();
    }

    private void InitializeComponents()
    {
        pictureBox = new PictureBox
        {
            Dock = DockStyle.Fill,
            SizeMode = PictureBoxSizeMode.StretchImage
        };

        Controls.Add(pictureBox);
    }

    private void ConnectToServer()
    {
        try
        {
            TcpClient client = new TcpClient(SERVER_IP, PORT);
            NetworkStream stream = client.GetStream();

            while (true)
            {
                ReceiveScreenshot(stream);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}");
            Environment.Exit(0);
        }
    }

    private void ReceiveScreenshot(NetworkStream stream)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        Image screenshot = (Image)formatter.Deserialize(stream);
        pictureBox.Image = screenshot;
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new RemoteDesktopClient());
    }
}
