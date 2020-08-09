using System;
using FRC_Scouting_6487.Data;
using FRC_Scouting_6487.Models;
using FRC_Scouting_6487.Properties;
using FRC_Scouting_6487.Lib;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.IO;

namespace ScoutingServer
{
    class Program
    {
        static TeamDatabase database;

        public static TeamDatabase Database
        {
            get
            {
                if (database == null) database = new TeamDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                return database;
            }
        }

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
            ConsoleLog.Log("Starting TCP Listener");
            #region Start TCP Server
            Thread ServerStartingThread = new Thread(ServerStartingHandler);
            ServerStartingThread.Start();
            #endregion
            ConsoleLog.Log("Main Thread Ends");
        }

        static async void ServerStartingHandler(Object obj)
        {
            ConsoleLog.Succeed("Server Starting Thread Started.");
            #region TCP Listener Starts
            TcpListener tcpListener;
            try
            {
                tcpListener = new TcpListener(System.Net.IPAddress.Any, WebProperties.ListeningPort);
                tcpListener.Start();
                ConsoleLog.Succeed("TCP Listener Started.");
                ConsoleLog.Info("TCP Listening Port: " + WebProperties.ListeningPort);
            } catch (Exception e)
            {
                ConsoleLog.LogException(e, "TCP Listener Started Failed.");
                ConsoleLog.Info("Quiting the application.");
                return;
            }
            #endregion
            while (true)
            {
                try
                {
                    ConsoleLog.Log("IDLE: Waiting for new client to connect.");
                    TcpClient client = await tcpListener.AcceptTcpClientAsync();
                    ConsoleLog.Succeed("New Client Connected.");
                    Thread clientHandlingThread = new Thread(ServerConnectionHandler);
                    clientHandlingThread.Start(client);
                } catch (Exception e)
                {
                    ConsoleLog.LogException(e, "An Error Occurred in Accepting Thread.");
                    ConsoleLog.Info("Continuing for the next loop.");
                }
            }
        }

        static async void ServerConnectionHandler(Object obj)
        {
            try
            {
                #region Receiving Message
                ConsoleLog.Succeed("Handling Thread Started.");

                TcpClient client = obj as TcpClient;
                NetworkStream clientStream = client.GetStream();

                StreamReader sr = new StreamReader(clientStream);
                string result = await sr.ReadToEndAsync();
                sr.Close();

                ConsoleLog.Info("Message Length: " + result.Length);
                ConsoleLog.Info("Message Received: " + result);

                StreamWriter sw = new StreamWriter(clientStream);
                await sw.WriteAsync("Receiving Successed!");
                sw.Flush();
                sw.Close();

                clientStream.Close();
                client.Close();
                #endregion
                #region Handling the request

                #endregion
            }
            catch (Exception e)
            {
                ConsoleLog.LogException(e, "An Error Occurred in the Handling Thread.");
                ConsoleLog.Info("Continuing the Program.");
            }
        }
    }
}
