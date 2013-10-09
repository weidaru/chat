using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ServerView
{
    public partial class Server : Form
    {
        private TcpSocket.Server server;
        private Dictionary<String, List<String>> receiveDic;

        public Server()
        {
            InitializeComponent();

            server = new TcpSocket.Server(DisplayOnReceive, LogOnLogger);
            receiveDic = new Dictionary<string, List<String>>();
            server.Start();
        }


        private void SendButton_Click(object sender, EventArgs e)
        {
            String name = nameCombo.SelectedItem.ToString();
            server.SendMessage(name, inputBox.Text);
            String m = "@Server - " + inputBox.Text + '\n';
            receive.AppendText(m);
            AddToDic(name, m);
            inputBox.Clear();
        }

        private void AddToDic(String name, String message)
        {
            if (!receiveDic.ContainsKey(name))
                receiveDic[name] = new List<String>();
            receiveDic[name].Add(message);
        }

        private void DisplayOnReceive(String name, String message)
        {
            String text = "@" + name + " - " + message + "\n";
            AddToDic(name, text);

            String curName = null;
            nameCombo.Invoke((MethodInvoker)delegate()
            {
                if (nameCombo.Items.IndexOf(name) == -1)
                    nameCombo.Items.Add(name);

                if (nameCombo.SelectedItem == null)
                {
                    nameCombo.SelectedIndex = nameCombo.FindStringExact(name);
                    return;
                }

                curName = nameCombo.SelectedItem.ToString();

                if (curName.Equals(name))
                {
                    receive.Invoke((MethodInvoker)delegate()
                    {
                        receive.AppendText(text);
                    });
                }
            });

        }

        private void LogOnLogger(String message)
        {
                logger.Invoke((MethodInvoker)delegate()
                {
                    logger.AppendText(message + "\n");
                });
        }

        private void nameCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            String sName = nameCombo.SelectedItem.ToString();
            receive.Clear();
            foreach (String s in receiveDic[sName])
                receive.AppendText(s);
        }

        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            server.Close();
        }
    }
}
