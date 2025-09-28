namespace Client.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.RichTextBox rtbMessages;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnSendImage;
        private System.Windows.Forms.Button btnSendAudio;
        private System.Windows.Forms.Button btnSendVideo;

        private void InitializeComponent()
        {
            this.rtbMessages = new System.Windows.Forms.RichTextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnSendImage = new System.Windows.Forms.Button();
            this.btnSendAudio = new System.Windows.Forms.Button();
            this.btnSendVideo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbMessages
            this.rtbMessages.Location = new System.Drawing.Point(12, 12);
            this.rtbMessages.Size = new System.Drawing.Size(460, 250);
            this.rtbMessages.ReadOnly = true;
            // 
            // txtMessage
            this.txtMessage.Location = new System.Drawing.Point(12, 270);
            this.txtMessage.Size = new System.Drawing.Size(360, 22);
            // 
            // btnSend
            this.btnSend.Location = new System.Drawing.Point(380, 268);
            this.btnSend.Size = new System.Drawing.Size(92, 25);
            this.btnSend.Text = "Gönder";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnSendImage
            this.btnSendImage.Location = new System.Drawing.Point(12, 300);
            this.btnSendImage.Size = new System.Drawing.Size(110, 25);
            this.btnSendImage.Text = "Resim Gönder";
            this.btnSendImage.Click += new System.EventHandler(this.btnSendImage_Click);
            // 
            // btnSendAudio
            this.btnSendAudio.Location = new System.Drawing.Point(130, 300);
            this.btnSendAudio.Size = new System.Drawing.Size(110, 25);
            this.btnSendAudio.Text = "Ses Gönder";
            this.btnSendAudio.Click += new System.EventHandler(this.btnSendAudio_Click);
            // 
            // btnSendVideo
            this.btnSendVideo.Location = new System.Drawing.Point(250, 300);
            this.btnSendVideo.Size = new System.Drawing.Size(110, 25);
            this.btnSendVideo.Text = "Video Gönder";
            this.btnSendVideo.Click += new System.EventHandler(this.btnSendVideo_Click);
            // 
            // MainForm
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.rtbMessages);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnSendImage);
            this.Controls.Add(this.btnSendAudio);
            this.Controls.Add(this.btnSendVideo);
            this.Text = "Client Chat";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
