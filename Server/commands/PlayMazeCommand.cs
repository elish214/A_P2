using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.commands
{
    class PlayMazeCommand : ICommand
    {
        private IModel model;

        public PlayMazeCommand(IModel model)
        {
            this.model = model;
        }

        public string Execute(string[] args, TcpClient client = null)
        {
            string direction = args[0];
            model.Play(name, client);
            return "move played";
        }
    }
