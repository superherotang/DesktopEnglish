
namespace DesktopEnglish
{
    partial class BackForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackForm));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsm_close = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_setting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_pause = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_ukMp3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_usMp3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm_close,
            this.tsm_setting,
            this.tsm_pause,
            this.tsm_ukMp3,
            this.tsm_usMp3,
            this.toolStripSeparator1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowCheckMargin = true;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 130);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // tsm_close
            // 
            this.tsm_close.Name = "tsm_close";
            this.tsm_close.Size = new System.Drawing.Size(138, 24);
            this.tsm_close.Text = "关闭";
            this.tsm_close.Click += new System.EventHandler(this.tsm_close_Click);
            // 
            // tsm_setting
            // 
            this.tsm_setting.Name = "tsm_setting";
            this.tsm_setting.Size = new System.Drawing.Size(138, 24);
            this.tsm_setting.Text = "设置";
            this.tsm_setting.Click += new System.EventHandler(this.tsm_setting_Click);
            // 
            // tsm_pause
            // 
            this.tsm_pause.Name = "tsm_pause";
            this.tsm_pause.Size = new System.Drawing.Size(138, 24);
            this.tsm_pause.Text = "暂停";
            this.tsm_pause.Click += new System.EventHandler(this.tsm_pause_Click);
            // 
            // tsm_ukMp3
            // 
            this.tsm_ukMp3.Name = "tsm_ukMp3";
            this.tsm_ukMp3.Size = new System.Drawing.Size(138, 24);
            this.tsm_ukMp3.Text = "英式发音";
            this.tsm_ukMp3.Click += new System.EventHandler(this.tsm_ukMp3_Click);
            // 
            // tsm_usMp3
            // 
            this.tsm_usMp3.Name = "tsm_usMp3";
            this.tsm_usMp3.Size = new System.Drawing.Size(138, 24);
            this.tsm_usMp3.Text = "美式发音";
            this.tsm_usMp3.Click += new System.EventHandler(this.tsm_usMp3_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(135, 6);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // BackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BackForm";
            this.Text = "BackForm";
            this.TopMost = true;
            this.LocationChanged += new System.EventHandler(this.BackForm_LocationChanged);
            this.Resize += new System.EventHandler(this.BackForm_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsm_close;
        private System.Windows.Forms.ToolStripMenuItem tsm_setting;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem tsm_pause;
        private System.Windows.Forms.ToolStripMenuItem tsm_ukMp3;
        private System.Windows.Forms.ToolStripMenuItem tsm_usMp3;
    }
}