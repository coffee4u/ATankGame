﻿using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
namespace GameClient
{
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client Init!");
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 10000));

            byte[] data = new byte[1024];
            int count = clientSocket.Receive(data);
            string msg = Encoding.UTF8.GetString(data, 0, count);
            Console.WriteLine(msg);

            while (true)
            {
                string s = Console.ReadLine();
                if(s == "c")
                {
                    clientSocket.Close();
                    return;
                }
                clientSocket.Send(Encoding.UTF8.GetBytes(s));
            }

            Console.ReadKey();
            clientSocket.Close();
        }
    }
}
