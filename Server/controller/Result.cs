using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.controller
{
    /// <summary>
    /// An enum to clarify code.
    /// </summary>
    public enum Status { Open, Close, Keep };

    /// <summary>
    /// Result class.
    /// </summary>
    public class Result
    {
        private static Result error;

        public static Result Error
        {
            get
            {
                if (error == null)
                {
                    error = new Result(Status.Keep, "Command not found");
                }
                return error;
            }
        }

        /// <summary>
        /// Holds after result's status.
        /// </summary>
        public Status Status { get; }

        /// <summary>
        /// Holds result's response.
        /// </summary>
        public string Response { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="status"> a status after response. </param>
        /// <param name="response"> a string to response. </param>
        public Result(Status status, string response)
        {
            Status = status;
            Response = response;
        }
    }
}
