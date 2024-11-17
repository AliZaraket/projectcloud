using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

class Server
{
    // Import the necessary Windows API functions
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);

    [DllImport("user32.dll")]
    static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, int dwExtraInfo);

    [DllImport("user32.dll")]
    public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

    const int MOUSEEVENTF_LEFTDOWN = 0x02;
    const int MOUSEEVENTF_LEFTUP = 0x04;
    const int VK_CONTROL = 0x11;
    const int VK_SHIFT = 0x10;
    const int VK_ESC = 0x1B;

    static void Main()
    {
        // Set the IP address and port
        IPAddress ipAddress = IPAddress.Parse("127.0.0.1"); // Use your desktop's IP address
        int port = 8888;

        // Create TCP listener
        TcpListener listener = new TcpListener(ipAddress, port);
        listener.Start();
        Console.WriteLine("Server started...");

        while (true)
        {
            // Accept incoming connection
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Client connected...");

            // Get the client's network stream
            NetworkStream stream = client.GetStream();

            byte[] data = new byte[256];
            int bytes;

            // Read data from the client
            StringBuilder builder = new StringBuilder();
            while ((bytes = stream.Read(data, 0, data.Length)) != 0)
            {
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            string receivedCommand = builder.ToString();
            Console.WriteLine("Received command: " + receivedCommand);

            // Perform action based on received command
            PerformCommand(receivedCommand);

            // Close the connection
            client.Close();
        }
    }

    static void PerformCommand(string command)
    {
        // Perform action based on the command
        switch (command.ToLower())
        {
            case "move mouse left":
                // Code to move mouse left
                MoveMouseLeft();
                Console.WriteLine("Moving mouse left...");
                break;
            case "click on icon":
                // Code to click on icon
                ClickOnIcon();
                Console.WriteLine("Clicking on icon...");
                break;
            case "open application":
                // Code to open application
                OpenApplication();
                Console.WriteLine("Opening application...");
                break;
            default:
                // Handle unrecognized command
                Console.WriteLine("Unrecognized command: " + command);
                break;
        }
    }

    static void MoveMouseLeft()
    {
        // Move the mouse left by 100 pixels
        SetCursorPos(Cursor.Position.X - 100, Cursor.Position.Y);
    }

    static void ClickOnIcon()
    {
        // Find the window handle of the desktop
        IntPtr desktopHandle = FindWindow("Progman", "Program Manager");

        // Bring the desktop window to the foreground
        SetForegroundWindow(desktopHandle);

        // Simulate a left mouse button click
        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
    }

    static void OpenApplication()
    {
        // Replace "notepad.exe" with the path to the application you want to open
        Process.Start("notepad.exe");
    }
}

