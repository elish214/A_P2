using Client.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.model
{
    public interface IModel
    { 
        Controller Controller { get; }

        Task Task { get; }
    }
}
