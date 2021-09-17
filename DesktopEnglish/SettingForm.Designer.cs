
namespace DesktopEnglish
{
    partial class SettingForm
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
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.lb_tmd = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.lb_tmdx = new System.Windows.Forms.Label();
            this.lb_speed = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_bj = new System.Windows.Forms.Label();
            this.lb_txt = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_tmd
            // 
            this.lb_tmd.AutoSize = true;
            this.lb_tmd.Location = new System.Drawing.Point(53, 71);
            this.lb_tmd.Name = "lb_tmd";
            this.lb_tmd.Size = new System.Drawing.Size(67, 15);
            this.lb_tmd.TabIndex = 4;
            this.lb_tmd.Text = "透明度：";
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(126, 59);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(387, 56);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.Value = 5;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // lb_tmdx
            // 
            this.lb_tmdx.AutoSize = true;
            this.lb_tmdx.Location = new System.Drawing.Point(532, 70);
            this.lb_tmdx.Name = "lb_tmdx";
            this.lb_tmdx.Size = new System.Drawing.Size(15, 15);
            this.lb_tmdx.TabIndex = 6;
            this.lb_tmdx.Text = "5";
            // 
            // lb_speed
            // 
            this.lb_speed.AutoSize = true;
            this.lb_speed.Location = new System.Drawing.Point(53, 127);
            this.lb_speed.Name = "lb_speed";
            this.lb_speed.Size = new System.Drawing.Size(75, 15);
            this.lb_speed.TabIndex = 7;
            this.lb_speed.Text = "切换速度:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Info;
            this.textBox1.Location = new System.Drawing.Point(134, 121);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(71, 25);
            this.textBox1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "秒";
            // 
            // lb_bj
            // 
            this.lb_bj.AutoSize = true;
            this.lb_bj.Location = new System.Drawing.Point(56, 179);
            this.lb_bj.Name = "lb_bj";
            this.lb_bj.Size = new System.Drawing.Size(37, 15);
            this.lb_bj.TabIndex = 10;
            this.lb_bj.Text = "背景";
            // 
            // lb_txt
            // 
            this.lb_txt.AutoSize = true;
            this.lb_txt.Location = new System.Drawing.Point(177, 178);
            this.lb_txt.Name = "lb_txt";
            this.lb_txt.Size = new System.Drawing.Size(37, 15);
            this.lb_txt.TabIndex = 11;
            this.lb_txt.Text = "文字";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "字体";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(102, 223);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(399, 63);
            this.button4.TabIndex = 13;
            this.button4.Text = "字体";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(18, 292);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 46);
            this.button1.TabIndex = 14;
            this.button1.Text = "恢复默认";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(343, 292);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 46);
            this.button2.TabIndex = 15;
            this.button2.Text = "应用";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(459, 292);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(110, 46);
            this.button5.TabIndex = 17;
            this.button5.Text = "取消";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(102, 170);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 38);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(230, 170);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(36, 38);
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_txt);
            this.Controls.Add(this.lb_bj);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lb_speed);
            this.Controls.Add(this.lb_tmdx);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.lb_tmd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "setting";
            this.TopMost = true;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SettingForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SettingForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Label lb_tmd;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lb_tmdx;
        private System.Windows.Forms.Label lb_speed;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_bj;
        private System.Windows.Forms.Label lb_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}