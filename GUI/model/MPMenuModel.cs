using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.model
{
    public class MPMenuModel : MCMenuModel, IMPMenuModel
    {
        public int ChosenGame { get; set; }
    }
}
