using System;
using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace Client
{
    class Program
    {
        /*TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        NetworkStream serverStream = default(NetworkStream);
        string readData = null;
        string ipGateway = "127.0.0.1";
        string nickname = "boy";
        */

        static void Main(string[] args)
        {
            TcpClient clientSocket = new System.Net.Sockets.TcpClient();
            NetworkStream serverStream = default(NetworkStream);
            string ipGateway = "127.0.0.1";
            string nickname = "boy";

            connect(clientSocket, ipGateway, serverStream, nickname);

            //create 'serverListener thread'


            //'userListener' loop
        }

        public static void connect(TcpClient clientSocket, string ipGateway, NetworkStream serverStream, string nickname)
        {
            Console.WriteLine("Connecting to chat... " + ipGateway);
            clientSocket.Connect(ipGateway, 8888);
            serverStream = clientSocket.GetStream();

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(nickname);

            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }

        public static void serverListener(NetworkStream serverStream, TcpClient clientSocket)
        {
            while (true)
            {
                serverStream = clientSocket.GetStream();
                int buffSize = 0;
                byte[] inStream = new byte[10025];
                buffSize = clientSocket.ReceiveBufferSize;
                serverStream.Read(inStream, 0, buffSize);
                string returndata = System.Text.Encoding.ASCII.GetString(inStream);
            }
        }

    }
}