using Client.controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client.model
{
    /// <summary>
    /// Client model class.
    /// </summary>
    public class ClientModel : IClientModel
    {
        /// <summary>
        /// Holds the controller it's assosiated with.
        /// </summary>
        public IClientController Controller { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="controller"> the controller it's assosiated with. </param>
        public ClientModel(IClientController controller)
        {
            Controller = controller;
        }
       
        /// <summary>
        /// Initialize and run task through controller.
        /// </summary>
        public void RunTask()
        {
            Controller.RunTask();
        }

    }
}
