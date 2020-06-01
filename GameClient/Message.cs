using System;
using System.Linq;
using System.Text;

namespace GameClient
{
    public class Message
    {
        public Message()
        {
        }

        public static byte[] GetBytes(string data)
        {
            byte[] databytes = Encoding.UTF8.GetBytes(data);
            int length = databytes.Length;
            byte[] lengthBytes = BitConverter.GetBytes(length);
            byte[] newBytes = lengthBytes.Concat(databytes).ToArray();
            return newBytes;
        }
    }
}
