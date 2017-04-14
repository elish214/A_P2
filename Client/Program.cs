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
    public class Program
    {
        static void Main(string[] args)
        {
        /*    Client client = new Client();

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
