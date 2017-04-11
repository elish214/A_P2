using Server.controller;
using Server.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.commands
{
    public class CloseMazeCommand : ICommand
    {
        private IModel model;

        public CloseMazeCommand(IModel model)
        {
            this.model = model;
        }

        public Result Execute(string[] args, TcpClient client = null)
        {
            string name = args[0];
            MazeGame game = model.Games[name];

            //notify other player about pos change
            foreach (TcpClient c in game.Players.Keys)
            {
                Console.WriteLine("trying send close...");
                if (c != client)
                {
                    model.Controller.Send(" ", c);
                    Console.WriteLine("sent close");
                }
            }

            return new Result(Status.Close, " ");
        }
    }
}
