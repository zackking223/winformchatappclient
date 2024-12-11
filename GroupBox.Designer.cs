
namespace ChatAppClient
{
    partial class GroupBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupBox));
            this.NgatBtn = new System.Windows.Forms.Button();
            this.GuiBtn = new System.Windows.Forms.Button();
            this.tinNhanBox = new System.Windows.Forms.RichTextBox();
            this.danhSachTinNhan = new System.Windows.Forms.ListBox();
            this.MoiBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.InviteBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // NgatBtn
            // 
            this.NgatBtn.BackColor = System.Drawing.Color.DarkRed;
            this.NgatBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.NgatBtn.Location = new System.Drawing.Point(459, 442);
            this.NgatBtn.Name = "NgatBtn";
            this.NgatBtn.Size = new System.Drawing.Size(106, 40);
            this.NgatBtn.TabIndex = 5;
            this.NgatBtn.Text = "Thoát phòng";
            this.NgatBtn.UseVisualStyleBackColor = false;
            this.NgatBtn.Click += new System.EventHandler(this.NgatBtn_Click);
            // 
            // GuiBtn
            // 
            this.GuiBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.GuiBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.GuiBtn.Location = new System.Drawing.Point(459, 397);
            this.GuiBtn.Name = "GuiBtn";
            this.GuiBtn.Size = new System.Drawing.Size(106, 40);
            this.GuiBtn.TabIndex = 6;
            this.GuiBtn.Text = "Gửi";
            this.GuiBtn.UseVisualStyleBackColor = false;
            this.GuiBtn.Click += new System.EventHandler(this.GuiBtn_Click);
            // 
            // tinNhanBox
            // 
            this.tinNhanBox.Location = new System.Drawing.Point(12, 397);
            this.tinNhanBox.Name = "tinNhanBox";
            this.tinNhanBox.Size = new System.Drawing.Size(441, 86);
            this.tinNhanBox.TabIndex = 4;
            this.tinNhanBox.Text = "";
            this.tinNhanBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tinNhanBox_KeyDown);
            // 
            // danhSachTinNhan
            // 
            this.danhSachTinNhan.FormattingEnabled = true;
            this.danhSachTinNhan.ItemHeight = 16;
            this.danhSachTinNhan.Location = new System.Drawing.Point(12, 58);
            this.danhSachTinNhan.Name = "danhSachTinNhan";
            this.danhSachTinNhan.Size = new System.Drawing.Size(553, 324);
            this.danhSachTinNhan.TabIndex = 3;
            // 
            // MoiBtn
            // 
            this.MoiBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.MoiBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MoiBtn.Location = new System.Drawing.Point(459, 5);
            this.MoiBtn.Name = "MoiBtn";
            this.MoiBtn.Size = new System.Drawing.Size(106, 40);
            this.MoiBtn.TabIndex = 5;
            this.MoiBtn.Text = "Mời";
            this.MoiBtn.UseVisualStyleBackColor = false;
            this.MoiBtn.Click += new System.EventHandler(this.MoiBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mời người dùng";
            // 
            // InviteBox
            // 
            this.InviteBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InviteBox.ForeColor = System.Drawing.Color.Silver;
            this.InviteBox.Location = new System.Drawing.Point(165, 12);
            this.InviteBox.Name = "InviteBox";
            this.InviteBox.Size = new System.Drawing.Size(276, 27);
            this.InviteBox.TabIndex = 8;
            this.InviteBox.Text = "Nhập tên người dùng";
            this.InviteBox.Enter += new System.EventHandler(this.InviteBox_Enter);
            this.InviteBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InviteBox_KeyDown);
            this.InviteBox.Leave += new System.EventHandler(this.InviteBox_Leave);
            // 
            // GroupBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 500);
            this.Controls.Add(this.InviteBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MoiBtn);
            this.Controls.Add(this.NgatBtn);
            this.Controls.Add(this.GuiBtn);
            this.Controls.Add(this.tinNhanBox);
            this.Controls.Add(this.danhSachTinNhan);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GroupBox";
            this.Text = "Nhóm chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GroupBox_FormClosing);
            this.Load += new System.EventHandler(this.GroupBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NgatBtn;
        private System.Windows.Forms.Button GuiBtn;
        private System.Windows.Forms.RichTextBox tinNhanBox;
        private System.Windows.Forms.ListBox danhSachTinNhan;
        private System.Windows.Forms.Button MoiBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InviteBox;
    }
}