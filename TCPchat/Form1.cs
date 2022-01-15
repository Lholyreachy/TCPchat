using System;
using System.Text;
using System.Windows.Forms;
using SimpleTCP;
using System.Net;

namespace TCPchat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SimpleTcpServer server;
   
        private void Form1_Load(object sender, EventArgs e)
        {

            server = new SimpleTcpServer();
            server.Delimiter = 0x13; // enter
            server.StringEncoder = Encoding.UTF8;
            server.DataReceived += Server_DataReceived;

        }
    
            private void Server_DataReceived(object sender, SimpleTCP.Message e)
            {
                txtStatus.Invoke((MethodInvoker)delegate ()
                {
                    txtStatus.Text += e.MessageString;
                   e.ReplyLine(string.Format("You said: {0}", e.MessageString));
                });
            }

        private void btnStart_Click(object sender, EventArgs e)
        {
            txtStatus.Text += "Server starting...";
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            // System.Net.IPAddress ip = new System.Net.IPAddress(long.Parse(txtHost.Text));
            server.Start(ip, Convert.ToInt32(txtPort.Text));

            //IPAddress ip = IPAddress.Parse("127.0.0.1");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if(server.IsStarted)
                server.Stop();
        }
    }
}
