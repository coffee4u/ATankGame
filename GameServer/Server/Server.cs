using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GameServer.Controller;
namespace GameServer.Server
{
    public class Server
    {
        private IPEndPoint iPEndPoint;
        private Socket serverSocket;
        private List<Client> clientList = new List<Client>();
        private ControllerManager controllerManager = new ControllerManager();

        public Server()
        {

        }

        public Server(string ipStr, int port)
        {
            SetIPAndPort(ipStr, port);
        }

        public void SetIPAndPort(string ipStr, int port)
        {
            iPEndPoint = new IPEndPoint(IPAddress.Parse(ipStr), port);
        }

        public void Start()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(iPEndPoint);
            serverSocket.Listen(0);
            serverSocket.BeginAccept(AcceptCallBack, null);
        }

        private void AcceptCallBack(IAsyncResult ar)
        {
            Socket clientSocket = serverSocket.EndAccept(ar);
            Client client = new Client(clientSocket, this);
            client.Start();
            clientList.Add(client);
        }

        public void RemoveClient(Client client)
        {
            lock (clientList)
            {
                clientList.Remove(client);

            }
        }
    }
}