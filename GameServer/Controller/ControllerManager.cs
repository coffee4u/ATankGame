using System;
using System.Collections.Generic;
using Common;
using System.Reflection;
using GameServer.Servers;
namespace GameServer.Controller
{
    public class ControllerManager
    {
        private Dictionary<RequestCode, BaseController> controllerDict
            = new Dictionary<RequestCode, BaseController>();
        private Server server;
        public ControllerManager(Server server)
        {
            this.server = server;
            InitController();

        }

        void InitController()
        {
            DefaultController defaultController = new DefaultController();
            controllerDict.Add(defaultController.RequestCode,defaultController);
        }

        public void HandleRequest(RequestCode requestCode, ActionCode actionCode,string data,Client client)
        {
            BaseController controller;
            bool isGet = controllerDict.TryGetValue(requestCode, out controller);
            if (isGet == false)
            {
                Console.WriteLine("HandleRequest isGet Error, requestCode = :" + requestCode);
                return;
            }
            string methodName = Enum.GetName(typeof(ActionCode),actionCode);
            MethodInfo mi = controller.GetType().GetMethod(methodName);
            if(mi == null)
            {
                Console.WriteLine("HandleRequest MethodInfo Error, methodName = :" + methodName);
            }
            object[] parameters = new object[] { data,client, server};
            object o = mi.Invoke(controller, parameters);
            if(o==null || string.IsNullOrEmpty(o as string))
            {
                return;
            }
            server.SendResponse(client, requestCode, o as string);
        }
    }
}
