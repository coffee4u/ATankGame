using System;
using System.Text;
namespace GameServer
{
    public class Message
    {
        public Message()
        {
        }
        const int LEN = 1024;
        const int COUNT_LEN = 4;
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

        public void ReadMessage()
        {
            while (true)
            {
                if (startIndex <= COUNT_LEN) return;
                int count = BitConverter.ToInt32(data, 0);
                if (startIndex - COUNT_LEN >= count)
                {
                    string s = Encoding.UTF8.GetString(data, COUNT_LEN, count);
                    Console.WriteLine("Recevied: " + s);
                    Array.Copy(data, COUNT_LEN + count, data, 0, startIndex - count - COUNT_LEN);
                    startIndex = startIndex - count - COUNT_LEN;

                }
                else
                {
                    return;
                }
            }

        }
    }
}
