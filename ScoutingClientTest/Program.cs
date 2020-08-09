using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using FRC_Scouting_6487.Properties;

namespace ScoutingClientTest
{
    class Program
    {
        private static TcpClient ConnectToServer()
        {
            TcpClient client = new TcpClient();
            IPHostEntry host = Dns.GetHostEntry("127.0.0.1");
            var address = (from h in host.AddressList
                           where h.AddressFamily == AddressFamily.InterNetwork
                           select h).First();
            client.Connect(address.ToString(), WebProperties.ListeningPort);
            return client;
        }

        static void Main(string[] args)
        {
            Start();
        }

        private static async void Start()
        {
            TcpClient client = ConnectToServer();
            NetworkStream clientStream = client.GetStream();
            StreamWriter sw = new StreamWriter(clientStream);
            await sw.WriteAsync("abcdefg");
            sw.Flush();
            sw.Close();
            clientStream.Close();
            client.Close();
        }
    }
}
