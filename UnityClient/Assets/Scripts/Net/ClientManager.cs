using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System;
using Common;
public class ClientManager : BaseManager
{
    private const string IP = "127.0.0.1";
    private const int PORT = 6688;

    private Socket clientSocket;
    private Message msg = new Message();

    public ClientManager(GameFacade facade) : base(facade) { }

    public override void OnInit()
    {
        base.OnInit();

        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Start();
        try
        {
            clientSocket.Connect(IP, PORT);
        }catch(Exception e)
        {
            Debug.LogWarning("Can't connect server:" + e.ToString());
        }
    }
    private void Start()
    {
        clientSocket.BeginReceive(msg.Data, msg.StartIndex,msg.RemainSize, SocketFlags.None, ReceiveCallback, null);
    }
    private void ReceiveCallback(IAsyncResult ar)
    {
        try
        {
            int count = clientSocket.EndReceive(ar);
            msg.ReadMessage(count, OnPrecessDataCallback);
            Start();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

    }

    private void OnPrecessDataCallback(RequestCode requestCode,string data)
    {
        facade.HandleResponse(requestCode, data);
    }
    public void SendRequest(RequestCode requestCode,ActionCode actionCode,string data)
    {
        byte[] bytes = Message.PackData(requestCode, actionCode, data);
        clientSocket.Send(bytes);
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
