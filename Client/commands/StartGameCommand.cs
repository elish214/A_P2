using Client.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.commands
{
    public class StartGameCommand : ICommand
    {
        private IModel model;

        public StartGameCommand(IModel model)
        {
            this.model = model;
        }

        public string Execute(string command, ref bool running)
        {
            running = true;
            Console.WriteLine("waiting for another player...");
            model.Task.Start();
            return command;
        }
    }
}
