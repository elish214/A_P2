using MazeLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.model
{
    public interface IMPMenuModel : IMCMenuModel
    {
        event PropertyChangedEventHandler PropertyChanged;

        ObservableCollection<string> GamesList { get; set; }

        int ChosenGame { get; set; }

        void Load();

        Boolean Start();

        Boolean Join();

        void Close();
    }
}
