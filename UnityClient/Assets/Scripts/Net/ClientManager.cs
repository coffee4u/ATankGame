using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System;

public class ClientManager : BaseManager
{
    private const string IP = "127.0.0.1";
    private const int PORT = 6688;

    private Socket clientSocket;
    public override void OnInit()
    {
        base.OnInit();

        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        try
        {
            clientSocket.Connect(IP, PORT);
        }catch(Exception e)
        {
            Debug.LogWarning("Can't connect server:" + e.ToString());
        }
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        try
        {
            if (clientSocket != null)
            {
                clientSocket.Close();
            }
        }catch(Exception e)
        {
            Debug.LogWarning("Can not close the connection");
        }
    }
}
