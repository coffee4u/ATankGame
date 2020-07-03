using System;
using System.Text;
using System.Linq;
using Common;
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

        public void ReadMessage(int newDataAmount, Action<RequestCode, string> processDataCallback)
        {
            startIndex += newDataAmount;
            while (true)
            {
                if (startIndex <= COUNT_LEN) return;
                int count = BitConverter.ToInt32(data, 0);
                if (startIndex - COUNT_LEN >= count)
                {
                    RequestCode requestCode = (RequestCode)BitConverter.ToInt32(data, 4);

                    string s = Encoding.UTF8.GetString(data, COUNT_LEN + Request_code_len, count - Request_code_len);
                    Console.WriteLine("Recevied: " + s);
                    processDataCallback(requestCode, s);

                    Array.Copy(data, COUNT_LEN + count, data, 0, startIndex - count - COUNT_LEN);
                    startIndex = startIndex - count - COUNT_LEN;

                }
                else
                {
                    break;
                }
            }

        }

        public static byte[] PackData(RequestCode requestCode, string data)
        {
            byte[] requestCodeBytes = BitConverter.GetBytes((int)requestCode);
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            int dataAmount = requestCodeBytes.Length + dataBytes.Length;
            byte[] dataAmountBytes = BitConverter.GetBytes(dataAmount);
            return dataAmountBytes.Concat(requestCodeBytes).Concat(dataBytes).ToArray<Byte>();

        }

    public static byte[] PackData(RequestCode requestCode, ActionCode actionCode, string data)
    {
        byte[] requestCodeBytes = BitConverter.GetBytes((int)requestCode);
        byte[] actionCodeBytes = BitConverter.GetBytes((int)actionCode);
        byte[] dataBytes = Encoding.UTF8.GetBytes(data);
        int dataAmount = requestCodeBytes.Length + dataBytes.Length + actionCodeBytes.Length;
        byte[] dataAmountBytes = BitConverter.GetBytes(dataAmount);
        return dataAmountBytes.Concat(requestCodeBytes).Concat(actionCodeBytes).Concat(dataBytes).ToArray<Byte>();

    }
}

