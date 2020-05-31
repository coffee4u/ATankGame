using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace GameServer
{
    class Server
    {
        static byte[] dataBuffer = new byte[1024];

        static void Main(string[] args)
        {
            StartServerAsync();
            Console.ReadKey();
        }

        static void StartServerAsync()
        {
            Console.WriteLine("Server Init!");
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //IPAddress iPAddress = new IPAddress(new byte[] { 127,0,0,1 });
            IPAddress iPAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 10000);
            serverSocket.Bind(iPEndPoint);
            serverSocket.Listen(50);
            //Socket clientSocket = serverSocket.Accept();
            serverSocket.BeginAccept(AcceptCallBack, serverSocket);
            //Receive a message from client
            //byte[] dataBuffer = new byte[1024];
            //int count = clientSocket.Receive(dataBuffer);
            //string msgReceive = System.Text.Encoding.UTF8.GetString(dataBuffer, 0, count);
            //Console.WriteLine(msgReceive);

            //clientSocket.Close();
            //serverSocket.Close();
        }

        static void AcceptCallBack(IAsyncResult ar)
        {
            Socket serverSocket = ar.AsyncState as Socket;
            Socket clientSocket = serverSocket.EndAccept(ar);


            //Send a message to client
            string msg = "Hello Client!";
            byte[] data = Encoding.UTF8.GetBytes(msg);
            clientSocket.Send(data);
            clientSocket.BeginReceive(dataBuffer, 0, 1024, SocketFlags.None, RecevieCallBack, clientSocket);
            serverSocket.BeginAccept(AcceptCallBack, serverSocket);

        }

        static void RecevieCallBack(IAsyncResult ar)
        {
            Socket clientSocket = ar.AsyncState as Socket;
            try
            {
                int count = clientSocket.EndReceive(ar);
                Console.WriteLine("recevied count:" + count);
                if(count == 0)
                {
                    // client closed
                    clientSocket.Close();
                    return;
                }
                string msg = Encoding.UTF8.GetString(dataBuffer, 0, count);
                Console.WriteLine("recevied:" + msg);
                clientSocket.BeginReceive(dataBuffer, 0, 1024, SocketFlags.None, RecevieCallBack, clientSocket);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                if (clientSocket != null)
                {
                    clientSocket.Close();
                    
                }
            }
        }


        static void StartServerSync()
        {
            Console.WriteLine("Server Init!");
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //IPAddress iPAddress = new IPAddress(new byte[] { 127,0,0,1 });
            IPAddress iPAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 10000);
            serverSocket.Bind(iPEndPoint);
            serverSocket.Listen(50);
            Socket clientSocket = serverSocket.Accept();

            //Send a message to client
            string msg = "Hello Client!";
            byte[] data = System.Text.Encoding.UTF8.GetBytes(msg);
            clientSocket.Send(data);

            //Receive a message from client
            byte[] dataBuffer = new byte[1024];
            int count = clientSocket.Receive(dataBuffer);
            string msgReceive = System.Text.Encoding.UTF8.GetString(dataBuffer, 0, count);
            Console.WriteLine(msgReceive);

            clientSocket.Close();
            serverSocket.Close();
        }
    }
}
