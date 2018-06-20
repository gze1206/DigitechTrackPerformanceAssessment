using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TPA
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Resize
            var rectangle = ScreenRectangle();
            Size = new Size(rectangle.Width, rectangle.Height);
            Location = new Point(0, 0);
        }

        public Rectangle ScreenRectangle()
        {
            return Screen.FromControl(this).Bounds;
        }
    }
}
