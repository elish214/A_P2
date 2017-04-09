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
    public class ListCommand : ICommand
    {
        private IModel model;

        public ListCommand(IModel model)
        {
            this.model = model;
        }

        public Result Execute(string[] args, TcpClient client = null)
        {
            if (model.Games.Keys.Count == 0)
                return new Result(Status.Keep, "");
            return new Result(Status.Keep, model.Games.Keys.Aggregate((result, next) => $"{result},{next}"));
        }
    }
}
