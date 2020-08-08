using System;
using FRC_Scouting_6487.Data;
using FRC_Scouting_6487.Models;
using FRC_Scouting_6487.Properties;
using FRC_Scouting_6487.Lib;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace ScoutingServer
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Program Starts
            ConsoleLog.Succeed("----------- Program Starts -----------");
            ConsoleLog.Note("|                                    |");
            ConsoleLog.Note("--- FRC Scouting Web Server (6487) ---");
            ConsoleLog.Note("|                                    |");
            ConsoleLog.Note("--------- Author: Haoyun Qin ---------");
            ConsoleLog.Log("");
            ConsoleLog.Info ("GitHub Link: https://github.com/JeffersonQin/FRC-Scouting-6487");
            ConsoleLog.Log("");
            ConsoleLog.Log("**************************************");
            ConsoleLog.Log("");
            ConsoleLog.Log("");
            ConsoleLog.Log("");
            ConsoleLog.Log("**************************************");
            #endregion
            #region TCP Listener Starts
            TcpListener tcpListener = new TcpListener(System.Net.IPAddress.Any, WebProperties.ListeningPort);
            tcpListener.Start();
            ConsoleLog.Succeed("TCP Listener Starts Succuss");
            ConsoleLog.Info("TCP Listening Port: " + WebProperties.ListeningPort);
            #endregion
            while (true)
            {
                ConsoleLog.Log("IDLE: Waiting for new client to connect.");
                TcpClient client = tcpListener.AcceptTcpClient();
                Thread clientHandlingThread = new Thread(ServerConnectionHandler);
                clientHandlingThread.Start(client);
            }
        }

        static void ServerConnectionHandler(Object obj)
        {
            TcpClient client = obj as TcpClient;
            NetworkStream clientStream = client.GetStream();

            const int bufferSize = 8192;
            byte[] buffer = new byte[bufferSize];
            int len;
            while ((len = clientStream.Read(buffer, 0, bufferSize)) != -1)
            {
                string request = Encoding.ASCII.GetString(buffer).Substring(0, len);
                ConsoleLog.Note(request);
            }
        }
    }
}
