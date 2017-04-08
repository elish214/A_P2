﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using Server.model;

namespace Server.commands
{
    public class StartMazeCommand : ICommand
    {
        private IModel model;

        public StartMazeCommand(IModel model)
        {
            this.model = model;
        }

        public string Execute(string[] args, TcpClient client = null)
        {
            string name = args[0];
            int rows = int.Parse(args[1]);
            int cols = int.Parse(args[2]);
            model.StartMaze(name, rows, cols, client);
            return model.StartMaze(name, rows, cols, client).ToJSON(); //PROBLEM
        }
    }
}
