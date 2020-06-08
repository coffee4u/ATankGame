using System;
using Common;

namespace GameServer.Controller
{
    abstract class BaseController
    {
        RequestCode requestCode = RequestCode.None;

        public virtual void DefaultHandle() { }
    }
}
