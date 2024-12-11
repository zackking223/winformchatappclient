using System;
using System.Windows.Forms;

namespace ChatAppClient
{
    public partial class FormDangNhap : Form
    {
        ProcessDataBase processDB = new ProcessDataBase();
        public FormDangNhap()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void DangKyBtn_Click(object sender, EventArgs e)
        {
            if (!processDB.KiemTraLap("NguoiDung", tenDangNhapBox.Text.Trim(), "maND"))
            {
                processDB.CapNhatDuLieu($"Insert into NguoiDung (maND, matKhau) VALUES (N'{tenDangNhapBox.Text.Trim()}',N'{ProcessDataBase.MaHoaMatKhau(matKhauBox.Text.Trim())}')");
                MessageBox.Show("Tạo tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DangNhapBtn_Click(object sender, EventArgs e)
        {
            if (processDB.XacThuc(tenDangNhapBox.Text.Trim(), matKhauBox.Text.Trim())) {
                if (!processDB.KiemTraOnline(tenDangNhapBox.Text.Trim()))
                {
                    this.Hide();
                    NguoiDung user = processDB.LayThongTin(tenDangNhapBox.Text.Trim());
                    var form2 = new FormTrungTam(user.ten);

                    form2.Closed += (s, args) => this.Close();
                    form2.Show();
                } else
                {
                    MessageBox.Show("Tài khoản đã được đăng nhập ở nơi khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Sai email hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DangNhap()
        {
            if (processDB.XacThuc(tenDangNhapBox.Text.Trim(), matKhauBox.Text.Trim()))
            {
                if (!processDB.KiemTraOnline(tenDangNhapBox.Text.Trim()))
                {
                    this.Hide();
                    NguoiDung user = processDB.LayThongTin(tenDangNhapBox.Text.Trim());
                    var form2 = new FormTrungTam(user.ten);

                    form2.Closed += (s, args) => this.Close();
                    form2.Show();
                }
                else
                {
                    MessageBox.Show("Tài khoản đã được đăng nhập ở nơi khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Sai email hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DangNhap();   
            }
        }
    }
}
