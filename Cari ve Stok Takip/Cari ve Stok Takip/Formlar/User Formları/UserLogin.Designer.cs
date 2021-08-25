
namespace Cari_ve_Stok_Takip
{
    partial class UserLogin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btn_Login = new System.Windows.Forms.Button();
            this.link_UserForgotPWOpen = new System.Windows.Forms.LinkLabel();
            this.link_AdminLoginFormOpen = new System.Windows.Forms.LinkLabel();
            this.link_HowToUse = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(475, 80);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Cari_ve_Stok_Takip.Properties.Resources.Beykent_Universitesi_Logo_Yeni;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 80);
            this.pictureBox1.TabIndex = 89;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Close
            // 
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_Close.ForeColor = System.Drawing.Color.White;
            this.btn_Close.Location = new System.Drawing.Point(444, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(30, 30);
            this.btn_Close.TabIndex = 8;
            this.btn_Close.Text = "X";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(124, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cari ve Stok Takip";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(169, 124);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(193, 26);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(58, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kullanıcı Adı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(115, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Şifre";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(169, 156);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '•';
            this.textBox2.Size = new System.Drawing.Size(193, 26);
            this.textBox2.TabIndex = 3;
            // 
            // btn_Login
            // 
            this.btn_Login.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.btn_Login.FlatAppearance.BorderSize = 3;
            this.btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_Login.ForeColor = System.Drawing.Color.White;
            this.btn_Login.Location = new System.Drawing.Point(119, 204);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(150, 40);
            this.btn_Login.TabIndex = 5;
            this.btn_Login.Text = "Giriş yap";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // link_UserForgotPWOpen
            // 
            this.link_UserForgotPWOpen.ActiveLinkColor = System.Drawing.Color.White;
            this.link_UserForgotPWOpen.AutoSize = true;
            this.link_UserForgotPWOpen.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.link_UserForgotPWOpen.Location = new System.Drawing.Point(275, 219);
            this.link_UserForgotPWOpen.Name = "link_UserForgotPWOpen";
            this.link_UserForgotPWOpen.Size = new System.Drawing.Size(106, 17);
            this.link_UserForgotPWOpen.TabIndex = 6;
            this.link_UserForgotPWOpen.TabStop = true;
            this.link_UserForgotPWOpen.Text = "Şifremi unuttum";
            this.link_UserForgotPWOpen.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_UserForgotPWOpen_LinkClicked);
            // 
            // link_AdminLoginFormOpen
            // 
            this.link_AdminLoginFormOpen.ActiveLinkColor = System.Drawing.Color.White;
            this.link_AdminLoginFormOpen.AutoSize = true;
            this.link_AdminLoginFormOpen.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.link_AdminLoginFormOpen.Location = new System.Drawing.Point(12, 278);
            this.link_AdminLoginFormOpen.Name = "link_AdminLoginFormOpen";
            this.link_AdminLoginFormOpen.Size = new System.Drawing.Size(80, 17);
            this.link_AdminLoginFormOpen.TabIndex = 7;
            this.link_AdminLoginFormOpen.TabStop = true;
            this.link_AdminLoginFormOpen.Text = "Admin girişi";
            this.link_AdminLoginFormOpen.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_AdminLoginFormOpen_LinkClicked);
            // 
            // link_HowToUse
            // 
            this.link_HowToUse.ActiveLinkColor = System.Drawing.Color.White;
            this.link_HowToUse.AutoSize = true;
            this.link_HowToUse.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.link_HowToUse.Location = new System.Drawing.Point(361, 278);
            this.link_HowToUse.Name = "link_HowToUse";
            this.link_HowToUse.Size = new System.Drawing.Size(102, 17);
            this.link_HowToUse.TabIndex = 8;
            this.link_HowToUse.TabStop = true;
            this.link_HowToUse.Text = "Nasıl kullanılır?";
            this.link_HowToUse.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_HowToUse_LinkClicked);
            // 
            // UserLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(475, 304);
            this.Controls.Add(this.link_HowToUse);
            this.Controls.Add(this.link_AdminLoginFormOpen);
            this.Controls.Add(this.link_UserForgotPWOpen);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserLogin";
            this.Load += new System.EventHandler(this.UserLogin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.LinkLabel link_UserForgotPWOpen;
        private System.Windows.Forms.LinkLabel link_AdminLoginFormOpen;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.LinkLabel link_HowToUse;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}