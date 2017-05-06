using Client.controller;
using Client.model;
using Client.view;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ClientMain
    {
        private Client client;

        public ClientMain()
        {
            //int port = int.Parse(ConfigurationManager.AppSettings["port"]);
            //IPAddress IP = IPAddress.Parse(ConfigurationManager.AppSettings["IP"].ToString());

            int port = 12345;
            IPAddress IP = IPAddress.Parse("127.0.0.1");

            ClientController controller = new ClientController();
            IServerHandler handler = new ServerHandler(controller);
            IClientModel model = new ClientModel(controller);
            client = new Client(IP, port, handler);

            controller.Model = model;
            controller.View = handler;
            controller.BuildCommands();
            //client.Start();
        }

        public string Send(string message)
        {
            return client.Send(message);
        }
    }
}
