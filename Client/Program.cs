using Client.controller;
using Client.model;
using Client.view;
using System;
using System.Collections.Generic;
using System.Linq;
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
            ClientController controller = new ClientController(); 
            IServerHandler handler = new ServerHandler(controller);
            IClientModel model = new ClientModel(controller);
            Client client = new Client(12345, handler);

            controller.Model = model;
            controller.View = handler;
            controller.BuildCommands();
            client.Start();
           
        }
    }
}
