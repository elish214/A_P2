﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.commands
{
    class ListCommand : ICommand
    {
        private IModel model;

        public ListCommand(IModel model)
        {
            this.model = model;
        }

        public string Execute(string[] args, TcpClient client = null)
        {
            //List = model.GameList;
            return maze.ToJSON();
        }
    }
}