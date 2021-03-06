﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using Server.model;
using Server.controller;
using MazeGeneratorLib;
using System.Threading;

namespace Server.commands
{
    /// <summary>
    /// Start maze command class.
    /// </summary>
    public class StartMazeCommand : IServerCommand
    {
        /// <summary>
        /// Holds the model it's assosiated with.
        /// </summary>
        private IServerModel model;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="model"> the model it's assosiated with. </param>
        public StartMazeCommand(IServerModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Excute command. called by controller. starts a maze.
        /// </summary>
        /// <param name="args"> arguments from console. </param>
        /// <param name="client"> a client to handle. </param>
        /// <returns> a result to send back to client. </returns>
        public Result Execute(string[] args, TcpClient client = null)
        {
            try
            {
                if(args.Count() > 3)
                {
                    throw new FormatException();
                }

                string name = args[0];
                int rows = int.Parse(args[1]);
                int cols = int.Parse(args[2]);

                model.Start(name, rows, cols, client);

                return new Result(Status.Open, "");
            }
            catch (Exception e)
            {
                return Result.ConnectionError;
            }
        }
    }
}
