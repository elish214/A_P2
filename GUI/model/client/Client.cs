using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI.model.client
{
    /// <summary>
    /// player communicate class.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// singleton.
        /// </summary>
        public static Client Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Client();
                }
                return instance;
            }
        }

        /// <summary>
        /// private instance.
        /// </summary>
        private static Client instance;

        /// <summary>
        /// Communicate End Point.
        /// </summary>
        public IPEndPoint EndPoint { get; set; }

        /// <summary>
        /// An action.
        /// </summary>
        public Action Act { get; set; }

        /// <summary>
        /// The client.
        /// </summary>
        private TcpClient tcpClient;

        /// <summary>
        /// A network stream.
        /// </summary>
        private NetworkStream stream;

        /// <summary>
        /// A stream reader.
        /// </summary>
        private StreamReader reader;

        /// <summary>
        /// A stream writer.
        /// </summary>
        private StreamWriter writer;

        /// <summary>
        /// A running boolean.
        /// </summary>
        private bool running;

        /// <summary>
        /// A delegate for an action.
        /// </summary>
        /// <param name="result"> a string. </param>
        public delegate void Action(string result);
    
        /// <summary>
        /// Constructor.
        /// </summary>
        private Client() { }

        /// <summary>
        /// A once connection function.
        /// </summary>
        /// <param name="msg"> a message to send.</param>
        /// <returns> returns a message. </returns>
        public string WriteRead(string msg)
        {
            Connect();
            Write(msg);
            string result = Read();
            Disconnect();

            return result;
        }

        /// <summary>
        /// Connect client to server.
        /// </summary>
        public void Connect()
        {
            tcpClient = new TcpClient();
            tcpClient.Connect(EndPoint);
            stream = tcpClient.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream)
            {
                AutoFlush = true
            };
        }

        /// <summary>
        /// Disconnect client from server.
        /// </summary>
        public void Disconnect()
        {
            running = false;
            reader.Close();
            writer.Close();
            stream.Close();
            tcpClient.Close();
        }

        /// <summary>
        /// write to server.
        /// </summary>
        /// <param name="msg"></param>
        public void Write(string msg)
        {
            try
            {
                writer.WriteLine(msg);
            }
            catch (Exception e) { }
        }

        public string Read()
        {
            string result = "";

            do
            {
                result += reader.ReadLine();
                result += '\n';
                //Console.WriteLine(result);
            } while (reader.Peek() >= 0);
            //MessageBox.Show(result);
            return result;
        }

        public void ASyncRead()
        {
            running = true;
            new Task(() =>
            {
                string result;

                try
                {
                    do
                    {
                        result = Instance.Read();
                        //MessageBox.Show(result);
                        Act(result);
                    } while (running);
                }
                catch (Exception e)
                {
                    Disconnect();
                }
            }).Start();
        }
    }
}
