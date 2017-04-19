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
        /// <summary>
        /// Holds syntax error singleton.
        /// </summary>
        private static Result syntaxError;

        /// <summary>
        /// syntax error singleton propery.
        /// </summary>
        public static Result SyntaxError
        {
            get
            {
                if (syntaxError == null)
                {
                    syntaxError = new Result(Status.Keep, "Command not found");
                }
                return syntaxError;
            }
        }

        /// <summary>
        /// Holds connection error.
        /// </summary>
        private static Result connectionError;

        /// <summary>
        /// Connection error singleton propery.
        /// </summary>
        public static Result ConnectionError
        {
            get
            {
                if (connectionError == null)
                {
                    connectionError = new Result(Status.Close, "Connection failed");
                }
                return connectionError;
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
