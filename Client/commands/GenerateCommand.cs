using Client.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.commands
{
    public class GenerateCommand : ICommand
    {
        private IModel model;

        public GenerateCommand(IModel model)
        {
            this.model = model;
        }

        public string Execute(string command, ref bool running)
        {
            running = false;
            return command; 
        }
    }
}
