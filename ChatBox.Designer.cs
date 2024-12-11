
namespace ChatAppClient
{
    partial class ChatBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatBox));
            this.danhSachTinNhan = new System.Windows.Forms.ListBox();
            this.tinNhanBox = new System.Windows.Forms.RichTextBox();
            this.GuiBtn = new System.Windows.Forms.Button();
            this.NgatBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // danhSachTinNhan
            // 
            this.danhSachTinNhan.FormattingEnabled = true;
            this.danhSachTinNhan.ItemHeight = 16;
            this.danhSachTinNhan.Location = new System.Drawing.Point(14, 13);
            this.danhSachTinNhan.Name = "danhSachTinNhan";
            this.danhSachTinNhan.Size = new System.Drawing.Size(553, 324);
            this.danhSachTinNhan.TabIndex = 0;
            // 
            // tinNhanBox
            // 
            this.tinNhanBox.Location = new System.Drawing.Point(14, 353);
            this.tinNhanBox.Name = "tinNhanBox";
            this.tinNhanBox.Size = new System.Drawing.Size(441, 86);
            this.tinNhanBox.TabIndex = 1;
            this.tinNhanBox.Text = "";
            this.tinNhanBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tinNhanBox_KeyDown);
            // 
            // GuiBtn
            // 
            this.GuiBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.GuiBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.GuiBtn.Location = new System.Drawing.Point(461, 353);
            this.GuiBtn.Name = "GuiBtn";
            this.GuiBtn.Size = new System.Drawing.Size(106, 40);
            this.GuiBtn.TabIndex = 2;
            this.GuiBtn.Text = "Gửi";
            this.GuiBtn.UseVisualStyleBackColor = false;
            this.GuiBtn.Click += new System.EventHandler(this.GuiBtn_Click);
            // 
            // NgatBtn
            // 
            this.NgatBtn.BackColor = System.Drawing.Color.DarkRed;
            this.NgatBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.NgatBtn.Location = new System.Drawing.Point(461, 398);
            this.NgatBtn.Name = "NgatBtn";
            this.NgatBtn.Size = new System.Drawing.Size(106, 40);
            this.NgatBtn.TabIndex = 2;
            this.NgatBtn.Text = "Ngắt kết nối";
            this.NgatBtn.UseVisualStyleBackColor = false;
            this.NgatBtn.Click += new System.EventHandler(this.NgatBtn_Click);
            // 
            // ChatBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 448);
            this.Controls.Add(this.NgatBtn);
            this.Controls.Add(this.GuiBtn);
            this.Controls.Add(this.tinNhanBox);
            this.Controls.Add(this.danhSachTinNhan);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChatBox";
            this.Text = "Tên phòng";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatBox_FormClosing);
            this.Load += new System.EventHandler(this.ChatBox_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox danhSachTinNhan;
        private System.Windows.Forms.RichTextBox tinNhanBox;
        private System.Windows.Forms.Button GuiBtn;
        private System.Windows.Forms.Button NgatBtn;
    }
}