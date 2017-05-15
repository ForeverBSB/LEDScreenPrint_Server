namespace LEDScreenPrint_Server
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.labelNow = new System.Windows.Forms.Label();
            this.labelNowDate = new System.Windows.Forms.Label();
            this.labelNowWeek = new System.Windows.Forms.Label();
            this.labelNowTime = new System.Windows.Forms.Label();
            this.labelFight = new System.Windows.Forms.Label();
            this.labelFightDate = new System.Windows.Forms.Label();
            this.labelFightWeek = new System.Windows.Forms.Label();
            this.labelFightTime = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.ContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.ContextMenuStrip = this.ContextMenu;
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Visible = true;
            // 
            // ContextMenu
            // 
            this.ContextMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmExit});
            this.ContextMenu.Name = "ContextMenu";
            this.ContextMenu.Size = new System.Drawing.Size(270, 86);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(269, 38);
            this.tsmExit.Text = "退出(&X)";
            this.tsmExit.Click += new System.EventHandler(this.tsmExit_Click);
            // 
            // labelNow
            // 
            this.labelNow.AutoSize = true;
            this.labelNow.BackColor = System.Drawing.Color.Transparent;
            this.labelNow.ForeColor = System.Drawing.Color.Red;
            this.labelNow.Location = new System.Drawing.Point(42, 54);
            this.labelNow.Name = "labelNow";
            this.labelNow.Size = new System.Drawing.Size(106, 24);
            this.labelNow.TabIndex = 1;
            this.labelNow.Text = "天文时间";
            this.labelNow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNowDate
            // 
            this.labelNowDate.AutoSize = true;
            this.labelNowDate.BackColor = System.Drawing.Color.Transparent;
            this.labelNowDate.ForeColor = System.Drawing.Color.Red;
            this.labelNowDate.Location = new System.Drawing.Point(42, 104);
            this.labelNowDate.Name = "labelNowDate";
            this.labelNowDate.Size = new System.Drawing.Size(178, 24);
            this.labelNowDate.TabIndex = 1;
            this.labelNowDate.Text = "2017年05月13日";
            this.labelNowDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNowWeek
            // 
            this.labelNowWeek.AutoSize = true;
            this.labelNowWeek.BackColor = System.Drawing.Color.Transparent;
            this.labelNowWeek.ForeColor = System.Drawing.Color.Red;
            this.labelNowWeek.Location = new System.Drawing.Point(42, 152);
            this.labelNowWeek.Name = "labelNowWeek";
            this.labelNowWeek.Size = new System.Drawing.Size(82, 24);
            this.labelNowWeek.TabIndex = 1;
            this.labelNowWeek.Text = "星期日";
            this.labelNowWeek.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNowTime
            // 
            this.labelNowTime.AutoSize = true;
            this.labelNowTime.BackColor = System.Drawing.Color.Transparent;
            this.labelNowTime.ForeColor = System.Drawing.Color.Red;
            this.labelNowTime.Location = new System.Drawing.Point(42, 202);
            this.labelNowTime.Name = "labelNowTime";
            this.labelNowTime.Size = new System.Drawing.Size(154, 24);
            this.labelNowTime.TabIndex = 1;
            this.labelNowTime.Text = "00时00分00秒";
            this.labelNowTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFight
            // 
            this.labelFight.AutoSize = true;
            this.labelFight.BackColor = System.Drawing.Color.Transparent;
            this.labelFight.ForeColor = System.Drawing.Color.Red;
            this.labelFight.Location = new System.Drawing.Point(1894, 54);
            this.labelFight.Name = "labelFight";
            this.labelFight.Size = new System.Drawing.Size(106, 24);
            this.labelFight.TabIndex = 1;
            this.labelFight.Text = "作战时间";
            this.labelFight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFightDate
            // 
            this.labelFightDate.AutoSize = true;
            this.labelFightDate.BackColor = System.Drawing.Color.Transparent;
            this.labelFightDate.ForeColor = System.Drawing.Color.Red;
            this.labelFightDate.Location = new System.Drawing.Point(1894, 104);
            this.labelFightDate.Name = "labelFightDate";
            this.labelFightDate.Size = new System.Drawing.Size(178, 24);
            this.labelFightDate.TabIndex = 1;
            this.labelFightDate.Text = "1900年01月01日";
            this.labelFightDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFightWeek
            // 
            this.labelFightWeek.AutoSize = true;
            this.labelFightWeek.BackColor = System.Drawing.Color.Transparent;
            this.labelFightWeek.ForeColor = System.Drawing.Color.Red;
            this.labelFightWeek.Location = new System.Drawing.Point(1894, 152);
            this.labelFightWeek.Name = "labelFightWeek";
            this.labelFightWeek.Size = new System.Drawing.Size(82, 24);
            this.labelFightWeek.TabIndex = 1;
            this.labelFightWeek.Text = "星期一";
            this.labelFightWeek.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFightTime
            // 
            this.labelFightTime.AutoSize = true;
            this.labelFightTime.BackColor = System.Drawing.Color.Transparent;
            this.labelFightTime.ForeColor = System.Drawing.Color.Red;
            this.labelFightTime.Location = new System.Drawing.Point(1894, 202);
            this.labelFightTime.Name = "labelFightTime";
            this.labelFightTime.Size = new System.Drawing.Size(154, 24);
            this.labelFightTime.TabIndex = 1;
            this.labelFightTime.Text = "23时59分59秒";
            this.labelFightTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("宋体", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTitle.ForeColor = System.Drawing.Color.Red;
            this.labelTitle.Location = new System.Drawing.Point(250, 88);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(1615, 112);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "欢迎各位首长莅临指导我部工作";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(2114, 281);
            this.Controls.Add(this.labelFightTime);
            this.Controls.Add(this.labelFightWeek);
            this.Controls.Add(this.labelNowTime);
            this.Controls.Add(this.labelFightDate);
            this.Controls.Add(this.labelNowWeek);
            this.Controls.Add(this.labelFight);
            this.Controls.Add(this.labelNowDate);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelNow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.ContextMenuStrip ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
        private System.Windows.Forms.Label labelNow;
        private System.Windows.Forms.Label labelNowDate;
        private System.Windows.Forms.Label labelNowWeek;
        private System.Windows.Forms.Label labelNowTime;
        private System.Windows.Forms.Label labelFight;
        private System.Windows.Forms.Label labelFightDate;
        private System.Windows.Forms.Label labelFightWeek;
        private System.Windows.Forms.Label labelFightTime;
        private System.Windows.Forms.Label labelTitle;
    }
}

