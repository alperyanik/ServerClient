using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Server.Logic
{
    public class ServerLogic
    {
        private TcpListener listener;
        private RichTextBox rtbMessages;
        private readonly object clientsLock = new object();
        private readonly List<TcpClient> clients = new List<TcpClient>();

        public ServerLogic(RichTextBox rtb)
        {
            rtbMessages = rtb;
        }

        public void StartServer(string ip, int port)
        {
            Thread serverThread = new Thread(() =>
            {
                listener = new TcpListener(IPAddress.Parse(ip), port);
                listener.Start();
                UpdateRTB("Server başlatıldı, client bekleniyor...\n");

                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    lock (clientsLock) { clients.Add(client); }
                    UpdateRTB("Yeni client bağlandı!\n");
                    Thread clientThread = new Thread(() => HandleClient(client));
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }
            });
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        private void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[4096];

            try
            {
                int bytesRead;
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string header = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    if (header.StartsWith("TEXT|"))
                    {
                        string msg = header.Substring(5);
                        UpdateRTB("Client: " + msg + "\n");
                    }
                    else if (header.StartsWith("IMAGE|") || header.StartsWith("AUDIO|") || header.StartsWith("VIDEO|"))
                    {
                        // Header kısmını ayır
                        int firstSep = header.IndexOf('|', header.IndexOf('|') + 1);
                        string type = header.Substring(0, header.IndexOf('|'));
                        string filename = header.Substring(header.IndexOf('|') + 1, firstSep - header.IndexOf('|') - 1);

                        UpdateRTB($"Client {type} gönderdi: {filename}\n");

                        // Opsiyonel: dosya kaydetmek için
                        // File.WriteAllBytes(Path.Combine("ServerFiles", filename), buffer, firstSep + 1, bytesRead - firstSep - 1);
                    }
                }
            }
            catch { }
            finally
            {
                client.Close();
                lock (clientsLock) { clients.Remove(client); }
                UpdateRTB("Client ayrıldı\n");
            }
        }

        private void UpdateRTB(string message)
        {
            if (rtbMessages.InvokeRequired)
                rtbMessages.Invoke(new Action(() => rtbMessages.AppendText(message + "\n")));
            else
                rtbMessages.AppendText(message + "\n");
        }
    }
}
