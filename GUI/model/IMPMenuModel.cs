﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.model
{
    public interface IMPMenuModel : IMCMenuModel
    {
        int ChosenGame { get; set; }
    }
}