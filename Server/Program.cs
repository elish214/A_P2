﻿using Server.controller;
using Server.model;
using Server.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            IModel model = new MazeModel(controller);
            IClientHandler handler = new ClientHandler(controller);
            view.Server server = new view.Server(12345, handler);

            controller.Model = model;
            controller.View = handler;
            controller.BuildCommands();
            server.Start();

            Console.ReadKey(); // prevent closing
        }
    }
}
