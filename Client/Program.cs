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
    /// <summary>
    /// This is the entry point to the client-side.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Client's main method.
        /// </summary>
        /// <param name="args"> arguments from user. </param>
        static void Main(string[] args)
        {
            int port = int.Parse(ConfigurationManager.AppSettings["port"]);
            IPAddress IP = IPAddress.Parse(ConfigurationManager.AppSettings["IP"].ToString());

            ClientController controller = new ClientController(); 
            IServerHandler handler = new ServerHandler(controller);
            IClientModel model = new ClientModel(controller);
            Client client = new Client(IP, port, handler);

            controller.Model = model;
            controller.View = handler;
            controller.BuildCommands();
            client.Start();
           
        }
    }
}
