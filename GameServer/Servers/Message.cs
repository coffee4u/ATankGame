﻿using System;
using System.Text;
using Common;
using System.Linq;
namespace GameServer.Servers
{
    public class Message
    {
        public Message()
        {
        }
        const int LEN = 1024;
        const int COUNT_LEN = 4;
        const int Request_code_len = 4;
        const int Action_code_len = 4;
        private byte[] data = new byte[LEN];
        private int startIndex = 0;

        public byte[] Data
        {
            get { return data; }
        }

        public int StartIndex
        { get { return startIndex; } }

        public int RemainSize
        {
            get { return LEN - startIndex; }
        }

        public void AddCount(int count)
        {
            startIndex += count;
        }

        public void ReadMessage(int newDataAmount, Action<RequestCode,ActionCode,string> processDataCallback)
        {
            startIndex += newDataAmount;
            while (true)
            {
                if (startIndex <= COUNT_LEN) return;
                int count = BitConverter.ToInt32(data, 0);
                if (startIndex - COUNT_LEN >= count)
                {
                    RequestCode requestCode = (RequestCode)BitConverter.ToInt32(data, 4);
                    ActionCode actionCode = (ActionCode)BitConverter.ToInt32(data, 8);

                    string s = Encoding.UTF8.GetString(data, COUNT_LEN + Request_code_len + Action_code_len, count - Request_code_len - Action_code_len);
                    Console.WriteLine("Recevied: " + s);
                    processDataCallback(requestCode, actionCode, s);

                    Array.Copy(data, COUNT_LEN + count, data, 0, startIndex - count - COUNT_LEN);
                    startIndex = startIndex - count - COUNT_LEN;

                }
                else
                {
                    break;
                }
            }

        }

        public static byte[] PackData(RequestCode requestCode,string data)
        {
            byte[] requestCodeBytes = BitConverter.GetBytes((int)requestCode);
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            int dataAmount = requestCodeBytes.Length + dataBytes.Length;
            byte[] dataAmountBytes = BitConverter.GetBytes(dataAmount);
            return dataAmountBytes.Concat(requestCodeBytes).Concat(dataBytes).ToArray<Byte>();
            
        }
    }
}
