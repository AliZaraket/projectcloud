using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Client
{
    static void Main()
    {
        // Set the IP address and port of the server (desktop)
        IPAddress ipAddress = IPAddress.Parse("192.168.0.121"); // Use the desktop's IP address
        int port = 8888;

        // Connect to the server
        TcpClient client = new TcpClient();
        client.Connect(ipAddress, port);
        Console.WriteLine("Connected to server...");

        // Get the network stream
        NetworkStream stream = client.GetStream();

        // Send commands to the server
        string command;
        do
        {
            Console.Write("Enter command (or 'exit' to quit): ");
            command = Console.ReadLine();

            // Convert the command to bytes and send it to the server
            byte[] data = Encoding.Unicode.GetBytes(command);
            stream.Write(data, 0, data.Length);
            Console.WriteLine("Sent command: " + command);

        } while (command.ToLower() != "exit");

        // Close the connection
        client.Close();
    }
}
    

