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
            /*
           Client client = new Client();

            while (true)
            {
                client.Communicate(12345);
            } 

          */ 
            Controller controller = new Controller(); 
            IHandler handler = new Handler(controller);
            IModel model = new ClientModel(controller);
            Client client = new Client(12345, handler);

            controller.Model = model;
            controller.View = handler;
            controller.BuildCommands();
            client.Start();
           
        }
    }
}
