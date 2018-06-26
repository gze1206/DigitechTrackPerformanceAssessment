namespace TPA.Framework.Core
{
    partial class DevConsole
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
            this.console = new System.Windows.Forms.RichTextBox();
            this.commandBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // console
            // 
            this.console.BackColor = System.Drawing.SystemColors.Desktop;
            this.console.Location = new System.Drawing.Point(13, 13);
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.Size = new System.Drawing.Size(775, 394);
            this.console.TabIndex = 1;
            this.console.Text = "";
            // 
            // commandBox
            // 
            this.commandBox.BackColor = System.Drawing.SystemColors.Desktop;
            this.commandBox.ForeColor = System.Drawing.SystemColors.Window;
            this.commandBox.Location = new System.Drawing.Point(12, 413);
            this.commandBox.Name = "commandBox";
            this.commandBox.Size = new System.Drawing.Size(671, 25);
            this.commandBox.TabIndex = 0;
            this.commandBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.commandBox_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(690, 414);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 24);
            this.button1.TabIndex = 2;
            this.button1.Text = "send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DevConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.commandBox);
            this.Controls.Add(this.console);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "DevConsole";
            this.Text = "DevConsole";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DevConsole_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox commandBox;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.RichTextBox console;
    }
}