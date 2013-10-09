using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;

namespace TcpSocket
{
    class Server : HasDisplayDelegate
    {
        private TcpListener tcpListener;
        private Dictionary<String, TcpClient> clients;
        private Thread listenThread;

        public Server()
        {
            Init(DisplayOnConsole, LogOnConsole);
        }

        public Server(DisplayDelegate d, LogDelegate l)
        {
            Init(d, l);
        }


        private void DisplayOnConsole(String name, String message)
        {
            Console.WriteLine("@" + name + "-" + message);
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
            logDelegate("Decrypt " + encoder.GetString(res).TrimEnd('\0'));
            return CaesarCoding.Decrypt(res);
        }


        private void Init(DisplayDelegate d, LogDelegate l)
        {
            SetDisplayDelegate(d);
            SetLogDelegate(l);
            
            tcpListener = new TcpListener(IPAddress.Any, 11000);
            clients = new Dictionary<String, TcpClient>();

            listenThread = new Thread(new ThreadStart(ListenToClient));
        }

        public void Start()
        {
            listenThread.Start(); 
        }

        public void Close()
        {
            tcpListener.Stop();
            listenThread.Abort();
        }


        private void ListenToClient()
        {
            logDelegate("The server is running at port 11000...");
            tcpListener.Start();
            logDelegate("Waiting for connection");

            while (true)
            {
                TcpClient c = tcpListener.AcceptTcpClient();
                Thread t = new Thread(new ParameterizedThreadStart(HandleClientInput));
                t.Start(c);
            }
        }

        private void HandleClientInput(object obj)
        {
            TcpClient c = (TcpClient)obj;
            String name = null;
            NetworkStream stream = c.GetStream();
            bool firstTime = true; ;

            while (true)
            {
                int count = 0;
                byte[] buffer = new byte[2048];

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
                if (firstTime)
                {
                    name = str;
                    clients[name] = c;
                    logDelegate("New connection established. @" + name);
                    firstTime = false;
                }
                else
                {
                    logDelegate("New message. @" + name);
                    displayDelegate(name, str);
                }
            }

            c.Close();
            if (name != null)
            {
                clients.Remove(name);
                logDelegate("Connection with client name " + name + " closed");
            }
        }

        public void SendMessage(String clientName, String message)
        {
            TcpClient c = clients[clientName];
            NetworkStream stream = c.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] ba = encoder.GetBytes(message);
            logDelegate("Sending message to client " + clientName);

            stream.Write(Encrypt(ba), 0, ba.Length);
        }

        public String[] GetClientNames()
        {
            String[] result = new String[clients.Count];
            clients.Keys.CopyTo(result, 0);
            return result ;
        }
    }
}
