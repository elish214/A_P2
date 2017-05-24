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
    /// <summary>
    /// single player menu view model class.
    /// </summary>
    public class SPMenuViewModel : MCMenuViewModel
    {
        /// <summary>
        /// private model member.
        /// </summary>
        private ISPMenuModel model;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="model"> a model. </param>
        public SPMenuViewModel(ISPMenuModel model) : base(model)
        {
            this.model = model;
        }

        /// <summary>
        /// generating a maze.
        /// </summary>
        public void Generate()
        {
            Maze maze = model.Generate();

            new SinglePlayerWindow(maze).Show();
        }
    }
}
