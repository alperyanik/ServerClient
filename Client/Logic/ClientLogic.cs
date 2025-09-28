using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace Client.Logic
{
    public class ClientLogic
    {
        private TcpClient client;
        private NetworkStream stream;
        private RichTextBox rtbMessages;

        public ClientLogic(RichTextBox rtb)
        {
            rtbMessages = rtb;
        }

        public void Connect(string ip, int port)
        {
            client = new TcpClient(ip, port);
            stream = client.GetStream();
            UpdateRTB("Server'a bağlandı!\n");

            // Server’dan gelen mesajları dinleme
            Thread listenThread = new Thread(ListenForMessages);
            listenThread.IsBackground = true;
            listenThread.Start();
        }

        private void ListenForMessages()
        {
            byte[] buffer = new byte[4096];
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                UpdateRTB("Server: " + message + "\n");
            }
        }

        public void SendText(string message)
        {
            if (client != null && client.Connected)
            {
                string formatted = "TEXT|" + message;
                byte[] data = Encoding.UTF8.GetBytes(formatted);
                stream.Write(data, 0, data.Length);
                UpdateRTB("Client: " + message + "\n");
            }
        }

        public void SendFile(string filePath, string type)
        {
            if (client == null || !client.Connected) return;
            byte[] fileData = File.ReadAllBytes(filePath);
            string fileName = Path.GetFileName(filePath);
            string header = $"{type}|{fileName}|";
            byte[] headerBytes = Encoding.UTF8.GetBytes(header);

            // Header + file data
            byte[] sendData = new byte[headerBytes.Length + fileData.Length];
            Buffer.BlockCopy(headerBytes, 0, sendData, 0, headerBytes.Length);
            Buffer.BlockCopy(fileData, 0, sendData, headerBytes.Length, fileData.Length);

            stream.Write(sendData, 0, sendData.Length);
            UpdateRTB($"Client {type} gönderdi: {fileName}\n");
        }

        private void UpdateRTB(string message)
        {
            if (rtbMessages.InvokeRequired)
                rtbMessages.Invoke(new Action(() => rtbMessages.AppendText(message)));
            else
                rtbMessages.AppendText(message);
        }

        public void Close()
        {
            client.Close();
        }
    }
}
