using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GUI.model.client
{
    public class Client
    {
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
        private static Client instance;

        public IPEndPoint EndPoint { get; set; }

        private TcpClient tcpClient;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;

        public delegate void Action(string result);

        private Client() { }

        public string WriteRead(string msg)
        {
            Connect();
            Write(msg);
            string result = Read();
            Disconnect();

            return result;
        }

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

        public void Disconnect()
        {
            reader.Close();
            writer.Close();
            stream.Close();
            tcpClient.Close();
        }

        public void Write(string msg)
        {
            writer.WriteLine(msg);
        }

        public string Read()
        {
            string result = "";

            do
            {
                result += reader.ReadLine();
                //Console.WriteLine(result);
            } while (reader.Peek() >= 0);

            return result;
        }

        public void ASyncRead(Action act)
        {
            new Task(() =>
            {
                string result;

                try
                {
                    do
                    {
                        result = Instance.Read();
                        act(result);
                    } while (true);
                }
                catch (Exception e) { }
            }).Start();
        }
    }
}
