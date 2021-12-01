using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTalk_Sever
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(Object sender, EventArgs e)
        {
        }


        private void ServerOpenButton_Click(Object sender, EventArgs e)
        {
            ChatGroup newGroup = new ChatGroup();

            newGroup.StartChatSever();
            ServerStatusLabel.Text = "서버 상태 : ON";
        }


    }
}
