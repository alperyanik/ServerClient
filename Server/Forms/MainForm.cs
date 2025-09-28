using System;
using System.Windows.Forms;
using Server.Logic;

namespace Server.Forms
{
    public partial class MainForm : Form
    {
        private ServerLogic server;

        public MainForm()
        {
            InitializeComponent();
            server = new ServerLogic(rtbMessages);
            server.StartServer("127.0.0.1", 5000);
        }
    }
}
