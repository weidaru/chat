using System;
using System.Collections.Generic;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TcpSocket
{
    class Client : HasDisplayDelegate
    {
        private TcpClient tcpClient;
        private String name;
        private Thread listenThread;

        private void DisplayOnConsole(String name, String message)
        {
            Console.WriteLine(message);
        }

        private void LogOnConsole(String m)
        {
            Console.WriteLine(m);
        }

        private byte[] Encrypt(byte[] org)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            logDelegate("Encrypt " + encoder.GetString(org));
            return CaesarCoding.Encrypt(org);
        }

        private byte[] Decrypt(byte[] res)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            logDelegate("Decrypt " + encoder.GetString(res).Trim('\0'));
            return CaesarCoding.Decrypt(res);
        }

        public void Start()
        {
            try
            {
                tcpClient.Connect("localhost", 11000);
                SendMessage(name);
                listenThread.Start();
            }
            catch (SocketException ex)
            {
                throw ex;
            }
        }

        public void Close()
        {
            tcpClient.Close();
            listenThread.Abort();
        }

        public String GetName()
        {
            return name;
        }


        public Client(String name)
        {
            Init(DisplayOnConsole, LogOnConsole, name);
        }

        public Client(DisplayDelegate d, LogDelegate l, String name)
        {
            Init(d, l, name);
        }

        private void Init(DisplayDelegate d, LogDelegate l, String name)
        {
            displayDelegate = d;
            logDelegate = l;
            this.name = name;
            tcpClient = new TcpClient();
            listenThread = new Thread(new ThreadStart(ListenToServer));

        }

        public void SendMessage(String message)
        {
                NetworkStream stream = tcpClient.GetStream();
                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] ba = encoder.GetBytes(message);
                logDelegate("Client " + name + " sending message to server ");

                stream.Write(Encrypt(ba), 0, ba.Length);
        }

        private void ListenToServer()
        {
            logDelegate("Connected to localhost:11000");

            NetworkStream stream = tcpClient.GetStream();
            byte[] buffer = new byte[2048];

            while (true)
            {
                int count = 0;

                try
                {
                    count = stream.Read(buffer, 0, 2048);
                }
                catch
                {
                    break;
                }

                if (count == 0)
                    break;

                ASCIIEncoding encoder = new ASCIIEncoding();
                String str = encoder.GetString(Decrypt(buffer), 0, count).TrimEnd('\0');
                displayDelegate(name, str);
            }
            tcpClient.Close();
        }
    }
}
