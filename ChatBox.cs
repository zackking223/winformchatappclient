using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatAppClient
{
    public partial class ChatBox : Form
    {
        Socket client;
        IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
        string sender = NguoiDung.maND;
        string receiver;
        bool isRunning = true;
        bool CancelClose = true;

        public ChatBox(string nguoiGui, string nguoiNhan)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.sender = nguoiGui;
            this.receiver = nguoiNhan;
            Task.Run(SocketStartFunc);
        }

        private void ChatBox_Load(object sender, EventArgs e)
        {
            this.Text = "Chat riêng với " + receiver;
        }

        private async Task SocketStartFunc()
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            await client.ConnectAsync(ipep);
            NetworkStream stream = new NetworkStream(client);
            StreamWriter writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            StreamReader reader = new StreamReader(stream);

            //Telling the server this socket is 1 client - 1 client
            //Telling the server who sent, who to receive
            MessageObj msg = new MessageObj()
            {
                Type = "PrivateChat",
                Sender = sender,
                Receiver = receiver,
                Message = "None",
                Role = "None",
                RoomName = "None"
            };
            string jsonString = JsonSerializer.Serialize<MessageObj>(msg);
            await writer.WriteLineAsync(jsonString);

            while (isRunning)
            {
                string response = await reader.ReadLineAsync();
                MessageObj message = JsonSerializer.Deserialize<MessageObj>(response);

                if (message.Type == "SendMessage")
                {
                    this.Invoke(new Action(() => {
                        AddMessage(message.Message);
                    }));
                } else if (message.Type == "CloseForm")
                {
                    this.Invoke(new Action(() => {
                        isRunning = false;
                        if (client != null)
                        {
                            client.Shutdown(SocketShutdown.Both);
                            client.Close();
                        }
                        CancelClose = false;
                        this.Close();
                    }));
                }
                
            }
            writer.Dispose();
            reader.Dispose();
            stream.Close();
        }

        private async Task SendData(string message, string type)
        {
            NetworkStream stream = new NetworkStream(client);
            StreamWriter writer = new StreamWriter(stream);
            writer.AutoFlush = true;

            MessageObj msg = new MessageObj()
            {
                Type = type,
                Sender = sender,
                Receiver = receiver,
                Message = message,
                Role = "None",
                RoomName = "None"
            };
            string jsonString = JsonSerializer.Serialize<MessageObj>(msg);
            await writer.WriteLineAsync(jsonString);

            writer.Close();
            stream.Close();
        }

        private void AddMessage(string text, string sender)
        {
            this.danhSachTinNhan.Items.Add($"{sender}: {text}");
        }

        private void AddMessage(string text)
        {
            this.danhSachTinNhan.Items.Add($"{text}");
        }

        private async void GuiBtn_Click(object sender, EventArgs e)
        {
            int i = tinNhanBox.SelectionStart;
            if (tinNhanBox.Text.Trim() != "")
            {
                AddMessage(tinNhanBox.Text.Trim(), "Bạn");
                await SendData(tinNhanBox.Text.Trim(), "SendMessage");
                tinNhanBox.Clear();
                tinNhanBox.SelectionStart = i;
                tinNhanBox.SelectionLength = 0;
            }
        }

        private void NgatBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void tinNhanBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int i = tinNhanBox.SelectionStart;
                if (tinNhanBox.Text.Trim() != "")
                {
                    AddMessage(tinNhanBox.Text.Trim(), "Bạn");
                    await SendData(tinNhanBox.Text.Trim(), "SendMessage");
                    tinNhanBox.Clear();
                    tinNhanBox.SelectionStart = i;
                    tinNhanBox.SelectionLength = 0;
                }
            }
        }

        private async void ChatBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = CancelClose;
            if (CancelClose) await SendData(FormTrungTam.EXIT_ROOM_CODE, FormTrungTam.EXIT_ROOM_CODE);
        }
    }
}
