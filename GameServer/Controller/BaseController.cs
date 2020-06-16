using System;
using Common;
using GameServer.Servers;

namespace GameServer.Controller
{
    public abstract class BaseController
    {
        RequestCode requestCode = RequestCode.None;

        public RequestCode RequestCode
        {
            get
            {
                return requestCode;
            }
        }
        public virtual string DefaultHandle(string data,Client client, Server server) { return null; }
    }

}
