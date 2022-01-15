using SimpleTCP;
using System;
using System.Windows.Forms;
using System.Net;
using System.Text;



namespace Client
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SimpleTcpServer client;
        

        private void Form1_Load(object sender, EventArgs e)
        {
            SimpleTcpServer client = new SimpleTcpServer(); 
            client.StringEncoder = Encoding.UTF8;
 
            client.Delimiter = 0x13; //enter
            client.DataReceived += Client_DataReceived;


        }

        private void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            throw new NotImplementedException();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
        }
        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            txtStatus.Invoke((MethodInvoker)delegate ()
           {
               txtStatus.Text += e.MessageString;
              
           });
        }
       public void btnSend_Click(object sender, EventArgs e)
        {

           // client.WriteLineAndGetReply(txtMessage.Text, TimeSpan.FromSeconds(3));
            

        }

        private void txtHost_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {

        }
    }

    
}
