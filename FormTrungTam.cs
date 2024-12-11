using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;

namespace ChatAppClient
{
    public partial class FormTrungTam : Form
    {
        private string ten = "noname";
        private string nguoiNhan;
        ProcessDataBase processDB = new ProcessDataBase();
        Socket client;
        IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
        bool isRunning = true;
        public static string EXIT_ROOM_CODE = "qwjeklqwjklfnmmasasm,dasn,dwqqwkl:wqe;;e";
        public FormTrungTam(string ten)
        {
            InitializeComponent();
            this.ten = ten;
            tenNguoiDung.Text = "Tên: " + ten;
            danhSachOnline.Items.Clear();
            getOnlineUsers();
            Task.Run(SocketStartFunc);
        }

        private void FormTrungTam_Load(object sender, EventArgs e)
        {
            this.Text = "Phần mềm chat - " + ten;
        }
        private async Task SocketStartFunc()
        {
            isRunning = true;
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            await client.ConnectAsync(ipep);
            NetworkStream stream = new NetworkStream(client);
            StreamWriter writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            StreamReader reader = new StreamReader(stream);

            //Telling the server this socket is a lobby
            //Telling the server who sent
            MessageObj msg = new MessageObj()
            {
                Type = "Lobby",
                Sender = ten,
                Receiver = "None",
                Message = "Hello",
                Role = "None",
                RoomName = ten
            };
            string jsonString = JsonSerializer.Serialize<MessageObj>(msg);
            await writer.WriteLineAsync(jsonString);

            while (isRunning)
            {
                string response = await reader.ReadLineAsync();
                MessageObj message = JsonSerializer.Deserialize<MessageObj>(response);

                if (message.Type == "InviteToRoom")
                {
                    await SendData("Đã nhận được lời mời", "InviteReceived",message.Sender);
                    this.Invoke(new Action(async () => {
                        await ShowInvitation(message.Message, message.RoomName);
                    }));
                }
            }
            writer.Dispose(); 
            reader.Dispose();
            stream.Close();
        }

        private async Task ShowInvitation(string message, string roomName)
        {
            string title = "Lời mời";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                isRunning = false;
                await SendData(EXIT_ROOM_CODE, EXIT_ROOM_CODE);
                client.Close();

                danhSachOnline.Enabled = false;
                TaoPhongBtn.Enabled = false;
                DangXuatBtn.Enabled = false;
                GroupBox groupChat = new GroupBox(roomName, ten, "Guest");
                groupChat.Closed += (s, args) =>
                {
                    danhSachOnline.Enabled = true;
                    TaoPhongBtn.Enabled = true;
                    DangXuatBtn.Enabled = true;
                    Task.Run(SocketStartFunc);
                };
                groupChat.Show();
            }
            else
            {
                await SendData($"{ten} từ chối tham gia phòng!","DenyInvitation", roomName);
            }
        }

        private async Task SendData(string message, string type)
        {
            NetworkStream stream = new NetworkStream(client);
            StreamWriter writer = new StreamWriter(stream);
            writer.AutoFlush = true;

            MessageObj msg = new MessageObj()
            {
                Type = type,
                Sender = ten,
                Receiver = "None",
                Message = message,
                Role = "None",
                RoomName = "None"
            };
            string jsonString = JsonSerializer.Serialize<MessageObj>(msg);
            await writer.WriteLineAsync(jsonString);

            writer.Close();
            stream.Close();
        }

        private async Task SendData(string message, string type, string receiver)
        {
            NetworkStream stream = new NetworkStream(client);
            StreamWriter writer = new StreamWriter(stream);
            writer.AutoFlush = true;

            MessageObj msg = new MessageObj()
            {
                Type = type,
                Sender = ten,
                Receiver = receiver,
                Message = message,
                Role = "None",
                RoomName = receiver
            };
            string jsonString = JsonSerializer.Serialize<MessageObj>(msg);
            await writer.WriteLineAsync(jsonString);

            writer.Close();
            stream.Close();
        }

        private void getOnlineUsers()
        {
            List<string> danhSach = processDB.DanhSachOnline();
            this.danhSachOnline.SelectedIndexChanged -= danhSachOnline_SelectedIndexChanged;
            danhSachOnline.DataSource = danhSach;
            this.danhSachOnline.SelectedIndexChanged += danhSachOnline_SelectedIndexChanged;
        }

        private async void danhSachOnline_SelectedIndexChanged(object sender, EventArgs e)
        {
            isRunning = false;
            await SendData(EXIT_ROOM_CODE, EXIT_ROOM_CODE);
            client.Close();

            nguoiNhan = danhSachOnline.SelectedItem.ToString();

            danhSachOnline.Enabled = false;
            TaoPhongBtn.Enabled = false;
            DangXuatBtn.Enabled = false;
            ChatBox chat = new ChatBox(ten, nguoiNhan);
            chat.Closed += (s, args) =>
            {
                danhSachOnline.Enabled = true;
                TaoPhongBtn.Enabled = true;
                DangXuatBtn.Enabled = true;
                Task.Run(SocketStartFunc);
            };
            chat.Show();
        }

        private async void TaoPhongBtn_Click(object sender, EventArgs e)
        {
            isRunning = false;
            await SendData(EXIT_ROOM_CODE, EXIT_ROOM_CODE);
            client.Close();

            danhSachOnline.Enabled = false;
            TaoPhongBtn.Enabled = false;
            DangXuatBtn.Enabled = false;
            GroupBox groupChat = new GroupBox(ten, ten, "Owner");
            groupChat.Closed += (s, args) =>
            {
                danhSachOnline.Enabled = true;
                danhSachOnline.Enabled = true;
                TaoPhongBtn.Enabled = true;
                DangXuatBtn.Enabled = true;
                Task.Run(SocketStartFunc);
            };
            groupChat.Show();
        }

        private async void DangXuatBtn_Click(object sender, EventArgs e)
        {
            this.FormClosed -= TrungTam_FormClosed;
            isRunning = false;
            await SendData(EXIT_ROOM_CODE, EXIT_ROOM_CODE);
            if (client != null)
            {
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
            processDB.CapNhatDuLieu($"Update NguoiDung Set isOnline = 0 where maND=N'{ten}'");
            this.Hide();

            var form2 = new FormDangNhap();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private async void TrungTam_FormClosed(object sender, FormClosedEventArgs e)
        {
            processDB.CapNhatDuLieu($"Update NguoiDung Set isOnline = 0 where maND=N'{NguoiDung.maND}'");
            isRunning = false;
            await SendData(EXIT_ROOM_CODE, EXIT_ROOM_CODE);
            if (client != null)
            {
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
        }

        private void LamMoiBtn_Click(object sender, EventArgs e)
        {
            getOnlineUsers();
        }
    }
    class MessageObj
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string RoomName { get; set; }
        public string Role { get; set; }
    }
}


