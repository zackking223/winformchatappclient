
namespace ChatAppClient
{
    partial class FormDangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDangNhap));
            this.label1 = new System.Windows.Forms.Label();
            this.tenDangNhapBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.matKhauBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DangNhapBtn = new System.Windows.Forms.Button();
            this.DangKyBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập";
            // 
            // tenDangNhapBox
            // 
            this.tenDangNhapBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenDangNhapBox.Location = new System.Drawing.Point(194, 98);
            this.tenDangNhapBox.Name = "tenDangNhapBox";
            this.tenDangNhapBox.Size = new System.Drawing.Size(347, 30);
            this.tenDangNhapBox.TabIndex = 1;
            this.tenDangNhapBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormDangNhap_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mật khẩu";
            // 
            // matKhauBox
            // 
            this.matKhauBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matKhauBox.Location = new System.Drawing.Point(194, 170);
            this.matKhauBox.Name = "matKhauBox";
            this.matKhauBox.PasswordChar = '*';
            this.matKhauBox.Size = new System.Drawing.Size(347, 30);
            this.matKhauBox.TabIndex = 2;
            this.matKhauBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormDangNhap_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(223, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "ChatApp";
            // 
            // DangNhapBtn
            // 
            this.DangNhapBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.DangNhapBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DangNhapBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.DangNhapBtn.Location = new System.Drawing.Point(194, 254);
            this.DangNhapBtn.Name = "DangNhapBtn";
            this.DangNhapBtn.Size = new System.Drawing.Size(120, 45);
            this.DangNhapBtn.TabIndex = 3;
            this.DangNhapBtn.Text = "Đăng nhập";
            this.DangNhapBtn.UseVisualStyleBackColor = false;
            this.DangNhapBtn.Click += new System.EventHandler(this.DangNhapBtn_Click);
            // 
            // DangKyBtn
            // 
            this.DangKyBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.DangKyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DangKyBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.DangKyBtn.Location = new System.Drawing.Point(338, 254);
            this.DangKyBtn.Name = "DangKyBtn";
            this.DangKyBtn.Size = new System.Drawing.Size(120, 45);
            this.DangKyBtn.TabIndex = 4;
            this.DangKyBtn.Text = "Đăng ký";
            this.DangKyBtn.UseVisualStyleBackColor = false;
            this.DangKyBtn.Click += new System.EventHandler(this.DangKyBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ChatAppClient.Properties.Resources.chatAppLogo2;
            this.pictureBox1.Location = new System.Drawing.Point(338, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // FormDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 338);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.DangKyBtn);
            this.Controls.Add(this.DangNhapBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.matKhauBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tenDangNhapBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDangNhap";
            this.Text = "Đăng nhập hoặc đăng ký";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tenDangNhapBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox matKhauBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button DangNhapBtn;
        private System.Windows.Forms.Button DangKyBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

