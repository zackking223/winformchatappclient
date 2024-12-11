
namespace ChatAppClient
{
    partial class FormTrungTam
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTrungTam));
            this.danhSachOnline = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TaoPhongBtn = new System.Windows.Forms.Button();
            this.DangXuatBtn = new System.Windows.Forms.Button();
            this.tenNguoiDung = new System.Windows.Forms.Label();
            this.LamMoiBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // danhSachOnline
            // 
            this.danhSachOnline.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.danhSachOnline.FormattingEnabled = true;
            this.danhSachOnline.ItemHeight = 20;
            this.danhSachOnline.Location = new System.Drawing.Point(12, 101);
            this.danhSachOnline.Name = "danhSachOnline";
            this.danhSachOnline.Size = new System.Drawing.Size(338, 464);
            this.danhSachOnline.TabIndex = 3;
            this.danhSachOnline.SelectedIndexChanged += new System.EventHandler(this.danhSachOnline_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Danh sách online";
            // 
            // TaoPhongBtn
            // 
            this.TaoPhongBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.TaoPhongBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaoPhongBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TaoPhongBtn.Location = new System.Drawing.Point(376, 70);
            this.TaoPhongBtn.Name = "TaoPhongBtn";
            this.TaoPhongBtn.Size = new System.Drawing.Size(150, 45);
            this.TaoPhongBtn.TabIndex = 6;
            this.TaoPhongBtn.Text = "Tạo phòng";
            this.TaoPhongBtn.UseVisualStyleBackColor = false;
            this.TaoPhongBtn.Click += new System.EventHandler(this.TaoPhongBtn_Click);
            // 
            // DangXuatBtn
            // 
            this.DangXuatBtn.BackColor = System.Drawing.Color.DarkRed;
            this.DangXuatBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DangXuatBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.DangXuatBtn.Location = new System.Drawing.Point(376, 140);
            this.DangXuatBtn.Name = "DangXuatBtn";
            this.DangXuatBtn.Size = new System.Drawing.Size(150, 45);
            this.DangXuatBtn.TabIndex = 6;
            this.DangXuatBtn.Text = "Đăng xuất";
            this.DangXuatBtn.UseVisualStyleBackColor = false;
            this.DangXuatBtn.Click += new System.EventHandler(this.DangXuatBtn_Click);
            // 
            // tenNguoiDung
            // 
            this.tenNguoiDung.AutoSize = true;
            this.tenNguoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenNguoiDung.Location = new System.Drawing.Point(12, 20);
            this.tenNguoiDung.Name = "tenNguoiDung";
            this.tenNguoiDung.Size = new System.Drawing.Size(57, 25);
            this.tenNguoiDung.TabIndex = 7;
            this.tenNguoiDung.Text = "Tên:";
            // 
            // LamMoiBtn
            // 
            this.LamMoiBtn.Location = new System.Drawing.Point(249, 70);
            this.LamMoiBtn.Name = "LamMoiBtn";
            this.LamMoiBtn.Size = new System.Drawing.Size(101, 25);
            this.LamMoiBtn.TabIndex = 8;
            this.LamMoiBtn.Text = "Làm mới";
            this.LamMoiBtn.UseVisualStyleBackColor = true;
            this.LamMoiBtn.Click += new System.EventHandler(this.LamMoiBtn_Click);
            // 
            // FormTrungTam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 581);
            this.Controls.Add(this.LamMoiBtn);
            this.Controls.Add(this.tenNguoiDung);
            this.Controls.Add(this.DangXuatBtn);
            this.Controls.Add(this.TaoPhongBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.danhSachOnline);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTrungTam";
            this.Text = "Phần mềm chat";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TrungTam_FormClosed);
            this.Load += new System.EventHandler(this.FormTrungTam_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox danhSachOnline;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button TaoPhongBtn;
        private System.Windows.Forms.Button DangXuatBtn;
        private System.Windows.Forms.Label tenNguoiDung;
        private System.Windows.Forms.Button LamMoiBtn;
    }
}