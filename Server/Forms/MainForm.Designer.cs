namespace Server.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.RichTextBox rtbMessages;

        private void InitializeComponent()
        {
            this.rtbMessages = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbMessages
            this.rtbMessages.Location = new System.Drawing.Point(12, 12);
            this.rtbMessages.Size = new System.Drawing.Size(460, 337);
            this.rtbMessages.ReadOnly = true;
            // 
            // MainForm
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.rtbMessages);
            this.Name = "MainForm";
            this.Text = "Server Chat";
            this.ResumeLayout(false);
        }
    }
}
