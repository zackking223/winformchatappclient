using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatAppClient
{
    public partial class GroupBox : Form
    {
        Socket client;
        IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
        string roomID;
        string sender;
        string role = "Owner";
        bool isRunning = true;
        bool CancelClose = true;
        ProcessDataBase processDB = new ProcessDataBase();

        public GroupBox(string roomID, string sender, string role)
        {
            InitializeComponent();

            this.roomID = roomID;
            this.sender = sender;
            this.role = role;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            Task.Run(SocketStartFunc);
        }

        private async Task SocketStartFunc()
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            await client.ConnectAsync(ipep);
            NetworkStream stream = new NetworkStream(client);
            StreamWriter writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            StreamReader reader = new StreamReader(stream);

            //Telling the server this socket is a group chat
            //Telling the server who you are, who own the room, what is your role
            MessageObj msg = new MessageObj()
            {
                Type = "GroupChat",
                Sender = sender,
                Receiver = "None",
                Message = "None",
                Role = role,
                RoomName = roomID
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
                    this.Invoke(new Action (() => {
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

        private async Task SendData(string message, string requestType)
        {
            NetworkStream stream = new NetworkStream(client);
            StreamWriter writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            MessageObj msg = new MessageObj()
            {
                Type = requestType,
                Sender = sender,
                Receiver = "None",
                Message = message,
                Role = role,
                RoomName = roomID
            };
            string jsonString = JsonSerializer.Serialize<MessageObj>(msg);
            await writer.WriteLineAsync(jsonString);

            writer.Close();
            stream.Close();
        }

        private async Task SendData(string message, string requestType, string receiver)
        {
            NetworkStream stream = new NetworkStream(client);
            StreamWriter writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            MessageObj msg = new MessageObj()
            {
                Type = requestType,
                Sender = sender,
                Receiver = receiver,
                Message = message,
                Role = role,
                RoomName = roomID
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

        private void GroupBox_Load(object sender, EventArgs e)
        {
            this.Text = "Phòng của " + roomID;
        }

        private async void MoiBtn_Click(object objSender, EventArgs e)
        {
            if (InviteBox.Text != "")
            {
                if (processDB.KiemTraLap("NguoiDung", InviteBox.Text.Trim(), "maND"))
                {
                    if (InviteBox.Text.Trim() != sender)
                    {
                        await SendData("Mời " + InviteBox.Text.Trim(), "AddReceiver", InviteBox.Text.Trim());
                        InviteBox.Clear();
                    } else
                    {
                        MessageBox.Show("Không được tự mời bản thân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        InviteBox.Focus();
                    }
                } else
                {
                    MessageBox.Show("Tên người dùng sai hoặc không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    InviteBox.Focus();
                }
            } else
            {
                MessageBox.Show("Bạn phải nhập tên người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                InviteBox.Focus();
            }
        }

        private async void InviteBox_KeyDown(object objSender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(InviteBox.Text != "")
                {
                    if (processDB.KiemTraLap("NguoiDung", InviteBox.Text.Trim(), "maND"))
                    {
                        if (InviteBox.Text.Trim() != sender)
                        {
                            await SendData("Mời " + InviteBox.Text.Trim(), "AddReceiver", InviteBox.Text.Trim());
                            InviteBox.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Không được tự mời bản thân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            InviteBox.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên người dùng sai hoặc không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        InviteBox.Focus();
                    }
                } else
                {
                    MessageBox.Show("Bạn phải nhập tên người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    InviteBox.Focus();
                }
            }
        }

        private async void GuiBtn_Click(object sender, EventArgs e)
        {
            if (tinNhanBox.Text.Trim() != "")
            {
                AddMessage(tinNhanBox.Text.Trim(), "Bạn");
                await SendData(tinNhanBox.Text.Trim(), "SendMessage");
                tinNhanBox.Clear();
                InviteBox.Text = "Nhập tên người dùng";
                InviteBox.ForeColor = Color.Silver;
            }
        }

        private async void tinNhanBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tinNhanBox.Text.Trim() != "")
                {
                    AddMessage(tinNhanBox.Text.Trim(), "Bạn");
                    await SendData(tinNhanBox.Text.Trim(), "SendMessage");
                    tinNhanBox.Clear();
                    InviteBox.Text = "Nhập tên người dùng";
                    InviteBox.ForeColor = Color.Silver;
                }
            }
        }

        private void NgatBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void InviteBox_Enter(object sender, EventArgs e)
        {
            if (InviteBox.Text == "Nhập tên người dùng")
            {
                InviteBox.Text = "";
                InviteBox.ForeColor = Color.Black;
            }
        }

        private void InviteBox_Leave(object sender, EventArgs e)
        {
            if (InviteBox.Text == "")
            {
                InviteBox.Text = "Nhập tên người dùng";
                InviteBox.ForeColor = Color.Silver;
            }
        }
        private async void GroupBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = CancelClose;
            if (CancelClose) await SendData(FormTrungTam.EXIT_ROOM_CODE, FormTrungTam.EXIT_ROOM_CODE);
        }
    }
}
