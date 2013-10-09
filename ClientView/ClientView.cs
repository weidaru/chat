using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace ClientView
{
    public partial class Client : Form
    {
        private TcpSocket.Client client;

        public Client(String name)
        {
            InitializeComponent();
            Text += (" " + name);
            client = new TcpSocket.Client(DisplayOnReceive, LogOnLogger, name);
            try
            {
                client.Start();
            }
            catch (SocketException)
            {
                MessageBox.Show("The server is not on. Please try next time.");
            }
        }


        private void SendButton_Click(object sender, EventArgs e)
        {
            client.SendMessage(inputBox.Text);
            receive.AppendText("@" + client.GetName() + " - " + inputBox.Text + '\n');
            inputBox.Clear();
        }

        private void DisplayOnReceive(String name, String message)
        {
            try
            {
                receive.AppendText("@Server" + " - " + message + '\n');
            }
            catch (InvalidOperationException)
            {
                receive.Invoke((MethodInvoker)delegate()
                {
                    receive.AppendText("@Server" + " - " + message + '\n');
                });
            }


        }

        private void LogOnLogger(String message)
        {
            try
            {
                logger.AppendText(message + "\n");
            }
            catch (InvalidOperationException)
            {
                logger.Invoke((MethodInvoker)delegate()
                {
                    logger.AppendText(message + '\n');
                });
            }
        }


        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.Close();
        }
    }
}
