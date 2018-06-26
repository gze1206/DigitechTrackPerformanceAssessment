namespace TPA.Custom
{
    partial class MapEditor
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.열기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.맵크기WHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbMapWidth = new System.Windows.Forms.ToolStripTextBox();
            this.tbMapHeight = new System.Windows.Forms.ToolStripTextBox();
            this.새타일생성ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.열기ToolStripMenuItem,
            this.저장ToolStripMenuItem,
            this.새타일생성ToolStripMenuItem,
            this.맵크기WHToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AllowDrop = true;
            this.splitContainer1.Panel1.AutoScroll = true;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Size = new System.Drawing.Size(800, 422);
            this.splitContainer1.SplitterDistance = 267;
            this.splitContainer1.TabIndex = 1;
            // 
            // 열기ToolStripMenuItem
            // 
            this.열기ToolStripMenuItem.Name = "열기ToolStripMenuItem";
            this.열기ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.열기ToolStripMenuItem.Text = "열기";
            this.열기ToolStripMenuItem.Click += new System.EventHandler(this.열기ToolStripMenuItem_Click);
            // 
            // 저장ToolStripMenuItem
            // 
            this.저장ToolStripMenuItem.Name = "저장ToolStripMenuItem";
            this.저장ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.저장ToolStripMenuItem.Text = "저장";
            this.저장ToolStripMenuItem.Click += new System.EventHandler(this.저장ToolStripMenuItem_Click);
            // 
            // 맵크기WHToolStripMenuItem
            // 
            this.맵크기WHToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbMapWidth,
            this.tbMapHeight});
            this.맵크기WHToolStripMenuItem.Name = "맵크기WHToolStripMenuItem";
            this.맵크기WHToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            this.맵크기WHToolStripMenuItem.Text = "맵 크기 (W, H)";
            // 
            // tbMapWidth
            // 
            this.tbMapWidth.Name = "tbMapWidth";
            this.tbMapWidth.Size = new System.Drawing.Size(100, 27);
            this.tbMapWidth.Text = "10";
            this.tbMapWidth.ToolTipText = "맵의 넓이입니다";
            this.tbMapWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMapWidth_KeyPress);
            // 
            // tbMapHeight
            // 
            this.tbMapHeight.Name = "tbMapHeight";
            this.tbMapHeight.Size = new System.Drawing.Size(100, 27);
            this.tbMapHeight.Text = "10";
            this.tbMapHeight.ToolTipText = "맵의 높이입니다";
            this.tbMapHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMapWidth_KeyPress);
            // 
            // 새타일생성ToolStripMenuItem
            // 
            this.새타일생성ToolStripMenuItem.Name = "새타일생성ToolStripMenuItem";
            this.새타일생성ToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.새타일생성ToolStripMenuItem.Text = "새 타일 생성";
            this.새타일생성ToolStripMenuItem.Click += new System.EventHandler(this.새타일생성ToolStripMenuItem_Click);
            // 
            // MapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MapEditor";
            this.Text = "MapEditor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem 열기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 저장ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 맵크기WHToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox tbMapWidth;
        private System.Windows.Forms.ToolStripTextBox tbMapHeight;
        private System.Windows.Forms.ToolStripMenuItem 새타일생성ToolStripMenuItem;
    }
}