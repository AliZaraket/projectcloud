using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Server
{
    static void Main(string[] args)
    {
        // Set the IP address and port for the server
        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        int port = 8888;

        // Create a TCP listener
        TcpListener listener = new TcpListener(ipAddress, port);

        // Start listening for client requests
        listener.Start();
        Console.WriteLine("Server started, waiting for connections...");

        // Accept the client connection
        TcpClient client = listener.AcceptTcpClient();
        Console.WriteLine("Client connected!");

        // Get the network stream for reading and writing
        NetworkStream stream = client.GetStream();

        // Buffer for incoming data
        byte[] buffer = new byte[1024];
        int bytesRead;

        // Read incoming data from the client
        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
        {
            // Convert the bytes received into a string
            string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Client: " + dataReceived);

            // Send a response back to the client
            string response = "Server received: " + dataReceived;
            byte[] responseData = Encoding.ASCII.GetBytes(response);
            stream.Write(responseData, 0, responseData.Length);
        }

        // Close the connection
        client.Close();
        listener.Stop();
    }
}
