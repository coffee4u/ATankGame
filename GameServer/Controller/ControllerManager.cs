using System;
using System.Collections.Generic;
using Common;
namespace GameServer.Controller
{
    public class ControllerManager
    {
        private Dictionary<RequestCode, BaseController> contollerDict
            = new Dictionary<RequestCode, BaseController>();

        public ControllerManager()
        {
            Init();

        }

        void Init()
        {

        }
    }
}
