namespace RegisterLorry2022
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            pictureBoxCaptcha = new PictureBox();
            txtYzm = new TextBox();
            txtPsw = new TextBox();
            txtName = new TextBox();
            linkLabel1 = new LinkLabel();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            label5 = new Label();
            progressBar1 = new ProgressBar();
            timer1 = new System.Windows.Forms.Timer(components);
            timer2 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCaptcha).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBoxCaptcha);
            panel1.Controls.Add(txtYzm);
            panel1.Controls.Add(txtPsw);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(114, 45);
            panel1.Name = "panel1";
            panel1.Size = new Size(507, 355);
            panel1.TabIndex = 0;
            // 
            // pictureBoxCaptcha
            // 
            pictureBoxCaptcha.Location = new Point(323, 225);
            pictureBoxCaptcha.Name = "pictureBoxCaptcha";
            pictureBoxCaptcha.Size = new Size(140, 32);
            pictureBoxCaptcha.TabIndex = 9;
            pictureBoxCaptcha.TabStop = false;
            pictureBoxCaptcha.Click += pictureBoxCaptcha_Click;
            // 
            // txtYzm
            // 
            txtYzm.Location = new Point(182, 225);
            txtYzm.Name = "txtYzm";
            txtYzm.Size = new Size(135, 27);
            txtYzm.TabIndex = 8;
            // 
            // txtPsw
            // 
            txtPsw.Location = new Point(184, 166);
            txtPsw.Name = "txtPsw";
            txtPsw.PasswordChar = '*';
            txtPsw.Size = new Size(217, 27);
            txtPsw.TabIndex = 7;
            // 
            // txtName
            // 
            txtName.Location = new Point(184, 116);
            txtName.Name = "txtName";
            txtName.Size = new Size(217, 27);
            txtName.TabIndex = 6;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(318, 335);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(189, 20);
            linkLabel1.TabIndex = 5;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "还没有账号？注册一个吧！";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(84, 225);
            label4.Name = "label4";
            label4.Size = new Size(92, 27);
            label4.TabIndex = 4;
            label4.Text = "验证码：";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(98, 164);
            label3.Name = "label3";
            label3.Size = new Size(78, 27);
            label3.TabIndex = 3;
            label3.Text = "密 码：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(15, 114);
            label2.Name = "label2";
            label2.Size = new Size(161, 27);
            label2.TabIndex = 2;
            label2.Text = "用户名/手机号：";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(165, 50);
            label1.Name = "label1";
            label1.Size = new Size(183, 27);
            label1.TabIndex = 1;
            label1.Text = "欢迎来到Lorry之家";
            // 
            // button1
            // 
            button1.Location = new Point(223, 282);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "登录";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.GrayText;
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(69, 27);
            label5.TabIndex = 9;
            label5.Text = "label5";
            // 
            // progressBar1
            // 
            progressBar1.Dock = DockStyle.Bottom;
            progressBar1.Location = new Point(0, 474);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(800, 29);
            progressBar1.TabIndex = 1;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // timer2
            // 
            timer2.Tick += timer2_Tick;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 503);
            Controls.Add(label5);
            Controls.Add(progressBar1);
            Controls.Add(panel1);
            MinimumSize = new Size(550, 550);
            Name = "Login";
            Text = "Form1";
            Load += Form1_Load;
            Resize += Form1_Resize;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCaptcha).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label5;
        private TextBox txtYzm;
        private TextBox txtPsw;
        private TextBox txtName;
        private LinkLabel linkLabel1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button button1;
        private ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private PictureBox pictureBoxCaptcha;
    }
}