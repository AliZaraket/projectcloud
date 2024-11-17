using System;
using System.Net.Sockets;
using System.Text;

class Client
{
    static void Main(string[] args)
    {
        // Set the IP address and port for the server
        string ipAddress = "127.0.0.1";
        int port = 8888;

        // Create a TCP client
        TcpClient client = new TcpClient();

        // Connect to the server
        client.Connect(ipAddress, port);
        Console.WriteLine("Connected to server!");

        // Get the network stream for reading and writing
        NetworkStream stream = client.GetStream();

        // Send data to the server
        string message = "Hello from client!";
        byte[] data = Encoding.ASCII.GetBytes(message);
        stream.Write(data, 0, data.Length);

        // Buffer for incoming data
        byte[] buffer = new byte[1024];

        // Read the response from the server
        int bytesRead = stream.Read(buffer, 0, buffer.Length);
        string responseData = Encoding.ASCII.GetString(buffer, 0, bytesRead);
        Console.WriteLine("Server: " + responseData);

        // Close the connection
        client.Close();
    }
}
