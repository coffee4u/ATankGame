using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using MySql.Data.MySqlClient;
using GameServer.Servers;

namespace GameServer
{
    class Program
    {
        //static byte[] dataBuffer = new byte[1024];

        static void Main(string[] args)
        {
            //TestMySql();
            //StartServerAsync();
            //Console.ReadKey();
            Server server = new Server("127.0.0.1", 6688);
        }

        //static void TestMySql()
        //{
        //    string connStr = "database=test007;datasource=127.0.0.1;port=3306;user=root;pwd=Cb080200;";
        //    MySqlConnection conn = new MySqlConnection(connStr);

        //    conn.Open();

        //    #region Update
        //    //MySqlCommand cmd = new MySqlCommand("update user set password = @pwd where id = 1", conn);
        //    //cmd.Parameters.AddWithValue("pwd", "sikiedu.com");
        //    //cmd.ExecuteNonQuery();
        //    #endregion

        //    #region Delete
        //    //MySqlCommand cmd = new MySqlCommand("delete from user where id = @id", conn);
        //    //cmd.Parameters.AddWithValue("id", 1);
        //    //cmd.ExecuteNonQuery();
        //    #endregion

        //    #region Insert
        //    //string username = "cwer";
        //    //string password = "lcker";
        //    //MySqlCommand cmd = new MySqlCommand("insert into user set username=@un,password=@pwd", conn);
        //    //cmd.Parameters.AddWithValue("un", username);
        //    //cmd.Parameters.AddWithValue("pwd", password);
        //    //cmd.ExecuteNonQuery();
        //    #endregion

        //    #region Search
        //    //MySqlCommand cmd = new MySqlCommand("select * from user", conn);

        //    //MySqlDataReader reader = cmd.ExecuteReader();
        //    //while (reader.HasRows && reader.Read())
        //    //{
        //    //    ;
        //    //    string username = reader.GetString("username");
        //    //    string password = reader.GetString("password");
        //    //    Console.WriteLine(username + ":" + password);
        //    //}

        //    //reader.Close();
        //    #endregion

        //    conn.Close();

        //}

        //static void StartServerAsync()
        //{
        //    Console.WriteLine("Server Init!");
        //    Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //    //IPAddress iPAddress = new IPAddress(new byte[] { 127,0,0,1 });
        //    IPAddress iPAddress = IPAddress.Parse("127.0.0.1");
        //    IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 10000);
        //    serverSocket.Bind(iPEndPoint);
        //    serverSocket.Listen(50);
        //    //Socket clientSocket = serverSocket.Accept();
        //    serverSocket.BeginAccept(AcceptCallBack, serverSocket);
        //    //Receive a message from client
        //    //byte[] dataBuffer = new byte[1024];
        //    //int count = clientSocket.Receive(dataBuffer);
        //    //string msgReceive = System.Text.Encoding.UTF8.GetString(dataBuffer, 0, count);
        //    //Console.WriteLine(msgReceive);

        //    //clientSocket.Close();
        //    //serverSocket.Close();
        //}
        //static Message msg = new Message();

        //static void AcceptCallBack(IAsyncResult ar)
        //{
        //    Socket serverSocket = ar.AsyncState as Socket;
        //    Socket clientSocket = serverSocket.EndAccept(ar);

        //    //Send a message to client
        //    string msgStr = "Hello Client!";
        //    byte[] data = Encoding.UTF8.GetBytes(msgStr);
        //    clientSocket.Send(data);
        //    clientSocket.BeginReceive(msg.Data, msg.StartIndex, msg.RemainSize, SocketFlags.None, RecevieCallBack, clientSocket);
        //    serverSocket.BeginAccept(AcceptCallBack, serverSocket);

        //}
        //static void RecevieCallBack(IAsyncResult ar)
        //{
        //    Socket clientSocket = ar.AsyncState as Socket;
        //    try
        //    {
        //        int count = clientSocket.EndReceive(ar);
        //        Console.WriteLine("recevied count:" + count);
        //        if(count == 0)
        //        {
        //            // client closed
        //            clientSocket.Close();
        //            return;
        //        }
        //        msg.AddCount(count);
        //        msg.ReadMessage();
        //        //string msgStr = Encoding.UTF8.GetString(dataBuffer, 0, count);
        //        //Console.WriteLine("recevied:" + msgStr);
        //        clientSocket.BeginReceive(msg.Data, msg.StartIndex, msg.RemainSize, SocketFlags.None, RecevieCallBack, clientSocket);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //        if (clientSocket != null)
        //        {
        //            clientSocket.Close();
                    
        //        }
        //    }
        //}


        //static void StartServerSync()
        //{
        //    Console.WriteLine("Server Init!");
        //    Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //    //IPAddress iPAddress = new IPAddress(new byte[] { 127,0,0,1 });
        //    IPAddress iPAddress = IPAddress.Parse("127.0.0.1");
        //    IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 10000);
        //    serverSocket.Bind(iPEndPoint);
        //    serverSocket.Listen(50);
        //    Socket clientSocket = serverSocket.Accept();

        //    //Send a message to client
        //    string msg = "Hello Client!";
        //    byte[] data = System.Text.Encoding.UTF8.GetBytes(msg);
        //    clientSocket.Send(data);

        //    //Receive a message from client
        //    byte[] dataBuffer = new byte[1024];
        //    int count = clientSocket.Receive(dataBuffer);
        //    string msgReceive = System.Text.Encoding.UTF8.GetString(dataBuffer, 0, count);
        //    Console.WriteLine(msgReceive);

        //    clientSocket.Close();
        //    serverSocket.Close();
        //}
    }
}
