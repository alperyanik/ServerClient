using System;
using System.Windows.Forms;
using Client.Logic;

namespace Client.Forms
{
    public partial class MainForm : Form
    {
        private ClientLogic client;

        public MainForm()
        {
            InitializeComponent();
            client = new ClientLogic(rtbMessages);
            client.Connect("127.0.0.1", 5000);
        }

        // Text gönder
        private void btnSend_Click(object sender, EventArgs e)
        {
            string msg = txtMessage.Text.Trim();
            if (!string.IsNullOrEmpty(msg))
            {
                client.SendText(msg); // Güncel metod adı
                txtMessage.Clear();
            }
        }

        // Resim gönder
        private void btnSendImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Resim Dosyaları|*.jpg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                client.SendFile(ofd.FileName, "IMAGE");
            }
        }

        // Ses gönder
        private void btnSendAudio_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Ses Dosyaları|*.mp3;*.wav";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                client.SendFile(ofd.FileName, "AUDIO");
            }
        }

        // Video gönder
        private void btnSendVideo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Video Dosyaları|*.mp4;*.avi";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                client.SendFile(ofd.FileName, "VIDEO");
            }
        }
    }
}
