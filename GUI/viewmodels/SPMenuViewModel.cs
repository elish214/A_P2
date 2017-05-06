using GUI.model;
using GUI.windows;
using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.viewmodels
{
    public class SPMenuViewModel : MCMenuViewModel
    {
        private ISPMenuModel model;

        public SPMenuViewModel(ISPMenuModel model) : base(model)
        {
            this.model = model;
        }

        public void Generate()
        {
            Maze maze = model.Generate();

            new SinglePlayerWindow(maze).Show();
        }
    }
}
