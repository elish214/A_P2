using Client.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.commands
{
    public class JoinGameCommand : ICommand
    {
        private IModel model;

        public JoinGameCommand(IModel model)
        {
            this.model = model;
        }

        public string Execute(string command, ref bool running)
        {
            running = true;
            return command;
        }
    }
}
