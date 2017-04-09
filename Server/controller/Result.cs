using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.controller
{
    public enum Status { Open, Close, Keep };

    public class Result
    {
        public Status Status { get; }
        public string Response { get; }

        public Result(Status status, string response)
        {
            Status = status;
            Response = response;
        }
    }
}
